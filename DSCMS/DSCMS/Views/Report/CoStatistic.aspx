<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CoStatistic.aspx.cs" Inherits="DSCMS.Views.Report.CoStatistic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate View
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function printTrigger() {
            //document.getElementById("diviframe").style.display="none";
            var PDF = document.getElementById("iFramePdf");
            PDF.focus();
            PDF.contentWindow.print();

        }
</script>
   
 
 
            
            <div id="diviframe" runat="server"   style="width:100%;margin:auto;height:90%;padding-top:5%;display:none">
             </div>
         
            <br />
      
      
    <style>
        #cal1 {
            display: none;
            position: absolute;
            background-color: white;
        }

        #cal2 {
            display: none;
            position: absolute;
            background-color: white;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script>
        var val1 = 0;
        var val2 = 0;
        function showcal1() {
            if (val1 == 0) {
                document.getElementById("cal1").style.display = "block";
                val1 = 1;
            }
            else {
                document.getElementById("cal1").style.display = "none";
                val1 = 0;
            }
        }
        function showcal2() {
            if (val2 == 0) {
                document.getElementById("cal2").style.display = "block";
                val2 = 1;
            }
            else {
                document.getElementById("cal2").style.display = "none";
                val2 = 0;
            }
        }
    </script>
    <div class="col-lg-12">
        <div class="row" id="check">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Certificate</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i>Approved Certificate Detail
                    </li>
                </ol>
            </div>
            <div class="col-md-10 col-md-offset-1">
               
                
                </div>
           
            <div class="col-md-10 col-md-offset-1">
                 <div class="form-horizontal" role="form" style="font-family: Cambria;">
              <div class="row">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-3">
                       
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

                    <div class="col-md-3">
                       
                                    <asp:TextBox ID="txtTodate"  CssClass="form-control" runat="server"></asp:TextBox>
                                  <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtTodate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                      
                      
                        <div class="col-ms-3" style="width: 150px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>


                        </div>
                    </div>
                   
               
                        </div>
</div>
                <div class="row" style="padding-bottom:10px">
                     <div class="group" >
                         <label class="control-label col-md-2" runat="server" id="lblCetificateNo" text="">Ref No</label>
                      <div class="col-md-3">
                                   <asp:TextBox ID="txtcertNo"  CssClass="form-control" runat="server"></asp:TextBox>
                          </div>
                         
                               <label class="control-label col-md-2" runat="server" id="lblcusid" for="email" text=""></label>
                      <div class="col-md-3">
                                <asp:DropDownList ID="drpSearch" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    
                                </asp:DropDownList>
                          </div>

                             
                      </div>
                </div>
                     <div class="row" style="padding-bottom:10px;padding-top:7px">
                          
                     <div class="group" >
                          <label class="control-label col-md-2" runat="server" id="Label1" text="">Invoice No</label>
                         
                      <div class="col-md-3">
                                   <asp:TextBox ID="txtInvoiceNo"  CssClass="form-control" runat="server"></asp:TextBox>
                        
                          </div>

                      <div class="col-md-5" >
                              <div style="float:right">
                        <asp:Button ID="Find" runat="server"  Text="Find" CssClass="btn btn-primary" OnClick="Find_onClick" />
                        <asp:Button ID="btnprint" runat="server"  Text="print" CssClass="btn btn-primary" OnClick="down" />
                             </div></div>
              </div>

                     </div>
                     
                  
                         </div>
               
          
                <div class="panel panel-default panel-table">
                    <div class="panel-heading">
                        <div class="row">
                          
                            <div class="col col-xs-3 text-right" style="float: right">
                                
                                    <div class="input-group">
                                        
                                    </div>
                               

                            </div>
                            <div class="col col-xs-2 text-right">
                            </div>

                        </div>
                    </div>

                    <div class="panel-body">
                      <style>
                          .hid {
                            font-size:0px;
                            padding:0px;
                          }
                      </style>

                        <asp:GridView ID="gvCertificate" AutoGenerateColumns="False" runat="server" CssClass="table  table-bordered  table-hover table-list-search" PageSize="10"
                            OnPageIndexChanging="grdData_PageIndexChanging" AllowPaging="True" >
                            <Columns>
                               <%-- <asp:BoundField HeaderText="Customer Name" DataField="CustomerName1" SortExpression="CustomerName1" />
                                <asp:BoundField HeaderText="Ref No" DataField="CertificateId1" SortExpression="CertificateId1" />
                                 <asp:BoundField HeaderText="Request Date" DataField="RequestDate1" SortExpression="RequestDate1" />
                                <asp:BoundField HeaderText="Issued Date" DataField="CreatedDate21" SortExpression="CreatedDate21" />
                                <asp:BoundField HeaderText="Consignor" DataField="Consignor1" SortExpression="Consignor1" />
                                <asp:BoundField HeaderText="Consignee" DataField="Consignee1" SortExpression="Consignee1" />--%>
                                <%--<asp:BoundField HeaderText="" DataField="CertificatePath1" ItemStyle-CssClass="hid"  SortExpression="CertificatePath1" />--%>
                                
                                   <asp:BoundField HeaderText="Request ID" DataField="Request_Id" />
                                   <asp:BoundField HeaderText="Requested By" DataField="User_ID" />
                                  <asp:BoundField HeaderText="Requested Date" DataField="RequestedDate_" />
                                  <asp:BoundField HeaderText="Date of Approved " DataField="CretifiedDate_" />
                                 <asp:BoundField HeaderText="Approved By" DataField="PersonName_"  />
                                  <asp:BoundField HeaderText="Reference No" DataField="Certificate_Name"  />
                                   <asp:BoundField HeaderText="Company Name" DataField="CustomerName_"  />
                                  <asp:BoundField HeaderText=" Print Status" DataField="Is_Downloaded"  />
                                  <asp:BoundField HeaderText="Seal Apllied" DataField="SealRequired_"  />
                                  <asp:BoundField HeaderText="Invoice Id" DataField="InvoiceId_"  />
                                 <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="CertificatePath" runat="server" Text='<%#Eval("Certificate_Path") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>
                                <%-- <asp:BoundField HeaderText="" ItemStyle-CssClass="hidden" DataField="AdminPassword1" SortExpression="AdminPassword1"  />--%>
                                <%--<asp:ButtonField CommandName="select" ControlStyle-CssClass="btn btn-info btn-sm" HeaderText="View Details" Text="View"></asp:ButtonField>
                               --%> <asp:TemplateField HeaderText = "">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" Visible='<%# InvoicedCertificateBtn((string)Eval("Certificate_Path")) %>'  CssClass="btn btn-primary" runat="server" OnClick="LinkButton1_Click">View</asp:LinkButton>
                                       <asp:Label ID="LinkButton2" Visible='<%# Certificatelable((string)Eval("Certificate_Path")) %>'  runat="server" >Manual Certificate</asp:Label>
                                        
                                   </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText = "">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton3"   CssClass="btn btn-primary" Visible='<%# InvoicedCertificateBtn((string)Eval("Certificate_Path")) %>' runat="server" OnClick="Print_Click">Print</asp:LinkButton>
                                         <asp:Label ID="LinkButton4" Visible='<%# Certificatelable((string)Eval("Certificate_Path")) %>'  runat="server" >Manual Certificate</asp:Label>
                                         <asp:CheckBox id="CheckBox1" Checked="false" TextAlign="Right" Visible='<%# InvoicedCertificateBtn((string)Eval("Certificate_Path")) %>'  runat="server"/>
                                       </ItemTemplate>
                                </asp:TemplateField>
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
