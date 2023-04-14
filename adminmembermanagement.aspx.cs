using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class membermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //Go button
        protected void Button3_Click(object sender, EventArgs e)
        {
            goMember();
        }

        //green Active
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateStatus("active");
        }

        //yellow pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateStatus("pending");
        }

        // red deactive
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateStatus("deactive");
        }

        //delete user permamnently
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                deleteUser();
            }
            else
            {
                Response.Write("<script>alert('Member does not exists');</script>");
            }

        }


        //Go button
        void goMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox6.Text = dr.GetValue(0).ToString();
                        TextBox2.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(1).ToString();
                        TextBox9.Text = dr.GetValue(2).ToString();
                        TextBox10.Text = dr.GetValue(3).ToString();
                        TextBox3.Text = dr.GetValue(4).ToString();
                        TextBox11.Text = dr.GetValue(5).ToString();
                        TextBox4.Text = dr.GetValue(6).ToString();
                        TextBox7.Text = dr.GetValue(7).ToString();
                        //TextBox2.Text = dr.GetValue(0).ToString();
                    }
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

        //Update status to active
        void updateStatus(string status)
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearForm();
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

        //clear form
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
        }

        //delete user
        void deleteUser()
        {
            if (checkMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member deleted');</script>");
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
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
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
    }
}