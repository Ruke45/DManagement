<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewUploadForm.aspx.cs" Inherits="DSCMS.Views.Customer.ViewUploadForm" %>
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
          <div class="col-md-10 col-md-offset-1 ">

                    <div class="panel panel-default panel-table boxshadow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col col-xs-9">
                                    <div class="row">
                                        <div class="col-lg-3">
                                    <label class="control-label" style="color:black">Customer Name</label>
                                            </div>
                                        <div class="col-lg-8" style="z-index:999999">
                                    <asp:DropDownList CssClass="form-control" ID="drpCustomer" AutoPostBack="true" 
                                        runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="drpCustomer_SelectedIndexChanged" >
                                        <asp:ListItem Text="--Select Customer Name--" Value="no" />
                                    </asp:DropDownList>
                                            </div>
                                        </div>
                                </div>
                                <div class="col col-xs-3 text-right">
                                </div>


                            </div>
                        </div>
                        
                      
                        </div>
              </div>
         
        <div class="row">
            <div class="container boxshadow">

               

                <div class="col-lg-11">
                    <div class="form-horizontal" role="form" style="font-family: Cambria;">


                        <div class="form-group">
                            <label class="control-label col-sm-5" for="email">Copy Of Business Registration</label>
                             <div class="col-sm-1">
                                 <asp:Button ID="btnViewRegLetter" Visible="false" CssClass="btn btn-primary" runat="server" Text="View" OnClick="btnViewRegLetter_Click" />
                             </div>
                            <div class="col-sm-4">
                            <div id="regLetter" runat="server"></div>
                            </div>
                            
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-5" for="email">Request Letter</label>
                               <div class="col-sm-1">
                                   <asp:Button ID="btnReqLetter" CssClass="btn btn-primary" Visible="false"  runat="server" Text="View" OnClick="btnReqLetter_Click" />
                               </div>
                            <div class="col-sm-4">
                                 <div id="reqletter" runat="server"></div>
                                </div>
                          
                               </div>
                  
                         
                        </div>
         
                
    

        
            <%--End of Row--%>
        </div>
            </div>
         </div>
    </div>
</asp:Content>
