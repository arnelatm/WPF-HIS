Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Public Sub New(accountName As String)
            DataService = New ServiceAccounts(accountName)
        End Sub

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IModelAccounts.UpdateGlReferenceNumber
            Dim updateResult As Integer
            updateResult = DataService.UpdateGlReferenceNumber(model)
            Return updateResult
        End Function

    End Class

    'Public MustInherit Class ModelOpenInvoice
    '    Inherits ModelAccounts
    '    Implements IModelOpenInvoice

    '    'Protected Property ServiceOpenInvoice

    '    Public Function AddInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelOpenInvoice.AddInvoicePayment
    '        Dim updateResult As Integer
    '        updateResult = DataService.AddInvoicePayment(idNo, amount, discountTaken)
    '        Return updateResult
    '    End Function

    '    Public Function RemoveInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelOpenInvoice.RemoveInvoicePayment
    '        Dim updateResult As Integer
    '        updateResult = DataService.RemoveInvoicePayment(idNo, amount, discountTaken)
    '        Return updateResult
    '    End Function

    'End Class

    'Public Class ModelApOpenInvoice
    '    Inherits ModelOpenInvoice

    '    Public Sub New()
    '        DataService = New ServiceApOpenInvoice()
    '    End Sub

    'End Class

    'Public Class ModelArOpenInvoice
    '    Inherits ModelOpenInvoice

    '    Public Sub New()
    '        DataService = New ServiceArOpenInvoice()
    '    End Sub

    'End Class

    'Public Class ModelDistributionScheme
    '    Inherits ModelOpenInvoice

    '    Public Sub New()
    '        DataService = New ServiceDistributionScheme()
    '    End Sub

    'End Class

    'Public Class ModelDistributionSchemeItem
    '    Inherits ModelOpenInvoice

    '    Public Sub New()
    '        DataService = New ServiceDistributionSchemeItem()
    '    End Sub

    'End Class

End Namespace