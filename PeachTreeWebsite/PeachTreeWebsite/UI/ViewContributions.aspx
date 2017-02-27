<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewContributions.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewContributions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewContributions" runat="server">Contributions</asp:Label>
    	<br />
		<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Text="Add Contribution" />
    </div>
    <div>    	
		<asp:GridView ID="gridviewContrib" runat="server" CssClass="gv" cellpadding="10">
			<Columns>
				<asp:TemplateField>
					<ItemTemplate>
						<asp:Button ID="btnDownload" CssClass="btn btn-link" Text="Download" runat="server" 
							CommandName="Download" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /><br />
                        <asp:Button ID="btnEdit" CssClass="btn btn-link" Text="Edit" runat="server" 
							CommandName="Edit" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" /><br />
                        <asp:Button ID="btnDelete" CssClass="btn btn-link" Text="Delete" runat="server" 
							CommandName="Delete" 
							CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
					</ItemTemplate>					
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
		<asp:Label ID="lblError" runat="server"></asp:Label>    	
	</div>
</asp:Content>
