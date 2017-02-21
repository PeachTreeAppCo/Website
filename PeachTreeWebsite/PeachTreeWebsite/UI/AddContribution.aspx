<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AddContribution.aspx.cs" Inherits="PeachTreeWebsite.UI.AddContribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAccountSettings" runat="server">Add Contribution</asp:Label>
    </div>
    <div>
        Title<br />
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <asp:FileUpload ID="fileContrib" runat="server" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Label ID="lblSubmit" runat="server"></asp:Label>
    </div>
</asp:Content>
