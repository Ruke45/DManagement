using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Email;
using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DSCMS
{
    public partial class Approval : System.Web.UI.Page
    {
        UserSession userSession;
      
        protected void Page_Load(object sender, EventArgs e)
        {
           userSession = new UserSession();

           

           CheckAutentication();
            if (!this.IsPostBack)
            {
                NewMethod();
            }
            bool checkNetConection=CheckForInternetConnection();
           
            if (checkNetConection == false)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Warning ! </strong>Server Has No Internet Conection</div>";


                ErrorMessage.InnerHtml = qu;

            }
            else {
                try
                {
                    EmailManager em = new EmailManager();
                    Email count = em.getEmailCount();
                    if (count.Count1 != 0)
                    {
                        lblEmailCount.Text = count.Count1.ToString();
                        divSendMailQue.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);
                }
            }
        }

        private void getEmail()
        {
            string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
            try
            {
                
                EmailManager em = new EmailManager();
                foreach (var msge in em.getEmail())
                {
                    string mailMsg = msge.EmailBody1;
                    string mailAddress = msge.EmailAddress1;
                    int mailId = msge.EmailId1;
                    ParameateManager pm = new ParameateManager();
                    Parameters cryip = pm.getEmailPassword("EmailPassword");
                    string cipherText = cryip.ParameterValue1;
                    string AdminEmailAddress = cryip.ParameterDescription1;
                    
                    string password = Decrypt(cipherText, Key);
            
                    //string AdminEmailAddress = System.Configuration.ConfigurationManager.AppSettings["AdminEmailAddress"];
                    //string password = System.Configuration.ConfigurationManager.AppSettings["AdminEmailPassword"];

                    bool chekmail = EmailSender(mailMsg, mailAddress, AdminEmailAddress, password);
                    if (chekmail == true)
                    {
                        Email email = new Email();
                        email.EmailId1 = mailId;
                        em.deleteMail(email);
                    }

                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

        private static bool EmailSender(string mailMsg, string mailAddress, string AdminEmailAddress, string password)
        {
            try
            {
                string HostName = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
                string Port = System.Configuration.ConfigurationManager.AppSettings["EmailPort"];
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(AdminEmailAddress);
                msg.To.Add(mailAddress);
                msg.Body = mailMsg;
                msg.IsBodyHtml = true;
                SmtpClient smpt = new SmtpClient();
                smpt.Host = HostName;
                System.Net.NetworkCredential net = new System.Net.NetworkCredential();
                net.UserName = AdminEmailAddress;
                net.Password = password;
                smpt.UseDefaultCredentials = true;
                smpt.Credentials = net;
                smpt.Port =Convert.ToInt32(Port);
                smpt.EnableSsl = true;
                smpt.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return false;
            }
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void CheckAutentication()
        {
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx?ID=Error");
            }
            try
            {
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "CuApp");
                if (auth == false)
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }
            } 
            catch (Exception ex) {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx?ID=Catch");
            }
        }

        private void NewMethod()
        {
            try{
            CustomerRequestManager rm = new CustomerRequestManager();
            gvExpoter.DataSource = rm.getCustomerRequest("P");
            gvExpoter.DataBind();
            
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Req = gvExpoter.SelectedRow.Cells[0].Text;
          Response.Redirect("CustomerRequestDetails.aspx?ReqID="+Req,false);
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvExpoter.PageIndex = e.NewPageIndex;
            NewMethod();
        }

        protected void Sendmail_Click(object sender, EventArgs e)
        {
            getEmail();
            divSendMailQue.Visible = false;
        }


        private string Decrypt(string cipherText, string key)
        {
            try
            {
                string EncryptionKey = key;

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                return null;
            }
        }
    }
}