<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BillPrints.aspx.cs" Inherits="DSCMS.Views.Invoice.BillPrints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Invoice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
     <script type="text/javascript" src="../../js/pdf1.js"></script>
    <script type="text/javascript" src="../../js/pdf2.js"></script>
    <script type="text/javascript" src="../../js/pdf3.js"></script>
    <script type="text/javascript" src="../../js/pdf4.js"></script>
   
 
     <script type="text/javascript">
      //   document.getElementById("more_btn").style.display = "none";
         function PrintPage() {
            // document.getElementById("div2").style.display = "none";
            // document.getElementById("div1").style.display = "none";
            // document.getElementById("div3").style.display = "none";
             document.getElementById("DivMore").style.display = "none";
            // document.getElementById("lblView").style.display = "none";
           
             window.print();
            // var delay = 1000; //1 second

            // setTimeout(function () {
             //    document.getElementById("div2").style.display = "block";
             //    document.getElementById("div1").style.display = "block";
             //    document.getElementById("div3").style.display = "block";
              //  document.getElementById("DivMore").style.display = "block";
           //  }, delay);
             
         }
         function show() {
            
         }
         function MoreDetailsShow() {
             document.getElementById("DivMore").style.display = "block";
             window.location.hash = '#DivMore';
             document.getElementById("more_btn").style.display = "block";
         }
         function MoreDetailsHide() {
             document.getElementById("DivMore").style.display = "none";
             document.getElementById("more_btn").style.display = "none";
             
         }
         function MoreDetailsPrint() {
            //document.getElementById("div2").style.display = "none";
            //document.getElementById("div1").style.display = "none";
            //document.getElementById("div3").style.display = "none";
            document.getElementById("content").style.display = "none";
            //document.getElementById("btnhid").style.display = "none";
            //document.getElementById("lblView").style.display = "none";
            //document.getElementById("DivMore").style.display = "block";
            //document.getElementById("MoreInforPrint").style.display = "none";

            
             window.print();
             //var delay = 3000; //3 second

             //setTimeout(function () {
             //    document.getElementById("div2").style.display = "block";
             //   document.getElementById("div1").style.display = "block";
             //   document.getElementById("div3").style.display = "block";
                document.getElementById("content").style.display = "block";
             //   document.getElementById("btnhid").style.display = "block";
             //   document.getElementById("lblView").style.display = "block";
             //   document.getElementById("MoreInforPrint").style.display = "block";
             //}, delay);

         }
</script>
    <script type=application/javascript>document.links[0].href = "data:text/html;charset=utf-8," + encodeURIComponent('<!doctype html>' + document.documentElement.outerHTML)</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <style>
     #more_btn {
        display:none;
     }
        .possitions {
            float:right;
        }
     #DivMore {
        display:none;
     }
  

     @media print {
         body * {
            visibility:hidden;
         }
         #tbl, #tbl * {
            visibility:visible;
         }
        
         #content {
             position:absolute;
             left:100px;

            top:0px;
         }
           #DivMore {
             position:absolute;
             left:100px;
            top:-200px;
         }
         @page {
    size: auto;   /* auto is the initial value */
    margin: 0;  /* this affects the margin in the printer settings */
}
     }
    </style>

    <div class="col-lg-12" id="div1">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Statement</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Monthly Bill
                    </li>
                </ol>
            </div>
        </div>
    </div>

    <div class="container"  >
        <div class="row">
             <div class="form-group" id="div3"  >
                            <label class="control-label col-sm-2"  for="email">Print Reason</label>
                            <div class="col-sm-6" style="padding-bottom:50px">
                                <asp:TextBox ID="txtPrintReason" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                 <div class="col-md-3">
                     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrintReason" ForeColor="Red"  ErrorMessage="Reason Field Is Required"></asp:RequiredFieldValidator>
                 --%></div>
                 
                        </div>
           
             <div id="Div1" class="col-lg-8 " style="font-family: Cambria;" runat="server">
        <div id="tbl"  style="width:100%">
