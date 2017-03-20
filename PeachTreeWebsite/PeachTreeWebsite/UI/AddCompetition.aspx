<%@ Page Title="Add Competition" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AddCompetition.aspx.cs" Inherits="PeachTreeWebsite.UI.AddCompetition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAddCompetition" runat="server">Add Competition</asp:Label>
        <br />
        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click" Text="Back" />
    </div>
    <div>

        Title<br />
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <br />
        Initial Closure Date<br />
        <asp:Calendar ID="calInitClose" runat="server"></asp:Calendar>
        <br />
        <br />
        Final Closure Date<br />
        <asp:Calendar ID="calFinalClose" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnAdd_Click" />

        <asp:Label ID="lblSaveError" CssClass="text-danger" runat="server"></asp:Label>

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
