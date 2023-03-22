Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ProductModel
        Public Property Active As Boolean
        Public Property Barcode As String
        Public Property BaseUnitIdNo As Int16
        Public Property CategoryIdNo As Int16
        Public Property DateCreated As DateTime?
        Public Property Errors As List(Of String)
        Public Property GlAccountIdNo As Int16?
        Public Property GTIN As String
        Public Property IdNo As Int32
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property ProductNameAra As String

    End Class

End Namespace