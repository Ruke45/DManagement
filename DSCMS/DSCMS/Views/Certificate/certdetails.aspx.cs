using DCISDBManager.objLib.Certificate;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.MasterDataManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.trnLib.EmailManager;

namespace DSCMS.Views.Certificate
{
    public partial class certdetails : System.Web.UI.Page
    {
        UserSession userSession;
        UserManager usrM = new UserManager();
        CertificateRequestManager Crm = new CertificateRequestManager();
        List<CertificateRequestDetail> ReDe = new List<CertificateRequestDetail>();
        List<SupportingDocUpload> SupList = new List<SupportingDocUpload>();
        CertificateRequestDetail CRD = new CertificateRequestDetail();
        CertficateRequestDataManagement cd = new CertficateRequestDataManagement();

        CertificateRequestHeader Crh = new CertificateRequestHeader();
        UserSignature Sign = new UserSignature();
        DCISDBManager.objLib.Usr.User Usr = new DCISDBManager.objLib.Usr.User();
        DCISDBManager.objLib.Usr.User Usr2 = new DCISDBManager.objLib.Usr.User();
        CheckAuthManager authorized;
        string Template_ID;
        string Customer_Name;
        string Telephone_;

        string HSCODEHAS = System.Configuration.ConfigurationManager.AppSettings["HSCODEHAS"];
        string GOLOBALTMP = System.Configuration.ConfigurationManager.AppSettings["GOLOBALTMP"];
        string MASSACTIVE = System.Configuration.ConfigurationManager.AppSettings["MASSACTIVE"];
        string NINDROTMP = System.Configuration.ConfigurationManager.AppSettings["NINDROTMP"];
        string ROWWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["ROWWITHOUTHS"];
        string ROWWITH_HS = System.Configuration.ConfigurationManager.AppSettings["ROWWITH_HS"];
        string COLUMNWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["COLUMNWITHOUTHS"];

        string UserGroupID_Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        string UserGroupID_CustomerAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
        string UserGroupID_SAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];

        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            //this.Form.Enctype = "multipart/form-data";

            authorized = new CheckAuthManager();
            string id2 = Request.QueryString["ReqstID"];

            string userid1=cd.getuseridfrmreqid(id2);

            Usr = usrM.getUserDetails(userid1, "%", "%","%");


           //

            //userSession.User_Id = Usr.User_ID;
            //userSession.User_Group = Usr.UserGroup_ID;
            //userSession.Is_Active = Usr.Is_Active;
            //// userSession.Is_Vat = Usr.Is_Vat;
            //userSession.PasswordExpire_Date = Usr.PassowordExpiry_Date;
            //userSession.Person_Name = Usr.Person_Name;


       
          
               
                Usr2 = usrM.getCustomerTemplate(Usr.Customer_ID);
               
                    Template_ID = Usr2.Template_ID;
                   Customer_Name = Usr2.Customer_Name;
                    Telephone_ = Usr2.Telephone_;
                
           












            //
          





