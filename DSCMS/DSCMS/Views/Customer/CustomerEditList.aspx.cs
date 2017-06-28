using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Customer
{
    public partial class CustomerEditList : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
            if(!IsPostBack){
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
            gridView();
        }
        private void CheckAutentication()
        {
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            try
            {
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "ACuEdLi");
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
        private void gridView()
        {
            try
            {
                CustomerApproveManager CAM = new CustomerApproveManager();
                string Admin = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                string customerId = drpCustomer.SelectedValue;
                gvCustomer.DataSource = CAM.getAllCustomer(customerId, Admin);
                gvCustomer.DataBind();
                string divID = null;
                foreach (var data in CAM.getAllCustomer(customerId, Admin))
                {
                    divID += "<tr><td>" + data.CustomerId1 + "</td>";
                    divID += "<td>" + data.CustomerName1 + "</td>";
                    //  divID += "<td>" + PortOfDischarge + "</td>";
                    divID += "<td>" + data.Address11 + "</td>";
                    //divID += "<td>" + Consignee + "</td>";
                    divID += "<td>" + data.Address21 + "</td>";
                    //divID += "<td>" + PaidType + "</td>";
                    divID += "<td>" + data.Address31 + "</td>";
                    divID += "<td>" + data.ContactPersonName1 + "</td>";
                    divID += "<td>" + data.ContactPersonMobile1 + "</td>";
                    divID += "<td>" + data.ContactPersonDirectPhoneNumber1 + "</td>";
                    divID += "<td>" + data.ContactPersonEmail1 + "</td>";
                    divID += "<td>" + data.UserID1 + "</td></tr>";
                   
                   
                }
                head.InnerHtml = divID;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string CustomerId = null;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                CustomerId = row.Cells[0].Text;
            }
           Response.Redirect("~/Views/Customer/AdminEditCustomer.aspx?CustomerId=" + CustomerId, false);
            
        }
        protected void View_Click(object sender, EventArgs e)
        {
            string CustomerId = null;
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                CustomerId = row.Cells[0].Text;
            }


            Response.Redirect("~/Views/Customer/ViewCustomerDetails.aspx?CustomerId=" + CustomerId, false);
    
        }

        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvCustomer.PageIndex = e.NewPageIndex;
            gridView();
        }

        protected void gvCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string AdminUserId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
                if (AdminUserId != userSession.User_Group)
                {
                    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("Approve");
                    lnkBtn.Visible = false;
                }
            }
        }



      
    }
}