<div id="content">
           <table>
               <tr>
                   <td style="width:400px">
                       
                       <asp:Label ID="lblHeadAddress1" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="lblHeadAddress2" runat="server" Text="Label"></asp:Label><br />
                         <asp:Label ID="lblHeadAddress3" runat="server" Text="Label"></asp:Label>
                   </td>
                   <td style="width:300px">
                       Tel	:	 <asp:Label ID="lblTelephone" runat="server" Text="Label"></asp:Label><br />
                        Fax	:	 <asp:Label ID="lblFax" runat="server" Text="Label"></asp:Label><br />
                        Web	:	 <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                   </td>
                   <td>
                       <img src="../../img/nce_new_logo.png" class="img-responsive" style="max-width: 100px; max-height: 80px" />
                   </td>
               </tr>
               <tr>
                  <td style="height:15px"></td>
                    <td></td>
                    <td></td>
               </tr>
               <tr>
                   <td></td>
                   <td style="padding-left:160px">
                       <label>Invoice No</label>
                   </td>
                   <td>
                       <asp:Label ID="lblInvoiceNo" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
                <tr>
                   <td></td>
                   <td style="padding-left:160px">
                       <label>Invoice Date</label>
                   </td>
                   <td>
                       <asp:Label ID="lblInvoiceDate" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
              </table>
              <table>
                           <tr>
                               <td style="width:80px">
                                     <label>Bill To : </label>
                               </td>
                               <td style="padding:5px;width:600px"><asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>(<asp:Label ID="lblCustomerId" runat="server" Text=""></asp:Label>)
                        </td>
                           </tr>
                           <tr>
                               <td>

                               </td>
                               <td style="padding-left:5px"><asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label></td>
                           </tr>
                           <tr>
                               <td></td>
                               <td style="padding-left:5px"><asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></td>
                           </tr>
                           <tr>
                               <td></td>
                               <td style="padding-left:5px"><asp:Label ID="lblAddress3" runat="server" Text=""></asp:Label></td>
                           </tr>
                       <tr>
                              <td><label>From Date:</label></td>
                              <td><asp:Label ID="lblFrom" runat="server" Text=""></asp:Label></td>
                          </tr>
                          <tr>
                              <td>
                                  <label>To Date:</label>
                              </td>
                              <td>
                                  <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                              </td>
                          </tr>
                      </table>
            <Label id="lblView">View Only</Label>
            <div style="float:right">
            <asp:Label ID="lblPrintTime" runat="server" ></asp:Label>
                </div>
  <table class="table table-bordered boxshadow">
                        <tbody>
                            <tr>

                                <td>
                                    <center><asp:Label ID="lblInvoiceName" runat="server" Text=""></asp:Label></center>
                                </td>
                               
                            </tr>
                        </tbody>
                    </table>
            <style>
                .line {
                    text-align:right;
                }
            </style>
           
                   
                    <table class="table table-bordered boxshadow">
                        <thead>
                            <tr>
                                <td>Document Type</td>
                                <td style="width:100px">Rate</td>
                                <td style="width:200px">No Of Items</td>
                                <td style="width:200px">Total</td>
                            </tr>
                        </thead>
                        <tbody>
                            <div id="CertificateDetail" runat="server"></div>
                            <div id="RateDetails" runat="server"></div>
                           <%-- <tr>
                                <td style="width: 250px; font-weight: bold;" class="text-justify">Suporting Document Rate</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblSuportionDocRate" runat="server" Style="float: right;"></asp:Label>
                                        </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="width: 250px; " class="text-justify">Total</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblGrossTotal" runat="server" Style="float: right;"></asp:Label>
                                        </div>
                                </td>
                            </tr>
                           <div id="head" runat="server"></div>
                           <%-- <tr>
                                    <td style="width: 149px; font-weight: bold;" class="text-justify">Total Tax</td>
                                    <td class="modal-sm" colspan="3">
                                         <asp:Label ID="lblTax" runat="server" Style="float: right; " Text=""></asp:Label>
                                    </td>
                              </tr>--%>
                            <tr>
                                <td style="width: 250px; " class="text-justify">Grand Total</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                   <asp:Label ID="lblTotal" runat="server" Style="float: right;font-weight: bold "></asp:Label>
                                        </div>
                                </td>
                            </tr>
                           
                        </tbody>
                    </table>
    </div>
            <br />
            <br />
            <br />
            <div id="DivMore">
                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>More Details</small>
                    </h2>
                </div>
                     
                <asp:GridView ID="gvState" CssClass="table  table-bordered  table-hover" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo1" SortExpression="InvoiceNo1" />
                        <asp:BoundField HeaderText="From" DataField="sFromDate1" SortExpression="sFromDate1" />
                        <asp:BoundField HeaderText="To" DataField="sToDate1" SortExpression="sToDate1" />
                     
                    </Columns>
                </asp:GridView>
                <br />
                <label>Issued Certificate Details</label> 
                <asp:GridView ID="gvRequest" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover">
                        <Columns>
                          <asp:BoundField HeaderText="Request No"  DataField="RequestNo1" SortExpression="RequestNo1" />
                            <asp:BoundField HeaderText="Certificate No"  DataField="CertificateNo1" SortExpression="CertificateNo1" />
                            <asp:BoundField HeaderText="Consignor"  DataField="Consignor1" SortExpression="Consignor1" />
                            <asp:BoundField HeaderText="Consignee" DataField="Consignee1" SortExpression="Consignee1" />
                            <asp:BoundField HeaderText="Created Date" DataField="CreatedDate21" SortExpression="CreatedDate21" />
                            <asp:BoundField HeaderText="Charge" DataField="UnitCharge21" ItemStyle-CssClass="line" SortExpression="UnitCharge21" />
                            </Columns>
                    </asp:GridView>
                <table class="table table-bordered boxshadow">
                    <tbody>
                        <tr>
                            <td style="width: 250px; font-weight: bold;" class="text-justify">Total</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float: right">
                                    <asp:Label CssClass="" ID="lblRequestCost" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>


                    </tbody>

                </table>
                <br />
                <label>Supporting Documents Details</label>
                 <asp:GridView ID="gvRate" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover">
                        <Columns>
                          
                            <asp:BoundField HeaderText="Suporting Document"  DataField="SuportingDocName1" SortExpression="SuportingDocName1" />
                            <asp:BoundField HeaderText="Suporting Document Id" DataField="SuportingDocId1" SortExpression="SuportingDocId1" />
                            <asp:BoundField HeaderText="Request Date" DataField="SrequestDate1" SortExpression="SrequestDate1" />
                            <asp:BoundField HeaderText="Approved Date" DataField="CreatedDate21" SortExpression="CreatedDate21" />
                            <asp:BoundField HeaderText="Rate"  DataField="Rate1" SortExpression="Rate1" />
                            <asp:BoundField HeaderText="Charge" DataField="RateValue1" ItemStyle-CssClass="line" SortExpression="RateValue1" />
                            </Columns>
                    </asp:GridView>
                <table class="table table-bordered boxshadow">
                    <tbody>
                        <tr>
                            <td style="width: 250px; font-weight: bold;" class="text-justify">Total</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float: right">
                                    <asp:Label ID="lblTotalRate" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 250px; font-weight: bold;" class="text-justify">Total Before Tax</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float: right">
                                   <asp:Label ID="lblTotalGross" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </tbody>

                </table>
                <br />
                <label>Tax Details</label> 
                
                <asp:GridView ID="gvTax" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover">
                        <Columns>
                          <asp:BoundField HeaderText="Tax Name"  DataField="TaxName11" SortExpression="TaxName11" />
                            <asp:BoundField HeaderText="Percentage"  DataField="TaxPercentage1" SortExpression="TaxPercentage1" />
                            <asp:BoundField HeaderText="Value" DataField="stAmount1" ItemStyle-CssClass="line" SortExpression="stAmount1" />
                        </Columns>
                    </asp:GridView>
                <table class="table table-bordered boxshadow">
                    <tbody>
                        <tr>
                            <td style="width: 250px; font-weight: bold;" class="text-justify">Total Tax</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float: right">
                                   <asp:Label ID="lblTotalTax" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>
                         <tr>
                            <td style="width: 250px; font-weight: bold;" class="text-justify">Grand Total</td>
                            <td class="modal-sm" colspan="3">
                                <div style="float: right">
                                    <asp:Label ID="lblTotalNet" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>

                    </tbody>

                </table>

            </div>
                </div>
                           <div style="float:right" id="more_btn">
                    <div class="row" style="z-index:99">
                        <table>
                            <tr>
                                <td> <input id="MoreInforPrint"  type="button" class="btn btn-primary btn-block" value="Print More Details" onclick="MoreDetailsPrint()"/>
                        </td>
                                <td>  <input type="button" id="btnhid" value="Hide More Details" class="btn btn-primary" onclick="MoreDetailsHide()" /> 
                          </td>
                            </tr>
                        </table>
                           
                          
                  </div>
                </div>
                <div style="width:100%;height:55px"></div>
    </div>
            
             <div class="col-lg-2" style="font-family: Cambria;" id="div2">
                 <input  type="button" class="btn btn-primary btn-block" value="More Details" onclick="MoreDetailsShow()"/>
                 <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Print Invoice" OnClick="Printbtn"  />
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning btn-block" Text="<< Go Back" OnClick="Back" />
                 
            </div>
             </div>      
       </div>
  

</asp:Content>

