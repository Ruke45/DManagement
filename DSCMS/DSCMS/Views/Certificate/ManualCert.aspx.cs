using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Drawing;
using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.Utility;

using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using System.Windows;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.objLib.Certificate;
using System.Threading;
using DCISDBManager.trnLib.CustomerRequestManagement;


namespace DSCMS.Views.Certificate
{
    public partial class ManualCert : System.Web.UI.Page
    {
        CustomerDetailManager cdm = new CustomerDetailManager();
        TaxDataMaintenance tdm = new TaxDataMaintenance();
        manualCertifiManagement mcm = new manualCertifiManagement();
        UserSession session;

        string grpidAdmin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];

        //  SupportingDocumentManagement sdm = new SupportingDocumentManagement();
        protected void Page_Load(object sender, EventArgs e)
        {

            session = new UserSession();

            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "tx");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }


            if (!Page.IsPostBack)
            {

                BindGrid();
                BindDropDown();

            }
        }

        public void BindGrid()
        {
            try
            {
                GridView1.DataSource = mcm.getManualData("Y","%","%");

                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }

        public void CertificateID_Click(object sender, EventArgs e)
        {
            string refno;
            string cusID;

            if (txtCertificateNo.Text != "")
            {

                refno = txtCertificateNo.Text;

            }
            else {

                refno = "%";
            
            }

            if (ddUserID.SelectedValue != "")
            {

                cusID = ddUserID.SelectedValue;

            }
            else
            {

                cusID = "%";

            }

            GridView1.DataSource = mcm.getManualData("Y", cusID, refno);

            GridView1.DataBind();




        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }


        public void BindDropDown()
        {
            try



            {
                ddCustomer.DataSource = cdm.getAllCustomer("y");
                ddCustomer.DataTextField = "CustomerName1";
                ddCustomer.DataValueField = "CustomerId1";

                ddCustomer.DataBind();

                ddAcustomer.DataSource = cdm.getAllCustomer("y");
                ddAcustomer.DataTextField = "CustomerName1";
                ddAcustomer.DataValueField = "CustomerId1";

                ddAcustomer.DataBind();



                ddUserID.DataSource = cdm.getAllCustomer("y");
                ddUserID.DataTextField = "CustomerName1";
                ddUserID.DataValueField = "CustomerId1";

                ddUserID.DataBind();


                

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }




        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Label custID = null;

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                TxteID.Text = row.Cells[1].Text;
                txtRefferenceNo.Text = row.Cells[1].Text;
                txtIssuedDate.Text= row.Cells[2].Text;
                txtInvoiceNo.Text = row.Cells[3].Text;

                //ddCustomer.SelectedItem.Text = row.Cells[0].Text;
              

                custID = (Label)row.FindControl("lblCusID");
                ddCustomer.SelectedValue = custID.Text;

                string item = row.Cells[4].Text;

                if (item == "CO") {

                    ddeItemDescription.SelectedValue = "C";
                
                }
                if (item == "Invoice")
                {
                    ddeItemDescription.SelectedValue = "I";


                }
                if (item == "Document")
                {

                    ddeItemDescription.SelectedValue = "O";

                }



               // txtTaxName.Text = row.Cells[1].Text;
               // txtTaxCode.Text = row.Cells[0].Text;
               // txtTaxPercentages.Text = row.Cells[2].Text;
               // ddeTaxPriority.SelectedValue = row.Cells[3].Text;
                // txtPersonName.Text = row.Cells[2].Text;
                mp1.Show();
            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            btnTdelete.Visible = true;
            mp3.Show();
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                txtRefferenceNo.Text = row.Cells[1].Text;

                //txtTaxCode.Text = row.Cells[0].Text;

            }



        }

        protected void btnDelete_Click(object sender, EventArgs e){


       objmanualcertifi om = new objmanualcertifi();
          

            
            om.Refference_No = txtRefferenceNo.Text;

            string inv=mcm.getInvoicedTrue(txtRefferenceNo.Text);

            if (inv != "") {

                Label2.Text = "Reffered Certificate is already Invoiced";
                Button1.Visible = false;
                btnCloseD.Text = "Close";
               // btnCloseD.Visible = false;
                
                mp3.Show();
                return;
            
            
            }


            om.Status_ = "N";








            mcm.ModifyManualData(om);

          
            Response.Redirect("ManualCert.aspx", false);


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddCustomer.SelectedValue == "")
            {
                lblerrorTaxPriorityadd.Text = "Please Select Customer.";
                mp1.Show();
                return;
            }



            if (txtRefferenceNo.Text == "")
            {
                lblError.Text = "Please Fill out the Refference No to continue.";
                mp1.Show();
                return;
            }

            //if (txtTaxName.Text == "")
            //{
            //    lblError.Text = "Please Fill out the Tax Name to continue.";
            //    mp1.Show();
            //    return;
            //}


            /*
             if (txtTaxPercentages.Text == "" || Int32.Parse(txtTaxPercentages.Text)>100)
             {
                 lblError.Text = "Please Fill out the Tax Percentages Correctly to continue.";
                 mp1.Show();
                 return;
             }
 */
            //if (txtTaxPercentages.Text == "")
            //{
            //    lblError.Text = "Please Fill out the Tax Percentages Correctly to continue.";
            //    mp1.Show();
            //    return;
            //}

            if (ddeItemDescription.SelectedValue == "")
            {
                lblError.Text = "Please Select Tax Priority  to continue.";
                mp1.Show();
                return;
            }



            objmanualcertifi om = new objmanualcertifi();

            om.Created_By = session.User_Id;
            om.Customer_ID = ddCustomer.SelectedValue;
            
            om.Refference_No = txtRefferenceNo.Text;
            om.ExporterInvoice_No = txtInvoiceNo.Text;
            om.Issued_Date = txtIssuedDate.Text;
            om.Item_Description = ddeItemDescription.SelectedValue;
            om.Status_ = "Y";



           

      


            mcm.ModifyManualData(om);

          
            
           
                
           //om.ExporterInvoice_No=
            
            
            
      


          
           // tdm.ModifyTaxData(edittax);
            Response.Redirect("ManualCert.aspx", false);


        }

        protected void btnSubmitA_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddAcustomer.SelectedValue == "")
                {
                    lblerrorTaxPriorityadd.Text = "Please Select Customer Name.";
                    mp2.Show();
                    return;
                }



                if (txtARefferenceNo.Text == "")
                {
                    lblerroradddn.Text = "Please Fill out the Reference No to continue.";
                    mp2.Show();
                    return;
                }
                if (txtAInvoiceNo.Text == "")
                {
                    lblTaxPercentageAdd.Text = "Please Fill out the Invoice No to continue.";
                    mp2.Show();
                    return;
                }


                //if (txtAddTaxPercentage.Text == "" || Int32.Parse(txtAddTaxPercentage.Text) > 100)
                if (txtAIssuedDate.Text == "")
                {
                    lblerrorTaxNameadd.Text = "Please Fill out the Issued Date Correctly to continue.";
                    mp2.Show();
                    return;
                }

                if (ddAItemDescription.SelectedValue == "")
                {
                    lblerrorTaxPriorityadd.Text = "Please Fill out Item Description to continue.";
                    mp2.Show();
                    return;
                }


                string a = txtARefferenceNo.Text;
             

                    objmanualcertifi om = new objmanualcertifi();

                    om.Customer_ID = ddAcustomer.SelectedValue;
                    om.Created_By = session.User_Id;
                    om.Refference_No = txtARefferenceNo.Text;
                    om.ExporterInvoice_No = txtAInvoiceNo.Text;
                    om.Issued_Date = txtAIssuedDate.Text;
                    om.Item_Description = ddAItemDescription.SelectedValue;
                    om.Status_ = "Y";

                    foreach (var data in mcm.getManualData("Y","%","%"))
                    {


                        if (txtARefferenceNo.Text.Equals(data.Refference_No))
                        {


                            lblerrorTaxPriorityadd.Text = "There is another entry with the same Reference No.";
                            mp2.Show();
                            return;







                        }
                       


                    }



                    mcm.CreateManualData(om);
                    ddAcustomer.SelectedIndex = -1;
                    Label3.Text = "Record with Reference No:  <b><i>" +txtARefferenceNo.Text+ " </b></i> Added Successfully";
                    txtARefferenceNo.Text=null;
                    txtAInvoiceNo.Text = null;
                    txtAIssuedDate.Text = null;
                     ddAItemDescription.SelectedIndex = -1;
                

                    mp2.Show();
                
             //   Response.Redirect("ManualCert.aspx", false);


            }
            catch (Exception es)
            {

                ErrorLog.LogError(es);

            }




        }


        protected void btnSubmit2_Click(object sender, EventArgs e)
        {

            txtARefferenceNo.Text = null;
            txtAIssuedDate.Text=null;
            txtAInvoiceNo.Text = null;
            ddAcustomer.SelectedValue =null;

            mp2.Show();

           

        }

        protected void Addbutton_Click(object sender, EventArgs e)
        {
            mp1.Hide();
            txtARefferenceNo.Text = null;
            txtAInvoiceNo.Text = null;
            txtAIssuedDate.Text = null;
            ddAItemDescription.SelectedIndex = -1;

            //txtTaxCodeadd.Text = null;
            //txtTaxNameadd.Text = null;
            //txtAddTaxPercentage.Text = null;
            mp2.Show();


        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mp1.Show();

        }



        protected override void OnInit(EventArgs e)
        {
            GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
            base.OnInit(e);
        }
        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
         
            if (e.Row.RowType != DataControlRowType.DataRow) return;
          

            if (e.Row.Cells[5].Text == "Yes")
            {

                Label sds = (Label)e.Row.FindControl("lblIDs");
                
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton btnReason = (LinkButton)e.Row.FindControl("LinkButton2");
                sds.Text = "Invoiced";
                btnEdit.Visible = false;
                btnReason.Visible = false;
            }

          


        }

       

    }
}