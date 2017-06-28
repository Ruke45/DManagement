
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.MasterMaintainance;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



namespace DSCMS
{
    public partial class CustomerRequestStatus : System.Web.UI.Page
    {
       
        UserSession userSession;
        CertficateRequestDataManagement crd = new CertficateRequestDataManagement();
        SupportingDocumentManagement sdm = new SupportingDocumentManagement();
        DownloadCertificate dc = new DownloadCertificate();
        string Customer = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Customer"];
        CustomerDetailManager cdm = new CustomerDetailManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Start = DateTime.Now.ToString("yyyyMMdd");

            string End = DateTime.Now.ToString("yyyyMMdd");
            UserSession us = new UserSession();
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtTodate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                ddStatus.SelectedValue = "All";
                DropDownList1.SelectedValue = "All";
                if (us.User_Group != "CUSTOMER" && us.User_Group != "CADMIN")
                {
                    ddCustomer.SelectedValue = "All";
                }
                else
                {

                    string cusid = us.Customer_ID;
                    ddCustomer.SelectedValue = us.Customer_ID;
                }

          
            
            if (us.User_Group != "CUSTOMER" && us.User_Group != "CADMIN")
            {
               
                gvCusreq.DataSource = crd.getEmailCustomerRequestn("%", "%", "%", Start, End, "All","%");
            }
            else {

                string cusid = us.Customer_ID;
               
                gvCusreq.DataSource = crd.getEmailCustomerRequestn("%", cusid, "%", Start, End, "All","%");
            
            }
            gvCusreq.DataBind();
            }
            hd.Visible = false;
            userSession = new UserSession();

         UserAutentication();
         if (userSession.User_Group != "ADMIN" && userSession.User_Group != "SADMIN")
          {

              ddCustomer.SelectedValue = userSession.Customer_ID;
                ddCustomer.Enabled = false;
          }
          if (!Page.IsPostBack)
          {

              BindDropDown();
          }

        //  string Start = DateTime.Now.ToString("yyyyMMdd");
        

          //  BindDData();
            //----
            //if (Calendar1.SelectedDate.ToShortDateString() != "1/1/0001")
            //    txtFromDate.Text = Calendar1.SelectedDate.ToShortDateString();
            //if (Calendar2.SelectedDate.ToShortDateString() != "1/1/0001")
            //    txtTodate.Text = Calendar2.SelectedDate.ToShortDateString();
            //if (ddStatus.SelectedValue != "")


