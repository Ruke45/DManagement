<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="DSCMS.Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Approval
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .hidden {
            display: none;
        }
    </style>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Customer</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Customer Request Approval
                    </li>
                </ol>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
             <div class="container col-lg-12" runat="server" visible="false"  id="divSendMailQue" style="font-family: Cambria;">
                <div class="col-lg-8"></div>
            <div class="col-md-4" style="height:66px;">
                 
                    
               
                <div style="float:right">
                <asp:Button ID="Sendmail" runat="server" CssClass="btn btn-primary" Text="Send Confirmation" OnClick="Sendmail_Click" />
                <br /><lable>Confirmation Pending: </lable><asp:Label ID="lblEmailCount" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-10 col-md-offset-1">

            <div class="panel panel-default panel-table">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                            <h3 class="panel-title"></h3>

                        </div>
                        <div class="col col-xs-3 text-right" style="float: right">
                            

                        </div>
                        <div class="col col-xs-2 text-right">
                        </div>

                    </div>
                </div>

                <div class="panel-body">
                   
                    <asp:GridView ID="gvExpoter" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search" 
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdData_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Request Id" DataField="RequestId1" SortExpression="RequestId1" />
                            <asp:BoundField HeaderText="Expoter Name" DataField="Name1" SortExpression="Name1" />
                            <asp:BoundField HeaderText="Telephone No" DataField="Telephone1" SortExpression="Telephone1" />
                            <asp:BoundField HeaderText="Email" DataField="Email1" SortExpression="Email1" />
                            <asp:BoundField HeaderText="Address1" DataField="Address11" SortExpression="Address11" />
                            <asp:BoundField HeaderText="Address2" DataField="Address21" SortExpression="Address21" />
                            <asp:BoundField HeaderText="Address3" DataField="Address31" SortExpression="Address31" />
                            <asp:BoundField HeaderText="Admin User Name" DataField="AdminUserId1" SortExpression="AdminUserId1" />
                            <%-- <asp:BoundField HeaderText="" ItemStyle-CssClass="hidden" DataField="AdminPassword1" SortExpression="AdminPassword1"  />--%>
                            <asp:ButtonField CommandName="select" ControlStyle-CssClass="btn btn-info btn-sm" HeaderText="View Details" Text="View"></asp:ButtonField>
                        </Columns>
                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
