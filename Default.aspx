<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UrlShortner._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="title">
            <span>URL Shortner</span>
        </div>
    <div class="row d-flex m-t-2">
        <div class="col-md-1 m-l-3">
            <span><strong>Full URL:</strong></span>
        </div>
        <div class="col-sm-12 col-md-3 m-l-2">
            <asp:TextBox ID="txtFullUrl" runat="server" CssClass="form-control" placeholder="Enter website url" />
        </div>
        <div class="">
            <p>
            <asp:Button ID="btnGenerateShortUrl" runat="server" ClientIDMode="Static" OnClick="btnGenerateShortUrl_Click" Text="Generate Short Url" />
                </p>
        </div>
    </div>
        <asp:Panel ID="pnlShortUrl" runat="server" Visible="false" CssClass="d-block m-l-2 m-t-2">
            <span><strong>Shortened URL:</strong></span>
            <a id="aUrl" runat="server" ClientIdMode="Static" target="_blank"><asp:Literal ID="ltlHref" runat="server" /></a>
        </asp:Panel>
        <asp:Label ID="lblMsg" runat="server" CssClass="m-t-2" Text="" />

</asp:Content>
