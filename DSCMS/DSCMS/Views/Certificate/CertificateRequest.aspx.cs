using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Usr;
using DCISDBManager.objLib.Master;
using DCISDBManager.trnLib.MasterDataManagement;
using DCISDBManager.trnLib.ParameterManagement;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.CheckAuth;
using System.IO;
using System.Transactions;

namespace DSCMS
{
    public partial class CertificateRequest : System.Web.UI.Page
    {
       List<CertificateRequestDetail> requestDetails = new List<CertificateRequestDetail>();
       CertificateRequestManager CerRqM = new CertificateRequestManager();
       CertificateRequestHeader HeaderR = new CertificateRequestHeader();
       CertificateRequestDetail CRD = new CertificateRequestDetail();

       UserSession usrSessiong;
       CheckAuthManager authorized;
      // static string TemplateID = string.Empty;
       string HSCODEHAS = System.Configuration.ConfigurationManager.AppSettings["HSCODEHAS"];
       string GOLOBALTMP = System.Configuration.ConfigurationManager.AppSettings["GOLOBALTMP"];
       string MASSACTIVE = System.Configuration.ConfigurationManager.AppSettings["MASSACTIVE"];
       string NINDROTMP = System.Configuration.ConfigurationManager.AppSettings["NINDROTMP"];
       string ROWWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["ROWWITHOUTHS"];
       string ROWWITH_HS = System.Configuration.ConfigurationManager.AppSettings["ROWWITH_HS"];
       string COLUMNWITHOUTHS = System.Configuration.ConfigurationManager.AppSettings["COLUMNWITHOUTHS"];
       string COLUMNWITHOUTHS2 = System.Configuration.ConfigurationManager.AppSettings["COLUMNWITHOUTHS2"];

        protected void Page_Load(object sender, EventArgs e)
        {
            usrSessiong = new UserSession();
            authorized = new CheckAuthManager();

            if (usrSessiong.Template_ID == "" || usrSessiong.Customer_Name == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Unable to detect Your Certificate Template...!";
                qu += "<div>";

                ErrorMessage.InnerHtml = qu;
                btnRequestCertificate.Visible = false;
            }


            if (!IsPostBack)
            {
                getData();
                getSupportingDocuments();
                getCustomerConsignees();
                //getPackageType();
                getCountries();
                HttpContext.Current.Session["CRequestItems"] = null;
                requestDetails.Clear();
                // getCustomerTemplate(); NINDROTMP HSCODE_N_BTMROW
                txtExporter.Text = usrSessiong.Customer_Name.Replace("<br />", "\r\n");

                if (usrSessiong.Template_ID.Equals(ROWWITHOUTHS))
                {
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                    DivNormal.Visible = false;
                    HSDetails.Visible = false;
                }
                else if (usrSessiong.Template_ID.Equals(ROWWITH_HS))
                {
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                    DivNormal.Visible = false;

                }
                else if (usrSessiong.Template_ID.Equals(COLUMNWITHOUTHS))
                {
                    txtHScode.Visible = false;
                    lblHScode.Visible = false;
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                    ROWBase.Visible = false;
                }
                else if (usrSessiong.Template_ID.Equals(COLUMNWITHOUTHS2))
                {
                    txtHScode.Visible = false;
                    lblHScode.Visible = false;
                    divOtherComments.Visible = false;
                    diveRemarkGlobl.Visible = false;
                    ROWBase.Visible = false;
                }
                else if (usrSessiong.Template_ID.Equals(NINDROTMP))
                {
                    divPOD.Visible = false;
                    divPODE.Visible = false;
                    txtPortDischrg.Visible = false;
                    txtPlcofDelivry.Visible = false;
                    diveRemarkGlobl.Visible = false;
                    ROWBase.Visible = false;
                }
                else if (usrSessiong.Template_ID.Equals(MASSACTIVE))
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
                else if (usrSessiong.Template_ID.Equals(HSCODEHAS))
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

            if (HttpContext.Current.Session["CRequestItems"] == null)
            {

                //   Instance.ProductList = new List<Product>();
                HttpContext.Current.Session["CRequestItems"] = requestDetails;
            }
            else
            {
                requestDetails = (List<CertificateRequestDetail>)HttpContext.Current.Session["CRequestItems"];
            }


            if (usrSessiong.User_Id == "" || usrSessiong.Customer_ID == "")
            {
                Response.Redirect("~/Views/Home/Logout.aspx");
            }
            bool resutl = authorized.IsUserGroupAuthorised(usrSessiong.User_Group, "CREQ");
            if (resutl == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }

            //if (requestDetails.Count == 0)
            //{
            //    btnRequestCertificate.Visible = false;
            //}

        }

        protected void getData()
        {
            GridView1.DataSource = requestDetails;
            GridView1.DataBind();
        }

        //protected void getPackageType()
        //{
        //    try
        //    {
        //        PackageTypeManager Pkm = new PackageTypeManager();
        //        drpPakgType.DataSource = Pkm.getPackageTypeList("%").Packageresultset;
        //        drpPakgType.DataTextField = "PackageDescription";
        //        drpPakgType.DataValueField = "PackageType";
        //        drpPakgType.DataBind();
        //        drpPakgType.SelectedIndex = -1;
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
                drpCountry.SelectedIndex = drpCountry.Items.IndexOf(drpCountry.Items.FindByValue("LK"));
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }


