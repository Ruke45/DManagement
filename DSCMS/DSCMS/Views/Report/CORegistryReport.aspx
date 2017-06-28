<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CORegistryReport.aspx.cs" Inherits="DSCMS.Views.Report.CORegistryReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | CO Registry Report
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
                        <i class="fa fa-flag "></i> NCE DCO Registry Report
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
                                <label class="control-label" for="email">From : </label>
                                    <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" required=""></asp:TextBox>
                                    <cc1:calendarextender id="CalendarExtender1" runat="server"
                                        cssclass="cal_Theme1"
                                        targetcontrolid="txtDate"
                                        format="yyyy/MM/dd"
                                        popupbuttonid="Image1" />
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="email">To : </label>
                                    <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server" required=""></asp:TextBox>
                                    <cc1:calendarextender id="CalendarExtender2" runat="server"
                                        cssclass="cal_Theme1"
                                        targetcontrolid="txtToDate"
                                        format="yyyy/MM/dd"
                                        popupbuttonid="Image1" />
                                    <asp:Button ID="Button1" runat="server" Text="Report"  CssClass="btn btn-primary" OnClick="btnReport_Click" />
                            </div>
                            </div>
                    </div>
                </div>
                <div class="panel-body">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="10pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BorderStyle="None" Width="100%" Height="720px" DocumentMapWidth="100%"></rsweb:ReportViewer>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="form-group text-right">
                                <div class="col-sm-12">
                                    <%--<asp:Button ID="btnBulkSign" runat="server" Text="Approve/Sign Certificates" CssClass="btn btn-primary" OnClick="btnBulkSign_Click" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
