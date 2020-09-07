Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ProductCategoryModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property ProductCategoryCode As String
        Public Property ProductCategoryName As String
        Public Property ProductCategoryNameAra As String
        Public Property Notes As String
    End Class

End Namespace