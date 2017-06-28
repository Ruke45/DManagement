<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CustomerEditList.aspx.cs" Inherits="DSCMS.Views.Customer.CustomerEditList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Edit List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
        <script>
            function PrintPage() {

                document.getElementById("hideDiv").style.display = "none";
                document.getElementById("printdiv").style.display = "block";
                window.print();
                document.getElementById("hideDiv").style.display = "block";
                document.getElementById("printdiv").style.display = "none";
            }
</script>
     <script type=application/javascript>document.links[0].href = "data:text/html;charset=utf-8," + encodeURIComponent('<!doctype html>' + document.documentElement.outerHTML)</script>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style>
            @media print {
       
         #printdiv {
            visibility:visible;
         }
      
         @page {
    size: auto;   /* auto is the initial value */
    margin: 0;  /* this affects the margin in the printer settings */
    size:landscape;
}
     }
           
    </style>
     <div id="hideDiv">
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Customer</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Edit/View Customer Details
                    </li>
                </ol>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
           

        <div class="col-md-10 col-md-offset-1">

            <div class="panel panel-default panel-table">
                
              
                <div class="panel-heading">
                    <div class="row">
                        <div class="col col-xs-7">
                            <h3 class="panel-title"></h3>
                          
                        </div>
                        <div class="col col-lg-5 text-right" style="float: right">
                             
                                <div class="row">
                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                             <div class="group">
                                 <div class="col-md-5">
                                    <label class="control-label">Customer Name</label>
                                     </div>
                                 <div class="col-md-7">
                                    <asp:DropDownList ID="drpCustomer" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true">
                                       <asp:ListItem Text="All" Value="%" />
                                    </asp:DropDownList>
                                    </div>
                                 </div>
                                </div>
                          

                        </div>
                        <div class="col col-xs-2 text-right">
                            
                        </div>

                    </div>
                </div>
               
                <div class="panel-body">
                       <input type="button" style="float:right"  class="btn btn-primary" value="Print" onclick="PrintPage()"  />
                    <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search" 
                       AllowPaging="True" PageSize="10" OnPageIndexChanging="grdData_PageIndexChanging" OnRowDataBound="gvCustomer_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="Customer Id" DataField="CustomerId1" SortExpression="CustomerId1" />
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="CustomerName1" />
                            <asp:BoundField HeaderText="Address1" DataField="Address11" SortExpression="Address11" />
                            <asp:BoundField HeaderText="Address2" DataField="Address21" SortExpression="Address21" />
                            <asp:BoundField HeaderText="Address3" DataField="Address31" SortExpression="Address31" />
                            <asp:BoundField HeaderText="Contact Person Name" DataField="ContactPersonName1" SortExpression="ContactPersonName1" />
                            <asp:BoundField HeaderText="Product Details" DataField="Productdetails1" SortExpression="Productdetails1" />
                             <asp:TemplateField HeaderText="Edit Option">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Approve" runat="server" CssClass="btn btn-default" Width="55px" OnClick="Edit_Click">Edit</asp:LinkButton>
                                    <asp:LinkButton ID="Reject" runat="server" CssClass="btn btn-primary" Width="55px" OnClick="View_Click">View</asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                    </asp:GridView>
                    </div>
                   
                    <div class="col-md-12 text-center">
                        <ul class="pagination pagination-lg pager" id="myPager"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
    <div id="printdiv" style="display:none">
    
        <table class="table table-bordered boxshadow" id="dvContents"  >
                            <thead>
                            <tr>
                                <th>Customer Id</th>
                                 <th>Customer Name</th>
                               <%--  <th>Port Of Discharge</th>--%>
                                 <th>Address1</th>
                              <%--  <th>Consignee</th>--%>
                                 <th>Address2</th>
                                <%-- <th>Paid Type</th>--%>
                                 <th>Address3</th>
                                 <th>Contact Person Name</th>
                                <th>Contact Person  Mobile No</th>
                                 <th>Contact Person  Phone No</th>
                                 <th>Contact Person  Email</th>
                                <th>Admin User Name</th>
                              <%--  <th>Items</th>--%>
                               
                                 
                            </tr>
                                </thead>
                            <tbody>
                            
                                <div runat="server" id="head"></div>
                          
                                </tbody>
                        </table>
        </div>
</asp:Content>
