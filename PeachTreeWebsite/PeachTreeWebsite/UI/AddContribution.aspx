<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AddContribution.aspx.cs" Inherits="PeachTreeWebsite.UI.AddContribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAccountSettings" runat="server">Add Contribution</asp:Label>   <br />      
    </div>
    <div>
                <asp:Label ID="lblTitle" runat="server" Text="Title *"></asp:Label>
                <br />
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblComp" runat="server" Text="Competition *"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlComps" runat="server">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblDoc" runat="server" Text="Document *"></asp:Label>
                <asp:FileUpload ID="fileContrib" runat="server" />
                <br />
                <asp:Label ID="lblImage" runat="server" Text="Image"></asp:Label>
                <asp:FileUpload ID="fileImage" runat="server" />
                <br />
                <asp:CheckBox ID="cbTerms" runat="server" Text="I agree to the terms and conditions and confirm that this is my work." />
                <asp:Button ID="btnTnC" CssClass="btn-link" runat="server" OnClick="btnTnC_Click" Text="View Terms and Conditions" Width="194px" />
                <br />
                <br />
                <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                <asp:Label ID="lblSubmit" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnBack" CssClass="btn btn-success" runat="server" OnClick="btnBack_Click" Text="Back to Contributions" />
    </div>
</asp:Content>

