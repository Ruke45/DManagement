<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CustomerStatementReport.aspx.cs" Inherits="DSCMS.Views.Report.CustomerStatementReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Statement Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Reports</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-flag "></i> Customer Statement Report
                    </li>
                </ol>
            </div>
        </div>
        <div class="row" runat="server" id="ErrorMessage" style="font-family: Cambria;">
        </div>
        <div class="col-md-12">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                    <div class="row" style ="color:#000;">
                        <div class="col col-lg-12 form-inline">
                            <div class="form-group">
                                <div class="form-group">
                                    <label class="control-label" for="email">From : </label>
                                    <asp:TextBox ID="txtDate" class="form-control" runat="server" required=""></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                        CssClass="cal_Theme1"
                                        TargetControlID="txtDate"
                                        format="yyyy/MM/dd"
                                        PopupButtonID="Image1" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label" for="email">To : </label>
                                    <asp:TextBox ID="txtToDate" class="form-control" runat="server" required=""></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                        CssClass="cal_Theme1"
                                        TargetControlID="txtToDate"
                                        format="yyyy/MM/dd"
                                        PopupButtonID="Image1" />
                                </div>

                                <div class="form-group">
                                    <label class="control-label" runat="server" id="lblCustomer" for="email">Customer : </label>
                                    <asp:DropDownList ID="drpCustomer" AppendDataBoundItems="true" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="%">All Customers</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label class="control-label" runat="server" id="lblMember" for="email">NCE Member : </label>
                                    <asp:DropDownList ID="drpNCEMember" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="%">All</asp:ListItem>
                                        <asp:ListItem Value="Yes">YES</asp:ListItem>
                                        <asp:ListItem Value="No">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                 <div class="form-group">
                                    <label class="control-label" runat="server" id="lblPaytype" for="email">Payment Type : </label>
                                    <asp:DropDownList ID="drpPaytype" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="%">All</asp:ListItem>
                                        <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                        <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                    </asp:DropDownList>
                                </div>



                                <%--<div class="checkbox">
                                    <label>
                                        <input type="checkbox">
                                        Remember me</label>
                                </div>--%>
                                <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn btn-primary" OnClick="btnReport_Click" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="panel-body">

                    <rsweb:ReportViewer ID="ReportViewer1"  runat="server" Font-Names="Verdana" Font-Size="10pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BorderStyle="None" Width="100%" Height="710px" DocumentMapWidth="100%"></rsweb:ReportViewer> <%--ZoomMode="FullPage" SizeToReportContent="true"--%>
                </div>
            </div>
        </div>
        </div>

</asp:Content>
