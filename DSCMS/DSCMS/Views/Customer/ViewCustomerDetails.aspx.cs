using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.trnLib.CustomerRequestManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DCISDBManager.objLib.Template;
using DCISDBManager.trnLib.TemplateMnangement;
using System.Web.UI.WebControls;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.Utility;
using DCISDBManager.trnLib.ExportSectorManagement;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace DSCMS.Views.Customer
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();

            if (!this.IsPostBack)
            {
                GetFillingData();

            }






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
                bool auth = Am.IsUserGroupAuthorised(groupId, "CusView");
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
        private void GetFillingData()
        {   
            try
            {
                string CustomerId = null;
                string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
                string SGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
                string FGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_FAdmin"];
                string AdminGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                if (AGroupId == userSession.User_Group || SGroupId == userSession.User_Group || FGroupId == userSession.User_Group)
                {
                string Customer = Request.QueryString["CustomerId"];
                
                    CustomerId = Customer;
                }
                else
                {
                    CustomerId = userSession.Customer_ID;
                }
                CustomerApproveManager CAM = new CustomerApproveManager();
                CustomerApproved CusData = CAM.getCustomerDetails(CustomerId, AdminGroupId);
                lblCustomerId.Text = CusData.CustomerId1;
                lblCustName.Text = CusData.CustomerName1;
                lblAddress1.Text = CusData.Address11;
                lblAddress2.Text = CusData.Address21;
                lblAddress3.Text = CusData.Address31;
                lblEmail.Text = CusData.Email1;
                lblTelephone.Text = CusData.Telephone1;
                lblFax.Text = CusData.Fax1;
                lblContactName.Text = CusData.ContactPersonName1;
                lblContactEmail.Text = CusData.ContactPersonEmail1;
                lblContactMobile.Text = CusData.ContactPersonMobile1;
                lblDesignation.Text = CusData.ContactPersonDesignation1;
                lblPhoneNumber.Text = CusData.ContactPersonDirectPhoneNumber1;
                txaProducts.InnerText = CusData.Productdetails1;
                //lblExportSector.Text = CusData.ExportSector1;
                CustomerDetailManager rm = new CustomerDetailManager();
                string ExSector = null;
                foreach (var sector in rm.getCustomerExportSector(CustomerId))
                {
                    ExSector +=sector.ExportSector1+",";
                }
                lblExportSector.Text = ExSector;
                lblMember.Text = CusData.NCEMember1;
                lblPaidType.Text = CusData.PaidType1;
                lblTemplate.Text = CusData.TemplateName1;
                lblAdminName.Text = CusData.Admin1;
                lblUserName.Text = CusData.UserID1;
                if (CusData.IsSVat1 == "1")
                {
                    lblisVat.Text = "SVAT Customer";
                }
                else {
                    lblisVat.Text ="VAT Customer";
                }
                
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
        }

     

        protected void btnBack_Click(object sender, EventArgs e)
        {
           
            string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
            string SGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_SAdmin"];
            string FGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_FAdmin"];
            string AdminGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
            if (AGroupId == userSession.User_Group || SGroupId == userSession.User_Group || FGroupId == userSession.User_Group)
            {
                Response.Redirect("~/Views/Customer/CustomerEditList.aspx");
            }
            else {
                Response.Redirect("~/Views/Home/Dashboard.aspx");
            }
           
    
        }
    }
}