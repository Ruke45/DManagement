using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.UserManagement;

namespace DSCMS.Views.Home
{
    public partial class UserLogin : System.Web.UI.Page
    {
        //UserSession userSession;
        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUserLogin_Click(object sender, EventArgs e)
        {
            UserManager usrM = new UserManager();
            UserSignature Sign = new UserSignature();
            DCISDBManager.objLib.Usr.User LogUser = new DCISDBManager.objLib.Usr.User();
            DCISDBManager.objLib.Usr.User LogUser2 = new DCISDBManager.objLib.Usr.User();

            LogUser = usrM.getUserLogin(txtUserName.Text, txtPassword.Text);

            if (LogUser != null)
            {
                UserSession userSession = new UserSession();
                userSession.User_Id = LogUser.User_ID;
                userSession.User_Group = LogUser.UserGroup_ID;
                userSession.Is_Active = LogUser.Is_Active;
                userSession.PasswordExpire_Date = LogUser.PassowordExpiry_Date;
                userSession.Person_Name = LogUser.Person_Name;

                if (LogUser.UserGroup_ID == UserGroupID_SAdmin)
                {
                    Sign = usrM.getUserSignatureDetails(LogUser.User_ID);

                    if (Sign != null)
                    {
                        userSession.PFX_path = Sign.PFX_path;
                        userSession.SignatureIMG_Path = Sign.SignatureIMG_Path;
                    }
                }
                else if ((LogUser.UserGroup_ID.Equals(UserGroupID_Customer)) || (LogUser.UserGroup_ID.Equals(UserGroupID_CustomerAdmin)))
                {
                    userSession.Customer_ID = LogUser.Customer_ID;
                    LogUser2 = usrM.getCustomerTemplate(LogUser.Customer_ID);
                    if (LogUser2.Template_ID != null)
                    {
                        userSession.Template_ID = LogUser2.Template_ID;
                        userSession.Customer_Name = LogUser2.Customer_Name;
                        userSession.Telephone_ = LogUser2.Telephone_;
                    }
                }
                string qu = null;
                qu += "<div class=\"alert alert-danger\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Login Success </strong>Login Successful *" +userSession.User_Id+"</div>";

                ErrorMessage.InnerHtml = qu;

            }
            else
            {
                string qu = null;
                qu += "<div class=\"alert alert-danger\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Login Faild ! </strong>Incorrect User Name or Password Please Try Again</div>";

                ErrorMessage.InnerHtml = qu;
            }

            //string CheckStatus = Request.QueryString["request"];

            //if (CheckStatus  == "1")
            //{
            //    Response.Redirect("~/Views/Customer/Approval.aspx", false);
            //}
            //else
            //{
            //    Response.Redirect("~/Views/Home/Dashboard.aspx", false);
            //}
        }
    }
}