Module Module1
    Dim seletormenu As Object
    Dim array(4, 4) As String
    Dim linha As Object
    Dim coluna As Object
    Dim valor As Object
    Sub Main()
        Randomize()
        For index As Integer = 0 To 4
            For index2 As Integer = 0 To 4
                Dim value As Integer = CInt(Int((1000 * Rnd())) + 1)
                array(index, index2) = index & "." & index2 & ("   ") & value

            Next
        Next
        Menu()
    End Sub



    Sub Menu()
        Console.WriteLine("Menu inicial")
        Console.WriteLine("1. Exibir dados")
        Console.WriteLine("2. Editar dados")
        Console.WriteLine("3. Sair")
        Console.WriteLine(vbCrLf)
        seletormenu = Console.ReadLine()
        Try
            seletormenu = CInt(seletormenu)
        Catch ex As Exception
            Console.WriteLine(vbCrLf)
            Console.WriteLine("Opção inválida")
            Console.WriteLine(vbCrLf)
            Menu()
        End Try
        Seletor(seletormenu)

    End Sub
    Function Seletor(ByVal seletormenu As Integer)

        Select Case seletormenu
            Case "1"
                For index As Integer = 0 To 4
                    For index2 As Integer = 0 To 4
                        Console.WriteLine(array(index, index2))
                    Next
                Next
                Console.WriteLine(vbCrLf)
                Menu()
            Case "2"
                Editar()
            Case "3"

        End Select
        Return Nothing
    End Function
    Sub Editar()

        Console.WriteLine("Digite o numero da linha que deseja alterar ou digite VOLTAR para voltar ao menu principal")
        linha = Console.ReadLine()
        If CStr(linha) = "VOLTAR" Then
            Menu()
        End If
        Console.WriteLine("Digite o numero da coluna que deseja alterar")
        coluna = Console.ReadLine()

        Console.WriteLine("Digite o valor")
        valor = Console.ReadLine()
        Try
            linha = CInt(linha)
            coluna = CInt(coluna)
        Catch ex As Exception
            Console.WriteLine(vbCrLf)
            Console.WriteLine("Valores inválidos")
            Editar()
        End Try
        valor = linha & "." & coluna & "   " & valor
        Console.WriteLine(array(linha, coluna) & " será sobrescrito por " & valor & ". Digite 1 para confirmar")
        Dim conf As Object = Console.ReadLine()
        If conf = 1 Then
            array(linha, coluna) = valor
        Else
            Console.WriteLine("Operação cancelada, voltando ao menu principal.")
            Menu()
        End If
        Menu()
    End Sub
End Module
