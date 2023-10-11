
Imports Telerik.Web.UI
Imports System.Web.UI.WebControls
Imports System
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = TryCast(e.Item, GridDataItem)
            If item("Overview").Text.Length > 100 Then
                item.ToolTip = item("Overview").Text
                item("Overview").Text = item("Overview").Text.Substring(0, 70) & "..."
            End If
        End If
    End Sub
End Class

