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
            updateResult = GetAccountsService().UpdateGlReferenceNumber(model)
            Return updateResult
        End Function

        Public Overrides Function GetCommonService() Implements IModelCommon.GetCommonService
            Return GetAccountsService()
        End Function

        Public Overridable Function GetAccountsService()
            Return Service
        End Function

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
            DataBizObject = New ApJournal
        End Sub

        Public Overrides Function GetAccountsService()
            Return New ServiceApJournal()
        End Function

    End Class

    Public Class ModelArJournal
        Inherits ModelAccounts

        Public Sub New()
            DataBizObject = New ArJournal
        End Sub

        Public Overrides Function GetAccountsService()
            Return New ServiceArJournal()
        End Function

    End Class

    Public Class ModelJournalItems
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceJournalItem()
        End Function

    End Class

    Public Class ModelApJournalItems
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceApJournalItems()
        End Function

    End Class

    Public Class ModelArJournalItems
        Inherits ModelAccounts

        Public Sub New()
            DataBizObject = New ArOpenInvoice
        End Sub

        Public Overrides Function GetAccountsService()
            Return New ServiceArJournalItems()
        End Function

    End Class

    Public Class ModelGeneralJournal
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceGeneralJournal()
        End Function

    End Class

    Public Class ModelGeneralJournalItem
        Inherits ModelAccounts

        Public Overrides Function GetAccountsService()
            Return New ServiceGeneralJournalItem()
        End Function

    End Class

    Public MustInherit Class ModelOpenInvoice
        Inherits ModelAccounts
        Implements IModelOpenInvoice

        Protected Property ServiceOpenInvoice

        Public Overrides Function GetAccountsService()
            Return ServiceOpenInvoice
        End Function

        Public Function AddInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelOpenInvoice.AddInvoicePayment
            Dim updateResult As Integer
            updateResult = ServiceOpenInvoice.AddInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

        Public Function RemoveInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelOpenInvoice.RemoveInvoicePayment
            Dim updateResult As Integer
            updateResult = ServiceOpenInvoice.RemoveInvoicePayment(idNo, amount, discountTaken)
            Return updateResult
        End Function

    End Class

    Public Class ModelApOpenInvoice
        Inherits ModelOpenInvoice

        Public Sub New()
            DataBizObject = New ApOpenInvoice()
            ServiceOpenInvoice = New ServiceApOpenInvoice()
        End Sub

    End Class

    Public Class ModelArOpenInvoice
        Inherits ModelOpenInvoice

        Public Sub New()
            DataBizObject = New ArOpenInvoice()
            ServiceOpenInvoice = New ServiceArOpenInvoice()
        End Sub

    End Class

End Namespace