<%@ Page Language="VB" Inherits="Telerik.GridExamplesVBNET.AccessibilityAndInternationalization.Localization.DefaultVB"CodeFile="DefaultVB.aspx.vb"  %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head runat="server">
    <title>Telerik ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ConfigurationPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" DataSourceID="SqlDataSource1" AllowSorting="True"
        EnableHeaderContextFilterMenu="true" EnableHeaderContextMenu="true" AllowPaging="True"
        runat="server" GridLines="None" AllowFilteringByColumn="True" ShowGroupPanel="True">
        <MasterTableView TableLayout="Fixed">
        </MasterTableView>
        <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
        <ClientSettings AllowDragToGroup="True">
        </ClientSettings>
    </telerik:RadGrid>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, PostalCode FROM Customers"
        runat="server"></asp:SqlDataSource>
    <qsf:ConfiguratorPanel runat="server" ID="ConfigurationPanel1">
        <Views>
            <qsf:View>
                <qsf:ConfiguratorColumn ID="ConfiguratorColumn1" runat="server" Size="Narrow" Title="Choose language">
                    <qsf:RadioButtonList ID="radiobuttonlistLanguages" runat="server" RepeatDirection="Vertical"
                        AutoPostBack="True" Style="margin-left: 1em" OnSelectedIndexChanged="radiobuttonlistLanguages_SelectedIndexChanged">
                        <asp:ListItem Value="de-DE"><img src="flags/german.gif" alt="Deutsch"/> Deutsch</asp:ListItem>
                        <asp:ListItem Value="en-US" Selected="true"><img src="flags/english.gif" alt="English" /> English</asp:ListItem>
                        <asp:ListItem Value="fr-FR"><img src="flags/french.gif" alt="Français" /> Français</asp:ListItem>
                        <asp:ListItem Value="bg-BG"><img src="flags/bulgarian.gif" alt="Български" /> Български</asp:ListItem>
                    </qsf:RadioButtonList>
                </qsf:ConfiguratorColumn>
            </qsf:View>
        </Views>
    </qsf:ConfiguratorPanel>
    </form>
</body>
</html>