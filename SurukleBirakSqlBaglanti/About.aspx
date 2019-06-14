<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SurukleBirakSqlBaglanti.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Deneme</h2>
    <asp:GridView ID="GridView1" DataKeyNames="TerritoryID" runat="server" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="true"
                HeaderText="Silme"/>
            <asp:CommandField ShowEditButton="true"
                HeaderText="Guncelle" />
             
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" 
        runat="server" 
        ConnectionString="Data Source=.;Initial Catalog=NORTHWND;Integrated Security=True"
        SelectCommand="Select [TerritoryID],[TerritoryDescription] from [Territories]"
        DeleteCommand="DELETE FROM [Territories] WHERE [TerritoryID]=@TerritoryID"
        UpdateCommand="UPDATE [Territories] 
        SET [TerritoryDescription]=@TerritoryDescription 
        WHERE [TerritoryID]=@TerritoryID "
        >
        <UpdateParameters>
            <asp:Parameter Name="TerritoryDescription" DbType="String" />
            <asp:Parameter Name="TerritoryID" DbType="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="TerritoryID" DbType="Int32" />
        </DeleteParameters>
        
    </asp:SqlDataSource>
</asp:Content>

