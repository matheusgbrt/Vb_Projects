Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Module Module1
    Dim cnpj As String
    Dim ano As String
    Dim sequencial As String
    Dim FormattedResposta As String

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
            Public Property niFornecedor As String
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
            Public Property valorParcela As Double
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
        Menu()
        APICall(cnpj, ano, sequencial)
        Format(FormattedResposta)
        Console.ReadLine()
    End Sub
    Public Async Function APICall(ByVal cnpj, ByVal ano, ByVal sequencial) As Task
        Dim client As HttpClient = New HttpClient()
        client.BaseAddress = New Uri("https://treina.pncp.gov.br/api/pncp")
        Dim endpoint = String.Format("https://treina.pncp.gov.br/api/pncp/v1/orgaos/{0}/contratos/{1}/{2}", cnpj, ano, sequencial)
        Dim resposta As HttpResponseMessage = Await client.GetAsync(endpoint)
        Try
            resposta.EnsureSuccessStatusCode()
        Catch ex As Exception
            Console.WriteLine("Ocorreu um erro: " & ex.Message)
            Menu()
        End Try
        FormattedResposta = Await resposta.Content.ReadAsStringAsync()
        Dim desconstruido As Contrato = JsonConvert.DeserializeObject(Of Contrato)(FormattedResposta)
        Dim OrgaoEntidade As OrgaoEntidade = desconstruido.orgaoEntidade
        Dim UnidadeOrgao As UnidadeOrgao = desconstruido.unidadeOrgao
        Dim TipoContrato As TipoContrato = desconstruido.tipoContrato
        Dim CategoriaProcesso As CategoriaProcesso = desconstruido.categoriaProcesso
        Console.WriteLine("CNPJ: " & OrgaoEntidade.cnpj & "      Razão social: " & OrgaoEntidade.razaoSocial)
        Console.WriteLine("UF:  " & UnidadeOrgao.ufNome & "             Municipio: " & UnidadeOrgao.municipioNome & "-" & UnidadeOrgao.ufSigla)
        Console.WriteLine("Ano Contrato: " & desconstruido.anoContrato & "           Data de Atualização: " & desconstruido.dataAtualizacao)
        Console.WriteLine("Numero do processo:" & desconstruido.processo)
    End Function
    Sub Menu()
        Console.WriteLine("CHAMADA DE API" & vbLf & "Digite o CNPJ do contratante")
        cnpj = Console.ReadLine()
        Console.WriteLine("Digite o ano do contratato")
        ano = Console.ReadLine()
        Console.WriteLine("Digite o sequencial do contratato")
        sequencial = Console.ReadLine()
    End Sub

End Module