<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row jumbotron">
        <h2>User and Role Administration</h2>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!--Nav Tabs-->
            <ul class="nav nav-tabs">
                <li class="active"><a href="#users" data-toggle="tab">Users</a></li>

                <li><a href="#roles" data-toggle="tab">Roles</a></li>

                <li><a href="#unregistered" data-toggle="tab">Unregistered Users</a></li>
            </ul>
            <!--Tab content area-->
            <div class="tab tab-content">
                <!--User tab-->
                <div class="tab-pane fade in active" id="users">
                    <h2>User</h2>

                </div>
                <%--eop--%>
                <!--Roles tab-->
                <div class="tab-pane fade" id="roles">
                    <!--DataKeyNames contains the considered pkey field
                        of class that is being used Instert, Update, Delete
                        
                        RefreshAll will call a generic method in my code behind that will cause the ODS sets to rebind their data-->
                    <asp:ListView ID="RoleListView" runat="server"
                        DataSourceID="RoleListViewODS"
                        ItemType="ChinookSystem.Security.RoleProfile"
                        InsertItemPosition="LastItem"
                        DataKeyNames="RoleId"
                        OnItemInserted="RefreshAll"
                        OnItemDeleted="RefreshAll">

                        <EmptyDataTemplate>
                            <span>No security roles have been set up</span>
                        </EmptyDataTemplate>

                        <LayoutTemplate>
                            <div class="row bginfo">
                                <div class="col-sm-3 h4">Action</div>
                                <div class="col-sm-3 h4">Role Name</div>
                                <div class="col-sm-6 h4">Users</div>
                            </div>
                            <div class="row" id="itemPlaceHolder" runat="server"></div>

                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="row">
                            <div class="col-sm-3">
                                <asp:LinkButton ID="RemoveRole" runat="server" CommandName="Delete">Remove</asp:LinkButton>
                            </div> 
                            <div class="col-sm-3">
                                <%# Item.RoleName %>
                            </div>
                            <div class="col-sm-6">
                                <asp:Repeater ID="RoleUsers" runat="server" DataSource=" <%# Item.UserNames %>" ItemType="System.String">
                                    <ItemTemplate>
                                        <%# Item %>
                                    </ItemTemplate>
                                    <SeparatorTemplate>, </SeparatorTemplate>
                                </asp:Repeater>
                            </div>
                                </div>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="row">
                            <div class="col-sm-3">
                                <asp:LinkButton ID="InsertRole" runat="server" CommandName="Insert">Insert</asp:LinkButton>&nbsp; &nbsp;
                                <asp:LinkButton ID="Cancel" runat="server">Cancel</asp:LinkButton>
                            </div> 
                            <div class="col-sm-3">
                                <asp:TextBox ID="NewRoleName" runat="server" Text='<%# BindItem.RoleName %>' placeholder="Role Name"></asp:TextBox>
                            </div>
                                </div>
                        </InsertItemTemplate>

                    </asp:ListView>
                </div>
                <%--eop--%>
                <!--Unregistered tab-->
                <div class="tab-pane fade" id="unregistered">
                    <h2>Unregistered</h2>
                     <asp:GridView ID="UnregisteredUsersGridView" runat="server" 
                        AutoGenerateColumns="False" 
                        DataSourceID="UnregisteredUsersODS"
                         DataKeyNames="CustomerEmployeeId"
                         ItemType="ChinookSystem.Security.UnregisteredUserProfile" OnSelectedIndexChanging="UnregisteredUsersGridView_SelectedIndexChanging">
                        <Columns>
                            <asp:CommandField SelectText="Register" ShowSelectButton="True"></asp:CommandField>
                            <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType"></asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
                            <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname"></asp:BoundField>
                            <asp:TemplateField HeaderText="AssignedUserName" SortExpression="AssignedUserName">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# Bind("AssignedUserName") %>' 
                                        ID="AssignedUserName"></asp:TextBox>
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AssignedEmail" SortExpression="AssignedEmail">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" Text='<%# Bind("AssignedEmail") %>' 
                                        ID="AssignedEmail"></asp:TextBox>
                                </ItemTemplate>
                               
                            </asp:TemplateField>

                        </Columns>
                         <EmptyDataTemplate>
                             <span>No Unregistered users available at this time</span>
                         </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="UnregisteredUsersODS" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="ListAllUnRegisteredUsers" 
                        TypeName="ChinookSystem.Security.UserManager">
                    </asp:ObjectDataSource>
                </div>
                <%--eop--%>
        </div>
      </div>
    </div>
    <asp:ObjectDataSource ID="RoleListViewODS" 
        runat="server" 
        DataObjectTypeName="ChinookSystem.Security.RoleProfile" 
        DeleteMethod="deleteRole" 
        InsertMethod="AddRole" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="ListAllRoles" 
        TypeName="ChinookSystem.Security.RoleManager"></asp:ObjectDataSource>
</asp:Content>

