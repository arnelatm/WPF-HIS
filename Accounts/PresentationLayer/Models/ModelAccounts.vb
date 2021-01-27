Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelAccounts
        Inherits ModelCommon
        Implements IModelAccounts

        Public Sub New()

        End Sub

        Public Sub New(objectName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            DataService = New ServiceAccounts(objectName, bizParam, daoParam)
        End Sub

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IModelAccounts.UpdateGlReferenceNumber
            Dim updateResult As Integer
            updateResult = DataService.UpdateGlReferenceNumber(model)
            Return updateResult
        End Function

        Public Function UpdateOpeningBalance(Of TM)(ByRef model As TM) As Integer Implements IModelAccounts.UpdateOpeningBalance
            Dim updateResult As Integer
            updateResult = DataService.UpdateOpeningBalance(model)
            Return updateResult
        End Function

        'Public Function AddInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelAccounts.AddInvoicePayment
        '    Dim updateResult As Integer
        '    updateResult = DataService.AddInvoicePayment(idNo, amount, discountTaken)
        '    Return updateResult
        'End Function

        'Public Function RemoveInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Integer Implements IModelAccounts.RemoveInvoicePayment
        '    Dim updateResult As Integer
        '    updateResult = DataService.RemoveInvoicePayment(idNo, amount, discountTaken)
        '    Return updateResult
        'End Function

        'Public Function AddApOpenInvoice(journalItemModel As JournalItemModel, journalCode As String) As Integer Implements IModelAccounts.AddApOpenInvoice
        '    Throw New NotImplementedException()
        'End Function

        Public Function GetCustomerOpenInvoices(Of TM)(idNo As Int32) As List(Of TM) Implements IModelAccounts.GetCustomerOpenInvoices
            Return DataService.GetOpenInvoices(Of TM)(idNo)
        End Function

        Public Function GetSupplierOpenInvoices(Of TM)(idNo As Int32) As List(Of TM) Implements IModelAccounts.GetSupplierOpenInvoices
            Return DataService.GetOpenInvoices(Of TM)(idNo)
        End Function

        Public Function GetAcctReconItems(Of TM)(AccountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
            As List(Of TM) Implements IModelAccounts.GetAcctReconItems
            Return DataService.GetAcctReconItems(Of TM)(AccountIdNo, reconciliationDate, sortExpression)
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IModelAccounts.GenerateCode
            Return DataService.GenerateCode(idNo)
        End Function

        Public Function UpdateVatNumber(vatNumber As String, idNo As Integer) As Integer Implements IModelAccounts.UpdateVatNumber
            Return DataService.UpdateVatNumber(vatNumber, idNo)
        End Function

    End Class

End Namespace