Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Class ListView
    Inherits System.Web.UI.Page

Public ReadOnly Property Images() As List(Of Image)
    Get
        Dim data As List(Of Image) = TryCast(Session("DataImages"), List(Of Image))

        If data Is Nothing Then
            data = GetImages()
            Session("DataImages") = data
        End If

        Return data
    End Get
End Property

Public Function GetImages() As List(Of Image)

    Dim images As List(Of Image) = New List(Of Image)
    Dim image As Image = New Image()
    image.ID = 1
    image.Name = "Chrysanthemum"
    image.ImageUrl = "~/images/Chrysanthemum.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Chrysanthemum.jpg"
    image.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
    images.Add(image)
    image = New Image()
    image.ID = 2
    image.Name = "Desert"
    image.ImageUrl = "~/images/Desert.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Desert.jpg"
    image.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
    images.Add(image)
    image = New Image()
    image.ID = 3
    image.Name = "Hydrangeas"
    image.ImageUrl = "~/images/Hydrangeas.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Hydrangeas.jpg"
    image.Description = "The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English."
    images.Add(image)
    image = New Image()
    image.ID = 4
    image.Name = "Jellyfish"
    image.ImageUrl = "~/images/Jellyfish.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Jellyfish.jpg"
    image.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
    images.Add(image)
    image = New Image()
    image.ID = 5
    image.Name = "Koala"
    image.ImageUrl = "~/images/Koala.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Koala.jpg"
    image.Description = "The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English"
    images.Add(image)
    image = New Image()
    image.ID = 6
    image.Name = "Lighthouse"
    image.ImageUrl = "~/images/Lighthouse.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Lighthouse.jpg"
    image.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
    images.Add(image)
    image = New Image()
    image.ID = 7
    image.Name = "Penguins"
    image.ImageUrl = "~/images/Penguins.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Penguins.jpg"
    image.Description = "The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English"
    images.Add(image)
    image = New Image()
    image.ID = 8
    image.Name = "Tulips"
    image.ImageUrl = "~/images/Tulips.jpg"
    image.ThumbnailUrl = "~/images/Thumbnails/Tulips.jpg"
    image.Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
    images.Add(image)

    Return images
End Function

Public ReadOnly Property Articles() As List(Of Article)
    Get
        Dim data As List(Of Article) = TryCast(Session("DataArticles"), List(Of Article))

        If data Is Nothing Then
            data = GetArticles()
            Session("DataArticles") = data
        End If

        Return data
    End Get
End Property

Public Function GetArticles() As List(Of Article)
    Dim articles As List(Of Article) = New List(Of Article)
    Dim article As Article = New Article()
    article.ID = 1
    article.Title = "Phasellus auctor nisi dolor"
    article.Description = "Donec aliquam turpis sed nisl mattis sagittis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut vitae sapien metus. In hac habitasse platea dictumst. Aenean velit mauris, lobortis eu lacinia sed, imperdiet quis dui. Vestibulum ut metus sagittis dui lacinia mollis ornare eget urna. Mauris vehicula scelerisque sagittis"
    articles.Add(article)
    article = New Article()
    article.ID = 2
    article.Title = "In magna mi, dapibus ut tortor"
    article.Description = "Nullam facilisis neque ut aliquet imperdiet. Mauris ut odio augue. Curabitur in mi ac odio vestibulum lobortis. Donec sed mollis nibh, vitae varius lorem. Fusce ac neque lacinia dui facilisis posuere. Fusce pharetra rhoncus vulputate"
    articles.Add(article)
    article = New Article()
    article.ID = 3
    article.Title = "Aenean ut lacus enim"
    article.Description = "Aenean euismod est tortor, et pharetra mauris ultricies ut. Vivamus fringilla libero nec est tincidunt, sit amet venenatis felis accumsan. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae"
    articles.Add(article)
    article = New Article()
    article.ID = 4
    article.Title = "Aenean luctus bibendum"
    article.Description = "Mauris blandit sit amet diam eget dictum. Ut sit amet tortor sit amet nibh elementum scelerisque. Nullam felis turpis, suscipit ut nunc at, euismod condimentum massa. Ut finibus odio vitae euismod dapibus. Fusce luctus elit leo, at ultrices orci imperdiet quis"
    articles.Add(article)
    article = New Article()
    article.ID = 4
    article.Title = "Lorem ipsum dolor sit amet"
    article.Description = "Etiam nisi felis, ullamcorper et sagittis sed, posuere et lorem. Mauris non rutrum tortor. Suspendisse eu leo nec justo facilisis imperdiet sed vel felis. Nullam eros urna, efficitur in eros at, interdum iaculis massa"
    articles.Add(article)

    Return articles

End Function

Protected Sub RadListViewImages_NeedDataSource(sender As Object, e As Telerik.Web.UI.RadListViewNeedDataSourceEventArgs)
    RadListViewImages.DataSource = Images
End Sub

Protected Overrides Sub OnLoad(e As EventArgs)
    MyBase.OnLoad(e)

    RadLightBoxImageDetails.DataSource = Images
    RadLightBoxImageDetails.DataBind()
End Sub

Protected Sub RadListViewImages_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListViewItemEventArgs)
    Dim item As RadListViewDataItem = TryCast(e.Item, RadListViewDataItem)
    Dim description As String = TryCast(item.DataItem, Image).Description
    If description.Length > 100 Then
        description = description.Substring(0, 97) + "..."
    End If
    TryCast(item.FindControl("LabelShortDescription"), Literal).Text = description
End Sub
Protected Sub RadListViewArticles_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs)
    RadListViewArticles.DataSource = Articles
End Sub

End Class