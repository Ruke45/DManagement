

<%@ Page Title=""  Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master"  CodeBehind="ManualCert.aspx.cs" Inherits="DSCMS.Views.Certificate.ManualCert" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">NCEDCOS | Offline certificates
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Certificate</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-cogs"></i> Offline  Certificate Details
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">
             <div class="form-horizontal" role="form" style="font-family: Cambria;">
              <div class="row" id="div3">
                   
                 
                    <label class="control-label col-md-1" for="email">Ref No</label>
                          
                    <div class="col-md-2">
                        <asp:TextBox ID="txtCertificateNo"   enabled="true"  CssClass="form-control" runat="server"></asp:TextBox>
    
                    </div>

                         
                   <label class="control-label col-md-2" runat="server" id="lblcusid" for="email" text="">Customer Name</label>
                             
                    <div class="col-md-5" runat="server" id="divhid">
                       <div >
                                    <asp:DropDownList ID="ddUserID" Height="32px" CssClass="form-control"   runat="server" AppendDataBoundItems="true"><asp:ListItem Text="All" Value="" /></asp:DropDownList>
                           </div>

                               
                      </div>
                         <div class="col-md-2">
                             <label class="control-label col-md-5" runat="server" id="Label4" for="email" text=""></label>
                             <div class="col-sm-5" >
                         <asp:Button ID="Button4" CssClass="btn btn-primary"  runat="server"  Text="Search" OnClick="CertificateID_Click" />
                       
                    </div> </div>
                   
               
                        </div>
</div>
            
            <br/>
            <br />





            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                  <div class="col col-xs-8"><h5>Certificate List</h5>
                
                  </div>
                    <div class="col col-xs-4 text-right">       
                     
                        <div >
                            <div class="col-sm-5" style="float:right">
                            <asp:Button ID="btnShow" runat="server"  width="200" CssClass="btn btn-Secondary" style="display:none"  Text="Edit" />
            <asp:Button ID="btnShow2" runat="server"  CssClass="btn btn-primary" Text="Add new" OnClick="Addbutton_Click" />
                         <asp:Button ID="btnTdelete" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>
                        </div>
                            </div>
                     
                
                  </div>
                  

                </div>
              </div>
              <div class="panel-body">
                          <asp:GridView ID="GridView1" BorderStyle="NotSet" runat="server" AllowPaging="True" PageSize="10"
                              CssClass="table  table-bordered  table-hover table-list-search" OnPageIndexChanging="grdData_PageIndexChanging"
                              AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
 >
                              <Columns>


                                 <asp:BoundField HeaderText="Customer Name" DataField="Customer_ID" SortExpression="Customer_ID" />
                                 <asp:BoundField HeaderText="Reference No" DataField="Refference_No" SortExpression="Tax_Id" />
                                  <asp:BoundField HeaderText="Issued Date" DataField="Issued_Date" SortExpression="Tax_Id" />
                                   <asp:BoundField HeaderStyle-HorizontalAlign="Center" HeaderText="Exporter Invoice No"  DataField="ExporterInvoice_No"   SortExpression="Tax_Id" />
                                  <asp:BoundField HeaderText="Item Description" DataField="Item_Description"  SortExpression="Tax_Id" />
                                  <asp:BoundField HeaderText="Is Invoiced" DataField="Req_No"  SortExpression="Tax_Id" />

                                    <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblCusID" runat="server" Text='<%#Eval("Cust_ID") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>


                                 <asp:TemplateField HeaderText = "Edit Option">
                                   <ItemTemplate>

                                        <asp:Label ID ="lblIDs" runat="server" ></asp:Label>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">Edit</asp:LinkButton>
                                       <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger" OnClick="Delete_Click">Delete</asp:LinkButton>
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>
                              </Columns>
                              <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                          </asp:GridView>

               
            </div>

</div>

	<%--<div class="row">
        <div class="col-md-3">

        </div>
		<div class="col-md-9">
    	   
		</div>
	</div>--%>
            
</div>
            </div>
           
            


            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>


