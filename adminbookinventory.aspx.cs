using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_book;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillAuthorPublisherValues();

            }
            GridView1.DataBind();
        }

        //GO button
        protected void Button3_Click(object sender, EventArgs e)
        {
            goBook();
        }
        //ADD button
        protected void Button1_Click(object sender, EventArgs e)
        {

            if(checkBookExists())
            {
                Response.Write("<script>alert('Book already exists'); </script>");

            }
            else
            {
                addNewBook();
            }
        }
        //Update button
        protected void Button4_Click(object sender, EventArgs e)
        {
            updateBook();
        }
        //DELETE button
        protected void Button5_Click(object sender, EventArgs e)
        {
            deleteBook();
        }


        //Userdefined methods
        //check if book exists
        bool checkBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_table WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                return false;
            }

        }

        //to add author and publisher names
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource= dt;
                DropDownList3.DataValueField= "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }
        }

        //for GO
        void goBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_table WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox1.Text = dr.GetValue(0).ToString();
                        TextBox6.Text = dr.GetValue(1).ToString();
                        TextBox2.Text = dr.GetValue(5).ToString();
                        TextBox8.Text = dr.GetValue(7).ToString();
                        TextBox9.Text = dr.GetValue(8).ToString();
                        TextBox10.Text = dr.GetValue(9).ToString();
                        TextBox3.Text = dr.GetValue(11).ToString().Trim();
                        TextBox11.Text = dr.GetValue(12).ToString().Trim();
                        TextBox4.Text = " "+ (Convert.ToInt32(dr.GetValue(11).ToString().Trim()) - Convert.ToInt32(dr.GetValue(12).ToString().Trim()));
                        TextBox7.Text = dr.GetValue(10).ToString();
                        DropDownList1.SelectedValue= dr.GetValue(6).ToString();
                        DropDownList2.SelectedValue= dr.GetValue(4).ToString();
                        DropDownList3.SelectedValue= dr.GetValue(3).ToString();
                                     
                    
                    }
                    global_actual_stock = Convert.ToInt32(dr.GetValue(11).ToString().Trim());
                    global_current_stock = Convert.ToInt32(dr.GetValue(12).ToString().Trim());
                    global_issued_book = global_actual_stock - global_current_stock;
                    global_filepath= dr.GetValue(0).ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");

                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }
        }

        //Addbook
        void addNewBook()
        {
            try
            {
                //for adding multiple genere
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                //genres= horror,comedy,...

                //for fil upload
                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_table (book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) VALUES (@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock , @book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@edition", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully');</script>");
                GridView1.DataBind();
                //clearForm();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");

            }
        }

        //Upadte Book
        void updateBook()
        {
            if (checkBookExists())
            {
                try
                {
                    //for adding multiple genere
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    //genres= horror,comedy,...

                    //for fil upload
                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;



                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@edition", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", global_actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", global_current_stock.ToString());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    //clearForm();
                    Response.Write("<script>alert('Status Changed'); </script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "'); </script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }


        //delete book
        void deleteBook()
        {
            if (checkBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('book deleted');</script>");
                    clearForm();
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "'); </script>");
                }


            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }


        //clear form
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }
    }
}