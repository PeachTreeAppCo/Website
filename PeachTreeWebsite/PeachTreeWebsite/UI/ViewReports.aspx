<%@ Page Title="View Reports" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewReports" runat="server" CssClass="h1">Reports</asp:Label>
    </div>
    <div>

        <strong>Publication Statistics</strong><br />
        Select a year:
        <div style="width: 320px">
            <div style="float: left; width: 200px">
                <asp:DropDownList ID="ddlComps" runat="server" CssClass="form-control" Width="150px" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div style="float: left; width: 10px">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-default" Text="Search" OnClick="btnSearch_Click" />
            </div>
        </div>
        <br /><br />
        <div>
            <asp:Label ID="lblErr" runat="server"></asp:Label>
        </div>        
        <br />
        <br />
        No. of Contributions (Total):
        <asp:Label ID="lblContribTotal" runat="server">0</asp:Label>
        <br />
        No. of Contributions from your faculty:
        <asp:Label ID="lblContribFaculty" runat="server">0</asp:Label>

        <br />
        No. of Contributors within your faculty:
        <asp:Label ID="lblContributors" runat="server">0</asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblMarketingManager" style="font-weight: bold" runat="server" Visible="False">Marketing Manager Reports</asp:Label>
        <br />
        <asp:Label ID="lblNoComment" runat="server" Text="No. of Contributions without comments: " Visible="False"></asp:Label>
        <asp:Label ID="lblNoCommentsResult" runat="server" Visible="False">0</asp:Label>
        <br />
        <asp:Label ID="lblNoComment14Days" runat="server" Text="No. of Contributions without comments after 14 days:  " Visible="False"></asp:Label>
        <asp:Label ID="lblNoComments14DaysResult" runat="server" Text="0" Visible="False"></asp:Label>
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
