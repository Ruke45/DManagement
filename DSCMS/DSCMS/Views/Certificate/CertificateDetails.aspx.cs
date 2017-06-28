using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DCISDBManager.objLib.Master;
using DCISDBManager.trnLib.MasterDataManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.SupportDocumentSignManagement;
using System.Transactions;

namespace DSCMS.Views.Certificate
{
    public partial class CertificateDetails : System.Web.UI.Page
    {
        UserSession userSession;
        CheckAuthManager authorized=new CheckAuthManager();
        CertificateRequestManager Crm = new CertificateRequestManager();
        CertificateRequestHeader Crh = new CertificateRequestHeader();
        CertificateSignManagment CSMan = new CertificateSignManagment();

        SupportingDocumentManagement SDManager = new SupportingDocumentManagement();
        SDocSignRequsetManager SDsign = new SDocSignRequsetManager();

        static List<CertificateRequestDetail> ReDe = new List<CertificateRequestDetail>();
        static List<SupportingDocUpload> SupList = new List<SupportingDocUpload>();
        List<RejectResons> RejectResons = new List<RejectResons>();


        string TemplateID = string.Empty;

        string ExpireDays = System.Configuration.ConfigurationManager.AppSettings["CertificateExpire"];

        string HSCODEHAS = System.Configuration.ConfigurationManager.AppSettings["HSCODEHAS"];
        string GOLOBALTMP = System.Configuration.ConfigurationManager.AppSettings["GOLOBALTMP"];
        string MASSACTIVE = System.Configuration.ConfigurationManager.AppSettings["MASSACTIVE"];
        string NINDROTMP = System.Configuration.ConfigurationManager.AppSettings["NINDROTMP"];
        string ROWWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["ROWWITHOUTHS"];
        string COLUMNWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["COLUMNWITHOUTHS"];

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            if (userSession == null)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "CREQD"))
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
                btnRequestCertificate.Enabled = false;
                btnRequestCertificate.Enabled = false;
               // btnRejectCertificateReq.Enabled = false;

            }
            LoadCertificateRequest();

            if (!IsPostBack)
            {
                getRejectResons();

                if (TemplateID.Equals(ROWWITHOUTHS))
                {
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                }
                else if (TemplateID.Equals(COLUMNWITHOUTHS))
                {
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                }
                else if (TemplateID.Equals(NINDROTMP))
                {
                    divPortofDischarg.Visible = false;
                    divePlaceofDel.Visible = false;
                    txtPortDischrg.Visible = false;
                    txtPlcofDelivry.Visible = false;
                    diveRemarkGlobl.Visible = false;
                }
                else if (TemplateID.Equals(MASSACTIVE))
                {
                    divPortofDischarg.Visible = false;
                    divePlaceofDel.Visible = false;
                    txtPortDischrg.Visible = false;
                    txtPlcofDelivry.Visible = false;
                    diveRemarkGlobl.Visible = false;
                }
                else if (TemplateID.Equals(HSCODEHAS))
                {
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                }
                else
                {
                    divOtherComments.Visible = false;
                }

            }
            
        }

        protected void LoadCertificateRequest()
        {

            string id =  Request.QueryString["ReqstID"];

            Crh = Crm.getRequestByID(id);

            txtConsignee.Text = Crh.Consignee1;
            txtInvoDate.Text = Crh.InvoiceDate1.ToString("dd/MM/yyyy");
            txtExporter.Text = Crh.Consignor1;
            txtInvoNo.Text = Crh.InvoiceNo1;
            txtInvoVal.Text = Crh.TotalInvoiceValue1.ToString();
            txtPlcofDelivry.Text = Crh.PlaceOfDelivery1;
            txtPortDischrg.Text = Crh.PortOfDischarge1;
            txtPortLoading.Text = Crh.LoadingPort1;
            txtTotQunatity.Text = Crh.TotalQuantity1;
            txtVessel.Text = Crh.Vessel1;
            txtCountryOfOrigin.Text = Crh.CountryName1;
            lblRequestID.Text = Crh.RequestId1;
            TemplateID = Crh.TemplateId1;
            txtOtherComments.Text = Crh.OtherComments1;
  

            getItemDetails(id, Crm);
            getSupportingDOC(id, Crm);

        }

        private void getItemDetails(string id, CertificateRequestManager Crm)
        {
            ReDe = Crm.getReqDetailByReqID(id,true);
            gvCItems.DataSource = ReDe;
            gvCItems.DataBind();
        }
        private void getSupportingDOC(string id, CertificateRequestManager Crm)
        {
            SupList = Crm.getSupportingDOCfRequest(id);
            gvSupportingDOc.DataSource = SupList;
            gvSupportingDOc.DataBind();
        }

        private void getRejectResons()
        {
            RejectResonManagment ReM = new RejectResonManagment();
            drpRejectReason.DataSource = ReM.getCertificaterRejectResons();
            drpRejectReason.DataTextField = "Reason_";
            drpRejectReason.DataValueField = "Reason_Code";
            drpRejectReason.DataBind();
        }

        protected void linkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    for (int i = 0; i < SupList.Count; i++)
                    {
                        if (SupList[i].Seq_No == Convert.ToInt64(row.Cells[0].Text))
                        {
                            Response.ContentType = "APPLICATION/OCTET-STREAM";
                            String Header = "Attachment; Filename=" + SupList[i].Document_Name;
                            Response.AppendHeader("Content-Disposition", Header);
                            System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(SupList[i].Uploaded_Path));
                            Response.WriteFile(Dfile.FullName);
                            //Don't forget to add the following line
                            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
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

        protected void btnRequestCertificate_Click(object sender, EventArgs e)
        {
           // txtComment.Text = string.Empty;
           //if(Crh.Status1.Equals("A"))
           //{
           //    string qu = null;
           //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
           //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
           //    qu += " <strong> Error ! </strong>This Certificate Is Already Been Approved.</div>";
           //    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

           //    ErrorMessage.InnerHtml = qu;
           //    return;
           //}
            mp1.Show();
            txtComment.Text = string.Empty;
            lblError.Text = string.Empty;

        }

        protected void btnCerateCertificate_Click(object sender, EventArgs e)
        {
            //using (TransactionScope transactionScope = new TransactionScope())
            //{
            //    try
            //    {
            //        SequenceManager seqmanager = new SequenceManager();
            //        string Certificate_No = "CE" + seqmanager.getNextSequence("CertificateSign").ToString();

            //        string LogoPath = Server.MapPath("~/img/NCELOGO.PNG"); // NCE Certificate logo Image path
            //        string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy") 
            //                                + "/" + DateTime.Now.ToString("yyyy_MM_dd") 
            //                                + "/" + Certificate_No + "_Certificate";
            //        //DirectoryPath which will save the NOT singed PDF File as NOT_Signed.pdf in the given Path
            //        if (!Directory.Exists(Server.MapPath(DirectoryPath)))
            //        {
            //            Directory.CreateDirectory(Server.MapPath(DirectoryPath));
            //        }

            //        /**PDF Cerator 
            //         * Parameters
            //         * Certificate Reques Header Detail Object
            //         * Certificate Request Item Details Object List
            //         * Document Save Path
            //         * 
            //        */
            //        PDFCreator.CertificateCreate Certificate =
            //            new PDFCreator.CertificateCreate(Certificate_No, Crh,
            //                ReDe, LogoPath,
            //                Server.MapPath(DirectoryPath + "/NOT_Signed.pdf"),
            //                userSession.Person_Name, "--");
            //        // Certificate.CreateCertificate(HS CODe Is True Or False, Comment);
            //        if (Crh.TemplateId1.Equals(HSCODEHAS))
            //        {
            //            Certificate.CreateCertificate(true, false, txtComment.Text.ToString());
            //        }
            //        else if (Crh.TemplateId1.Equals(HSCODE_N_BTMROW))
            //        {
            //            Certificate.CreateCertificate(true, true, txtComment.Text.ToString());
            //        }
            //        else if (Crh.TemplateId1.Equals(MASSACTIVE))
            //        {
            //            Certificate.CreateCertificate(false, false, txtComment.Text.ToString());
            //        }
            //        else if (Crh.TemplateId1.Equals(NINDROTMP))
            //        {
            //            Certificate.CreateCertificate(true, false, txtComment.Text.ToString());
            //        }
            //        else if (Crh.TemplateId1.Equals(ROWWITHOUTHS))
            //        {
            //            Certificate.CreateCertificate(false, false, txtComment.Text.ToString());
            //        }
            //        else
            //        {
            //            Certificate.CreateCertificate(false, false, txtComment.Text.ToString());
            //        }

            //        string NotSigned = Server.MapPath(DirectoryPath + "/NOT_Signed.pdf");
            //        string Signed = Server.MapPath(DirectoryPath + "/" + Certificate_No + "_Certificate.pdf");
            //        string pathe = Server.MapPath(userSession.PFX_path);//From DB
            //        //  string pathe = Server.MapPath("~/Signature/Samitha/Samitha.pfx");//From DB
            //        string SignatureIMG = Server.MapPath(userSession.SignatureIMG_Path);// From DB
            //        //   string SignatureIMG = Server.MapPath("~/Signature/Samitha/sign.JPG");// From DB

            //        var PFX = new FileStream(pathe, FileMode.OpenOrCreate);
          

            //        PDFCreator.Signature SignCertificate = new PDFCreator.Signature();
            //        bool singed = SignCertificate.signCertificate(NotSigned, Signed,
            //                                                      PFX, txtCertificatePass.Text,
            //                                                      SignatureIMG);
            //        if (!singed)
            //        {
            //            PFX.Close();
            //            mp1.Show();
            //            lblError.Text = "Wrong password or Corrupted Certificate file.";
            //            return;
            //        }

            //        CertificateApproval Approve = new CertificateApproval();
            //        Approve.Certificate_Name = Certificate_No + "_Certificate.pdf";
            //        Approve.Certificate_Path = DirectoryPath + "/" + Certificate_No + "_Certificate.pdf";
            //        // Approve.Created_By = "SAMITHA";
            //        Approve.Created_By = userSession.User_Id;
            //        Approve.Expiry_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays));
            //        Approve.Is_Downloaded = "N";
            //        Approve.Is_Valid = "Y";
            //        Approve.Request_Id = Crh.RequestId1;
            //        Approve.Certificate_Id = Certificate_No;

            //        bool result = CSMan.ApproveCertificate(Approve);
            //        if (!result)
            //        {
            //            string qu = null;
            //            qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //            qu += " <strong> Successful ! </strong>Certificate Approval Faild</div>";
            //            qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";
            //            ErrorMessage.InnerHtml = qu;
            //            return;

            //        }
            //        for (int i = 0; i < SupList.Count(); i++)
            //        {
            //            if (SupList[i]._Remarks.Equals("Certification"))
            //            {
            //                string DocPath = Server.MapPath(DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name);
            //                if (!Directory.Exists(Server.MapPath(DirectoryPath + "/Supporting-Doc")))
            //                {
            //                    Directory.CreateDirectory(Server.MapPath(DirectoryPath + "/Supporting-Doc"));
            //                }

            //                PDFCreator.Signature SignDoc = new PDFCreator.Signature();
            //                var PFX2 = new FileStream(pathe, FileMode.OpenOrCreate);

            //                bool Sign = SignDoc.signCertificate(
            //                    Server.MapPath(SupList[i].Uploaded_Path),
            //                    DocPath,
            //                    PFX2, txtCertificatePass.Text, SignatureIMG);

            //                if (!Sign)
            //                {
            //                    PFX.Close();
            //                    PFX2.Close();
            //                    lblError.Text = "Corrupted Supporting Document file. Signature Placement Failed !";
            //                    mp1.Show();
            //                    return;
            //                }

            //                SupList[i].Certified_Doc_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;
            //                SupList[i].Status_ = "A";
            //                SupList[i].Customer_ID = Crh.CustomerId1;
            //                SupList[i].Approved_By = userSession.User_Id;
            //                SupList[i].Expire_Date = DateTime.Today.AddDays(Convert.ToInt64(ExpireDays)).ToString();

            //                SDsign.setSupportingDocSignRequestINCertRequest(SupList[i]);

            //                SupList[i].Uploaded_Path = DirectoryPath + "/Supporting-Doc/" + SupList[i].Document_Name;
            //                Crm.UpdateSupportingDocCertified(SupList[i]);


            //            }
            //        }

            //        transactionScope.Complete();
            //        transactionScope.Dispose();
            //        string Qu = null;
            //        Qu += "<div class=\"alert alert-dismissable alert-success\">";
            //        Qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //        Qu += " <strong> Successful ! </strong>Certificate Approval Successful. Certificate ID : " + Certificate_No + "</div>";
            //        Qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //        ErrorMessage.InnerHtml = Qu;
            //        btnRequestCertificate.Enabled = false;
            //        btnRejectRequest.Enabled = false;

            //    }
            //    catch (TransactionAbortedException Ex)
            //    {
            //        transactionScope.Dispose();
                    
            //        string qu = null;
            //        qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //        qu += " <strong> Error ! (Transaction) </strong>Unable to Complete the Request. Please Contact the Administrator</div>";
            //        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //        ErrorMessage.InnerHtml = qu;
            //        ErrorLog.LogError(Ex);
            //    }
            //    catch (FileNotFoundException Ex)
            //    {
            //        string qu = null;
            //        qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //        qu += " <strong> Error ! </strong>Certificate File Not Found ! Please Contact the Administrator</div>";
            //        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //        ErrorMessage.InnerHtml = qu;
            //        ErrorLog.LogError(Ex);
            //    }
            //    catch (FieldAccessException Ex)
            //    {
            //        string qu = null;
            //        qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //        qu += " <strong> Error ! </strong>Cannot Access the Certificate Files Please Contact the Administrator</div>";
            //        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //        ErrorMessage.InnerHtml = qu;
            //        ErrorLog.LogError(Ex);
            //    }
            //    catch (Exception Ex)
            //    {
            //        string qu = null;
            //        qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //        qu += " <strong> Error ! </strong>Cannot Access the Files Please Contact the Administrator</div>";
            //        qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //        ErrorMessage.InnerHtml = qu;
            //        ErrorLog.LogError(Ex);
            //    }
            //}

        }

        protected void btnRejectRequest_Click(object sender, EventArgs e)
        {
            //if (Crh.Status1.Equals("A"))
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong>This Certificate Is Already Been Approved.</div>";
            //    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}
            mp2.Show();
        }

        protected void btnRejectCertificateReq_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpRejectReason.SelectedIndex == 0)
                {
                    lblRejectError.Text = "Please Select a Reject Reson First.";
                    mp2.Show();
                    return;
                }
                bool result = CSMan.RejectCertificate(Crh.RequestId1, userSession.User_Id, drpRejectReason.SelectedValue);
                if (result)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Success ! </strong>Certificate Rejected...</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                    btnRequestCertificate.Enabled = false;
                    btnRejectRequest.Enabled = false;
                }
                else
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Faild to Complete the Task Please Try Again Later.</div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error (Exception) ! </strong>Faild to Complete the Task Please Try Again Later.</div>";
                qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                ErrorMessage.InnerHtml = qu;
            }


        }



    }
}