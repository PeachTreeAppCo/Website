<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PeachTreeWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container" id="myContainer">
    <br/>
    <div class="row">
      <div class="span12">
        <div class="" id="loginModal">
          <div class="modal-body">
            <div class="well custom-well">
              <ul class="nav nav-tabs full-width">
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
                          <br/>                        
                        <div class="controls">
                          <button class="btn btn-success" id="btnLogin" style="width: 72px" runat="server" onServerClick="btnLogin_Click">Login</button>
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
                        <asp:DropDownList ID="ddlFaculty" placeholder="Select your faculty" CssClass="input-xlarge custom-text" runat="server">
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
                    <br/>
                    <!-- Faculty Login Button-->
                    <div>
                      <button class="btn btn-success" id="btnFacultySignIn">Sign in</button>
                    </div>
                    </fieldset>
                    <br/>
                </div>
                <div class="tab-pane fade form-centered" id="guestsignin">
                    <br/>
                    <!-- Guest Login Button-->
                    <div>
                      <button class="btn btn-success" id="btnGuestSignIn">Continue as a Guest</button>
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
