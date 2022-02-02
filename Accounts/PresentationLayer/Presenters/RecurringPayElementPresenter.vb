Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class RecurringPayElementPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IRecurringPayElementView, TM)

        Public Sub New(itemView As IRecurringPayElementView)
            MyBase.New(itemView)
            Service = New AccountsService("RecurringPayElement")
            TableName = "RecurringPayElement"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of RecurrTypeSelection)("RecurrType")
            CreateDataSource("Employee", "EmployeeIdNo")
            CreateDataSource("PayElement", "PayElementIdNo")
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "PayrollPayElement", "RecurringPayElementIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace