Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemePresenter(Of TM As New)
        Inherits CommonPresenter(Of IDistributionSchemeView, TM)

        Public ParentViewList As List(Of TM)
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _distributionSchemeItemService As New AccountsService("DistributionSchemeItem")

        Public Sub New(view As IDistributionSchemeView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("DistributionScheme")
            TableName = "DistributionScheme"
            SortOrderKey = "DistributionSchemeName"

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

        Protected Overrides Sub CreateDataSources()
            MakeVarDataSources({New Object() {"RevCostCenter", "RevCostCentersByCode"}})
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
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
            End If
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Int32 = retVal
            retVal = UpdateChildData(_distributionSchemeItemService, DtUpdateTable, DtInsertTable, passedValue, "DistributionSchemeIdNo")
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = True
            Dim totalPercentage As Decimal = 0D
            If MyBase.IsBizDataValid() Then
                If View.DistributionSchemeItems Is Nothing OrElse View.DistributionSchemeItems.Count = 0 Then
                    Messaging.Show(True, "MsgBlankDistributionScheme")
                    retValue = False
                Else
                    For Each item In View.DistributionSchemeItems
                        totalPercentage += item.Percentage
                        If item.RevCostCenterIdNo = 0 Then
                            Dim lineNumber = Format(item.Sequence, "0")
                            Messaging.ShowPmMessage(True, "MsgBlankRevenueCostCenter", {"lineNumber", lineNumber})
                            retValue = False
                            Exit For
                        End If
                    Next
                    If retValue And Math.Abs(totalPercentage - 100.0) > 0.001 Then
                        Messaging.Show(True, "MsgInvalidTotalPercentage")
                        retValue = False
                    End If
                End If
            End If
            Return retValue
        End Function

    End Class

End Namespace