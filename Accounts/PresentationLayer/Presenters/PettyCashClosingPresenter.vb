Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
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
        Protected DtUpdateTable As New DataTable
        Private _journalItemModel
        Private _pcJournalsModel

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("PettyCashClosing")
            TableName = "PettyCashClosing"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashClosingModel()
            DataModel = New PettyCashClosingModel()
            Dim djArgs = {"CdJournalItem_View", "", "InsertCdJournalItemTVP"}
            _journalItemModel = New ModelAccounts("JournalItem", Nothing, djArgs)
            djArgs = {"CdJournalItem_View", "UpdatePcJournalsTVP", ""}
            _pcJournalsModel = New ModelAccounts("PcJournals", Nothing, djArgs)
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

            CreateDataTable(DtUpdateTable, {{"CdJournalIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"PcClosed", GetType(Boolean)}
                                            })
            QuitOnSave = True
            AskBeforeSave = True
        End Sub

        Public Sub GetOpenPettyCash()
            Dim modelData As List(Of PcJournalModel)
            modelData = ModelOfPresenter.GetOpenPettyCash()
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
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            Dim nRowCount As Int16 = 1
            Dim workRow As DataRow = Nothing
            CreateJournalItems()
            For Each dataView In View.JournalItems
                Dim idNo As Integer = dataView.IdNo
                workRow = DtInsertTable.NewRow()
                workRow("Sequence") = nRowCount
                workRow("AccountIdNo") = dataView.AccountIdNo
                workRow("Credit") = dataView.Credit
                workRow("Debit") = dataView.Debit
                workRow("JournalIdNo") = View.IdNo
                workRow("Notes") = dataView.Notes
                workRow("RevCostCenteridNo") = dataView.RevCostCenterIdNo
                DtInsertTable.Rows.Add(workRow)
                nRowCount += 1
            Next
            workRow = Nothing
            For Each dataView In View.PcJournals
                If dataView.PcClosed Then
                    Dim idNo As Integer = dataView.IdNo
                    workRow = DtUpdateTable.NewRow()
                    workRow("CdJournalIdNo") = View.IdNo
                    workRow("IdNo") = dataView.IdNo
                    workRow("PcClosed") = True
                    DtUpdateTable.Rows.Add(workRow)
                End If
            Next
            View.PcClosed = True
        End Sub

        Public Sub CreateJournalItems()
            View.JournalItems = New List(Of IJournalItemView)
            Dim x = New JournalItemView
            x.AccountIdNo = View.AccountIdNo
            x.Credit = View.Amount
            x.Debit = 0
            x.Notes = ""
            x.Sequence = 1
            x.JournalIdNo = 0
            View.JournalItems.Add(x)
            x = New JournalItemView
            x.AccountIdNo = View.PcAccountIdNo
            x.Credit = 0
            x.Debit = View.Amount
            x.Notes = ""
            x.Sequence = 2
            x.JournalIdNo = 0
            View.JournalItems.Add(x)
        End Sub

        'Private Sub MakeJournalItem()
        '    Dim aAccountIdNo As Int16() = {}
        '    Dim aAmount() As Decimal = {}
        '    Dim aAdded() As Boolean = {}
        '    View.JournalItems.Clear()
        '    Dim item As New JournalItemView With {
        '            .JournalIdNo = View.IdNo,
        '            .Sequence = 1,
        '            .AccountIdNo = View.AccountIdNo,
        '            .Credit = If(View.Amount < 0, 0, View.Amount),
        '            .Debit = If(View.Amount < 0, View.Amount * -1, 0),
        '            .RevCostCenterIdNo = 0,
        '            .Notes = ""
        '            }
        '    View.JournalItems.Add(item)
        '    item = New JournalItemView With {
        '            .JournalIdNo = View.IdNo,
        '            .Sequence = 1,
        '            .AccountIdNo = 113,
        '            .Credit = If(View.Amount < 0, View.Amount * -1, 0),
        '            .Debit = If(View.Amount < 0, 0, View.Amount),
        '            .RevCostCenterIdNo = 0,
        '            .Notes = ""
        '            }
        '    View.JournalItems.Add(item)
        'End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer
            passedValue = retVal
            For Each row As DataRow In DtInsertTable.Rows
                row.Item("JournalIdNo") = passedValue
            Next
            retVal = _journalItemModel.InsertTvp(DtInsertTable)
            If retVal >= 0 Then
                retVal = _pcJournalsModel.DelUpdateTvp(DtUpdateTable, passedValue)
            End If
            If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
                View.IdNo = passedValue
                retVal = UpdateGlReferenceNumber(passedValue)
            End If
        End Sub

        Public Function UpdateGlReferenceNumber(pcIdNo As Integer) As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            DataModel.IdNo = pcIdNo
            retValue = ModelOfPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public ReadOnly Property PcAccountCount As Int16
            Get
                Dim specialAccount As String
                specialAccount = EnumToCode(SpecialAccountSelection.PettyCashAccount)
                Return ModelOfPresenter.CountRecordWithKey(specialAccount, "Account", "SpecialAccount")
            End Get
        End Property

        Public ReadOnly Property DefaultPcAccount As Int16
            Get
                Dim retVal As String = Nothing
                If View.PcAccountIdNo Is Nothing Or View.PcAccountIdNo <= 0 Then
                    If PcAccountCount >= 1 Then
                        retVal = GetRecordFieldWithKey(EnumToCode(SpecialAccountSelection.PettyCashAccount), "Account", "SpecialAccount", "IdNo")
                    Else
                        Return 0
                    End If
                End If
                If retVal Is Nothing Then
                    Return 0
                End If
                Return CInt(retVal)
            End Get
        End Property

    End Class

End Namespace