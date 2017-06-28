
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CustomerRequestDetails.aspx.cs" Inherits="DSCMS.CustomerRequestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Approval
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ReasonPop" runat="server" visible="false">
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px;margin-top:-60px; position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 10%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Reject Reason</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Reject Reason</label>


                                <div class="col-sm-1">
                                    <asp:DropDownList ID="ddRejectReason" Width="400" Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Reason--" Value="" />
                                    </asp:DropDownList>

                                </div>
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="Reject_btn" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" OnClick="Close_btn" />
                    </div>
                </div>
            </div>


        </div>

    </div>



    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12" style="font-family: Cambria;">
            <h1 class="page-header">Customer Approval
                           
            </h1>
            <br />
            <ol class="breadcrumb">
                <li class="active" style="font-family:Tahoma">
                    <i class="fa fa-dashboard"></i>Customer Detail
                </li>
            </ol>
        </div>
        <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
    </div>
    <div class="container ">
        <div class="row">
            <div class="col-lg-10 " style="font-family: Cambria;">

                <table class="table table-bordered boxshadow">

                    <tbody>

                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Request ID </td>
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
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Address 1 </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>

                            </td>



                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Address 2 </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label>

                            </td>



                        </tr>

                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Address 3 </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAddress3" runat="server" Text=""></asp:Label>

                            </td>



                        </tr>



                        <tr>

                            <td style="width: 210px; font-weight: bold;" class="text-justify">Template Name </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblTemplateName" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblTemplateId" runat="server" Text="" Style="display: none"></asp:Label>
                                <asp:DropDownList Visible="false" ID="drpTemplateId" Width="200" Height="30" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Select Template--" Value="" />
                                </asp:DropDownList>
                                <asp:Label ID="lblTemplateError" runat="server" Text="Please Select Template" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Telephone </td>
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
                            <td style="width: 210px; font-weight: bold;" class="text-justify">E- Mail Address </td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                         <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Administrator Name</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAdminName" runat="server" Text=""></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Administrator User Name</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblAdminUser" runat="server" Text=""></asp:Label>
                                <asp:Label Style="display: none" ID="lblAdminPassword" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Contact Person Name</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblContactPerson" runat="server" Text=""></asp:Label>
                                <asp:Label Style="display: none" ID="lblAdmin" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Contact Person Designation</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblPersonDesignation" runat="server" Text=""></asp:Label>


                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Contact Person Direct Phone Number</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblPersonPhoneNumber" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Contact Person Mobile</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblContactPersonMobile" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 149px; font-weight: bold;" class="text-justify">Contact Person Email</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblContactPersonEmail" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Product Details</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblProductDetails" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Export Sector</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblExportSector" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblExportSectorId"  runat="server" Visible="false" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">NCE Member</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblNCEMember" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                         <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Tax Type</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblSvat" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Registration Letter</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Button ID="btnreg" runat="server" OnClick="btnreg_Click" Text="View" CssClass="btn btn-primary"  />

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Request Letter</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Button ID="btnreq" runat="server" Text="View" OnClick="btnreq_Click" CssClass="btn btn-primary" />

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

            <div class="col-lg-2" style="font-family: Cambria;">

                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" Text="Approve" OnClick="Apporve" />
                <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger btn-block" Text="Reject" OnClick="Button3_Click" /><br />
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning btn-block" Text="<< Go Back" OnClick="Button2_Click" />
            </div>
        </div>
    </div>

</asp:Content>
