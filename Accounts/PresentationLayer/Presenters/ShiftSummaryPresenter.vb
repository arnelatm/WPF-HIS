Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ShiftSummaryPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IShiftSummaryView, TM)

        Public Sub New(itemView As IShiftSummaryView)
            MyBase.New(itemView)
            Service = New AccountsService("ShiftSummary")
            TableName = "ShiftSummary"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim time = Today
            View.DateStart = time
            View.DateEnd = time
        End Sub

    End Class

End Namespace