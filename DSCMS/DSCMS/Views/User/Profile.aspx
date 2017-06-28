<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DSCMS.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                 <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12" style="font-family:Cambria;">
                        <h1 class="page-header">
                           <small>User</small>
                        </h1> <br />
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-users"></i> Profile
                            </li>
                        </ol>
                    </div>
                </div>
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
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Customer Name </td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>

                            </td>
                             
                          
                          </tr>
                          <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Short Name </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblShortName" runat="server" Text=""></asp:Label>

                            </td>
           
                          </tr>
                          <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Customer Type</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblCustomerType" runat="server" Text=""></asp:Label>

                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Address Line 1 </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>

                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Address Line 2 </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label>

                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Address Line 3 </td>
                            <td class="modal-sm" style="width: 287px">
                                <asp:Label ID="lblAddress3" runat="server" Text=""></asp:Label>

                            </td>
                            <td style="width: 124px; font-weight: bold;" class="text-right">PO BOX </td>
                              <td>
                                <asp:Label ID="lblPOB" runat="server" Text=""></asp:Label>

                              </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Country </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label>
                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">City </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                                

                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Invoice Type </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblInvoiceType" runat="server" Text=""></asp:Label>
                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">VAT Regstration No </td>
                            <td class="modal-sm" style="width: 287px">
                                <asp:Label ID="lblVARno" runat="server" Text=""></asp:Label>

                            </td>
                            <td style="width: 124px; font-weight: bold;" class="text-right">SVAT No </td>
                                <asp:Label ID="lblSVAT" runat="server" Text=""></asp:Label>
                              <td></td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Telephone </td>
                            <td class="modal-sm" style="width: 287px">
                                <asp:Label ID="lblIDD" runat="server" Text=""></asp:Label>
                                 &nbsp; 
                                <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label>

                            </td>
                            <td style="width: 124px; font-weight: bold;" class="text-right">FAX </td>
                              <td>
                                <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
                              </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Contact Person </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblContactPerson" runat="server" Text=""></asp:Label>
                            </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">E- Mail Address </td>
                            <td class="modal-sm" style="width: 287px">
                                   <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>

                            </td>
                            <td style="width: 124px; font-weight: bold;" class="text-right">Web Address </td>
                              <td><asp:Label ID="lblWebAddress" runat="server" Text=""></asp:Label></td>

                          </tr>
                             <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Requested Date </td>
                            <td class="modal-sm" style="width: 287px">
                                <asp:Label ID="lblRequestDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 124px; font-weight: bold;" class="text-right">Request Status </td>
                              <td>
                                <asp:Label ID="lblRequestStatus" runat="server" Text=""></asp:Label>

                              </td>

                          </tr>
                             <tr>
                            <td style="width: 149px" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" style="width: 287px">&nbsp;</td>
                            <td style="width: 124px">&nbsp;</td>
                              <td></td>

                          </tr>
                        </tbody>
                      </table>

                        </div>

                <div class="col-lg-2" style="font-family:Cambria; ">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Change Password" /><br />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning btn-block" Text="<< Go Back" />
                    </div>
                        </div>
    </div>


</asp:Content>
