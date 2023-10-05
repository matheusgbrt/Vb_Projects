Imports System.Net.Mail
Imports System.Configuration
Module Module1
    Dim titulo As String
    Dim content As String
    Dim receiver As String
    Dim server As New SmtpClient()
    Dim mail As New MailMessage()
    Sub Main()
        SmtpConfig()
        mail.To.Clear()
        Console.WriteLine("Enviador de E-mail" & vbLf & "Digite abaixo para quem deseja enviar um e-mail, separados por virgula")
        receiver = Console.ReadLine()
        receiver.Split(",")
        Console.WriteLine("Digite o título do E-mail")
        titulo = Console.ReadLine()
        Console.WriteLine("Digite o conteúdo do E-mail")
        content = Console.ReadLine()
        MailBuilder()
        server.Send(mail)

        Console.WriteLine("Digite 1 para enviar outro email, qualquer outra tecla para sair")
        Dim confirm As String = Console.ReadLine()
        Select Case confirm
            Case "1"
                Main()
            Case Else
        End Select

    End Sub
    Sub MailBuilder()
        mail.From = New MailAddress("matheusgbteste@outlook.com")
        mail.Subject = titulo
        mail.Body = content
        mail.To.Add(receiver)
    End Sub
    Sub SmtpConfig()
        server.Credentials = New Net.NetworkCredential(ConfigurationManager.AppSettings("FromEMail"), ConfigurationManager.AppSettings("Password"))
        server.Port = 587
        server.Host = "smtp-mail.outlook.com"
        server.EnableSsl = True
        server.DeliveryMethod = SmtpDeliveryMethod.Network
    End Sub
End Module
