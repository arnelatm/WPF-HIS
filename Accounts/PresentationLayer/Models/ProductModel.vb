Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ProductModel
        Public Property Errors As List(Of String)
        Public Property Active As Boolean
        Public Property BaseUnit As Int16
        Public Property CategoryIdNo As Int16
        Public Property DateCreated As DateTime?
        Public Property GlAccountIdNo As Int16?
        Public Property IdNo As Int32
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property ProductNameAra As String
    End Class

End Namespace