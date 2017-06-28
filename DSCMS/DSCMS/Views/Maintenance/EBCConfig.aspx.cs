using DCISDBManager.objLib.Master;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Maintenance
{
    public partial class EBCConfig : System.Web.UI.Page
    {
        MailSendManager EManager = new MailSendManager();
        static List<objParameters> EPara = new List<objParameters>();

        UserSession userSession;
        CheckAuthManager authorized = new CheckAuthManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            if (userSession == null)
            {
                Response.Redirect("~/Views/Home/Logout.aspx");
            }
            if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "EBCRC"))
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (!IsPostBack)
            {
                getParameters();
            }
        }

        private void getParameters()
        {
            try
            {
                
                EPara = EManager.getALLEBC_EmailParamters();

                txtEmail.Text = EPara[0].Parameter_Value;
                txtPopImapPort.Text = EPara[5].Parameter_Value;
                txtPopIMapSname.Text = EPara[2].Parameter_Value; ;
                txtSMTPName.Text = EPara[3].Parameter_Value;
                txtSMTPPort.Text = EPara[4].Parameter_Value;
                txtEmailP.Text = EPara[0].Parameter_Value;
                drpPopimap.SelectedIndex = drpPopimap.Items.IndexOf(drpPopimap.Items.FindByValue(EPara[6].Parameter_Value));
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            bool result = EManager.setUpdateEBCconfig(EPara[0].Parameter_Code,txtEmail.Text);
            if (!result)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Update the Value</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                getParameters();
            }

        }

        protected void btnImapPopProtocol_Click(object sender, EventArgs e)
        {
            bool result = EManager.setUpdateEBCconfig(EPara[6].Parameter_Code, drpPopimap.SelectedValue);
            if (!result)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Update the Value</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                getParameters();
            }
        }

        protected void btnPopImapServerName_Click(object sender, EventArgs e)
        {
            bool result = EManager.setUpdateEBCconfig(EPara[2].Parameter_Code, txtPopIMapSname.Text);
            if (!result)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Update the Value</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                getParameters();
            }
        }

        protected void IPserverPort_Click(object sender, EventArgs e)
        {
            bool result = EManager.setUpdateEBCconfig(EPara[5].Parameter_Code, txtPopImapPort.Text);
            if (!result)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Update the Value</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                getParameters();
            }
        }

        protected void btnSMTPName_Click(object sender, EventArgs e)
        {
            bool result = EManager.setUpdateEBCconfig(EPara[3].Parameter_Code, txtSMTPName.Text);
            if (!result)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Update the Value</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                getParameters();
            }
        }

        protected void btnSMTPPort_Click(object sender, EventArgs e)
        {
            bool result = EManager.setUpdateEBCconfig(EPara[4].Parameter_Code, txtSMTPPort.Text);
            if (!result)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Update the Value</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
            else
            {
                getParameters();
            }
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtNewpass.Text == "" || txtConfirmPass.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill out the Password Fields Befor Submitting.";
                qu += "<div>";

                PassError.InnerHtml = qu;
            }
            string DECKey = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
            string DecryptID = DECKey.Substring(10);
            //string EncryptPassword = EncDec.Encrypt("gmt47@hotmail.com", DecryptID);
            //string De = EncDec.Decrypt(EncryptPassword, DecryptID);

            if (txtNewpass.Text.Equals(txtConfirmPass.Text))
            {
                string Encrypt = EncDec.Encrypt(txtPassword.Text, DecryptID);
                if (EPara[1].Parameter_Value.Equals(Encrypt))
                {
                    string NewEncrypt = EncDec.Encrypt(txtNewpass.Text, DecryptID);
                    bool result = EManager.setUpdateEBCconfig(EPara[1].Parameter_Code, NewEncrypt);
                    if (!result)
                    {
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Error ! </strong>Unable To Update the Value";
                        qu += "<div>";
                        ErrorMessage.InnerHtml = qu;
                    }
                    else
                    {
                        getParameters();
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Successful ! </strong>Password Changed ";
                        qu += "<div>";

                        PassError.InnerHtml = qu;
                    }
                }
                else
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Incorret Password!";
                    qu += "<div>";

                    PassError.InnerHtml = qu;
                }
            }
            else
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Confirm Passwords Doesn't Match To the New Password !";
                qu += "<div>";

                PassError.InnerHtml = qu;
            }

        }
    }
}