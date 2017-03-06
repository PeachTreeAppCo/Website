﻿<%@ Page Title="View Contributions" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewContributions.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewContributions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewContributions" runat="server">Contributions</asp:Label>
    	<br />
		<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Text="Add Contribution" />
    </div>
    <div>    	
        <asp:Label ID="lblError" runat="server"></asp:Label> 
		<asp:GridView ID="gridviewContrib" onrowcommand="GridView1_RowCommand" runat="server" CssClass="gv" cellpadding="10" AllowSorting="True">
			<Columns>
				<asp:TemplateField>
					<ItemTemplate>
						<asp:Button ID="btnDownload" CssClass="btn btn-link" Text="Download" runat="server" 
							CommandName="Download" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/><br />
                        <asp:Button ID="btnEdit" CssClass="btn btn-link" Text="Edit" runat="server" 
							CommandName="EditCont" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /><br />
                        <asp:Button ID="btnDelete" CssClass="btn btn-link" Text="Delete" runat="server" 
							CommandName="DeleteCont" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
					</ItemTemplate>					
				</asp:TemplateField>
			</Columns>
		</asp:GridView>		   	
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
