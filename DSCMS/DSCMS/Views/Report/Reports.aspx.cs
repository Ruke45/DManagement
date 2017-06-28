using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CertificateManagement;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.CustomerRequestManagement;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Report
{
    public partial class Reports : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
            content.Visible = false;
            FirstPageLoad();
            if (!IsPostBack) {
                txtFromDate.Text = DateTime.Today.ToShortDateString();
                txtTodate.Text = DateTime.Today.ToShortDateString();
                getDetail();
            }

        }

        private void FirstPageLoad()
        {
            try
            {
               
                if (!IsPostBack)
                {
                    CustomerDetailManager cm = new CustomerDetailManager();

                    drpCustomer.DataSource = cm.getAllCustomer("Y");
                    
                    drpCustomer.DataValueField = "CustomerId1";
                    drpCustomer.DataTextField = "CustomerName1";
                    drpCustomer.DataBind();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);

            }

        }




        protected void Find_Click(object sender, EventArgs e)
        {
            getDetail();
            
        }

        private void getDetail()
        {
            try
            {
                string CustomerId = drpCustomer.SelectedValue;
                if (CustomerId == "All")
                {
                    CustomerId = "%";
                }
                string Todate = txtTodate.Text;
                string Fromdate = txtFromDate.Text;
                bool sort = cbSorting.Checked;
                string Sorting = null;
                if (sort == true)
                {
                    Sorting = "ASC";
                }
                else
                {
                    Sorting = "DESC";
                }
                string Status = "A";
                if (Todate != "" && Fromdate != "")
                {
                    DateTime StartDate = Convert.ToDateTime(Fromdate);
                    DateTime EndDate = Convert.ToDateTime(Todate);
                    string Start = StartDate.ToString("yyyyMMdd");
                    string End = EndDate.ToString("yyyyMMdd");
                    CertificateManager CM = new CertificateManager();
                    CertificateRequestManager CRM = new CertificateRequestManager();
                   
                    string customerName=drpCustomer.SelectedItem.ToString();
                    string divID = null;
                    int ok = 0;
                    lblcusname.Text = customerName;
                    lblFrom.Text = Fromdate;
                    lblTo.Text = Todate;
                    foreach (var data in CM.getReportDetails(CustomerId, Status, Sorting, Start, End))
                    {
                        //--creadted date package typr

                        string CertificateId = data.CertificateId1;
                        string NCEMember = data.NECMember1;
                        string PortOfDischarge = data.PortOfDischarge1;
                        string InvoiceNo = data.InvoiceNo1;
                        string Consignee = data.Consignee1;
                        string CreatedBy = data.CreatedBy1;
                        string PaidType = data.PaidType1;
                        string TotalInvoiceValue = data.TotalInvoiceValue1;
                        string CustomerName = data.CustomerName1;
                        string requestId = data.RequestId1;
                        string requestDate = data.RequestDate1.ToShortDateString();
                        string createdDate = data.CreatedDate1.ToShortDateString();

                        divID += "<tr><td>" + CertificateId + "</td>";
                        divID += "<td>" + NCEMember + "</td>";
                      //  divID += "<td>" + PortOfDischarge + "</td>";
                        divID += "<td>" + InvoiceNo + "</td>";
                        //divID += "<td>" + Consignee + "</td>";
                        divID += "<td>" + CreatedBy + "</td>";
                        //divID += "<td>" + PaidType + "</td>";
                        divID += "<td>" + TotalInvoiceValue + "</td>";
                        divID += "<td>" + CustomerName + "</td>";
                        divID += "<td>" + requestDate + "</td>";
                        divID += "<td>" + createdDate + "</td>";
                       // divID += "<td>";

                        //foreach (var type in CRM.getReqDetailByReqID(requestId, true))
                        //{
                        //    string PackageDescription = type.GoodItem1;
                        //    divID += PackageDescription + "<br>";
                        //}

                         divID += "<td>";

                         foreach (var doc in CM.getSuportingDocumentForCertificate(Status, requestId))
                        {
                            string SupDoc = doc.SuportingDocName1;
                            divID += SupDoc + "<br>";
                        }
                        divID += "</tr>";
                        head.InnerHtml = divID;
                        ok = 1;
                    }
                    if (ok == 0)
                    {

                        divID = null;
                        head.InnerHtml = divID;
                    }
                    else
                    {
                        content.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
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
                bool auth = Am.IsUserGroupAuthorised(groupId, "CetHis");
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

    }
}