<%@ Page Title="Add Contribution" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="AddContribution.aspx.cs" Inherits="PeachTreeWebsite.UI.AddContribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblAccountSettings" runat="server" CssClass="h1">Add Contribution</asp:Label>   
        <br /><br />
                <asp:Button ID="btnBack" CssClass="btn btn-default" runat="server" OnClick="btnBack_Click" Text="Back to Contributions" />
        <br />      
    </div>
    <div>
                <asp:Label ID="lblTitle" runat="server" Text="Title *"></asp:Label>
                <br />
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblComp" runat="server" Text="Competition *"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlComps" CssClass="form-control" Width="150px" runat="server">
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
                <asp:Button ID="btnTnC" CssClass="btn-link" runat="server" OnClientClick="aspnetForm.target ='_blank';" OnClick="btnTnC_Click" Text="View Terms and Conditions" Width="194px" />
                <br />
                <br />
                <asp:Button ID="btnSubmit" CssClass="btn btn-default" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                <asp:Label ID="lblSubmit" runat="server"></asp:Label>
                <br />
                <br />
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

