<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewCustomerDetails.aspx.cs" Inherits="DSCMS.Views.Customer.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Customer Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="row">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>Customer</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li class="active">
                            <i class="fa fa-th-large"></i> View Customer Detail
                        </li>
                    </ol>
                </div>
            </div>

           
        </div>
        <div class="row">
            <div class="container boxshadow">

                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Customer Details</small>
                    </h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Id</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblCustomerId" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        




                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Name</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblCustName" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>


                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address 1</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblAddress1" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address 2</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblAddress2" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Address 3</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblAddress3" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>



                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">General E-Mail</label>
                            <div class="col-sm-3">
                                <asp:Label ID="lblEmail" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">General Telephone</label>

                            <div class="col-sm-3">
                                <asp:Label ID="lblTelephone" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>



                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">General FAX</label>
                            <div class="col-sm-3">
                                <asp:Label ID="lblFax" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Contact Person’s Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Name</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblContactName" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Designation</label>
                            <div class="col-sm-3">
                                <asp:Label ID="lblDesignation" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Direct Phone Number</label>
                            <div class="col-sm-3">
                                <asp:Label ID="lblPhoneNumber" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Mobile</label>
                            <div class="col-sm-3">
                                <asp:Label ID="lblContactMobile" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">E-mail</label>
                            <div class="col-sm-3">
                                <asp:Label ID="lblContactEmail" CssClass="form-control" runat="server" Text=""></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>


                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Product Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Export Products</label>
                            <div class="col-sm-6">
                                <textarea id="txaProducts" runat="server" name="txaProducts" cols="50" rows="10" style="width: 100%" disabled="disabled"> </textarea>
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Export Sector </label>
                            <div class="col-sm-6">

                                <asp:Label ID="lblExportSector" CssClass="form-control" runat="server" ></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">NCE Member </label>
                            <div class="col-sm-1">

                                <asp:Label ID="lblMember" CssClass="form-control" runat="server" Text=""></asp:Label>

                            </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Paid Type</label>
                                <div class="col-sm-1">

                                    <asp:Label ID="lblPaidType" CssClass="form-control" runat="server" Text=""></asp:Label>
                                </div>

                            </div>



                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Tax Type</label>
                                <div class="col-sm-2">

                                    <asp:Label ID="lblisVat" CssClass="form-control" runat="server" Text=""></asp:Label>
                                </div>

                            </div>




                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Template</label>
                                <div class="col-sm-6">
                                    <asp:Label ID="lblTemplate" CssClass="form-control" runat="server" Text=""></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>
                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Admin Details</small></h2>
                </div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Admin Name</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblAdminName" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Admin User Name</label>
                            <div class="col-sm-6">
                                <asp:Label ID="lblUserName" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                            </div>

                        </div>
                     <div class="form-group">
                                
                                <div class="col-sm-6">
                                   </div>
                         <div class="col-md-2">
                              <asp:Button ID="btnBack" runat="server" CssClass="btn btn-warning btn-block" Text="<< Go Back" OnClick="btnBack_Click" />
                                
                         </div>

                            </div>

                        <div class="col-lg-11" id="Save" runat="server">
                            <div class="form-horizontal" role="form" style="font-family: Cambria;">
                            </div>
                            <%--End of form-horizontal--%>
                        </div>
                        <%-- End of col-lg-11--%>
                    </div>
                    <%--End of Row--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
