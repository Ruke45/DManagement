<%@ Page Title=""  Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="OwnerDetailentry.aspx.cs" Inherits="DSCMS.Views.Maintenance.OwnerDetailentry" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



  
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
 NCEDCOS | Change Owner Details
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    


    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
   
   <script type="text/javascript">
       function HideLabel() {
           var seconds = 5;
           setTimeout(function () {
               document.getElementById("<%=lblSuccess.ClientID %>").style.display = "none";
           }, seconds * 1000);
       };
</script>
    <%--<script runat="server">
    protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        
        
        
        if (ddUserGroup.SelectedValue.Equals("CADMIN") || ddUserGroup.SelectedValue.Equals("CUSTOMER"))
        {
            cd.Visible = true;
        }
        else {
            cd.Visible = false;
        }
        
    }
</script>--%>


    <asp:Literal ID="LiteralMessage" runat="server"></asp:Literal>


                  <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                          <small>User</small>
                        </h1>
                        <ol class="breadcrumb">
                            <li class="active">
                                <i class="fa fa-users"></i> Owner Details
                            </li>
                        </ol>
                    </div>
                </div>

             <div class="row">
                 <div class="container boxshadow">
                 <div class="col-lg-11">
                      <div class="col-lg-12" style="font-family:Cambria;">
                                <h1 class="page-header">
                                    <small>Owner Details</small>
                                </h1>
                            </div>
                     <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
                          <%--Error Msg goes here--%>
                     <div class="form-horizontal" role="form" style="font-family:Cambria;">

                         <div class="form-group" runat="server" visible="false">
                            <label class="control-label col-sm-2" for="UserGroupID">Owner ID</label>
                            <div class="col-sm-5">
                            <asp:DropDownList ID="ddUserGroup" AutoPostBack="true" CssClass="form-control"


             OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  runat="server" AppendDataBoundItems="true"><asp:ListItem Text="--Select Owner--" Value="" />
                                <asp:ListItem Text="Owner1" Value="1" />
                                <asp:ListItem Text="Owner2" Value="2" />


                            </asp:DropDownList>
                            </div>
                             <div class="col-sm-3">
                                 <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="ddUserGroup" ErrorMessage="Owner ID is a Required." autoposback="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                  </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ControlToValidate="ddUserGroup" ErrorMessage="." autoposback="true" ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>


                             </div>

                            <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Name</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="PersonName" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="PersonName" ErrorMessage="Person Name is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="PersonName" ErrorMessage="."  ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>
           
                        </div>
                           <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Company Name</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txtCompanyName" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="Company Name is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div><div>
                        </div></div>
           
                        </div>


                          <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Address 1</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txtAdrs1" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="PersonName" ErrorMessage="Person Name is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="PersonName" ErrorMessage="."  ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>
           
                        </div>

                         <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Address 2</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txtaddr2" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ControlToValidate="PersonName" ErrorMessage="Person Name is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ControlToValidate="PersonName" ErrorMessage="."  ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>
           
                        </div>
                         <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Address 3</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txtaddr3" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server" ControlToValidate="PersonName" ErrorMessage="Person Name is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" ControlToValidate="PersonName" ErrorMessage="."  ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>
           
                        </div>


                         <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Email</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txtemail" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                             <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="PersonName" ErrorMessage="Person Name is a Required."  ForeColor="Red"></asp:RequiredFieldValidator>
                                   </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator13" runat="server" ControlToValidate="PersonName" ErrorMessage="."  ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>
           
                        </div>

                          <div class="form-group">
                            <label class="control-label col-sm-2" for="PersonName">Telephone No</label>
                            <div class="col-sm-5">
                            <asp:TextBox ID="txttelno" CssClass="form-control"  runat="server"></asp:TextBox>

                            </div>
                              <div class="col-sm-3">
                                  <div>
                          
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="should be 10 digits" ForeColor="Red" ControlToValidate="txttelno"
        ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                                   </div><div><asp:RequiredFieldValidator id="RequiredFieldValidator15" runat="server" ControlToValidate="PersonName" ErrorMessage="."  ForeColor="White"></asp:RequiredFieldValidator>
                        </div></div>
           
                        </div>                   
                  
                           <div class="form-group">
                                <div class="col-sm-8">
                                    <div class="col-sm-4"></div>
                                    <div class="col-sm-8">
                                 <asp:Label ID="lblSuccess" runat="server" Text="Label" visible="false" ForeColor="blue">"User Created Successfully!!!"</asp:Label>

                           </div>
                                    </div>
                        
                        </div>

                        

                        

                        

                       

                         <div class="form-group">
                           <div class="col-sm-5"></div>
                            <div class="col-sm-5">
                            <asp:Button ID="btnAdd" runat="server" Text="Submit" CssClass="btn btn-primary" Width="150px" OnClick="Button1_Click1" />
                            </div>
                        </div>

                         

                      </div> <%--End of form-horizontal--%>
                 </div><%-- End of col-lg-11--%>
             </div> <%--End of Row--%>
    </div>
                 </div>
</asp:Content>
