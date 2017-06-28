using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.ParameterManagement;
using System.IO;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.SupportDocumentSignManagement;
using System.Transactions;
using DCISDBManager.trnLib.MasterDataManagement;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using System.Net;
using DCISDBManager.trnLib.CustomerRequestManagement;

namespace DSCMS.Views.Certificate
{
    public partial class UploadBCertificateRequests : System.Web.UI.Page
    {
        CertificateRequest CRequst = new CertificateRequest();
        CertificateRequestManager CRmanager = new CertificateRequestManager();
        CertificateSignManagment CSMan = new CertificateSignManagment();
        SupportingDocumentManagement SDManager = new SupportingDocumentManagement();
        SDocSignRequsetManager SDsign = new SDocSignRequsetManager();

        UserSession usrSession;
        CheckAuthManager authorized;

        List<SupportingDocUpload> SupList = new List<SupportingDocUpload>();

        string ExpireDays = System.Configuration.ConfigurationManager.AppSettings["CertificateExpire"];
        string CertificateSEAL = System.Configuration.ConfigurationManager.AppSettings["CertificateSEAL"];

        protected void Page_Load(object sender, EventArgs e)
        {
            usrSession = new UserSession();
            authorized = new CheckAuthManager();
            if (usrSession == null)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            if (!authorized.IsUserGroupAuthorised(usrSession.User_Group, "UBCRS"))
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (usrSession.PFX_path == "" || usrSession.SignatureIMG_Path == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Cannot Find Your Digital Signature Please Contact the Administrator..</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                btnCerateCertificate.Visible = false;
                btnRejectCertificateReq.Visible = false;

            }
            if (!IsPostBack)
            {
                getCustomer();
                getPendingRequest(drpCustomer.SelectedValue);
                getRejectResons();

            }
        }

        private void getSupportingDOC(string id)
        {
            SupList = CRmanager.getSupportingDOCfUploadBRequest(id);
            gvSupportingDOc.DataSource = SupList;
            gvSupportingDOc.DataBind();
        }


        protected void getCustomer()
        {
            try
            {

                CustomerDetailManager cm = new CustomerDetailManager();

                drpCustomer.DataSource = cm.getAllCustomer("Y");

                drpCustomer.DataValueField = "CustomerId1";
                drpCustomer.DataTextField = "CustomerName1";
                drpCustomer.DataBind();
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


        private void getPendingRequest(string CustomerID)
        {
            try
            {
                gvPendigUCR.DataSource = CRmanager.getPendingUpBaseCRequest(CustomerID).CertificateUpload_List;
                gvPendigUCR.DataBind();
            }
            catch(Exception Ex)
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
                    Label lblUploadPath = (Label)row.Cells[0].FindControl("lblUploadPath");
                    Label lblRequestID = (Label)row.Cells[0].FindControl("lblRequestID");
                    Response.ContentType = "APPLICATION/OCTET-STREAM";
                    String Header = "Attachment; Filename=" + lblRequestID.Text+"_Certificate.pdf";
                    Response.AppendHeader("Content-Disposition", Header);
                    System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(lblUploadPath.Text));
                    Response.WriteFile(Dfile.FullName);
                    //Don't forget to add the following line
                    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
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
                    Label lblDocName = (Label)row.FindControl("lblDocName");
                    Label lblSDUppathe = (Label)row.FindControl("lblSDUppathe");
                    Label lblRefNo = (Label)row.FindControl("lblRefNo");

                    Session["PDFUrl"] = lblSDUppathe.Text;
                    string pageurl = "PdfView.aspx?ID=" + lblRefNo.Text + "&DN=" + lblDocName.Text;
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_newtab');", true);
                   // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
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

        protected void linkbtnApprove_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                Label lblCid = (Label)row.FindControl("lblCid");
                Label lblSealRequired = (Label)row.FindControl("lblSealRequired");

                lblACid.Text = lblCid.Text;
                lblAPath.Text = lblUploadPath.Text;
                lblAReqID.Text = lblRequestID.Text;
                lblSealNeeded.Text = lblSealRequired.Text;
               // ApproveCertificateRequest(lblCid.Text, lblRequestID.Text);
                if (usrSession.C_Password.Equals(""))
                {
                    ModelApprove.Show();
                }
                else
                {
                    getSupportingDOC(lblAReqID.Text);
                    ApproveCertificateRequest(lblCid.Text, lblRequestID.Text, lblUploadPath.Text,Convert.ToBoolean(lblSealNeeded.Text));
                }

            }
        }


