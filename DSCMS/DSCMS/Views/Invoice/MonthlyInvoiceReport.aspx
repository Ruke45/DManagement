<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MonthlyInvoiceReport.aspx.cs" Inherits="DSCMS.MonthlyInvoiceReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Invoice Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
        #cal1 {
        display:none;
        position:absolute;
        background-color:white;
        }
         #cal2 {
        display:none;
        position:absolute;
        background-color:white;
        }
    </style>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
    <div id="cal11" style="width: 30px; height: 40px; background-color: red; display: none"></div>
    <div class="col-lg-12" style="min-height: 500px">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Invoice</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Monthly Invoice Report
                    </li>
                </ol>
            </div>
        </div>
       

        <div class="col-md-10 col-md-offset-1">
           





               <div class="row">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-3">
                       
                                    <asp:TextBox  CssClass="form-control" ID="txtFromDate" runat="server"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy"
                                PopupButtonID="Image1" />
                      
                        <div class="col-ms-3" style="width: 150px">
                            <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div><div>
                             <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" Font-Size="Small" />
                                    </div>
                        </div>
                    </div>

                          
                    <label class="control-label col-md-2" for="email">To Date </label>

                    <div class="col-md-3">
                       
                                    <asp:TextBox ID="txtTodate"  CssClass="form-control" runat="server"></asp:TextBox>
                                  <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="dd/MM/yyyy"
                                PopupButtonID="Image1" />
                      
                      
                        <div class="col-ms-3" style="width: 150px">
                            <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                             </div>
                                <div>
                                <asp:Label ID="labdatevalidation" runat="server" Visible="false" Font-Size="Small" ForeColor="Red" />
                                    </div>

                        </div>
                    </div>
                   
               
                        </div>
        </div>

                <div class="row" style="padding-bottom:10px">
                     <div class="group" >
                               <label class="control-label col-md-2" runat="server" id="lblcusid"> Customer Name</label>
                      <div class="col-md-5">
                                <asp:DropDownList ID="drpCustomer" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="%">All</asp:ListItem>
                                    
                                </asp:DropDownList>
                          </div>

                       
                          <div class="col-md-3" >
                        <asp:Button ID="Find" runat="server" Width="100%" Text="Find" CssClass="btn btn-primary" OnClick="Button1_Click" />
                             </div>
                      </div>
                </div>
            
              
                     <div class="row">
                    <div class="group">
                         <div class="col-md-8"></div>
                        
                    </div>
                         </div>
            <div style="height: 20px"></div>
            <div class="panel panel-default panel-table" style="min-width:700px">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                          
                        </div>
                        <div class="col col-xs-5 text-right" style="float: right">
                        
                        </div>
                        <div class="col col-xs-2 text-right">
                        </div>
                    </div>
                </div>

                <div class="panel-body" id="grid">
                    <style>
                .line {
                    text-align:right;
                }
            </style>
                    <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  
                        table-hover table-list-search" AllowPaging="True" PageSize="10" OnSelectedIndexChanged="gvInvoice_SelectedIndexChanged"
                        OnPageIndexChanging="grdData_PageIndexChanging" >
                        <Columns>
                            <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo1" SortExpression="InvoiceNo1" />
                            <asp:BoundField HeaderText="Customer Id" DataField="CustomerId1" SortExpression="CustomerId1" />
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="CustomerName1" />
                            <asp:BoundField HeaderText="From" DataField="sFromDate1" SortExpression="sFromDate1" />
                            <asp:BoundField HeaderText="TO" DataField="sToDate1" SortExpression="sToDate1" />
                            <asp:BoundField HeaderText="Approved Date" DataField="sCreatedDate1" SortExpression="sCreatedDate1" />
                            <asp:BoundField HeaderText="Invoice Total" DataField="sInvoiceTotal1" ItemStyle-CssClass="line" SortExpression="sInvoiceTotal1" />
                            <asp:ButtonField CommandName="select" ControlStyle-CssClass="btn btn-info btn-sm" HeaderText="View Details" Text="View"></asp:ButtonField>
                        </Columns>
                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                    <table>
                        <tr>
                            <td style="width:75%"></td>
                            <td style="padding:5px"><label>Total Value</label></td>
                            <td style="padding:5px;text-align:right;width:150px"><asp:Label ID="lblTotalCount" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
