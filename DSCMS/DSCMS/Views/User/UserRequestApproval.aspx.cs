using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Email;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.objLib.Parameters;
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
    public partial class UserRequestApproval : System.Web.UI.Page
    {
        UserSession userSession;
        string CustometId = null;
        bool checkmailInsert=true;
        EmailManager em = new EmailManager();
      
        string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
       
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            UserAuthentication();
            if (!this.IsPostBack)
            {
                NewMethod();
             
           
            }
            ErrorPopups();
        }
     

        private string Decrypt(string cipherText,string key)
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

        private void ErrorPopups()
        {
            try{
            string error = Request.QueryString["error"];
            if (error == "1")
            {

                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "  Email Send Fail,Try manualy</div>";


                ErrorMessage.InnerHtml = qu;
            }
            bool checkNetConection = CheckForInternetConnection();

            if (checkNetConection == false)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Warning ! </strong>Server Has No Internet Conection</div>";


                ErrorMessage.InnerHtml = qu;

            }
            else
            {
                Email count=em.getEmailCount();
                if (count.Count1 != 0)
                {
                    lblEmailCount.Text = count.Count1.ToString();
                    divSendMailQue.Visible = true;
                }
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
        }

        private void UserAuthentication()
        {
            try{

            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = userSession.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "UsApp");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }
        private void NewMethod()
        {
            try{
            AddNewExportUserManagement Um = new AddNewExportUserManagement();
            gvUser.DataSource = Um.getUser("P");
            gvUser.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
            
        }



        protected void Approve_Click(object sender, EventArgs e)
        {
           try{
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                int ExpiryDate = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"]);
                AddNewExportUserManagement Um = new AddNewExportUserManagement();
                AddNewExportUser Approve = new AddNewExportUser();

                string reqID=row.Cells[0].Text;
                CustometId=row.Cells[6].Text;
                bool check=false;
                foreach (var Detail in Um.getUser("P")){

                    if (reqID == Detail.UserRequestId1.ToString()) {
                        Approve.Status1 = "A";
                        Approve.IsActive1 = "Y";
                        Approve.UserRequestId1 = Detail.UserRequestId1;
                        Approve.UserID1 = Detail.UserID1;
                        Approve.PersonName1 = Detail.PersonName1;
                        Approve.UserGroupID1 = Detail.UserGroupID1;
                        Approve.Password1 = Detail.Password1;
                        Approve.CreatedBy1 = userSession.User_Id;
                        Approve.CustomerId1 = Detail.CustomerId1;
                        Approve.PassowordExpiryDate1 = DateTime.Now.AddDays(ExpiryDate);

                        check = Um.ApproveUser(Approve);
                    }
                }
                
                
                
                
                if (check == true)
                {
                    string AdminMsg = System.Configuration.ConfigurationManager.AppSettings["UserRequestrApprove"];
                   
                    string ClientEmailaddress = null;
                    
                    sendEmail(AdminMsg, ClientEmailaddress);
                    if(checkmailInsert==false){
                        Response.Redirect("UserRequestApproval.aspx?error=1", false);
                    }
                    else{
                    Response.Redirect("UserRequestApproval.aspx", false);
                    }
                }
                else {
                   
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += "User Approval Failed</div>";


                    ErrorMessage.InnerHtml = qu;
                }
              
            }
           }
           catch (Exception ex)
           {
               ErrorLog.LogError(ex);

           }

        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            try{
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                 txtUserId.Text=row.Cells[0].Text;
                 txtCustomerId.Text= row.Cells[6].Text;
            }
           // RejectUserRequest(sender);
            ReasonsManagement rm = new ReasonsManagement();
            string RejectCat = System.Configuration.ConfigurationManager.AppSettings["ApprovalRejectResonCategory"];
            if (IsPostBack)
            {
                ddRejectReason.DataSource = rm.getRejectReason(RejectCat);
                ddRejectReason.DataTextField = "Reason_Name";
                ddRejectReason.DataValueField = "Reject_Code";
                ddRejectReason.DataBind();
                ddRejectReason.AppendDataBoundItems = false;
            }
            ReasonPop.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }
        protected void Close_btn(object sender, EventArgs e)
        {
            ReasonPop.Visible = false;
        }
        protected void Reject_btn(object sender, EventArgs e)
        {
            RejectUserRequest();
        }

        private void RejectUserRequest()
        {
            try{
            AddNewExportUserManagement Um = new AddNewExportUserManagement();
               AddNewExportUser Approve = new AddNewExportUser();
               Approve.Status1 = "R";
               Approve.RejectReason1 = ddRejectReason.SelectedValue;
            Approve.UserRequestId1 =txtUserId.Text;
                CustometId =txtCustomerId.Text;
                Um.RejectUser(Approve);
                string AdminMsg = System.Configuration.ConfigurationManager.AppSettings["UserRequestrReject"];
                string AdminMsg1 = AdminMsg+",Reson for the Rejection Is:"+ddRejectReason.SelectedItem.Text;
                string ClientEmailaddress = null;
                sendEmail(AdminMsg1, ClientEmailaddress);
                if (checkmailInsert == false)
                {
                   Response.Redirect("UserRequestApproval.aspx?error=1", false);
                }
               else
                {
                    Response.Redirect("UserRequestApproval.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
              
            }
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvUser.PageIndex = e.NewPageIndex;
            NewMethod();
        }


        private bool sendEmail(string AdminMsg,string ClientEmailaddress )
        {
           
            ParameateManager pm = new ParameateManager();
            Parameters cryip = pm.getEmailPassword("EmailPassword");
            string cipherText = cryip.ParameterValue1;
            string AdminEmailaddress = cryip.ParameterDescription1;

            string AdminPassword = Decrypt(cipherText,Key);
            
            
            if (ClientEmailaddress == null)
            {
                try
                {
                    CustomerDetailManager cm = new CustomerDetailManager();
                    CustomerDetails cd = cm.getRequestDetails(CustometId);
                    ClientEmailaddress = cd.Email1;
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
                System.Net.NetworkCredential net = new System.Net.NetworkCredential();
                net.UserName = AdminEmailaddress;
                net.Password = AdminPassword;
                smpt.UseDefaultCredentials = true;
                smpt.Credentials = net;
                smpt.Port = Convert.ToInt32(Port);
                smpt.EnableSsl = true;
                smpt.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

                
                EmailManager em = new EmailManager();
                Email msg = new Email();
                msg.EmailAddress1 = ClientEmailaddress;
                msg.EmailBody1 = AdminMsg;
                checkmailInsert = em.setEmail(msg);
                return false;
                }
            }

        protected void Sendmail_Click(object sender, EventArgs e)
        {
            getEmail();
            divSendMailQue.Visible = false;
           
        }


        private void getEmail()
        {
           try{
            foreach (var msge in em.getEmail())
            {
                string mailMsg = msge.EmailBody1;
                string mailAddress = msge.EmailAddress1;
                int mailId = msge.EmailId1;


                bool chekmail = sendEmail(mailMsg, mailAddress);
                if (chekmail == true)
                {
                    Email email = new Email();
                    email.EmailId1 = mailId;
                    em.deleteMail(email);
                }

            }
           }
           catch (Exception ex)
           {
               ErrorLog.LogError(ex);
              
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

        } 
}