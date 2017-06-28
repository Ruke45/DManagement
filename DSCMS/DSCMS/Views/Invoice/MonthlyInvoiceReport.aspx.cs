using DCISDBManager.objLib.Invoice;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.InvoiceManeger;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS
{
    public partial class MonthlyInvoiceReport : System.Web.UI.Page
    {
      UserSession userSession;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

            UserAutentication();
            if (!IsPostBack)
            {
                if (txtTodate.Text == "")
                {
                    string Start = Request.QueryString["Start"];
                    string End = Request.QueryString["End"];
                    if (Start != null || End != null)
                    {
                        GetingData();
                    }
                }
                try
                {
                    CustomerDetailManager cm = new CustomerDetailManager();

                    drpCustomer.DataSource = cm.getAllCustomer("Y");
                    drpCustomer.DataValueField = "CustomerId1";
                    drpCustomer.DataTextField = "CustomerName1";
                    drpCustomer.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);

                }
            }
            

        }

        private void UserAutentication()
        {
            try{
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = userSession.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "InvRe");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {

            GetingData();
            
        }

        private void GetingData()
        {
            try
            {
                var todate = txtFromDate.Text;
                var fromdate = txtTodate.Text;
                DateTime StartDate = DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null);
                DateTime EndDate = DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null); 
                // DateTime EndDate = Convert.ToDateTime(txtTodate.Text);

                if (txtTodate.Text == "") {
                string Start = Request.QueryString["Start"];
                string End = Request.QueryString["End"];
                 StartDate = DateTime.ParseExact(Start, "dd/MM/yyyy", null);
                 EndDate = DateTime.ParseExact(End, "dd/MM/yyyy", null);
                 txtFromDate.Text = Start;
                 txtTodate.Text = End;
                 todate = Start;
                 fromdate = End;
                }
                if (txtFromDate.Text != "" || txtTodate.Text != "")
                {
                     StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null);
                    //StartDate = Convert.ToDateTime(txtFromDate.Text);
                    //EndDate = Convert.ToDateTime(txtTodate.Text);
                     EndDate = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null);
                     todate = txtFromDate.Text;
                     fromdate = txtTodate.Text;
                }
               


                if (todate != "01/01/0001" || fromdate != "01/01/0001")
                {
                    //string[] startdate = todate.Split('/');
                    //string[] enddate = fromdate.Split('/');

                    //string syear = startdate[2];
                    //string smonth = startdate[1];
                    //string sday = startdate[0];

                    //string eyear = enddate[2];
                    //string emonth = enddate[1];
                    //string eday = enddate[0];
                    //int check = 0;
                    //int scheck = 0;

                    //if (sday != "01")
                    //{
                    //    labstartdatevalidation.Visible = true;
                    //    labstartdatevalidation.Text = "You Must Select Start of the Month.";
                    //    scheck = 1;

                    //}
                    //if (syear == eyear && smonth == emonth)
                    //{
                    //    if (emonth == "01" || emonth == "03" || emonth == "05" || emonth == "07" || emonth == "08" || emonth == "10" || emonth == "12")
                    //    {
                    //        if (eday != "31")
                    //        {
                    //            labdatevalidation.Visible = true;
                    //            labdatevalidation.Text = "You Must Select End of the Month.";
                    //            check = 1;
                    //        }
                    //    }
                    //    if (emonth == "04" || emonth == "06" || emonth == "09" || emonth == "11")
                    //    {
                    //        if (eday != "30")
                    //        {
                    //            labdatevalidation.Visible = true;
                    //            labdatevalidation.Text = "You Must Select End of the Month.";
                    //            check = 1;
                    //        }
                    //    }
                    //    int endyear = Int32.Parse(eyear);
                    //    decimal checkyear1 = endyear % 4;
                    //    if (checkyear1 == 0)
                    //    {
                    //        if (emonth == "02" && eday != "29")
                    //        {
                    //            labdatevalidation.Visible = true;
                    //            labdatevalidation.Text = "You Must Select End of the Month.";
                    //            check = 1;
                    //        }
                    //    }
                    //    if (checkyear1 != 0)
                    //    {
                    //        if (emonth == "02" && eday != "28")
                    //        {
                    //            labdatevalidation.Visible = true;
                    //            labdatevalidation.Text = "You Must Select End of the Month.";
                    //            check = 1;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    labdatevalidation.Visible = true;
                    //    labdatevalidation.Text = "You Must Select Same Month.";
                    //    check = 1;
                    //}


                    //if (check != 1)
                    //{
                    //    labdatevalidation.Visible = false;

                    //}
                    //if (scheck != 1)
                    //{
                    //    labstartdatevalidation.Visible = false;
                    //}

                    //if (scheck != 1 && check != 1)
                    //{


                        NewMethod(StartDate, EndDate);

                  //  }
                }
                else
                {
                    labdatevalidation.Visible = true;
                    labdatevalidation.Text = "Required Field.";
                    labstartdatevalidation.Visible = true;
                    labstartdatevalidation.Text = "Required Field.";
                }


            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }
        
        private void NewMethod(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                InvoiceDetailSavingManager rm = new InvoiceDetailSavingManager();

                string Start = StartDate.ToString("yyyyMMdd");
                string End = EndDate.ToString("yyyyMMdd");

                bindgrid(rm, Start, End);
                
               
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        private void bindgrid(InvoiceDetailSavingManager rm, string Start, string End)
        {
            try{
                string CustomerId = drpCustomer.SelectedValue;
            gvInvoice.DataSource = rm.getInvoiceReport(Start, End,CustomerId);
            gvInvoice.DataBind();
            decimal total = 0;
            foreach (var cal in rm.getInvoiceReport(Start, End,CustomerId))
            {
                
                total = cal.InvoiceTotal1 + total;
            }
            lblTotalCount.Text =Math.Round(total,2).ToString();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
        }

        protected void gvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
            string InvNo = gvInvoice.SelectedRow.Cells[0].Text;
            string CusID = gvInvoice.SelectedRow.Cells[1].Text;
            string GTotal = gvInvoice.SelectedRow.Cells[5].Text;
            string NTotal = gvInvoice.SelectedRow.Cells[6].Text;
            var Start=txtFromDate.Text;
            var End = txtTodate.Text;
            Response.Redirect("BillPrints.aspx?InvNo=" + InvNo + "&start=" + Start + "&End=" + End, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
              
            }
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try{
                DateTime StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null);
                DateTime EndDate  = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null);
                
                gvInvoice.PageIndex = e.NewPageIndex;
                NewMethod(StartDate, EndDate);
            
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
        }

       
        
    }
}