using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.ParameterManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Parameters;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using DCISDBManager.trnLib.Utility;

namespace DSCMS.Views.Parameter
{
    public partial class AdminEmailDetail : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
        }

        private void CheckAutentication()
        {
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = userSession.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "MailCon");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ParameateManager pm = new ParameateManager();
                Parameters data = new Parameters();
                string key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
                string pass = Encrypt(txtPassword.Text, key);

                data.ParameterCode1 = "EmailPassword";
                data.ParameterDescription1 = txtEmailAddress.Text;
                data.ParameterValue1 = pass;

                pm.setEmailDetails(data);
                string qu = null;
                qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong>Successfuly Saved,</strong> Confirmation Sucess</div>";
                Msg.InnerHtml = qu;
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Save Fail, Try Agian.</div>";

                Msg.InnerHtml = qu;
            }
        }

        private string Encrypt(string clearText, string key)
        {
            try
            {
                string EncryptionKey = key;
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return null;
            }
        }
    }
}