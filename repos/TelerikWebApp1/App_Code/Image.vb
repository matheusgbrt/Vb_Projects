Public Class Image
    Public Property ID() As Integer
        Get
            Return m_ID
        End Get
        Set(value As Integer)
            m_ID = Value
        End Set
    End Property
    Private m_ID As Integer
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(value As String)
            m_Description = Value
        End Set
    End Property
    Private m_Description As String
    Public Property ImageUrl() As String
        Get
            Return m_ImageUrl
        End Get
        Set(value As String)
            m_ImageUrl = Value
        End Set
    End Property
    Private m_ImageUrl As String
    Public Property ThumbnailUrl() As String
        Get
            Return m_ThumbnailUrl
        End Get
        Set(value As String)
            m_ThumbnailUrl = Value
        End Set
    End Property
    Private m_ThumbnailUrl As String
End Class
