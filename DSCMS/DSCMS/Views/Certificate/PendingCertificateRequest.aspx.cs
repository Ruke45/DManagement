using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.SupportDocumentSignManagement;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.trnLib.ParameterManagement;
using System.Net.Mail;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using DCISDBManager.objLib.Parameters;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.EmailManager;

namespace DSCMS
{
    public partial class ViewCertificaterRequest : System.Web.UI.Page
    {
        UserSession userSession;
        CertificateRequestHeader ReqH = new CertificateRequestHeader();
        CertificateRequestManager CRmanager = new CertificateRequestManager();
        SDocSignRequsetManager SDSignMngr = new SDocSignRequsetManager();
        CustomerDetailManager cdm = new CustomerDetailManager();
        OwnerDetailManagement od = new OwnerDetailManagement();
        MailSendManager mail = new MailSendManager();

        static List<SupportingDocUpload> SupList = new List<SupportingDocUpload>();

        string SADMIN_Email = System.Configuration.ConfigurationManager.AppSettings["SAdminEmailAddress"];
        string Pending_Email = System.Configuration.ConfigurationManager.AppSettings["requestEmailAddress1"];
        string Pending_Email2 = System.Configuration.ConfigurationManager.AppSettings["requestEmailAddress2"];
        string Customer_GropID = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string SAdmin_GropID = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            if (!IsPostBack)
            {
                getCertificatRequests();
                getPendingRequest();
                getPendingSDRequest();
                getPendingWEBRequest();
            }
        }

