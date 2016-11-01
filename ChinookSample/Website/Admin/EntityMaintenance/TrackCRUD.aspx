<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrackCRUD.aspx.cs" Inherits="Admin_EntityMaintenance_TrackCRUD" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="my" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron">
        <h1>Wired ListView CRUD</h1>
    </div>
    <my:MessageUserControl runat="server" ID="MessageUserControl" />
    <asp:ListView ID="TrackList" runat="server" DataSourceID="TrackListODS" InsertItemPosition="LastItem" DataKeyNames="TrackId" >
        <EditItemTemplate>
            <tr style="background-color: #008A8C; color: #000000;">
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("TrackId") %>' runat="server" ID="TrackIdTextBox" Enabled="false" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" /></td>
                <td>
                    <asp:DropDownList ID="DropDownListAlbum" runat="server" DataSourceID="AlbumListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Bind("AlbumId") %>'></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="DropDownListMediaType" runat="server" DataSourceID="MediaTypeListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Bind("MediaTypeId") %>'></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="DropDownListGenre" runat="server" DataSourceID="GenreListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Bind("GenreId") %>'></asp:DropDownList></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Composer") %>' runat="server" ID="ComposerTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Milliseconds") %>' runat="server" ID="MilisecondsTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Bytes") %>' runat="server" ID="BytesTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" /></td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" CssClass="btn btn-success" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" CssClass="btn btn-info" />
                </td>
                <td>
                    <asp:TextBox Text='<%# Bind("TrackId") %>' runat="server" ID="TrackIdTextBox" Enabled="false"/></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" /></td>
                <td>
                    <asp:DropDownList ID="DropDownListAlbum" runat="server" DataSourceID="AlbumListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Bind("AlbumId") %>'></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="DropDownListMediaType" runat="server" DataSourceID="MediaTypeListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Bind("MediaTypeId") %>'></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="DropDownListGenre" runat="server" DataSourceID="GenreListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Bind("GenreId") %>'></asp:DropDownList></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Composer") %>' runat="server" ID="ComposerTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Milliseconds") %>' runat="server" ID="MilisecondsTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Bytes") %>' runat="server" ID="BytesTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" /></td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" CssClass="btn btn-danger" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" CssClass="btn btn-info"/>
                </td>
                <td>
                    <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                <td>
                    <asp:DropDownList ID="DropDownListAlbum" runat="server" DataSourceID="AlbumListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Eval("AlbumId") %>'></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="DropDownListMediaType" runat="server" DataSourceID="MediaTypeListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Eval("MediaTypeId") %>'></asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="DropDownListGenre" runat="server" DataSourceID="GenreListODS" DataTextField="DisplayText" DataValueField="PFKeyIdentifier" selectedValue='<%# Eval("GenreId") %>'></asp:DropDownList></td>
                <td>
                    <asp:Label Text='<%# Eval("Composer") %>' runat="server" ID="ComposerLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MilisecondsLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1"
                            class="table table-hover table-bordered table-condensed">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server" style="background-color:#337ab7;color:white; width:300px;"></th>
                                <th runat="server" style="background-color:#337ab7;color:white;">Track</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">Name</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">Album</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">MediaTypeId</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">GenreId</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">Composer</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">Ms</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">Bytes</th>
                                <th runat="server" style="background-color:#337ab7;color:white;">UnitPrice</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                        <asp:DataPager runat="server" ID="DataPager1">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                <asp:NumericPagerField></asp:NumericPagerField>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>
                <td>
                    <asp:Label Text='<%# Eval("TrackId") %>' runat="server" ID="TrackIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("MediaTypeId") %>' runat="server" ID="MediaTypeIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("GenreId") %>' runat="server" ID="GenreIdLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Composer") %>' runat="server" ID="ComposerLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MilisecondsLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Bytes") %>' runat="server" ID="BytesLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Album") %>' runat="server" ID="AlbumLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("MediaType") %>' runat="server" ID="MediaTypeLabel" /></td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="TrackListODS" runat="server" DataObjectTypeName="ChinookSystem.Data.Entities.Track"
        DeleteMethod="DeleteTrack"
        InsertMethod="AddTrack"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ListTracks"
        TypeName="ChinookSystem.BLL.TrackController"
        UpdateMethod="UpdateTrack"
        OnDeleted="CheckForException" OnInserted="CheckForException" OnSelected="CheckForException" OnUpdated="CheckForException"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AlbumListODS" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="AlbumList"
        TypeName="ChinookSystem.BLL.AlbumController"
        OnDeleted="CheckForException" OnInserted="CheckForException" OnSelected="CheckForException" OnUpdated="CheckForException"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="MediaTypeListODS" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="MediaTypeList"
        TypeName="ChinookSystem.BLL.MediaTypeController"
        OnDeleted="CheckForException" OnInserted="CheckForException" OnSelected="CheckForException" OnUpdated="CheckForException"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="GenreListODS" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GenreList"
        TypeName="ChinookSystem.BLL.GenreController"
        OnDeleted="CheckForException" OnInserted="CheckForException" OnSelected="CheckForException" OnUpdated="CheckForException"></asp:ObjectDataSource>

</asp:Content>

