using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Customer
{
    public partial class AdminEditUser : System.Web.UI.Page
    {
        UserSession session;
        string CustomerId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            session = new UserSession();
           CheckAutentication();
            CustomerId = drpCustomer.SelectedValue.ToString();
            if (CustomerId == "--Select Customer Name--")
            {
                drpCustomer.SelectedValue = Request.QueryString["CusId"];
            }
            FirstPageData();
        }
        private void CheckAutentication()
        {
            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            try
            {
                string groupId = session.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "UsEdi");
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

        private void FirstPageData()
        {
            try
            {
               
                string IsActive = "Y";
                CustomerDetailManager cm = new CustomerDetailManager();

                drpCustomer.DataSource = cm.getAllCustomer("Y");
                drpCustomer.DataValueField = "CustomerId1";
                drpCustomer.DataTextField = "CustomerName1";
                drpCustomer.DataBind();


                string CustomerId = drpCustomer.SelectedValue;
                CustomerApproveManager CAM = new CustomerApproveManager();
                gvUser.DataSource = CAM.getAllUserUsingCustomer(CustomerId, IsActive);
                gvUser.DataBind();

                UserGroupManager UGM = new UserGroupManager();
                drpUserGroup.DataSource = UGM.getUserGroup("%", "y");
                drpUserGroup.DataTextField = "GroupName1";
                drpUserGroup.DataValueField = "GroupId1";
                drpUserGroup.DataBind();
                txtCustomer.Text = CustomerId;
               
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
           try{ 
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                lblUserName.Text = row.Cells[0].Text;
                txtPersonName.Text=row.Cells[1].Text;

            }
            ReasonPop.Visible = true;
           }
           catch (Exception ex)
           {
               ErrorLog.LogError(ex);
           }
        }

        protected void Save_btn(object sender, EventArgs e)
        {
            try{
            string UserName = lblUserName.Text;
            string PersonName = txtPersonName.Text;
            string IsActive = "Y";
            ReasonPop.Visible = false;
            UpdateUserTable(UserName, PersonName, IsActive);
            Response.Redirect("~/Views/Customer/AdminEditUser.aspx?CusId=" + CustomerId, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void Close_btn(object sender, EventArgs e)
        {
            ReasonPop.Visible = false;
            divRemove.Visible = false;
           
        }
        protected void Remove_btn(object sender, EventArgs e)
        {
            try{
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
                lblUserid.Text = row.Cells[0].Text;
                lblPersonName.Text = row.Cells[1].Text;
            }
            divRemove.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }
        protected void Confirm_btn(object sender, EventArgs e) {
            try{
            string UserName = lblUserid.Text;
            string PersonName =lblPersonName.Text;
            string IsActive = "N";
            divRemove.Visible = false;
            UpdateUserTable(UserName, PersonName, IsActive);
            Response.Redirect("~/Views/Customer/AdminEditUser.aspx?CusId=" + CustomerId, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }

        }

        private static void UpdateUserTable(string UserName, string PersonName, string IsActive)
        {
            try{
            CustomerApproveManager CAM = new CustomerApproveManager();
            CustomerApproved customer = new CustomerApproved();
            customer.Admin1 = UserName;
            customer.PersonName1 = PersonName;
            customer.IsActive1 = IsActive;
            CAM.ModifiUserDetails(customer);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }



       
            

         
        protected void Add_new(object sender, EventArgs e)
        {
            UserManager UM = new UserManager();
            string GroupIdWeb = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
            string GroupId = drpUserGroup.SelectedValue.ToString();
            
            string UserName=txtUserName.Text;
            bool checkok=false;
            if (UM.CheckUserIDAvailability(UserName) == false)
            {
                CustomerApproveManager CAM = new CustomerApproveManager();
                if (GroupId == GroupIdWeb)
                {
                    if (CAM.getCheckUserGroup(CustomerId, GroupId, "Y") == false)
                    {
                        checkok = true;
                    }
                    else
                    {
                        lblGroupErrormsg.Visible = true;
                    }
                }
                else {
                    checkok = true;
                
                }

            }
            else {
                lblUserNameCheck.Visible = true;
            }

            if(checkok==true){
            DCISDBManager.objLib.Usr.User adUser = new DCISDBManager.objLib.Usr.User();

                        adUser.Customer_ID = CustomerId;
                        adUser.UserGroup_ID = GroupId;
                        adUser.Password_ = txtPassword.Text;
                        adUser.Person_Name = txtAdminName.Text;
                        adUser.User_ID = txtUserName.Text;
                        adUser.Created_By =session.Customer_ID;
                        adUser.Is_Active = "Y";
                        string expdate = System.Configuration.ConfigurationManager.AppSettings["ExpiryDate"];
                        adUser.PassowordExpiry_DateN = DateTime.Today.AddDays(Int32.Parse(expdate));
                        UM.CreateNewUserN(adUser);
                        
                        Response.Redirect("~/Views/Customer/AdminEditUser.aspx?CusId="+CustomerId,false);
                       
            }

         }
       
    }
}