<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertifcateDownload.aspx.cs" MasterPageFile="~/Master.Master" Inherits="DSCMS.Views.Certificate.CertifcateDownload" %>
<%@ MasterType VirtualPath="~/Master.Master" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Download Certificate
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="diviframe" runat="server"   style="width:100%;margin:auto;height:90%;padding-top:5%;display:none">
             </div>

       <asp:Button ID="Btnsd" runat="server" width="200" CssClass="btn btn-Secondary" style="display:none" Text="Download" />
 <style>
        .possitions {
            float:right;
        }
    </style>

    <script>
        var val1 = 0;
        var val2 = 0;
        function showcal1() {
            if (val1 == 0) {
                document.getElementById("cal1").style.display = "block";
                val1 = 1;
            }
            else {
                document.getElementById("cal1").style.display = "none";
                val1 = 0;
            }
        }
        function showcal2() {
            if (val2 == 0) {
                document.getElementById("cal2").style.display = "block";
                val2 = 1;
            }
            else {
                document.getElementById("cal2").style.display = "none";
                val2 = 0;
            }
        }
</script>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    


    <script type='text/javascript'>
        function printTrigger() {
            //document.getElementById("diviframe").style.display="none";
            var PDF = document.getElementById("iFramePdf");
            PDF.focus();
            PDF.contentWindow.print();

        }

        function LoadOnce() {

            window.location.reload();


        }


        function setFormSubmitToFalse() {
            setTimeout(function () { _spFormOnSubmitCalled = false; }, 3000);
            window.location.reload();
            return true;
        }
</script>




     <script type='text/javascript'>      //<![CDATA[
         var dow = 0;
         $(window).load(function () {
             $(document).ready(function () {
                 $('#Btnsd').click(function () {
                     dow = 1;
                     html2canvas($("#a"), {
                         onrendered: function (canvas) {

                             var imgData = canvas.toDataURL('image/png');
                             $("#imgRes").attr("src", imgData);
                             var doc = new jsPDF('p', 'mm');
                             doc.addImage(imgData, 'PNG', 10, 10);
                             doc.save('TaxInvoice.pdf');

                             window.location.href = "CertifcateDownload.aspx";
                         }

                     });

                 });

             });


         });//]]> 

        

  

    </script>

 
   
    <%--<iframe name="myIframe" id="Iframe1" width="950px" height="400px" runat ="server" src="~/Uploads/9.26.20162.52.45PM.pdf" ></iframe>--%>
    
        
        <div class="col-lg-12">
                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>Certificate</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-th-large"></i>Approved Certificate Download
                            </li>
                        </ol>
                    </div>
                </div>
            <div class="col-md-10 col-md-offset-1">
                 <div class="form-horizontal" role="form" style="font-family: Cambria;">
              <div class="row">
                    <div class="group">
                    <label class="control-label col-md-2" for="email">From Date</label>

                    <div class="col-md-2">
                       
                                 <table><tr><td> <asp:TextBox Enabled="false" ID="txtFromDate" runat="server" Width="100px"  CssClass="form-control"></asp:TextBox></td>
                            <td><input type="button" onclick="showcal1()" value="..." class="form-control" /></td>
                               </tr></table>
                            <div id="cal1" style="z-index:999;display:none;position:absolute">
                           <asp:Calendar ID="Calendar2"  runat="server" OnSelectionChanged="Page_Load" Format="MM/dd/yyyy"></asp:Calendar>
                                </div>
                      
                        <div class="col-ms-3" style="width: 150px">
                              <asp:RequiredFieldValidator ID="RvFromDate" runat="server" ControlToValidate="txtFromDate" ErrorMessage="From Date is a Required." ForeColor="Red"></asp:RequiredFieldValidator>
                            
                                <asp:Label ID="labstartdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                        </div>
                    </div>

                          
                    <label class="control-label col-md-1" for="email">To Date </label>

                    <div class="col-md-2">
                       
                                     <table><tr><td>
                             <asp:TextBox ID="txtTodate" Width="100px" Enabled="false" runat="server"  CssClass="form-control"></asp:TextBox></td>
                            <td> <input type="button" onclick="showcal2()" value="..." class="form-control"/>
                                </td></tr></table>
                            <div id="cal2" style="z-index:999;display:none;position:absolute">
                             <asp:Calendar ID="Calendar3"   runat="server"  OnSelectionChanged="Page_Load" Format="MM/dd/yyyy"></asp:Calendar>
                            </div>
                          
                      
                      
                        <div class="col-ms-3" style="width: 100px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTodate" ErrorMessage="From Date is Required." ForeColor="Red"></asp:RequiredFieldValidator>

                             <asp:Label ID="labdatevalidation" runat="server" Visible="false" ForeColor="Red" />
                        </div>
                    </div>
                        <div class="col-md-3"  >

                         <label class="control-label col-md-12" for="email">Stamp Applied</label>
                            </div>
                    <div class="col-md-1"  >
                            <asp:DropDownList ID="ddseal"  runat="server" AppendDataBoundItems="true"  CssClass="form-control">
                                <asp:ListItem Text="All" Value="All" Selected="True" ></asp:ListItem>                       
                               <asp:ListItem Value="True">Yes</asp:ListItem>
                                  <asp:ListItem Value="False">No</asp:ListItem>
                               
      

                            </asp:DropDownList>
                           
                         
                        </div>
                   
               
                        </div>
