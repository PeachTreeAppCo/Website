<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AddFeedback.aspx.cs" Inherits="PeachTreeWebsite.UI.AddFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAddFeedback" runat="server">Add Feedback</asp:Label>
        <br />
        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success" OnClick="btnBack_Click" Text="Back" />
    </div>
    <div>
        Submission title:
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
        <br />
        <br />
        Status:<br />
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem>Submitted</asp:ListItem>
            <asp:ListItem>Published</asp:ListItem>
            <asp:ListItem>Declined</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Feedback:<br />
        &nbsp;<asp:TextBox ID="txtFeedback" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click" Text="Submit" />

        <asp:Label ID="lblSubmit" runat="server"></asp:Label>

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