        protected void getCertificatRequests()
        {
            if (userSession.User_Group == Customer_GropID || userSession.User_Group == UserGroupID_CustomerAdmin)
            {
                gvPendigCR.DataSource = CRmanager.getRequestedCertificates(userSession.Customer_ID, "P").CertificateRequestsList;
                gvPendigCR.DataBind();
            }
            //else if (userSession.User_Group == SAdmin_GropID)
            //{
            //    gvPendigCR.DataSource = CRmanager.getRequestedCertificates("%", "P").CertificateRequestsList;
            //    gvPendigCR.DataBind();
            //}
            else
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");  
            }
        }

        protected void gvPendigCR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userSession.User_Group == Customer_GropID || userSession.User_Group == UserGroupID_CustomerAdmin)
            {
                Response.Redirect("EditCertificateRequest.aspx?ReqstID=" + gvPendigCR.SelectedRow.Cells[0].Text, false);
            }
            else if (userSession.User_Group == SAdmin_GropID)
            {
                Response.Redirect("CertificateDetails.aspx?ReqstID=" + gvPendigCR.SelectedRow.Cells[0].Text, false);
            }
        }


        protected void gvPendigCR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.getCertificatRequests();
            gvPendigCR.PageIndex = e.NewPageIndex;
            gvPendigCR.DataBind();
        }

        protected void gvPendigSDR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.getPendingSDRequest();
            gvPendigSDR.PageIndex = e.NewPageIndex;
            gvPendigSDR.DataBind();
        }

        protected void gvPendigUCR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.getPendingRequest();
            gvPendigUCR.PageIndex = e.NewPageIndex;
            gvPendigUCR.DataBind();
        }


        private void getSupportingDOC(string id)
        {
            SupList = CRmanager.getSupportingDOCfUploadBRequest(id);
            gvSupportingDOc.DataSource = SupList;
            gvSupportingDOc.DataBind();
        }

        private void getSupportingDOCWEB(string id)
        {
            SupList = CRmanager.getSupportingDOCfRequest(id);
            gvWEBSupDoc.DataSource = SupList;
            gvWEBSupDoc.DataBind();
        }

        private void getPendingRequest()
        {
            try
            {
                if (userSession.Customer_ID != null)
                {
                    gvPendigUCR.DataSource = CRmanager.getPendingUpBaseCRequest(userSession.Customer_ID).CertificateUpload_List;
                    gvPendigUCR.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }

            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("UploadBCertificateRequests.aspx @ getPendingRequest()", Ex);
            }
        }

        private void getPendingWEBRequest()
        {
            try
            {
                if (userSession.Customer_ID != null)
                {
                    gvPendigWCR.DataSource = CRmanager.getPendingWebBaseCRequest(userSession.Customer_ID).PendignWebBasedCertificate_List;
                    gvPendigWCR.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }

            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("UploadBCertificateRequests.aspx @ getPendingRequest()", Ex);
            }
        }

        private void getPendingSDRequest()
        {
            try
            {
                if (userSession.Customer_ID != null)
                {
                    gvPendigSDR.DataSource = SDSignMngr.DCISgetPendingSDApprovals("P", userSession.Customer_ID).SDPendingApproval_List;
                    gvPendigSDR.DataBind();
                }
                else
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }

            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("UploadBCertificateRequests.aspx @ getPendingRequest()", Ex);
            }
        }

        protected void linkDownDoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblRequestID = (Label)row.Cells[0].FindControl("lblRequestSDID");
                    Label lblPath = (Label)row.Cells[0].FindControl("lblUploadSDPath");
                    Label lblDocName = (Label)row.Cells[0].FindControl("lblDocName");

                    Session["PDFUrl"] = lblPath.Text;
                    string pageurl = "PdfView.aspx?ID=" + lblRequestID.Text + "&DN=" + lblDocName.Text;
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                    //Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>"); 

                }
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Download The File....</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }
        }

        protected void linkDownUBDoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblRequestID = (Label)row.Cells[0].FindControl("lblRequestID");
                    Label lblPath = (Label)row.Cells[0].FindControl("lblUploadPath");
                    Label lblDocName = (Label)row.Cells[0].FindControl("lblDocName");

                    Session["PDFUrl"] = lblPath.Text;
                    string pageurl = "PdfView.aspx?ID=" + lblRequestID.Text + "&DN=" + lblRequestID.Text+".pdf";
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                    //Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>"); ;
                }
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Download The File....</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblPath = (Label)row.FindControl("lblCertificatePath");
                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                Session["PDFUrl"] = lblPath.Text;
                string pageurl = "PdfView.aspx?ID=" + lblRequestID.Text + "&DN=" + lblRequestID.Text + ".pdf";
                Page.ClientScript.RegisterStartupScript(
                this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
               // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
            }
        }

        //protected void linkDownDoc_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        //        {
        //            Label lblUploadPath = (Label)row.Cells[0].FindControl("lblUploadPath");
        //            Label lblRequestID = (Label)row.Cells[0].FindControl("lblRequestID");
        //            Response.ContentType = "APPLICATION/OCTET-STREAM";
        //            String Header = "Attachment; Filename=" + lblRequestID.Text + "_Certificate.pdf";
        //            Response.AppendHeader("Content-Disposition", Header);
        //            System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(lblUploadPath.Text));
        //            Response.WriteFile(Dfile.FullName);
        //            //Don't forget to add the following line
        //            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
        //            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
        //            HttpContext.Current.ApplicationInstance.CompleteRequest();
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        string qu = null;
        //        qu += "<div class=\"alert alert-dismissable alert-warning\">";
        //        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
        //        qu += " <strong> Error ! </strong>Unable To Download The File....</div>";
        //        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

        //        ErrorMessage.InnerHtml = qu;
        //        ErrorLog.LogError(Ex);
        //    }
        //}


        protected void likViewSupportingDoc_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                getSupportingDOC(lblRequestID.Text);
                mp1.Show();
            }
        }

        protected void linkDownloadSD_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    for (int i = 0; i < SupList.Count; i++)
                    {
                        if (SupList[i].Seq_No == Convert.ToInt64(row.Cells[0].Text))
                        {
                            //Response.ContentType = "APPLICATION/OCTET-STREAM";
                            //String Header = "Attachment; Filename=" + SupList[i].Document_Name;
                            //Response.AppendHeader("Content-Disposition", Header);
                            //System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(SupList[i].Uploaded_Path));
                            //Response.WriteFile(Dfile.FullName);
                            ////Don't forget to add the following line
                            //HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                            //HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                            //HttpContext.Current.ApplicationInstance.CompleteRequest();
                                    Label lblPath = (Label)row.FindControl("lblUploadPath");
                                    Label lblRequestID = (Label)row.FindControl("lblRequestID");
                                    Session["PDFUrl"] = SupList[i].Uploaded_Path;
                                    string pageurl = "PdfView.aspx?ID=" + SupList[i].Seq_No + "&DN=" + SupList[i].SupportingDoc_Name + ".pdf";
                                    // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                                    Page.ClientScript.RegisterStartupScript(
                                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_blank');", true);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Download The File....</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }

        }




        protected void btnClose_Click(object sender, EventArgs e)
        {
            mp1.Dispose();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                Label lblTempwebr  = null;

                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {

                    lblTempwebr = (Label)row.FindControl("lblRequestID");



                    //    lblTemp=

                    //    myIframe.Attributes["src"] = lblTemp.Text;



                }

                string webreqid = lblTempwebr.Text;
                String CustID;
                string SendEmailAddress;

                CustID = userSession.Customer_ID;

                string cusName = od.getCutomerName(CustID);

                CustomerDetails cd = cdm.getRequestDetails(CustID);
                SendEmailAddress = cd.Email1;

                String AdminMsg = "Certificate reminder for Request Id:-" + webreqid + " from Customer Name:-" + cusName + " (" + CustID + "). Reply via:- " + SendEmailAddress;
                string ClientEmailaddress = System.Configuration.ConfigurationManager.AppSettings["AdminEmailAddress"];

                sendEmail(AdminMsg, ClientEmailaddress);



                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Email sent Successfully !!!</strong></div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;





               // Response.Redirect("PendingCertificateRequest.aspx", false);

            }catch(Exception ex){

                ErrorLog.LogError(ex);
            }


        }


        protected void btnSupdocSend_Click(object sender, EventArgs e)
        {
            try
            {

                Label lblTempwebr = null;

                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {

                    lblTempwebr = (Label)row.FindControl("lblRequestSDID");



                    //    lblTemp=

                    //    myIframe.Attributes["src"] = lblTemp.Text;



                }

                string webreqid = lblTempwebr.Text;
                String CustID;
                string SendEmailAddress;

                CustID = userSession.Customer_ID;

                string cusName = od.getCutomerName(CustID);

                CustomerDetails cd = cdm.getRequestDetails(CustID);
                SendEmailAddress = cd.Email1;

                String AdminMsg = " Certificate reminder for Document Request Id:-" + webreqid + " from Customer Name:-" + cusName + " (" + CustID + "). Reply via:- " + SendEmailAddress;
                string ClientEmailaddress = System.Configuration.ConfigurationManager.AppSettings["AdminEmailAddress"];

                sendEmail(AdminMsg, ClientEmailaddress);



                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Email sent Successfully !!!</strong></div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;





                // Response.Redirect("PendingCertificateRequest.aspx", false);

            }
            catch (Exception ex)
            {

                ErrorLog.LogError(ex);
            }


        }

        private bool sendEmail(string AdminMsg, string ClientEmailaddress)
        {

            //mail.SendEmail(ContactPersonEmail, "Customer Request", AdminMsg, "");
           

            //string Key = System.Configuration.ConfigurationManager.AppSettings["DecKey"];
            //ParameateManager pm = new ParameateManager();
            //Parameters cryip = pm.getEmailPassword("EmailPassword");
            //string cipherText = cryip.ParameterValue1;
            //string AdminEmailaddress = cryip.ParameterDescription1;

            //string AdminPassword = Decrypt(cipherText, Key);

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
                mail.SendEmail(Pending_Email, "Certificate Request Reminder", AdminMsg, "");
                mail.SendEmail(Pending_Email2, "Certificate Request Reminder", AdminMsg, "");
                //string HostName = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
                //string Port = System.Configuration.ConfigurationManager.AppSettings["EmailPort"];
                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress(AdminEmailaddress);
                //msg.To.Add(ClientEmailaddress);
                //msg.Body = AdminMsg;
                //msg.IsBodyHtml = true;
                //SmtpClient smpt = new SmtpClient();
                //smpt.Host = HostName;
                //// smpt.Host = "smtp.mail.yahoo.com";

                //System.Net.NetworkCredential net = new System.Net.NetworkCredential();
                //net.UserName = AdminEmailaddress;
                //net.Password = AdminPassword;
                //smpt.UseDefaultCredentials = true;
                //smpt.Credentials = net;
                //smpt.Port = Convert.ToInt32(Port);
                //// smpt.Port = 465;
                //smpt.EnableSsl = true;
                //smpt.Send(msg);
                //return true;
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

        protected void gvPendigWCR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.getPendingWEBRequest();
            gvPendigWCR.PageIndex = e.NewPageIndex;
            gvPendigWCR.DataBind();
        }

        protected void linkViewWEBSD_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                getSupportingDOCWEB(lblRequestID.Text);
                Mpw1.Show();
            }
        }
    }
}