<!-- ModalPopupExtender -->
<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
            
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none" >
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Edit Certificate Data</h4>
      </div>
      <div class="modal-body">
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                          <div class="form-group">
                            
                            <div class="col-sm-8">
                            <asp:TextBox ID="TxteID"  name="address3"   style="display:none"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                          

                          <div class="form-group">
                              <label class="control-label col-sm-2" for="email">Reference No</label>
                              <div class="col-sm-4">
                                  <asp:TextBox ID="txtRefferenceNo" name="address3" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                              </div>
                              <div class="col-sm-4">
                            <asp:Label ID="lblerrortxtTaxCode" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                          </div>
                         

                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Issued Date</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtIssuedDate"  name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                                   <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtIssuedDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />
                               
                                <div class="col-sm-8">
                            <asp:Label ID="Label1" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                        </div>
                         

                          

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="taxercentage">Invoice No</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoiceNo"     CssClass="form-control" runat="server"></asp:TextBox>
                             
                            </div>
                             
                              
                        </div>
                            
                                                  

                         
                         
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Item Description</label>
                            <div class="col-sm-1">
                            <asp:DropDownList ID="ddeItemDescription" width="270" Height="30" runat="server" AppendDataBoundItems="true">
<asp:ListItem Text="" Value="" />
                                <asp:ListItem Text="CO" Value="C" />
                                <asp:ListItem Text="Other Documents" Value="O" />
                                <asp:ListItem Text="Invoices" Value="I" />


                            </asp:DropDownList>
                            </div>
                        </div>
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer</label>
                            <div class="col-sm-1">
                            <asp:DropDownList ID="ddCustomer" width="270" Height="30" runat="server" AppendDataBoundItems="true">
<asp:ListItem Text="" Value="" />
                               

                            </asp:DropDownList>
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
        Delete Data</div></div>
        
      
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
            <cc1:ModalPopupExtender  ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Add Certificate Data</h4>
      </div>
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                          <%--<asp:RegularExpressionValidator ID="Regex1" runat="server" Enabled="false" ValidationExpression="((\d+)((\.\d{1,2})?))$"
ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
ControlToValidate="txtAddTaxPercentage" />--%>
                           <div class="form-group">

                                <asp:Label ID="Label3" ForeColor="Black" runat="server" Text=""></asp:Label>

                               </div>
                          
                          <div class="form-group">
                              <label class="control-label col-sm-2" for="email"></label>
                              <div class="col-sm-8">
                                  <asp:Label ID="lblerroraddTaxID" ForeColor="Red" runat="server" Text=""></asp:Label>
                                  <asp:TextBox ID="TextBox1"  name="address3" CssClass="form-control"  style="display:none" runat="server"></asp:TextBox>
                              </div>
                          </div>

                          <div class="form-group">
                              <label class="control-label col-sm-2" for="email">Reference No</label>
                              <div class="col-sm-4">
                                  <asp:TextBox ID="txtARefferenceNo"   name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                              </div>
                              <div class="col-sm-8">
                                  <asp:Label ID="lblerroradddn"  ForeColor="Red" runat="server" Text=""></asp:Label>
                              </div>
                          </div>
                         
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Issued Date</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtAIssuedDate"     name="address3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                  <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtAIssuedDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />

                               <div class="col-sm-8">
                            <asp:Label ID="lblerrorTaxNameadd" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                        </div>
                                             
                          
                          <div class="form-group">
                            <label class="control-label col-sm-2" for="taxercentage">Invoice No</label>
                            <div class="col-sm-4">
                            <asp:TextBox ID="txtAInvoiceNo"      name="taxpercentage" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                               <div class="col-sm-8">
                            <asp:Label ID="lblTaxPercentageAdd" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                        </div>
                 

                         
                           

                          
                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Item Description</label>
                            <div class="col-sm-1">
                            <asp:DropDownList ID="ddAItemDescription"    width="270" Height="30" runat="server" AppendDataBoundItems="true"><asp:ListItem Text="" Value="" />
                                  <asp:ListItem Text="CO" Value="C" />
                                <asp:ListItem Text="OtherDocuments" Value="O" />
                                <asp:ListItem Text="Invoices" Value="I" />

                            </asp:DropDownList>
                            </div>
                        </div>

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="email">Customer</label>
                            <div class="col-sm-4">
                            <asp:DropDownList ID="ddAcustomer"    width="270" Height="30" runat="server" AppendDataBoundItems="true">
<asp:ListItem Text="" Value="" />
                               

                            </asp:DropDownList>
                            </div>
                                 <div class="col-sm-8" style="margin-left:-46px">
                                
                            <asp:Label ID="lblerrorTaxPriorityadd" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                        </div>


                         
                          
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="btnSubmitA" runat="server" Text="Submit"   CssClass="btn btn-primary" Width="200px" OnClick="btnSubmitA_Click" />
          <asp:Button ID="Button2" runat="server" Text="Close"   CssClass="btn btn-default" />
      </div>
    </div>
</asp:Panel>
            </ContentTemplate>
        

        



</asp:UpdatePanel>




</asp:Content>








