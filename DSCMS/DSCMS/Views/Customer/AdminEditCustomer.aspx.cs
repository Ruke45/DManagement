/*
//PROGRAM-ID.                   CustomerRegistration.cs
//AUTHOR.                             Nipun Munipura
//COMPANY.                         VOTRE IT (Pvt.) Ltd.
 
//DATE-WRITTEN.                                2016-11-08
 
//Version.                               1.0.0
 
//*******************************************************************************
 
//                                Copyright(c) 2016-2017 VOTRE IT Pvt Ltd
 
//                                                        ALL RIGHTS RESERVED
 
//*******************************************************************************
 
//This software is the confidential and proprietary information of VOTRE IT Pvt. Ltd.
 
//("Confidential Information").
 
//You shall not disclose such Confidential Information and shall use it only in
 
//accordance with the terms of the license agreement you entered into with VOTRE IT.
 
//*******************************************************************************
 
//AMENDMENT HISTORY.
 
//===================
 
//  1.  PROGRAMMER   : NIPUN MUNIPURA
 
//      DATE         : 2016-Dec-19
//      Version             : 1.0.1
//      DESCRIPTION  : Add Customer Edit/Add option
//      the command is:customerrequest.AdminName1 = txtContactName.Text.ToString();
 
 

//******************************************************************************
 
//  ABSTRACT ( PROGRAM DESCRIPTION )
 
//  ================================
 
//******************************************************************************
 
//*/

