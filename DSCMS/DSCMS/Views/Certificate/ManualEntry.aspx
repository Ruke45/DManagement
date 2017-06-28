<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ManualEntry.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.Views.Certificate.ManualEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Data Entry Pending List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../../js/jquery-1.11.1.min.js"></script>
            <script>
                $(document).ready(function () {
                    $(".datepicker1").datepicker({ format: 'yyyy/mm/dd' })
                });
    </script>
    <script type="text/javascript">
        function ShowModalPopup() {
            $find("mpe").show();
            return false;
        }
        function HideModalPopup() {
            $find("mpe").hide(); zz
            return false;
        }
    </script>

   


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Maintenance</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-th-large"></i>   Certificate Data Entry Pending List
                            </li>
                        </ol>
                    </div>
                </div>
    
        <div class="col-md-10 col-md-offset-1 ">

            <div class="panel panel-default panel-table boxshadow">
              <div class="panel-heading">
                <div class="row">
                                      <div class="col col-xs-9"><h5>Data  List </h5>
                
                  </div>
                    <div class="col col-xs-3 text-right">       
                      <form action="#" method="get">
                        <div class="input-group">
                            <div class="col-sm-5" style="float:right">
                            <asp:Button ID="btnShow" runat="server" Width="200" CssClass="btn btn-Secondary" Text="Edit" style="display:none" visible="false"/>
                                <asp:Button ID="btnTdelete" runat="server" Width="200" CssClass="btn btn-Secondary"  Text="Edit" style="display:none" visible="false"/>
            <asp:Button ID="btnShow2" CssClass="btn btn-primary" Width="200" runat="server"  Text="Edit  Data" style="display:none" />
                                <asp:Button ID="Button2" CssClass="btn btn-primary"  runat="server"  Text="Edit  Data"  OnClick="redirrect"/>
                            
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
                                 <asp:BoundField HeaderText="Request Id" DataField="Request_Id" SortExpression="Request_Id" />
                                  <asp:BoundField HeaderText="Customer Id" DataField="Customer_Id" SortExpression="Request_Id" />
                                   <asp:BoundField HeaderText="Certificate Name" DataField="Certificate_Name" SortExpression="Request_Id" />

                                  <asp:TemplateField Visible="false">
                                      <ItemTemplate>
                                          <asp:Label ID ="lblCertificatePath" runat="server" Text='<%#Eval("Certificate_Path") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>
                                  
                                   
                                 <asp:TemplateField HeaderText = "Edit Option"><ItemStyle Width="18%"></ItemStyle>
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary"  OnClick="LinkButton1_Click">Add</asp:LinkButton>
                                        <asp:LinkButton ID="LinkDelete" runat="server" CssClass="btn btn-danger" style="display:none" OnClick="Delete_Click">Delete</asp:LinkButton>
                                       
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
 <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


<!-- ModalPopupExtender -->

