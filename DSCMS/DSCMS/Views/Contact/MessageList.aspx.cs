using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.ContactManager;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS.Views.Contact
{
   
    public partial class MassageList : System.Web.UI.Page
    {
        UserSession userSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSession = new UserSession();
            CheckAutentication();
            popup.Visible = false;
            if (!IsPostBack) {
            
            string status=DropDownList1.SelectedValue = "N";
            ContactFormManger CF = new ContactFormManger();
            gvmassage.DataSource = CF.getAllNewMassage(status);
            gvmassage.DataBind();
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
                bool auth = Am.IsUserGroupAuthorised(groupId, "msg");
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

        protected void Find_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null);
            DateTime EndDate = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null);
            string start1 = StartDate.ToString("yyyyMMdd");
            string End1 = EndDate.ToString("yyyyMMdd");
            string drpvalue = DropDownList1.SelectedValue.ToString();
            if (drpvalue == "All") {
                drpvalue = "%";
            }
            databinding(start1, End1, drpvalue);
        }

        private void databinding(string start1, string End1, string drpvalue)
        {
            try
            {
                ContactFormManger CF = new ContactFormManger();
                gvmassage.DataSource = CF.getAllMassage(start1, End1, drpvalue);
                gvmassage.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
            }
        }

        protected void gvmassage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Label seqId = (Label)gvmassage.SelectedRow.Cells[4].FindControl("seq");
                ContactFormManger CF = new ContactFormManger();
                CF.ModifyMassageViewStatus(seqId.Text,"Y");
                popup.Visible = true;
                txtName.Text = gvmassage.SelectedRow.Cells[0].Text;
                txtEmail.Text = gvmassage.SelectedRow.Cells[1].Text;
                txtPhone.Text = gvmassage.SelectedRow.Cells[2].Text;
               
                Label Detail = (Label)gvmassage.SelectedRow.Cells[3].FindControl("detail");

                TextArea1.InnerText = Detail.Text;
                DateTime StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null);
                DateTime EndDate = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null);
                string start1 = StartDate.ToString("yyyyMMdd");
                string End1 = EndDate.ToString("yyyyMMdd");
                string drpvalue = DropDownList1.SelectedValue.ToString();
                if (drpvalue == "All")
                {
                    drpvalue = "%";
                }
                databinding(start1, End1, drpvalue);
            }
            catch (Exception ex) {
                ErrorLog.LogError(ex);
            }
        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null).ToString("yyyyMMdd");
                string EndDate = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null).ToString("yyyyMMdd");
                string drpvalue = DropDownList1.SelectedValue.ToString();
                if (drpvalue == "All") {
                    drpvalue = "%";
                }
                gvmassage.PageIndex = e.NewPageIndex;
                databinding(StartDate, EndDate,drpvalue);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(ex);
                
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            popup.Visible = false;
            string StartDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null).ToString("yyyyMMdd");
            string EndDate = DateTime.ParseExact(txtTodate.Text, "dd/MM/yyyy", null).ToString("yyyyMMdd");
            string drpvalue = DropDownList1.SelectedValue.ToString();
            if (drpvalue == "All")
            {
                drpvalue = "%";
            }
           
            databinding(StartDate, EndDate, drpvalue);
        }
    }
}