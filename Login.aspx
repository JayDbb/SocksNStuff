<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SocksNStuff.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <img width="400" height="400" class="d-none d-md-block mx-2" src="assets/Login-bro.png" />
        <div class=" p-2 shadow-lg d-flex flex-column align-items-center" style="width: 350px;">
            <h2 class="text-center mb-4 ">Login</h2>
            <%--<asp:Label ID="lbMessage" runat="server" ForeColor="Red" />--%>

            <div class="form-group  mt-3">
                <asp:Label AssociatedControlID="txtEmail" runat="server" CssClass="form-label">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email" />
            </div>
            <asp:RegularExpressionValidator
                ID="revEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Please enter a valid email address."
                CssClass="text-danger"
                ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                Display="Dynamic" />



            <div class="form-group mt-3">
                <asp:Label AssociatedControlID="txtPassword" runat="server" CssClass="form-label">Password</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password" />
            </div>
            <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="Please enter a valid password." runat="server" />

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100 mt-4" OnClick="ShopLogin" />

            <asp:CustomValidator
                ID="cvLoginErrorEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Invalid email "
                CssClass="text-danger"
                Display="Dynamic" />
            <asp:CustomValidator
                ID="cvLoginErrorPwd"
                runat="server"
                ControlToValidate="txtPassword"
                ErrorMessage="Invalid password "
                CssClass="text-danger"
                Display="Dynamic" />
              <asp:CustomValidator
                  ID="cvLoginError"
                  runat="server"
                  ControlToValidate="txtPassword"
                  ErrorMessage="Invalid password and email "
                  CssClass="text-danger"
                  Display="Dynamic" />


            <p class="mt-3">
                Don't Have an Account? 
                <a runat="server" href="SignUp.aspx" class="border-0 text-info bg-transparent" >Sign up!</a>
            </p>
        </div>
    </div>
</asp:Content>
