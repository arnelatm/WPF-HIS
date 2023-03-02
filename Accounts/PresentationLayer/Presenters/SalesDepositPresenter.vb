Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SalesDepositPresenter
        Inherits AccountsPresenter(Of ISalesDepositsView, SalesDepositModel)

        Public ParentViewList As List(Of SalesDepositModel)
        Private ReadOnly _vatRate As Decimal
        Private ReadOnly _slJournalItemService As New AccountsService("JournalItem", Nothing, {"ArJournalItem_View", "dbo.UpdateSlJournalItemTVP", "dbo.InsertSlJournalItemTVP"})


        Public Sub New(view As ISalesDepositsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("SalesDeposit")
            TableName = "SalesDeposit"
            SortOrderKey = "Sequence"
            DataModel = New SalesDepositModel
            '_cashCodesModel = GetCashCodesModel()
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _vatRate = GetAppSetting("VATR","VAT","VAT Percentage Rate")/100D
        End Sub
        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            ' ReSharper disable once VBUseMethodAny.1
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _slJournalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub
        Public Overrides Function IsOkToEditRecord() As Boolean
            Dim result As Boolean = True
            If ReconciledEntriesExist(View.JournalItems, "SJ") Then
                result = False
            Else
                If DependentRecordExist() Then
                    result = False
                End If
            End If
            Return result
        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsOkToDeleteRecord Then
                If ReconciledEntriesExist(View.JournalItems, "SJ") Then
                    retValue = False
                End If
            End If
            Return retValue
        End Function
    End Class

End Namespace