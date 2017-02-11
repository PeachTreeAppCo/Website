<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PeachTreeWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">
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
                      <div class="control-group">
                        <!-- Member Email -->
                        <div class="controls">
                          <input type="text" id="email" name="email" placeholder="Enter your email" class="input-xlarge custom-text">
                        </div>
                      </div>
                      <div class="control-group">
                          <br/>
                        <!-- Member Password-->
                        <div class="controls">
                          <input type="password" id="password" name="password" placeholder="Password" class="input-xlarge custom-text">
                        </div>
                      </div>                        
                      <div class="control-group">
                          <br/>
                        <!-- Member Login Button -->
                        <div class="controls">
                          <button class="btn btn-success">Login</button>
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
                        <input type="text" list=faculties name="faculties" placeholder="Select your faculty" class="input-xlarge custom-text">
                        <datalist id=faculties>
                               <option> Faculty of Architecture, Computing & Humanities
                               <option> Faculty of Education & Health
                               <option> Faculty of Engineering & Science
                               <option> Business School 
                         </datalist>
                      </div>
                    </div>
                        <br/>
                    <div class="control-group">
                      <!-- Faculty Password-->
                      <div class="controls">
                        <input type="password" id="facultyPwd" name="password" placeholder="Password" class="input-xlarge custom-text">
                      </div>
                    </div>
                    <br/>
                    <!-- Faculty Login Button-->
                    <div>
                      <button class="btn btn-success">Sign in</button>
                    </div>
                    </fieldset>
                    <br/>
                </div>
                <div class="tab-pane fade form-centered" id="guestsignin">
                    <br/>
                    <!-- Guest Login Button-->
                    <div>
                      <button class="btn btn-success">Guest Login</button>
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
