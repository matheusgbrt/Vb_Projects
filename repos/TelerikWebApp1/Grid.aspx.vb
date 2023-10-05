Imports System.Collections.Generic
Imports System.Data
Imports Telerik.Web.UI

Partial Class Grid
    Inherits System.Web.UI.Page

    Public ReadOnly Property Sellers() As DataTable
        Get
            Dim data As DataTable = TryCast(Session("Data"), DataTable)

            If data Is Nothing Then
                data = GetSellers()
                Session("Data") = data
            End If

            Return data
        End Get
    End Property

    Public Function GetSellers() As DataTable
        Dim data As New DataTable()
        data.Columns.Add("ID", GetType(Integer))
        data.Columns.Add("Name")
        data.Columns.Add("Age", GetType(Integer)).DefaultValue = 0
        data.Columns.Add("BirthDate", GetType(DateTime))
        data.Columns.Add("Rating", GetType(Integer)).DefaultValue = 0
        data.Columns.Add("City")
        data.PrimaryKey = New DataColumn() {data.Columns("ID")}

        Dim firstNames As List(Of String) = New List(Of String)
        firstNames.Add("Nancy")
        firstNames.Add("Andrew")
        firstNames.Add("Janet")
        firstNames.Add("Margaret")
        firstNames.Add("Steven")
        firstNames.Add("Michael")
        firstNames.Add("Robert")
        firstNames.Add("Laura")
        firstNames.Add("Anne")
        firstNames.Add("Nige")

        Dim cities As List(Of String) = Me.GetCities()
        Dim birthDates As List(Of DateTime) = New List(Of Date)()
        birthDates.Add("1948/12/08")
        birthDates.Add("1952/02/19")
        birthDates.Add("1963/08/30")
        birthDates.Add("1937/09/19")
        birthDates.Add("1955/03/04")
        birthDates.Add("1963/07/02")
        birthDates.Add("1960/05/29")
        birthDates.Add("1958/01/09")
        birthDates.Add("1966/01/27")
        birthDates.Add("1966/03/27")
            
        Dim random As New Random()

        For i As Integer = 0 To 83
            Dim birthDate As DateTime = birthDates(random.[Next](birthDates.Count - 1))
            data.Rows.Add(random.[Next](10000, Integer.MaxValue), firstNames(random.[Next](firstNames.Count - 1)), DateTime.Now.Year - birthDate.Year, birthDate, random.[Next](1, 5), cities(random.[Next](cities.Count - 1)))
        Next

        Return data
    End Function

    Public Function GetCities() As List(Of String)
        Dim cities As List(Of String) = New List(Of String)
        cities.Add("Seattle")
        cities.Add("Tacoma")
        cities.Add("Kirkland")
        cities.Add("Redmond")
        cities.Add("London")
        cities.Add("Philadelphia")
        cities.Add("New York")
        cities.Add("London")
        cities.Add("Boston")

        Return cities
    End Function

    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs)
        RadGrid1.DataSource = Me.Sellers
    End Sub

    Protected Sub RadGrid1_UpdateCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs)
        Dim table As New Hashtable()
        TryCast(e.Item, GridEditableItem).ExtractValues(table)

        Dim row As DataRow = Me.Sellers.Rows.Find(TryCast(e.Item, GridEditableItem).GetDataKeyValue("ID"))

        For Each key As String In table.Keys
            row(key) = If(table(key), DBNull.Value)
        Next
        Dim [date] As DateTime
        If DateTime.TryParse((row("BirthDate").ToString()), [date]) Then
            row("Age") = DateTime.Now.Year - [date].Year
        Else
            row("Age") = 0
        End If
    End Sub

    Protected Sub RadGrid1_InsertCommand(sender As Object, e As GridCommandEventArgs)
        Dim table As New Hashtable()
        TryCast(e.Item, GridEditableItem).ExtractValues(table)
        Dim row As DataRow = Me.Sellers.NewRow()

        For Each key As String In table.Keys
            If table(key) IsNot Nothing Then
                row(key) = table(key)
            End If
        Next
        row("ID") = New Random().[Next](Integer.MaxValue)
        Dim [date] As DateTime
        If DateTime.TryParse((row("BirthDate").ToString()), [date]) Then
            row("Age") = DateTime.Now.[Date].Year - [date].Year
        End If
        Me.Sellers.Rows.InsertAt(row, 0)
    End Sub

    Protected Sub RadGrid1_DeleteCommand(sender As Object, e As GridCommandEventArgs)
        Me.Sellers.Rows.Remove(Me.Sellers.Rows.Find(TryCast(e.Item, GridEditableItem).GetDataKeyValue("ID")))
    End Sub

    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs)
        Dim comboBox As RadComboBox = TryCast(e.Item.FindControl("RCB_City"), RadComboBox)
        If comboBox IsNot Nothing Then
            If Not (TypeOf e.Item.DataItem Is GridInsertionObject) Then
                comboBox.SelectedValue = TryCast(e.Item.DataItem, DataRowView)("City").ToString()
            End If
            comboBox.DataTextField = String.Empty
            comboBox.DataSource = Me.GetCities()
            comboBox.DataBind()
            If Me.RadGrid1.ResolvedRenderMode = RenderMode.Mobile Then
                TryCast(e.Item.FindControl("TB_Age"), WebControl).Enabled = False
            Else
                TryCast(TryCast(e.Item, GridEditableItem)("Age").Controls(0), WebControl).Enabled = False
            End If
        End If
    End Sub
	
    Protected Sub RadGrid1_ItemCreated(sender As Object, e As GridItemEventArgs)
        Dim headerItem As GridHeaderItem = TryCast(e.Item, GridHeaderItem)
        If headerItem IsNot Nothing Then
            headerItem("EditColumn").Text = String.Empty
            headerItem("DeleteColumn").Text = String.Empty
        End If
    End Sub
End Class