<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Detalhes.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script src="./assets/JQuery/jquery-3.7.1.min.js" language="javascript" type="text/javascript"></script>
    <script src="./assets/JQuery/jquery-3.7.1.js" language="javascript" type="text/javascript"></script>
    <script src="./assets/JavaScript.js" language="javascript" type="text/javascript"></script>
    <link rel="stylesheet" href="./content/bootstrap.min.css" />
    <link rel="stylesheet" href="./assets/CSS/StyleSheet.css" />
</head>
<body>
    <div class="container-lg">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <telerik:RadGrid ID="RadGrid1" runat="server" Culture="pt-BR" DataSourceID="SqlDataSource1" Skin="Bootstrap">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

                <ExportSettings>
                    <Pdf PageWidth="">
                    </Pdf>
                </ExportSettings>
                <mastertableview autogeneratecolumns="False" datakeynames="IDMovies" datasourceid="SqlDataSource1">
                    <rowindicatorcolumn shownosorticon="False">
                    </rowindicatorcolumn>
                    <expandcollapsecolumn shownosorticon="False">
                    </expandcollapsecolumn>
                    <Columns>
<telerik:GridBoundColumn DataField="IDMovies" DataType="System.Int32" FilterControlAltText="Filter IDMovies column" HeaderText="IDMovies" ReadOnly="True" ShowNoSortIcon="False" SortExpression="IDMovies" UniqueName="IDMovies" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="id" DataType="System.Int32" FilterControlAltText="Filter id column" HeaderText="ID" ShowNoSortIcon="False" SortExpression="id" UniqueName="id">
                            <HeaderStyle HorizontalAlign="Center"
                                Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridCheckBoxColumn DataField="adult" DataType="System.Boolean" FilterControlAltText="Filter adult column" HeaderText="Adulto" ShowNoSortIcon="False" SortExpression="adult" UniqueName="adult" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" Width="25px"></HeaderStyle>
                        </telerik:GridCheckBoxColumn>
                        <telerik:GridBoundColumn DataField="title" FilterControlAltText="Filter title column" HeaderText="Título" ShowNoSortIcon="False" SortExpression="title" UniqueName="title" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle HorizontalAlign="Center"
                                Width="150px" />

                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="original_language" FilterControlAltText="Filter original_language column" HeaderText="Dialeto" ShowNoSortIcon="False" SortExpression="original_language" UniqueName="original_language" ItemStyle-HorizontalAlign="Center">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="overview" FilterControlAltText="Filter overview column" HeaderText="Descrição" ShowNoSortIcon="False" SortExpression="overview" UniqueName="overview" HeaderStyle-HorizontalAlign="Center">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="popularity" DataType="System.Double" FilterControlAltText="Filter popularity column" HeaderText="Popularidade" ShowNoSortIcon="False" SortExpression="popularity" UniqueName="popularity" ItemStyle-HorizontalAlign="Center">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="release_date" DataType="System.DateTime" FilterControlAltText="Filter release_date column" HeaderText="Lançamento" ShowNoSortIcon="False" SortExpression="release_date" UniqueName="release_date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"
                                Width="100px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="vote_average" DataType="System.Double" FilterControlAltText="Filter vote_average column" HeaderText="Nota popular" ShowNoSortIcon="False" SortExpression="vote_average" UniqueName="vote_average" ItemStyle-HorizontalAlign="Center">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="vote_count" DataType="System.Int16" FilterControlAltText="Filter vote_count column" HeaderText="Votos" ShowNoSortIcon="False" SortExpression="vote_count" UniqueName="vote_count">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <editformsettings>
                        <editcolumn shownosorticon="False">
                        </editcolumn>
                    </editformsettings>
                </mastertableview>
            </telerik:RadGrid>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesafioConnectionString %>" SelectCommand="SELECT * FROM [Movies] where IDMovies = @newparameter">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="newparameter" QueryStringField="var1" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
        </div>
</body>
</html>
