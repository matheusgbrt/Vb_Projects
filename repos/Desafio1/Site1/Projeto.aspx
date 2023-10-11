<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Projeto.aspx.vb" Inherits="_Default" Culture="pt-BR" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Projeto Desafio</title>
    <script src="./assets/JQuery/jquery-3.7.1.min.js" language="javascript" type="text/javascript"></script>
    <script src="./assets/JQuery/jquery-3.7.1.js" language="javascript" type="text/javascript"></script>
    <script src="./assets/JavaScript.js" language="javascript" type="text/javascript"></script>
    <link rel="stylesheet" href="./content/bootstrap.min.css" />
    <link rel="stylesheet" href="./assets/CSS/StyleSheet.css" />

</head>
<body>
    <div class="container-lg">
        <nav class="navbar navbar-expand-lg navbar-light bg-light" id="nav1" style="margin-bottom: 2%">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Navbar</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dropdown
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="#">Action</a></li>
                                <li><a class="dropdown-item" href="#">Another action</a></li>
                                <li>
                                    <hr class="dropdown-divider" />
                                </li>
                                <li><a class="dropdown-item" href="#">Something else here</a></li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
                        </li>
                    </ul>
                    <form class="d-flex">
                        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
                        <button class="btn btn-outline-success" type="submit">Search</button>
                    </form>
                </div>
            </div>
        </nav>
        <form id="form1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesafioConnectionString %>" SelectCommand="SELECT [IDMovies], [id], [adult], [title], [original_language], [overview], [popularity], [release_date], [vote_average], [vote_count] FROM [Movies] ORDER BY [IDMovies]" DeleteCommand="DELETE FROM [Movies] WHERE [IDMovies] = @IDMovies" InsertCommand="INSERT INTO [Movies] ([id], [adult], [title], [original_language], [overview], [popularity], [release_date], [vote_average], [vote_count]) VALUES (@id, @adult, @title, @original_language, @overview, @popularity, @release_date, @vote_average, @vote_count)" UpdateCommand="UPDATE [Movies] SET [id] = @id, [adult] = @adult, [title] = @title, [original_language] = @original_language, [overview] = @overview, [popularity] = @popularity, [release_date] = @release_date, [vote_average] = @vote_average, [vote_count] = @vote_count WHERE [IDMovies] = @IDMovies">
                <DeleteParameters>
                    <asp:ControlParameter ControlID="RadGrid1" Name="IDMovies" PropertyName="SelectedValue" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:ControlParameter ControlID="RadGrid1" Name="IDMovies" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="id" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="adult" PropertyName="SelectedValue" Type="Boolean" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="title" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="original_language" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="overview" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="popularity" PropertyName="SelectedValue" Type="Double" />
                    <asp:ControlParameter ControlID="RadGrid1" DbType="Date" Name="release_date" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="vote_average" PropertyName="SelectedValue" Type="Double" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="vote_count" PropertyName="SelectedValue" Type="Int16" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:ControlParameter ControlID="RadGrid1" Name="id" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="adult" PropertyName="SelectedValue" Type="Boolean" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="title" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="original_language" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="overview" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="popularity" PropertyName="SelectedValue" Type="Double" />
                    <asp:ControlParameter ControlID="RadGrid1" DbType="Date" Name="release_date" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="vote_average" PropertyName="SelectedValue" Type="Double" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="vote_count" PropertyName="SelectedValue" Type="Int16" />
                    <asp:ControlParameter ControlID="RadGrid1" Name="IDMovies" PropertyName="SelectedValue" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="Bootstrap">
            </telerik:RadWindowManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap"></telerik:RadAjaxLoadingPanel>

            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
            
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteColumn="True" AutoGenerateEditColumn="True" Culture="pt-BR" DataSourceID="SqlDataSource1" ShowGroupPanel="True" AllowAutomaticDeletes="True" AllowAutomaticInserts="True" AllowAutomaticUpdates="True" SelectionMode="Row" RegisterWithScriptManager="False" Skin="Bootstrap" CssClass="GridView">
                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <ExportSettings>
                    <Pdf PageWidth="">
                    </Pdf>
                </ExportSettings>

                <ClientSettings AllowDragToGroup="True" AllowKeyboardNavigation="True" AllowRowsDragDrop="True" EnablePostBackOnRowClick="False">
                    <Selecting AllowRowSelect="True" />
                    <ClientEvents OnRowDblClick="PaginaDetalhes" OnPopUpShowing="onPopUpShowing" OnCommand="gridCommand" />
                </ClientSettings>

                <MasterTableView EditMode="PopUp" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="IDMovies,id" ClientDataKeyNames="IDMovies,id"
                    CommandItemDisplay="Top">
                    <RowIndicatorColumn ShowNoSortIcon="False"></RowIndicatorColumn>

                    <ExpandCollapseColumn ShowNoSortIcon="False"></ExpandCollapseColumn>

                    <Columns>
                        <telerik:GridBoundColumn DataField="IDMovies" DataType="System.Int32" FilterControlAltText="Filter IDMovies column" HeaderText="IDMovies" ReadOnly="True" ShowNoSortIcon="False" SortExpression="IDMovies" UniqueName="IDMovies" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="id" DataType="System.Int32" FilterControlAltText="Filter id column" HeaderText="ID" ShowNoSortIcon="False" SortExpression="id" UniqueName="id">
                            <HeaderStyle HorizontalAlign="Center"
                                Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="adult" DataType="System.Boolean" FilterControlAltText="Filter adult column" HeaderText="Adulto" ShowNoSortIcon="False" SortExpression="adult" UniqueName="adult" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="25px">
                            <HeaderStyle HorizontalAlign="Center" Width="25px"></HeaderStyle>
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="title" FilterControlAltText="Filter title column" HeaderText="Título" ShowNoSortIcon="False" SortExpression="title" UniqueName="title" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle HorizontalAlign="Center"
                                Width="50px" />

                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="original_language" FilterControlAltText="Filter original_language column" HeaderText="Dialeto" ShowNoSortIcon="False" SortExpression="original_language" UniqueName="original_language" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="overview" FilterControlAltText="Filter overview column" HeaderText="Descrição" ShowNoSortIcon="False" SortExpression="overview" UniqueName="overview" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="popularity" DataType="System.Double" FilterControlAltText="Filter popularity column" HeaderText="Popularidade" ShowNoSortIcon="False" SortExpression="popularity" UniqueName="popularity" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="release_date" DataType="System.DateTime" FilterControlAltText="Filter release_date column" HeaderText="Lançamento" ShowNoSortIcon="False" SortExpression="release_date" UniqueName="release_date" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle HorizontalAlign="Center"
                                Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="vote_average" DataType="System.Double" FilterControlAltText="Filter vote_average column" HeaderText="Nota popular" ShowNoSortIcon="False" SortExpression="vote_average" UniqueName="vote_average" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="vote_count" DataType="System.Int16" FilterControlAltText="Filter vote_count column" HeaderText="Votos" ShowNoSortIcon="False" SortExpression="vote_count" UniqueName="vote_count" Visible="false">
                        </telerik:GridBoundColumn>
                    </Columns>
                    </MasterTableView>
                <SelectedItemStyle BackColor="Transparent" CssClass="SelectedRow" />
            </telerik:RadGrid>
                </telerik:RadAjaxPanel>
        </form>
    </div>

</body>
</html>
