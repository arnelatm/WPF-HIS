Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EarningModel

        Public Property AccountIdNo As Int16
        Public Property BasePaymentIdNo As Int16
        Public Property CalculationType As Char
        Public Property DefaultQuantity As Decimal
        Public Property EarningCode As String
        Public Property Summary As Boolean
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property EarningType As Char
        Public Property IdNo As Int16
        Public Property IncludeInEos As Boolean
        Public Property FactorValue As Decimal
        Public Property FactorType as String
        Public Property Notes As String
        Public Property Rate As Decimal
        Public Property Taxable As Boolean
        Public Property Unit As Char
        Public Property UnitAttendance As Char
        Public Property UsePayGroups As Boolean
        Property Errors As List(Of String)
        Public Property PayrollEarnAccounts As IList(Of PayrollEarnAccountModel)
        Public Property EarningsSummary As IList(Of EarningSummaryModel)
    End Class

End Namespace