using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.ExportSectorManagement;
using DCISDBManager.trnLib.TemplateMnangement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Customer
{
    public partial class AdminEditCustomer : System.Web.UI.Page
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
                bool auth = Am.IsUserGroupAuthorised(groupId, "ACuEd");
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
                string AdminGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                string CustomerId = null;
                if (userSession.User_Group == AdminGroupId)
                {
                    CustomerId = userSession.Customer_ID;
                }
                else
                {
                    CustomerId = Request.QueryString["CustomerId"];
                }
                

                CustomerApproveManager CAM = new CustomerApproveManager();
                CustomerApproved CusData = CAM.getCustomerDetails(CustomerId, AdminGroupId);
                txtCustomerId.Text = CusData.CustomerId1;
                txtCustName.Text = CusData.CustomerName1;
               // txtAdminName.Text = CusData.Admin1;
                txtAddress1.Text = CusData.Address11;
                txtAddress2.Text = CusData.Address21;
                txtAddress3.Text = CusData.Address31;
                txtEmail.Text = CusData.Email1;
                txtTelephone.Text = CusData.Telephone1;
                txtFax.Text = CusData.Fax1;
                txtContactName.Text = CusData.ContactPersonName1;
                txtContactEmail.Text = CusData.ContactPersonEmail1;
                txtContactMobile.Text = CusData.ContactPersonMobile1;
                txtDesignation.Text = CusData.ContactPersonDesignation1;
                txtPhoneNumber.Text = CusData.ContactPersonDirectPhoneNumber1;
                txaProducts.InnerText = CusData.Productdetails1;
                txtuserName.Text = CusData.UserID1;
                string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                if (userSession.User_Group == AGroupId)
                {
                    RbtnMember.Enabled = false;
                    txtCustName.Enabled = false;
                }
                RbtnMember.SelectedValue = CusData.NCEMember1;
                RblPaid.SelectedValue = CusData.PaidType1;
               

                TemplateDropdown(CusData);

                ExportSectorManager Tm = new ExportSectorManager();
                drpExportSector.DataSource = Tm.getAllExportSector("Y");
                drpExportSector.DataValueField = "ExportId1";
                drpExportSector.DataTextField = "ExportSector1";
                drpExportSector.DataBind();
                drpExportSector1.DataSource = Tm.getAllExportSector("Y");
                drpExportSector1.DataValueField = "ExportId1";
                drpExportSector1.DataTextField = "ExportSector1";
                drpExportSector1.DataBind();
                drpExportSector2.DataSource = Tm.getAllExportSector("Y");
                drpExportSector2.DataValueField = "ExportId1";
                drpExportSector2.DataTextField = "ExportSector1";
                drpExportSector2.DataBind();
                drpExportSector3.DataSource = Tm.getAllExportSector("Y");
                drpExportSector3.DataValueField = "ExportId1";
                drpExportSector3.DataTextField = "ExportSector1";
                drpExportSector3.DataBind();
                drpExportSector4.DataSource = Tm.getAllExportSector("Y");
                drpExportSector4.DataValueField = "ExportId1";
                drpExportSector4.DataTextField = "ExportSector1";
                drpExportSector4.DataBind();
                CustomerDetailManager rm = new CustomerDetailManager();
                int i = 0;
                foreach (var sector in rm.getCustomerExportSector(CustomerId))
                {
                    if (i == 0) {
                        if (drpExportSector.SelectedValue == "")
                        {
                            drpExportSector.SelectedValue = sector.ExportId1;
                           
                        }
                        lblExportSector.Text = sector.Id1.ToString();
                    }
                    if (i == 1) {
                        sector1.Visible = true;
                        if (drpExportSector1.SelectedValue == "")
                        {
                            drpExportSector1.SelectedValue = sector.ExportId1;
                            
                        }
                        lblExportSector1.Text = sector.Id1.ToString();
                    }
                    if (i == 2)
                    {
                        sector2.Visible = true;
                        if (drpExportSector2.SelectedValue == "")
                        {
                            drpExportSector2.SelectedValue = sector.ExportId1;
                            
                        }
                        lblExportSector2.Text = sector.Id1.ToString();
                    }
                    if (i == 3)
                    {
                        sector3.Visible = true;
                        if (drpExportSector3.SelectedValue == "")
                        {
                            drpExportSector3.SelectedValue = sector.ExportId1;
                           
                        }
                        lblExportSector3.Text = sector.Id1.ToString();
                    }
                    if (i == 4)
                    {
                        sector4.Visible = true;
                        if (drpExportSector4.SelectedValue == "")
                        {
                            drpExportSector4.SelectedValue = sector.ExportId1;
                            
                        }
                        lblExportSector4.Text = sector.Id1.ToString();
                    }

                    i++;
                   
                    

                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }

        private void TemplateDropdown(CustomerApproved CusData)
        {
            try
            {
                CustomerTemplateManager Tm = new CustomerTemplateManager();
                drpTemplate.DataSource = Tm.getTemplate("Y");
                drpTemplate.DataValueField = "TemplateId1";
                drpTemplate.DataTextField = "TemplateName1";
                drpTemplate.DataBind();


                if (drpTemplate.SelectedValue == "")
                {

                    drpTemplate.SelectedValue = CusData.TemplateId1;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerRequestManager customerrequestcheck = new CustomerRequestManager();
                CustomerApproveManager CAM = new CustomerApproveManager();
                if (CAM.CheckAllCustomerToEdit(txtCustomerId.Text, txtCustName.Text)==false)
                {
                    CustomerApproved CusUpdate = new CustomerApproved();
                    CusUpdate.CustomerId1 = txtCustomerId.Text;
                    CusUpdate.CustomerName1 = txtCustName.Text;
                   // CusUpdate.Admin1 = txtAdminName.Text;
                    CusUpdate.Address11 = txtAddress1.Text;
                    CusUpdate.Address21 = txtAddress2.Text;
                    CusUpdate.Address31 = txtAddress3.Text;
                    CusUpdate.Email1 = txtEmail.Text;
                    CusUpdate.Telephone1 = txtTelephone.Text;
                    CusUpdate.Fax1 = txtFax.Text;
                    CusUpdate.ContactPersonName1 = txtContactName.Text;
                    CusUpdate.ContactPersonEmail1 = txtContactEmail.Text;
                    CusUpdate.ContactPersonMobile1 = txtContactMobile.Text;
                    CusUpdate.ContactPersonDesignation1 = txtDesignation.Text;
                    CusUpdate.ContactPersonDirectPhoneNumber1 = txtPhoneNumber.Text;
                    CusUpdate.Productdetails1 = txaProducts.InnerText;

                    CusUpdate.NCEMember1 = RbtnMember.SelectedValue;
                    CusUpdate.PaidType1 = RblPaid.SelectedValue;
                   
                    CusUpdate.TemplateId1 = drpTemplate.SelectedValue;
                    CusUpdate.CreatedBy1 = userSession.User_Id;
                    CusUpdate.UserID1 = txtuserName.Text;
                    CusUpdate.NewUserName1 = txtnewUserName.Text;
                    CusUpdate.NewPassword1 = txtPassword.Text;
                    
                    ExportSectorManager Expmanager = new ExportSectorManager();
                    string Customerid = Request.QueryString["CustomerId"];
                    if (Customerid == null) {
                        Customerid = userSession.Customer_ID;
                    }
                    if (lblExportSector.Text=="") {
                        lblExportSector.Text = "0";
                    }
                    if (lblExportSector1.Text == "")
                    {
                        lblExportSector1.Text = "0";
                    }
                    if (lblExportSector2.Text == "")
                    {
                        lblExportSector2.Text = "0";
                    }
                    if (lblExportSector3.Text == "")
                    {
                        lblExportSector3.Text = "0";
                    }
                    if (lblExportSector4.Text == "")
                    {
                        lblExportSector4.Text = "0";
                    }
                    if (drpExportSector.SelectedValue != "")
                    {
                        
                        int id = Convert.ToInt32(lblExportSector.Text);
                        Expmanager.UpdateCustomerExportSector(id, drpExportSector.SelectedValue,Customerid, "Y");
                    }
                    if (drpExportSector1.SelectedValue != "")
                    {
                       int id1=Convert.ToInt32(lblExportSector1.Text);
                        Expmanager.UpdateCustomerExportSector(id1, drpExportSector1.SelectedValue,Customerid, "Y");
                    }
                    if (drpExportSector2.SelectedValue != "")
                    {
                       int id2=Convert.ToInt32(lblExportSector2.Text);
                        Expmanager.UpdateCustomerExportSector(id2, drpExportSector2.SelectedValue,Customerid, "Y");
                    }
                    if (drpExportSector3.SelectedValue != "")
                    {
                       int id3=Convert.ToInt32(lblExportSector3.Text);
                        Expmanager.UpdateCustomerExportSector(id3, drpExportSector3.SelectedValue,Customerid, "Y");
                    }
                    if (drpExportSector4.SelectedValue != "")
                    {
                       int id4=Convert.ToInt32(lblExportSector4.Text);
                        Expmanager.UpdateCustomerExportSector(id4, drpExportSector4.SelectedValue,Customerid, "Y");
                    }
                    if (txtnewUserName.Text == "")
                    {
                        
                            CAM.ModifiCustomerDetails(CusUpdate);
                         string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                         if (userSession.User_Group == AGroupId)
                         {
                             userSession.Template_ID = drpTemplate.SelectedValue;
                             Response.Redirect("~/Views/Home/Dashboard.aspx");
                         }
                         else
                         {
                             Response.Redirect("~/Views/Customer/CustomerEditList.aspx");
                         }
                    }
                    else {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showDiv()", true);
                        string AdminUserId = txtnewUserName.Text;
                        string CheckStatus = "A";
                       

                       CustomerRequest check1 = customerrequestcheck.getAdministratorID(AdminUserId, CheckStatus);

                        if (txtConfermpass.Text == "") {
                            lblconPassword.Visible = true;
                        }
                        if (txtPassword.Text == "")
                        {
                            lblpasswordrequired.Visible = true;
                        }
                        if (check1.AdminUserId1 != null)
                        {
                            lbluserName.Visible = true;
                            string msg = null;
                            msg += "<div class=\"alert alert-dismissable alert-warning\">";
                            msg += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            msg += " The Administrator Exists...! Try Another User Name</div>";
                            ErrorMessage1.InnerHtml = msg;
                        }
                       
                        else
                        {
                            CAM.ModifiCustomerDetailsWithCAdmin(CusUpdate);
                            string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
                            if (userSession.User_Group == AGroupId)
                            {
                                Response.Redirect("~/Views/Home/Logout.aspx");
                            }else{
                           
                            Response.Redirect("~/Views/Customer/CustomerEditList.aspx");
                            }
                        }
                    }

                    
                }
                else {
                    lblCusCheck.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string msg = null;
                msg += "<div class=\"alert alert-dismissable alert-warning\">";
                msg += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                msg += " Save Fail !</div>";
                ErrorMessage1.InnerHtml = msg;
                ErrorLog.LogError(ex);

            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
             string AGroupId = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_CustomerAdmin"];
             if (userSession.User_Group == AGroupId)
             {
                 Response.Redirect("~/Views/Home/Dashboard.aspx");
             }
             else
             {
                 Response.Redirect("~/Views/Customer/CustomerEditList.aspx");
             }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sector1.Visible = true;
            drpExportSector1.Focus();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            sector2.Visible = true;
            drpExportSector2.Focus();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            sector3.Visible = true;
            drpExportSector3.Focus();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            sector4.Visible = true;
            drpExportSector4.Focus();
        }
    }
}