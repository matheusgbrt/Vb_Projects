Imports System.ComponentModel
Imports System.Configuration.Install

Public Class ProjectInstaller

    Public Sub New()
        MyBase.New()

        'Esta chamada é exigida pelo Designer de Componentes.
        InitializeComponent()

        'Adicione código de inicialização adicional após a chamada a InitializeComponent

    End Sub

    Private Sub ServiceInstaller1_AfterInstall(sender As Object, e As InstallEventArgs) Handles TesteServico.AfterInstall

    End Sub
End Class
