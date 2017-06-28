<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TaxRegistration.aspx.cs" Inherits="DSCMS.TaxRegistration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Tax Registration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <small>Customer</small>
                </h1>
                <ol class="breadcrumb">
                    <li class="active">
                        <i class="fa fa-th-large"></i> Tax Registration
                    </li>
                </ol>
            </div>
        </div>
        <div class="container col-lg-12" runat="server" visible="false" id="ErrorMessage1" style="font-family: Cambria;">
                <%--Error Msg goes here--%>
            </div>
        <div class="container boxshadow">
            <div class="col-md-10 col-md-offset-1">
                <div class="row">
                    
                   
                   
                    <div class="col-lg-12">
                        <h2 class="page-header">
                            <small>Tax Type</small></h2>
                    </div>
               

                <div></div>
                <div class="panel panel-default panel-table">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col col-xs-7">
                                <div class="col-lg-12">
                                    <label class="control-label col-sm-2" for="email">SVat</label>
                                    <div class="col-sm-8">
                                        <asp:CheckBox ID="cbSVat" runat="server" />
                                    </div>
                                </div>

                            </div>

                            <div class="col col-xs-3 text-right" style="float: right">
                                <form action="#" method="get">
                                    <div class="input-group">
                                        <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                        <input class="form-control" id="system-search" placeholder="Search for" />
                                        <span class="input-group-btn">
                                            <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                        </span>
                                    </div>
                                </form>

                            </div>
                            <div class="col col-xs-2 text-right">
                            </div>

                        </div>
                    </div>

                    <div class="panel-body">

                        <div class="col-md-12 text-center">

                            <asp:GridView ID="gvTaxRegistration" runat="server" AutoGenerateColumns="False" CssClass="table  table-bordered  table-hover table-list-search" >
                                <Columns>
                                    <%-- <asp:BoundField HeaderText="Tax ID" DataField="TaxId1" SortExpression="TaxId1" />--%>
                                    <asp:BoundField HeaderText="Tax Code" DataField="TaxCode1" SortExpression="TaxCode1" />
                                    <asp:BoundField HeaderText="Tax Name" DataField="TaxName1" SortExpression="TaxName1" />
                                    <asp:BoundField HeaderText="Tax Persentage" DataField="TaxPercentage1" SortExpression="TaxPercentage1" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" onclick="changeTextValue(this)" />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Registration No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="RegistrationNo" runat="server" Enabled="true" ClientIDMode="Static"></asp:TextBox>
                                           
                                        </ItemTemplate>

                                    </asp:TemplateField>


                                </Columns>
                                 <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                            </asp:GridView>

                            
                        </div>
                    </div>
                </div>
                    </div>
                
                <div class="panel-footer">
                    <div class="row">
                        <div class="col col-xs-4">
                        </div>
                        <div class="col col-xs-8">
                            <div style="float: right">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Button1_Click" />

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
                            <script>
                                function changeTextValue(chk) {
                                    var currentTextID = $(chk).parents('tr').find('input[type="text"][id$="RegistrationNo"]');
                                    // alert(chk.checked);
                                    if (chk.checked == true) {
                                        currentTextID.attr("disabled", false);
                                    }
                                    else {

                                        currentTextID.attr("disabled", true);
                                    }
                                }



                            </script>
</asp:Content>
