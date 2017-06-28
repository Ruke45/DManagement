/*
//PROGRAM-ID.                   SelectTemplate.cs
//AUTHOR.                             Nipun Munipura
//COMPANY.                         VOTRE IT (Pvt.) Ltd.
 
//DATE-WRITTEN.                                2016-11-08
 
//Version.                               1.0.0
 
//*******************************************************************************
 
//                                Copyright(c) 2016-2017 VOTRE IT Pvt Ltd
 
//                                                        ALL RIGHTS RESERVED
 
//*******************************************************************************
 
//This software is the confidential and proprietary information of VOTRE IT Pvt. Ltd.
 
//("Confidential Information").
 
//You shall not disclose such Confidential Information and shall use it only in
 
//accordance with the terms of the license agreement you entered into with VOTRE IT.
 
//*******************************************************************************
 
//AMENDMENT HISTORY.
 
//===================
 
//  1.  PROGRAMMER   : NIPUN MUNIPURA
 
//      DATE         : 2016-Dec-05
//      Version             : 1.0.1
//      DESCRIPTION  : hide 3 template for Customer,but all template can show for Admin
 //     the command is:string NCEAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
            if (userSession.User_Group == NCEAdmin){}
 // else{}
 

//******************************************************************************
 
//  ABSTRACT ( PROGRAM DESCRIPTION )
 
//  ================================
 
//******************************************************************************
 
//*/





using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Email;
using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.Template;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.TemplateMnangement;
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

namespace DSCMS
{
   
    public partial class SelectTemplate : System.Web.UI.Page
    {
        string ReqId = null;
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
        

            ReqId = Request.QueryString["ReqID"];
            if (ReqId == "" || ReqId==null)
            {
                Response.Redirect("CustomerRegistration.aspx", false);
            }
            GetDataItem1();
        }

      