</div>
                <div class="row" style="padding-bottom:10px">
                     <div class="group" >
                          <label class="control-label col-md-2" for="email">Ref No</label>
                      <div class="col-md-3">
                                  <asp:TextBox ID="txtCertificateNo"   enabled="true"  CssClass="form-control" runat="server"></asp:TextBox>
    
                          </div>
                         
                                <label class="control-label col-md-2" runat="server" id="lblcusid" for="email" text="">Customer Name</label>
                      <div class="col-md-4">
                                 <asp:DropDownList ID="ddUserID" Height="32px" CssClass="form-control"   runat="server" AppendDataBoundItems="true"><asp:ListItem Text="All" Value="" /></asp:DropDownList>
                           
                          </div>

                          

                         </div>
                    <br/><br/><br/>
                    <div class="group" >

                        <label class="control-label col-md-2" for="email">Invoice No</label>
                      <div class="col-md-3">
                                  <asp:TextBox ID="txtInvoiceNo"   enabled="true"  CssClass="form-control" runat="server"></asp:TextBox>
    
                          </div>
                        <label class="control-label col-md-5" for="email"></label>
                         <div class="col-md-1">  <asp:Button ID="Button4" runat="server"   CssClass="btn btn-primary"   Text="Search" OnClick="CertificateID_Click"   />
              </div>
                    </div  >         
                      
                </div>
              
                     </div>
                </div>
            </div>
    
        <div id="a" class="col-md-10 col-md-offset-1 ">
      
                <div>
                    <div>
                         
                            
          
            <div   class="panel panel-default panel-table boxshadow" style="width:120%;margin-left:-10%" >
              <div class="panel-heading">
                <div class="row">
                                      <div class="col col-xs-2"> 
                                          <h5>Certificate Download</h5>
                                           <asp:Label ID="Label1" ForeColor="Red" runat="server" Visible="false" Text="Your Download Date Expired"></asp:Label>
                
                  </div>
                                            <div class="col col-xs-6 ">
                          <%--  <form action="#" method="get">
                                <div class="input-group">
                                    <!-- USE TWITTER TYPEAHEAD JSON WITH API TO SEARCH -->
                                    <input class="form-control" id="system-search" name="q" placeholder="Search for"/>
                                    <span class="input-group-btn">
                                        <button type="submit" class="btn btn-default frm-btn"><i class="glyphicon glyphicon-search"></i></button>
                                    </span>
                                </div>
                            </form>--%>
                                                  
                      
                      <div class="col-md-4">
                               
                            </div>
                                                 <div class="col col-xs-4 ">

                                                     
                        </div>

                                                <div class="col-sm-1">
                                            

                    </div>



                        </div>


                    <div class="col col-xs-4 text-right">       
                     
                        <div class="input-group">
                              <asp:CheckBox id="CheckB1" 
                                  AutoPostBack="true"
                                  text="Select All"
  Enabled="true"
    Checked="false"
     TextAlign="Right"
     OnCheckedChanged="chkStatus_OnCheckedChanged"
 
     runat="server"/>&nbsp;&nbsp;&nbsp;
                          

                            <div class="btn-group">

                    
                           
             <asp:Button ID="btnShow2" runat="server"   CssClass="btn btn-primary" style="display:none"   Text="Test"   />
                                  
                                 <asp:Button ID="Button2" runat="server"   CssClass="btn btn-primary" style="display:none"  Width="100"   Text="Select All  " OnClick="select"  />
                                 <asp:Button ID="Button3" runat="server"   CssClass="btn btn-primary" style="display:none"  Width="100"   Text="Unselect All" OnClick="unselect"  />
                                <asp:Button ID="Button1" runat="server"   CssClass="btn btn-primary"   Width="100" OnClientClick="javascript:setFormSubmitToFalse()"   Text="Download " OnClick="down"  />
                                  <asp:Button ID="Button5" runat="server"   CssClass="btn btn-primary"  Width="100"   Text="Print " OnClick="PrintB"  />
                                 <asp:Button ID="Button6" runat="server"   CssClass="btn btn-primary"  Width="100"   Text="View " OnClick="View"  />

                            </div>
                        

                  
                </div>
                  </div>
                  

                </div>
              </div>
              <div class="panel-body" >
                          <asp:GridView ID="GridView1" BorderStyle="NotSet" runat="server"   AllowPaging="true" PageSize="50"
                              CssClass="table  table-bordered  table-hover table-list-search"  OnPageIndexChanging="grdData_PageIndexChanging" DataKeyNames="Request_Id"
                              AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="ReSelectSelectedRecords"
 >
                              <Columns>
                                    <asp:TemplateField Visible="false"  >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblTemplateID" runat="server" Text='<%#Eval("Certificate_Path") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>
                               <asp:BoundField HeaderText="Request ID" DataField="Request_Id" />
                                   <asp:BoundField HeaderText="Requested By" DataField="User_ID" />
                                  <asp:BoundField HeaderText="Date of Request" DataField="RequestedDate_" />
                                  <asp:BoundField HeaderText="Date of Approved " DataField="CretifiedDate_" />

                                  <asp:BoundField HeaderText="Reference No" DataField="Certificate_Name"  />
                                   <%--<asp:BoundField HeaderText="Consignee Name" DataField="Consignor_"  />--%>


                                  <asp:TemplateField runat="server" Visible="true"  HeaderText="Consignee's Name"  >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblTemplateIDe" runat="server" Text='<%#Eval("Consignor_") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                  <asp:TemplateField runat="server" Visible="true"  HeaderText="Customer Name"  >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblTemplateIDer" runat="server" Text='<%#Eval("CustomerName_") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                   

                                   <asp:BoundField HeaderText="Invoice Id" DataField="InvoiceId_"  />
                                  <asp:BoundField HeaderText=" Print Status" DataField="Is_Downloaded"  />
                                  <asp:BoundField HeaderText="Stamp Applied" DataField="SealRequired_"  />
                                  <asp:BoundField HeaderText="Approved By" DataField="PersonName_"  />
                                  
                                   <asp:BoundField HeaderText="Request Method" DataField="Is_Uploaded"  />
                                <%--  <asp:BoundField HeaderText="Designation" DataField="Designation_"  />--%>
                                 
                                    <asp:TemplateField Visible="false"  >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblDownvery" runat="server" Text='<%#Eval("Downvery_") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                  <asp:TemplateField runat="server" Visible="true"  HeaderText="Consignee"  >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblTemplateIDeweww" runat="server" Text='<%#Eval("Consignee_") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                  <asp:TemplateField runat="server" Visible="true"  HeaderText="Consignor"  >
                                      <ItemTemplate>
                                          <asp:Label ID ="lblTemplateIDewewwert" runat="server" Text='<%#Eval("Consignor_") %>'></asp:Label>
 
                                      </ItemTemplate>

                                  </asp:TemplateField>

                                 


                                 <asp:TemplateField HeaderText=" Download" >
                                   <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary"  ClientIDMode="AutoID" OnClick="LinkButton1_Click"  >Certificate</asp:LinkButton>
                                       
                                     
                                     <asp:LinkButton ID="LinkDelete" runat="server" CssClass="btn btn-primary" style="display:none"  OnClick="view">view</asp:LinkButton>
                                       
                                   </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText=" Download" >
                                       <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary"  ClientIDMode="AutoID" OnClick="Document_Click"  >Documents </asp:LinkButton>
                                     </ItemTemplate>  </asp:TemplateField>
                                   <asp:TemplateField >
                                       <ItemTemplate>
                                       <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-primary"  Visible="false"  ClientIDMode="AutoID" OnClick="LinkButton2_Click"  >View </asp:LinkButton>
                                     </ItemTemplate>  </asp:TemplateField>

                                   <asp:TemplateField >
                                        <ItemTemplate>
                                        <asp:CheckBox id="CheckBox1" 
  
    Checked="false"
     TextAlign="Right"
  
 
     runat="server"/> </ItemTemplate> 
                                       </asp:TemplateField>
                                  
                              </Columns>
                               <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                              <PagerStyle CssClass="Gridpaging" HorizontalAlign="Right" />
                          </asp:GridView>

                  </div>
                </div>
            </div>
            </div>
  </div>
                  
          <%--  </div>

