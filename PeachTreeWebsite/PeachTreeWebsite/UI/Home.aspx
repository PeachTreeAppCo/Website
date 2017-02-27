﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PeachTreeWebsite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblWelcome" runat="server">Welcome</asp:Label>
    </div>
    <div class ="form-centered full-width">
        <p><button class="btn btn-success" id="btnViewContributions" runat="server" style="width: 300px;" onServerClick="btnViewContributions_Click">View your Contributions</button></p>
        <p><button class="btn btn-success" id="btnViewReports" runat="server" style="width: 300px;" onServerClick="btnViewReports_Click">View Reports</button></p>
        <p><button class="btn btn-success" id="btnAccountSettings" runat="server" style="width: 300px;" onServerClick="btnAccountSettings_Click">Account Settings</button></p>
        <p><button class="btn btn-success" id="btnViewPublications" runat="server" style="width: 300px;" onServerClick="btnViewPublications_Click">View Publications</button></p>
        <p><button class="btn btn-success" id="btnViewFailedLogins" runat="server" style="width: 300px;" onServerClick="btnViewFailedLogins_Click">View Failed Login Attempts</button></p>
        <p><button class="btn btn-danger" id="btnManageUsers" runat="server" style="width: 300px;" onServerClick="btnManageUsers_Click">Manage Users</button></p>
    </div>
</asp:Content>