        protected void btnBulkSign_Click(object sender, EventArgs e)
        {
            if (usrSession.C_Password.Equals(""))
            {
                mpBulk.Show();
            }
            else
            {
                bool result = false;

                foreach (GridViewRow row in gvPendigUCR.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = ((CheckBox)row.FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            Label lblRequestID = (Label)row.FindControl("lblRequestID");
                            Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                            Label lblCid = (Label)row.FindControl("lblCid");
                            Label lblSealRequired = (Label)row.FindControl("lblSealRequired");

                            string RequestId = lblRequestID.Text;
                            string UploadPath = lblUploadPath.Text;
                            string CustomerId = lblCid.Text;
                            bool SealNeeded = Convert.ToBoolean(lblSealRequired.Text);
                            getSupportingDOC(RequestId);
                            result = ApproveCertificateRequest(CustomerId, RequestId, UploadPath, SealNeeded);
                            if (!result)
                            {
                                getPendingRequest(drpCustomer.SelectedValue);
                                return;
                            }
                        }
                    }
                    // Thread.Sleep(100);
                }
                getPendingRequest(drpCustomer.SelectedValue);
            }
        }

        protected void linkbtnReject_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblRequestID = (Label)row.FindControl("lblRequestID");
                    lblRejectRequestID.Text = lblRequestID.Text;
                    mpReject.Show();
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("btnReject - UploadBasedCertificateRequest.aspx", Ex);
            }
        }


        private bool ApproveCertificateRequest(string CustomerID, string RequestID,string CerificatePath,bool SealRequred)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    SequenceManager seqmanager = new SequenceManager();
                    string Certificate_No = "CE" + seqmanager.getNextSequence("CertificateSign").ToString();

                    string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy")
                                            + "/Issued_Certificates/" + DateTime.Now.ToString("yyyy_MM_dd") + "/"
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
                    Point.Y = 55;
                    SignCertificate.AddTextToPdf(NotSigned, CertificateID_Added, Certificate_No, Point, Server.MapPath(usrSession.SignatureIMG_Path),SealRequred,usrSession.Person_Name);

                   // string NotSigned = Server.MapPath(CerificatePath);
                    string Signed = Server.MapPath(DirectoryPath + "/" + Certificate_No + "_Certificate.pdf");
                    string pathe = Server.MapPath(usrSession.PFX_path);//From DB
                    //string pathe = Server.MapPath("~/Signature/Samitha/Samitha.pfx");//From DB
                    string SignatureIMG = Server.MapPath(usrSession.SignatureIMG_Path);// From DB
                    //string SignatureIMG = Server.MapPath("~/Signature/Samitha/Chernenko_Signature.png");// From DB

                    var PFX = new FileStream(pathe, FileMode.OpenOrCreate);

                  //  PDFCreator.Signature SignCertificate = new PDFCreator.Signature();
                    bool singed = SignCertificate.signCertificate(CertificateID_Added, Signed, PFX, usrSession.C_Password);
                    if (!singed)
                    {
                        PFX.Close();
                        lblError.Text = "Wrong password or Corrupted Certificate file.";
                        usrSession.C_Password = "";
                        ModelApprove.Show(); 
                        return false;
                    }
                    CertificateApproval Approve = new CertificateApproval();
                    Approve.Certificate_Name = Certificate_No + "_Certificate.pdf";
                    Approve.Certificate_Path = DirectoryPath + "/" + Certificate_No + "_Certificate.pdf";
                  //  Approve.Created_By = "SAMITHA";
                    Approve.Created_By = usrSession.User_Id;
                    Approve.Expiry_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays));
                    Approve.Is_Downloaded = "N";
                    Approve.Is_Valid = "Y";
                    Approve.Request_Id = RequestID;
                    Approve.Certificate_Id = Certificate_No;

                    bool result = CSMan.ApproveCertificate(Approve);
                    bool result2 = CRmanager.UpdateUploadBCertifcateRequest(Approve);
                    for (int i = 0; i < SupList.Count(); i++)
                    {
                        if (SupList[i]._Remarks.Equals("NCE_Certification"))
                        {
                            string DocPath = Server.MapPath(DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name);
                            string SealedPath = Server.MapPath(DirectoryPath + "/Supporting-Doc/Temp/" + SupList[i].Document_Name);

                            if (!Directory.Exists(Server.MapPath(DirectoryPath + "/Supporting-Doc")))
                            {
                                Directory.CreateDirectory(Server.MapPath(DirectoryPath + "/Supporting-Doc/Temp"));
                            }

                            PDFCreator.Signature SignDoc = new PDFCreator.Signature();

                            SignDoc.AddSealSD(Server.MapPath(SupList[i].Uploaded_Path),SealedPath,Server.MapPath(usrSession.SignatureIMG_Path));

                            var PFX2 = new FileStream(pathe, FileMode.OpenOrCreate);

                            bool Sign = SignDoc.signSupportingDoc(RequestID,
                                SealedPath,
                                DocPath,
                                PFX2, usrSession.C_Password);

                            if (!Sign)
                            {
                                PFX.Close();
                                PFX2.Close();
                                usrSession.C_Password = "";
                                lblError.Text = "Corrupted Supporting Document file. Signature Placement Failed !";
                                ModelApprove.Show();
                                return false;
                            }

                            SupList[i].Certified_Doc_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;
                            SupList[i].Status_ = "A";
                            SupList[i].Customer_ID = CustomerID;
                            SupList[i].Approved_By = usrSession.User_Id;
                            SupList[i].Expire_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays)).ToString();

                            SDsign.setSupportingDocSignRequestINCertRequest(SupList[i]);

                            SupList[i].Uploaded_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;

                            CRmanager.UpdateSupportingDocCertified(SupList[i]);

                        }
                    }
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += "Certificate Approval Successful.";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingRequest(drpCustomer.SelectedValue);

                    transactionScope.Complete();
                    transactionScope.Dispose();
                    return true;
                }

                catch (TransactionAbortedException Ex)
                {
                    transactionScope.Dispose();
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! (Transaction) </strong>Ether The Certificate Is Approved By another Signatory Or The Database Transaction Has Faild !</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingRequest(drpCustomer.SelectedValue);
                    ErrorLog.LogError(Ex);
                    return false;
                }
                catch (FileNotFoundException Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Certificate File Not Found ! Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingRequest(drpCustomer.SelectedValue);
                    ErrorLog.LogError(Ex);
                    return false;
                }
                catch (FieldAccessException Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Cannot Access the Files Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingRequest(drpCustomer.SelectedValue);
                    ErrorLog.LogError(Ex);
                    return false;
                }
                catch (Exception Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Cannot Access the Files Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingRequest(drpCustomer.SelectedValue);
                    ErrorLog.LogError(Ex);
                    return false;
                }

            }
        }

        protected void btnCerateCertificate_Click(object sender, EventArgs e)
        {
            usrSession.C_Password = txtCertificatePass.Text;
            getSupportingDOC(lblAReqID.Text);
            ApproveCertificateRequest(lblACid.Text, lblAReqID.Text, lblAPath.Text,Convert.ToBoolean(lblSealNeeded.Text));
        }

        protected void btnRejectCertificateReq_Click(object sender, EventArgs e)
        {
            if (drpRejectReason.SelectedIndex == 0)
            {
                lblRejectError.Text = "Please Select a Reject Reson First.";
                mpReject.Show();
                return;
            }
            try
            {
                bool result = CSMan.RejectUBCertificate(lblRejectRequestID.Text,usrSession.User_Id, drpRejectReason.SelectedValue);

                if (result)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Request Rejected.";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingRequest(drpCustomer.SelectedValue);
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

        protected void linkViewPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                    WebClient user = new WebClient();
                    Byte[] FileBuffer = user.DownloadData(Server.MapPath(lblUploadPath.Text));
                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                    else
                    {
                        Response.Redirect("~/Views/Home/FileNotFound.aspx");
                    }
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("Certificate PDF View", Ex);
                Response.Redirect("~/Views/Home/FileNotFound.aspx");

            }
        }

        protected void btnByCustomer_Click(object sender, EventArgs e)
        {
            getPendingRequest(drpCustomer.SelectedValue);
        }

        protected void btnBulkSignPop_Click(object sender, EventArgs e)
        {
            bool result = false;
            usrSession.C_Password = txtSignatoryPass.Text;
            foreach (GridViewRow row in gvPendigUCR.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = ((CheckBox)row.FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        Label lblRequestID = (Label)row.FindControl("lblRequestID");
                        Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                        Label lblCid = (Label)row.FindControl("lblCid");
                        Label lblSealRequired1 = (Label)row.FindControl("lblSealRequired");

                        string RequestId = lblRequestID.Text;
                        string UploadPath = lblUploadPath.Text;
                        string CustomerId = lblCid.Text;
                        bool seal = Convert.ToBoolean(lblSealRequired1.Text);
                        getSupportingDOC(RequestId);
                        result = ApproveCertificateRequest(CustomerId, RequestId, UploadPath,seal);
                        if (!result)
                        {
                            getPendingRequest(drpCustomer.SelectedValue);
                            return;
                        }
                    }
                }
                // Thread.Sleep(100);
            }
            getPendingRequest(drpCustomer.SelectedValue);
        }
    }
}