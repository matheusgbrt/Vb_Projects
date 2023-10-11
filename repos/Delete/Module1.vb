Imports System.Diagnostics
Module Module1

    Sub Main()
        Dim logName As String = "MyNewLog"


        If EventLog.Exists(logName) Then
            ' Delete the event lo          EventLog.Delete(logName)
        End If
    End Sub

End Module