            //if (!authorized.IsUserGroupAuthorised(userSession.User_Group, "CREQE"))
            //{
            //    Response.Redirect("~/Views/Home/Forbidden.aspx");
            //}
            if (!IsPostBack)
            {
                string id = Request.QueryString["ReqstID"];
                if (Crm.checkCertificateEditRequest(Usr.Customer_ID, id))
                {

                    //getPackageType();
                    getCountries();
                    LoadCertificateRequest();


                    if (Template_ID.Equals(ROWWITHOUTHS))
                    {
                        divOtherComments.Visible = false;
                        diveRemarkGlobl.Visible = false;
                        DivNormal.Visible = false;
                        HSDetails.Visible = false;
                    }
                    else if (Template_ID.Equals(ROWWITH_HS))
                    {
                        divOtherComments.Visible = false;
                        diveRemarkGlobl.Visible = false;
                        DivNormal.Visible = false;

                    }
                    else if (Template_ID.Equals(COLUMNWITHOUTHS))
                    {
                        txtHScode.Visible = false;
                        lblHScode.Visible = false;
                        divOtherComments.Visible = false;
                        diveRemarkGlobl.Visible = false;
                        ROWBase.Visible = false;
                    }
                    else if (Template_ID.Equals(NINDROTMP))
                    {
                        divPOD.Visible = false;
                        divPODE.Visible = false;
                        txtPortDischrg.Visible = false;
                        txtPlcofDelivry.Visible = false;
                        diveRemarkGlobl.Visible = false;
                        ROWBase.Visible = false;
                    }
                    else if (Template_ID.Equals(MASSACTIVE))
                    {
                        txtHScode.Visible = false;
                        lblHScode.Visible = false;
                        divPOD.Visible = false;
                        divPODE.Visible = false;
                        txtPortDischrg.Visible = false;
                        txtPlcofDelivry.Visible = false;
                        diveRemarkGlobl.Visible = false;
                        ROWBase.Visible = false;
                    }
                    else if (Template_ID.Equals(HSCODEHAS))
                    {
                        divOtherComments.Visible = false;
                        diveRemarkGlobl.Visible = false;
                        ROWBase.Visible = false;
                    }
                    else
                    {
                        divOtherComments.Visible = false;
                        ROWBase.Visible = false;
                    }

                }
                else
                {
                    Response.Redirect("~/Views/Home/Forbidden.aspx");
                }
            }

        }

        //protected void getPackageType()
        //{
        //    try
        //    {
        //        PackageTypeManager Pkm = new PackageTypeManager();//Here
        //        drpPakgType.DataSource = Pkm.getPackageTypeList("%").Packageresultset;
        //        drpPakgType.DataTextField = "PackageDescription";
        //        drpPakgType.DataValueField = "PackageType";
        //        drpPakgType.DataBind();
        //    }
        //    catch (Exception Ex)
        //    {
        //        ErrorLog.LogError(Ex);
        //    }
        //}

        protected void getCountries()
        {
            try
            {
                CountryManager cm = new CountryManager();
                drpCountry.DataSource = cm.getCountry("%").Countryresultset;
                drpCountry.DataTextField = "CountryName";
                drpCountry.DataValueField = "CountryCode";
                drpCountry.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
            //  drpCountry.SelectedIndex = drpCountry.Items.IndexOf(drpCountry.Items.FindByValue("SL"));
        }

        private void getSupportingDOC(string id, CertificateRequestManager Crm)
        {
            try
            {
                SupList = Crm.getSupportingDOCfRequest(id);
                gvSupportingDOc.DataSource = SupList;
                gvSupportingDOc.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        private void getNotUploadedSupportingDOC(string id, CertificateRequestManager Crm)
        {
            try
            {
                gvNotUploadedDOC.DataSource = Crm.getNotUploadedSupportingDOCfRequest(id).Not_Uploaded_SD;
                gvNotUploadedDOC.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void LoadCertificateRequest()
        {
            try
            {
                string id = Request.QueryString["ReqstID"];

                Crh = Crm.getRequestByID(id);

                txtConsignee.Text = Crh.Consignee1;
                txtDate.Text = Crh.InvoiceDate1.ToString("yyyy/MM/dd");
                txtExporter.Text = Crh.Consignor1;
                txtInvoNo.Text = Crh.InvoiceNo1;
                txtInvoVal.Text = Crh.TotalInvoiceValue1.ToString();
                txtPlcofDelivry.Text = Crh.PlaceOfDelivery1;
                txtPortDischrg.Text = Crh.PortOfDischarge1;
                txtPortLoading.Text = Crh.LoadingPort1;
                txtTotQunatity.Text = Crh.TotalQuantity1;
                txtVessel.Text = Crh.Vessel1;
                drpCountry.SelectedIndex = drpCountry.Items.IndexOf(drpCountry.Items.FindByValue(Crh.CountryCode1));
                txtOtherComments.Text = Crh.OtherComments1;
                txtOtherDetails.Text = Crh.OtherDetails1;
                chckSealRequired.Checked = Convert.ToBoolean(Crh.Seal_Required);

                if (userSession.Template_ID.Equals(ROWWITH_HS) || userSession.Template_ID.Equals(ROWWITHOUTHS))
                {

                    CRD = Crm.getROWbasedCertificateRequestDetails(id);
                    txtSeqNo.Text = Convert.ToString(CRD.SeqNo1);
                    txtGoodDetails.Text = CRD.Good_Details.Replace("<br />", "\r\n");
                    txtHSDetails.Text = CRD.HSCode_Details.Replace("<br />", "\r\n");
                    txtQuantityDetails.Text = CRD.Quantity_Details.Replace("<br />", "\r\n");

                }
                else
                {
                    getItemDetails(id, Crm);
                }

                getSupportingDOC(id, Crm);
                getNotUploadedSupportingDOC(id, Crm);
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }

        }

        private void getItemDetails(string id, CertificateRequestManager Crm)
        {
            try
            {
                ReDe = Crm.getReqDetailByReqID(id, false);
                gvItemDetails.DataSource = ReDe;
                gvItemDetails.DataBind();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void linkEditItem_Click(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblSeqNo = (Label)row.FindControl("lblSeqNo");
                Label lblPackageType = (Label)row.FindControl("lblPackageType");
                txtGoodItem.Text = row.Cells[0].Text;
                txtShippingMark.Text = row.Cells[1].Text;
                //drpPakgType.SelectedIndex = drpPakgType.Items.IndexOf(drpPakgType.Items.FindByValue(lblPackageType.Text));//Here
                drpPakgType.Text = lblPackageType.Text;
                txtSummary.Text = row.Cells[3].Text;
                txtQuntity.Text = row.Cells[4].Text;
                if (row.Cells[5].Text == "&nbsp;")
                {
                    txtHScode.Text = "";
                }
                else
                {
                    txtHScode.Text = row.Cells[5].Text;
                }
                txtSequence.Text = lblSeqNo.Text;
            }
            mp1.Show();
        }

        protected void btnUpdateCertificate_Click(object sender, EventArgs e)
        {
            if (checkGridView() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>IF the Supporting Document Needs to Signed Please Upload a '.pdf' File</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (checkNotUploadedGridView() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Upload the Mandatory Supporting Documents.</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtConsignee.Text == "" || txtExporter.Text == "" || txtDate.Text == "" || txtInvoNo.Text == "" || txtVessel.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill out All the required Fields before submitting the Request</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtPortLoading.Text == "" || txtInvoVal.Text == "" || txtTotQunatity.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill out All the required Fields before submitting the Request</div>";


                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtPlcofDelivry.Visible == true)
            {
                if (txtPlcofDelivry.Text == "" || txtPortDischrg.Text == "")
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Please Fill All the Required Fields Before Submitting.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
            }
            if (ROWBase.Visible == true)
            {

                if (txtQuantityDetails.Text == "" || txtGoodDetails.Text == "")
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Please Fill the Shipping Goods Details.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }

                if (txtHSDetails.Visible == true && txtHSDetails.Text == "")
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Please Fill the HS Code Details.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
            }
            try
            {
                Convert.ToDateTime(txtDate.Text);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Enter a  Date in Invoice Date Text Box Ex: 2016/01/01</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            string RequestId = Request.QueryString["ReqstID"];

            CertificateRequestHeader HeaderR = new CertificateRequestHeader();

            HeaderR.RequestId1 = RequestId;
            HeaderR.Consignee1 = txtConsignee.Text;
            HeaderR.Consignor1 = txtExporter.Text;
            HeaderR.CountryCode1 = drpCountry.SelectedValue.ToString();
            HeaderR.CreatedBy1 = userSession.User_Id;
            HeaderR.CustomerId1 = userSession.Customer_ID;
            HeaderR.InvoiceDate1 = Convert.ToDateTime(txtDate.Text);
            HeaderR.InvoiceNo1 = txtInvoNo.Text;
            HeaderR.LoadingPort1 = txtPortLoading.Text;
            HeaderR.PlaceOfDelivery1 = txtPlcofDelivry.Text;
            HeaderR.PortOfDischarge1 = txtPortDischrg.Text;
            //HeaderR.TemplateId1 = userSession.te;
            HeaderR.TotalInvoiceValue1 = txtInvoVal.Text;
            HeaderR.TotalQuantity1 = txtTotQunatity.Text;
            HeaderR.Vessel1 = txtVessel.Text;
            HeaderR.Status1 = "P";
            HeaderR.OtherDetails1 = txtOtherDetails.Text;
            HeaderR.OtherComments1 = txtOtherComments.Text;
            HeaderR.Seal_Required = chckSealRequired.Checked.ToString();


            bool resutl = false;
            if (userSession.Template_ID.Equals(ROWWITH_HS) || userSession.Template_ID.Equals(ROWWITHOUTHS))
            {
                CertificateRequestDetail CRD = new CertificateRequestDetail();
                CRD.Good_Details = txtGoodDetails.Text.Replace("\r\n", "<br />");
                CRD.HSCode_Details = txtHSDetails.Text.Replace("\r\n", "<br />");
                CRD.Quantity_Details = txtQuantityDetails.Text.Replace("\r\n", "<br />");
                CRD.CreatedBy1 = userSession.User_Id;
                CRD.SeqNo1 = Convert.ToInt64(txtSeqNo.Text);

                resutl = Crm.updateCertificateRequest(HeaderR, CRD);
            }
            else
            {
                resutl = Crm.updateCertificateRequest(HeaderR, ReDe);
            }


            if (resutl)
            {
                foreach (GridViewRow row in gvSupportingDOc.Rows)
                {
                    Label SeqNo = (Label)row.FindControl("lblseqid");
                    string d = SeqNo.Text;
                    //TextBox ename = (TextBox)row.FindControl("txtename");
                    //TextBox emid = (TextBox)row.FindControl("txtemid");
                    CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

                    FileUpload fu = (FileUpload)row.FindControl("btnEditFileUpload");
                    bool sr = fu.HasFile;

                    string DirectoryPath = "~/Uploads/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/" + RequestId;
                    if (fu.HasFile)
                    {
                        if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                        {
                            Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                        }
                        string file = Path.Combine(Server.MapPath(DirectoryPath + "/"), fu.FileName.Replace(" ", "_"));
                        fu.SaveAs(file);

                        SupportingDocUpload objsup = new SupportingDocUpload();

                        objsup.Seq_No = Convert.ToInt64(SeqNo.Text);
                        objsup.Uploaded_By = userSession.User_Id;
                        objsup.Uploaded_Path = DirectoryPath + "/" + fu.FileName.Replace(" ", "_");
                        objsup.Document_Name = fu.FileName.Replace(" ", "_");

                        Crm.setUpdateSupportingDocumentFRequest(objsup);

                    }
                    if (chkSelect.Checked)
                    {
                        Crm.setUpdateSupportingDocumenSignature(Convert.ToInt64(SeqNo.Text), chkSelect.Checked, "Certification");
                    }
                    else
                    {
                        Crm.setUpdateSupportingDocumenSignature(Convert.ToInt64(SeqNo.Text), chkSelect.Checked, "");
                    }
                }

                LoadCertificateRequest();

                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "Certificate Request Edit Successfull.</div>";

                ErrorMessage.InnerHtml = qu;
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (txtSequence.Text.Equals("A"))
            {
                CRD.RequestId1 = Request.QueryString["ReqstID"];
                CRD.GoodItem1 = txtGoodItem.Text;
                CRD.HSCode1 = txtHScode.Text;
                CRD.PackageType1 = drpPakgType.Text;//Here
                CRD.Quantity1 = txtQuntity.Text;
                CRD.SummaryDesc1 = txtSummary.Text;
                CRD.ShippingMark1 = txtShippingMark.Text;
                CRD.CreatedBy1 = userSession.User_Id;

                Crm.setCertificateRequestDetails(CRD);

                LoadCertificateRequest();
            }
            else
            {
                if (userSession.Template_ID == ROWWITHOUTHS || userSession.Template_ID == COLUMNWITHOUTHS || userSession.Template_ID == MASSACTIVE)
                {
                    if (txtGoodItem.Text == "" || txtQuntity.Text == "" || txtSummary.Text == "" || txtShippingMark.Text == "")
                    {
                        lblError.Text = "Please Fill out All the Fields";
                        mp1.Show();
                        return;
                    }
                }
                else
                {
                    if (txtGoodItem.Text == "" || txtQuntity.Text == "" || txtSummary.Text == "" || txtShippingMark.Text == "" || txtHScode.Text == "")
                    {
                        lblError.Text = "Please Fill out All the Fields";
                        mp1.Show();
                        return;
                    }
                }
                CertificateRequestDetail CRd = new CertificateRequestDetail();
                CRd.GoodItem1 = txtGoodItem.Text;
                CRd.PackageType1 = drpPakgType.Text;//here
                CRd.Quantity1 = txtQuntity.Text;
                CRd.ShippingMark1 = txtShippingMark.Text;
                CRd.SummaryDesc1 = txtSummary.Text;
                CRd.HSCode1 = txtHScode.Text;
                CRd.SeqNo1 = Convert.ToInt64(txtSequence.Text);

                Crm.setUpdateCertificateRequestDetails(CRd);
                this.LoadCertificateRequest();
            }
        }

        protected void linkDownload_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblseqid = (Label)row.FindControl("lblseqid");
                    Label Document_Name = (Label)row.FindControl("lblDocument_Name");
                    Label Uploaded_Path = (Label)row.FindControl("lblUploadP");

                    Response.ContentType = "APPLICATION/OCTET-STREAM";
                    String Header = "Attachment; Filename=" + Document_Name.Text;
                    Response.AppendHeader("Content-Disposition", Header);
                    System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(Uploaded_Path.Text));
                    Response.WriteFile(Dfile.FullName);
                    //Don't forget to add the following line
                    Response.End();
                }
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Download The File....</div>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }
        }

        private int checkGridView()
        {
            int count = 0;
            foreach (GridViewRow row in gvSupportingDOc.Rows)
            {
                Label lblUploadP = (Label)row.FindControl("lblUploadP");
                CheckBox IsSign = (CheckBox)row.FindControl("chkSelect");
                FileUpload fu = (FileUpload)row.FindControl("btnEditFileUpload");

                string UpPath = Server.MapPath(lblUploadP.Text);

                if (fu.HasFile == false)
                {
                    if (IsSign.Checked && !Path.GetExtension(UpPath).ToLower().Equals(".pdf"))
                    {
                        count++;
                    }
                }
                else
                {
                    string FuPath = System.IO.Path.GetExtension(fu.PostedFile.FileName);
                    if (IsSign.Checked && !Path.GetExtension(FuPath).ToLower().Equals(".pdf"))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int checkNotUploadedGridView()
        {
            int count = 0;
            foreach (GridViewRow row in gvNotUploadedDOC.Rows)
            {
                Label DocID = (Label)row.FindControl("SupDOCID");
                Label isMandotory = (Label)row.FindControl("lblIsmandatory");
                FileUpload fu = (FileUpload)row.FindControl("btnFileUpload");
                if (isMandotory.Text.ToUpper() == "Y")
                {
                    count++;
                }

            }
            return count;
        }

        private int isPDF()
        {
            int count = 0;
            foreach (GridViewRow row in gvNotUploadedDOC.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkRow2");
                FileUpload fu = (FileUpload)row.FindControl("btnFileUpload");
                if (chkRow.Checked && fu.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fu.PostedFile.FileName);
                    if (extension.ToLower() != ".pdf")
                    {
                        count++;
                    }
                }

            }
            return count;
        }

        protected void linkRemoveItem_Click(object sender, EventArgs e)
        {
            if (ReDe.Count == 1)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Cannot Remove ! </strong> There is only one item in the Request</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Int64 Seq = Convert.ToInt64(row.Cells[6].Text);
                Crm.setDELETECertificatRequestDetails(Seq);
            }
            LoadCertificateRequest();
        }

        protected void btnSendForApproval_Click(object sender, EventArgs e)
        {
            if (checkGridView() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>IF the Supporting Document Needs to Signed Please Upload a '.pdf' File</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (checkNotUploadedGridView() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Upload the Mandatory Supporting Documents.</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtConsignee.Text == "" || txtExporter.Text == "" || txtDate.Text == "" || txtInvoNo.Text == "" || txtVessel.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill out All the required Fields before submitting the Request</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtPortLoading.Text == "" || txtInvoVal.Text == "" || txtTotQunatity.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill out All the required Fields before submitting the Request</div>";


                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtPlcofDelivry.Visible == true)
            {
                if (txtPlcofDelivry.Text == "" || txtPortDischrg.Text == "")
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Please Fill All the Required Fields Before Submitting.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
            }
            if (ROWBase.Visible == true)
            {

                if (txtQuantityDetails.Text == "" || txtGoodDetails.Text == "")
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Please Fill the Shipping Goods Details.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }

                if (txtHSDetails.Visible == true && txtHSDetails.Text == "")
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong>Please Fill the HS Code Details.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
            }
            try
            {
                Convert.ToDateTime(txtDate.Text);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Enter a  Date in Invoice Date Text Box Ex: 2016/01/01</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            try
            {
                bool Created = false;
                string Template = userSession.Template_ID.ToString();
                LoadCertificateRequest();

                string LogoPath = Server.MapPath("~/img/NCELOGO.PNG"); // NCE Certificate logo Image path
                string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy")
                                        + "/Web_Based_Certificates/" + DateTime.Now.ToString("yyyy_MM_dd") + "/" + Crh.RequestId1;

                //Crh.Customer_Telephone = userSession.Telephone_;
                //Crh.CustomerName1 = userSession.Customer_Name;
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
                            new PDFCreator.RowWithHSTemplate(Crh,
                            CRD, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                else if (Template.Equals(ROWWITHOUTHS))
                {
                    PDFCreator.RowWithoutHSTemplate Certificate =
                            new PDFCreator.RowWithoutHSTemplate(Crh,
                            CRD, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                else if (Template.Equals(GOLOBALTMP))
                {
                    PDFCreator.OrientGlobalCertificateTemplate Certificate =
                            new PDFCreator.OrientGlobalCertificateTemplate(Crh,
                            ReDe, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                else if (Template.Equals(MASSACTIVE))
                {
                    PDFCreator.MassActiveCertificateTemplate Certificate =
                            new PDFCreator.MassActiveCertificateTemplate(Crh,
                            ReDe, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                else if (Template.Equals(NINDROTMP))
                {
                    PDFCreator.NidroCertificateTemplate Certificate =
                            new PDFCreator.NidroCertificateTemplate(Crh,
                            ReDe, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                else if (Template.Equals(COLUMNWITHOUTHS))
                {
                    PDFCreator.ColumnWithoutHSTemplate Certificate =
                            new PDFCreator.ColumnWithoutHSTemplate(Crh,
                            ReDe, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                else
                {
                    PDFCreator.ColumnWithHSTemplate Certificate =
                            new PDFCreator.ColumnWithHSTemplate(Crh,
                            ReDe, LogoPath,
                            Server.MapPath(DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf"), "", "");

                    Created = Certificate.CreateCertificate("");
                }
                if (Created)
                {
                    if (Crm.setWebBasedCertificateCreation(Crh.RequestId1,
                        DirectoryPath + "/" + Crh.RequestId1 + "_Sample_Cert.pdf",
                        Crh.RequestId1 + "_Sample_Cert.pdf"))
                    {

                        Crm.UpdateReqeustHeadStatus(Crh.RequestId1, "G");
                    }
                }

                Response.Redirect("~/Views/Certificate/PendingCertificateRequest.aspx");
                Response.End();
            }

            catch (Exception Ex)
            {
                ErrorLog.LogError("Certificate Generate", Ex);
            }
        }

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            Clear();
            txtSequence.Text = "A";
            mp1.Show();
        }

        protected void Clear()
        {
            txtGoodItem.Text = string.Empty;
            txtShippingMark.Text = string.Empty;
            drpPakgType.Text = string.Empty; //here
            txtSummary.Text = string.Empty;
            txtQuntity.Text = string.Empty;
            txtHScode.Text = string.Empty; ;
            txtSequence.Text = string.Empty;
        }

        protected void linkUploadSDOC_Click(object sender, EventArgs e)
        {
            if (isPDF() > 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>You must Upload a PDF document if needed to be Singed.</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            try
            {

                string Request_Ref_No = Request.QueryString["ReqstID"];
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {

                    Label lblRequestID = (Label)row.FindControl("lblRequestID");
                    Label DocID = (Label)row.FindControl("SupDOCID");
                    FileUpload FileUploader = (FileUpload)row.FindControl("btnFileUpload");
                    CheckBox chkRow = (CheckBox)row.FindControl("chkRow2");


                    string DirectoryPath = "~/Uploads/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/" + Request_Ref_No;
                    if (FileUploader.HasFile)
                    {
                        if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                        {
                            Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                        }
                        string file = Path.Combine(Server.MapPath(DirectoryPath + "/"), FileUploader.FileName.Replace(" ", "_"));
                        FileUploader.SaveAs(file);

                        SupportingDocUpload objsup = new SupportingDocUpload();

                        objsup.Request_Ref_No = Request_Ref_No;
                        objsup.Document_Id = DocID.Text.ToString();
                        if (chkRow.Checked)
                        {
                            objsup._Remarks = "NCE_Certification";
                            objsup.Signature_Required = true;
                        }
                        else { objsup._Remarks = ""; objsup.Signature_Required = false; }
                        objsup.Uploaded_By = userSession.User_Id;
                        objsup.Uploaded_Path = DirectoryPath + "/" + FileUploader.FileName.Replace(" ", "_");
                        objsup.Document_Name = FileUploader.FileName.Replace(" ", "_");

                        Crm.setSupportingDocumentFRequest(objsup);

                    }
                }
                LoadCertificateRequest();
            }
            catch (Exception Ex)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Unable To Upload The File....</div>";

                ErrorMessage.InnerHtml = qu;
                ErrorLog.LogError(Ex);
            }
        }

        protected void linkRemoveSD_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {
                    Label lblseqid = (Label)row.FindControl("lblseqid");
                    Label lblUploadP = (Label)row.FindControl("lblUploadP");
                    File.Delete(Server.MapPath(lblUploadP.Text));
                    Crm.setDELETESupportingDocUpload(Convert.ToInt64(lblseqid.Text));
                }
                LoadCertificateRequest();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }



    }
}