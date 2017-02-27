<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewContributions.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewContributions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewContributions" runat="server">Contributions</asp:Label>
    </div>
    <div>
    	
		<asp:GridView ID="gridviewContrib" runat="server">
		</asp:GridView>
		<br />
		<asp:Label ID="lblError" runat="server"></asp:Label>
    	
	</div>
</asp:Content>
