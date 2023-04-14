using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //protected const string Obj = "null ";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;     //useer;ogin link button
                    LinkButton2.Visible = true; //signup link button

                    LinkButton3.Visible = false;     //logout link button
                    LinkButton7.Visible = false;    //hello user

                    LinkButton6.Visible = true;    //admin login
                    LinkButton8.Visible = false;    //book inentry
                    LinkButton9.Visible = false;    //book issueing
                    LinkButton10.Visible = false;   //member management
                    LinkButton11.Visible = false;   //author management
                    LinkButton12.Visible = false;   //publisher managemnt
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton6.Visible = true;    //admin login
                    LinkButton8.Visible = false;    //book inentry
                    LinkButton9.Visible = false;    //book issueing
                    LinkButton10.Visible = false;   //member management
                    LinkButton11.Visible = false;   //author management
                    LinkButton12.Visible = false;   //publisher managemnt

                    LinkButton1.Visible = false;     //useer;ogin link button
                    LinkButton2.Visible = false; //signup link button

                    LinkButton3.Visible = true;     //logout link button
                    LinkButton7.Visible = true;    //hello user
                    LinkButton7.Text = "Hello "+ Session["username"].ToString();
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton8.Visible = true;    //book inentry
                    LinkButton9.Visible = true;    //book issueing
                    LinkButton10.Visible = true;   //member management
                    LinkButton11.Visible = true;   //author management
                    LinkButton12.Visible = true;   //publisher managemnt
                    LinkButton6.Visible = false;    //admin login

                    LinkButton1.Visible = false;     //useer;ogin link button
                    LinkButton2.Visible = false; //signup link button

                    LinkButton3.Visible = true;     //logout link button
                    LinkButton7.Visible = true;    //hello user
                    LinkButton7.Text = "Hello Admin " + Session["username"].ToString();
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookissue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        //ViewAll Books
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        //Logout
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Logging Out Your Session');</script>");
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = " ";

            //LinkButton1.Visible = true;     //useer;ogin link button
            //LinkButton2.Visible = true; //signup link button

            //LinkButton3.Visible = false;     //logout link button
            //LinkButton7.Visible = false;    //hello user

            //LinkButton6.Visible = true;    //admin login
            //LinkButton8.Visible = false;    //book inentry
            //LinkButton9.Visible = false;    //book issueing
            //LinkButton10.Visible = false;   //member management
            //LinkButton11.Visible = false;   //author management
            //LinkButton12.Visible = false;   //publisher managemnt

            Response.Redirect("homepage.aspx");
        }
    }
}