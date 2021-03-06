﻿<%@ Page Title="View Competitions" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewCompetitions.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewCompetitions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewCompetitions" runat="server" CssClass="h1">Manage Competitions</asp:Label>
        <br /><br />
        <asp:Button ID="btnAddComp" runat="server" OnClick="btnAddComp_Click" CssClass="btn btn-default" Text="Add" />
    </div>
    <div>
        <asp:Label ID="lblError" CssClass="text-danger" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-hover" CellPadding="10"  AllowPaging="True" OnPageIndexChanging="grdData_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CssClass="btn btn-link" Text="Edit" runat="server"
                            CommandName="EditComp"
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
