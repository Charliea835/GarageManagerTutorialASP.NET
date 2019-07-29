<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="GarageManager.Pages.Management.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Name:</p>
    <p>
        <asp:TextBox ID="txtName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    </p>
    <p>
        Type:</p>
    <p>
        <asp:DropDownList ID="ddlType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" SelectCommand="SELECT * FROM [ProductType] ORDER BY [Name]"></asp:SqlDataSource>
    </p>
    <p>
        Price:</p>
    <p>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </p>
    <p>
        Image:</p>
    <p id="ddlImage">
        <asp:DropDownList ID="ddlImages" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Description:</p>
    <p>
        <asp:TextBox ID="txtDescription" runat="server" Height="72px" TextMode="MultiLine" Width="200px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" />
    </p>
    <p>
        <asp:Label ID="LblResult" runat="server"></asp:Label>
    </p>
</asp:Content>
