using DCISDBManager.objLib.MasterMaintenance;
using DCISDBManager.trnLib.MasterMaintenance;
using DCISDBManager.trnLib.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Details();
        

        }

        void Details() {
            try
            {
                OwnerDetailManagement odm = new OwnerDetailManagement();

                OwnerDetailsobj a = new OwnerDetailsobj();



                var asd = odm.getOwnerDetails("2");

                //AuthorizedName.InnerText = ": Sam Smith ";
                //PhoneNo.InnerText = "0225487856";
                //email.InnerText = "samsmith@nce.lk ";
                //Logo.Attributes["src"] = ResolveUrl("~/img/NCE_Home_logo.png");
                string address = "";

                foreach (var data in odm.getOwnerDetails("2"))
                {

                    AuthorizedName.InnerText = ": " + data.Name_;
                    PhoneNo.InnerText = data.Telephone_No;
                    email.InnerText = data.Email_;


                    string addresss = data.Image_Urls;

                    Logo.Attributes["src"] = ResolveUrl(addresss);






                }










            }
        catch(Exception Ex){
            ErrorLog.LogError(Ex);
        }

        }

    }
}