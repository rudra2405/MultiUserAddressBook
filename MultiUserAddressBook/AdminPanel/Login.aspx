<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/CSS/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="~/Content/CSS/MyCss.css" rel="stylesheet" />
    <script src="~/Content/JS/bootstrap.min.js"></script>

</head>
<body>
   <form id="form1" runat="server">
   <div class="container">
        <div class="row header">
            <div class="col-md-12 text-center">
                <h1 style="color:#3952ee">Existing User Login to Address Book</h1>
            </div>
       </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
        </div>
       <br />
        <div class="row content">
            <div class="col-md-4">
                <h1>User Name :</h1>
            </div>
             <div class="col-md-4">
                 <br />
                <asp:TextBox ID="txtUserNameLogin" placeholder="Enter User name" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <br />
            </div>
        </div>
        <div class="row content">
            <div class="col-md-4">
                <h1>Password :</h1>
            </div>
             <div class="col-md-4">
                 <br />
                <asp:TextBox ID="txtPasswordLogin" runat="server" placeholder="Enter Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
           <div class="col-md-4">
               <br />
           </div>
        </div>
         <div class="row content">
            <div class="col-md-4">
           </div>
             <div class="col-md-8">
                 <br />
                <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-danger" OnClick="btnLogin_Click"/>&nbsp&nbsp&nbsp
                <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click"/>
            </div>
        </div>
   </div>
  </form>
</body>
</html>
