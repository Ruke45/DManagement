<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="DSCMS.Views.Home.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div style="margin-top: 130px">
    	  <div class="">
				<div class="loginmodal-container">
					<h1>Member Login</h1><br/>
				  <div>
                      <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" required=""></asp:TextBox>
                      <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required=""></asp:TextBox>
                      <asp:Button ID="btnUserLogin" runat="server" Text="Login" CssClass="login loginmodal-submit" OnClick="btnUserLogin_Click" />
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
         <div class="row">
            <div style="text-align:center">
            <asp:HyperLink ID="link1" runat="server"  NavigateUrl="~/Views/Home/EnterEmailAdress.aspx"> Forgot your password?</asp:HyperLink>

                </div>
            </div>

        </div>
</asp:Content>
