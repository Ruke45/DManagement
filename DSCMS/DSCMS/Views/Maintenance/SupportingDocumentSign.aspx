<%@ Page Title="" Language="C#" AutoEventWireup="true"MasterPageFile="~/Master.Master" CodeBehind="SupportingDocumentSign.aspx.cs" Inherits="DSCMS.Views.Maintenance.SupportingDocumentSign" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">NCEDCOS | Certificate Co-ordinates
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
                                <i class="fa fa-cogs"></i> Document Signature Coordinates
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-9"> <h5>Signature Co-ordinates List</h5>
                
                  </div>
                    <div class="col col-xs-3 text-right">       
                      <form action="#" method="get">
                        <div >
                            <div class="col-sm-5" style="float:right">
                                <asp:Button ID="btnShow" runat="server" width="200" CssClass="btn btn-Secondary" style="display:none"  Text="Edit" />
            <asp:Button ID="btnShow2" runat="server"  style="fit-position:80%" CssClass="btn btn-primary" Text="Add New " />
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
                                  

                                  <asp:BoundField HeaderText="Supporting Document ID" Visible="true" DataField="SupportingDocument_Id"   SortExpression="Template_Name" ><ItemStyle Width="200px"></ItemStyle></asp:BoundField>
                                  <asp:BoundField HeaderText="Supporting Document Name" Visible="true" DataField="SupportingDocument_Name"   SortExpression="Template_Name" ><ItemStyle Width="200px"></ItemStyle></asp:BoundField>
                                   <asp:BoundField HeaderText="Lower Left X Cord" DataField="LLX_Cordinates" ItemStyle-HorizontalAlign="Right" SortExpression="Customer_Name" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                 <asp:BoundField HeaderText="Lower Left Y Cord" DataField="LLY_Cordinates" ItemStyle-HorizontalAlign="Right" SortExpression="Customer_Name" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                   <asp:BoundField HeaderText="Upper Right X co-ord" DataField="URX_cordinates" ItemStyle-HorizontalAlign="Right" SortExpression="Customer_Name" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                 <asp:BoundField HeaderText="Upper Right Y co-ord" DataField="URY_cordinates" ItemStyle-HorizontalAlign="Right" SortExpression="Customer_Name" ><ItemStyle Width="100px"></ItemStyle></asp:BoundField>
                                  
                                   
                                 <asp:TemplateField HeaderText = "Edit Option" ><ItemStyle Width="100px"></ItemStyle>
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-primary" runat="server" OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" style="display:none" OnClick="Delete_Click">Delete</asp:LinkButton>
                                       
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

</div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
                              <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" runat="server"
 TargetControlID="txtHeight" Enabled="false" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
 TargetControlID="txtWidth" Enabled="false" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
 TargetControlID="txtXCord" Enabled="false" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
 TargetControlID="txtYcord" Enabled="false" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>

<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Edit Signature Co-ordinates </h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                         
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer ID</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="TxtCustomerID" Enabled="false"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                      
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer Name</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtTemplateName" Enabled="false"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Upper Right X co-ordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtHeight"   name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div>
                                <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="rgxc" ControlToValidate="txtHeight" runat="server"
      ErrorMessage="Enter Height Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Upper Right Y co-ordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtWidth"   name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div>
                               <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtWidth" runat="server"
      ErrorMessage="Enter width Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Lower Left X Cordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtXCord"  name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div>
                              <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtXCord" runat="server"
      ErrorMessage="Enter X Cordinate Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>

                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Lower Left  Y Cordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtYcord"   name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div><div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtYcord" runat="server"
      ErrorMessage="Enter Y Cordinate Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
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
                            <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnTdelete"
    CancelControlID="btnCloseD" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" Width="600"  align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
          <div class="col-xs-5 text-left" >
        Delete Supporting Document</div>
        
      </div>
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label1" Font-Size="Medium" runat="server" Text="Are  You Sure Want to Delete this Record?"></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-primary" Width="150px" OnClick="btnDelete_Click" />
          <asp:Button ID="btnCloseD" runat="server" Text="No" Width="150px"  CssClass="btn btn-Secondary" />
      </div>
    </div>
</asp:Panel>



<!-- Modal -->
            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title"> Add Signature Co-ordinates </h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                         

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Supporting Document</label>
                            <div class="col-sm-1">
                                <asp:DropDownList ID="ddCustomerName" height="30" runat="server" Width="300" AppendDataBoundItems="true"><asp:ListItem Text="  " Value="" /></asp:DropDownList>
                            </div>
                        </div>

                                                                                <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddRejectCode" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
 
                       <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Upper Right X co-ordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtAHeight"   name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div>
                           <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtAHeight" runat="server"
      ErrorMessage="Enter Height Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Upper Right Y co-ordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtAWidth"   name="address3" CssClass="form-control" Width="280" runat="server" ItemStyle-HorizontalAlign="Right"></asp:TextBox>
                            </div>
                              <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtAWidth" runat="server"
      ErrorMessage="Enter width Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Lower Left X Co-ordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtAXcord"  name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div>
                              <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtAXcord" runat="server"
      ErrorMessage="Enter X cordinate Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Lower Left Y Co-ordinate</label>
                            <div class="col-sm-1">
                            <asp:TextBox ID="txtAYCord"   name="address3" CssClass="form-control" Width="280" runat="server"></asp:TextBox>
                            </div>
                              <div class="col-sm-9">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtAYCord" runat="server"
      ErrorMessage="Enter X cordinate Value Correctly " ForeColor="Red" Display="Dynamic" ValidationExpression="[0-9]*\.?[0-9]*"></asp:RegularExpressionValidator>
                               </div>
                        </div>
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroraddReasonName" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerrorr" ForeColor="Red" runat="server" Text=""></asp:Label>
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






