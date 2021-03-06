﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PeachTreeWebsite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblWelcome" runat="server" CssClass="h1">Welcome</asp:Label>
        <br /><br />
        <h6><asp:Label ID="lblUserType" runat="server"></asp:Label></h6>
        <h6><asp:Label ID="lblLastLogin" runat="server"></asp:Label></h6>
    </div>
    <div class ="form-centered full-width">
        <p><button class="btn btn-default" id="btnViewContributions" runat="server" style="width: 300px;" onServerClick="btnViewContributions_Click">View your Contributions</button></p>
        <p><button class="btn btn-default" id="btnViewSubmissions" runat="server" style="width: 300px;" onServerClick="btnViewSubmissions_Click">View Submissions</button></p>
        <p><button class="btn btn-default" id="btnViewReports" runat="server" style="width: 300px;" onServerClick="btnViewReports_Click">View Reports</button></p>
        <p><button class="btn btn-default" id="btnViewPublications" runat="server" style="width: 300px;" onServerClick="btnViewPublications_Click">View Publications</button></p>
        <p><button class="btn btn-default" id="btnViewCompetitions" runat="server" style="width: 300px;" onServerClick="btnViewCompetitions_Click">Manage Competitions</button></p>
        <p><button class="btn btn-default" id="btnViewFailedLogins" runat="server" style="width: 300px;" onServerClick="btnViewFailedLogins_Click">View Failed Login Attempts</button></p>
        <p><button class="btn btn-danger" id="btnManageUsers" runat="server" style="width: 300px;" onServerClick="btnManageUsers_Click">Manage Users</button></p>
    </div>
        <%-- Google Analytics --%>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-93014084-1', 'auto');
        ga('send', 'pageview');
    </script>
    <%-- End Google Analytics --%>
</asp:Content>
