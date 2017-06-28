using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.UserManagement;

namespace DSCMS
{
    public partial class Login : System.Web.UI.Page
    {
        UserSession userSession;
        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        protected void Page_Load(object sender, EventArgs e)
        {
             userSession = new UserSession();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserManager usrM = new UserManager();
            UserSignature Sign = new UserSignature();
            DCISDBManager.objLib.Usr.User Usr = new DCISDBManager.objLib.Usr.User();
            DCISDBManager.objLib.Usr.User Usr2 = new DCISDBManager.objLib.Usr.User();

            Usr = usrM.getUserLogin(txtUserName.Text, txtPassword.Text);

            if (Usr == null)
            {
                string qu = null;
                qu += "<div class=\"alert alert-danger\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Login Faild ! </strong>Incorrect User Name or Password Please Try Again</div>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                userSession.User_Id = Usr.User_ID;
                userSession.User_Group = Usr.UserGroup_ID;
                userSession.Is_Active = Usr.Is_Active;
                // userSession.Is_Vat = Usr.Is_Vat;
                userSession.PasswordExpire_Date = Usr.PassowordExpiry_Date;
                userSession.Person_Name = Usr.Person_Name;


                  if (Usr.UserGroup_ID == UserGroupID_SAdmin)
                   {
                    Sign = usrM.getUserSignatureDetails(Usr.User_ID);

                    if (Sign != null)
                    {
                        userSession.PFX_path = Sign.PFX_path;
                        userSession.SignatureIMG_Path = Sign.SignatureIMG_Path;
                    }
                  }
                  else if ((Usr.UserGroup_ID.Equals(UserGroupID_Customer)) || (Usr.UserGroup_ID.Equals(UserGroupID_CustomerAdmin)))
                  {
                      userSession.Customer_ID = Usr.Customer_ID;
                      Usr2 = usrM.getCustomerTemplate(Usr.Customer_ID);
                      if (Usr2.Template_ID != null)
                      {
                          userSession.Template_ID = Usr2.Template_ID;                         
                          userSession.Customer_Name = Usr2.Customer_Name;
                          userSession.Telephone_ = Usr2.Telephone_;
                      }
                  }

                //Usr = null;
                //Usr2 = null;
                //Sign = null;

                string CheckStatus = Request.QueryString["request"];
                if (CheckStatus != null)
                {
                    if (CheckStatus.Equals("1"))
                    {
                        Response.Redirect("~/Views/Customer/Approval.aspx",false);
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Home/Dashboard.aspx", false);
                }
            }

            //string qu = null;
            //qu += "<div class=\"alert alert-danger\">";
            //qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //qu += " <strong>Login Faild ! </strong> Login Faild !</div>";

            //ErrorMessage.InnerHtml = qu;
        }
    }
}