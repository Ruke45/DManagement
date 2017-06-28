<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Alerts.aspx.cs" Inherits="DSCMS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Alerts
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4>Alerts</h4>
					<p class="mb20">Provide contextual feedback messages for typical user actions with the handful of available and flexible alert messages</p>
					<div class="alert alert-dismissable alert-success">
						<strong>Well done!</strong> You successfully read this important alert message.
						<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
					</div>
					<div class="alert alert-dismissable alert-info">
						<strong>Heads up!</strong> This alert needs your attention, but it's not super important.
						<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
					</div>
					<div class="alert alert-dismissable alert-warning">
						<strong>Warning!</strong> Best check yo self, you're not looking too good.
						<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
					</div>
					<div class="alert alert-dismissable alert-danger">
						<strong>Oh snap!</strong> Change a few things up and try submitting again.
						<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
					</div>
















</asp:Content>
