<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MonthlyInvoiceBill.aspx.cs" Inherits="DSCMS.MonthlyInvoiceBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Invoice
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <script>

        setTimeout(function () {

            $('.progress .bar').each(function () {
                var me = $(this);
                var perc = me.attr("data-percentage");

                var current_perc = 0;

                var progress = setInterval(function () {
                    if (current_perc >= perc) {
                        clearInterval(progress);
                    } else {
                        current_perc += 1;
                        me.css('width', (current_perc) + '%');
                    }

                    me.text((current_perc) + '%');

                }, 50);

            });

        }, 300);
    </script>
          
    
  <div class="progress progress-success">
<div class="bar" style="float: left; width: 0%; " data-percentage="100"></div>--%>
       <asp:GridView ID="gvInvoicedetails" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover">
                        <Columns>
                          <asp:BoundField HeaderText="Request No"  DataField="RequestId1" SortExpression="RequestId1" />
                            <asp:BoundField HeaderText="Consignor"  DataField="Consignor1" SortExpression="Consignor1" />
                            <asp:BoundField HeaderText="Consignee" DataField="Consignee1" SortExpression="Consignee1" />
                            <asp:BoundField HeaderText="Created Date" DataField="CreatedDate1" SortExpression="CreatedDate1" />
                            <asp:BoundField HeaderText="Unit Charge" DataField="UnitCharge21" ItemStyle-CssClass="line" SortExpression="UnitCharge21" />
                            <asp:BoundField HeaderText="Quantity" DataField="Quantity1" ItemStyle-CssClass="line" SortExpression="Quantity1" />
                            <asp:BoundField HeaderText="Invoice Line Value" DataField="InvoiceLineValue21" ItemStyle-CssClass="line" SortExpression="InvoiceLineValue21" />
                        </Columns>
           </asp:GridView>
           <table>
               <div runat="server" id="head"></div>
               <tr>
                                <td style="width: 149px; font-weight: bold;" class="text-justify">Invoice Charges</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblInvoiceCharges" runat="server" Style="float: right;"></asp:Label>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 149px; font-weight: bold;" class="text-justify">Co Charges</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblCoCharges" runat="server" Style="float: right;"></asp:Label>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 149px; font-weight: bold;" class="text-justify">Other Document Charges</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblOtherCharges" runat="server" Style="float: right;"></asp:Label>
                                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 149px; font-weight: bold;" class="text-justify">Gross Total</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblGrossTotal" runat="server" Style="float: right;"></asp:Label>
                                        </div>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td style="width: 149px; font-weight: bold;" class="text-justify">Total</td>
                                <td class="modal-sm" colspan="3">
                                    <div style="float:right">
                                    <asp:Label ID="lblTotal" runat="server" Style="float: right; "></asp:Label>
                                        </div>
                                </td>
                            </tr>
                           
           </table>
                    
</div>




</asp:Content>
