using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;


namespace DSCMS.Views.Home
{
    public partial class EnterEmailAdress : System.Web.UI.Page
    {
        UserSession userSession;
        DownloadCertificate dc = new DownloadCertificate();

        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];

        string host = System.Configuration.ConfigurationManager.AppSettings["HostAddress"];
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {



            UserManager usrM = new UserManager();
            UserSignature Sign = new UserSignature();
            DCISDBManager.objLib.Usr.User adUser = new DCISDBManager.objLib.Usr.User();
            CustomerDetailManager cdm = new CustomerDetailManager();
            DCISDBManager.objLib.Usr.User Usr = new DCISDBManager.objLib.Usr.User();
            DCISDBManager.objLib.Usr.User Usr2 = new DCISDBManager.objLib.Usr.User();

            //  Usr = usrM.getUserLogin(txtUserName.Text, txtPassword.Text);

            string usrIDcheck = txtUserName.Text;



            if (usrM.CheckUserIDAvailability(usrIDcheck) == true)
            {



               // string CustomerID = dc.getCustIDfrmUserID(usrIDcheck);















                var details = usrM.getUserDetails(usrIDcheck, "y", "%","%");

                string email = details.Email_;

                    Random rnd = new Random();
                    int myRandomNo = rnd.Next(10000000, 99999999);

                    adUser.Password_ = myRandomNo.ToString();
                    adUser.User_ID = txtUserName.Text;

                    usrM.ModifyRandomNo(adUser);


                    string a = usrM.getRandomID(usrIDcheck);



                    //   string AdminMsg = "Change your password using " + "http://220.247.222.114/Views/Customer/CustomerRegistration.aspx?Username="+usrIDcheck + "&No="+a+"";
                    string AdminMsg = "Change your password using " +host+ "/Views/User/PasswordChangeemail.aspx?Username=" + usrIDcheck + "&No=" + a + "";

                    sendEmail(AdminMsg, email);




















                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> A password Reset Link is Sent to the Customer Email.Please Check !!!</strong></div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;



                



            }
            else {

                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>The Operation cannot be Continued.This User Name is not Correct</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            
            
            
            }
        }
        private bool sendEmail(string AdminMsg, string ClientEmailaddress)
        {
            string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
            ParameateManager pm = new ParameateManager();
            Parameters cryip = pm.getEmailPassword("EmailPassword");
            string cipherText = cryip.ParameterValue1;
            string AdminEmailaddress = cryip.ParameterDescription1;

            string AdminPassword = Decrypt(cipherText, Key);

            if (ClientEmailaddress == null)
            {
                try
                {


                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);
                }
            }
            try
            {
                string HostName = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
                string Port = System.Configuration.ConfigurationManager.AppSettings["EmailPort"];
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(AdminEmailaddress);
                msg.To.Add(ClientEmailaddress);
                msg.Body = AdminMsg;
                msg.IsBodyHtml = true;
                SmtpClient smpt = new SmtpClient();
                smpt.Host = HostName;
                // smpt.Host = "smtp.mail.yahoo.com";

                System.Net.NetworkCredential net = new System.Net.NetworkCredential();
                net.UserName = AdminEmailaddress;
                net.Password = AdminPassword;
                smpt.UseDefaultCredentials = true;
                smpt.Credentials = net;
                smpt.Port = Convert.ToInt32(Port);
                // smpt.Port = 465;
                smpt.EnableSsl = true;
                smpt.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);


                // EmailManager em = new EmailManager();
                // Email msg = new Email();
                //msg.EmailAddress1 = ClientEmailaddress;
                // msg.EmailBody1 = AdminMsg;
                // checkmailInsert = em.setEmail(msg);
                return false;
            }
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