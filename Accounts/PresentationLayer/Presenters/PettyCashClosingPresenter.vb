Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PettyCashClosingPresenter
        Inherits AccountsPresenter(Of IPettyCashClosingView, PettyCashClosingModel)

        Private _jiFooter As DgvFooter
        Protected DtInsertTable As New DataTable

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PettyCashClosing")
            TableName = "PettyCashClosing"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashClosingModel()
            DataModel = New PettyCashClosingModel()
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)


            CreateDataTable(DtInsertTable, {{"AccountIdNo", GetType(Int16)},
                                            {"Credit", GetType(Decimal)},
                                            {"Debit", GetType(Decimal)},
                                            {"JournalIdNo", GetType(Int32)},
                                            {"Notes", GetType(String)},
                                            {"RevCostCenterIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                            })
        End Sub

        Public Sub GetOpenPettyCash()
            Dim modelData As List(Of PcJournalModel)
            modelData = ModelPresenter.GetOpenPettyCash()
            View.PcJournals = New List(Of IPcJournalView)
            GlobalVariables.Mapper.Map(modelData, View.PcJournals)
        End Sub

        'Public Overrides Sub SaveOriginalValues()
        '    'GlobalVariables.Mapper.Map(Of T, TM)(Me.View, Me.OriginalModel)
        'End Sub

        Public Sub SelectChoice(ByVal SelectAll As Boolean)
            Dim total As Decimal = 0
            For Each item In View.PcJournals
                item.PcClosed = SelectAll
                If SelectAll Then
                    total += item.Amount
                End If
            Next item
            View.Amount = total
            View.Applied = total
        End Sub

        Public Function TotalSelection()
            Dim total As Decimal = 0D
            For Each item In View.PcJournals
                If item.PcClosed Then
                    total += item.Amount
                End If
            Next item
            Return total
        End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            'ViewToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf JournalItemFillData, AddressOf JournalItemFilter)

            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            Dim nRowCount As Int16 = 1
            Dim workRow As DataRow = Nothing
            'For Each dataView In dataViews
            '    If includeFilter.Invoke(dataView) Then
            '        Dim idNo As Integer = CallByName(dataView, dataViewIdNoFieldName, CallType.Get)
            '        If idNo <= 0 Then
            '            workRow = insertTable.NewRow()
            '        Else
            '            workRow = updateTable.NewRow()
            '            workRow(dataViewIdNoFieldName) = idNo
            '        End If
            '        workRow(sequenceFieldName) = nRowCount
            '        fillSub.Invoke(dataView, workRow)
            '        If idNo <= 0 Then
            '            insertTable.Rows.Add(workRow)
            '        Else
            '            updateTable.Rows.Add(workRow)
            '        End If
            '        nRowCount += 1
            '    End If
            'Next

        End Sub



    End Class

End Namespace