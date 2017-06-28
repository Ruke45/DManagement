<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="UnitChargeMaintenance.aspx.cs" Inherits="DSCMS.UnitChargeMaintenance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">NCEDCOS | Unit Charge Maintenance
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Maintenance</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-cogs"></i> Template Unit Charge
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-9"> <h5>Template Unit Charge List</h5>
                
                  </div>
                    <div class="col col-xs-3 text-right">       
                      <form action="#" method="get">
                        <div class="input-group">
                            <div class="col-sm-5">
                                <asp:Button ID="btnShow" Width="200" CssClass="btn btn-Secondary" runat="server"  style="display:none"   Text="Edit" />
            <asp:Button ID="btnShow2" Width="200" CssClass="btn btn-primary" runat="server" Text="Add New " />
                                   <asp:Button ID="btnTdelete" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>

                           </div>
                        </div>
                      </form>
                
                  </div>
                  

                </div>
              </div>
              <div class="panel-body">
                          <asp:GridView ID="GridView1" BorderStyle="NotSet" runat="server" AllowPaging="True" PageSize="10"
                              CssClass="table  table-bordered  table-hover table-list-search" OnPageIndexChanging="grdData_PageIndexChanging"
                              AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
 >
                              <Columns>
                                  <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblTemplateID" runat="server" Text='<%#Eval("Template_Id") %>'></asp:Label>
 
                                      </ItemTemplate>
                                      
                                  </asp:TemplateField>
                                 <asp:BoundField HeaderText="Template Name" DataField="Template_Name" SortExpression="Template_Name" />
                                 
                                  <asp:BoundField HeaderText="UnitCharge Value"  DataField="UnitCharge_Value" SortExpression="Template_Name" ItemStyle-HorizontalAlign="Right" ><ItemStyle Width="200px"></ItemStyle></asp:BoundField>
                                   
                                 <asp:TemplateField HeaderText = "Edit Option">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                       
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


            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


<!-- ModalPopupExtender -->
             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
Enabled="false" TargetControlID="txtUnitChargeValue" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>

<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Edit Template Charge</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Template ID</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtTemplateID" Enabled="false"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Unit Charge Value</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtUnitChargeValue"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="btnSubmit_Click" />
          <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default" />
      </div>
    </div>
</asp:Panel>
<!-- ModalPopupExtender -->


                                    
           




<!-- Modal -->
                  <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" runat="server"
Enabled="false" TargetControlID="txtUnitChargeAdd" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>
            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Add Template Charge</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                        
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Template Name</label>
                            <div class="col-sm-1">
                                <asp:DropDownList ID="ddTemplateID" height="30" runat="server" Width="300" AppendDataBoundItems="true"><asp:ListItem Text="  " Value="" /></asp:DropDownList>
                            </div>
                        </div>
                                                                                <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddid" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Unit Charge</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txtUnitChargeAdd"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                               <div class="col-sm-4">
                               <asp:RegularExpressionValidator ID="rgx" ControlToValidate="txtUnitChargeAdd" runat="server"
      ErrorMessage="Enter Unit Charge Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddn" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmitA" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="btnSubmitA_Click" />
          <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-default" />
      </div>
    </div>
</asp:Panel>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
        </Triggers>

        



</asp:UpdatePanel>




</asp:Content>



