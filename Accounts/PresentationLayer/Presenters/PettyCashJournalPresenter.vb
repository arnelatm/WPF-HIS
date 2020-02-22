Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class PettyCashJournalPresenter
        Inherits AccountsPresenter(Of IPettyCashJournalView, PettyCashJournal, PettyCashJournalModel)

        Public ParentViewList As List(Of PettyCashJournalModel)
        Private _apOpenInvoiceBo As New ApOpenInvoice
        Private ReadOnly _apOpenInvoiceModel As New ModelApOpenInvoice

        Public Sub New(view As IPettyCashJournalView)
            MyBase.New(view)
            CurrentModel = New ModelPettyCashJournal()
            TableName = "PettyCashJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashJournalModel()
            BizObject = New PettyCashJournal
            DataModel = New PettyCashJournalModel
            _apOpenInvoiceModel = New ModelApOpenInvoice
        End Sub

        Public Property JournalItemsPresenter As PettyCashJournalItemsPresenter
        Public Property PcsOiItemsPresenter As PcsOiItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim PettyCashJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    PettyCashJournalChangesMade = True
                ElseIf PcsOiItemsPresenter.ChangesMadeInPcsOiItem Then
                    PettyCashJournalChangesMade = True
                Else
                    PettyCashJournalChangesMade = False
                End If
            Else
                PettyCashJournalChangesMade = True
            End If
            Return PettyCashJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            DataModel = GlobalVariables.Mapper.Map(Of PettyCashJournalModel)(BizObject)
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
            retVal = Model.GetRecordFieldWithKey(idNo, "PettyCashJournal", "IdNo", "PaymentType")
            Return retVal
        End Function

        Public Function GetAdvancePaymentOpenIdNo(ByRef idNo As Integer) As Integer
            Dim retVal As String
            retVal = Model.GetRecordFieldWith2Key(idNo, "PC", "ApOpenInvoice", "JournalIdNo", "JournalCode", "IdNo")
            Return retVal
        End Function

        Public Function GetSupplierOpenInvoices(ByRef supplierIdNo As Integer) As String
            Dim retVal As String
            retVal = Model.GetSupplierOpenInvoices(supplierIdNo)
            Return retVal
        End Function

    End Class
End NameSpace