<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PeachTreeWebsite._Default"%>

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
                          <asp:Label ID="lblLoginError" runat="server"></asp:Label>
                          <br/>                        
                        <div class="controls">
                          <button class="btn btn-success" id="btnLogin" runat="server" onServerClick="btnLogin_Click">Login</button>
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
                        <div class="controls">
                        <asp:DropDownList ID="ddlFaculty" class="input-xlarge custom-text" runat="server" Height="26px">
                        </asp:DropDownList>
                      </div>
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
                      <button class="btn btn-success" id="btnFacultySignIn" runat="server" onServerClick="btnFacultySignIn_Click">Login</button>
                    </div>
                    </fieldset>
                    <br/>
                </div>
                <div class="tab-pane fade form-centered" id="guestsignin">
                    <br/>
                    <!-- Guest Login Button-->
                    <div>
                      <button class="btn btn-success" id="btnGuestSignIn" runat="server" onServerClick="btnGuestSignIn_Click">Continue as a Guest</button>
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
</asp:Content>