            //.....
            //{
            //    grid();
            //}

        }


        

        public void BindDropDown()
        {
            try
            {

                ddCustomer.DataSource = cdm.getAllCustomer("y");
                ddCustomer.DataTextField = "CustomerName1";
                ddCustomer.DataValueField = "CustomerId1";

                ddCustomer.DataBind();


            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }

        public void BindDData()
        {
            try
            {

                if (txtRequestNo.Text != "")
                {
                    gvCusreq.DataSource = crd.getEmailCustomerRequest(txtRequestNo.Text, "%", "%", "20000707", "20160707");

                    gvCusreq.DataBind();



                }
                else
                {


                    // GridView1.DataSource = rm.getReasons("%");
                    //  GridView1.DataSource = rm.getTemplateSupportingDocument("%", "y");
                    gvCusreq.DataSource = crd.getEmailCustomerRequest("%", "%", "%", "20000707", "20160707");

                    gvCusreq.DataBind();

                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }


        private void UserAutentication()
        {
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = userSession.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "ptype");
            //if (auth == false)
            //{
            //    Response.Redirect("~/Views/Home/Login.aspx");
            //}
        }
        protected void gvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {

         



        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvCusreq.PageIndex = e.NewPageIndex;

          //  gvCusreq.DataBind();
            grid();
        
        }

        protected void btnReject_Click(object sender, EventArgs e) {

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                Label lblTemp = null;

                lblTemp = (Label)row.FindControl("lblRejectCode");

               string reason= crd.getRejectReason(lblTemp.Text, "%");

               Label1.Text = reason;

                mp3.Show();


            }
        
        
        }

   

        protected void ck(object sender, EventArgs e)
       {

            this.gvCusreq.Columns[8].Visible = false;

            //e.Row.Cells[7].Visible = false;

        
        
        }

        protected void btnDetails_Click(object sender, EventArgs e) {

            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {

                Label lblTemp = null;

                lblTemp = (Label)row.FindControl("lblRequest_ID");

                string ReqID = lblTemp.Text;

                if (row.Cells[0].Text.Equals("Document"))
                {
                    string sdID = row.Cells[1].Text;
                    string Text = sdm.getSupDocName(sdID);
                    lblDocName.Text = Text;
                    mp2.Show();

                    //  Response.Redirect("~/Views/Maintenance/CustomerRequestStatus.aspx");
                }
                else
                {
                 //   Response.Redirect("~/Views/Maintenance/CustomerRequestStatsusDetails.aspx?RQID=" + ReqID);
                    Response.Redirect("~/Views/Certificate/certdetails.aspx?ReqstID=" + ReqID);
                }
            }
        
        }
        protected void btnDelete_DataBinding(object sender, System.EventArgs e)
        { }

        protected override void OnInit(EventArgs e)
        {
            gvCusreq.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
            base.OnInit(e);
        }
        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            //{
            //    if (row.Cells[3].Text == "Rejected")
            //    {

            //        LinkButton btnEdit = (LinkButton)e.Row.FindControl("LinkButton3");
            //        btnEdit.Visible = false;

            //    }
            //}

           // if (e.Row.RowType != DataControlRowType.DataRow) return;

            //  string Is_Downloaded;
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            //if (DropDownList1.SelectedValue == "Normal")
            //{
            //    if (e.Row.Cells[0].Text == "Document" || e.Row.Cells[0].Text == "Emailed" || e.Row.Cells[0].Text == "Uploaded")
            //    {
            //        e.Row.Visible = false;
                
            //    }
            
            
            //}

            //if (DropDownList1.SelectedValue == "Uploaded")
            //{
            //    if (e.Row.Cells[0].Text == "Document" || e.Row.Cells[0].Text == "Emailed" || e.Row.Cells[0].Text == "Normal")
            //    {
            //        e.Row.Visible = false;

            //    }


            //}
            //if (DropDownList1.SelectedValue == "Document")
            //{
            //    if (e.Row.Cells[0].Text == "Normal" || e.Row.Cells[0].Text == "Emailed" || e.Row.Cells[0].Text == "Uploaded")
            //    {
            //        e.Row.Visible = false;

            //    }


            //}
            //if (DropDownList1.SelectedValue == "Emailed")
            //{
            //    if (e.Row.Cells[0].Text == "Document" || e.Row.Cells[0].Text == "Normal" || e.Row.Cells[0].Text == "Uploaded")
            //    {
            //        e.Row.Visible = false;

            //    }


            //}
            //if (DropDownList1.SelectedValue == "") { }
            //if (DropDownList1.SelectedValue == "") { }
            //if (DropDownList1.SelectedValue == "") { }

            if (e.Row.Cells[4].Text == "Reject")
            {
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("LinkButton3");
                LinkButton btnReason = (LinkButton)e.Row.FindControl("LinkButton1");
               
                btnEdit.Visible = false;
                btnReason.Visible = true;
            }

            if (e.Row.Cells[0].Text == "Uploaded Certificate")
            {
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("LinkButton3");
                btnEdit.Visible = false;
            }


        }

        void disable(object sender, EventArgs e)
        {
            //LinkButton btnEdit = (LinkButton)e.Row.FindControl("LinkButton3");
            //LinkButton btnReason = (LinkButton)e.Row.FindControl("LinkButton1");

          //  btnEdit.Visible = false;
          //  btnReason.Visible = false;

        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Visible = false;
            labdatevalidation.Visible = false;

            grid();
        }

      
        private void grid()
        {

            lblCustomer.Visible = false;
            lblStatus.Visible = false;
            DateTime StartDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime EndDate = Convert.ToDateTime(txtTodate.Text);

            int S = DateTime.Compare(StartDate, EndDate);
            if (S > 0) {
                    labdatevalidation.Visible = true;
                   labdatevalidation.Text = "Select values for two date fields corectly";
                   return;
            
            }
            string Start = StartDate.ToString("yyyyMMdd");
            string End = EndDate.ToString("yyyyMMdd");
            var todate = txtFromDate.Text;
            var fromdate = txtTodate.Text;

            string[] startdate = todate.Split('-', '/');
            string[] enddate = fromdate.Split('-', '/');

            string sdays = startdate[1];
            string years = startdate[2];
            string month = startdate[0];

            string edays = enddate[1];
            string eyears = enddate[2];
            string emonth = enddate[0];

            string reqNo = "%";
            string Invoiceno = "%";
            string CusID = "%";
            string status = "%";
            string FrmDate = years + month + sdays;
            string Todate = eyears + emonth + edays;


            int FrmDateI = Int32.Parse(FrmDate);
            int TodateI = Int32.Parse(Todate);
            if (txtRequestNo.Text != "")
            {
                reqNo = txtRequestNo.Text;



            }

            if (txtInvoice.Text != "")
            {
                Invoiceno = txtInvoice.Text;



            }

           

            //if (FrmDateI > TodateI)
            //{
            //    labdatevalidation.Visible = true;
            //    labdatevalidation.Text = "Select values for two date fields corectly";

            //}
            if (DropDownList1.SelectedValue == "")
            {

                Label2.Visible = true;
            }

            if (ddStatus.SelectedValue == "")
            {

                lblStatus.Visible = true;
            }

            if (ddCustomer.SelectedValue == "")
            {

                lblCustomer.Visible = true;
            }

            if (ddStatus.SelectedValue == "All")
            {
                status = "%";

            }
            if (ddStatus.SelectedValue == "Approved")
            {
                status = "A";

            }
            if (ddStatus.SelectedValue == "Reject")
            {
                status = "R";

            }
            if (ddStatus.SelectedValue == "Pending")
            {
                status = "P";

            }
            if (ddCustomer.SelectedValue == "All")
            {
                CusID = "%";

            }
            else
            {
                CusID = ddCustomer.SelectedValue;

            }

            if (userSession.User_Group == Customer)
            {
                ddCustomer.Enabled = false;
                //  CusID = dc.getCustIDfrmUserID(userSession.User_Id);
                CusID = userSession.Customer_ID;

            }

         //   if (DropDownList1.SelectedValue == "Normal")
          //  {
             //   status = "G";

           // }

            // download.visible = "true";
           
           
            String type = DropDownList1.SelectedValue;
          
               

               hd.Visible = true;


            //  gvCusreq.DataSource = crd.getEmailCustomerRequestn(reqNo, CusID, status, FrmDate, Todate, type);
               if (txtInvoice.Text != "")
               {
                   Invoiceno = txtInvoice.Text;
                   gvCusreq.DataSource =crd.getstatusfromInvoice(reqNo, CusID, status, Start, End, type, Invoiceno);
                   gvCusreq.DataBind();


               }
               else
               {
                   gvCusreq.DataSource = crd.getEmailCustomerRequestn(reqNo, CusID, status, Start, End, type, Invoiceno);
                   gvCusreq.DataBind();
               }
            Label3.Text = "Status List from " + StartDate.ToShortDateString() + " to " + EndDate.ToShortDateString();
            gvDownload.DataSource = crd.getEmailCustomerRequestn(reqNo, CusID, status, Start, End, type, Invoiceno);
            gvDownload.DataBind();
            //     gvCusreq.DataSource = crd.getEmailCustomerRequest(reqNo, CusID, status, FrmDate, Todate);

            //       gvCusreq.DataBind();


        }

        protected void ExportToPDF(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages


                    gride.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=StatusView.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        //public override void VerifyRenderingInServerForm(Control control)
        //{


        //}
     

    }
}