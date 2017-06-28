<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EnterEmailAdress.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.Views.Home.EnterEmailAdress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-lg-12" runat="server" id="Div1" style="font-family: Cambria;">

            <div style="margin-top: 130px">
    	  <div class="">
				<div class="loginmodal-container">
					<h1>Password Reset</h1><br/>
				  <div>
                      <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" required=""></asp:TextBox>
                      <%--<asp:TextBox ID="txtPassword" runat="server"  placeholder="Password" TextMode="Password" required=""></asp:TextBox>--%>
                      <asp:Button ID="btnLogin" runat="server" Text="Send" CssClass="login loginmodal-submit" OnClick="btnLogin_Click" />
				  </div>
				</div>
			</div>
		  </div><br />


           
    <div class="container">
             <div class="row">
                   <div class="col-sm-6 col-sm-offset-3 social-login" id="ErrorMessage" runat="server" style="text-align:center">
                     <%--<div class="alert alert-dismissable alert-danger">
						<strong>Login Failed ! </strong>User Name or Password is incorrect try submitting again.
						<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
					</div>--%>
            </div>
            </div>

       

        </div>
        </div>
</asp:Content>

