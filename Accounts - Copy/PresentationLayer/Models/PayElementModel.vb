Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayElementModel

        Public Property AccountIdNo As Int16
        Public Property Active As Boolean
        Public Property BasePaymentIdNo As Int16?
        Public Property CalculationType As Char
        Public Property DefaultQuantity As Decimal
        Public Property Errors As List(Of String)
        Public Property FactorType As String
        Public Property FactorValue As Decimal
        Public Property IdNo As Int16
        Public Property IncludeInEos As Boolean
        Public Property Notes As String
        Public Property PayElementCode As String
        Public Property ReportGroupIdNo As Int16
        Public Property PayElementKind As Char
        Public Property PayElementName As String
        Public Property PayElementNameAra As String
        Public Property PayElementType As Char
        Public Property QuantityType As Char
        Public Property Rate As Decimal
        Public Property Summary As Boolean
        Public Property Taxable As Boolean
        Public Property Unit As Char
        Public Property UsePayGroups As Boolean
        Public Property UsePayGroupSetting As Boolean
        Public Property PayElementAccounts As IList(Of PayElementAccountModel)
        Public Property PayElementItems As IList(Of PayElementItemModel)
    End Class

End Namespace