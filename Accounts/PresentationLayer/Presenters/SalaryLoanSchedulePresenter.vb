Imports AATM.Accounts.Interfaces
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SalaryLoanSchedulePresenter
        Inherits PresenterNew(Of ISalaryLoanScheduleView, SalaryLoanScheduleModel)
        Implements ISalaryLoanSchedulePresenter

        Public Sub New(view As IViewNew)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("SalaryLoanSchedule")
            TableName = "SalaryLoanSchedule"
            SortOrderKey = "IdNo"
            OriginalModel = New SalaryLoanScheduleModel()
            DataModel = New SalaryLoanScheduleModel()
            TreeViewList = New List(Of SalaryLoanScheduleModel)
            QuitOnSave = False
        End Sub

        Public Function GetBranchList(Optional ByVal sortKey As String = "") As List(Of SalaryLoanScheduleModel)
            Dim xModel As New SalaryLoanScheduleModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of SalaryLoanScheduleModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of SalaryLoanScheduleModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New SalaryLoanScheduleModel
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace