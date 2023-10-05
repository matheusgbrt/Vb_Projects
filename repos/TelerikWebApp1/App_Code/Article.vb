Public Class Article
    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set(value As Integer)
            m_ID = Value
        End Set
    End Property
    Private m_ID As Integer
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set(value As String)
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = Value
        End Set
    End Property
    Private m_Description As String
End Class