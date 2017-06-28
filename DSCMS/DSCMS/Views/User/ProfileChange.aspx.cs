using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.trnLib.Utility;

using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;


namespace DSCMS
{
    public partial class ProfileChange : System.Web.UI.Page
    {
        static string DECKey = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
        string Password = DECKey.Substring(12);
        UserSession session;
        UserManager um = new UserManager();
        UserGroupManager ugm = new UserGroupManager();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];

        protected void Page_Load(object sender, EventArgs e)
        {
           
            session = new UserSession();
            if (session.User_Id=="")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }

            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "proc");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            UserID.Text = session.User_Id;
           


        }


        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                //Object a;
                String b = UserID.Text;
                
                string pass = EncDec.Encrypt(OldPassword.Text, Password);
                DCISDBManager.objLib.Usr.User passwordcheck = new DCISDBManager.objLib.Usr.User();

                if (um.CheckUserPasswordMatching(b, pass) == true && um.CheckUserIDAvailability(b)==true)
                {



                    lblErrorPassword.Visible = false;
                    DCISDBManager.objLib.Usr.User adUser = new DCISDBManager.objLib.Usr.User();
                    adUser.User_ID = UserID.Text;
                    adUser.Password_ = NewPassword.Text;
                   // a = um.getUserPassword(adUser.User_ID, "%");
                    /*  foreach (Object value in a)
                      {
                          b = Convert.ToString(value);
                      }*/
                    um.ModifyUserPassword(adUser.User_ID, adUser.Password_);
                    OldPassword.Text = null;
                    UserID.Text = null;
                    string qu = null;
                    qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong>Save Success...!</strong> </div>";

                    ErrorMessage.InnerHtml = qu;
                }
                else {

                    lblErrorPassword.Visible = true;
                
                }
                

            }

            catch (Exception es)
            {


                System.Console.Error.Write(es.Message);

            }

        }
    }
}