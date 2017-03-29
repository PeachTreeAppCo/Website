<%@ Page Title="Terms and Conditions" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="TermsAndConditions.aspx.cs" Inherits="PeachTreeWebsite.UI.TermsAndConditions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <br />
        <asp:Label ID="lblTnC" runat="server">Terms and Conditions</asp:Label>
    </div>
    <div>
        <p>
            <strong>Please Read the Terms and Conditions below.</strong>
        </p>
        <p>
            By accessing this service, provided by Peach Tree App Co and your University, you agree to the following Terms and Conditions:<br />
            • The content of this website is for general use and information only; it will be updated without notice. <br />
            • All of the Intellectual Property produced from this service is owned by the University and is in accordance with Copyright Standards. <br />
            • This web service monitors browsing and preferences, using cookies. Cookies will not store personal data or pass data onto third parties – in agreement by the Data Protection Act (1998). <br />
            • The web service is in in compliance with the UK&amp;I Law’s regulations and standards.
        </p>
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
