using DCISDBManager.objLib.Rates;
using DCISDBManager.objLib.TaxDetails;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.RateManagement;
using DCISDBManager.trnLib.TaxManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Customer
{
    public partial class CustomerFinanceData : System.Web.UI.Page
    {
        UserSession userSession;
        string CustomerId=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

            CheckAuthentication();
            CustomerId =Request.QueryString["CusId"];
             if (!IsPostBack)
             {
                 try
                 {
                     CustomerDetailManager Cmanager = new CustomerDetailManager();
                     string details = Cmanager.getMemberDetails(CustomerId);
                     string Ratestatus = "Y";
                     if (details == "Yes")
                     {
                         lblMemberMassage.Text = "NCE Member Rates ";
                     }
                     else {
                         lblMemberMassage.Text = "NCE Non-Member Rates ";
                     }
                     if (CustomerId != "")
                     {
                         lblCustomerName.Text = "Customer ID :-" + CustomerId;
                         RateManager Rm = new RateManager();
                         gvfinance.DataSource = Rm.getMemberRates(details, Ratestatus);
                         gvfinance.DataBind();

                     }
                 }
                 catch (Exception ex)
                 {
                     ErrorLog.LogError(ex);

                 }
             }
        }

        private void CheckAuthentication()
        {
            try
            {
                if (userSession.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "CuFi");
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try{
                bool check = false;
                string qu = null;
               string paidType= RbtnPaidType.Text;
            foreach (GridViewRow row in gvfinance.Rows)
            {
                
                string RateId = row.Cells[0].Text;
                string Ratename = row.Cells[1].Text;
                var txtValue = row.FindControl("txtValue") as TextBox;
                var value = txtValue.Text;
                if (value != "")
                {
                    decimal RateValue1 = Convert.ToDecimal(value);

                    RateManager Rm = new RateManager();
                    Rates data = new Rates();

                    data.CustomerId1 = CustomerId;
                    data.RatesId1 = RateId;
                    data.Rates1 = RateValue1;
                    data.PaidType1 = paidType;



                     check = Rm.setCustomerRate(data);
                   
                }
            }
            if (gvfinance.Rows == null) {
                
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Please Enter Rate Values First</div>";
            }
            if (check == true)
            {
                Response.Redirect("CustomerEditList.aspx");
            }
            else
            {
                
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Save Faill</div>";


                ErrorMessage.InnerHtml = qu;
            }
            }
                    catch (Exception ex) {
                        ErrorLog.LogError(ex);
                    }
                }
                
              


            }
          
            
           }

        
    
