<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="SocksNStuff.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 80vh;">
        <img style="margin-right: 80px;" width="400" height="400" class="d-none d-md-block mr-5" src="assets/Sign up-amico.png" />
        <div class="ml-5 p-4 shadow-lg d-flex flex-column align-items-center" style="width: 350px;">
            <h2 class="text-center mb-4">Sign up</h2>

            <div class="form-group mt-3">
                <asp:Label AssociatedControlID="txtFname" runat="server" CssClass="form-label">First Name</asp:Label>
                <asp:TextBox ID="txtFname" runat="server" CssClass="form-control" Placeholder="Enter your first name" />
                <asp:RequiredFieldValidator ControlToValidate="txtFname" ErrorMessage="Please enter a valid first name." CssClass="text-danger mt-1" runat="server" Display="Dynamic" />
            </div>

            <div class="form-group mt-3">
                <asp:Label AssociatedControlID="txtLname" runat="server" CssClass="form-label">Last Name</asp:Label>
                <asp:TextBox ID="txtLname" runat="server" CssClass="form-control" Placeholder="Enter your last name" />
                <asp:RequiredFieldValidator ControlToValidate="txtLname" ErrorMessage="Please enter a valid last name." CssClass="text-danger mt-1" runat="server" Display="Dynamic" />
            </div>

            <div class="form-group mt-3">
                <asp:Label AssociatedControlID="txtEmail" runat="server" CssClass="form-label">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid email address." CssClass="text-danger mt-1" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" Display="Dynamic" />
            </div>

            <div class="form-group mt-3">
                <asp:Label AssociatedControlID="txtPassword" runat="server" CssClass="form-label">Password</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password" />
                <asp:RequiredFieldValidator ControlToValidate="txtPassword" ErrorMessage="Please enter a valid password." CssClass="text-danger mt-1" runat="server" Display="Dynamic" />
           <asp:RegularExpressionValidator 
    ID="PasswordStrengthValidator" 
    runat="server" 
    ControlToValidate="txtPassword"
    ErrorMessage="Password must be at least 8 characters long, and include uppercase, lowercase, a number, and a special character." 
    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$"
               Display="Dynamic"
               CssClass="text-danger">
</asp:RegularExpressionValidator>
                </div>

            <asp:Button ID="btnLogin" runat="server" Text="Sign Up" CssClass="btn btn-primary w-100 mt-4" OnClick="ShopSignUp" />
        <asp:ModelErrorMessage ID="ErrorMessage" CssClass="text-danger" runat="server" Display="Dynamic" />
              <asp:CustomValidator
      ID="AccontExist"
      runat="server"
      ControlToValidate="txtPassword"
      ErrorMessage="Account Already Exists"
      CssClass="text-danger"
      Display="Dynamic" />
            <p class="mt-3">Have an Account? <a runat="server" href="Login.aspx" class="border-0 text-info bg-transparent" >Login!</a>
</p>
        </div>
    </div>
</asp:Content>
