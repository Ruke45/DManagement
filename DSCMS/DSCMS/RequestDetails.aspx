<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RequestDetails.aspx.cs" Inherits="DSCMS.RequestDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12" style="font-family:Cambria;">
                        <h2 class="page-header">
                            Certificate Request Details
                        </h2> <br />
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-dashboard"></i>My Profile
                            </li>
                        </ol>
                    </div>
                </div>
           <div class="container">
             <div class="row">
                    <div class="col-lg-10" style="font-family:Cambria;">

                          <table class="table table-bordered boxshadow">
        
                          <tbody>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Request No</td>
                            <td class="modal-sm" style="width: 287px">
                                <asp:Label ID="lblAddress3" runat="server" Text=""></asp:Label>

                            </td>
                            <td style="width: 124px; font-weight: bold;" class="text-right">Request Date </td>
                              <td>
                                <asp:Label ID="lblPOB" runat="server" Text=""></asp:Label>

                              </td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Customer Name</td>
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
                            <td style="width: 149px; font-weight: bold;" class="text-justify">&nbsp;</td>
                            <td class="modal-sm" colspan="3">
                                &nbsp;</td>

                          </tr>
                            <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Supporting Document </td>
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

                <div class="col-lg-2" style="font-family:Cambria;">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Approve" /><br />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning btn-block" Text="View Certificate" />
                    </div>
                        </div>
    </div>


</asp:Content>
