﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="AdminPanel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMainContent" Runat="Server">

      <div class="row">
        <div class="col-md-12 text-center">
            <h2 style="color: #0094ff">Contact List</h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
      <div style="overflow:scroll">
        <div class="col-md-12">
            <div>
                 <asp:HyperLink runat="server" ID="h1AddContact" Text="Add new Contact" NavigateUrl="~/AdminPanel/Contact/ContactAddEdit.aspx" CssClass="btn btn-primary"></asp:HyperLink>
            </div>
            <div>
              <asp:GridView ID="gvContact" runat="server" OnRowCommand="gvContact_RowCommand" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                  <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger"
                             CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID").ToString() %>' OnClientClick = "javascript : return confirm(' are you sure you want to delete your data?')"/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="h1Edit" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/Contact/ContactAddEdit.aspx?ContactID=" + Eval("ContactID").ToString().Trim() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CountryName" HeaderText="Country"/>
                    <asp:BoundField DataField="StateName" HeaderText="State"/>
                    <asp:BoundField DataField="CityName" HeaderText="City"/>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory"/>
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                    <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                    <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo" />
                    <asp:BoundField DataField="BirthDate" DataFormatString="{0:dd'/'MM'/'yyyy}" HeaderText="BirthDate" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                    <asp:BoundField DataField="FacebookID" HeaderText="FacebookID" />
                    <asp:BoundField DataField="LinkedINID" HeaderText="LinkedINID" />
                    
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                          <asp:Image runat="server" ID="ImgPhoto" ImageUrl='<%# Eval("ContactPhotoPath") %>' Height="70px" Width="100px"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                  <FooterStyle BackColor="Tan" />
                  <HeaderStyle BackColor="Tan" Font-Bold="True" />
                  <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                  <SortedAscendingCellStyle BackColor="#FAFAE7" />
                  <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                  <SortedDescendingCellStyle BackColor="#E1DB9C" />
                  <SortedDescendingHeaderStyle BackColor="#C2A47B" />
              </asp:GridView>
            </div>
         </div>
     </div>
 </div>
</asp:Content>

