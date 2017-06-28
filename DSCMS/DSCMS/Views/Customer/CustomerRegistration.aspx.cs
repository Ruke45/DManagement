/*
//PROGRAM-ID.                   CustomerRegistration.cs
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
//      DESCRIPTION  : Remove Customer Admin name.And assign person name for admin name
//      the command is:customerrequest.AdminName1 = txtContactName.Text.ToString();
 
 

//******************************************************************************
 
//  ABSTRACT ( PROGRAM DESCRIPTION )
 
//  ================================
 
//******************************************************************************
 
//*/


using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Email;
using DCISDBManager.objLib.Parameters;
using DCISDBManager.objLib.TaxDetails;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.ExportSectorManagement;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.TaxManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace DSCMS
{
    
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            userSession = new UserSession();
            try
            {
                if (!this.IsPostBack){
                ExportSectorManager Tm = new ExportSectorManager();
                drpExportSector1.DataSource = Tm.getAllExportSector("Y");
                drpExportSector1.DataValueField = "ExportId1";
                drpExportSector1.DataTextField = "ExportSector1";
                drpExportSector1.DataBind();

                drpExportSector2.DataSource = Tm.getAllExportSector("Y");
                drpExportSector2.DataValueField = "ExportId1";
                drpExportSector2.DataTextField = "ExportSector1";
                drpExportSector2.DataBind();

                drpExportSector3.DataSource = Tm.getAllExportSector("Y");
                drpExportSector3.DataValueField = "ExportId1";
                drpExportSector3.DataTextField = "ExportSector1";
                drpExportSector3.DataBind();

                drpExportSector4.DataSource = Tm.getAllExportSector("Y");
                drpExportSector4.DataValueField = "ExportId1";
                drpExportSector4.DataTextField = "ExportSector1";
                drpExportSector4.DataBind();

                drpExportSector5.DataSource = Tm.getAllExportSector("Y");
                drpExportSector5.DataValueField = "ExportId1";
                drpExportSector5.DataTextField = "ExportSector1";
                drpExportSector5.DataBind();
            }
               
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string AdminUserId = UserName.Text.ToString();
                string CustomerName = CustName.Text.ToString();
                string CheckStatus = "A";
                string RejectStatus = "R";
                string pending = "p";
                CustomerRequestManager customerrequestcheck = new CustomerRequestManager();
                CustomerRequest check1 = customerrequestcheck.getAdministratorID(AdminUserId, RejectStatus);
                CustomerRequest check2 = customerrequestcheck.getCustomerName(CustomerName, CheckStatus,pending);
                int nullcount=0;
                if (check2.AdminUserId1 == null) { 
                    nullcount=nullcount+1;
                }
                if (check1.AdminUserId1 == null )
                {
                    nullcount = nullcount+1;
                }
                if (nullcount==2)
                {
                    CustomerRequestManager customerrequestmanager = new CustomerRequestManager();
                    CustomerRequest customerrequest = new CustomerRequest();
                    MailSendManager mail = new MailSendManager();
                    customerrequest.ContactPersonName1 = txtContactName.Text;
                    customerrequest.ContactPersonDesignation1 = txtDesignation.Text;
                    customerrequest.ContactPersonDirectPhoneNumber1 = txtPhoneNumber.Text;
                    customerrequest.ContactPersonMobile1 = txtContactMobile.Text;
                    customerrequest.ContactPersonEmail1 = txtContactEmail.Text;
                    customerrequest.Productdetails1 = txaProducts.InnerText;
                    customerrequest.ExportSector1 = "Have";
                    customerrequest.NCEMember1 = RbtnMember.Text;
                    customerrequest.Name1 = CustName.Text.ToString();
                    customerrequest.Telephone1 = Telephone.Text.ToString();
                    customerrequest.Fax1 = Fax.Text.ToString();
                    customerrequest.Email1 = Email.Text.ToString();
                    customerrequest.Address11 = Address1.Text.ToString();
                    customerrequest.Address21 = Address2.Text.ToString();
                    customerrequest.Address31 = Address3.Text.ToString();
                    string SVATValue = "0";
                    if (rdtax.Text == "Yes")
                    {
                        SVATValue = "1";
                    }
                    customerrequest.SVat1 = SVATValue;
                    customerrequest.AdminName1 = txtContactName.Text.ToString();//change this code 2016/12/05
                    customerrequest.AdminPassword1 = Password.Text.ToString();
                    customerrequest.AdminUserId1 = UserName.Text.ToString();
                    customerrequest.Status1 = "P";
                    customerrequest.TemplateId1 = null;
                    customerrequest.ModifiedBy1 = null;
                    if (userSession.User_Id != "")
                    {
                        customerrequest.CreatedBy1 = userSession.User_Id;
                    }
                    else
                    {
                        customerrequest.CreatedBy1 = "SYSTEM";
                    }
                    customerrequest.RequestId1 = "0";
                   
                    string Admin = UserName.Text.ToString();
                    string reqno = customerrequestmanager.setCustomerRequest(customerrequest);
                    //insert tax data start
                    string TaxCode=null;
                    TextBox RegistrationNo=null;
                     foreach (GridViewRow row in gvTaxRegistration.Rows)
                {

                    TaxCode = row.Cells[0].Text;

                    RegistrationNo = row.FindControl("RegistrationNo") as TextBox;
                    
                         String regNo = RegistrationNo.Text;
                                CustometTaxDetailManager taxmanger = new CustometTaxDetailManager();
                                setCustomerTaxDetails taxdata = new setCustomerTaxDetails();

                                taxdata.CustomerId1 = null;
                                taxdata.RequestId1 = reqno;
                                taxdata.TaxCode1 = TaxCode;
                                taxdata.TaxRegistrationNo1 = regNo;
                                taxdata.CreatedBy1 = userSession.User_Id;
                                taxdata.IsActive1 = "Y";



                                taxmanger.setTaxData(taxdata).ToString();
                            }

                     LetterUpload(reqno);
                    
                    //end insert tax data
                     string sector1=drpExportSector1.SelectedValue;
                     customerrequestmanager.setCustomerExportSector(reqno, sector1, "Y");
                    if(drpExportSector2.SelectedValue !=""){
                         string sector2=drpExportSector2.SelectedValue;
                         customerrequestmanager.setCustomerExportSector(reqno, sector2, "Y");
                    }
                     if(drpExportSector3.SelectedValue !=""){
                          string sector3=drpExportSector3.SelectedValue;
                          customerrequestmanager.setCustomerExportSector(reqno, sector3, "Y");
                    }
                     if(drpExportSector4.SelectedValue !=""){
                          string sector4=drpExportSector4.SelectedValue;
                          customerrequestmanager.setCustomerExportSector(reqno, sector4, "Y");
                    }
                     if (drpExportSector5.SelectedValue != "")
                     {
                          string sector5=drpExportSector5.SelectedValue;
                          customerrequestmanager.setCustomerExportSector(reqno, sector5, "Y");
                         
                    }
                    
                    if (reqno != "")
                    {
                        string AdminMsg = CustName.Text + " has sent a request for a new CO customer registration." + "Use That Link http://220.247.222.114/Views/Home/Login.aspx?request=1";
                        string EmailPerson1 = System.Configuration.ConfigurationManager.AppSettings["Person1Email"];
                        string EmailPerson2 = System.Configuration.ConfigurationManager.AppSettings["Person2Email"];
                        string ContactPersonEmail = null;
                        string NCEAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
                        if (userSession.User_Group != NCEAdmin)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (i == 0)
                                {
                                    ContactPersonEmail = EmailPerson1;
                                }
                                else
                                {
                                    ContactPersonEmail = EmailPerson2;
                                }

                                mail.SendEmail(ContactPersonEmail, "Customer Request",AdminMsg,"");
                            }

                        }
                        Response.Redirect("SelectTemplate.aspx?ReqID=" + reqno, false);
                    }
                }
                if (check1.AdminUserId1 != null)
                {
                    lblUserNameCheck.Visible = true;
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " The Administrator Exists...! Try Another User Name</div>";


                    ErrorMessage1.InnerHtml = qu;
                }
                else
                {
                    string qu = null;
                    ErrorMessage1.InnerHtml = qu;
                    lblUserNameCheck.Visible = false;
                }
                if (check2.AdminUserId1 != null)
                {
                    lblCusCheck.Visible = true;
                    string qu1 = null;
                    qu1 += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu1 += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu1 += " The Customer Exist...! Try Another Company Name</div>";


                    ErrorMessage2.InnerHtml = qu1;
                }
                else
                {
                    string qu1 = null;
                    ErrorMessage2.InnerHtml = qu1;
                    lblCusCheck.Visible = false;
                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);

            }
            }

        private void LetterUpload(string reqno)
        {


            int count = 0;
            string subPath = "~/Letters/"; // your code goes here
            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));
            string RegistrationFileName = null;
            string RequestLetterFileName = null;
            string CustomerId = userSession.Customer_ID;
            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

            if (btnRegistration.HasFile)
            {
                string fileName = Path.GetFileName(btnRegistration.PostedFile.FileName);
                RegistrationFileName = userSession.Customer_ID + fileName;

                btnRegistration.PostedFile.SaveAs(Server.MapPath("~/Letters/") + RegistrationFileName);
                //Response.Redirect(Request.Url.AbsoluteUri);
                count = count + 1;
            }
            else
            {
                
                Label1.Text = "Error Uploading the file. Make sure to select A correct file type";
            }

            if (btnRequest.HasFile)
            {
                string fileName = Path.GetFileName(btnRequest.PostedFile.FileName);
                RequestLetterFileName = userSession.Customer_ID + fileName;
                btnRequest.PostedFile.SaveAs(Server.MapPath("~/Letters/") + RequestLetterFileName);
                count = count + 1;
                //  Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                
                Label2.Text = "Error Uploading the file. Make sure to select A correct file type";
               
            }
            if (count <=1)
            {
                if(RequestLetterFileName==null){
                    RequestLetterFileName = "No";
                }
                if (RegistrationFileName == null)
                {
                    RegistrationFileName="No";
                }
                CustomerRequestManager CRM = new CustomerRequestManager();
               CRM.setCustomerletterPath(RequestLetterFileName, RegistrationFileName, null, reqno,"N");
                string qu = null;
                qu += "<div style='color:green' class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong>Attachment Uploaded Successfuly</strong> </div>";


                ErrorMessage1.InnerHtml = qu;

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
               // MailMessage msg = new MailMessage();
                //msg.From = new MailAddress(AdminEmailAddress);
               // msg.To.Add(ClientEmailaddress);
               // msg.Body = AdminMsg;
              //  msg.IsBodyHtml = true;
               // SmtpClient smpt = new SmtpClient();
              //  smpt.Host = HostName;
               // System.Net.NetworkCredential net = new System.Net.NetworkCredential();
               // net.UserName = AdminEmailAddress;
               // net.Password = AdminPassword;
               // smpt.UseDefaultCredentials = true;
              //  smpt.Credentials = net;
               // smpt.Port = Convert.ToInt32(Port);
              //  smpt.EnableSsl = true;
               // smpt.Send(msg);
                string to = ContactPersonEmail;

                //It seems, your mail server demands to use the same email-id in SENDER as with which you're authenticating. 
                //string from = "sender@domain.com";
                string from = AdminEmailAddress;

                
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

        protected void RbtnMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaxManager tax = new TaxManager();
            if (rdtax.Text == "Yes")
            {
                string svatCode = System.Configuration.ConfigurationManager.AppSettings["VatCode"];
                
                gvTaxRegistration.DataSource = tax.getTaxDetails("Y", svatCode);
                gvTaxRegistration.DataBind();
                
            }
            else {
                gvTaxRegistration.DataSource = tax.getTaxDetails("Y", "0");
                gvTaxRegistration.DataBind();
            }
            UserName.Focus();
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