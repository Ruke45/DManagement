<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DSCMS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div style="margin-top: 130px">
    	  <div class="">
				<div class="loginmodal-container">
					<h1>Login to Your Account</h1><br>
				  <div>
                      <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" required=""></asp:TextBox>
                      <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required=""></asp:TextBox>
                      <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login loginmodal-submit" OnClick="btnLogin_Click" />
				  </div>
					
				  <div class="login-help">
					<a href="#">Register</a>
				  </div>
				</div>
			</div>
		  </div><br />
           
    <div class="container">
             <div class="row">
                   <div class="col-sm-6 col-sm-offset-3 social-login" id="ErrorMessage" runat="server">
                     <div class="alert alert-dismissable alert-danger">
						<strong>Login Failed ! </strong>User Name or Password is incorrect try submitting again.
						<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
					</div>
            </div>
            </div>
        </div>
</asp:Content>
