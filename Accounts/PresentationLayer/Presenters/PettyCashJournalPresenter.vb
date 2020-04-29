Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PettyCashJournalPresenter
        Inherits AccountsPresenter(Of IPettyCashJournalView, PettyCashJournalModel)

        Public ParentViewList As List(Of PettyCashJournalModel)
        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Public Sub New(view As IPettyCashJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PettyCashJournal")
            TableName = "PettyCashJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashJournalModel()
            DataModel = New PettyCashJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property JournalItemsPresenter As PettyCashJournalItemsPresenter
        Public Property PcsOiItemsPresenter As PcsOiItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim pettyCashJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    pettyCashJournalChangesMade = True
                ElseIf PcsOiItemsPresenter.ChangesMadeInPcsOiItem Then
                    pettyCashJournalChangesMade = True
                Else
                    pettyCashJournalChangesMade = False
                End If
            Else
                pettyCashJournalChangesMade = True
            End If
            Return pettyCashJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer
            Return _apOpenInvoiceModel.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function GetPaymentType(ByRef idNo As Int32) As String
            Dim retVal As String
            retVal = Model.GetRecordFieldWithKey(idNo, "PettyCashJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Int32) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "PC", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Int32) As List(Of PcsOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of PcsOiItemModel)(supplierIdNo)
        End Function

    End Class

End Namespace