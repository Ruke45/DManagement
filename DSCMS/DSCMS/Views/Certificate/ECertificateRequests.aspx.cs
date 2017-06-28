using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DCISDBManager.trnLib.MasterDataManagement;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.Email;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.ParameterManagement;
using System.Transactions;
using System.Net.NetworkInformation;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS.Views.Certificate
{
    public partial class ECertificateRequests : System.Web.UI.Page
    {
        EmailRequestManager EmailRM = new EmailRequestManager();
        CertificateSignManagment CSMan = new CertificateSignManagment();
        MailSendManager SendManger = new MailSendManager();

        EmailRequest ERequests = new EmailRequest();
        CheckAuthManager authorized = new CheckAuthManager();
        UserSession userSession;

        string ExpireDays = System.Configuration.ConfigurationManager.AppSettings["CertificateExpire"];
        string MailSubject = System.Configuration.ConfigurationManager.AppSettings["EmailCertificateSend_MailSubject"];
        string MailBody = System.Configuration.ConfigurationManager.AppSettings["EmailCertificateSend_MailBody"];

        string CertificateSEAL = System.Configuration.ConfigurationManager.AppSettings["CertificateSEAL"];
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            if (userSession == null)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "EBCR"))
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (userSession.PFX_path == "" || userSession.SignatureIMG_Path == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Cannot Find Your Digital Signature Please Contact the Administrator..</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                btnApproveCertificate.Enabled = false;

            }
            if (!IsPostBack)
            {
                
                string script = "$(document).ready(function () { $('[id*=btnLoading]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                getERequestData();
                getRejectResons();
            }
        }

        protected void getERequestData()
        {
            try
            {
                gvPendigECR.DataSource = EmailRM.getEmailBasedCertRequest("P");
                gvPendigECR.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        private void getRejectResons()
        {
            try
            {
                RejectResonManagment ReM = new RejectResonManagment();
                drpRejectReason.DataSource = ReM.getCertificaterRejectResons();
                drpRejectReason.DataTextField = "Reason_";
                drpRejectReason.DataValueField = "Reason_Code";
                drpRejectReason.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void linkCertificateN_Click(object sender, EventArgs e)
        {


        }

        protected void linbtnReject_Click(object sender, EventArgs e)
        {
            ErrorMessage.InnerHtml = null;
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    lblRejectRequestID.Text = row.Cells[0].Text;
                    mpReject.Show();
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("btnReject - EcertificateRequest.aspx", Ex);
            }
            
        }

        protected void linbtnApprove_Click(object sender, EventArgs e)
        {
            ErrorMessage.InnerHtml = null;
            try
            {
                using (GridViewRow Row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    //Find the DropDownList in the Row
                    string RequestID = (Row.FindControl("lblRequestID") as Label).Text;
                    // We'll read all files from Images subfolder
                    string pathe = Server.MapPath("~/Inbox/" + RequestID + "/Certificate");
                    DirectoryInfo diFiles = new DirectoryInfo(Server.MapPath("~/Inbox/" + RequestID + "/Certificate"));
                    // Takes all .gif images,
                    // You can set some other filter or 
                    // *.* for all files
                    drpCertificateS.DataSource = diFiles.GetFiles("*.*");
                    drpCertificateS.DataBind();

                    lblApporveRequestID.Text = RequestID;
                    lblCustomerId.Text = Row.Cells[2].Text;
                    //drpCertificateS.Items.Insert(0, new ListItem(""));
                    mpApprove.Show();
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("btnApprove - EcertificateRequest.aspx", Ex);
            }
        }

        protected void btnSyncEmails_Click(object sender, EventArgs e)
        {
            // Add Fake Delay to simulate long running process.
            ErrorMessage.InnerHtml = null;
            System.Threading.Thread.Sleep(1000);

            try
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " There is No Internet Connection.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
                if (!Directory.Exists(Server.MapPath("~/Inbox")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Inbox"));
                }
                EmailRequestManager EmlR = new EmailRequestManager();
                int result =  EmlR.SynceEmails(Server.MapPath("~/Inbox"));//"madusankagmt@hotmail.com", "Password#!123#"
                if (result == 2)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += "E-Based Certificate Request Parameters are not configured or cannot be found. Please contact the Administrator";
                    qu += "</div>";
                }
                getERequestData();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("(ECertificateRequests ->btnSyncEmails_Click", Ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu +=  Ex.Message;
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
        }

        protected void btnRejectCertificateReq_Click(object sender, EventArgs e)
        {
            ErrorMessage.InnerHtml = null;
            if (drpRejectReason.SelectedIndex == 0)
            {
                lblRejectError.Text = "Please Select a Reject Reson First.";
                mpReject.Show();
                return;
            }
            try
            {
                bool result = CSMan.RejectECertificate(lblRejectRequestID.Text, userSession.User_Id, drpRejectReason.SelectedValue);

                if (result)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Request Rejected.";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = qu;
                    getERequestData();
                }
                else
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Server Error Please Contact the Administrator.";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = qu;
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnApproveCertificate_Click(object sender, EventArgs e)
        {
            string NotSigned = "~/Inbox/" + lblApporveRequestID.Text + 
                               "/Certificate/" + drpCertificateS.Text.ToString();
            ApproveCertificateRequest(lblCustomerId.Text, lblApporveRequestID.Text, NotSigned);
            getERequestData();
        }

        //Certificate Approval Method
        private void ApproveCertificateRequest(string CustomerID, string RequestID, string CerificatePath)
        {
            ErrorMessage.InnerHtml = null;
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    EmailCertificateConfig Econfig = EmailRM.getEmailSignatureConfig(CustomerID);
                    if (Econfig == null)
                    {
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " <strong> Error ! </strong>Customer's Certificate Signature Placement is Not Configured..";
                        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                        ErrorMessage.InnerHtml = qu;
                        return;
                    }

                    SequenceManager seqmanager = new SequenceManager();
                    string Certificate_No = "CE" + seqmanager.getNextSequence("CertificateSign").ToString();

                    string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy")
                                            + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/"
                                            + Certificate_No + "_Certificate";
                    //DirectoryPath which will save the NOT singed PDF File as NOT_Signed.pdf in the given Path
                    if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                    {
                        Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                    }
                    PDFCreator.Signature SignCertificate = new PDFCreator.Signature();

                    string NotSigned = Server.MapPath(CerificatePath);
                    string CertificateID_Added = Server.MapPath(DirectoryPath + "/" + "Not_Signed" + "_Certificate.pdf");

                    /* Method Which Create a New Document Withe Printed Certificate ID
                     * Point is the Certificate ID Placement Area Object
                     */
                    System.Drawing.Point Point = new System.Drawing.Point();
                    Point.X = 350;
                    Point.Y = 40;
                    SignCertificate.AddTextToPdf(NotSigned, CertificateID_Added, Certificate_No, Point, CertificateSEAL);
                    /* Method Which Create a New Document Withe Printed Certificate ID*/


                    string Signed = Server.MapPath(DirectoryPath + "/" + Certificate_No + "_Certificate.pdf");
                    string pathe = Server.MapPath(userSession.PFX_path);//From DB
                    //string pathe = Server.MapPath("~/Signature/Samitha/Samitha.pfx");//From DB
                    string SignatureIMG = Server.MapPath(userSession.SignatureIMG_Path);// From DB
                   // string SignatureIMG = Server.MapPath("~/Signature/Samitha/sign.png");// From DB

                    var PFX = new FileStream(pathe, FileMode.OpenOrCreate);

                    
                   // bool singed = SignCertificate.signCertificate(NotSigned, Signed, PFX, "Password#1", SignatureIMG);
                    bool singed = SignCertificate.signCertificate(CertificateID_Added, Signed, PFX, txtCertificatePass.Text, SignatureIMG, Econfig);
                    if (!singed)
                    {
                        PFX.Close();
                        lblError.Text = "Wrong password or Corrupted Certificate file.";
                        mpApprove.Show();
                        return;
                    }
                    CertificateApproval Approve = new CertificateApproval();
                    Approve.Certificate_Name = Certificate_No + "_Certificate.pdf";
                    Approve.Certificate_Path = DirectoryPath + "/" + Certificate_No + "_Certificate.pdf";
                   // Approve.Created_By = "SYSTEM";
                    Approve.Created_By = userSession.User_Id;
                    Approve.Expiry_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays));
                    Approve.Is_Downloaded = "N";
                    Approve.Is_Valid = "Y";
                    Approve.Request_Id = RequestID;
                    Approve.Certificate_Id = Certificate_No;

                    bool result = CSMan.ApproveECertificate(Approve);
                    string que = null;
                    que += "<div class=\"alert alert-dismissable alert-success\">";
                    que += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    que += " <strong> Successful ! </strong>Certificate Approval Successful..";
                    que += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = que;
                    transactionScope.Complete();
                    transactionScope.Dispose();
                }

                catch (TransactionAbortedException Ex)
                {
                    transactionScope.Dispose();
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! (Transaction) </strong>Unable to Complete the Request. Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    ErrorLog.LogError(Ex);
                }
                catch (FileNotFoundException Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Certificate File Not Found ! Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    ErrorLog.LogError(Ex);
                }
                catch (FieldAccessException Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Cannot Access the Files Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    ErrorLog.LogError(Ex);
                }
                catch (Exception Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Cannot Access the Files Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    ErrorLog.LogError(Ex);
                }

            }
        }
        //Certificate Approval Method

        protected void lblbtnSupportdoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow Row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    //Find the DropDownList in the Row
                    string RequestID = (Row.FindControl("lblRequestID") as Label).Text;
                    // We'll read all files from Images subfolder
                    string pathe = Server.MapPath("~/Inbox/" + RequestID + "/");
                    string[] filePaths = Directory.GetFiles(pathe);
                    List<ListItem> files = new List<ListItem>();
                    foreach (string filePath in filePaths)
                    {
                        files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                    }
                    gridSDoc.DataSource = files;
                    gridSDoc.DataBind();
                    ModelSupDoc.Show();
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("lblbtnSupportdoc_Click - EcertificateRequest.aspx", Ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable to Open the Documents.</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }
        }

        protected void linkDownloadSD_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;

                Response.ContentType = "APPLICATION/OCTET-STREAM";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath.Replace(" ", "_")));
                System.IO.FileInfo Dfile = new System.IO.FileInfo(filePath);
                Response.WriteFile(Dfile.FullName);
                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("linkDownloadSD_Click - EcertificateRequest.aspx", Ex);
            }
        }

        protected void lblbtnCertificateDoc_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow Row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    //Find the DropDownList in the Row
                    string RequestID = (Row.FindControl("lblRequestID") as Label).Text;
                    // We'll read all files from Images subfolder
                    string pathe = Server.MapPath("~/Inbox/" + RequestID + "/Certificate/");
                    //  DirectoryInfo diFiles = new DirectoryInfo(Server.MapPath("~/Inbox/" + RequestID + "/Certificate"));

                    string[] filePaths = Directory.GetFiles(pathe);
                    List<ListItem> files = new List<ListItem>();
                    foreach (string filePath in filePaths)
                    {
                        files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                    }
                    gridCertificate.DataSource = files;
                    gridCertificate.DataBind();

                    ModelCertificate.Show();
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("lblbtnCertificateDoc_Click - EcertificateRequest.aspx", Ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable to Open the Document.</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }

        }

        protected void SendApprovedCertificates()
        {
            List<EmailRequest> ERlist = new List<EmailRequest>();

            ERlist = SendManger.getSendPendingEBCertificates();
            if (ERlist.Count != 0)
            {
                for (int x = 0; x < ERlist.Count(); x++)
                {
                    try
                    {
                        int Send = 0;
                        Send = SendManger.SendEmail(ERlist[x].Email_,
                                             MailSubject,
                                             MailBody + "Certificate-Id : "+ERlist[x].Certificate_Id,
                                             Server.MapPath(ERlist[x].Certificate_Path));
                        if (Send == 1)
                        {
                            SendManger.UpdateEBCSend(ERlist[x].Request_ID, "Y");
                        }
                        else if (Send == 2)
                        {
                            string qu = null;
                            qu += "<div class=\"alert alert-dismissable alert-warning\">";
                            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            qu += " There is No Internet Connection.</div>";
                            ErrorMessage.InnerHtml = qu;
                        }
                        else
                        {
                            string qu = null;
                            qu += "<div class=\"alert alert-dismissable alert-warning\">";
                            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            qu += " Email Send Faild.</div>";
                            ErrorMessage.InnerHtml = qu;
                        }
                    }
                    catch (Exception Ex)
                    {
                        ErrorLog.LogError("Email Sending Fail", Ex);
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Email Send Faild.</div>";
                        ErrorMessage.InnerHtml = qu;
                    }
                }
            }

            
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            btnSendEmail.Enabled = false;
            btnSyncEmails.Enabled = false;
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " There is No Internet Connection.</div>";
                //qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            try
            {
                SendApprovedCertificates();
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "Email Sending Successful";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                ErrorMessage.InnerHtml = qu;
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }

            btnSendEmail.Enabled = true;
            btnSyncEmails.Enabled = true;
        }
    }
}