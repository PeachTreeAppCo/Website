﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AddContribution.aspx.cs" Inherits="PeachTreeWebsite.UI.AddContribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAccountSettings" runat="server">Add Contribution</asp:Label>
    </div>
    <div>
        <asp:Label ID="lblTitle" runat="server" Text="Title *"></asp:Label><br />
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblDoc" runat="server" Text="Document *"></asp:Label>
        <asp:FileUpload ID="fileContrib" runat="server" />
        <br />
        <asp:Label ID="lblImage" runat="server" Text="Image"></asp:Label>
        Image<asp:FileUpload ID="fileContrib0" runat="server" />
        <br />
        <asp:CheckBox ID="cbTerms" runat="server" Text="I agree to the terms and conditions and confirm that this is my work.   " />
&nbsp;
        <asp:Button ID="btnTnC" CssClass="btn-link" runat="server" OnClick="btnTnC_Click" Text="View Terms and Conditions" Width="194px" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Label ID="lblSubmit" runat="server"></asp:Label>
    </div>
</asp:Content>
