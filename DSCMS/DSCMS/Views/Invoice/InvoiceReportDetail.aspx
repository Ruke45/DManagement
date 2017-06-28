<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InvoiceReportDetail.aspx.cs" Inherits="DSCMS.Views.Invoice.InvoiceReportDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Invoice Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Invoice</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Monthy Bill Details Report
                    </li>
                </ol>
            </div>
        </div>
    </div>
    <div class="container ">
        <div class="row">
            <div class="col-lg-10 " style="font-family: Cambria;">

                <table class="table table-bordered boxshadow">
                    <tbody>
                        <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Customer Name </td>
                            <td style="height: 31px" colspan="3">
                                <div style="float:right">
                                <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Customer ID</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float:right">
                                <asp:Label ID="lblCustomerId" runat="server" Text=""></asp:Label>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Invoice Number</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float:right">
                                <asp:Label ID="lblInvoiceNo" runat="server" Text=""></asp:Label>
                                    </div>
                            </td>
                        </tr>

                    </tbody>
                </table>
                <table class="table table-bordered boxshadow">
                    <tbody>
                        <tr>

                            <td>
                                <center><asp:Label ID="lblInvoiceName" runat="server" Text=""></asp:Label></center>
                            </td>

                        </tr>
                    </tbody>
                </table>
                <asp:GridView ID="gvInvoicedetails" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <span>
                                    <%#Container.DataItemIndex + 1%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="RequestNo1" DataField="RequestNo1" SortExpression="RequestNo1" />
                        <asp:BoundField HeaderText="UnitCharge1" DataField="UnitCharge1" SortExpression="UnitCharge1" />
                    </Columns>
                </asp:GridView>

                <table class="table table-bordered boxshadow">
                    <tbody>

                        <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Gross Total</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float:right">
                                <asp:Label ID="lblGrossTotal" runat="server" Text=""></asp:Label>
                                    </div>
                            </td>
                        </tr>
                        <div id="head" runat="server"></div>
                        <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Total</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float:right">
                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                                    </div>
                            </td>
                        </tr>
                        
                    </tbody>
                </table>
            </div>

            <div class="col-lg-2" style="font-family: Cambria;">
                <!-- <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Approve"  />
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger btn-block" Text="Reject" /> <br />-->
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning btn-block" Text="<< Go Back" OnClick="Button2_Click" />
            </div>
        </div>
    </div>
</asp:Content>
