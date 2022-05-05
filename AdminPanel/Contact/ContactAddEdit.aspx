<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMainContent" Runat="Server">

    <div class="row text-center">
        <div class="col-md-12">
            <h2 style="color: #0094ff">Contact Add Edit Page</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"/>
        </div>
    </div>
    <br />
    <div class="row">
         <div class="col-md-4">
                <h3> *Country ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
          </div>
      </div>
     <div class="row">
         <div class="col-md-4">
                <h3> *State ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
          </div>
      </div>
     <div class="row">
         <div class="col-md-4">
                <h3> *City ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-control"></asp:DropDownList>
          </div>
      </div>
     <div class="row">
         <div class="col-md-4">
                <h3> *ContactCategory ID: </h3>
          </div>
          <div class="col-md-8">
              <br />
                 <%--<asp:CheckBoxList runat="server" ID="cblContactCategoryID" />--%>
                 <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-control"></asp:DropDownList>
          </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> *ContactName :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> *Upload Photo</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:FileUpload ID="fuContactPhotoPath" runat="server" />
                <asp:Image  runat="server"  ID="imgPhoto" Height="50px" Width="60px"/> 
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> *ContactNo :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtContactNo" TextMode="number" CssClass="form-control" />
           </div>
            <div>
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Valid MobileNo" ForeColor="Red" ValidationExpression="^[6-9]\d{9}$"  ValidationGroup="Save"></asp:RegularExpressionValidator>
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> WhatsApp No :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtWhatsAppNo" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> BirthDate :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtBirthDate" TextMode="date" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> *Email :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
           </div>
            <div>
               <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter Valid Email" Display="Dynamic" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Age :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> *Address :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> BloodGroup :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Facebook ID :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtFacebookID" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> LinkedIN ID :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtLinkedINID" CssClass="form-control" />
           </div>
      </div>
      <br />
    <div class="row">
          <div class="col-md-4">
            </div>
           <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="Save"/>
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"/>
          </div>
      </div>
</asp:Content>

