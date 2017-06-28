using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Drawing;
using DCISDBManager.objLib.Usr;
using DCISDBManager.trnLib;
using DCISDBManager.trnLib.UserManagement;
using System.Reflection;
using DCISDBManager.trnLib.CheckAuth;
using DCISDBManager.trnLib.EmailManager;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.objLib.MasterMaintenance;

namespace DSCMS.Views.Maintenance
{
     
    public partial class OwnerDetailentry : System.Web.UI.Page
    {
        OwnerDetailManagement odm = new OwnerDetailManagement();
        UserManager um = new UserManager();
        CertficateRequestDataManagement crm = new CertficateRequestDataManagement();
        UserGroupManager ugm = new UserGroupManager();
        UserSession session;
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!Page.IsPostBack)
            {
                loads();
            
                databind();
            }
            session = new UserSession();
            if (session.User_Id == "")
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
            string groupId = session.User_Group;
            CheckAuthManager Am = new CheckAuthManager();
            bool auth = Am.IsUserGroupAuthorised(groupId, "adu");
            if (auth == false)
            {
                Response.Redirect("~/Views/Home/Login.aspx");
            }
           

        }

        protected void databind()
        {
            DCISDBManager.objLib.Usr.UserGroup ddlistUser = new DCISDBManager.objLib.Usr.UserGroup();

          




        }


        void loads() {


            OwnerDetailsobj a = new OwnerDetailsobj();
           // string owner = ddUserGroup.SelectedValue;
            string owner = "2";



            var asd = odm.getOwnerDetails(owner);

            //AuthorizedName.InnerText = ": Sam Smith ";
            //PhoneNo.InnerText = "0225487856";
            //email.InnerText = "samsmith@nce.lk ";
            //Logo.Attributes["src"] = ResolveUrl("~/img/NCE_Home_logo.png");
            string address = "";

            foreach (var data in odm.getOwnerDetails(owner))
            {
                txtCompanyName.Text = data.company_;
                PersonName.Text = data.Name_;
                txtAdrs1.Text = data.Address1_;
                txtaddr2.Text = data.Address2_;
                txtaddr3.Text = data.Address_3;
                txtemail.Text = data.Email_;
                txttelno.Text = data.Telephone_No;






            }

        
        
        
        
        
        
        
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
              

            OwnerDetailsobj a = new OwnerDetailsobj();
            string owner = ddUserGroup.SelectedValue;



            var asd = odm.getOwnerDetails(owner);

           //AuthorizedName.InnerText = ": Sam Smith ";
           //PhoneNo.InnerText = "0225487856";
           //email.InnerText = "samsmith@nce.lk ";
           //Logo.Attributes["src"] = ResolveUrl("~/img/NCE_Home_logo.png");
           string address = "";

           foreach (var data in odm.getOwnerDetails(owner))
           {
               txtCompanyName.Text = data.company_;
               PersonName.Text = data.Name_;
               txtAdrs1.Text = data.Address1_;
               txtaddr2.Text = data.Address2_;
               txtaddr3.Text = data.Address_3;
               txtemail.Text = data.Email_;
               txttelno.Text = data.Telephone_No;

           
           
           
           
           
           }





        
        
        
        
        }








        protected void Button1_Click1(object sender, EventArgs e)
        {

            try
            {

                OwnerDetailsobj odo = new OwnerDetailsobj();

                odo.company_ = txtCompanyName.Text;

               // odo.id_ = ddUserGroup.SelectedValue;
                odo.id_ = "2";
                odo.Address1_=txtAdrs1.Text;
                odo.Address2_=txtaddr2.Text;
                   odo.Address_3=txtaddr3.Text;
                    odo.Telephone_No=txttelno.Text;
                    odo.Email_ = txtemail.Text;
                
                
                odo.Name_ = PersonName.Text;
                odo.Telephone_No = txttelno.Text;

                odm.ModifyOwner(odo);
                
               

                    string qu = null;
                    qu += "<div class=\"alert alert-dismissable alert-success\">";
                    qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
                    qu += " <strong> Changes Saved !!!</strong></div>";
                    qu += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-hidden=\"true\">&times;</button>";

                    ErrorMessage.InnerHtml = qu;


                   
                    PersonName.Text = null;
                    ddUserGroup.SelectedValue = "";


                    //  Response.Redirect("AddUser.aspx?show=1", false);
                    lblSuccess.Visible = true;
                
              

            }
            catch (Exception es)
            {


                System.Console.Error.Write(es.Message);

            }

        }


    }
}