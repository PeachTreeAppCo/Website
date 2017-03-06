<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewCompetitions.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewCompetitions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron">
        <asp:Label ID="lblViewCompetitions" runat="server">View Competitions</asp:Label>
        <br />
        <asp:Button ID="btnAddComp" runat="server" CssClass="btn btn-success" Text="Add" />
    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="gv" DataKeyNames="PTA_ID_Competition" DataSourceID="PeachTreeDB" cellpadding="10">
            <Columns>
                <asp:BoundField DataField="PTA_ID_Competition" HeaderText="PTA_ID_Competition" InsertVisible="False" ReadOnly="True" SortExpression="PTA_ID_Competition" />
                <asp:BoundField DataField="InitialClosureDate" HeaderText="InitialClosureDate" SortExpression="InitialClosureDate" />
                <asp:BoundField DataField="FinalClosureDate" HeaderText="FinalClosureDate" SortExpression="FinalClosureDate" />
                <asp:BoundField DataField="CompetitionName" HeaderText="CompetitionName" SortExpression="CompetitionName" />
            </Columns>
            <EmptyDataTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="PeachTreeDB" runat="server" ConnectionString="<%$ ConnectionStrings:PeachTreeWebsite.Properties.Settings.PeachTreeConnectionString %>" SelectCommand="SELECT * FROM [PTA_Competition]"></asp:SqlDataSource>
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
