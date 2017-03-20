<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PeachTreeWebsite._Default"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container" id="myContainer">
    <br/>
    <div class="row">
      <div class="span12">
        <div class="" id="loginModal">
          <div class="modal-body">
            <div class="well custom-well">
              <ul class="nav nav-tabs nav-justified full-width">
                <li class="active"><a href="#login" data-toggle="tab">Login</a></li>
                <li><a href="#facultyguestsignin" data-toggle="tab">Faculty Guest Login</a></li>
                <li><a href="#guestsignin" data-toggle="tab">Guest Login</a></li>
              </ul>
              <div id="myTabContent" class="tab-content">
                <div class="tab-pane active in form-centered" id="login">
                    <br/>
                    <fieldset>
                      <!-- Member Email -->
                      <div class="control-group">                        
                        <div class="controls">
                            <asp:TextBox ID="txtEmail" placeholder="Enter your email" class="input-xlarge custom-text" runat="server"></asp:TextBox>
                        </div>
                      </div>
                      <!-- Member Password-->
                      <div class="control-group">
                          <br/>                        
                        <div class="controls">                        
                            <asp:TextBox ID="txtPwd" type="password" name="password" placeholder="Password" class="input-xlarge custom-text" runat="server"></asp:TextBox>
                        </div>
                      </div>     
                      <!-- Member Login Button -->                   
                      <div class="control-group">                          
                          <asp:Label ID="lblLoginError" runat="server" CssClass="text-danger"></asp:Label>
                          <br/>                        
                        <div class="controls">
                          <button class="btn btn-default" id="btnLogin" runat="server" onServerClick="btnLogin_Click">Login</button>
                        </div>
                      </div>
                    </fieldset>
                    <br/>
                </div>
                <div class="tab-pane fade form-centered" id="facultyguestsignin">
                    <br/>
                    <fieldset>
                    <div class="control-group">
                      <!-- Faculty Name -->     
                                         
                        

                        <asp:DropDownList ID="ddlFaculty" class="input-xlarge custom-text" height="26px" runat="server">
                        </asp:DropDownList>
                      
                    </div>
                        <br/>
                    <div class="control-group">
                      <!-- Faculty Password-->
                      <div class="controls">
                        <asp:TextBox ID="txtFacultyPwd" type="password" placeholder="Password" class="input-xlarge custom-text" runat="server"></asp:TextBox>
                      </div>
                    </div>
                        <asp:Label ID="lblFacultyLoginErr" runat="server"></asp:Label>
                    <br/>
                    <!-- Faculty Login Button-->
                    <div>
                      <button class="btn btn-default" id="btnFacultySignIn" runat="server" onServerClick="btnFacultySignIn_Click">Login</button>
                    </div>
                    </fieldset>
                    <br/>
                </div>
                <div class="tab-pane fade form-centered" id="guestsignin">
                    <br/>
                    <!-- Guest Login Button-->
                    <div>
                      <button class="btn btn-default" id="btnGuestSignIn" runat="server" onServerClick="btnGuestSignIn_Click">Continue as a Guest</button>
                    </div>
                    <br/>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
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
