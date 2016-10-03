<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RepresentativeCustomers.aspx.cs" Inherits="Queries_RepresentativeCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EmployeeODS" DataTextField="Name" DataValueField="EmployeeId"></asp:DropDownList>
    <asp:Button ID="Fetch" runat="server" Text="Fetch"/>

    <asp:GridView ID="RepCustomerList" runat="server" AutoGenerateColumns="False" DataSourceID="RepCustomerODS" AllowPaging="true">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State"></asp:BoundField>
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="RepCustomerODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="RepresentativeCostumers_Get" TypeName="ChinookSystem.BLL.CustomerController">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="employeeId" Type="Int32"></asp:ControlParameter>

        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="EmployeeODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="EmployeeNameList_Get" TypeName="ChinookSystem.BLL.EmployeeController"></asp:ObjectDataSource>
</asp:Content>

