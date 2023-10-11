<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DesafioConnectionString %>" SelectCommand="SELECT [id], [adult], [title], [original_language], [overview], [popularity], [release_date], [vote_average], [vote_count] FROM [Movies]"></asp:SqlDataSource>
            <telerik:RadGrid ID="RadGrid1" runat="server" Culture="pt-BR" DataSourceID="SqlDataSource1">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>

<MasterTableView AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
<RowIndicatorColumn ShowNoSortIcon="False"></RowIndicatorColumn>

<ExpandCollapseColumn ShowNoSortIcon="False"></ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="id" DataType="System.Int32" FilterControlAltText="Filter id column" HeaderText="id" ShowNoSortIcon="False" SortExpression="id" UniqueName="id">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="adult" FilterControlAltText="Filter adult column" HeaderText="adult" ShowNoSortIcon="False" SortExpression="adult" UniqueName="adult">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="title" FilterControlAltText="Filter title column" HeaderText="title" ShowNoSortIcon="False" SortExpression="title" UniqueName="title">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="original_language" FilterControlAltText="Filter original_language column" HeaderText="original_language" ShowNoSortIcon="False" SortExpression="original_language" UniqueName="original_language">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="overview" FilterControlAltText="Filter overview column" HeaderText="overview" ShowNoSortIcon="False" SortExpression="overview" UniqueName="overview">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="popularity" DataType="System.Double" FilterControlAltText="Filter popularity column" HeaderText="popularity" ShowNoSortIcon="False" SortExpression="popularity" UniqueName="popularity">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="release_date" DataType="System.DateTime" FilterControlAltText="Filter release_date column" HeaderText="release_date" ShowNoSortIcon="False" SortExpression="release_date" UniqueName="release_date">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="vote_average" DataType="System.Double" FilterControlAltText="Filter vote_average column" HeaderText="vote_average" ShowNoSortIcon="False" SortExpression="vote_average" UniqueName="vote_average">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="vote_count" DataType="System.Int16" FilterControlAltText="Filter vote_count column" HeaderText="vote_count" ShowNoSortIcon="False" SortExpression="vote_count" UniqueName="vote_count">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn ShowNoSortIcon="False"></EditColumn>
</EditFormSettings>
</MasterTableView>
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>
