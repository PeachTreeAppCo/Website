﻿<%@ Page Title="View Publications" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="ViewPublications.aspx.cs" Inherits="PeachTreeWebsite.UI.ViewPublications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="lblViewPublications" runat="server">Publications</asp:Label>
    </div>
    <div>
        
        <br />
        Select a year:
        <asp:DropDownList ID="ddlComps" runat="server" AutoPostBack="true">
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search" OnClick="btnSearch_Click" />
        <asp:Label ID="lblErr" runat="server"></asp:Label>
        <br />
        <br />
        
        <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" runat="server" CssClass="gv" CellPadding="10" AllowSorting="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" CssClass="btn btn-link" Text="Download" runat="server"
                            CommandName="Download"
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
