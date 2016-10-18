<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
                </div><%--eop--%>
                <!--Roles tab-->
                <div class="tab-pane fade" id="roles">
                    <h2>Roles</h2>
                </div><%--eop--%>
                <!--Unregistered tab-->
                <div class="tab-pane fade" id="unregistered">
                    <h2>Unregistered</h2>
                </div><%--eop--%>
            </div>
        </div>    
    </div>
</asp:Content>

