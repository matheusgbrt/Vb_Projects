Imports System.IO
Imports System.Diagnostics
Imports System.Timers
Public Class ServicoTeste
    Private arquivoWS As StreamWriter
    Dim TimerExec As Timer = New Timer()

    Protected Overrides Sub OnStart(ByVal args() As String)
        arquivoWS = New StreamWriter("c://servicelog.log", True)
        Dim logSource As String = "TestService"
        Dim logName As String = "TesteEventoServico"
        Dim eventLog As New EventLog()
        Try
            If Not EventLog.SourceExists(logSource) Then
                EventLog.CreateEventSource(logSource, logName)
            End If
            LogWriting("Inicializando")
        Catch ex As Exception
            LogWriting("Crash em razão de:" & ex.Message)
        End Try
        TimerExec.Interval = 15000
        AddHandler TimerExec.Elapsed, AddressOf OnTimer
        TimerExec.Start()
    End Sub

    Protected Overrides Sub OnStop()
        Try
            LogWriting("Encerrado")
            arquivoWS.Close()
            If TimerExec IsNot Nothing Then
                TimerExec.Stop()
                TimerExec.Dispose()
            End If
        Catch ex As Exception
            LogWriting("Crash em razão de:" & ex.Message)
            arquivoWS.Close()
        End Try
    End Sub
    Private Sub OnTimer()
        LogWriting("Timer rodando.")
    End Sub
    Private Sub LogWriting(args As String)
        EventLog1.WriteEntry("Escrevendo no log: " & args)
        arquivoWS.WriteLine("Escrevendo no log: " & args & " as: " & Date.Now())
        arquivoWS.Flush()
    End Sub

End Class
