<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManageProductTypes.aspx.cs" Inherits="GarageManager.Pages.Management.ManageProductTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Name:</p>
    <p>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="SubmitBTN" runat="server" OnClick="SubmitBTN_Click" Text="Submit" />
    </p>
    <p>
        <asp:Label ID="LabelResult" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
