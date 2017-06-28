<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CustomerFinanceData.aspx.cs" Inherits="DSCMS.Views.Customer.CustomerFinanceData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Invoicing Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Customer</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Invoicing Details
                    </li>
                </ol>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;padding:10px">
                <%--Error Msg goes here--%>
                <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                <br />
            </div>
        </div>

        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
                <div class="panel-heading">
                </div>

                <div class="panel-body">

                    <div class="col-lg-11">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Payment Method</label>
                                <div class="col-sm-2">
                                    <asp:RadioButtonList ID="RbtnPaidType" runat="server">
                                        <asp:ListItem Value="cash">Cash</asp:ListItem>
                                        <asp:ListItem Value="credit">Credit</asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                <div class="col-sm-3">
                                    <asp:RequiredFieldValidator ID="cvPaidType" runat="server" ControlToValidate="RbtnPaidType" ErrorMessage="Paid Type is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lblMemberMassage" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:GridView ID="gvfinance" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search">
                        <Columns>

                            <asp:BoundField HeaderText="Document Type Id" DataField="RateId1" SortExpression="RateId1" />
                            <asp:BoundField HeaderText="Document Type Name" DataField="RateName1" SortExpression="RateName1" />
                            <asp:TemplateField HeaderText="Value" >
                                <ItemTemplate>
                                    <asp:TextBox ID="txtValue" runat="server" Text='<%# Eval("StringRateValue1") %>' ></asp:TextBox>
                                    <asp:CompareValidator ID="cvRegistrationNo" runat="server"  ControlToValidate="txtValue" Type="Currency" Operator="DataTypeCheck" ErrorMessage="   Invalid Value." ForeColor="Red" />
                                    <asp:RequiredFieldValidator ID="cvtxtValue" runat="server" ControlToValidate="txtValue" ErrorMessage=" Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                                </ItemTemplate>

                            </asp:TemplateField>


                        </Columns>
                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col col-xs-4">
                            </div>
                            <div class="col col-xs-8">
                                <div style="float: right">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" />

                                </div>
                            </div>
                        </div>
                    </div>

                </div>



            </div>

        </div>

        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-9">
            </div>
        </div>

    </div>











</asp:Content>
