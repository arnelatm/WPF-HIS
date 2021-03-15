Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DeductionModel

        Public Property AccountIdNo As Int16
        Public Property BasePaymentIdNo As Int16
        Public Property CalculationType As Char
        Public Property DefaultQuantity As Decimal
        Public Property DeductionCode As String
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property DeductionType As Char
        Public Property IdNo As Int16
        Public Property FactorValue As String
        Public Property FactorType As Char
        Public Property Notes As String
        Public Property Rate As Decimal
        Public Property Unit As Char
        Public Property UsePayGroups As Boolean
        Property Errors As List(Of String)
        Public Property PayrollDeductAccounts As IList(Of PayrollDeductAccountModel)

    End Class

End Namespace