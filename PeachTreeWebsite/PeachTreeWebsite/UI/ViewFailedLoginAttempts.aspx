<%@ Page Title="View Failed Login Attempts" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewFailedLoginAttempts.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewFailedLoginAttempts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAccountSettings" runat="server">View Failed Login Attempts</asp:Label>
    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PeachTreeWebsite.Properties.Settings.PeachTreeConnectionString %>" SelectCommand="SELECT [EmailEntered], [PwordEntered], [Date_Time] FROM [PTA_LoginAttempt] ORDER BY [Date_Time] DESC"></asp:SqlDataSource>
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
