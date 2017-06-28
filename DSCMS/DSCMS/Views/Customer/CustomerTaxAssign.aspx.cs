
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
    public partial class CustomerTaxAssign : System.Web.UI.Page
    {
        UserSession userSession;
        string CustomerId=null;
        string SVAT = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();

            UserAutentication();
           
            Dropdownlist();
            string cus = Request.QueryString["cus"];
            if (cus == null && drpCustomer.SelectedValue == "no")
            {
                divcontent.Visible = false;
            }
            else {
                divcontent.Visible = true;
          
            }
           
        }

        private void UserAutentication()
        {
            try
            {
                if (userSession.User_Id == "")
                {
                    Response.Redirect("~/Views/Home/Login.aspx");
                }
                string groupId = userSession.User_Group;
                CheckAuthManager Am = new CheckAuthManager();
                bool auth = Am.IsUserGroupAuthorised(groupId, "CuTxA");
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

        private void Dropdownlist()
        {
            try
            {
               
                
                
                CustomerId = drpCustomer.SelectedValue.ToString();
                if (!IsPostBack)
                {

                    GetAllCustomer();
                    getTaxdetails();

                }
               
                if (CustomerId != "no")
                {
                    divcontent.Visible = true;
                }

                getAllTaxdetail(CustomerId);
                CustomerId = drpCustomer.SelectedValue;
              
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
               
            }
        }
       
        private void getTaxdetails()
        {
            try
            {
                TaxManager tax = new TaxManager();

                drpTax.DataSource = tax.getTaxDetails("Y","0");
                drpTax.DataValueField = "TaxCode1";
                drpTax.DataTextField = "TaxName1";
                drpTax.DataBind();

                RateManager Rm = new RateManager();
                droRate.DataSource = Rm.getAllRates("Y");
                droRate.DataValueField = "RateId1";
                droRate.DataTextField = "RateName1";
                droRate.DataBind();

               
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
              
            }
            
        }

        private void GetAllCustomer()
        {
            try{
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

        private void getAllTaxdetail(string CustomerId)
        {
            try{
                if (CustomerId != "no")
            {
                
                TaxManager tax = new TaxManager();
                gvTax.DataSource = tax.getUserTaxDetails(CustomerId,"Y");
                gvTax.DataBind();
                RateManager Rm = new RateManager();
                gvRate.DataSource = Rm.getCustomerRates(CustomerId,"Y");
                gvRate.DataBind();


               
                
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
        }

        private  void SVATMassage()
        {
            string msg = null;
            msg += "<div class=\"alert alert-dismissable alert-warning\">";
            msg += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            msg += " This is SVAT Customer</div>";

            ErrorMessage.InnerHtml = msg;
        }

        

       

        protected void Edit_Click(object sender, EventArgs e)
        {
         try{   
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
               
              
                txtTaxCode.Text = row.Cells[0].Text;
                txtTaxName.Text = row.Cells[1].Text;
                txtTaxPercentage.Text = row.Cells[2].Text;
                txtRegNo.Text = row.Cells[3].Text;
                mp1.Show();
            
            }
         }
         catch (Exception ex)
         {
             ErrorLog.LogError(ex);

         }
              
          
        }

        protected void Rate_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
                {


                    txtRateId.Text = row.Cells[0].Text;
                    txtRateName.Text = row.Cells[1].Text;
                    txtRateValue1.Text = row.Cells[2].Text;
                   
                    mp3.Show();

                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }


        }

        protected void UpdateRegNo(object sender, EventArgs e)
        {
            try { 
            CustometTaxDetailManager taxmanger = new CustometTaxDetailManager();
            setCustomerTaxDetails taxdata = new setCustomerTaxDetails();
            taxdata.TaxCode1 = txtTaxCode.Text;
            taxdata.CustomerId1 = CustomerId;
            taxdata.TaxRegistrationNo1 = txtRegNo.Text;
            taxdata.IsActive1 = "Y";
            taxmanger.ModifyTaxData(taxdata);
           // Response.Redirect("CustomerTaxAssign.aspx?cus="+CustomerId, false);
                }catch(Exception ex){
                    ErrorLog.LogError(ex);
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Update Prosess Failed.Check Your Inputs</div>";


                    ErrorMessage.InnerHtml = qu;
                }
            getAllTaxdetail(CustomerId);
        }


        protected void UpdateRate(object sender, EventArgs e)
        {
            try
            {
                RateManager Rm = new RateManager();
                Rates Ratedata = new Rates();
                Ratedata.RatesId1 = txtRateId.Text;
                Ratedata.CustomerId1 = CustomerId;
                Ratedata.Rates1 = Convert.ToDecimal(txtRateValue1.Text);
                Rm.ModifyRateData(Ratedata);
               // Response.Redirect("CustomerTaxAssign.aspx?cus=" + CustomerId, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Update Prosess Failed.Check Your Inputs</div>";


                ErrorMessage.InnerHtml = qu;
            }
            getAllTaxdetail(CustomerId);
        }  
    

        protected void AddTax(object sender, EventArgs e)
        {
            try{
            if (CustomerId != null)
            {
               
                    CustometTaxDetailManager taxmanger = new CustometTaxDetailManager();
                    setCustomerTaxDetails taxdata = new setCustomerTaxDetails();

                    taxdata.CustomerId1 = CustomerId;
                    taxdata.TaxCode1 = drpTax.SelectedValue.ToString();
                    taxdata.TaxRegistrationNo1 = txtTaxReg.Text;
                    taxdata.IsActive1 = "Y";
                    bool SvatChecker = true;
                    if (RbtnSVAT.SelectedValue=="1")
                    {
                        string IsvatCode = System.Configuration.ConfigurationManager.AppSettings["VatCode"];
                       if( IsvatCode== drpTax.SelectedValue.ToString()){
                           SvatChecker = false;
                           SVATMassage();
                       }
                    }
                 bool check=true;
                 bool check1 = true;
                 if (SvatChecker)
                 {
                     check = taxmanger.setTaxData(taxdata);

                 }
                 else {
                      check1 = false;
                 }
                    if (check == false)
                    {
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Tax Already Add For this User.</div>";
                        ErrorMessage.InnerHtml = qu;
                    }

                    else
                    {
                        if (check1)
                        {
                            string qu = null;
                            qu += "<div class=\"alert alert-dismissable alert-success\">";
                            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            qu += " Save Success.</div>";
                            ErrorMessage.InnerHtml = qu;
                        }
                        else {
                            string qu = null;
                            qu += "<div class=\"alert alert-dismissable alert-warning\">";
                            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            qu += " Can not add VAT for SVAT Customer</div>";
                            ErrorMessage.InnerHtml = qu;
                        }
                       
                    }
               
            }
            else
            {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Select Customer First.</div>";


                ErrorMessage.InnerHtml = qu;
            }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
            getAllTaxdetail(CustomerId);
        }


        protected void AddRate(object sender, EventArgs e)
        {
            try
            {
                if (CustomerId != null)
                {
                    if (txtRateValue.Text != "")
                    {
                        RateManager taxmanger = new RateManager();
                        Rates taxdata = new Rates();

                        taxdata.CustomerId1 = CustomerId;
                        taxdata.RatesId1 = droRate.SelectedValue.ToString();
                        taxdata.Rates1 = Convert.ToDecimal(txtRateValue.Text);
                        bool check = taxmanger.setCustomerRate(taxdata);
                        if (check == false)
                        {

                            string qu = null;
                            qu += "<div class=\"alert alert-dismissable alert-warning\">";
                            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            qu += " Rate Already Add For this User.</div>";


                            ErrorMessage.InnerHtml = qu;
                        }

                        else
                        {
                            string qu = null;
                            qu += "<div class=\"alert alert-dismissable alert-Success\">";
                            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                            qu += " Save Success.</div>";


                            ErrorMessage.InnerHtml = qu;
                        }
                    }
                    else
                    {
                        string qu = null;
                        qu += "<div class=\"alert alert-dismissable alert-warning\">";
                        qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                        qu += " Add Process Failed. Check Your Inputs.</div>";


                        ErrorMessage.InnerHtml = qu;

                    }
                }
                else
                {
                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-warning\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " Select Customer First.</div>";


                    ErrorMessage.InnerHtml = qu;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }
            getAllTaxdetail(CustomerId);
        }


        protected void Delete_Click(object sender, EventArgs e)
        {
         try{   
            using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
            {
               
              
                lblTaxId.Text = row.Cells[0].Text;
                
                mp4.Show();
            
            }
         }
         catch (Exception ex)
         {
             ErrorLog.LogError(ex);

         }
              
          
        }

        protected void DeleteTax(object sender, EventArgs e)
        {
            try
            {
                CustometTaxDetailManager taxmanger = new CustometTaxDetailManager();
                setCustomerTaxDetails taxdata = new setCustomerTaxDetails();
                taxdata.TaxCode1 = lblTaxId.Text;
                taxdata.CustomerId1 = CustomerId;
                taxdata.TaxRegistrationNo1 = txtRegNo.Text;
                taxdata.IsActive1 = "N";
                taxmanger.ModifyTaxData(taxdata);
               // Response.Redirect("CustomerTaxAssign.aspx?cus=" + CustomerId, false);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += " Update Prosess Failed.Check Your Inputs</div>";


                ErrorMessage.InnerHtml = qu;
            }
            getAllTaxdetail(CustomerId);
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            TaxManager Tm = new TaxManager();
            string CustomerId=drpCustomer.SelectedValue;
            string VATId=System.Configuration.ConfigurationManager.AppSettings["VatCode"];
            string Vat=RbtnSVAT.Text;
         
            bool check=Tm.ModifySVATData(Vat, VATId, CustomerId);
            if (check) {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-success\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "Success Fully Saved</div>";


                ErrorMessage.InnerHtml = qu;
            }
            else {
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "This Customer Had VAT</div>";


                ErrorMessage.InnerHtml = qu;
            }
            
        }

        protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cus = Request.QueryString["cus"];
            if (cus == null && drpCustomer.SelectedValue == "no")
            {
                divcontent.Visible = false;
            }
            else
            {
                CustomerId = drpCustomer.SelectedValue;
                TaxManager tax = new TaxManager();
                getTaxDetails details = tax.getCustometSVAT(CustomerId);
                SVAT = details.SVAt1;
                getAllTaxdetail(CustomerId);
               
                
                    if (SVAT == "1")
                    {

                        RbtnSVAT.SelectedValue = SVAT;
                        SVATMassage();

                    }
                    else
                    {
                        RbtnSVAT.SelectedValue = SVAT;
                    }
                }

            

        }  
    }
}