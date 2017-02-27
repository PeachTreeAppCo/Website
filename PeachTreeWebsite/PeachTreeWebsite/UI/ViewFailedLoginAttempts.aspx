<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewFailedLoginAttempts.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewFailedLoginAttempts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAccountSettings" runat="server">View Failed Login Attempts</asp:Label>
    </div>
    <div>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PeachTreeWebsite.Properties.Settings.PeachTreeConnectionString %>" SelectCommand="SELECT [EmailEntered], [PwordEntered], [Date_Time] FROM [PTA_LoginAttempt] ORDER BY [Date_Time] DESC"></asp:SqlDataSource>

    </div>
</asp:Content>
