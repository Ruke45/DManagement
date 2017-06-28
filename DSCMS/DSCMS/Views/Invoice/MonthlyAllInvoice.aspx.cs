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
    public partial class MonthlyAllInvoice : System.Web.UI.Page
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
            bool auth = Am.IsUserGroupAuthorised(groupId, "InvBl");
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
        private void NewMethod(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                InvoiceManager rm = new InvoiceManager();
                DateTime a = DateTime.Now;

                string Start = StartDate.ToString("yyyyMMdd");
                string End = EndDate.ToString("yyyyMMdd");
                string CustomerId = drpCustomer.SelectedValue;

                gvInvoice.DataSource = rm.getAllInvoice(Start, End, "A", CustomerId);
                gvInvoice.DataBind();
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

 

        protected void gvInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

                string StartDate = txtFromDate.Text;
            string EndDate = txtTodate.Text;
            
            string cus = gvInvoice.SelectedRow.Cells[0].Text;

            Response.Redirect("InvoiceGenarator.aspx?StartDate=" + StartDate + "&EndDate=" + EndDate + "&cus=" + cus, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
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
                if (txtTodate.Text == "")
                {
                    string Start = Request.QueryString["Start"];
                    string End = Request.QueryString["End"];
                    StartDate = DateTime.ParseExact(Start, "dd/MM/yyyy", null);
                    //DateTime StartDate = Convert.ToDateTime(txtFromDate.Text);
                    EndDate = DateTime.ParseExact(End, "dd/MM/yyyy", null);
                    txtFromDate.Text=Start;
                    txtTodate.Text = End;
                     todate = Start;
                     fromdate = End;
                }
                // DateTime EndDate = Convert.ToDateTime(txtTodate.Text);
                if (txtTodate.Text != "" || txtFromDate.Text != "")
                {
                    StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null);
                    //DateTime StartDate = Convert.ToDateTime(txtFromDate.Text);
                    EndDate = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null);
                     todate = txtFromDate.Text;
                     fromdate = txtTodate.Text;
                }

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

                //}

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               // Response.Redirect("~/Views/Home/Login.aspx");
            }
        }


        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DateTime StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null);
                DateTime EndDate= DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null);
                gvInvoice.PageIndex = e.NewPageIndex;
                NewMethod(StartDate, EndDate);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                Response.Redirect("~/Views/Home/Login.aspx");
            }
        }

        protected void DesableDates(object sender, DayRenderEventArgs e) {
            if (e.Day.Date > DateTime.Today) {
              //  e.Day.IsSelectable = false;
            }
        }


    }
  
}