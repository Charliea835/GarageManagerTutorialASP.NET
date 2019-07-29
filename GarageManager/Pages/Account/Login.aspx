<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GarageManager.Pages.Account.Login" %>
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
        <asp:Button ID="loginBTN" runat="server" CssClass="button" OnClick="Button1_Click" Text="Login" />
    </p>
</asp:Content>
