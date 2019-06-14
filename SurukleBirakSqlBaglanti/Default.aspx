<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SurukleBirakSqlBaglanti._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TerritoryID" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="TerritoryID" HeaderText="TerritoryID" ReadOnly="True" SortExpression="TerritoryID" />
        <asp:BoundField DataField="TerritoryDescription" HeaderText="TerritoryDescription" SortExpression="TerritoryDescription" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>" 
    DeleteCommand="DELETE FROM [Territories] WHERE [TerritoryID] = @TerritoryID" 
    InsertCommand="INSERT INTO [Territories] ([TerritoryID], [TerritoryDescription]) VALUES (@TerritoryID, @TerritoryDescription)" 
    SelectCommand="SELECT [TerritoryID], [TerritoryDescription] FROM [Territories]" 
    UpdateCommand="UPDATE [Territories] SET [TerritoryDescription] = @TerritoryDescription WHERE [TerritoryID] = @TerritoryID">
    <DeleteParameters>
        <asp:Parameter Name="TerritoryID" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="TerritoryID" Type="String" />
        <asp:Parameter Name="TerritoryDescription" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="TerritoryDescription" Type="String" />
        <asp:Parameter Name="TerritoryID" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>

</asp:Content>
