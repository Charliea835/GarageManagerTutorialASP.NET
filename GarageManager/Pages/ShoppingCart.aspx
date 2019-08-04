<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GarageManager.Pages.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlShoppingCart" runat="server">


    </asp:Panel>

    <table>

        <tr>
            <td>
                <b>Total:</b>
            </td>

            <td><asp:Literal ID ="litTotal" runat="server" Text="" /></td>
        </tr>

        <tr>
            <td>
                <b>Vat:</b>
            </td>

            <td><asp:Literal ID ="LitVat" runat="server" Text="" /></td>
        </tr>

        <tr>
            <td>
                <b>Shipping:</b>
            </td>

            <td>£15</td>
        </tr>

        <tr>
            <td>
                <b>Total Amount:</b>
            </td>

            <td><asp:Literal ID ="LitTotalAmount" runat="server" Text="" /></td>
        </tr>

        <tr>

        <td>
            <asp:LinkButton ID="lnkContinue" runat="server" PostBackUrl="~/Pages/Index.aspx" Text="Continue shopping" />
            OR
            <asp:Button ID="btnCheckOut" runat="server" PostBackUrl="~/Pages/Success.aspx" CssClass="button" Width="250px" Text="Continue Checkout" />
        </td>
        </tr>


    </table>
</asp:Content>
