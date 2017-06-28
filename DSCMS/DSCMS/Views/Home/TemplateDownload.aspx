<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="TemplateDownload.aspx.cs" Inherits="DSCMS.Views.Home.TemplateDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    NCEDCOS | Certificate Template Download
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Home</small>
            </h1>
            <ol class="breadcrumb">
                <li class="active">
                    <i class="fa fa-th-large"></i> Certificate Template Download
                </li>
            </ol>
        </div>

        <div class="container col-lg-12" runat="server" id="ErrorMessage" style="font-family: Cambria;">
            <%--Error Msg goes here--%>
        </div>
    </div>


    <section id="plans">
        <div class="container boxshadow" style="padding-top: 20px;">
            <div class="col-lg-12" id="divTemplateHolder" runat="server">


            </div>
        </div>
    </section>
    <%--                    <!-- item -->
                <div class="col-md-4 text-center">
                    <div class="panel panel-pricing">
                        <div class="panel-heading">
                            <h4>Certificate Template 1</h4>
                        </div
                        <div class="panel-body text-center">
                             <img src="../../img/Cert-1.PNG" class="img-thumbnail" alt="Cinque Terre" width="304" height="236"/>
                        </div>
                        <ul class="list-group text-center">
                            <li class="list-group-item">NCE Digital CO Form For MASS Active</li>
                        </ul>
                        <div class="panel-footer">
                            <a class="btn btn-lg btn-block btn-default" href="TemplateDownload.aspx?TempID=123">Select</a>
                        </div>
                    </div>
                </div>
                <!-- /item -->--%>
</asp:Content>