<asp:Panel ID="Panel1" runat="server" Width="1300px"   CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content--><div id="Div1" runat="server"  style="max-height:600px; padding-top:30px; overflow: auto;">
    <div class="modal-content">
        <div class="modal-header">
        <h4 class="modal-title">Complete Certificate Details</h4>
      </div>
      <div class="modal-body">

          <iframe name="myIframe" id="myIframe" width="950px" height="400px" runat ="server" ></iframe>
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                           <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Certificate No</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="ReqID" ReadOnly="true" BackColor="White" CssClass="form-control" Enabled="false" runat="server" ></asp:TextBox>
                        </div>
                        <label class="control-label col-sm-2" for="email">Customer ID</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtCustID" ReadOnly="true" BackColor="White" CssClass="form-control" Enabled="false" runat="server"  ></asp:TextBox>
                        </div>
                    </div>
                      
                        
                          
                                                      <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label2" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>
                      <div class="container boxshadow">
            <div class="col-lg-11">
                				
                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="col-lg-12" style="font-family: Cambria;">
                        <h1 class="page-header">
                           <%-- <small>Certificate Details (Certificate Request ID : <asp:Label ID="lblRequestID" runat="server" Text=""></asp:Label>)</small>--%>
                        </h1>
                    </div>
                    
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignor / Exporter</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExporter"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblExporter" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                   <%-- <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            
                         </div>
                    </div>--%>
                   

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Consignee</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtConsignee"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                             <asp:Label ID="lblConsignee" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    


                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Invoice No</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoNo"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblInvoNo" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                        <label class="control-label col-sm-2" for="email">Invoice Date</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoDate"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblInvoDate" ForeColor="Red" runat="server" Text=""></asp:Label>

                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                CssClass="cal_Theme1"
                                TargetControlID="txtInvoDate"
                                Format="MM/dd/yyyy"
                                PopupButtonID="Image1" />

                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Country Of Origin</label>
                      <%--  <div class="col-sm-4">
                            <asp:TextBox ID="txtCountryOfOrigin"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>--%>
                         <div class="col-sm-4">
                            <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:Label ID="lblCountry" ForeColor="Red" runat="server" Text=""></asp:Label>

                        </div>
                        <label class="control-label col-sm-2" for="email">Vessel</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtVessel"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblVessel" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                     

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Loading</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPortLoading"  BackColor="White"  CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblPortLoading" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Port of Discharge</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPortDischrg"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblPortDischrg" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Place of Delivery</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPlcofDelivry"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblPlcofDelivry" ForeColor="Red" runat="server" Text=""></asp:Label>

                        </div>
                    </div>

                   
                   
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Total Quantity</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtTotQunatity"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblTotQunatity" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                  <%--  </div>
                    <div class="form-group">--%>
                        <label class="control-label col-sm-2" for="email">Total Invoice Value</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtInvoVal"  BackColor="White" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Label ID="lblInvoVal" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                     <div class="col-lg-12">
                        <h1 class="page-header">
                            <small>Certificate Items</small>
                        </h1>
                    </div>
                    <div class="container">
                        <div class="col-lg-11">

                            <div class="panel panel-default panel-table boxshadow">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col col-xs-7">
                                            <h3 class="panel-title">Items</h3>

                                        </div>
                                        <div class="col col-xs-3 text-right">
                                            <%--<div>
                                                <div class="input-group">
                                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                                    <input class="form-control" id="system-search" name="q" placeholder="Search for"/>
                                                    <span class="input-group-btn">
                                                        <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                                    </span>
                                                </div>
                                            </div>--%>
                                        </div>
                                        <div class="col col-xs-2 text-right">
                                            <%--<button type="button" class="btn btn-sm btn-default btn-create" id="btnShow" onclick="AddNewItem" runat="server" data-toggle="modal" data-target="#myModal">Create New</button>--%>
                                            <asp:Button ID="btnAddNewItem" CssClass="btn btn-sm btn-default btn-create" runat="server" Text="Add Good / Item" OnClick="btnAddNewItem_Click" />
                                        </div>

                                    </div>
                                </div>
                                <div class="panel-body">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView2" runat="server"
                                                CssClass="table  table-bordered  table-hover table-list-search"
                                                AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="GoodItem" DataField="GoodItem1" SortExpression="GoodItem1" />
                                                    <asp:BoundField HeaderText="Shipping Mark" DataField="ShippingMark1" SortExpression="ShippingMark1" />
                                                    <asp:BoundField HeaderText="Package Type" DataField="PackageType1" SortExpression="PackageType1" />
                                                    <asp:BoundField HeaderText="Summary" DataField="SummaryDesc1" SortExpression="SummaryDesc1" />
                                                    <asp:BoundField HeaderText="Qunatity" DataField="Quantity1" SortExpression="Quantity1" />
                                                    <asp:BoundField HeaderText="HS Code" DataField="HSCode1" SortExpression="HSCode1" />
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="linkEditItem" runat="server" OnClick="linkEditItem_Click">Remove</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <%--<asp:PostBackTrigger ControlID="btnAddItem"  />--%>
                                            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                </div>
                        </div>
                    </div>
                    </div>
                
                                <div class="panel-footer">
                                    <div class="row">
                                    </div>
                                </div>
                            


                     <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
                         </div>
                    </div>


                    
                </div>
            </div>
            <%--End of form-horizontal--%>
        </div>


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      
      <div class="modal-footer">
          <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" Width="200px" OnClick="btnSubmit_Click" />
          <asp:Button ID="btnClose" runat="server" Text="Close"  CssClass="btn btn-Secondary" OnClick="btnClose_Click" />
      </div>
    </div>
      </div>  
</asp:Panel>
            <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnTdelete"
    CancelControlID="btnCloseD" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
<asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" Width="600" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content" >
      <div class="modal-header">
           <div class="col-xs-3 text-left" >
        Delete Package</div></div>
      
        
      
      <div class="modal-body" >
                      <div class="form-horizontal" role="form" style="font-family:Cambria;">
                      
                         
                           

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="email"></label>
                            <div class="col-sm-8">
                            <asp:Label ID="Label1" Font-Size="Medium"  runat="server" Text="Are  You Sure ,You Want to Delete this Record?"></asp:Label>
                         </div>
                    </div>
                      


                        

                        

                         

                      </div> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-primary" Width="150px" OnClick="btnDelete_Click" />
          <asp:Button ID="btnCloseD" runat="server" Text="No" Width="150px" CssClass="btn btn-Secondary" OnClick="btnClose_Click" />
      </div>
    </div>
</asp:Panel>

<!-- ModalPopupExtender -->

<!-- Modal -->
            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow2"
    CancelControlID="Button4" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

<asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
       

                             <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Add New Item Details</h4>

            </div>
            <div class="modal-body">
                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Good/Item</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Shipping Mark</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Package Type</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="drpPakgType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Summary/Desc</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSummary" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Quantity</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtQuntity" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email" id="lblHScode" runat="server">HS Code</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email"></label>
                        <div class="col-sm-8">
                            <asp:Label ID="Label3" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--End of form-horizontal--%>
            </div>
            <div class="modal-footer">

                <asp:Button ID="btnAddItem" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddItem_Click" />
                <asp:Button ID="Button3" runat="server" Text="Close" CssClass="btn btn-default" OnClick="return_Click"  />
            <asp:Button ID="Button4" runat="server"  style="display:none" Text="terminateClose" CssClass="btn btn-default" OnClientClick="return HideModalPopup()" />
            </div>
        </div>
                 
           


</asp:Panel>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddItem" EventName="Click" />
        </Triggers>

        



</asp:UpdatePanel>
    



</asp:Content>



