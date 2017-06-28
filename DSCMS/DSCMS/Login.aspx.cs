using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSCMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string qu = null;
            qu += "<div class=\"alert alert-danger\">";
            qu += " <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>";
            qu += " <strong>Login Faild ! </strong> Login Faild !</div>";

            ErrorMessage.InnerHtml = qu;
        }
    }
}