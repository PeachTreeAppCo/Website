<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PeachTreeWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome</h1>
        <p class="lead">to the Student Magazine Contribution Hub. Please login to use the system.</p>
    </div>

    <div>        
        <strong>
        <asp:Login ID="Login1" runat="server" Font-Bold="False" Font-Names="Helvetica Neue" OnAuthenticate="Login1_Authenticate">
        </asp:Login>
        </strong>
        <br />
    </div>

</asp:Content>
