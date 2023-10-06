Imports ClosedXML.Excel
Module Module1

    Sub Main()
        Menu()
    End Sub
    Sub Menu()
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
            Case "2"
            Case "3"
            Case "4"
            Case Else
                Console.WriteLine("Opção inválida, voltando ao menu.")
                Menu()

        End Select
    End Sub

End Module
