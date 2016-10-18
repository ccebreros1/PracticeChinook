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
                    <asp:ListView ID="RoleListView" runat="server" 
                        DataSourceID="RoleListODS" 
                        ItemType="RoleProfile"
                        InsertItemPosition="LastItem">

                        <EmptyDataTemplate>
                            <span>No security roles have been set up</span>
                        </EmptyDataTemplate>
                        <LayoutTemplate>
                            <div class="col-sm-3 h4">Action</div>
                            <div class="col-sm-3 h4">Role Name</div>
                            <div class="col-sm-6 h4">Users</div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div class="col-sm-3">
                                <asp:LinkButton ID="RemoveRole" runat="server">Remove</asp:LinkButton>
                            </div> 
                            <div class="col-sm-3">
                                <%# Item.RoleName %>
                            </div>
                            <div class="col-sm-6">
                                <asp:Repeater ID="RoleUsers" runat="server" DataSource=" <%# Item.UserNames %>">
                                    <ItemTemplate>
                                        <%# Item %>
                                    </ItemTemplate>
                                    <SeparatorTemplate>, </SeparatorTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <div class="col-sm-3">
                                <asp:LinkButton ID="InsertRole" runat="server">Insert</asp:LinkButton>&nbsp; &nbsp;
                                <asp:LinkButton ID="Cancel" runat="server">Insert</asp:LinkButton>
                            </div> 
                            <div class="col-sm-3">
                                <asp:TextBox ID="NewRoleName" runat="server" Text='<%# BindItem.RoleName %>' placeholder="Role Name"></asp:TextBox>
                            </div>
                        </InsertItemTemplate>

                    </asp:ListView>
                </div>
                <%--eop--%>
                <!--Unregistered tab-->
                <div class="tab-pane fade" id="unregistered">
                    <h2>Unregistered</h2>
                </div>
                <%--eop--%>
            </div>
        </div>
    </div>
</asp:Content>

