﻿<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="PeachTreeWebsite.UI.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblManageUsers" runat="server" CssClass="h1">Manage Users</asp:Label>
    </div>
    
    <div class="wrap">        
        <%-- Select user area (LHS) --%>
        <div class="formone form-centered">
            <asp:Label ID="lblSelectType" runat="server">Select user type: </asp:Label>
            <br />
            <asp:DropDownList ID="ddlTypeofUser" runat="server" OnSelectedIndexChanged="ddlTypeofUser_SelectedIndexChanged" CssClass="form-control" Width="150px"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblSelectUser" runat="server">Select user: </asp:Label><br />
            <asp:ListBox ID="lbUsers" runat="server" OnSelectedIndexChanged="lbUsers_SelectedIndexChanged" Height="172px" Width="241px"></asp:ListBox>
        </div>

        <%-- Amend/Delete user area (RHS) --%>
        <div class="formtwo form-centered">
            <h4>User Details</h4>
            <asp:Label ID="lblUID" runat="server" Text="UserID" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtUID" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblFName" runat="server" Text="First Name(s)" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtFName" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblSName" runat="server" Text="Surname" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtSName" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblUserType" runat="server" Text="User Type" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtUType" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblPwd" runat="server" Text="Password" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtPwd" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblMobNum" runat="server" Text="Mobile" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtMobNum" runat="server" CssClass="inputuserdetail"></asp:TextBox><br />

            <asp:Label ID="lblStudyYr" runat="server" Text="Year of Study" CssClass="label-form"></asp:Label>
            <asp:TextBox ID="txtStudyYr" runat="server" CssClass="inputuserdetail"></asp:TextBox>
            <br />
            <p class="full-width">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" />
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
