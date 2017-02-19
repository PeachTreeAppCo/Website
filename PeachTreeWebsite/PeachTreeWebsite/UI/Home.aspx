<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PeachTreeWebsite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblWelcome" runat="server">Welcome</asp:Label>
    </div>
    <div class ="form-centered full-width">
        <p><button class="btn btn-success" id="btnAddContribution" runat="server" onServerClick="btnAddContribution_Click">Add your Contribution</button></p>
        <p><button class="btn btn-success" id="btnViewContributions" runat="server" onServerClick="btnViewContributions_Click">View your Contributions</button></p>
        <p><button class="btn btn-success" id="btnViewReports" runat="server" onServerClick="btnViewReports_Click">View Reports</button></p>
        <p><button class="btn btn-success" id="btnAccountSettings" runat="server" onServerClick="btnAccountSettings_Click">Account Settings</button></p>
        <p><button class="btn btn-success" id="btnViewPublications" runat="server" onServerClick="btnViewPublications_Click">View Publications</button></p>
        <p><button class="btn btn-danger" id="btnManageUsers" runat="server" onServerClick="btnManageUsers_Click">Manage Users</button></p>
    </div>
</asp:Content>
