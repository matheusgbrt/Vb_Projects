Imports System.Globalization
Imports Telerik.Web.UI

Namespace Telerik.GridExamplesVBNET.AccessibilityAndInternationalization.Localization
    Partial Class DefaultVB
        Inherits System.Web.UI.Page
        Protected Sub radiobuttonlistLanguages_SelectedIndexChanged(sender As Object, e As System.EventArgs)
            Dim newCulture As CultureInfo = CultureInfo.CreateSpecificCulture(radiobuttonlistLanguages.SelectedItem.Value)
            RadGrid1.Culture = newCulture
            RadGrid1.Rebind()
        End Sub
    End Class
End Namespace
