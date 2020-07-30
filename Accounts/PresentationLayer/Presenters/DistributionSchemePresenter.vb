Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemePresenter
        Inherits AccountsPresenter(Of IDistributionSchemeView, DistributionSchemeModel)

        Public ParentViewList As List(Of DistributionSchemeModel)
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable

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
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Percentage", GetType(Decimal))

            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("DistributionSchemeIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int32))
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
            For Each ji In View.DistributionSchemeitems
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

        Private Function SaveChildren(ByRef retVal As Integer) Handles MyBase.ParentRecordAddedSuccessfully, MyBase.ParentRecordUpdatedSuccessfully
            Dim insertReturnValue
            Dim updateReturnValue
            Dim headerIdNo As Int32
            If AddMode Then
                headerIdNo = retVal
                CallByName(View, IdFieldName, CallType.Set, retVal)
            Else
                headerIdNo = CallByName(View, IdFieldName, CallType.Get)
            End If
            updateReturnValue = ModelPresenter.DelUpdateTvp(DtUpdateTable, headerIdNo)
            If updateReturnValue >= 0 AndAlso DtInsertTable.Rows.Count > 0 Then
                For Each row As DataRow In DtInsertTable.Rows
                    row.Item("DistributionSchemeIdNo") = headerIdNo
                Next
                insertReturnValue = Model.InsertTvp(DtInsertTable)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

    End Class

End Namespace