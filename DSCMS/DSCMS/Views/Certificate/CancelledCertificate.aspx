<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CancelledCertificate.aspx.cs" Inherits="DSCMS.Views.Certificate.CancelledCertificate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Cancelled Certificate
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12" id="div4">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Certificate Cancellation History
                    </li>
                </ol>
            </div>
            <div class="col-md-10 col-md-offset-1">
               
                
                </div>
           
            <div class="col-md-10 col-md-offset-1">
                  <div class="form-horizontal" role="form" style="font-family: Cambria;">
              <div class="row" id="div3">
                    <div class="form-group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-2">
                       
                                    <asp:TextBox  CssClass="form-control" ID="txtFromDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtFromDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                      

                        <div class="col-ms-3" style="width: 150px">
                            <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>

                            <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                        </div>
                    </div>

                          
                    <label class="control-label col-md-2" for="email">To Date </label>

                    <div class="col-md-2">
                       
                                    <asp:TextBox ID="txtTodate" CssClass="form-control" runat="server"></asp:TextBox>
                               
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                        <div class="col-ms-3" style="width: 150px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>


                        </div>
                    </div>
                   
                         <label class="control-label col-md-2" for="email">Ref No</label>

                    <div class="col-md-2">
                       
                                    <asp:TextBox ID="txtrefNo" CssClass="form-control" runat="server"></asp:TextBox>
  
                    </div>
               
                        </div>
</div>
               
                <div class="row"  id="div2">
                     <div class="group" >
                               <label class="control-label col-md-2" runat="server" id="lblcusid" for="email" text="">Customer Name</label>
                      <div class="col-md-5"     style="padding-left: 6px">
                       
                        
                                <asp:DropDownList ID="drpCustomer" CssClass="form-control" AppendDataBoundItems="true" runat="server" >
                                    <asp:ListItem Value="%">All</asp:ListItem>
                                    
                                </asp:DropDownList>
                             
                          </div>

                        
                          <div class="col-md-5" >
                              <div style="float:right">
                        <asp:Button ID="Find" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="Find_Click"  />
                             </div></div>
                      </div>
                </div>

              </div>
                   <br />
                    
          
                <div class="panel panel-default panel-table" id="div5">
                    <div class="panel-heading" id="div1">
                        
                        <div class="row">
                           
                            <div class="col col-xs-3 text-right" style="float: right">
                                <form action="#" method="get">
                                    <div class="input-group">
                                        <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                       <%-- <input class="form-control" id="system-search" placeholder="Search for" />
                                       --%> <span class="input-group-btn">
                                          <%--  <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                       --%> </span>
                                    </div>
                                </form>

                            </div>
                            <div class="col col-xs-2 text-right">
                            </div>

                        </div>
                    </div>

                    <div class="panel-body" >
                       
                        
                       <asp:GridView ID="gvCertificate" CssClass="table  table-bordered  table-hover table-list-search" runat="server" AutoGenerateColumns="false" PageSize="10"
                       OnPageIndexChanging="grdData_PageIndexChanging" AllowPaging="True">
                    <Columns>
                        <asp:BoundField HeaderText="Certificate Id" DataField="CertificateId1" SortExpression="CertificateId1" />
                        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="Remark1" />
                        <asp:BoundField HeaderText="Remark" DataField="Remark1" SortExpression="sToDate1" />
                        <asp:BoundField HeaderText="Canceled By" DataField="CreatedBy1" SortExpression="CreatedBy1" />
                        <asp:BoundField HeaderText="Doc Type" DataField="DocType1" SortExpression="DocType1" />
                         
                         <asp:BoundField HeaderText="Canceled Date" DataField="CreatedDate21" SortExpression="CreatedDate21" />
                        
                    </Columns>
                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                </asp:GridView>
    
                        <div class="col-md-12 text-center">
                            <%--<ul class="pagination pagination-lg pager" id="myPager"></ul>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
