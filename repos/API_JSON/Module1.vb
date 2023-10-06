Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports ClosedXML.Excel
Imports System.Data.SqlClient
Module Module1
    Dim cnpj As String
    Dim ano As String
    Dim sequencial As String
    Dim FormattedResposta As String
    Dim Desconstruido As Contrato
    Dim Entidade As OrgaoEntidade
    Dim Unidade As UnidadeOrgao
    Dim TContrato As TipoContrato
    Dim CatProcesso As CategoriaProcesso


    Public Class OrgaoEntidade
        Public Property cnpj As String
        Public Property razaoSocial As String
        Public Property poderId As String
        Public Property esferaId As String
    End Class

    Public Class UnidadeOrgao
        Public Property ufNome As String
        Public Property codigoUnidade As String
        Public Property nomeUnidade As String
        Public Property ufSigla As String
        Public Property municipioNome As String
        Public Property municipioId As Integer
    End Class

    Public Class TipoContrato
        Public Property id As Integer
        Public Property nome As String
    End Class

    Public Class CategoriaProcesso
        Public Property id As Integer
        Public Property nome As String
    End Class

    Public Class Contrato
        Public Property orgaoEntidade As OrgaoEntidade
        Public Property orgaoSubRogado As Object
        Public Property unidadeOrgao As UnidadeOrgao
        Public Property unidadeSubRogada As Object
        Public Property anoContrato As Integer
        Public Property sequencialContrato As Integer
        Public Property numeroRetificacao As Integer
        Public Property dataAtualizacao As DateTime
        Public Property NiFornecedor As String
        Public Property tipoPessoa As String
        Public Property tipoPessoaSubContratada As Object
        Public Property dataPublicacaoPncp As DateTime
        Public Property tipoContrato As TipoContrato
        Public Property numeroContratoEmpenho As String
        Public Property dataAssinatura As String
        Public Property dataVigenciaInicio As String
        Public Property dataVigenciaFim As String
        Public Property categoriaProcesso As CategoriaProcesso
        Public Property nomeRazaoSocialFornecedor As String
        Public Property informacaoComplementar As String
        Public Property processo As String
        Public Property niFornecedorSubContratado As Object
        Public Property nomeFornecedorSubContratado As Object
        Public Property receita As Boolean
        Public Property objetoContrato As String
        Public Property valorInicial As Double
        Public Property numeroParcelas As Integer
        Public Property valorParcela As Double?
        Public Property valorGlobal As Double
        Public Property valorAcumulado As Double
        Public Property identificadorCipi As String
        Public Property urlCipi As Object
        Public Property numeroControlePNCP As String
        Public Property usuarioNome As String
        Public Property codigoPaisFornecedor As String
        Public Property numeroControlePncpCompra As String
    End Class


    Sub Main()
        Console.WriteLine("Escolha a opção:" & vbCrLf & "1. Inserir na base de dados" & vbCrLf & "2. Inserir no excel" & vbCrLf & "3. Consultar a base de dados" & vbCrLf & "4. Sair")
        Dim choice As Object = Console.ReadLine()
        Try
            choice = CInt(choice)
        Catch ex As Exception
            Console.WriteLine("Opção inválida, voltando ao menu.")
            Menu()
        End Try
        Select Case choice
            Case "1"
                Menu()
                APICall(cnpj, ano, sequencial)
                dbinsert()
                Main()
            Case "2"
                Menu()
                APICall(cnpj, ano, sequencial)
                WorkbookAppendDTable()
                Main()
            Case "3"
                dbread()
            Case "4"
            Case Else
                Console.WriteLine("Opção inválida, voltando ao menu.")
                Menu()
        End Select
    End Sub

    Sub Menu()
        Console.WriteLine("CHAMADA DE API" & vbLf & "Digite o CNPJ do contratante")
        cnpj = Console.ReadLine()
        Console.WriteLine("Digite o ano do contratato")
        ano = Console.ReadLine()
        Console.WriteLine("Digite o sequencial do contratato")
        sequencial = Console.ReadLine()

    End Sub
    Public Async Sub APICall(ByVal cnpj, ByVal ano, ByVal sequencial)
        Dim client As HttpClient = New HttpClient()
        client.BaseAddress = New Uri("https://treina.pncp.gov.br/api/pncp")
        Dim endpoint = String.Format("https://treina.pncp.gov.br/api/pncp/v1/orgaos/{0}/contratos/{1}/{2}", cnpj, ano, sequencial)
        Dim resposta As HttpResponseMessage = Await client.GetAsync(endpoint)
        Try
            resposta.EnsureSuccessStatusCode()
        Catch ex As Exception
            Console.WriteLine("Ocorreu um erro: " & ex.Message)
            Main()
        End Try
        FormattedResposta = Await resposta.Content.ReadAsStringAsync()
        Dim config As New JsonSerializerSettings With {
        .NullValueHandling = NullValueHandling.Ignore}
        Desconstruido = JsonConvert.DeserializeObject(Of Contrato)(FormattedResposta, config)
        Entidade = Desconstruido.orgaoEntidade
        Unidade = Desconstruido.unidadeOrgao
        TContrato = Desconstruido.tipoContrato
        CatProcesso = Desconstruido.categoriaProcesso
    End Sub
    Sub WorkbookCreateDTable()
        Using workbook As New XLWorkbook("C:\Users\Inovea\Documents\Test Archives\TestBook.xlsx")
            Dim worksheet As IXLWorksheet = workbook.Worksheet(1)
            Dim datatable As New DataTable()
            Dim linha As DataRow = datatable.NewRow()
            datatable.Columns.Add("CNPJ", GetType(String))
            datatable.Columns.Add("Razao Social", GetType(String))
            datatable.Columns.Add("UF", GetType(String))
            datatable.Columns.Add("Município", GetType(String))
            datatable.Columns.Add("Tipo do contrato", GetType(String))
            datatable.Columns.Add("Categoria do processo", GetType(String))
            datatable.Columns.Add("Data inicial de vigencia", GetType(String))
            datatable.Columns.Add("Data final de vigencia", GetType(String))
            datatable.Columns.Add("Valor inicial", GetType(Double))
            datatable.Columns.Add("Numero de parcelas", GetType(Integer))
            datatable.Columns.Add("Valor global", GetType(Double))
            datatable.Columns.Add("Valor acumulado", GetType(Double))
            datatable.Columns.Add("Fonte", GetType(String))
            datatable.Columns.Add("Fornecedor", GetType(String))
            datatable.Rows.Add(Entidade.cnpj, Entidade.razaoSocial, Unidade.ufNome, Unidade.municipioNome, TContrato.nome, CatProcesso.nome, Desconstruido.dataVigenciaInicio, Desconstruido.dataVigenciaFim, Desconstruido.valorInicial, Desconstruido.numeroParcelas, Desconstruido.valorGlobal, Desconstruido.valorAcumulado, Desconstruido.usuarioNome, Desconstruido.nomeRazaoSocialFornecedor)
            worksheet.Cell("B2").InsertData(datatable)
            workbook.Save()
        End Using
    End Sub
    Function Primeiralinhavazia(worksheet As IXLWorksheet, columnNumber As Integer) As Integer
        For row As Integer = 1 To worksheet.LastRowUsed().RowNumber()
            If worksheet.Cell(row + 1, columnNumber).IsEmpty() Then
                Return row + 1
            End If
        Next
        Return -1
    End Function
    Sub WorkbookAppendDTable()
        Using workbook As New XLWorkbook("C:\Users\Inovea\Documents\Test Archives\TestBook.xlsx")
            Dim worksheet As IXLWorksheet = workbook.Worksheet(1)
            Dim cellrow As Int16 = Primeiralinhavazia(worksheet, 2)
            Dim datatable As New DataTable()
            Dim linha As DataRow = DataTable.NewRow()
            DataTable.Columns.Add("CNPJ", GetType(String))
            DataTable.Columns.Add("Razao Social", GetType(String))
            DataTable.Columns.Add("UF", GetType(String))
            DataTable.Columns.Add("Município", GetType(String))
            DataTable.Columns.Add("Tipo do contrato", GetType(String))
            DataTable.Columns.Add("Categoria do processo", GetType(String))
            DataTable.Columns.Add("Data inicial de vigencia", GetType(String))
            DataTable.Columns.Add("Data final de vigencia", GetType(String))
            DataTable.Columns.Add("Valor inicial", GetType(Double))
            DataTable.Columns.Add("Numero de parcelas", GetType(Integer))
            DataTable.Columns.Add("Valor global", GetType(Double))
            DataTable.Columns.Add("Valor acumulado", GetType(Double))
            DataTable.Columns.Add("Fonte", GetType(String))
            DataTable.Columns.Add("Fornecedor", GetType(String))
            DataTable.Rows.Add(Entidade.cnpj, Entidade.razaoSocial, Unidade.ufNome, Unidade.municipioNome, TContrato.nome, CatProcesso.nome, Desconstruido.dataVigenciaInicio, Desconstruido.dataVigenciaFim, Desconstruido.valorInicial, Desconstruido.numeroParcelas, Desconstruido.valorGlobal, Desconstruido.valorAcumulado, Desconstruido.usuarioNome, Desconstruido.nomeRazaoSocialFornecedor)
            worksheet.Cell("B" & cellrow).InsertData(datatable)
            workbook.Save()
        End Using

    End Sub
    Sub dbinsert()
        Dim connectionString As String = "Server=localhost;Database=teste;User Id=teste;Password=teste"
        Dim connectionsql As New SqlConnection(connectionString)
        Try
            connectionsql.Open()
            Console.WriteLine("Coneção com o banco realizada com sucesso")
            Console.ReadLine()
        Catch ex As Exception
            Console.WriteLine("Erro" & ex.Message)
            Console.ReadLine()
        End Try
        Dim table As String = ("Contrato")
        Dim column1value As String = Entidade.cnpj
        Dim column2value As String = Entidade.razaoSocial
        Dim column3value As String = Unidade.ufNome
        Dim column4value As String = Unidade.municipioNome
        Dim column5value As String = TContrato.nome
        Dim column6value As String = CatProcesso.nome
        Dim column7value As String = Desconstruido.dataVigenciaInicio
        Dim column8value As String = Desconstruido.dataVigenciaFim
        Dim column9value As String = Desconstruido.valorInicial
        Dim column10value As String = Desconstruido.numeroParcelas
        Dim column11value As String = Desconstruido.valorGlobal
        Dim column12value As String = Desconstruido.valorAcumulado
        Dim column13value As String = Desconstruido.usuarioNome
        Dim column14value As String = Desconstruido.nomeRazaoSocialFornecedor

        Dim insert As String = "INSERT INTO " & table & "(CNPJ, RSocial,UF, Municipio, TipoContrato, Catprocesso, DataIVigencia, DataFVigencia, ValorInicial, NParcelas, ValorGlobal, ValorAcu, Fonte, Fornecedor)
        VALUES (@VALUE1, @VALUE2, @VALUE3, @VALUE4, @VALUE5, @VALUE6, @VALUE7, @VALUE8, @VALUE9, @VALUE10, @VALUE11, @VALUE12, @VALUE13, @VALUE14)"

        Dim comando As New SqlCommand(insert, connectionsql)


        comando.Parameters.AddWithValue("@value1", column1value)
        comando.Parameters.AddWithValue("@value2", column2value)
        comando.Parameters.AddWithValue("@value3", column3value)
        comando.Parameters.AddWithValue("@value4", column4value)
        comando.Parameters.AddWithValue("@value5", column5value)
        comando.Parameters.AddWithValue("@value6", column6value)
        comando.Parameters.AddWithValue("@value7", column7value)
        comando.Parameters.AddWithValue("@value8", column8value)
        comando.Parameters.AddWithValue("@value9", column9value)
        comando.Parameters.AddWithValue("@value10", column10value)
        comando.Parameters.AddWithValue("@value11", column11value)
        comando.Parameters.AddWithValue("@value12", column12value)
        comando.Parameters.AddWithValue("@value13", column13value)
        comando.Parameters.AddWithValue("@value14", column14value)
        comando.ExecuteNonQuery()
        connectionsql.Close()

    End Sub
    Sub dbread()
        Console.WriteLine("Deseja fazer a procura por:" & vbLf & "1. CNPJ" & vbLf & "2. Municipio" & vbLf & "3. Deletar uma entrada" & vbLf & "4. Voltar ao menu anterior")
        Dim choice As Object = Console.ReadLine()
        Try
            choice = CInt(choice)
        Catch ex As Exception
            Console.WriteLine("Opção inválida, voltando ao menu.")
            dbread()
        End Try

        Select Case choice
            Case "1"
                dbreadcnpj()
            Case "2"
                dbreadmun()
            Case "3"
                dbdelete()
            Case "4"
                Main()
            Case Else
                Console.WriteLine("Opção inválida, voltando ao menu.")
                dbread()
        End Select

    End Sub
    Sub dbreadcnpj()
        Dim connectionString As String = "Server=localhost;Database=teste;User Id=teste;Password=teste"
        Dim connectionsql As New SqlConnection(connectionString)
        Console.WriteLine("Digite o numero do CNPJ")
        Dim cnpj As Int64 = Console.ReadLine()
        Try
            connectionsql.Open()
            Console.WriteLine("Coneção com o banco realizada com sucesso")
        Catch ex As Exception
            Console.WriteLine("Erro" & ex.Message)
            Console.ReadLine()
        End Try
        Dim table As String = "Contrato"
        Dim Command As New SqlCommand("SELECT* FROM " & table & " WHERE CNPJ = " & cnpj, connectionsql)
        Dim reader As SqlDataReader = Command.ExecuteReader()
        Console.WriteLine(reader.GetName(0) & "   ,   " & reader.GetName(3) & "   ,   " & reader.GetName(4) & "   ,   " & reader.GetName(5) & "   ,   " & reader.GetName(6))
        While reader.Read()
            Console.WriteLine(reader("IDContrato").ToString & "   ,   " & reader("UF").ToString() & "   ,   " & reader("Municipio").ToString() & "   ,   " & reader("TipoContrato").ToString() & "   ,   " & reader("CatProcesso").ToString())
        End While
        connectionsql.Close()
        Console.ReadLine()
        dbread()
    End Sub
    Sub dbreadmun()
        Dim connectionString As String = "Server=localhost;Database=teste;User Id=teste;Password=teste"
        Dim connectionsql As New SqlConnection(connectionString)
        Console.WriteLine("Digite o nome do municipio")
        Dim municipio As String = Console.ReadLine()
        Try
            connectionsql.Open()
            Console.WriteLine("Coneção com o banco realizada com sucesso")
        Catch ex As Exception
            Console.WriteLine("Erro" & ex.Message)
            Console.ReadLine()
        End Try
        Dim table As String = "Contrato"
        Dim Command As New SqlCommand("SELECT* FROM " & table & " WHERE Municipio = '" & municipio & "'", connectionsql)
        Dim reader As SqlDataReader = Command.ExecuteReader()
        Console.WriteLine(reader.GetName(0) & "   ,   " & reader.GetName(1) & "   ,   " & reader.GetName(3) & "   ,   " & reader.GetName(5) & "   ,   " & reader.GetName(6))
        While reader.Read()
            Console.WriteLine(reader("IDContrato").ToString() & "   ,   " & reader("CNPJ").ToString() & "   ,   " & reader("UF").ToString() & "   ,   " & reader("TipoContrato").ToString() & "   ,   " & reader("CatProcesso").ToString())
        End While
        connectionsql.Close()
        Console.ReadLine()
        dbread()

    End Sub
    Sub dbdelete()
        Dim connectionString As String = "Server=localhost;Database=teste;User Id=teste;Password=teste"
        Dim connectionsql As New SqlConnection(connectionString)
        Console.WriteLine("Digite o id da entrada para deletar")
        Dim id As String = Console.ReadLine()
        Try
            connectionsql.Open()
            Console.WriteLine("Coneção com o banco realizada com sucesso")
        Catch ex As Exception
            Console.WriteLine("Erro" & ex.Message)
            Console.ReadLine()
        End Try
        Dim table As String = "Contrato"
        Dim Command As New SqlCommand("DELETE FROM " & table & " WHERE IDContrato = '" & id & "'", connectionsql)
        Command.ExecuteNonQuery()
        connectionsql.Close()
        Console.WriteLine("Entrada deletada.")
        Console.ReadLine()
        dbread()
    End Sub
End Module