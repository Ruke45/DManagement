using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using System.Transactions;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.SupportDocumentSignManagement;
using DCISDBManager.trnLib.MasterDataManagement;
using System.Net;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.objLib.Email;
using DCISDBManager.trnLib.EmailManager;

namespace DSCMS.Views.Certificate
{
    public partial class CertificateBulkSign : System.Web.UI.Page
    {
        CertificateRequestHeader CRHeader = new CertificateRequestHeader();
        CertificateRequestManager CRManager = new CertificateRequestManager();
        CertificateSignManagment CSMan = new CertificateSignManagment();
        SupportingDocumentManagement SDManager = new SupportingDocumentManagement();
        SDocSignRequsetManager SDsign = new SDocSignRequsetManager();
        List<EmailRequest> ERlist = new List<EmailRequest>();

        MailSendManager SendManger = new MailSendManager();

        List<CertificateRequestDetail> CRDetails = new List<CertificateRequestDetail>();
        List<SupportingDocUpload> SupList = new List<SupportingDocUpload>();
        CertificateRequestDetail CRD = new CertificateRequestDetail();



        UserSession userSession;
        CheckAuthManager authorized;

        string ExpireDays = System.Configuration.ConfigurationManager.AppSettings["CertificateExpire"];

        string HSCODEHAS = System.Configuration.ConfigurationManager.AppSettings["HSCODEHAS"];
        string GOLOBALTMP = System.Configuration.ConfigurationManager.AppSettings["GOLOBALTMP"];
        string MASSACTIVE = System.Configuration.ConfigurationManager.AppSettings["MASSACTIVE"];
        string NINDROTMP = System.Configuration.ConfigurationManager.AppSettings["NINDROTMP"];
        string ROWWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["ROWWITHOUTHS"];
        string ROWWITH_HS = System.Configuration.ConfigurationManager.AppSettings["ROWWITH_HS"];
        string COLUMNWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["COLUMNWITHOUTHS"];
        string COLUMNWITHOUTHS2 = System.Configuration.ConfigurationManager.AppSettings["COLUMNWITHOUTHS2"];


        string CertificateLOGO = System.Configuration.ConfigurationManager.AppSettings["CertificateLOGO"];
        string CertificateSEAL = System.Configuration.ConfigurationManager.AppSettings["CertificateSEAL"];

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            authorized = new CheckAuthManager();
            ERlist = SendManger.getSendPendingMailSendingCertificates("%","%");
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Logout.aspx");
            }
            bool resutl = authorized.IsUserGroupAuthorised(userSession.User_Group, "BULKS");
            if (resutl == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            if (!this.IsPostBack)
            {
                getCustomer();
                getPendingCRequest("%");
                getRejectResons();
                
            }

           // btnSendApproval.Text = "Pending Emails (" + ERlist.Count() +")";
        }

        private void getPendingCRequest(string CustomerID)
        {
            try
            {
                gvPendigCR.DataSource = CRManager.GetAllPendingCertificates(CustomerID).AllPendingCertificate_List;
                gvPendigCR.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("getPendingCRequest() @ PendingCertificate.aspx", Ex);
            }
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
            RejectResonManagment ReM = new RejectResonManagment();
            drpRejectReason.DataSource = ReM.getCertificaterRejectResons();
            drpRejectReason.DataTextField = "Reason_";
            drpRejectReason.DataValueField = "Reason_Code";
            drpRejectReason.DataBind();
        }

        private void getSupportingDOC(string id)
        {
            SupList = CRManager.getSupportingDOCfRequest(id);
            gvSupportingDOc.DataSource = SupList;
            gvSupportingDOc.DataBind();
        }

        private void getUSupportingDOC(string id)
        {
            SupList = CRManager.getSupportingDOCfUploadBRequest(id);
            gvSupportingDOc.DataSource = SupList;
            gvSupportingDOc.DataBind();
        }

