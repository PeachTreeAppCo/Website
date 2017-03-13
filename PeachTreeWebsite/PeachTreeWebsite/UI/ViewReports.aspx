<%@ Page Title="View Reports" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewReports" runat="server">Reports</asp:Label>
    </div>
    <div>

        <strong>Publication Statistics</strong><br />
        <br />

        Select a year:

        <asp:DropDownList ID="ddlComps" runat="server" AutoPostBack="true">
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search" OnClick="btnSearch_Click" />
        <asp:Label ID="lblErr" runat="server"></asp:Label>
        <br />
        <br />
        No. of Contributions (Total):
        <asp:Label ID="lblContribTotal" runat="server"></asp:Label>
        <br />
        No. of Contributions from your faculty:
        <asp:Label ID="lblContribFaculty" runat="server"></asp:Label>

        <br />
        No. of Contributors within your faculty:
        <asp:Label ID="lblContributors" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblNoComment" runat="server" Text="No. of Contributions without comments: " Visible="False"></asp:Label>
        <asp:Label ID="lblNoCommentsResult" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblNoComment14Days" runat="server" Text="No. of Contributions without comments after 14 days:  " Visible="False"></asp:Label>
        <asp:Label ID="lblNoComments14DaysResult" runat="server"></asp:Label>

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
