Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemePresenter
        Inherits AccountsPresenter(Of IDistributionSchemeView, DistributionSchemeModel)

        Public ParentViewList As List(Of DistributionSchemeModel)
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _distributionSchemeItemModel As New ModelAccounts("DistributionSchemeItem")

        Public Sub New(view As IDistributionSchemeView)
            MyBase.New(view)
            TableName = "DistributionScheme"
            SortOrderKey = "DistributionSchemeName"
            ModelPresenter = New ModelAccounts("DistributionScheme")
            OriginalModel = New DistributionSchemeModel()
            DataModel = New DistributionSchemeModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("DistributionSchemeIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Percentage", GetType(Decimal))

            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("DistributionSchemeIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Percentage", GetType(Decimal))

        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount = 1
            For Each ji In View.DistributionSchemeItems
                Dim workRow As DataRow
                If ji.IdNo <= 0 Then
                    workRow = DtInsertTable.NewRow()
                Else
                    workRow = DtUpdateTable.NewRow()
                    workRow("IdNo") = ji.IdNo
                End If
                workRow("DistributionSchemeIdNo") = View.IdNo
                workRow("Sequence") = nRowCount
                workRow("Percentage") = ji.Percentage
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            Next
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Int32 = retVal
            retVal = UpdateChildData(_distributionSchemeItemModel, DtUpdateTable, DtInsertTable, passedValue, "DistributionSchemeIdNo")
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.IsBizDataValid() Then
                If Not (View.DistributionSchemeItems Is Nothing OrElse View.DistributionSchemeItems.Count = 0) Then
                    retValue = True
                End If
            End If
            Return retValue
        End Function

    End Class

End Namespace