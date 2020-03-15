Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters


    Public Class SalesJournalPresenter
        Inherits AccountsPresenter(Of ISalesJournalView, SalesJournal, SalesJournalModel)

        Public ParentViewList As List(Of SalesJournalModel)
        Private _apOpenInvoiceBo As New ApOpenInvoice
        Private ReadOnly _apOpenInvoiceModel As New ModelApOpenInvoice

        Public Sub New(view As ISalesJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelSalesJournal()
            TableName = "SalesJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New SalesJournalModel()
            BizObject = New SalesJournal
            DataModel = New SalesJournalModel
            _apOpenInvoiceModel = New ModelApOpenInvoice
        End Sub

        Public Property JournalItemsPresenter As SalesJournalItemsPresenter
        Public Property SalesCashItemsPresenter As SalesCashItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim salesJournalChangesMade As Boolean
            If GlobalFunctions.ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    salesJournalChangesMade = True
                ElseIf SalesCashItemsPresenter.ChangesMadeInSalesCashItem Then
                    salesJournalChangesMade = True
                Else
                    salesJournalChangesMade = False
                End If
            Else
                salesJournalChangesMade = True
            End If
            Return salesJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            DataModel = GlobalVariables.Mapper.Map(Of SalesJournalModel)(BizObject)
            retValue = Model.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function GetPaymentType(ByRef idNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "SalesJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Integer) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "CK", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetSupplierOpenInvoices(supplierIdNo)
            Return retVal
        End Function

    End Class
End NameSpace