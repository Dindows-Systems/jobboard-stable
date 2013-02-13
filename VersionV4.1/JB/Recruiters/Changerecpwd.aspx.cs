﻿using System;

namespace JB.Recruiters
{
    public partial class Changerecpwd : Clcookiehandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //set default inputs
            TextBox1.Focus();
            Page.Form.DefaultButton = Button1.UniqueID;

            //read and validate login
            if (Request.QueryString["rand"] != null)
            {
                if (Session["cuserval"].ToString() == Request.QueryString["rand"])
                {
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }

            else
            {
                Response.Redirect("login.aspx");
            }
            ////////////////////////////////////
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cllg = new DlLogins();

            //check passwords is ok first
            if (cllg.Getuser(Session["pusername"].ToString(), TextBox1.Text) != null)
            {
                if (TextBox2.Text == TextBox3.Text)
                {
                    //change pwd
                    cllg.Chgpwdrec(Session["pusername"].ToString(), TextBox2.Text);
                    Session["reasons"] = "Password Changed, please use this from now onwards";
                    Response.Redirect("recconfirm.aspx");
                }

                else
                {
                    Label4.Text = "New Password donot match";
                }
            }

            else
            {
                //check pwd
                Label4.Text = "Please Check your old password";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Recruiters/");
        }
    }
}