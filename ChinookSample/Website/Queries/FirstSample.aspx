<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstSample.aspx.cs" Inherits="Queries_FirstSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Entity vs Linq to Entity Query</h1>
    <asp:TextBox ID="Year" runat="server"></asp:TextBox>
    <asp:Button ID="FetchYear" runat="server" Text="Fetch" />
    <asp:GridView ID="EntityFrameworkList" runat="server" AutoGenerateColumns="False" DataSourceID="EntityFrameworkODS" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="ArtistId" HeaderText="ArtistId" SortExpression="ArtistId"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="LinqToEntityList" runat="server" AutoGenerateColumns="False" DataSourceID="LinqToEntityODS" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="EntityFrameworkODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_ListAll" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LinqToEntityODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ArtistAlbums_Get" TypeName="ChinookSystem.BLL.ArtistController">
        <SelectParameters>
            <asp:ControlParameter ControlID="Year" PropertyName="Text" DefaultValue="2016" Name="year" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


