<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="PeachTreeWebsite.UI.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblManageUsers" runat="server">Manage Users</asp:Label>
    </div>
    <div class="wrapper"> 
        <h3>User Details</h3>
        <%-- Select user area (LHS) --%>
    <div class="formsidebyside" style="width: 40%">
        <asp:Label ID="lblSelectType" runat="server">Select user type: </asp:Label> <br />
        <asp:DropDownList ID="ddlTypeofUser" runat="server" OnSelectedIndexChanged="ddlTypeofUser_SelectedIndexChanged" Width="237px"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblSelectUser" runat="server">Select user: </asp:Label><br />
        <asp:ListBox ID="lbUsers" runat="server" OnSelectedIndexChanged="lbUsers_SelectedIndexChanged" Height="172px" Width="241px"></asp:ListBox>
    </div>

        <%-- Amend/Delete user area (RHS) --%>
    <div class="formsidebyside form-centered" style="width: 40%">
    <fieldset>
        <ul>
            <li>
                <asp:TextBox ID="txtUID" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblUID" runat="server" Text="UserID" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtFName" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblFName" runat="server" Text="First Name(s)" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtSName" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblSName" runat="server" Text="Surname" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtUType" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblUserType" runat="server" Text="User Type" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtPwd" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblPwd" runat="server" Text="Password" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtMobNum" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblMobNum" runat="server" Text="Mobile" CssClass="label-form"></asp:Label>                
            </li>
            <li>
                <asp:TextBox ID="txtStudyYr" runat="server" CssClass="inputuserdetail"></asp:TextBox>
                <asp:Label ID="lblStudyYr" runat="server" Text="Year of Study" CssClass="label-form"></asp:Label>                
            </li>
        </ul>
    </fieldset>
        <br />
        <p class="full-width">           
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" style="float: right" OnClick="btnUpdate_Click"/>       
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" style="float: right"/>                              
        </p>
    </div>
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
