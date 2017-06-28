using DCISDBManager.objLib.CustomerRequest;
using DCISDBManager.objLib.TaxDetails;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.TaxManagement;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DSCMS
{
    public partial class TaxRegistration : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            UserAutentication();
            ErrorMessage1.Visible = false;
          
            TaxManager tax = new TaxManager();
            string Isvat = "0";
            
            if (!IsPostBack)
            {
                gvTaxRegistration.DataSource = tax.getTaxDetails("Y", Isvat);
                gvTaxRegistration.DataBind();
            }
           

        }



        private void UserAutentication()
        {
            string Access = System.Configuration.ConfigurationManager.AppSettings["UserGroupID_Admin"];
            if (userSession.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = userSession.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "CuApp");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Forbidden.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string TaxCode = String.Empty;
            string svatCode = System.Configuration.ConfigurationManager.AppSettings["VatCode"];
            bool checkSvat = false;
            bool chkSvat = false;
            chkSvat=cbSVat.Checked;
            foreach (GridViewRow row in gvTaxRegistration.Rows)
            {
                
                TaxCode = row.Cells[0].Text;

                if (TaxCode == svatCode && chkSvat)
                {
                     var checktbox = row.FindControl("chk") as CheckBox;
                     if (checktbox != null && checktbox.Checked)
                     {
                         checkSvat = true;
                     }
                }
            }
            if (checkSvat==false)
            {
                string reqe = Request.QueryString["uid"];
                string CustomerID = reqe;

                TextBox RegistrationNo = null;
                string Isvat = System.Configuration.ConfigurationManager.AppSettings["VatCode"];
                foreach (GridViewRow row in gvTaxRegistration.Rows)
                {

                    TaxCode = row.Cells[0].Text;

                    RegistrationNo = row.FindControl("RegistrationNo") as TextBox;
                    if (Isvat != TaxCode)
                    {
                        var checktbox = row.FindControl("chk") as CheckBox;
                        if (checktbox != null && checktbox.Checked)
                        {
                            try
                            {
                                String regNo = RegistrationNo.Text;
                                CustometTaxDetailManager taxmanger = new CustometTaxDetailManager();
                                setCustomerTaxDetails taxdata = new setCustomerTaxDetails();

                                taxdata.CustomerId1 = CustomerID;
                                taxdata.TaxCode1 = TaxCode;
                                taxdata.TaxRegistrationNo1 = regNo;
                                taxdata.CreatedBy1 = userSession.User_Id;
                                taxdata.IsActive1 = "Y";



                                taxmanger.setTaxData(taxdata).ToString();
                            }

                            catch (Exception ex)
                            {
                                ErrorLog.LogError(ex);
                            }
                        }
                    }

                }
                String svat = cbSVat.Text.ToString();
                try
                {
                    if (svat != null)
                    {
                        CustomerDetailManager taxmanger = new CustomerDetailManager();
                        CustomerDetails taxdata = new CustomerDetails();

                        taxdata.CustomerId1 = CustomerID;
                        taxdata.IsSVat1 = "1";

                        taxmanger.setIsVat(taxdata).ToString();

                    }
                    Response.Redirect("CustomerEditList.aspx");
                }
                catch (Exception ex)
                {
                    ErrorLog.LogError(ex);
                }
            }

            else
            {
                ErrorMessage1.Visible = true;
                string qu = null;
                qu += "<div class=\"alert alert-dismissable alert-warning\">";
                qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                qu += "VAT cannot be applied to SVAT customer</div>";


                ErrorMessage1.InnerHtml = qu;
            }



        }

    }
   
    
}