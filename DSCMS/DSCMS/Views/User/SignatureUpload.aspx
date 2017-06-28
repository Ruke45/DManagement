<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SignatureUpload.aspx.cs" Inherits="DSCMS.Views.User.Signature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Signature Upload
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type ="text/javascript">
        var validFilesTypes = ["pfx"];

        function ValidateFile() {
            var file = document.getElementById("<%=SinPFXupload.ClientID%>");
        var label = document.getElementById("<%=Label1.ClientID%>");
        var path = file.value;
        var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
        var isValidFile = false;
        for (var i = 0; i < validFilesTypes.length; i++) {
            if (ext == validFilesTypes[i]) {
                isValidFile = true;
                break;
            }
        }
        if (!isValidFile) {
            label.style.color = "red";
            label.innerHTML = "Invalid File. Please upload a File with" +
             " extension:\n\n" + validFilesTypes.join(", ");
        }
        return isValidFile;
        }
</script>




    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>User</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-users"></i>Signatory Signature Upload
                </li>
            </ol>
        </div>
        <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
    </div>


        <div class="row">

        <div class="container boxshadow">
            <div class="col-lg-11">

                <div class="form-horizontal" role="form" style="font-family: Cambria;">

                    <div class="col-lg-12" style="font-family: Cambria;">
                        <h1 class="page-header">
                            <small>Signature Upload</small>
                        </h1>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Authorized User Name</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="drpdwnUsers" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Signature PFX File</label>
                        <div class="col-sm-8">
                            <asp:FileUpload ID="SinPFXupload" runat="server" CssClass="btn btn-default"/>  
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ControlToValidate="SinPFXupload"
    runat="server" Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-sm-2" for="email">Signature Image</label>
                        <div class="col-sm-8">
                            <asp:FileUpload ID="SinIMGupload" runat="server" CssClass="btn btn-default"/> 
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="SinIMGupload"
    runat="server" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$"
    ControlToValidate="SinIMGupload" runat="server" ForeColor="Red" ErrorMessage="Please select a .PNG or .JPG File."
    Display="Dynamic" />
 
                        </div>
                    </div>

                    <div class="form-group text-right">
                        <div class="col-sm-12">
                            <asp:Button ID="btnAddSignature" runat="server" Text="Upload Signature" CssClass="btn btn-primary" Width="200px" OnClientClick = "return ValidateFile()" OnClick="btnAddSignature_Click"  />
                        </div>
                    </div>
                    </div>
                </div>
            </div>
            </div>
</asp:Content>
