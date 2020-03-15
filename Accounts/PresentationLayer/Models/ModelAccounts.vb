Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public MustInherit Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Private Shared ReadOnly Service = New ServiceAccounts

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IModelAccounts.UpdateGlReferenceNumber
            Dim updateResult As Integer
            updateResult = DataService.UpdateGlReferenceNumber(model)
            Return updateResult
        End Function

        'Public Overrides Function GetCommonService() Implements IModelCommon.GetCommonService
        '    Return GetAccountsService()
        'End Function

        'Public Overridable Function GetAccountsService()
        '    Return Service
        'End Function

    End Class

    Public Class ModelCategory
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceCategory()
        End Sub

    End Class

    Public Class ModelEmployee
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceEmployee()
        End Sub

    End Class

    Public Class ModelApJournal
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceApJournal
        End Sub

    End Class

    Public Class ModelArJournal
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceArJournal
        End Sub

    End Class

    Public Class ModelJournalItems
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceJournalItem
        End Sub

    End Class

    Public Class ModelApJournalItems
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceApJournalItems
        End Sub

    End Class

    Public Class ModelArJournalItems
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceArJournalItems
        End Sub

    End Class

    Public Class ModelGeneralJournal
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceGeneralJournal
        End Sub

    End Class

    Public Class ModelGeneralJournalItem
        Inherits ModelAccounts

        Public Sub New()
            DataService = New ServiceGeneralJournalItems
        End Sub

    End Class

    Public MustInherit Class ModelOpenInvoice
        Inherits ModelAccounts
        Implements IModelOpenInvoice

        'Protected Property ServiceOpenInvoice

        Public Function AddInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelOpenInvoice.AddInvoicePayment
            Dim updateResult As Integer
            updateResult = DataService.AddInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

        Public Function RemoveInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelOpenInvoice.RemoveInvoicePayment
            Dim updateResult As Integer
            updateResult = DataService.RemoveInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

    End Class

    Public Class ModelApOpenInvoice
        Inherits ModelOpenInvoice

        Public Sub New()
            DataService = New ServiceApOpenInvoice()
        End Sub

    End Class

    Public Class ModelArOpenInvoice
        Inherits ModelOpenInvoice

        Public Sub New()
            DataService = New ServiceArOpenInvoice()
        End Sub

    End Class

End Namespace