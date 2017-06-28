using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.MasterMaintainance;
using DCISDBManager.trnLib.MasterMaintenance;
using System.Reflection;
using DCISDBManager.trnLib.UserManagement;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib.CheckAuth;

namespace DSCMS.Views.Maintenance
{
    public partial class CertificateReminders : System.Web.UI.Page
    {
        SignatureLevelManagement sgl = new SignatureLevelManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = sgl.getSignatureLevels("%", "%", "y");
            GridView1.DataBind();



        }
        protected void GridView1_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
              
              
              }

         

              protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
              
              
              }
    }
}