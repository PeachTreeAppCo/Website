<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewCompetitions.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewCompetitions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron">
        <asp:Label ID="lblViewCompetitions" runat="server">View Competitions</asp:Label>
        <br />
        <asp:Button ID="btnAddComp" runat="server" OnClick="btnAddComp_Click" CssClass="btn btn-success" Text="Add" />
    </div>
    <div>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" onrowcommand="GridView1_RowCommand" AllowSorting="True" AutoGenerateColumns="False" CssClass="gv" DataKeyNames="PTA_ID_Competition" DataSourceID="PeachTreeDB" cellpadding="10">
            <Columns>
                <asp:BoundField DataField="PTA_ID_Competition" HeaderText="Competition ID" InsertVisible="False" ReadOnly="True" SortExpression="PTA_ID_Competition" />
                <asp:BoundField DataField="InitialClosureDate" HeaderText="Initial Closure Date" SortExpression="InitialClosureDate" />
                <asp:BoundField DataField="FinalClosureDate" HeaderText="Final Closure Date" SortExpression="FinalClosureDate" />
                <asp:BoundField DataField="CompetitionName" HeaderText="Competition Name" SortExpression="CompetitionName" />
                <asp:TemplateField>
					<ItemTemplate>
                        <asp:Button ID="btnEdit" CssClass="btn btn-link" Text="Edit" runat="server" 
							CommandName="EditComp" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /><br />
                        <asp:Button ID="btnDelete" CssClass="btn btn-link" Text="Delete" runat="server" 
							CommandName="DeleteComp" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
					</ItemTemplate>					
				</asp:TemplateField>
            </Columns>
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
