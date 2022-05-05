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
        <div class="row content">
            <div class="col-md-4">
                <h1>User Name :</h1>
            </div>
             <div class="col-md-4">
                 <br />
                <asp:TextBox ID="txtUserNameLogin" placeholder="Enter User name" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-4">
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
                <asp:Button runat="server" iD="btnLogin" Text="Login" CssClass="btn btn-danger" OnClick="btnLogin_Click"></asp:Button>
            </div>
        </div>
    <br />
    <br />
         <div class="row header">
                <div class="col-md-12 text-center">
                    <h1 style="color:#3952ee">Register New User to Address Book</h1>
                </div>
          </div>
          <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblMassage" EnableViewState="false"/>
                </div>
            </div>
            <div class="row content">
                <div class="col-md-4">
                    <h1>User Name :</h1>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:TextBox runat="server" placeholder="Enter User Name" ID="txtUserName" CssClass="form-control"/> 
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row content">
              <div class="col-md-4">
                 <h1>Password : </h1>
               </div>
                <div class="col-md-4">
                    <br />
                    <asp:TextBox runat="server" placeholder="Enter Password" ID="txtPassword" TextMode="Password" CssClass="form-control"/> 
                </div>
               <div class="col-md-4">
                   <br />
                  <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Strong Password with minimum lenghth of 8" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&amp;])[A-Za-z\d$@$!%*?&amp;]{8,}" ValidationGroup="Register"></asp:RegularExpressionValidator>
               </div>
            </div>
             <div class="row content">
               <div class="col-md-4">
                 <h1> Retype Password : </h1>
               </div>
                <div class="col-md-4">
                    <br />
                    <asp:TextBox runat="server" placeholder="Retype Password" ID="txtRetypePassword" TextMode="Password" CssClass="form-control"/> 
                </div>
              <div class="col-md-4">
                  <br />
                   <asp:CompareValidator ID="cvRetypePassword" runat="server" ControlToCompare="txtPassword" Display="Dynamic" ControlToValidate="txtRetypePassword"  ErrorMessage="Retype Password Should Be Same As  Passwod" ForeColor="Red" ValidationGroup="Register"></asp:CompareValidator>
              </div>
            </div>
             <div class="row content">
                <div class="col-md-4">
                 <h1>Display Name : </h1>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:TextBox runat="server" placeholder="Enter Display Name" ID="txtDisplayName" CssClass="form-control" /> 
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="row content">
                <div class="col-md-4">
                   <h1> Mobile No : </h1>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:TextBox runat="server" placeholder="Enter Mobile No" ID="txtMobileNo" CssClass="form-control" /> 
                </div>
                <div class="col-md-4">
                  <br />
                      <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid MobileNo" ForeColor="Red" ValidationExpression="^[6-9]\d{9}$"  ValidationGroup="Register"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row content">
                <div class="col-md-4">
                    <h1>Email : </h1>
                </div>
                <div class="col-md-4">
                    <br />
                    <asp:TextBox runat="server"  placeholder="Enter Email" ID="txtEmail" TextMode="Email" CssClass="form-control" /> 
                </div>
               <div class="col-md-4">
                    <br />
                   <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter Valid Email" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  ValidationGroup="Register"></asp:RegularExpressionValidator>
               </div>
            </div>
            <div class="row content">
                <div class="col-md-4"></div>
                <div class="col-md-8">
                    <br />
                    <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" ValidationGroup="Register"/>&nbsp&nbsp&nbsp
                </div>
                <br />
                <br />
           </div>
  </div>
  </form>
</body>
</html>
