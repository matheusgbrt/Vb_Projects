Module Module1
    Dim fileloc As String = My.Computer.FileSystem.ReadAllText("C:\Users\Inovea\Documents\Test Archives\config.txt")
    Dim text As String
    Dim novo As String

    Public Sub Main()
        Menu()
    End Sub
    Sub Menu()
        Console.WriteLine(vbLf & "Arquivo sendo editado:" & vbCrLf & fileloc)
        Console.WriteLine("Escolha a opção:" & vbCrLf & "1. Exibir conteúdo do arquivo" & vbCrLf & "2. Editar conteúdo do arquivo" & vbCrLf & "3. Escolher um novo arquivo" & vbCrLf & "4. Sair")
        Dim choice As Object = Console.ReadLine()
        Try
            choice = CInt(choice)
        Catch ex As Exception
            Console.WriteLine("Opção inválida, voltando ao menu.")
            Menu()
        End Try
        Select Case choice
            Case "1"
                ReadFile()
                Menu()
            Case "2"
                SubMenu()
            Case "3"
                ChangeFile()
            Case "4"
            Case Else
                Console.WriteLine("Opção inválida, voltando ao menu.")
                Menu()

        End Select
    End Sub
    Sub ReadFile()
        Console.WriteLine(vbCrLf & "Conteúdo do arquivo" & vbCrLf)
        text = My.Computer.FileSystem.ReadAllText(fileloc)
        Console.WriteLine(text)
    End Sub
    Sub SubMenu()
        Console.WriteLine("EDITOR DE TEXTO" & vbCrLf & "1. Adicionar ao final do arquivo" & vbCrLf & "2. Sobrescrever o arquivo" & vbCrLf & "3. Deletar todo o centeúdo do arquivo" & vbCrLf & "4. Voltar ao menu principal")
        Dim choice As Object = Console.ReadLine()
        Try
            choice = CInt(choice)
        Catch ex As Exception
            Console.WriteLine("Opção inválida, voltando ao menu.")
            SubMenu()
        End Try
        Select Case choice
            Case "1"
                WriteFileAppend()
                SubMenu()
            Case "2"
                WriteFileOverwrite()
            Case "3"
                DeleteFile()
            Case "4"
                Menu()
            Case Else
                Console.WriteLine("Opção inválida, voltando ao menu.")
                SubMenu()
        End Select

    End Sub
    Sub WriteFileAppend()
        text = My.Computer.FileSystem.ReadAllText(fileloc)
        Dim array() As String = text.Split(vbCrLf)
        If array.Length > 6 Then
            Console.WriteLine("Últimas três linhas do arquivo")
            For x = (array.Length - 5) To (array.Length - 1) Step 1
                Console.WriteLine(array(x) & vbLf)
            Next
        End If
        Console.WriteLine(vbCrLf & "Digite o texto para ser adicionado ao final do arquivo" & vbCrLf)
        Dim append As String = Console.ReadLine()
        My.Computer.FileSystem.WriteAllText(fileloc, append & vbCrLf, True)
        SubMenu()
    End Sub
    Sub WriteFileOverwrite()
        Console.WriteLine(vbCrLf & "Todo o texto será sobrescrito, digite CONFIRMAR para prosseguir" & vbCrLf)
        Dim confirm As String = Console.ReadLine()
        Select Case confirm
            Case "CONFIRMAR"
                Console.WriteLine(vbCrLf & "Digite o texto para ser escrito" & vbCrLf)
                Dim overwrite As String = Console.ReadLine()
                My.Computer.FileSystem.WriteAllText(fileloc, overwrite, False)
                SubMenu()
            Case Else
                Console.WriteLine(vbCrLf & "Voltando ao menu de edição" & vbCrLf)
                SubMenu()
        End Select
    End Sub
    Sub DeleteFile()
        Console.WriteLine(vbCrLf & "Todo o texto será DELETADO, digite CONFIRMAR para prosseguir" & vbCrLf)
        Dim confirm As String = Console.ReadLine()
        Select Case confirm
            Case "CONFIRMAR"
                My.Computer.FileSystem.WriteAllText(fileloc, " ", False)
                Console.WriteLine(vbCrLf & "Conteúdo deletado" & vbCrLf)
                SubMenu()
            Case Else
                Console.WriteLine(vbCrLf & "Voltando ao menu de edição" & vbCrLf)
                SubMenu()
        End Select
    End Sub
    Sub ChangeFile()
        Console.WriteLine(vbCrLf & "Digite o caminho do novo arquivo" & vbCrLf)
        Dim newpath As String = Console.ReadLine()
        My.Computer.FileSystem.WriteAllText("C:\Users\Inovea\Documents\Test Archives\config.txt", newpath, False)
        fileloc = My.Computer.FileSystem.ReadAllText("C:\Users\Inovea\Documents\Test Archives\config.txt")
        Menu()
    End Sub
End Module
