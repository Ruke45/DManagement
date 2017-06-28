<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IssueCertificasteDetails.aspx.cs" Inherits="DSCMS.Views.Certificate.IssueCertificasteDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Document Cancellation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--   <div id="pop" runat="server" visible="false">
     <div style="position:fixed;margin-top:15%;width:100%;text-align:center;z-index:99999;background-color:#ff000000"></div>
    <div style="width:100%;height:110%;background-color:rgba(0, 0, 0, 0.81);z-index:9999;position:fixed;margin-left:-15px;margin-top:-60px">
        <div style="margin-left:5%;width:90%;background-color:white;height:80%;margin-top:5%;padding-left:8%">
        
          
            <div id="diviframe" runat="server" style="width:100%;margin:auto;height:90%;padding-top:5%"></div>
            <div class="row">
                <div class="col-md-10"></div>
                 <div class="col-md-2" style="padding:5px">
                     <asp:Button ID="btnCancel" runat="server" Text="Close" CssClass="btn btn-danger"  OnClick="Hide_Click" /></div>
            </div>
            <br />
        </div>
        
    </div>
        </div>--%>


     <div id="confermation" runat="server" visible="false">
     <div style="position:fixed;margin-top:15%;width:100%;text-align:center;z-index:99999;background-color:#ff000000"></div>
    <div style="width:100%;height:110%;background-color:rgba(0, 0, 0, 0.81);z-index:9999;position:fixed;margin-left:-15px;margin-top:-60px">
        <div style="margin-left:25%;width:50%;background-color:white;margin-top:15%;padding:5px;border-radius:10px">
          <%--  <embed src="sample-file (3).pdf" style="width:80%;margin-left:10%;height:100%" alt="pdf">--%>
          <h3>Confirmation</h3>
            <hr />
            <div id="div2" runat="server" style="margin:auto;padding-bottom:5%"></div>
             <hr />
            <div class="row">
               <div class="col-md-4" style="float:right">
               
                 
                     <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="btn btn-primary"  OnClick="FinalSubmit_Click" />
                     <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="btn btn-danger"  OnClick="Cancel_Click" />
           
                   </div> </div>
            <br />
      
        
    </div>
        </div>
    </div>
    
     <div class="row">
        <div class="col-lg-12" style="font-family: Cambria;">
            <h1 class="page-header">Document Cancellation
                           
            </h1>
            <br />
            <ol class="breadcrumb">
                <li class="active" style="font-family:Tahoma">
                    <i class="fa fa-dashboard"></i>Document Details
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
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Document Type</td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblDocType" runat="server" Text=""></asp:Label>

                            </td>


                        </tr>
                        <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Request Id</td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblRequestId" runat="server" Text=""></asp:Label>

                            </td>


                        </tr>
                        <tr>
                            <td style="width: 210px; font-weight: bold;" class="text-justify">Document No</td>
                            <td class="modal-sm" colspan="3">
                                <asp:Label ID="lblCertificateNo" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblDocID" runat="server" Text=""></asp:Label>
                            </td>

                        </tr>
                         <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Document Name </td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblCertificateName" runat="server" Text=""></asp:Label>

                            </td>


                        </tr>
                        <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Customer Name </td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>

                            </td>


                        </tr>
                         <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Approved Date</td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblApprovedDate" runat="server" Text=""></asp:Label>

                            </td>


                        </tr>
                         <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Expiry Date</td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblExpiryDate" runat="server" Text=""></asp:Label>

                            </td>


                        </tr>
                         <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Approved By</td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblApprovedBy" runat="server" Text=""></asp:Label>

                            </td>

                             
                        </tr>
                        <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Download Status</td>
                            <td style="height: 31px" colspan="3">
                                <asp:Label ID="lblDownload" runat="server" Text=""></asp:Label>

                            </td>

                             
                        </tr>
                         <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify"></td>
                            <td style="height: 31px" colspan="3">
                                <asp:Button ID="View" runat="server" Text="View Document" CssClass="btn btn-primary" OnClick="View_Click" />
                                   <asp:Label ID="lblPath" runat="server" Visible="false" ></asp:Label>
                                <asp:Label ID="lblCustomerId" runat="server" Visible="false" ></asp:Label>
                                 <asp:Label ID="lblmsg" runat="server" Visible="false" ></asp:Label>
                            </td>

                             
                        </tr>
                         <tr>
                            <td style="height: 31px; width: 149px; font-weight: bold;" class="text-justify">Remark</td>
                            <td style="height: 31px" colspan="3">
                                <div class="row">
                                <div class="col-md-8">
                                    <asp:DropDownList ID="drpRemark" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Reason--" Value="" />
                                    </asp:DropDownList>
                                 </div>
                                <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Submit_Click" />
                                  <asp:Button ID="Cancel" runat="server" Text="<< Back" CssClass="btn btn-warning" OnClick="Back_Click" />
                                 </div>
                                     </td>

                             
                        </tr>
                        
                        

                    </tbody>
                </table>
              <div>
                    
           
              </div>
            </div>

           
        </div>
    </div>

</asp:Content>
