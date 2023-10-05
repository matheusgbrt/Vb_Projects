Module Module1
    Dim v1 As Object
    Dim v2 As Object
    Dim resultado As Object
    Sub Main()
        Leitura()
        resultado = Operacao(v1, v2)
        Console.WriteLine("O resultado da sua operação é " & resultado)
        Console.ReadLine()
    End Sub
    Sub Leitura()
        Console.WriteLine("Digite um valor para ser calculado")
        v1 = Console.ReadLine()
        Console.WriteLine("Digite outro valor para ser calculado")
        v2 = Console.ReadLine()
        Try
            v1 = CDbl(v1)
            v2 = CDbl(v2)
        Catch ex As Exception
            Console.Write("Valor inválido, digite novamente" & vbCrLf)
            Console.Write(" ")
            Leitura()
        End Try
    End Sub
    Function Operacao(ByVal v1 As Double, ByVal v2 As Double)
        Console.WriteLine("Digite 1 para adição, 2 para subtração, 3 para multiplicação ou 4 para divisão")
        Dim v3 As Object = Console.ReadLine()
        Try
            v3 = CDbl(v3)
        Catch ex As Exception
            Console.Write("Valor inválido, digite novamente" & vbCrLf)
            Console.Write(" ")
            Operacao(v1, v2)
        End Try

        Select Case v3
            Case "1"
                resultado = v1 + v2
            Case "2"
                resultado = v1 - v2
            Case "3"
                resultado = v1 * v2
            Case "4"
                resultado = v1 / v2
        End Select

        Return resultado
    End Function


End Module