        public void GetDataItem1() {
            try{
            string Status = "Y";
            string divId = null;
            string divTab = null;

            CustomerTemplateManager rm = new CustomerTemplateManager();
            int brcount = 0;
                //Change this code for Show All templates for Administrator
                //Date 2016/12/05
            string NCEAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
            if (userSession.User_Group == NCEAdmin){
                foreach (var requst in rm.getTemplate(Status))
                {
                    if (brcount == 0)
                    {
                        divId += "<div class='row'>";
                    }
                    divId += "<div  class='col-md-4 col-sm-4 col-xs-6'><a  type='button' class='active' data-toggle='tab'  data-parent='#accordion'  href='#" + requst.TemplateId1 + "'><img src='../../" + requst.ImgUrl1 + "'  class='img-responsive templateimg'  alt='Cinque Terre' width='304' style='position:relative'></a>" + requst.TemplateName1 + "</div>";
                    divTab += "<div style='border-bottom: solid;padding-bottom: 50px;' id='" + requst.TemplateId1 + "' class='tab-pane fade'><h3>Template Detail About " + requst.TemplateName1 + "</h3>";
                    divTab += "" + requst.Discription1 + "<img src='../../" + requst.ImgUrl1 + "'  class='img-responsive'  alt='Cinque Terre' width='500'  style='position:relative;max-height: 420px;'>";
                    divTab += "<div style='height:30px'></div><div class='form-group'><div class='col-sm-6'>";
                    divTab += "<a class='btn btn-primary' href='/Views/Customer/SelectTemplate.aspx?temp=" + requst.TemplateId1 + "&ReqId=" + ReqId + "' '>Select</a>";

                    divTab += "</div></div></div>";

                    brcount++;
                    if (brcount == 3)
                    {
                        divId += "</div>";
                        brcount = 0;
                    }
                }
               
                head.InnerHtml = divId;
               detail.InnerHtml = divTab;
            }
            else
            {
                //Change this code for hide 3 templates for Customer
                //Date 2016/12/05
                string templateId1 = System.Configuration.ConfigurationManager.AppSettings["MASSACTIVE"];
                string templateId2 = System.Configuration.ConfigurationManager.AppSettings["NINDROTMP"];
                string templateId3 = System.Configuration.ConfigurationManager.AppSettings["GOLOBALTMP"];
                foreach (var requst in rm.getTemplate(Status))
                {
                    if (templateId1 != requst.TemplateId1 && templateId2 != requst.TemplateId1 && templateId3 != requst.TemplateId1)
                    {
                    if (brcount == 0)
                    {
                        divId += "<div class='row'>";
                    }
                    divId += "<div  class='col-md-4 col-sm-4 col-xs-6'><a  type='button' class='active' data-toggle='tab'  data-parent='#accordion'  href='#" + requst.TemplateId1 + "'><img src='../../" + requst.ImgUrl1 + "'  class='img-responsive templateimg'  alt='Cinque Terre' width='304' style='position:relative'></a>" + requst.TemplateName1 + "</div>";
                    divTab += "<div style='border-bottom: solid;padding-bottom: 50px;' id='" + requst.TemplateId1 + "' class='tab-pane fade'><h3>Template Detail About " + requst.TemplateName1 + "</h3>";
                    divTab += "" + requst.Discription1 + "<img src='../../" + requst.ImgUrl1 + "'  class='img-responsive'  alt='Cinque Terre' width='500'  style='position:relative;'>";
                    divTab += "<div style='height:30px'></div><div class='form-group'><div class='col-sm-6'>";
                    divTab += "<a class='btn btn-primary' href='/Views/Customer/SelectTemplate.aspx?temp=" + requst.TemplateId1 + "&ReqId=" + ReqId + "' '>Select</a>";

                    divTab += "</div></div></div>";

                    brcount++;
                    if (brcount == 3)
                    {
                        divId += "</div>";
                        brcount = 0;
                    }
                    }
                }

                head.InnerHtml = divId;
                detail.InnerHtml = divTab;
            }
           


           string temp = Request.QueryString["temp"];
           string ReqID = Request.QueryString["ReqId"];
           if (ReqID != null && temp != null)
           {
               selectTemplate(ReqID, temp);
           }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }

        protected void selectTemplate(string user,string temp)
        {
            try{
            CustomerRequestManager customerrequestmanager = new CustomerRequestManager();
            CustomerRequest selecttemplate = new CustomerRequest();

            selecttemplate.RequestId1 = user;
            selecttemplate.TemplateId1 = temp;
            if (user == "" || temp == "")
            {
                Label1.Visible = true;
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Save Fail, Try Agian.</div>";


                ErrorMessage.InnerHtml = qu;
            }
            else {
                bool save = customerrequestmanager.setTemplate(selecttemplate);
                if (save == false)
                {
                    Label1.Visible = true;
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Save Fail, Try Agian.</div>";


                    ErrorMessage.InnerHtml = qu;
                }
                else {
                    string NCEAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
                    if (userSession.User_Group == NCEAdmin)
                    {
                        string RequestId = null;
                        string CustomerName = null;
                        string Address1 = null;
                        string Address2 = null;
                        string Address3 = null;
                        string Telephone = null;
                        string Fax = null;
                        string Email = null;
                        string Admin = null;
                        string svat = null;
                        string AdminUser = null;
                        string AdminPassword = null;
                        string TemplateId = null;
                        string UserId = null;
                        string NCEMember = null;
                        string ContactPersonName= null;
                        string ContactPersonDesignation= null;
	                    string ContactPersonDirectPhoneNumber= null;
                        string ContactPersonMobile= null;
                        string ContactPersonEmail= null;
                        string Productdetails= null;
                        string ExportSector= null;
                        string GroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];

                        GetCustomerData(ref RequestId, ref CustomerName, ref Address1, ref Address2, ref Address3, ref Telephone, ref Fax, ref Email, ref Admin, ref AdminUser, ref AdminPassword, ref TemplateId, ref UserId, ref NCEMember, ref ContactPersonName, ref ContactPersonDesignation, ref ContactPersonDirectPhoneNumber, ref ContactPersonMobile, ref ContactPersonEmail, ref Productdetails, ref ExportSector, ref svat);
                        string CustomerId = SetApproveData(CustomerName, Address1, Address2, Address3, Telephone, Fax,
                            Email, AdminPassword, TemplateId, UserId, ContactPersonName, GroupId, AdminUser,
                            ContactPersonDesignation, ContactPersonDirectPhoneNumber, ContactPersonMobile, ContactPersonEmail, Productdetails
                           , ExportSector, NCEMember, Admin, svat);
                        string AdminMsg1 = System.Configuration.ConfigurationManager.AppSettings["CustomeRequestrApprove"];
                        string AdminMsg = AdminMsg1 + "Your Customer Code is:-" + CustomerId;
                        sendEmail(AdminMsg, ContactPersonEmail);
                       Response.Redirect("~/Views/Customer/CustomerFinanceData.aspx?CusId=" + CustomerId + "", false);
                    }
                    string qu = null;
                    qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong>Successfuly Saved,</strong> Confirmation Email will be Sent Once Confirmed</div>";


                    ErrorMessage.InnerHtml = qu;
                    head.Visible = false;
                }
               
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
           
        }

        private void sendEmail(string AdminMsg, string ContactPersonEmail)
        {
            string ClientEmailaddress = ContactPersonEmail;

            ParameateManager pm = new ParameateManager();
            Parameters cryip = pm.getEmailPassword("EmailPassword");
            string password = cryip.ParameterValue1;
            string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
            string AdminPassword = Decrypt(password, Key);
            string AdminEmailAddress = cryip.ParameterDescription1;


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

        private void GetCustomerData(ref string RequestId, ref string CustomerName, ref string Address1, ref string Address2, ref string Address3, ref string Telephone, ref string Fax, ref string Email, ref string Admin, ref string AdminUser, ref string AdminPassword, ref string TemplateId, ref string UserId, ref string NCEMember, ref string ContactPersonName, ref string ContactPersonDesignation, ref string ContactPersonDirectPhoneNumber, ref string ContactPersonMobile, ref string ContactPersonEmail, ref string Productdetails, ref string ExportSector, ref string svat)
        {
            try
            {
                UserId = userSession.User_Id;
                string reqe = Request.QueryString["ReqID"];
                CustomerRequestManager rm = new CustomerRequestManager();

                CustomerRequest requst = rm.getRequestDetails(reqe);

                RequestId = reqe;
                CustomerName = requst.Name1;
                Address1 = requst.Address11;
                Address2 = requst.Address21;
                Address3 = requst.Address31;

                Telephone = requst.Telephone1;
                Fax = requst.Fax1;
                Email = requst.Email1;
                Admin = requst.AdminName1;
                AdminUser = requst.AdminUserId1;
                AdminPassword = requst.AdminPassword1;
                TemplateId = requst.TemplateId1;
                ContactPersonName = requst.ContactPersonName1;
                ContactPersonDesignation = requst.ContactPersonDesignation1;
                ContactPersonDirectPhoneNumber = requst.ContactPersonDirectPhoneNumber1;
                ContactPersonMobile = requst.ContactPersonMobile1;
                ContactPersonEmail = requst.ContactPersonEmail1;
                Productdetails = requst.Productdetails1;
                ExportSector = reqe;
                NCEMember = requst.NCEMember1;
                svat = requst.SVat1;

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        private string SetApproveData(string CustomerName, string Address1, string Address2, string Address3, string Telephone, string Fax, string Email, string AdminPassword, string TemplateId, string UserId, string ContactPersonName, string GroupId, string AdminUser,
            string ContactPersonDesignation, string ContactPersonDirectPhoneNumber, string ContactPersonMobile,
            string ContactPersonEmail, string Productdetails, string ExportSector, string NCEMember, string Admin, string svat)
        {
            try
            {

                CustomerApproveManager customermanager = new CustomerApproveManager();
                CustomerApproved Cusdetail = new CustomerApproved();

                int ExpiryDate = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"]);

                Cusdetail.UserID1 = AdminUser;
                Cusdetail.UserGroupID1 = GroupId;
                Cusdetail.Password1 = AdminPassword;
                Cusdetail.CreatedBy1 = userSession.User_Id;
                Cusdetail.IsActive1 = "Y";
                Cusdetail.PassowordExpiryDate1 = DateTime.Now.AddDays(ExpiryDate);
                Cusdetail.TemplateId1 = TemplateId;
                Cusdetail.CustomerName1 = CustomerName;
                Cusdetail.Telephone1 = Telephone;
                Cusdetail.IsSVat1 = svat;
                Cusdetail.Fax1 = Fax;
                Cusdetail.Email1 = Email;
                Cusdetail.Address11 = Address1;
                Cusdetail.Address21 = Address2;
                Cusdetail.Address31 = Address3;
                Cusdetail.Status1 = "A";
                Cusdetail.ContactPersonName1 = ContactPersonName;
                Cusdetail.ContactPersonDesignation1=ContactPersonDesignation;
                Cusdetail.ContactPersonDirectPhoneNumber1 = ContactPersonDirectPhoneNumber;
                Cusdetail.ContactPersonMobile1=ContactPersonMobile;
                Cusdetail.ContactPersonEmail1 = ContactPersonEmail;
                Cusdetail.Productdetails1=Productdetails;
                Cusdetail.requestNo1 = ExportSector;
                Cusdetail.NCEMember1 = NCEMember;
                Cusdetail.Admin1 = Admin;
                String CusID = customermanager.setUserDetails(Cusdetail);

                return CusID;



            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("Approval.aspx");
                return null;
            }
        }

       
      
    }
}