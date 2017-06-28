<%--<!-- Version NO 12.1 -->
<!-- Request Date:2016/12/06-->
<!-- UPdate Date:2016/12/08-->
<!-- Request By:Mr.Pradeep-->
<!-- Changes:Change button name,header-->
<!-- Done By:nipun Munipura-->  
    --%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CoStatus.aspx.cs" Inherits="DSCMS.Views.Certificate.CoStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div id="ReasonPop" runat="server" visible="false">
        <div style="width: 100%; height: 150%; background-color: rgba(0, 0, 0, 0.81); z-index: 9999; margin-left: -15px;margin-top:-60px; position: fixed">
            <div class="col-lg-8" style="margin-left: 15%; margin-right: 15%; margin-top: 6%">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Message</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">


                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Name</label>


                                <div class="col-sm-7"> 
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Label1" runat="server" ForeColor="red" Visible="false" Text="Label"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Email Address</label>


                                <div class="col-sm-7">
                                   <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>
                                 <div class="col-sm-3">
                                     <div>
                                          <asp:RegularExpressionValidator ID="cvEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Address." ForeColor="Red"></asp:RegularExpressionValidator>
                           
                                     </div>
                                     <div>
                                          <asp:Label ID="Label2" runat="server" ForeColor="red" Visible="false" Text="Label"></asp:Label>
                                         </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Phone Number</label>


                                <div class="col-sm-7">
                                   
                                    <asp:TextBox ID="txtPhone" placeholder="+94123456778" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="col-sm-3">
                                      <div>
                                        <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server"
                                            ErrorMessage="Invalid Telephone Number"
                                            ControlToValidate="txtPhone"
                                            ValidationExpression="^\+(?:[0-9].?){6,14}[0-9]$" />
                                    </div><div>
                                    <asp:Label ID="Label3" runat="server" ForeColor="red" Visible="false" Text="Label"></asp:Label>
                                        </div>
                                </div>
                            </div>

                            

                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email">Details</label>


                                <div class="col-sm-7">
                                    <textarea id="TextArea1" class="form-control col-md-6" runat="server"  cols="20" rows="10"></textarea>

                                </div>
                                 <div class="col-sm-3">
                                    <asp:Label ID="Label4" runat="server" ForeColor="red" Visible="false" Text="Label"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="Send_btn" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" OnClick="Close_btn" />
                    </div>
                </div>
            </div>


        </div>

    </div>








    <div class="col-lg-12">
        <div class="row">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>Verification of the Certificate</small>
                    </h1>
                    <ol class="breadcrumb">
                        <li class="active">
                            <i class="fa fa-th-large"></i>Certificate Verification
                        </li>
                    </ol>
                </div>
            </div>
            <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
        </div>
        <div class="row">
            <div class="container boxshadow">

                <div class="col-lg-12">
                    <h2 class="page-header">
                        <small>Certificate Details</small>
                    </h2>

                </div>
                 <div class="form-horizontal" role="form" style="font-family: Cambria;">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="email">Reference Number(CO)</label>
                    <div class="col-sm-4" style="z-index:2">
                        <asp:TextBox ID="txtCertificateNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-3"  style="z-index:2">
                        <asp:Button ID="btnFind" runat="server" Text="Verify" CssClass="btn btn-primary" OnClick="btnFind_Click" />
                    </div>
                </div>
</div>

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <div style="width: 100%; height: 20px"></div>
                        <table class="table table-bordered boxshadow" runat="server" id="tbl" visible="false">

                            <tbody>

                                <tr>
                                    <td style="width: 210px; font-weight: bold;" class="text-justify">Consigner Name</td>

                                    <td style="height: 31px" colspan="3">
                                        <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 210px; font-weight: bold;" class="text-justify">Certificate(CO) Issued Date</td>

                                    <td style="height: 31px" colspan="3">
                                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Consignee</td>
                                    <td style="height: 31px" colspan="3">
                                        <asp:Label ID="lblConsignee" runat="server" Text=""></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Invoice Number</td>
                                    <td style="height: 31px" colspan="3">
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text=""></asp:Label>

                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Summary Description </td>
                                    <td style="height: 31px" colspan="3">
                                        <asp:Label ID="lbldescription" runat="server" Text=""></asp:Label>

                                    </td>
                                </tr>--%>
                                <%--<tr>
                                    <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Total Invoice Value</td>
                                    <td style="height: 31px" colspan="3">
                                        <asp:Label ID="lblInvoiceValue" runat="server" Text=""></asp:Label>

                                    </td>
                                </tr>--%>
                            </tbody>
                        </table>

                    </div>
                    <%--End of form-horizontal--%>
                    <div class="col-lg-13">
                        <br />
                        <br />
                        <h4>For further  clarifications, please contact:</h4>
                        <hr />
                        

                    <div class="form-horizontal" role="form" style="font-family: Cambria;">
                        <table style="margin-left:10%">
                            <tr>
                                <td class="col-md-4">
                            <label class="control-label" >Contact Person Name</label>
                                    </td>
                                <td  class="col-md-4">
                           
                                <asp:Label ID="lblName" CssClass="control-label" runat="server" ></asp:Label>
                                </td> 
                            </tr>
                         <tr>
                                <td  class="col-md-4">
                            <label class="control-label" for="email">Phone No</label>
                             </td>
                                <td  class="col-md-4">
                                <asp:Label ID="lblPhoneNo" CssClass="control-label" runat="server"></asp:Label>
                            </td> 
                            </tr>
                         <tr>
                                <td  class="col-md-4">
                            <label class="control-label" for="email">Fax No</label>
                             </td>
                                <td  class="col-md-4">
                                <asp:Label ID="lblFax" CssClass="control-label" runat="server"></asp:Label>
                           </td> 
                         </tr>
                         <tr>
                                <td  class="col-md-4">
                            <label class="control-label" for="email">Email Address</label>
                            </td><td  class="col-md-4">
                                <asp:Label ID="lblemail" CssClass="control-label" runat="server"></asp:Label>
                            </td> 
                            </tr>
                         <tr>
                                <td  class="col-md-4">
                            <label class="control-label" for="email">Web Address</label>
                            </td><td  class="col-md-4">
                                <asp:Label ID="lblWeb" CssClass="control-label" runat="server" EnableViewState="False"></asp:Label>
                           </td> 
                            </tr>
                        
                               
                        </table>
                         <br />
                        <br />
                        <div class="col-md-6"></div>
                        <div class="col-md-4">
                        <asp:Button ID="Button1" runat="server" Text="Message Us" CssClass="btn btn-primary" OnClick="Button1_Click" />
                            </div>
                        <br /><br />
                        </div>
                        </div>
                    <div class="container">
                     
                       <h4>Digital Signature Verification</h4>
                        <hr />
                        <p>Please download below two files and install to your computer to verify Digital Signature verified.</p>
                        <ul>
                            <li><a href="../../LankaSignFile/rootFile.rar" target="_blank" download>Root File</a></li>
                            <li><a href="../../LankaSignFile/IntermediateFile.rar" target="_blank" download>Intermediate File</a></li>
                        </ul>
                        <p>Installation Guide</p>
                        <ul>
                            <li><a href="../../LankaSignFile/help.pdf" target="_blank" download>installationguide.pdf</a></li>
                        </ul>
                        
                    </div>
               
                <%-- End of col-lg-11--%>
            </div>
            <%--End of Row--%>
        </div>
    </div>
        </div>
</asp:Content>
