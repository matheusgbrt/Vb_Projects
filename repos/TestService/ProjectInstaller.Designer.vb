<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Descartar substituições de instalador para limpar lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Designer de Componentes
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Designer de Componentes
    'Pode ser modificado usando o Designer de Componentes.
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.InstaladorTesteServico = New System.ServiceProcess.ServiceProcessInstaller()
        Me.TesteServico = New System.ServiceProcess.ServiceInstaller()
        Me.EventLogInstaller1 = New System.Diagnostics.EventLogInstaller()
        '
        'InstaladorTesteServico
        '
        Me.InstaladorTesteServico.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.InstaladorTesteServico.Password = Nothing
        Me.InstaladorTesteServico.Username = Nothing
        '
        'TesteServico
        '
        Me.TesteServico.ServiceName = "TesteServico"
        '
        'EventLogInstaller1
        '
        Me.EventLogInstaller1.CategoryCount = 0
        Me.EventLogInstaller1.CategoryResourceFile = Nothing
        Me.EventLogInstaller1.Log = "TesteEventoServico"
        Me.EventLogInstaller1.MessageResourceFile = Nothing
        Me.EventLogInstaller1.ParameterResourceFile = Nothing
        Me.EventLogInstaller1.Source = "TestService"
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.InstaladorTesteServico, Me.TesteServico, Me.EventLogInstaller1})

    End Sub

    Friend WithEvents InstaladorTesteServico As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents TesteServico As ServiceProcess.ServiceInstaller
    Friend WithEvents EventLogInstaller1 As EventLogInstaller
End Class
