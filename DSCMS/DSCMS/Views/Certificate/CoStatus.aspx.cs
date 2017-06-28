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
//      DESCRIPTION  : Change button name and page main header
 
 

//******************************************************************************
 
//  ABSTRACT ( PROGRAM DESCRIPTION )
 
//  ================================
 
//******************************************************************************
 
//*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.ContactManager;
using DCISDBManager.objLib.ContactDetail;
using DCISDBManager.trnLib.EmailManager;

namespace DSCMS.Views.Certificate
{
    public partial class CoStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getContactDetails();
        }

        private void getContactDetails()
        {
            try
            {
                OwnerDetailManagement odm = new OwnerDetailManagement();

                OwnerDetailsobj a = new OwnerDetailsobj();



                var asd = odm.getNCEContactPerson();


                lblName.Text = asd.Name_;
                lblPhoneNo.Text = asd.Telephone_No;
                lblemail.Text = asd.Email_;
                lblFax.Text= asd.Fax_No;
                lblWeb.Text = asd.Web_Address;

              

            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string CertificateNo = txtCertificateNo.Text;
                
                CertificateManager CM = new CertificateManager();
                CertificateRequestHeader CRH = CM.getRequestDetails(CertificateNo);
                // B.CustomerName,A.InvoiceDate,A.Consignee,A.InvoiceNo,A.TotalInvoiceValue
                lblCustomerName.Text = CRH.CustomerName1;
                lblDate.Text = CRH.InvoiceDate1.ToShortDateString();
                lblConsignee.Text = CRH.Consignee1;
                lblInvoiceNo.Text = CRH.InvoiceNo1;
               // lblInvoiceValue.Text = CRH.TotalInvoiceValue1;
                tbl.Visible = true;
                string qu = null;
                if (CRH.CustomerName1 == null)
                {
                    ErrorMessage.Visible = true;
                    tbl.Visible = false;
                    qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += "This document has NOT been authenticated by the National Chamber of Exporters of Sri Lanka (NCE).</div>";


                    ErrorMessage.InnerHtml = qu;

                }
                else {
                    qu = null;
                    ErrorMessage.Visible = true;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += "<center><b><p style='color:black'>This Document has been Authenticated by the NCE.</p></b></center></div>";

                 
                    ErrorMessage.InnerHtml = qu;
                }
            }catch(Exception ex){
                ErrorLog.LogError(ex);
                }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ReasonPop.Visible = true;
        }

        protected void Send_btn(object sender, EventArgs e)
        {
            try
            {
                int errorCount = 0;
                if (txtName.Text == "")
                {
                    Label1.Text = "Name is Required.";
                    Label1.Visible = true;
                    errorCount = errorCount + 1;
                }
                if (txtEmail.Text == "")
                {
                    Label2.Text = "Email Address is Required.";
                    Label2.Visible = true;
                    errorCount = errorCount + 1;
                }
                if (txtPhone.Text == "")
                {
                    Label3.Text = "Phone Number is Required.";
                    Label3.Visible = true;
                    errorCount = errorCount + 1;
                }
                if (TextArea1.InnerText == "")
                {
                    Label4.Text = "Details is Required.";
                    Label4.Visible = true;
                    errorCount = errorCount + 1;
                }

                if (errorCount == 0)
                {
                    ContactFormManger CF = new ContactFormManger();
                    ContactDetail data = new ContactDetail();
                    data.Name1 = txtName.Text;
                    data.Email1 = txtEmail.Text;
                    data.Phone1 = txtPhone.Text;
                    data.Detail1 = TextArea1.InnerText;
                    bool result=CF.setContactFormDetails(data);
                    if (result)
                    {
                        ReasonPop.Visible = false;
                        string qu = null;
                        ErrorMessage.Visible = true;
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += "<h3>Thank you for contacting us.</h3>";
                        qu += "We have received your enquiry and will respond to you very soon. For urgent enquiries please call us on one of the telephone numbers below.</div>";


                        ErrorMessage.InnerHtml = qu;
                        string EmailPerson1 = System.Configuration.ConfigurationManager.AppSettings["Person1Email"];
                     
                       
                    }
                    else {
                        ErrorMessage.Visible = true;
                        tbl.Visible = false;
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += "Sorry....! Your massage send faill</div>";


                        ErrorMessage.InnerHtml = qu;
                    }
                }
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

        protected void Close_btn(object sender, EventArgs e)
        {
            ReasonPop.Visible = false;
        }
    
    }
}