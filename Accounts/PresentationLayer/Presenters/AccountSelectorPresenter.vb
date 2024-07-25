Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Public Class AccountSelectorPresenter(Of TM As New)
    Inherits CommonPresenterNew(Of IApArEmReportView, TM)

    Public Sub New(view As IApArEmReportView, tableName As String)
        MyBase.New(view)
        Service = New AccountsService(tableName)
        view.IdNoData = MakeDataTable({tableName})
    End Sub

    Public Sub New()
    End Sub


End Class


