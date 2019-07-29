<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="GarageManager.Pages.Management.Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" PostBackUrl="~/Pages/Management/ManageProducts.aspx">Add a new product</asp:LinkButton>
<br />
<asp:GridView ID="GridProducts" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Width="100%" OnRowEditing="GridProducts_RowEditing">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="TypeID" HeaderText="TypeID" SortExpression="TypeID" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" DeleteCommand="DELETE FROM [Product] WHERE [ID] = @original_ID AND [TypeID] = @original_TypeID AND [Name] = @original_Name AND [Price] = @original_Price AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([Image] = @original_Image) OR ([Image] IS NULL AND @original_Image IS NULL))" InsertCommand="INSERT INTO [Product] ([TypeID], [Name], [Price], [Description], [Image]) VALUES (@TypeID, @Name, @Price, @Description, @Image)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [TypeID] = @TypeID, [Name] = @Name, [Price] = @Price, [Description] = @Description, [Image] = @Image WHERE [ID] = @original_ID AND [TypeID] = @original_TypeID AND [Name] = @original_Name AND [Price] = @original_Price AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([Image] = @original_Image) OR ([Image] IS NULL AND @original_Image IS NULL))">
    <DeleteParameters>
        <asp:Parameter Name="original_ID" Type="Int32" />
        <asp:Parameter Name="original_TypeID" Type="Int32" />
        <asp:Parameter Name="original_Name" Type="String" />
        <asp:Parameter Name="original_Price" Type="Decimal" />
        <asp:Parameter Name="original_Description" Type="String" />
        <asp:Parameter Name="original_Image" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="TypeID" Type="Int32" />
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Price" Type="Decimal" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="Image" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="TypeID" Type="Int32" />
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="Price" Type="Decimal" />
        <asp:Parameter Name="Description" Type="String" />
        <asp:Parameter Name="Image" Type="String" />
        <asp:Parameter Name="original_ID" Type="Int32" />
        <asp:Parameter Name="original_TypeID" Type="Int32" />
        <asp:Parameter Name="original_Name" Type="String" />
        <asp:Parameter Name="original_Price" Type="Decimal" />
        <asp:Parameter Name="original_Description" Type="String" />
        <asp:Parameter Name="original_Image" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>
<br />
<asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Pages/Management/ManageProductTypes.aspx">Add new product type</asp:LinkButton>
<br />
<br />
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" Width="50%">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" DeleteCommand="DELETE FROM [ProductType] WHERE [ID] = @original_ID AND [Name] = @original_Name" InsertCommand="INSERT INTO [ProductType] ([Name]) VALUES (@Name)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [ProductType]" UpdateCommand="UPDATE [ProductType] SET [Name] = @Name WHERE [ID] = @original_ID AND [Name] = @original_Name">
    <DeleteParameters>
        <asp:Parameter Name="original_ID" Type="Int32" />
        <asp:Parameter Name="original_Name" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Name" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Name" Type="String" />
        <asp:Parameter Name="original_ID" Type="Int32" />
        <asp:Parameter Name="original_Name" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>
<br />
</asp:Content>
