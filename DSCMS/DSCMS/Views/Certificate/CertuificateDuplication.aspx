<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CertuificateDuplication.aspx.cs" Inherits="DSCMS.Views.Certificate.CertuificateDuplication" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Document Cancellation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      
    <div class="col-lg-12" style="min-height: 500px">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Document Cancellation List
                    </li>
                </ol>
            </div>
            
        </div>
     
        <div class="col-md-10 col-md-offset-1">
             <div class="form-horizontal" role="form" style="font-family: Cambria;">
          <div class="row">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-2">
                       
                                    <asp:TextBox  CssClass="form-control" ID="txtFromDate" runat="server" ></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtFromDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />

                        <div class="col-ms-2">
                            <div>
                                <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblDateError" runat="server"  Visible="false" ForeColor="Red" />
                            </div>
                        </div>
                    </div>

                          
                    <label class="control-label col-md-2" for="email">To Date </label>

                    <div class="col-md-2">
                       
                                    <asp:TextBox ID="txtTodate"  CssClass="form-control" runat="server" ></asp:TextBox>
                                  <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                      
                      
                        <div class="col-ms-2" >
                            <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate" ErrorMessage="To Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="lblDateError1" runat="server"  Visible="false" ForeColor="Red" />
                            </div>

                        </div>
                    </div>
                   

                         <label class="control-label col-md-2" for="email">Ref No</label>

                    <div class="col-md-2">
                       
                                    <asp:TextBox ID="txtRefNo"  CssClass="form-control" runat="server" ></asp:TextBox>
                                
                    
                    </div>
                            
               
                        </div>
</div>
                <div class="row">
                     <div class="group" >
                               <label class="control-label col-md-2" >Customer</label>
                      <div class="col-md-5">
                                <asp:DropDownList ID="drpCustomer" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="%">All</asp:ListItem>
                                    
                                </asp:DropDownList>
                          </div>
                        
                       
                          <div class="col-md-5" >
                              <div style="float:right">
                        <asp:Button ID="Find" runat="server"  Text="Find" CssClass="btn btn-primary" OnClick="Button1_Click" />
                             </div></div>
                      </div>
                </div>
</div>
            <div style="height: 20px"></div>
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

                <div class="panel-body" id="grid">
                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search" PageSize="10"
                       OnPageIndexChanging="grdData_PageIndexChanging" AllowPaging="True" >
                        <Columns>
                            
                            <asp:BoundField HeaderText="Certificate Number" DataField="CertificateId1" SortExpression="CertificateId1" />
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="CustomerName1" />
                            <asp:BoundField HeaderText="Approved Date" DataField="CreatedDate21" SortExpression="CreatedDate21" />
                             <asp:BoundField HeaderText="Document Type" DataField="DocType1" SortExpression="DocType1" />
                  
                              <asp:TemplateField >
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton3" runat="server" Visible='<%# InvoicedCertificateBtn((string)Eval("Status1")) %>' OnClick="btnDetails_Click" CssClass="btn btn-primary"  >Details</asp:LinkButton>
                                       
                                         <asp:Label runat="server" ID="lblStatus" Text="Invoice Generated" Visible='<%# InvoicedCertificateLbl((string)Eval("Status1")) %>'></asp:Label>
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>
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
</asp:Content>
