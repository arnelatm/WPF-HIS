Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PayCyclePresenter(Of TM As New)
        Inherits CommonPresenter(Of IPayCycleView, TM)

        Public Sub New(view As IPayCycleView)
            MyBase.New(view)
            Service = New AccountsService("PayCycle")
            TableName = "PayCycle"
            TreeViewMainField = "PayCycleName"
            'TreeViewSecondaryField = "PayCycleCode"
            SortOrderKey = "PayCycleName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of PayFrequencySelection)("PayFrequency")
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "PayCycleIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PayPeriod", "PayCycleIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Payroll", "PayCycleIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class



End Namespace