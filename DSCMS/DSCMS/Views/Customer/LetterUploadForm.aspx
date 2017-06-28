<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LetterUploadForm.aspx.cs" Inherits="DSCMS.Views.Customer.LetterUploadForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
     NCEDCOS | Letter
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
                            <i class="fa fa-th-large"></i> Customer Registration Letter
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

               

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">


                        <div class="form-group">
                            <label class="control-label col-sm-5" for="email">Copy Of Business Registration</label>
                            <div class="col-sm-4">
                                <asp:FileUpload ID="btnRegistration" runat="server" />
                            </div>
                            <div class="col-sm-3">
                                
                                <asp:Label ID="Label1" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="control-label col-sm-5" for="email">Request Letter</label>
                            <div class="col-sm-4">
                                 <asp:FileUpload ID="btnRequestLetter" runat="server" />
                                </div>
                            <div class="col-sm-3">
                                <div> <asp:Label ID="Label2" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label></div>
                               
                            </div>
                        </div>

                           <div class="form-group">
                            <label class="control-label col-sm-5" for="email"></label>
                            <div class="col-sm-4">
                             </div>
                            <div class="col-sm-3">
                                <asp:Button ID="btnsave" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="btnsave_Click"  />
                            </div>
                        </div>
         
                   </div>
                </div>
    

        
            <%--End of Row--%>
        </div>
            </div>
    </div>
</asp:Content>