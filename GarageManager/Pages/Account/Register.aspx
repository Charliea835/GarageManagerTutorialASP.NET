<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GarageManager.Pages.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Literal ID="litStatus" runat="server"></asp:Literal>
    </p>
    <p>
        User name:</p>
    <p>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Password:</p>
    <p>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        Confirm Password:</p>
    <p>
        <asp:TextBox ID="txtConfpassword" runat="server" CssClass="inputs" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        First name:</p>
    <p>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Last name:</p>
    <p>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Address:</p>
    <p>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        Postal code:</p>
    <p>
        <asp:TextBox ID="txtPostalCode" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="Submit" />
    </p>
</asp:Content>
