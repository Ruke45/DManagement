<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CustomerTaxAssign.aspx.cs" Inherits="DSCMS.Views.Customer.CustomerTaxAssign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Tax/Rate
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table td {
           padding-bottom: 0px !important;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-lg-12">
                <div class="row">

                    <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Customer</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-th-large"></i>Edit Customer Rate & Tax
                            </li>
                        </ol>
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
                                        <div class="col-lg-8">
                                    <asp:DropDownList CssClass="form-control" ID="drpCustomer" AutoPostBack="True"
                                        runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="drpCustomer_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select Customer Name--" Value="no" />
                                    </asp:DropDownList>
                                            </div>
                                        </div>
                                </div>
                                <div class="col col-xs-3 text-right">
                                </div>


                            </div>
                        </div>
                        
                        <div class="panel-body"  id="divcontent" Visible="false" runat="server" >
                             <div class="form-horizontal" role="form" style="font-family: Cambria;">
                                 <div class="row">
                             <div class="form-group" >
                                
                                    <label class="control-label col-md-2" for="email">SVAT Customer </label>
                                    <div class="col-md-2">
                                        <asp:RadioButtonList ID="RbtnSVAT" runat="server"  >
                                            <asp:ListItem Value="1" runat="server"> Yes</asp:ListItem>
                                            <asp:ListItem Value="0" runat="server"> No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                  <div class="col-md-7">
                                 <div style="float:right;padding-right: 26px;">
                                 <asp:Button ID="Button8" runat="server" Text="Save" CssClass="btn btn-primary" Width="200"   OnClick="Save_Click"/>
                                </div>
                                     </div>
                                 </div>
                                 </div>
                                 </div>
                            <div class="col-lg-12">
                               
                                <div class="row">
                                    <div class="col-md-3">
                                        <h4>Rates</h4>
                                    </div>
                                    <div class="col-lg-8">
                                       


                                            <div style="float: right;">
                                                <asp:Button ID="btRateShow" runat="server" Width="200" CssClass="btn btn-Secondary" Style="display: none" Text="Edit" />

                                                <asp:Button ID="btnRates" runat="server" Width="200" CssClass="btn btn-primary" Text="Add New Rate" />

                                            </div>
                                    </div>
                                </div>
                                
                            </div>
                            <asp:GridView ID="gvRate" runat="server"
                                CssClass="table table-sm table-bordered  table-hover table-list-search"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField HeaderText="Rate Code" DataField="RateId1" SortExpression="RateId1" />
                                    <asp:BoundField HeaderText="Rate Name" DataField="RateName1" SortExpression="RateName1" />
                                    <asp:BoundField HeaderText="Rate Value" DataField="Rates1" SortExpression="Rates1" />
                                    <asp:TemplateField HeaderText="Edit Option">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick="Rate_Edit_Click">Edit</asp:LinkButton>
                                            <%-- <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" OnClick="Delete_Click">Delete</asp:LinkButton>
                                            --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                 <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                            </asp:GridView>
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-md-3">
                                        <h4>
                                            Tax Method</h4>
                                       
                                          
                                    </div>
                                    <div class="col-lg-8">
                                        <div style="float: right;padding:5px">
                                            <asp:Button ID="btnShow" runat="server" Width="200" CssClass="btn btn-Secondary" Style="display: none" Text="Edit" />
                                             <asp:Button ID="btnShow1" runat="server" Width="200" CssClass="btn btn-Secondary" Style="display: none" Text="Edit" />
                                            <asp:Button ID="btnShow2" runat="server" Width="200" CssClass="btn btn-primary" Text="Add New Tax " />
                                        </div>
                                    </div>
                                </div>
                               
                                </div>
                        
                        <asp:GridView ID="gvTax" runat="server"
                            CssClass="table table table-bordered  table-hover table-list-search"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Tax Code" DataField="TaxCode1" SortExpression="TaxCode1" />
                                <asp:BoundField HeaderText="Tax Name" DataField="TaxName1" SortExpression="TaxName1" />
                                <asp:BoundField HeaderText="Percentage" DataField="TaxPercentage1" SortExpression="TaxPercentage1" />
                                <asp:BoundField HeaderText="Tax Registration No" DataField="TaxRegistrationNo1" SortExpression="TaxRegistrationNo1" />
                                <asp:TemplateField HeaderText="Edit Option">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick="Edit_Click">Edit</asp:LinkButton>
                                         <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" OnClick="Delete_Click">Delete</asp:LinkButton>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                        </asp:GridView>


                    </div>

                </div>

                <div class="row">
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-9">
                    </div>
                </div>

            </div>
             </form>
                            </div>
                       

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>


            <!-- ModalPopupExtender -->
          
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Style="display: none">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Edit Tax</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Tax Code</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtTaxCode" Enabled="false" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Tax  Name</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtTaxName" Enabled="false" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Percentage</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtTaxPercentage" Enabled="false" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Tax Registration No</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtRegNo" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-8">
                                    <%--  <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                                    --%>
                                </div>
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="UpdateRegNo" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
                    </div>
                </div>
            </asp:Panel>
            <!-- ModalPopupExtender -->


             <cc1:ModalPopupExtender ID="mp4" runat="server" PopupControlID="Panel5" TargetControlID="btnShow1"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Panel5" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Style="display: none">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Delete Tax</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">

                            <div class="form-group">
                                <h4>Do you want to delete That Record</h4>
                            </div>
                            <asp:Label ID="lblTaxId" runat="server" Text="Label"></asp:Label>
                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button6" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="DeleteTax" />
                        <asp:Button ID="Button7" runat="server" Text="Close" CssClass="btn btn-default" />
                    </div>
                </div>
            </asp:Panel>
            <!-- Modal -->
            

            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
                CancelControlID="Button2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Style="display: none">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add New Tax</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Tax Name</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="drpTax" CssClass="form-control"
                                        Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Tax Name--" Value="" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-8">
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Tax Registraton No</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtTaxReg" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-8">
                                    <%--<asp:Label ID="lblerrorReqNo" ForeColor="Red" Visible="false" runat="server" Text="">Required Field</asp:Label>
                                    --%>
                                </div>
                            </div>









                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSubmitA" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="AddTax" />
                        <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-default" />
                    </div>
                </div>
            </asp:Panel>




            <cc1:FilteredTextBoxExtender ID="check1" runat="server" Enabled="true" TargetControlID="txtRateValue1"
                FilterType="Numbers, Custom " ValidChars="."></cc1:FilteredTextBoxExtender>

            <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btRateShow"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Style="display: none">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Edit Rates</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">
                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Rate  Code</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtRateId" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Rate  Name</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtRateName" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Rate Value</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtRateValue1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>


                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="UpdateRate" />
                        <asp:Button ID="Button3" runat="server" Text="Close" CssClass="btn btn-default" />
                    </div>
                </div>
            </asp:Panel>
            <!-- ModalPopupExtender -->




              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="true" TargetControlID="txtRateValue"
                FilterType="Numbers, Custom " ValidChars="."></cc1:FilteredTextBoxExtender>
            <!-- Modal -->
         

            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel4" TargetControlID="btnRates"
                CancelControlID="Button2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Style="display: none">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Add New Rate</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal" role="form" style="font-family: Cambria;">

                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Rate Name</label>
                                <div class="col-sm-7">
                                    <asp:DropDownList ID="droRate" CssClass="form-control"
                                        Height="30" runat="server" AppendDataBoundItems="true">
                                        <asp:ListItem Text="--Select Rate --" Value="" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-8">
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-sm-3" for="email">Rate Value</label>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtRateValue" name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="email"></label>
                                <div class="col-sm-8">
                                    <%--<asp:Label ID="lblerrorReqNo" ForeColor="Red" Visible="false" runat="server" Text="">Required Field</asp:Label>
                                    --%>
                                </div>
                            </div>

                        </div>
                        <%--End of form-horizontal--%>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button4" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="AddRate" />
                        <asp:Button ID="Button5" runat="server" Text="Close" CssClass="btn btn-default" />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
        </Triggers>





    </asp:UpdatePanel>




</asp:Content>