        protected void btnBulkSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (userSession.C_Password.Equals(""))
                {
                    lblError.Text = string.Empty;
                    mp1.Show();
                }
                else
                {
                    bool result = false;
                    foreach (GridViewRow row in gvPendigCR.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = ((CheckBox)row.FindControl("chkRow") as CheckBox);
                            if (chkRow.Checked)
                            {

                                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                                Label lblTemplateID = (Label)row.FindControl("lblTemplateID");
                                Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                                Label lblCustomerID = (Label)row.FindControl("lblCustomerID");
                                Label lblRequestType = (Label)row.FindControl("lblCertificateType");
                                Label lblSealRequired = (Label)row.FindControl("lblSealRequired");

                                string RequestID = lblRequestID.Text;
                                string TemplateID = lblTemplateID.Text;
                                string CustomerID = lblCustomerID.Text;
                                string UploadPath = lblUploadPath.Text;
                                bool SealNeeded = Convert.ToBoolean(lblSealRequired.Text);

                                if (lblRequestType.Text.Equals("W"))
                                {
                                    CRHeader = CRManager.getRequestByID(RequestID);
                                    if (CRHeader.TemplateId1.Equals(ROWWITH_HS) || CRHeader.TemplateId1.Equals(ROWWITHOUTHS))
                                    {
                                        CRD = CRManager.getROWbasedCertificateRequestDetails(RequestID);
                                    }
                                    else { CRDetails = CRManager.getReqDetailByReqID(RequestID, true); }
                                    SupList = CRManager.getSupportingDOCfRequest(RequestID);
                                    result = CreateCertificate(TemplateID);
                                }
                                else
                                {
                                    getUSupportingDOC(RequestID);
                                    result = ApproveCertificateRequest(CustomerID, RequestID, UploadPath, SealNeeded);
                                }
                                if (!result)
                                {
                                    getPendingCRequest(drpCustomer.SelectedValue);
                                    return;
                                }
                            }
                        }
                        // Thread.Sleep(100);
                    }
                    getPendingCRequest(drpCustomer.SelectedValue);
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("PendingCertificates.asp. BulkSign", Ex);
            }
        }

        protected bool CreateCertificate(string Template)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    bool Created = false;
                    SequenceManager seqmanager = new SequenceManager();
                    string Certificate_No = "CE" + seqmanager.getNextSequence("CertificateSign").ToString();

                    CRHeader.CertificateId1 = Certificate_No;

                    string LogoPath = Server.MapPath(CertificateLOGO); // NCE Certificate logo Image path
                    string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy")
                                            + "/Issued_Certificates/" + DateTime.Now.ToString("yyyy_MM_dd")
                                            + "/" + Certificate_No + "_Certificate";
                    //DirectoryPath which will save the NOT singed PDF File as NOT_Signed.pdf in the given Path
                    if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                    {
                        Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                    }

                    /**PDF Cerator 
                     * Parameters
                     * Certificate Reques Header Detail Object
                     * Certificate Request Item Details Object List
                     * Document Save Path
                     * 
                    */
                    if (Template.Equals(ROWWITH_HS))
                    {
                        PDFCreator.RowWithHSTemplate Certificate =
                                new PDFCreator.RowWithHSTemplate(CRHeader,
                                CRD, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"),userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(ROWWITHOUTHS))
                    {
                        PDFCreator.RowWithoutHSTemplate Certificate =
                                new PDFCreator.RowWithoutHSTemplate(CRHeader,
                                CRD, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(GOLOBALTMP))
                    {
                        PDFCreator.OrientGlobalCertificateTemplate Certificate =
                                new PDFCreator.OrientGlobalCertificateTemplate(CRHeader,
                                CRDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(MASSACTIVE))
                    {
                        PDFCreator.MassActiveCertificateTemplate Certificate =
                                new PDFCreator.MassActiveCertificateTemplate(CRHeader,
                                CRDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(NINDROTMP))
                    {
                        PDFCreator.NidroCertificateTemplate Certificate =
                                new PDFCreator.NidroCertificateTemplate(CRHeader,
                                CRDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(COLUMNWITHOUTHS))
                    {
                        PDFCreator.ColumnWithoutHSTemplate Certificate =
                                new PDFCreator.ColumnWithoutHSTemplate(CRHeader,
                                CRDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(COLUMNWITHOUTHS2))
                    {
                        PDFCreator.ColumnWithoutHSTemplate Certificate =
                                new PDFCreator.ColumnWithoutHSTemplate(CRHeader,
                                CRDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }
                    else
                    {
                        PDFCreator.ColumnWithHSTemplate Certificate =
                                new PDFCreator.ColumnWithHSTemplate(CRHeader,
                                CRDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"), userSession.Person_Name, DateTime.Now.ToString("yyyy/MM/dd"));

                        Created = Certificate.CreateCertificate("");
                    }

                    CRDetails.Clear();

                    //if (Created)
                    //{
                    //    CRManager.setWebBasedCertificateCreation(CRHeader.RequestId1,
                    //        DirectoryPath + "/" + CRHeader.RequestId1 + "_Not_Signed.pdf",
                    //        CRHeader.RequestId1 + "_Not_Signed.pdf");
                    //}

                    string Sealed = Server.MapPath(DirectoryPath + "/_Not_Signed.pdf");
                    string NotSigned = Server.MapPath(DirectoryPath + "/_Not_Signed.pdf"); ;
                    string Signed = Server.MapPath(DirectoryPath + "/" + Certificate_No + "_Certificate.pdf");
                    string pathe = Server.MapPath(userSession.PFX_path);//From DB
                    //  string pathe = Server.MapPath("~/Signature/Samitha/Samitha.pfx");//From DB
                    string SignatureIMG = Server.MapPath(userSession.SignatureIMG_Path);// From DB
                    //   string SignatureIMG = Server.MapPath("~/Signature/Samitha/sign.JPG");// From DB

                    var PFX = new FileStream(pathe, FileMode.OpenOrCreate);

                    PDFCreator.Signature SignCertificate = new PDFCreator.Signature();

                    if (Convert.ToBoolean(CRHeader.Seal_Required))
                    {
                        SignCertificate.AddSeal(Sealed, Server.MapPath(userSession.SignatureIMG_Path));
                        NotSigned = Server.MapPath(DirectoryPath + "/_Not_Signed_S.pdf");
                    }

                    bool singed = SignCertificate.signCertificate(NotSigned, Signed,
                                                                  PFX, userSession.C_Password);
                    if (!singed)
                    {
                        PFX.Close();
                        //mp1.Show();
                        //lblError.Text = "Wrong password or Corrupted Certificate file.";
                        userSession.C_Password = "";
                        return false;
                    }

                    CertificateApproval Approve = new CertificateApproval();
                    Approve.Certificate_Name = Certificate_No + "_Certificate.pdf";
                    Approve.Certificate_Path = DirectoryPath + "/" + Certificate_No + "_Certificate.pdf";
                    // Approve.Created_By = "SAMITHA";
                    Approve.Created_By = userSession.User_Id;
                    Approve.Expiry_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays));
                    Approve.Is_Downloaded = "N";
                    Approve.Is_Valid = "Y";
                    Approve.Request_Id = CRHeader.RequestId1;
                    Approve.Certificate_Id = Certificate_No;

                    bool result = CSMan.ApproveCertificate(Approve);
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

                            SignDoc.AddSealSD(Server.MapPath(SupList[i].Uploaded_Path),SealedPath,Server.MapPath(userSession.SignatureIMG_Path));

                            var PFX2 = new FileStream(pathe, FileMode.OpenOrCreate);

                            bool Sign = SignDoc.signSupportingDoc(Certificate_No,
                                SealedPath,
                                DocPath,
                                PFX2, userSession.C_Password);

                            if (!Sign)
                            {
                                PFX.Close();
                                PFX2.Close();
                                //lblError.Text = "Corrupted Supporting Document file @ " + SupList[i].Request_Ref_No + ":" + SupList[i].Document_Id + ". Signature Placement Failed !";
                                //mp1.Show();
                                userSession.C_Password = "";
                                return false;
                            }
                            SupList[i].Certified_Doc_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;
                            SupList[i].Status_ = "A";
                            SupList[i].Customer_ID = CRHeader.CustomerId1;
                            SupList[i].Approved_By = userSession.User_Id;
                            SupList[i].Expire_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays)).ToString();

                            SDsign.setSupportingDocSignRequestINCertRequest(SupList[i]);

                            SupList[i].Uploaded_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;
                            CRManager.UpdateSupportingDocCertified(SupList[i]);


                        }
                    }

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
                    qu += " <strong> Error ! (Transaction) </strong>Ether The Certificate Is Approved By another Signatory Or The Database Transaction Has Faild</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    
                    ErrorLog.LogError(Ex);
                    this.getPendingCRequest(drpCustomer.SelectedValue);
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
                    ErrorLog.LogError(Ex);
                    this.getPendingCRequest(drpCustomer.SelectedValue);
                    return false;
                }
                catch (FieldAccessException Ex)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Cannot Access the Certificate Files Please Contact the Administrator</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    ErrorLog.LogError(Ex);
                    this.getPendingCRequest(drpCustomer.SelectedValue);
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
                    ErrorLog.LogError(Ex);
                    this.getPendingCRequest(drpCustomer.SelectedValue);
                    return false;
                }
            }
        }

        protected void btnCerateCertificate_Click(object sender, EventArgs e)
        {
            bool result = false;
            userSession.C_Password = txtCertificatePass.Text;
            foreach (GridViewRow row in gvPendigCR.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = ((CheckBox)row.FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {

                        Label lblRequestID = (Label)row.FindControl("lblRequestID");
                        Label lblTemplateID = (Label)row.FindControl("lblTemplateID");
                        Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                        Label lblCustomerID = (Label)row.FindControl("lblCustomerID");
                        Label lblRequestType = (Label)row.FindControl("lblCertificateType");
                        Label lblSealRequired = (Label)row.FindControl("lblSealRequired");

                        string RequestID = lblRequestID.Text;
                        string TemplateID = lblTemplateID.Text;
                        string CustomerID = lblCustomerID.Text;
                        string UploadPath = lblUploadPath.Text;

                        if (lblRequestType.Text.Equals("W"))
                        {
                            CRHeader = CRManager.getRequestByID(RequestID);
                            if (CRHeader.TemplateId1.Equals(ROWWITH_HS) || CRHeader.TemplateId1.Equals(ROWWITHOUTHS))
                            {
                                CRD = CRManager.getROWbasedCertificateRequestDetails(RequestID);
                            }
                            else { CRDetails = CRManager.getReqDetailByReqID(RequestID, true); }
                            SupList = CRManager.getSupportingDOCfRequest(RequestID);
                            result = CreateCertificate(TemplateID);
                        }
                        else
                        {
                            getUSupportingDOC(RequestID);
                            result = ApproveCertificateRequest(CustomerID, RequestID, UploadPath,Convert.ToBoolean(lblSealRequired.Text));
                        }
                        if (!result)
                        {
                            getPendingCRequest(drpCustomer.SelectedValue);
                            return;
                        }
                    }
                }
                // Thread.Sleep(100);
            }
            getPendingCRequest(drpCustomer.SelectedValue);
        }

        protected void gvPendigCR_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("CertificateDetails.aspx?ReqstID=" + gvPendigCR.SelectedRow.Cells[0].Text, false);
        }

        protected void gvPendigCR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPendigCR.PageIndex = e.NewPageIndex;
            getPendingCRequest(drpCustomer.SelectedValue);
        }

        protected void btnApprove_Click(object sender, EventArgs e) ////
        {
            try
            {
                if (userSession.C_Password.Equals(""))
                {
                    using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                    {
                        Label lblRequestID = (Label)row.FindControl("lblRequestID");
                        Label lblTemplateID = (Label)row.FindControl("lblTemplateID");
                        Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                        Label lblCustomerID = (Label)row.FindControl("lblCustomerID");
                        Label lblCRequestType = (Label)row.FindControl("lblCertificateType");
                        Label lblSealRequired = (Label)row.FindControl("lblSealRequired");

                        txtRequestID.Text = lblRequestID.Text;
                        txtTemplateID.Text = lblTemplateID.Text;
                        txtCustomerID.Text = lblCustomerID.Text;
                        txtUploadPath.Text = lblUploadPath.Text;
                        txtCRequestType.Text = lblCRequestType.Text;
                        txtSealBoolen.Text = lblSealRequired.Text;

                    }
                    LblError2.Text = string.Empty;
                    mp2.Show();
                }
                else
                {
                    using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                    {
                        Label lblRequestID = (Label)row.FindControl("lblRequestID");
                        Label lblRequestType = (Label)row.FindControl("lblCertificateType");
                        Label lblTemplateID = (Label)row.FindControl("lblTemplateID");

                        Label lblUploadPath = (Label)row.FindControl("lblUploadPath");
                        Label lblCustomerID = (Label)row.FindControl("lblCustomerID");
                        Label lblSealRequired = (Label)row.FindControl("lblSealRequired");

                        string RequestID = lblRequestID.Text;
                        string TemplateID = lblTemplateID.Text;
                        string CustomerID = lblCustomerID.Text;
                        string UploadPath = lblUploadPath.Text;


                        if (lblRequestType.Text.Equals("W"))
                        {
                            CRHeader = CRManager.getRequestByID(RequestID);
                            if (CRHeader.TemplateId1.Equals(ROWWITH_HS) || CRHeader.TemplateId1.Equals(ROWWITHOUTHS))
                            {
                                CRD = CRManager.getROWbasedCertificateRequestDetails(RequestID);
                            }
                            else { CRDetails = CRManager.getReqDetailByReqID(RequestID, true); }
                            SupList = CRManager.getSupportingDOCfRequest(RequestID);
                            bool result = CreateCertificate(TemplateID);
                            if (!result)
                            {
                                getPendingCRequest(drpCustomer.SelectedValue);
                                mp2.Show();
                                LblError2.Text = "Wrong password or Corrupted Certificate file.";
                                return;
                            }
                            //else
                            //{
                            //    SendApprovedCertificates(CustomerID, RequestID); 
                            //}
                        }
                        else
                        {
                            getUSupportingDOC(RequestID);
                            bool result = ApproveCertificateRequest(CustomerID, RequestID, UploadPath,Convert.ToBoolean(lblSealRequired.Text));
                            //if (result) { SendApprovedCertificates(CustomerID, RequestID); }
                        }

                    }
                    
                    getPendingCRequest(drpCustomer.SelectedValue);
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("PendingCertificates.aspx - Single Approval button", Ex);
            }
        } 

        protected void btnReject_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                Label lblCertificateType = (Label)row.FindControl("lblCertificateType");
                Label lblCEmail = (Label)row.FindControl("lblCEmail");

                lblRejectRequestID.Text = lblRequestID.Text;
                lblRCertificateType.Text = lblCertificateType.Text;
                lblCUSEmail.Text = lblCEmail.Text;

            }
            lblRejectError.Text = string.Empty;
            mp3.Show();
        }

        protected void btnApproveCertificate_Click(object sender, EventArgs e)
        {
            userSession.C_Password = txtCpassword.Text;
            if (txtCRequestType.Text.Equals("W"))
            {
                CRHeader = CRManager.getRequestByID(txtRequestID.Text);
                if (CRHeader.TemplateId1.Equals(ROWWITH_HS) || CRHeader.TemplateId1.Equals(ROWWITHOUTHS))
                {
                    CRD = CRManager.getROWbasedCertificateRequestDetails(txtRequestID.Text);
                }
                else { CRDetails = CRManager.getReqDetailByReqID(txtRequestID.Text, true); }
                SupList = CRManager.getSupportingDOCfRequest(txtRequestID.Text);
                bool result = CreateCertificate(txtTemplateID.Text);
                if (!result)
                {
                    mp2.Show();
                    LblError2.Text = "Wrong password or Corrupted Certificate file.";
                    return;
                }
                //else
                //{
                //    SendApprovedCertificates(txtCustomerID.Text, txtRequestID.Text);
                //}
            }
            else
            {
                getUSupportingDOC(txtRequestID.Text);
                bool result = ApproveCertificateRequest(txtCustomerID.Text, txtRequestID.Text, txtUploadPath.Text,Convert.ToBoolean(txtSealBoolen.Text));
                //if (result) { SendApprovedCertificates(txtCustomerID.Text, txtRequestID.Text); }
            }
            getPendingCRequest(drpCustomer.SelectedValue);
        }

        protected void likViewSupportingDoc_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblRequestID = (Label)row.FindControl("lblRequestID");
                Label lblCertificateType = (Label)row.FindControl("lblCertificateType");
                if (lblCertificateType.Text.Equals("W"))
                {
                    getSupportingDOC(lblRequestID.Text);
                    lblCType.Text = "W";
                }
                else
                {
                    getUSupportingDOC(lblRequestID.Text);
                    lblCType.Text = "U";
                }
                mpSD.Show(); 
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
                   // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>"); 

                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_blank');", true);

                    if (lblCType.Text.Equals("W"))
                    {

                        getSupportingDOC(lblRefNo.Text);
                        lblCType.Text = "W";
                    }
                    else
                    {

                        getUSupportingDOC(lblRefNo.Text);
                        lblCType.Text = "U";
                    }
                    mpSD.Show();

                }
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong> Unable To Download The File....</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }

        }

        protected void btnRejectCertificateReq_Click(object sender, EventArgs e)
        {
            if (drpRejectReason.SelectedIndex == 0)
            {
                lblRejectError.Text = "Please Select a Reject Reson First.";
                mp3.Show();
                return;
            }
            try 
            {
                bool result = false;
                if (lblRCertificateType.Text.Equals("W"))
                {
                    result = CSMan.RejectCertificate(lblRejectRequestID.Text, userSession.User_Id, drpRejectReason.SelectedValue);
                }
                else
                {
                    result = CSMan.RejectUBCertificate(lblRejectRequestID.Text, userSession.User_Id, drpRejectReason.SelectedValue);
                }

                if (result)
                {

                    SendManger.SendEmail(lblCUSEmail.Text,
                              "Certificate Rejected",
                              "<h2 align=\"center\" style=\"color:#0178d8;\">National Chamber of Exporters of Sri Lanka</h2>" +
                              "<h3 align=\"center\">National Chamber of Exporters of Sri Lanka</h3><br>" +
                              "<p>This is to inform your request (Doc. No " + lblRejectRequestID.Text + " )has been Rejected by the NCE.</p>" +
                              "Rejected Reason : " + drpRejectReason.SelectedItem.Text + "</p>"
                              + "<p>For further clarifications, please contact Mr. Susantha Rupathunga on 4344218 or nce.dco@gmail.com</p>", "");

                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Request Rejected.";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingCRequest(drpCustomer.SelectedValue);

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

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblPath = (Label)row.FindControl("lblUploadPath");
                    Label lblRequestID = (Label)row.FindControl("lblRequestID");
                    Session["PDFUrl"] = lblPath.Text;
                    string pageurl = "PdfView.aspx?ID=" + lblRequestID.Text + "&DN=" + lblRequestID.Text + ".pdf";
                   // Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + pageurl + "','_blank');", true);
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnByCustomer_Click(object sender, EventArgs e)
        {
            getPendingCRequest(drpCustomer.SelectedValue);
        }

        private bool ApproveCertificateRequest(string CustomerID, string RequestID, string CerificatePath,bool SealReqired)
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
                    SignCertificate.AddTextToPdf(NotSigned, CertificateID_Added, Certificate_No, Point, Server.MapPath(userSession.SignatureIMG_Path), SealReqired,userSession.Person_Name);

                    // string NotSigned = Server.MapPath(CerificatePath);
                    string Signed = Server.MapPath(DirectoryPath + "/" + Certificate_No + "_Certificate.pdf");
                    string pathe = Server.MapPath(userSession.PFX_path);//From DB
                    //string pathe = Server.MapPath("~/Signature/Samitha/Samitha.pfx");//From DB
                    string SignatureIMG = Server.MapPath(userSession.SignatureIMG_Path);// From DB
                    //string SignatureIMG = Server.MapPath("~/Signature/Samitha/Chernenko_Signature.png");// From DB

                    var PFX = new FileStream(pathe, FileMode.OpenOrCreate);

                    //  PDFCreator.Signature SignCertificate = new PDFCreator.Signature();
                    bool singed = SignCertificate.signCertificate(CertificateID_Added, Signed, PFX, userSession.C_Password);
                    if (!singed)
                    {
                        PFX.Close();
                        lblError.Text = "Wrong password or Corrupted Certificate file.";
                        userSession.C_Password = "";
                        mp2.Show();
                        return false;
                    }
                    CertificateApproval Approve = new CertificateApproval();
                    Approve.Certificate_Name = Certificate_No + "_Certificate.pdf";
                    Approve.Certificate_Path = DirectoryPath + "/" + Certificate_No + "_Certificate.pdf";
                    //  Approve.Created_By = "SAMITHA";
                    Approve.Created_By = userSession.User_Id;
                    Approve.Expiry_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays));
                    Approve.Is_Downloaded = "N";
                    Approve.Is_Valid = "Y";
                    Approve.Request_Id = RequestID;
                    Approve.Certificate_Id = Certificate_No;

                    bool result = CSMan.ApproveCertificate(Approve);
                    bool result2 = CRManager.UpdateUploadBCertifcateRequest(Approve);
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

                            SignDoc.AddSealSD(Server.MapPath(SupList[i].Uploaded_Path), SealedPath, Server.MapPath(userSession.SignatureIMG_Path));

                            var PFX2 = new FileStream(pathe, FileMode.OpenOrCreate);

                            bool Sign = SignDoc.signSupportingDoc(Certificate_No,
                                SealedPath,
                                DocPath,
                                PFX2, userSession.C_Password);

                            if (!Sign)
                            {
                                PFX.Close();
                                PFX2.Close();
                                userSession.C_Password = "";
                                lblError.Text = "Corrupted Supporting Document file. Signature Placement Failed !";
                                mp2.Show();
                                return false;
                            }

                            SupList[i].Certified_Doc_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;
                            SupList[i].Status_ = "A";
                            SupList[i].Customer_ID = CustomerID;
                            SupList[i].Approved_By = userSession.User_Id;
                            SupList[i].Expire_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays)).ToString();

                            SDsign.setSupportingDocSignRequestINCertRequest(SupList[i]);

                            SupList[i].Uploaded_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;

                            CRManager.UpdateSupportingDocCertified(SupList[i]);


                        }
                    }
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Certificate Approval Successful..";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button></div>";

                    ErrorMessage.InnerHtml = qu;
                    getPendingCRequest(drpCustomer.SelectedValue);

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
                    getPendingCRequest(drpCustomer.SelectedValue);
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
                    getPendingCRequest(drpCustomer.SelectedValue);
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
                    getPendingCRequest(drpCustomer.SelectedValue);
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
                    getPendingCRequest(drpCustomer.SelectedValue);
                    ErrorLog.LogError(Ex);
                    return false;
                }

            }
        }

        protected void SendApprovedCertificates(string Cid,string Rid)
        {
            

            ERlist = SendManger.getSendPendingMailSendingCertificates(Cid,Rid);
            if (ERlist.Count != 0)
            {
                for (int x = 0; x < ERlist.Count(); x++)
                {
                    try
                    {
                        int Send = 0;
                        //Send = SendManger.SendEmail(ERlist[x].Email_,
                        //                     "Certificate Approved",
                        //                     "Your Certificate Request Under Ref No : "
                        //                     +ERlist[x].Request_ID +" Has Been Approved. You can Download it Under "
                        //                     + "Certificate-Id : " + ERlist[x].Certificate_Id,"");

                        Send = SendManger.SendEmail(ERlist[x].Email_,
                                                     "Certificate Approved",
                                                     "<h2 align=\"center\" style=\"color:#0178d8;\">National Chamber of Exporters of Sri Lanka</h2>" +
                                                     //"<h3 align=\"center\">National Chamber of Exporters of Sri Lanka</h3><br>" +
                                                     "<p>Thank you for placing the request of the Certificate of Origin from the National Chamber of Exporters of Sri Lanka.</p>"+
                                                     "<p>This is to confirm your request (Doc. No " + ERlist[x].Request_ID + " )has been approved by the NCE.</p>" +
                                                     "<p>You can Download it Under "
                                                     + "Reference No : " + ERlist[x].Certificate_Id +"</p>"
                                                     + "<p>For further clarifications, please contact Mr. Susantha Rupathunga on 4344218 or nce.dco@gmail.com", "");
                        if (Send == 1)
                        {
                            SendManger.UpdateApprovalMailsend(ERlist[x].Certificate_Id);
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
                            qu += "Confirmation Email Send Faild.</div>";
                            ErrorMessage.InnerHtml = qu;
                        }
                    }
                    catch (Exception Ex)
                    {
                        ErrorLog.LogError("Email Sending Fail", Ex);
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Confirmation Email Send Faild.</div>";
                        ErrorMessage.InnerHtml = qu;
                    }
                }
            }


        }

        protected void btnSendApproval_Click(object sender, EventArgs e)
        {
            SendApprovedCertificates("%","%");
        }

    }
}