        protected void getCustomerConsignees()
        {
            try
            {
                drpConsignee.Items.Clear();
                DCISDBManager.objLib.Certificate.CertificateRequest cr = new DCISDBManager.objLib.Certificate.CertificateRequest();
                cr = CerRqM.getCustomerConsignees(usrSessiong.Customer_ID);
                drpConsignee.DataSource = cr.DCISgetCustomerConsignees_List;
                drpConsignee.DataTextField = "Consignee";
                drpConsignee.DataValueField = "RequestId";
                drpConsignee.DataBind();
                drpConsignee.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void getSupportingDocuments()
        {
            try
            {
                SupportingDocList newlist = new SupportingDocList();
                newlist = CerRqM.getSupportindDOCs(usrSessiong.User_Id, usrSessiong.Template_ID);
                gvSupportingDOc.DataSource = newlist.SupportingDOCset;
                gvSupportingDOc.DataBind();
                
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        //protected void getCustomerTemplate()
        //{
        //    TemplateManagement TemplateM = new TemplateManagement();
        //    TemplateID =  TemplateM.getCustomerTemplate(usrSessiong.User_Id);
        //}

        protected void linkEditItem_Click(object sender, EventArgs e)
        {
            //using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            //{
                
            //    for (int i = 0; i < requestDetails.Count; i++)
            //    {
            //        if (requestDetails[i].GoodItem1 == row.Cells[0].Text)
            //        {
            //            requestDetails.RemoveAt(i);
            //            getData();
            //        }
            //    }
            //    if (requestDetails.Count == 0)
            //    {
            //        btnRequestCertificate.Visible = false;
            //    }
            //}
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                Label lblSeqNo = (Label)row.FindControl("lblSeqNo");
                Label lblPackageType = (Label)row.FindControl("lblPackageType");
                Label lblSummary = (Label)row.FindControl("lblSummary");
                txtg.Text = row.Cells[0].Text;
                if (txtg.Text == "&nbsp;") { txtg.Text = ""; }
                txts.Text = row.Cells[1].Text;
                if (txts.Text == "&nbsp;") { txts.Text = ""; }
                //drpPakgType.SelectedIndex = drpPakgType.Items.IndexOf(drpPakgType.Items.FindByValue(lblPackageType.Text));//Here
                txtp.Text = lblPackageType.Text;
                if (txtp.Text == "&nbsp;") { txtp.Text = ""; }
                txtsd.Text = lblSummary.Text;// Replace("<br />", "\n");
                if (txtsd.Text == "&nbsp;") { txtsd.Text = ""; }
                txtq.Text = row.Cells[4].Text;
                if (txtq.Text == "&nbsp;") { txtq.Text = ""; }
                if (row.Cells[5].Text == "&nbsp;")
                {
                    txth.Text = "";
                }
                else
                {
                    txth.Text = row.Cells[5].Text;
                }
                
            }
            mpedit.Show();
            
        }

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            Clear(false);
            if (requestDetails.Count > 0)
            {
                return;
            }
            else
            {
                mp1.Show();
            }
            
        }

        private void Clear(bool isTrue)
        {
            txtGoodItem.Text = string.Empty;
            txtShippingMark.Text = string.Empty;
            txtSummary.Text = string.Empty;
            txtQuntity.Text = string.Empty;
            txtHScode.Text = string.Empty;
            drpPakgType.Text = string.Empty; // Here

            if (isTrue)
            {
                txtConsignee.Text = string.Empty;
                txtDate.Text = string.Empty;
                //txtExporter.Text = string.Empty;
                txtInvoNo.Text  = string.Empty;
                txtInvoVal.Text = string.Empty;
                txtPlcofDelivry.Text = string.Empty;
                txtPortDischrg.Text = string.Empty;
                txtPortLoading.Text = string.Empty;
                txtTotQunatity.Text = string.Empty;
                txtVessel.Text = string.Empty;
                txtOtherComments.Text = string.Empty;
                txtOtherDetails.Text = string.Empty;
                txtQuantityDetails.Text = string.Empty;
                txtHSDetails.Text = string.Empty;
                txtGoodDetails.Text = string.Empty;
                chckSealRequired.Checked = false;
                chkRefference.Checked = false;

            }

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            //if (txtGoodItem.Text == "")
            //{
            //    lblError.Text = "Please Fill out the Good Item Text Box Before Adding the Item.";
            //    mp1.Show();
            //    return;
            //}
            //if (txtShippingMark.Text == "")
            //{
            //    lblError.Text = "Please Fill out the Shipping Mark Text Box Before Adding the Item.";
            //    mp1.Show();
            //    return;
            //}
            //if (drpPakgType.Text == "")//Here
            //{
            //    lblError.Text = "Please Enter the Package Type Before Adding the Item.";
            //    mp1.Show();
            //    return;
            //}
            if (txtSummary.Text == "")
            {
                lblError.Text = "Please Fill out the Summary Text Box Before Adding the Item.";
                mp1.Show();
                return;
            }
            //if (txtQuntity.Text == "")
            //{
            //    lblError.Text = "Please Fill out the Quantity Text Box Before Adding the Item.";
            //    mp1.Show();
            //    return;
            //}

            if (requestDetails.Count == 1)
            {
                lblError.Text = "Only 1 Items Can Be Added To A Certificate Request";
                mp1.Show();
                return;
            }


            CertificateRequestDetail reqD = new CertificateRequestDetail();
            reqD.GoodItem1 = txtGoodItem.Text;
            reqD.PackageType1 = drpPakgType.Text;//Here
            reqD.PackageDescription1 = drpPakgType.Text;//Here
            reqD.Quantity1 = txtQuntity.Text;
            reqD.RequestId1 = string.Empty;
            reqD.ShippingMark1 = txtShippingMark.Text;
            reqD.SummaryDesc1 = txtSummary.Text;
            reqD.HSCode1 = txtHScode.Text;
            reqD.CreatedBy1 = usrSessiong.User_Id;
            reqD.SeqNo1 = 1;

            if (requestDetails.Count == 0)
            {
                requestDetails.Add(reqD);
                btnRequestCertificate.Visible = true;
                getData();
            }
            else
            {
                for (int i = 0; i < requestDetails.Count; i++)
                {
                    if (requestDetails[i].RequestId1 == reqD.RequestId1)//Reqid Changed
                    {
                        requestDetails[i].GoodItem1 = reqD.GoodItem1;
                        requestDetails[i].PackageType1 = reqD.PackageType1;
                        requestDetails[i].PackageDescription1 = reqD.PackageDescription1;
                        requestDetails[i].Quantity1 = reqD.Quantity1;
                        requestDetails[i].ShippingMark1 = reqD.ShippingMark1;
                        requestDetails[i].SummaryDesc1 = reqD.SummaryDesc1;
                        requestDetails[i].HSCode1 = reqD.HSCode1;
                        getData();
                        return;
                    }
                }
                requestDetails.Add(reqD);
                getData();
                
            }
             Clear(false);
             //mp1.Show();
        }

        private int checkGridView()
        {
            int count = 0;
            foreach (GridViewRow row in gvSupportingDOc.Rows)
            {
                Label DocID = (Label)row.FindControl("lbleid");
                Label isMandotory = (Label)row.FindControl("lblIsmandatory");
                FileUpload fu = (FileUpload)row.FindControl("btnFileUpload");


                if (fu.HasFile == false)
                {
                    if (isMandotory.Text.ToUpper() == "Y")
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private int isPDF()
        {
            int count = 0;
            foreach (GridViewRow row in gvSupportingDOc.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");
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

        private int CheckFileSize()
        {
            int count = 0;
            foreach (GridViewRow row in gvSupportingDOc.Rows)
            {
                FileUpload fu = (FileUpload)row.FindControl("btnFileUpload");
                HttpPostedFile File = fu.PostedFile;
                if (fu.HasFile)
                {
                    if (File.ContentLength > 1048576)
                    {
                        count++;
                    }
                }


            }
            return count;
        }

        protected void btnRequestCertificate_Click(object sender, EventArgs e)
        {
            ErrorMessage.InnerHtml = "";

            if (txtConsignee.Text == "" || txtExporter.Text == "" || txtDate.Text == "" || txtInvoNo.Text == "" || txtVessel.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill All the Required Fields Before Submitting.";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtPortLoading.Text == "")//txtInvoVal.Text == "" || txtTotQunatity.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill All the Required Fields Before Submitting.";
                qu += "</div>";

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

            //if (Convert.ToDecimal(txtInvoVal.Text) < 0)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong>Total Invoice Value Must Be less Than 0";
            //    qu += "</div>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}
            //if (TemplateID == "")
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong> Certificate Template Data Is Missing..</div>";
            //    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}

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
                qu += " <strong> Error ! </strong>Please Enter a  Date in Invoice Date Text Box Ex: 2016/01/01";
                qu += "</div>";
                 
                ErrorMessage.InnerHtml = qu;
                return;
            }

            //if (checkGridView() != 0)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error! </strong>Please Upload the Mandatory Supporting Documents Before Submitting.";
            //    qu += "</div>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}

            if (isPDF() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Please Upload '.pdf' Format Supporting Documents if Needed to Be Signed | or Rename the file if the File Name Has ().";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            //if (CheckFileSize() != 0)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error! </strong>File Upload File Size Exceeded.";
            //    qu += "</div>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}

            if (DivNormal.Visible == true)
            {
                if (requestDetails.Count == 0)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error! </strong>Please Add the Certificate Items Before Requesting.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
            }


            SaveCertificateInfo("P");// P = Certificate Genaration is Pending..Not visible to Signatory.only for Customer
            requestDetails.Clear();
            getData();
        }

        private bool SaveCertificateInfo(string Status)
        {
            HeaderR.Consignee1 = txtConsignee.Text.Replace("\r\n", "<br />");
            HeaderR.Consignor1 = txtExporter.Text.Replace("\r\n", "<br />");
            HeaderR.CountryCode1 = drpCountry.SelectedValue.ToString();
            HeaderR.CountryName1 = drpCountry.SelectedItem.ToString();
            HeaderR.CreatedBy1 = usrSessiong.User_Id;
            HeaderR.CreatedDate1 = DateTime.Now;
            HeaderR.CustomerId1 = usrSessiong.Customer_ID;//"CID"
            HeaderR.InvoiceDate1 = Convert.ToDateTime(txtDate.Text);
            HeaderR.InvoiceNo1 = txtInvoNo.Text;
            HeaderR.LoadingPort1 = txtPortLoading.Text;
            HeaderR.PlaceOfDelivery1 = txtPlcofDelivry.Text;
            HeaderR.PortOfDischarge1 = txtPortDischrg.Text;
            HeaderR.TemplateId1 = usrSessiong.Template_ID;
            HeaderR.TotalInvoiceValue1 = txtInvoVal.Text;
            HeaderR.TotalQuantity1 = txtTotQunatity.Text;
            HeaderR.Vessel1 = txtVessel.Text;
            HeaderR.Status1 = Status;
            HeaderR.OtherComments1 = txtOtherComments.Text;
            HeaderR.RequestDate1 = DateTime.Now;
            HeaderR.OtherDetails1 = txtOtherDetails.Text;
            HeaderR.Seal_Required = chckSealRequired.Checked.ToString();
            HeaderR.Addto_Refference = chkRefference.Checked;

            objResultSet result = null;
            if (usrSessiong.Template_ID.Equals(ROWWITH_HS) || usrSessiong.Template_ID.Equals(ROWWITHOUTHS))
            {
                
                CRD.Good_Details = txtGoodDetails.Text.Replace("\r\n", "<br />");
                CRD.HSCode_Details = txtHSDetails.Text.Replace("\r\n", "<br />");
                CRD.Quantity_Details = txtQuantityDetails.Text.Replace("\r\n", "<br />");
                CRD.CreatedBy1 = usrSessiong.User_Id;

                result = CerRqM.setCertificateRequest(HeaderR, CRD);
            }
            else
            {
                result = CerRqM.setCertificateRequest(HeaderR, requestDetails);
            }


            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    //using (TransactionScope transactionScope = new TransactionScope())
                    //{

                    
                    HeaderR.RequestId1 = result.String_Value;
                    foreach (GridViewRow row in gvSupportingDOc.Rows)
                    {
                        Label DocID = (Label)row.FindControl("lbleid");
                        FileUpload FileUploader = (FileUpload)row.FindControl("btnFileUpload");
                        CheckBox chkRow = (CheckBox)row.FindControl("chkRow");


                        string DirectoryPath = "~/Uploads/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("yyyy_MM_dd") + "/" + result.String_Value;
                        if (result.Boolen_Value)
                        {
                            if (FileUploader.HasFile)
                            {
                                if (!Directory.Exists(Server.MapPath(DirectoryPath)))
                                {
                                    Directory.CreateDirectory(Server.MapPath(DirectoryPath));
                                }
                                string file = Path.Combine(Server.MapPath(DirectoryPath + "/"), FileUploader.FileName.Replace(" ", "_"));
                                FileUploader.SaveAs(file);

                                SupportingDocUpload objsup = new SupportingDocUpload();

                                objsup.Request_Ref_No = result.String_Value;
                                objsup.Document_Id = DocID.Text.ToString();
                                if (chkRow.Checked)
                                {
                                    objsup._Remarks = "NCE_Certification";
                                    objsup.Signature_Required = true;
                                }
                                else { objsup._Remarks = ""; objsup.Signature_Required = false; }
                                objsup.Uploaded_By = usrSessiong.User_Id;
                                objsup.Uploaded_Path = DirectoryPath + "/" + FileUploader.FileName.Replace(" ", "_");
                                objsup.Document_Name = FileUploader.FileName.Replace(" ", "_");

                                CerRqM.setSupportingDocumentFRequest(objsup);


                            }
                        }

                    }
                    transactionScope.Complete();
                    transactionScope.Dispose();
                    // }
                    btnRequestCertificate.Enabled = true;
                    Clear(true);
                    HttpContext.Current.Session["CRequestItems"] = null;
                    //requestDetails.Clear();
                    getSupportingDocuments();
                    getData();
                    getCustomerConsignees();


                    string qu = null;
                    if (Status.Equals("P"))
                    {
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Certificate Request Successfully Saved : " + result.String_Value + ".";
                        qu += "</div>";
                    }
                    else
                    {
                        qu += "<div class=\"alert alert-dismissable alert-success\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Certificate Request Successfull. Certificate Request ID : " + result.String_Value + ".";
                        qu += "</div>";
                    }



                    ErrorMessage.InnerHtml = qu;
                    return true;

                }
                catch (TransactionException ex)
                {
                    transactionScope.Dispose();
                    ErrorLog.LogError(ex);
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! (Transaction) </strong> Unable to Performe the Request Please Try Again Later.";//+ result.String_Value;
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return false;
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);

                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error ! </strong> Unable to Performe the Request Please Try Again Later. : ";//+ result.String_Value;
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return false;
                }
            }
        }

        protected void btnSendForApproval_Click(object sender, EventArgs e)
        {
            ErrorMessage.InnerHtml = "";
            if (txtConsignee.Text == "" || txtExporter.Text == "" || txtDate.Text == "" || txtInvoNo.Text == "" || txtVessel.Text == "")
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill All the Required Fields Before Submitting.";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            if (txtPortLoading.Text == "")//|| txtInvoVal.Text == "" || txtTotQunatity.Text == ""
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error ! </strong>Please Fill All the Required Fields Before Submitting.";
                qu += "</div>";

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




            //if (Convert.ToDecimal(txtInvoVal.Text) < 0)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong>Total Invoice Value Must Be less Than 0";
            //    qu += "</div>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}
            //if (TemplateID == "")
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error ! </strong> Certificate Template Data Is Missing..</div>";
            //    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}

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
                qu += " <strong> Error ! </strong>Please Enter a  Date in Invoice Date Text Box Ex: 2016/01/01";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }

            if (checkGridView() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Please Upload the Mandatory Supporting Documents Before Submitting.";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }

            if (isPDF() != 0)
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " <strong> Error! </strong>Please Upload '.pdf' Format Supporting Documents if Needed to Be Signed. | or Rename the file if the File Name Has ()";
                qu += "</div>";

                ErrorMessage.InnerHtml = qu;
                return;
            }
            //if (CheckFileSize() != 0)
            //{
            //    string qu = null;
            //    qu += "<div class=\"alert alert-dismissable alert-warning\">";
            //    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            //    qu += " <strong> Error! </strong>File Upload File Size Exceeded.";
            //    qu += "</div>";

            //    ErrorMessage.InnerHtml = qu;
            //    return;
            //}

            if (DivNormal.Visible == true)
            {
                if (requestDetails.Count == 0)
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Error! </strong>Please Add the Certificate Items Before Requesting.";
                    qu += "</div>";

                    ErrorMessage.InnerHtml = qu;
                    return;
                }
            }

            bool result = SaveCertificateInfo("G");

            try
            {
                if (result)
                {
                    bool Created = false;
                    string Template = usrSessiong.Template_ID.ToString();

                    string LogoPath = Server.MapPath("~/img/NCELOGO.PNG"); // NCE Certificate logo Image path
                    string DirectoryPath = "~/Documents/" + DateTime.Now.ToString("yyyy")
                                            + "/Web_Based_Certificates/" + DateTime.Now.ToString("yyyy_MM_dd")+"/" + HeaderR.RequestId1;

                    HeaderR.Customer_Telephone = usrSessiong.Telephone_;
                    HeaderR.CustomerName1 = usrSessiong.Customer_Name;
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
                                new PDFCreator.RowWithHSTemplate(HeaderR,
                                CRD, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "","");

                       Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(ROWWITHOUTHS))
                    {
                        PDFCreator.RowWithoutHSTemplate Certificate =
                                new PDFCreator.RowWithoutHSTemplate(HeaderR,
                                CRD, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "","");

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(GOLOBALTMP))
                    {
                        PDFCreator.OrientGlobalCertificateTemplate Certificate =
                                new PDFCreator.OrientGlobalCertificateTemplate(HeaderR,
                                requestDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "","");

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(MASSACTIVE))
                    {
                        PDFCreator.MassActiveCertificateTemplate Certificate =
                                new PDFCreator.MassActiveCertificateTemplate(HeaderR,
                                requestDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "","");

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(NINDROTMP))
                    {
                        PDFCreator.NidroCertificateTemplate Certificate =
                                new PDFCreator.NidroCertificateTemplate(HeaderR,
                                requestDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "","");

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(COLUMNWITHOUTHS))
                    {
                        PDFCreator.ColumnWithoutHSTemplate Certificate =
                                new PDFCreator.ColumnWithoutHSTemplate(HeaderR,
                                requestDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "","");

                        Created = Certificate.CreateCertificate("");
                    }
                    else if (Template.Equals(COLUMNWITHOUTHS2))
                    {
                        PDFCreator.ColumnWithoutHSTemplate Certificate =
                                new PDFCreator.ColumnWithoutHSTemplate(HeaderR,
                                requestDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"), "", "");

                        Created = Certificate.CreateCertificate("");
                    }
                    else
                    {
                        PDFCreator.ColumnWithHSTemplate Certificate =
                                new PDFCreator.ColumnWithHSTemplate(HeaderR,
                                requestDetails, LogoPath,
                                Server.MapPath(DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf"),"","");

                        Created = Certificate.CreateCertificate("");
                    }
                    if (Created)
                    {
                        CerRqM.setWebBasedCertificateCreation(HeaderR.RequestId1,
                            DirectoryPath + "/" + HeaderR.RequestId1 + "_Sample_Cert.pdf",
                            HeaderR.RequestId1 + "_Sample_Cert.pdf");

                        requestDetails.Clear();
                        HttpContext.Current.Session["CRequestItems"] = null;
                        Clear(true);
                    }
                }
                getData();
                //getCustomerConsignees();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError("Certificate Generate",Ex);
            }

        }

        protected void drpConsignee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpConsignee.SelectedIndex != -1)
                {
                    LoadCertificateRequest(drpConsignee.SelectedValue);
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }
        protected void LoadCertificateRequest(string id)
        {
            try
            {
                HeaderR = CerRqM.getRequestByID(id);

                txtConsignee.Text = HeaderR.Consignee1.Replace("<br />", "\r\n");
                txtDate.Text = HeaderR.InvoiceDate1.ToString("yyyy/MM/dd");
                txtExporter.Text = HeaderR.Consignor1.Replace("<br />", "\r\n");
                txtInvoNo.Text = HeaderR.InvoiceNo1;
                txtInvoVal.Text = HeaderR.TotalInvoiceValue1.ToString();
                txtPlcofDelivry.Text = HeaderR.PlaceOfDelivery1;
                txtPortDischrg.Text = HeaderR.PortOfDischarge1;
                txtPortLoading.Text = HeaderR.LoadingPort1;
                txtTotQunatity.Text = HeaderR.TotalQuantity1;
                txtVessel.Text = HeaderR.Vessel1;
                drpCountry.SelectedIndex = drpCountry.Items.IndexOf(drpCountry.Items.FindByValue(HeaderR.CountryCode1));
                txtOtherComments.Text = HeaderR.OtherComments1;
                txtOtherDetails.Text = HeaderR.OtherDetails1;
                chckSealRequired.Checked = Convert.ToBoolean(HeaderR.Seal_Required);

                if (usrSessiong.Template_ID.Equals(ROWWITH_HS) || usrSessiong.Template_ID.Equals(ROWWITHOUTHS))
                {

                    CRD = CerRqM.getROWbasedCertificateRequestDetails(id);
                   // txtSeqNo.Text = Convert.ToString(CRD.SeqNo1);
                    txtGoodDetails.Text = CRD.Good_Details.Replace("<br />", "\r\n");
                    txtHSDetails.Text = CRD.HSCode_Details.Replace("<br />", "\r\n");
                    txtQuantityDetails.Text = CRD.Quantity_Details.Replace("<br />", "\r\n");

                }
                else
                {
                    getItemDetails(id, CerRqM);
                }
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
                requestDetails = Crm.getReqDetailByReqID(id, false);
                GridView1.DataSource = requestDetails;
                GridView1.DataBind();

                HttpContext.Current.Session["CRequestItems"] = requestDetails;
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                requestDetails[0].SeqNo1 = 1;
                requestDetails[0].GoodItem1 = txtg.Text;
                requestDetails[0].ShippingMark1 = txts.Text;
                requestDetails[0].PackageType1 = txtp.Text;
                requestDetails[0].Quantity1 = txtq.Text;
                requestDetails[0].SummaryDesc1 = txtsd.Text;
                requestDetails[0].HSCode1 = txth.Text;
                HttpContext.Current.Session["CRequestItems"] = requestDetails;
                getData();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void linkRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                requestDetails = null;
                HttpContext.Current.Session["CRequestItems"] = requestDetails;
                getData();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btngeConsignee_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpConsignee.SelectedIndex != -1)
                {
                    LoadCertificateRequest(drpConsignee.SelectedValue);
                }
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }

        protected void btnRemoveConsignee_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpConsignee.SelectedIndex != -1)
                {
                    CerRqM.DeleteCustomerRefferenc(drpConsignee.SelectedValue);
                }
                getCustomerConsignees();
            }
            catch (Exception Ex)
            {
                ErrorLog.LogError(Ex);
            }
        }
    }
}