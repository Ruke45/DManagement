using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DCISDBManager.objLib.Usr;
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.objLib.Master;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.objLib.Certificate;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.MasterDataManagement;

namespace DSCMS.Views.Certificate
{
    public partial class EditManualEntry : System.Web.UI.Page
    {
        static List<CertificateRequestDetail> requestDetails = new List<CertificateRequestDetail>();
        UserSession session;
        PackageTypeManagement pt = new PackageTypeManagement();
        ManualCertificateManagement CerRqM = new ManualCertificateManagement();
        ManualCertificateManagement mcm = new ManualCertificateManagement();
        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
        protected void Page_Load(object sender, EventArgs e)
        {
            session = new UserSession();
            BindPackage();
            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "ptype");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }


            Response.AddHeader("X-Download-Options", "noopen");
            BindGrid();

        }

        public void BindPackage()
        {
            PackageTypeManager Pkm = new PackageTypeManager();
            drpPakgType.DataSource = Pkm.getPackageTypeList("%").Packageresultset;
            drpPakgType.DataTextField = "PackageDescription";
            drpPakgType.DataValueField = "PackageType";
            drpPakgType.DataBind();
        }

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
        public void BindGrid()
        {
            try
            {
                // GridView1.DataSource = pt.getPackageType("%");
                GridView1.DataSource = mcm.getUpoladListE("%", "A");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            requestDetails.Clear();
            Response.AddHeader("X-Download-Options", "noopen");
            ManualCertificateManagement mcM = new ManualCertificateManagement();
            Label lblTemp = null;
            btnShow.Visible = true;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                ReqID.Text = row.Cells[0].Text;

                txtCustID.Text = row.Cells[1].Text;
                lblTemp = (Label)row.FindControl("lblCertificatePath");
                // string a = row.Cells[2].Text;
                // myIframe.Attributes["src"] = "~/Uploads/TestPage(1).pdf";
                myIframe.Attributes["src"] = lblTemp.Text;
                getCountries();

                // txtPackageID.Text = row.Cells[0].Text;
                //  txtPackageDescription.Text = row.Cells[1].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }

            CertificateRequestHeader crg = CerRqM.getRequestHeader(ReqID.Text);
            ReqID.Text = crg.CertificateId1;
            txtConsignee.Text = crg.Consignee1;
            txtExporter.Text = crg.Consignor1;
         
            drpCountry.SelectedValue = crg.CountryCode1;

            // crh.CreatedBy1 = session.User_Id;
            txtCustID.Text = crg.CustomerId1;
            txtInvoDate.Text = crg.InvoiceDate1.ToString("MM'/'dd'/'yyyy");
            txtInvoNo.Text = crg.InvoiceNo1;
            txtPortLoading.Text = crg.LoadingPort1;
            txtPlcofDelivry.Text = crg.PlaceOfDelivery1;
            txtPortDischrg.Text = crg.PortOfDischarge1;
            //  crh.RequestDate1 = Convert.ToDateTime("1991-10-09");
            ReqID.Text = crg.RequestId1;
            //  crh.Status1 = "y";
            txtCustID.Text = crg.CustomerId1;

            txtInvoVal.Text = crg.TotalInvoiceValue1.ToString();
            txtTotQunatity.Text = crg.TotalQuantity1;
            txtVessel.Text = crg.Vessel1;


            //GridView2.DataSource = mcm.getRequestDetails(ReqID.Text);
            //    GridView2.DataBind();
            CertificateRequestDetail cde=new CertificateRequestDetail();
            var a = mcm.getRequestDetails(ReqID.Text);
           

        

            
            List<CertificateRequestDetail> lstmct = new List<CertificateRequestDetail>();
            lstmct = mcm.getRequestDetails(ReqID.Text);

            foreach (var result in lstmct) {

                CertificateRequestDetail reqD = new CertificateRequestDetail();
                reqD.PackageType1 = result.PackageType1;
                reqD.HSCode1 = result.HSCode1;




                reqD.GoodItem1 = result.GoodItem1;

                reqD.Quantity1 = result.Quantity1;

                reqD.RequestId1 = ReqID.Text;
                reqD.ShippingMark1 = result.ShippingMark1;
                reqD.SummaryDesc1 = result.SummaryDesc1;

                reqD.CreatedBy1 = result.CreatedBy1;

                requestDetails.Add(reqD);
            
            
            }
            getData();

            


          




        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnShow.Visible = false;
            Response.Redirect("CertifcateDownload.aspx", false);


        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                //  txtPackageID.Text = row.Cells[0].Text;
                //txtPackageID.Text = row.Cells[0].Text;
                //  DCISDBManager.objLib.MasterMaintenance.Packagetype inactive = new Packagetype();
                //  inactive.Modified_By = session.User_Id;
                // inactive.Package_Type = row.Cells[0].Text;
                //inactive.Is_Active = "n";
                // pt.ModifyPackageTypeStatus(inactive);


                //  Response.Redirect("PackageType.aspx",false);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DCISDBManager.objLib.MasterMaintenance.Packagetype inactive = new Packagetype();
            inactive.Modified_By = session.User_Id;
            //  inactive.Package_Type = txtPackageID.Text;
            inactive.Is_Active = "n";
            pt.ModifyPackageTypeStatus(inactive);
            Response.Redirect("PackageType.aspx", false);




        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                //if (txtGoodItem.Text == "")
                //{
                //    lblError.Text = "Please Fill out the Good Item to continue.";
                //    mp1.Show();
                //    return;
                //}
                //if (txtHSCode.Text == "")
                //{
                //    lblError.Text = "Please Fill out the HS Code to continue.";
                //    mp1.Show();
                //    return;
                //}
                //if (txtPackageType.Text == "")
                //{
                //    lblError.Text = "Please Fill out the Package Type to continue.";
                //    mp1.Show();
                //    return;
                //}
                //if (txtQuantity.Text == "")
                //{
                //    lblError.Text = "Please Fill out the Quantity to continue.";
                //    mp1.Show();
                //    return;
                //}
                //if (txtShippingMark.Text == "")
                //{
                //    lblError.Text = "Please Fill out the Shipping Mark to continue.";
                //    mp1.Show();
                //    return;
                //}
                //if (txtSummaryDesc.Text == "")
                //{
                //    lblError.Text = "Please Fill out the Summary Description to continue.";
                //    mp1.Show();
                //    return;
                //}
                if (txtConsignee.Text == "")
                {
                    lblError.Text = "Please Fill out the Consignee to continue.";
                    mp1.Show();
                    return;
                }
                if (txtExporter.Text == "")
                {
                    lblError.Text = "Please Fill out the Exporter to continue.";
                    mp1.Show();
                    return;
                }
                if (drpCountry.SelectedIndex==-1)
                {
                    lblError.Text = "Please Select the Country Of Origin to continue.";
                    mp1.Show();
                    return;
                }

                if (txtCustID.Text == "")
                {
                    lblError.Text = "Please Fill out the Customer ID to continue.";
                    mp1.Show();
                    return;
                }
                if (txtInvoDate.Text == "")
                {
                    lblError.Text = "Please Fill out the Invoice Date to continue.";
                    mp1.Show();
                    return;
                }
                if (txtInvoNo.Text == "")
                {
                    lblError.Text = "Please Fill out the Invoice Number to continue.";
                    mp1.Show();
                    return;
                }
                if (txtPortLoading.Text == "")
                {
                    lblError.Text = "Please Fill out the Port Loading to continue.";
                    mp1.Show();
                    return;
                }

                if (txtPlcofDelivry.Text == "")
                {
                    lblError.Text = "Please Fill out the Port of Delivery to continue.";
                    mp1.Show();
                    return;
                }

                if (txtPortDischrg.Text == "")
                {
                    lblError.Text = "Please Fill out the Port of Discharge to continue.";
                    mp1.Show();
                    return;
                }

                if (txtInvoVal.Text == "")
                {
                    lblError.Text = "Please Fill out the Invoice Value to continue.";
                    mp1.Show();
                    return;
                }

                if (txtTotQunatity.Text == "")
                {
                    lblError.Text = "Please Fill out the Total Quantity to continue.";
                    mp1.Show();
                    return;
                }
                if (txtVessel.Text == "")
                {
                    lblError.Text = "Please Fill out the Vessel to continue.";
                    mp1.Show();
                    return;
                }
                ManualCertificate mc3 = new ManualCertificate();
                mc3.Request_Id = ReqID.Text;
                mc3.Remarks_ = "A";

                mcm.ModifyUploadbaseRemarks(mc3);


                CertificateRequestDetail crd = new CertificateRequestDetail();

                crd.CreatedBy1 = session.User_Id;
                // crd.GoodItem1 = txtGoodItem.Text;
                //  crd.HSCode1 = txtHSCode.Text;
                crd.PackageDescription1 = "";
                //   crd.PackageType1 = txtPackageType.Text;
                //  crd.Quantity1 = txtQuantity.Text;
                //    crd.RequestId1 = ReqID.Text;
                //crd.SeqNo1 = 4;
                //    crd.ShippingMark1 = txtShippingMark.Text;
                //     crd.SummaryDesc1 = txtSummaryDesc.Text;



                //  mcm.SetManualEntry(crd);


               
                

                CertificateRequestHeader crh = new CertificateRequestHeader();




                crh.Consignee1 = txtConsignee.Text;
                crh.Consignor1 = txtExporter.Text;
                crh.CountryCode1 = drpCountry.SelectedValue;

                crh.CreatedBy1 = session.User_Id;
                crh.CustomerId1 = txtCustID.Text;
                crh.InvoiceDate1 = Convert.ToDateTime(txtInvoDate.Text);
                crh.InvoiceNo1 = txtInvoNo.Text;
                crh.LoadingPort1 = txtPortLoading.Text;
                crh.PlaceOfDelivery1 = txtPlcofDelivry.Text;
                crh.PortOfDischarge1 = txtPortDischrg.Text;
                //  crh.RequestDate1 = Convert.ToDateTime("1991-10-09");
                crh.RequestId1 = ReqID.Text;
                crh.Status1 = "y";
                mcm.getTemplateID(txtCustID.Text);
                crh.TemplateId1 = mcm.getTemplateID(txtCustID.Text);
                crh.TotalInvoiceValue1 = txtInvoVal.Text;
                crh.TotalQuantity1 = txtTotQunatity.Text;
                crh.Vessel1 = txtVessel.Text;

                //--new entry


                CertificateRequestHeader HeaderR = new CertificateRequestHeader();
                HeaderR.RequestId1 = ReqID.Text;
                HeaderR.Consignee1 = txtConsignee.Text;
                HeaderR.Consignor1 = txtExporter.Text;
                HeaderR.CountryCode1 = drpCountry.SelectedValue;
                HeaderR.CreatedBy1 = session.User_Id;
                HeaderR.CreatedDate1 = DateTime.Now;
                HeaderR.CustomerId1 = txtCustID.Text;//"CID"
                HeaderR.InvoiceDate1 = Convert.ToDateTime(txtInvoDate.Text);
                HeaderR.InvoiceNo1 = txtInvoNo.Text;
                HeaderR.LoadingPort1 = txtPortLoading.Text;
                HeaderR.PlaceOfDelivery1 = txtPlcofDelivry.Text;
                HeaderR.PortOfDischarge1 = txtPortDischrg.Text;
                HeaderR.TemplateId1 = mcm.getTemplateID(txtCustID.Text);
                HeaderR.TotalInvoiceValue1 = txtInvoVal.Text;
                HeaderR.TotalQuantity1 = txtTotQunatity.Text;
                HeaderR.Vessel1 = txtVessel.Text;
                HeaderR.Status1 = "A";





                //------------


                if (true)

                // if (mcm.SetManualEntry(crd) == true)
                {
                    //   mcm.SetManualHeaderEntry(crh);
                    ManualCertificate mc2 = new ManualCertificate();
                    mc2.Request_Id = ReqID.Text;
                    mc2.Remarks_ = "C";


                    if (mcm.ModifyUploadbaseRemarks(mc2).Equals(false))
                    {
                        mcm.ModifyEmailbaseRemarks(mc2);
                    }
                }

                CertificateRequestDetail reqD = new CertificateRequestDetail();
                reqD.RequestId1 = ReqID.Text;
                reqD.GoodItem1 = TextBox1.Text;
                reqD.PackageType1 = drpPakgType.SelectedValue.ToString();
                reqD.Quantity1 = txtQuntity.Text;
                reqD.RequestId1 = string.Empty;
                reqD.ShippingMark1 = TextBox2.Text;
                reqD.SummaryDesc1 = txtSummary.Text;
                // reqD.HSCode1 = txtHScode.Text;
                reqD.CreatedBy1 = session.User_Id;
               // objResultSet result = CerRqM.setCertificateRequest(HeaderR, requestDetails);
                objResultSet resultS = CerRqM.modifyCertificateRequest(HeaderR, requestDetails);

                if (requestDetails.Count == 0)
                {
                    requestDetails.Add(reqD);
                    // btnRequestCertificate.Visible = true;
                    getData();
                }
                else
                {
                    for (int i = 0; i < requestDetails.Count; i++)
                    {
                        //if (requestDetails[i].GoodItem1 == reqD.GoodItem1)
                        //{
                        requestDetails[i].RequestId1 = ReqID.Text;
                        requestDetails[i].GoodItem1 = reqD.GoodItem1;
                        requestDetails[i].PackageType1 = reqD.PackageType1;
                        requestDetails[i].Quantity1 = reqD.Quantity1;
                        requestDetails[i].ShippingMark1 = reqD.ShippingMark1;
                        requestDetails[i].SummaryDesc1 = reqD.SummaryDesc1;
                        requestDetails[i].HSCode1 = reqD.HSCode1;
                        requestDetails[i].CreatedBy1 = reqD.CreatedBy1;
                        getData();
                        return;
                        //}
                    }
                    requestDetails.Add(reqD);
                    getData();

                }

                //  Clear(false);
                mp1.Show();

                TextBox1.Text = null;
                drpPakgType.SelectedIndex = -1;
                txtQuntity.Text = null;
                TextBox2.Text = null;
                txtSummary.Text = null;
                txtQuntity.Text = null;
                txtConsignee.Text = null;
                txtExporter.Text = null;
                drpCountry.SelectedIndex =-1;




                txtInvoNo.Text = null;
                txtPortLoading.Text = null;
                txtPlcofDelivry.Text = null;
                txtPortDischrg.Text = null;

                txtInvoVal.Text = null;
                txtTotQunatity.Text = null;
                txtVessel.Text = null;

                Response.Redirect("EditManualEntry.aspx", false);


            }
            catch (Exception es)
            {
                System.Console.Error.Write(es.Message);


            }

        }


        protected override void OnInit(EventArgs e)
        {
            GridView2.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
            base.OnInit(e);
        }
        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblTemp = null ;
            //using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            //{
            //    lblTemp = (Label)row.FindControl("lblRunningNo");
            //    if (lblTemp.Text == "")
            //    {
            //        LinkButton btnEdit = (LinkButton)e.Row.FindControl("linkEditItem");
            //        btnEdit.Visible = false;
            //    }
            //}

            //if (e.Row.RowType != DataControlRowType.DataRow) return;


            //if (e.Row.FindControl("lblRunningNo").ToString() == "") {
            //    LinkButton btnEdit = (LinkButton)e.Row.FindControl("linkEditItem");
            //    btnEdit.Visible = false;
            
            //}
            //if (e.Row.Cells[6].Text == "")
            //{
            //    e.Row.Visible = false;
            //    LinkButton btnEdit = (LinkButton)e.Row.FindControl("linkEditItem");
            //    btnEdit.Visible = false;
            //}
        }
        protected void getData()
        {
            GridView2.DataSource = requestDetails;
            GridView2.DataBind();

        }
        protected void linkEditItem_Click(object sender, EventArgs e)
        {
            Label lblTemp = null;


            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                lblTemp = (Label)row.FindControl("lblRunningNo");
                if (lblTemp.Text != "") {
                    CertificateRequestDetail reqD = new CertificateRequestDetail();

                    reqD.CreatedBy1 = lblTemp.Text;
                    mcm.DeleteCertificateDetails(reqD);
                
                
                }


                for (int i = 0; i < requestDetails.Count; i++)
                {
                    if (requestDetails[i].GoodItem1 == row.Cells[0].Text)
                    {
                        requestDetails.RemoveAt(i);
                        getData();
                    }
                }
                if (requestDetails.Count == 0)
                {
                    // btnRequestCertificate.Visible = false;
                }

                mp1.Show();
            }

        }
   
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {

            mp2.Show();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   this.mp1.Show();

        }

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            
            TextBox1.Text = null;

            TextBox2.Text = null;
            TextBox3.Text = null;
            drpPakgType.SelectedIndex = -1;
            txtSummary.Text = null;
            txtQuntity.Text = null;

            // Clear(false);
            mp2.Show();
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                lblError.Text = "Please Fill out the Good Item Text Box Before Adding the Item.";
                mp1.Show();
                return;
            }
            if (TextBox2.Text == "")
            {
                lblError.Text = "Please Fill out the Shipping Mark Text Box Before Adding the Item.";
                mp1.Show();
                return;
            }
            if (drpPakgType.SelectedIndex == 0)
            {
                lblError.Text = "Please Select the Package Type Before Adding the Item.";
                mp1.Show();
                return;
            }
            if (txtSummary.Text == "")
            {
                lblError.Text = "Please Fill out the Summary Text Box Before Adding the Item.";
                mp1.Show();
                return;
            }
            if (txtQuntity.Text == "")
            {
                lblError.Text = "Please Fill out the Quantity Text Box Before Adding the Item.";
                mp1.Show();
                return;
            }

            if (requestDetails.Count == 12)
            {
                lblError.Text = "Only 12 Items Can Be Added To A Certificate Request";
                mp1.Show();
                return;
            }


            CertificateRequestDetail reqD = new CertificateRequestDetail();
            reqD.GoodItem1 = TextBox1.Text;
            reqD.PackageType1 = drpPakgType.SelectedValue.ToString();
            reqD.Quantity1 = txtQuntity.Text;
            reqD.RequestId1 = string.Empty;
            reqD.ShippingMark1 = TextBox2.Text;
            reqD.SummaryDesc1 = txtSummary.Text;
            reqD.HSCode1 = TextBox3.Text;
            reqD.CreatedBy1 = "";

            if (requestDetails.Count == 0)
            {
                requestDetails.Add(reqD);
                // btnRequestCertificate.Visible = true;
                getData();
            }
            else
            {
                for (int i = 0; i < requestDetails.Count; i++)
                {
                    if (requestDetails[i].GoodItem1 == reqD.GoodItem1)
                    {
                        requestDetails[i].GoodItem1 = reqD.GoodItem1;
                        requestDetails[i].PackageType1 = reqD.PackageType1;
                        requestDetails[i].Quantity1 = reqD.Quantity1;
                        requestDetails[i].ShippingMark1 = reqD.ShippingMark1;
                        requestDetails[i].SummaryDesc1 = reqD.SummaryDesc1;
                        requestDetails[i].HSCode1 = reqD.HSCode1;
                        requestDetails[i].CreatedBy1 = reqD.CreatedBy1;
                        getData();
                        // return;
                    }
                }
                requestDetails.Add(reqD);
                getData();

            }

            TextBox1.Text = null;

            TextBox2.Text = null;
            drpPakgType.SelectedIndex = -1;
            txtSummary.Text = null;
            txtQuntity.Text = null;
            // Clear(false);
            mp1.Show();
        }
    }
}