</div>

	<div class="row">
        <div class="col-md-3">

        </div>
		<div class="col-md-9">
    	   
		</div>
	</div>

</div>--%>

   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
 <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="Button2"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


<!-- ModalPopupExtender -->

<asp:Panel ID="Panel1" runat="server" Width="1300px"   CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content--><div id="Div1" runat="server"  style="max-height:600px; padding-top:30px; overflow: auto;">
    <div class="modal-content">
        <div class="modal-header">
        <h4 class="modal-title">View</h4>
      </div>
      <div class="modal-body">

          <iframe name="myIframe" id="myIframe" width="950px" height="400px" runat ="server" ></iframe>
   
          </div>
        <div class="modal-footer">
          
          <asp:Button ID="btnClose" runat="server" Text="Close"  CssClass="btn btn-Secondary"  />
      </div>

        </div>
        </div>
    </asp:Panel>--%>

           
 <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="Button2"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


<!-- ModalPopupExtender -->

<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-dialog modal-lg" align="center" style = "display:none">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Document Download</h4>
      </div>
      <div class="modal-body">
                      <asp:GridView ID="gvSupportingDOc" runat="server" CssClass="table table-responsive  table-bordered  table-hover" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Document Id" DataField="Downvery_" SortExpression="Downvery_" ItemStyle-Width="100px" />
                       
                        <asp:TemplateField HeaderText="Document Name">
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="lblDocName" runat="server" Text='<%# Eval("Certificate_Name") %>'></asp:Label>
                                <asp:Label ID="lblSDUppathe" runat="server" Visible="false" Text='<%# Eval("Certificate_Path") %>'></asp:Label>
                                 <asp:Label ID="lblReqNo" runat="server" Visible="false" Text='<%# Eval("Request_Id") %>'></asp:Label>
                                <asp:Label ID="lblRefNo" runat="server" Visible="false"  ></asp:Label>
                               
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDownloadSD" runat="server" OnClick="btnSupView_Click"    CssClass="btn btn-sm btn-default">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="">
                            <ItemStyle Width="60px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="linkDownloadSDs" runat="server" OnClick="btnSupDown_Click"    CssClass="btn btn-sm btn-default">Download</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>



                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                </asp:GridView> <%--End of form-horizontal--%>
      </div>
      <div class="modal-footer">
          
          <asp:Button ID="btnClose" runat="server" Text="Close"  CssClass="btn btn-Secondary"  />
      </div>
    </div>
</asp:Panel>


  

        

   
        

        






</asp:Content>




