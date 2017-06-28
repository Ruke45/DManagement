<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SetCertificate.aspx.cs" Inherits="DSCMS.Views.Certificate.SetCertificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


           <div class="container ">
             <div class="row">
                    <div class="col-lg-10 " style="font-family:Cambria;">

                          <table class="table table-bordered boxshadow">
        
                          <tbody>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Request ID </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblRequestID" runat="server" Text=""></asp:Label>
                            </td>
                         
                          </tr>
                            <tr>
                            <td style="font-weight: bold;" class="text-justify" colspan="2" rowspan="2">Address Line 3 
                                <br />
                                <asp:TextBox ID="TextBox1" runat="server" Height="86px" TextMode="MultiLine" Width="430px"></asp:TextBox>
                                <br />
                                </td>
                            <td style="font-weight: bold; text-align: left;" class="text-right" colspan="2">PO BOX 
                                <br />
                                <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="376px"></asp:TextBox>
                                </td>

                          </tr>

                              <tr>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td class="text-justify" colspan="2" rowspan="3">Consignee<br />
                                <asp:TextBox ID="TextBox3" runat="server" Height="86px" TextMode="MultiLine" Width="430px"></asp:TextBox>
                                  </td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify" rowspan="2">Invoice No<br />
                                &amp;<br />
                                Date<br />
                                (If Applicable)</td>
                            <td class="modal-sm" style="width: 287px">
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                  </td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td class="modal-sm" style="width: 287px">
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                  </td>
                            <td colspan="2">Country Of Origin&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox11" runat="server" Width="267px"></asp:TextBox>
                                  </td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">Port of Loading<br />
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                  </td>
                            <td class="modal-sm" style="width: 287px">Vessel<br />
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                  </td>
                            <td>Port of Dischargh<br />
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                  </td>
                              <td>Place of Delivery<br />
                                  <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                  </td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>

                              <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td>&nbsp;</td>
                              <td></td>

                          </tr>
                        </tbody>
                      </table>

                        </div>

                <div class="col-lg-2" style="font-family:Cambria; ">
                    <br />
                    </div>
                        </div>
    </div>






</asp:Content>
