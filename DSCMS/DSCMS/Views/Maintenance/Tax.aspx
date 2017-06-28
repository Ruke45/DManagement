<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="Tax.aspx.cs" Inherits="DSCMS.Tax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">Tax
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
                                <i class="fa fa-dashboard"></i> Tax Maintenance
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-9"><h5>Tax Maintenance List</h5>
                
                  </div>
                    <div class="col col-xs-3 text-right">       
                      <form action="#" method="get">
                        <div class="input-group">
                            <div class="col-sm-5">
                            <asp:Button ID="btnShow" runat="server"  width="200" CssClass="btn btn-Secondary" style="display:none"  Text="Edit" />
            <asp:Button ID="btnShow2" runat="server"  width="200" CssClass="btn btn-primary" Text="Add new" OnClick="Addbutton_Click" />
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
                                 
                                 <asp:BoundField HeaderText="Tax Code" DataField="Tax_Code" SortExpression="Tax_Id" />
                                  <asp:BoundField HeaderText="Tax Name" DataField="Tax_Name" SortExpression="Tax_Id" />
                                   <asp:BoundField HeaderStyle-HorizontalAlign="Center" HeaderText="Tax Percentage"  DataField="Tax_Percentage" ItemStyle-HorizontalAlign="Right"  SortExpression="Tax_Id" />
                                  <asp:BoundField HeaderText="Tax Priority" DataField="Tax_Priority" ItemStyle-HorizontalAlign="Right"  SortExpression="Tax_Id" />

                                 <asp:TemplateField HeaderText = "Edit Option">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                       <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger" OnClick="Delete_Click">Delete</asp:LinkButton>
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>
                              </Columns>
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
            <cc1:FilteredTextBoxExtender ID="TextBox1_FilteredTextBoxExtender" runat="server"
Enabled="false" TargetControlID="txtTaxPercentages" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
Enabled="False" TargetControlID="txtAddTaxPercentage" FilterType="Numbers">
</cc1:FilteredTextBoxExtender>
            


            <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>


<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
            
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Edit Tax Data</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                          <div class="form-group">
                            
                            <div class="col-sm-8">
                            <asp:TextBox ID="TxteID"  name="address3"   style="display:none"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                          

                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Code</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtTaxCode"  name="address3" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-4">
                            <asp:Label ID="lblerrortxtTaxCode" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>

                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Name</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtTaxName"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label1" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
     

                          

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="taxercentage">Tax Percentage</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtTaxPercentages"   name="taxpercentage"   CssClass="form-control" runat="server"></asp:TextBox>
                             
                            </div>
                              <div class="col-sm-4">
                              <asp:RangeValidator ID="percentageRangeValidator" runat="server"
    ControlToValidate="txtTaxPercentages" Display="Dynamic"  
    ErrorMessage="Invalid Percentage" MaximumValue="100.00" MinimumValue="0.00" Forecolor="red"
    Type="Double">Please Enter a Decimal Value.</asp:RangeValidator></div>
                              
                        </div>
                            
                                                  

                         
                         
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Priority</label>
                            <div class="col-sm-1">
                            <asp:DropDownList ID="ddeTaxPriority" width="270" Height="30" runat="server" AppendDataBoundItems="true"><asp:ListItem Text="--Select Priority--" Value="" /></asp:DropDownList>
                            </div>
                        </div>

                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerrorTaxPriority" ForeColor="Red" runat="server" Text=""></asp:Label>
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
            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" Width="600" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
           <div class="col-xs-3 text-left" >
        Delete Tax</div></div>
        
      
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label2" Font-Size="Medium"  runat="server" Text="Are  You Sure,You Want to Delete this Record?"></asp:Label>
                         </div>
                    </div>       

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-primary" Width="150px" OnClick="btnDelete_Click" />
          <asp:Button ID="btnCloseD" runat="server" Width="150px" Text="No"  CssClass="btn btn-Secondary" />
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
        <h4 class="modal-title">Add Tax</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                          <asp:RegularExpressionValidator ID="Regex1" runat="server" Enabled="false" ValidationExpression="((\d+)((\.\d{1,2})?))$"
ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
ControlToValidate="txtAddTaxPercentage" />
                      
                        
                                                                                <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroraddTaxID" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Code</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtTaxCodeadd"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerroradddn" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Name</label>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtTaxNameadd"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblerrorTaxNameadd" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                          
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="taxercentage">Tax Percentage</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtAddTaxPercentage"   name="taxpercentage" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                              <div class="col-sm-4">
                                           <asp:RangeValidator ID="RangeValidator1" runat="server"
    ControlToValidate="txtAddTaxPercentage" Display="Dynamic"  
    ErrorMessage="Invalid Percentage" MaximumValue="100.00" MinimumValue="0.00" Forecolor="red"
    Type="Double">Enter value Correctly</asp:RangeValidator>

                                  </div>
                        </div>
                 

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblTaxPercentageAdd" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>

                           

                          
                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Tax Priority</label>
                            <div class="col-sm-1">
                            <asp:DropDownList ID="ddTaxPriorityadd" width="270" Height="30" runat="server" AppendDataBoundItems="true"><asp:ListItem Text="--Select Priority--" Value="" /></asp:DropDownList>
                            </div>
                        </div>
                         

                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                                
                            <asp:Label ID="lblerrorTaxPriorityadd" ForeColor="Red" runat="server" Text=""></asp:Label>
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
        

        



</asp:UpdatePanel>




</asp:Content>


