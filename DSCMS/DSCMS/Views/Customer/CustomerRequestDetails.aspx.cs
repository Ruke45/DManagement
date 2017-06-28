using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Email;
using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Template;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.TemplateMnangement;
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

    public partial class CustomerRequestDetails : System.Web.UI.Page
    {
        string UserId=null;
        UserSession userSession;
        string regpath = null;
        string reqpath = null;
        bool checkEmailInsert = true;
        string GroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

           CheckAuthentication();
            GetRequestData();
            
        }

        private void GetRequestData()
        {
            try
            {
                UserId = userSession.User_Id;
                string reqe = Request.QueryString["ReqID"];
                CustomerRequestManager rm = new CustomerRequestManager();

                CustomerRequest requst = rm.getRequestDetails(reqe);

                lblRequestID.Text = reqe;
                lblCustomerName.Text = requst.Name1;
                lblAddress.Text = requst.Address11;
                lblAddress2.Text = requst.Address21;
                lblAddress3.Text = requst.Address31;
              
                lblTelephone.Text = requst.Telephone1;
                lblFax.Text = requst.Fax1;
                lblEmail.Text = requst.Email1;
                lblContactPerson.Text = requst.ContactPersonName1;
                lblAdminUser.Text = requst.AdminUserId1;
                lblAdminPassword.Text = requst.AdminPassword1;
                lblPersonDesignation.Text = requst.ContactPersonDesignation1;
                lblPersonPhoneNumber.Text = requst.ContactPersonDirectPhoneNumber1;
                lblContactPersonMobile.Text = requst.ContactPersonMobile1;
                lblContactPersonEmail.Text = requst.ContactPersonEmail1;
                lblProductDetails.Text = requst.Productdetails1;
                Session["RegPath"] = regpath = "../../Letters/" +requst.RegFilePath1;
                Session["ReqPath"] = reqpath = "../../Letters/" + requst.ReqFilePath1;
                if (requst.SVat1 == "1")
                {
                    lblSvat.Text = "SVAT Customer";
                }
                else {
                    lblSvat.Text = "VAT Customer";
                }
                
                lblExportSectorId.Text = reqe;
                lblNCEMember.Text = requst.NCEMember1;
                lblAdminName.Text = requst.AdminName1;
                string ExSector=null;
                foreach (var sector in rm.getRequestExportSector(reqe))
                {
                    ExSector += sector.ExportSector1+",";
                }
                lblExportSector.Text = ExSector;
                CustomerTemplateManager tm = new CustomerTemplateManager();
                if (requst.TemplateId1 == "" || requst.TemplateId1==null)
                {
                    drpTemplateId.Visible = true;


                    drpTemplateId.DataSource = tm.getTemplate("Y");
                    drpTemplateId.DataValueField = "TemplateId1";
                    drpTemplateId.DataTextField = "TemplateName1";
                    drpTemplateId.DataBind();
                    lblTemplateError.Visible = true;

                }
                else
                {
                    foreach (var template in tm.getTemplate("Y"))
                    {
                        lblTemplateName.Visible = true;
                        if (requst.TemplateId1 == template.TemplateId1)
                        {
                            lblTemplateName.Text = template.TemplateName1;
                        }
                    }

                    lblTemplateId.Text = requst.TemplateId1;
                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
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
            catch (Exception ex) {
                ErrorLog.LogError(ex);
                return null;
            }
        }


        private void CheckAuthentication()
        {
            try
            {
                if (userSession.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
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
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }

        protected void Apporve(object sender, EventArgs e)
        {
            try
            {

                CustomerApproveManager customermanager = new CustomerApproveManager();
                CustomerApproved Cusdetail = new CustomerApproved();
                MailSendManager mail = new MailSendManager();
                int ExpiryDate = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"]);

                Cusdetail.UserID1 = lblAdminUser.Text.ToString();
                Cusdetail.UserGroupID1 = GroupId;
                Cusdetail.Admin1 = lblAdminName.Text.ToString();
                Cusdetail.Password1 = lblAdminPassword.Text.ToString();
                Cusdetail.CreatedBy1 = userSession.User_Id;
                Cusdetail.IsActive1 = "Y";
                Cusdetail.PassowordExpiryDate1 = DateTime.Now.AddDays(ExpiryDate);
                if (lblTemplateId.Text == "")
                {
                    Cusdetail.TemplateId1 = drpTemplateId.SelectedValue;
                }
                else
                {
                    Cusdetail.TemplateId1 = lblTemplateId.Text;
                }
                Cusdetail.CustomerName1 = lblCustomerName.Text;
                Cusdetail.Telephone1 = lblTelephone.Text;
                string svat="0";
                if(lblSvat.Text=="SVAT Customer"){
                    svat="1";
                }
                Cusdetail.IsSVat1 = svat;
                Cusdetail.Fax1 = lblFax.Text;
                Cusdetail.Email1 = lblEmail.Text;
                Cusdetail.Address11 = lblAddress.Text;
                Cusdetail.Address21 = lblAddress2.Text;
                Cusdetail.Address31 = lblAddress3.Text;
                Cusdetail.Status1 = "A";

                Cusdetail.ContactPersonName1 = lblContactPerson.Text;
                Cusdetail.ContactPersonDesignation1 = lblPersonDesignation.Text;
                Cusdetail.ContactPersonDirectPhoneNumber1 = lblPersonPhoneNumber.Text;
                Cusdetail.ContactPersonMobile1 = lblContactPersonMobile.Text;
                Cusdetail.ContactPersonEmail1 = lblContactPersonEmail.Text;
                Cusdetail.Productdetails1 = lblProductDetails.Text;
                Cusdetail.requestNo1 = lblExportSectorId.Text;
                Cusdetail.NCEMember1 = lblNCEMember.Text;
                Cusdetail.Admin1 = lblAdminName.Text;
               
                String CusID = customermanager.setUserDetails(Cusdetail);
                if (CusID != null)
                {
                    string AdminMsg1 = System.Configuration.ConfigurationManager.AppSettings["CustomeRequestrApprove"];
                    string AdminMsg = AdminMsg1 +"Your Customer Code is:-"+ CusID;
                    mail.SendEmail(lblContactPersonEmail.Text, "Customer Request", AdminMsg, "");
                    if (checkEmailInsert == false)
                    {
                       
                        Response.Redirect("CustomerFinanceData.aspx?CusId=" + CusID + "&error=1", false);
                    }
                    else {
                    
                        Response.Redirect("CustomerFinanceData.aspx?CusId=" + CusID + "&error=1", false);
                    }
                }
                else
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Customer Approval Process Failed</div>";


                    ErrorMessage.InnerHtml = qu;

                   

                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("Approval.aspx");
            }
        }

        private void sendEmail(string AdminMsg)
        {
            string ClientEmailaddress = lblContactPersonEmail.Text;

            ParameateManager pm = new ParameateManager();
            Parameters cryip = pm.getEmailPassword("EmailPassword");
            string password = cryip.ParameterValue1;
            string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
            string AdminPassword = Decrypt(password, Key);
            string AdminEmailAddress=cryip.ParameterDescription1;
            

            try
            {
                string HostName = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
                string Port = System.Configuration.ConfigurationManager.AppSettings["EmailPort"];
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(AdminEmailAddress);
                msg.To.Add(ClientEmailaddress);
                msg.Body = AdminMsg;
                msg.IsBodyHtml = true;
                SmtpClient smpt = new SmtpClient();
                smpt.Host = HostName;
                System.Net.NetworkCredential net = new System.Net.NetworkCredential();
                net.UserName = AdminEmailAddress;
                net.Password = AdminPassword;
                smpt.UseDefaultCredentials = true;
                smpt.Credentials = net;
                smpt.Port = Convert.ToInt32(Port);
                smpt.EnableSsl = true;
                smpt.Send(msg);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);


                EmailManager em = new EmailManager();
                Email msg = new Email();
                msg.EmailAddress1 = ClientEmailaddress;
                msg.EmailBody1 = AdminMsg;
                bool checkEmailInsert = em.setEmail(msg);
              
            }
        }
        

        protected void Button3_Click(object sender, EventArgs e)
        {
            try{
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

            }
        }
        protected void Close_btn(object sender, EventArgs e) {
            ReasonPop.Visible = false;
        }
        protected void Reject_btn(object sender, EventArgs e) {
             RejectRequest();
        }
        private void RejectRequest()
        {
            try{
            CustomerRequestManager customerrequestmanager = new CustomerRequestManager();
            CustomerRequest customerrequest = new CustomerRequest();
            customerrequest.Status1 = "R";
            customerrequest.RejectReason1 = ddRejectReason.SelectedValue;
            customerrequest.CreatedBy1 = UserId;
            customerrequest.RequestId1 = lblRequestID.Text.ToString();

            bool check = customerrequestmanager.setApproveCustomer(customerrequest);
            if (check == true)
            {
                string AdminMsg = System.Configuration.ConfigurationManager.AppSettings["CustomeRequestrReject"];
                string AdminMsg1 = AdminMsg + ddRejectReason.SelectedItem.Text;
               // sendEmail(AdminMsg1);
                MailSendManager mail = new MailSendManager();
                mail.SendEmail(lblContactPersonEmail.Text, "Customer Request", AdminMsg1, "");
            }
            if (checkEmailInsert == false)
            {
                Response.Redirect("Approval.aspx?error=1", false);
            }
            else
            {
                Response.Redirect("Approval.aspx");
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Approval.aspx");
        }

        protected void btnreg_Click(object sender, EventArgs e)
        {
            try
            {
                Session["PDFUrl"] = Session["RegPath"].ToString();
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void btnreq_Click(object sender, EventArgs e)
        {
            try
            {
                Session["PDFUrl"] = Session["ReqPath"].ToString();
                string pageurl = "../Certificate/PdfView.aspx";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }
    }
}