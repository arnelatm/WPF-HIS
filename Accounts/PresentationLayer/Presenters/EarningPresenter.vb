Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AutoMapper

Namespace PresentationLayer.Presenters

    Public Class EarningPresenter
        Inherits AccountsPresenter(Of IEarningView, EarningModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Private ReadOnly _payrollEarnAccountModel As New ModelAccounts("PayrollEarnAccount")
        Private ReadOnly _earningSummaryModel As New ModelAccounts("EarningSummary")

        Public Sub New(view As IEarningView)
            MyBase.New(view)

            InitializerWithTv("Earning")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("EarningIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("EarningIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnInsertTable.Columns.Add("EarningSummaryIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("EarningIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("Multiplier", GetType(Decimal))
            DtEarnInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnUpdateTable.Columns.Add("EarningSummaryIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("EarningIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtEarnUpdateTable.Columns.Add("Multiplier", GetType(Decimal))
            DtEarnUpdateTable.Columns.Add("Sequence", GetType(Int16))

            ChildModels.Add(_earningSummaryModel)

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayrollEarnAccounts, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PayrollEarnAccountFilter)
                ViewToDataTables(View.EarningsSummary, DtEarnInsertTable, DtEarnUpdateTable, AddressOf FillEsData, AddressOf EarnSummaryFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("EarningIdNo") = View.IdNo
            workRow("PayGroupIdNo") = itemDataView.PayGroupIdNo
        End Sub

        Public Function PayrollEarnAccountFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) Then 'AndAlso (obj.PayGroupIdNo Is Nothing Or obj.PayGroupIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Private Sub FillEsData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("EarningSummaryIdNo") = View.IdNo
            workRow("EarningIdNo") = itemDataView.EarningIdNo
            workRow("Multiplier") = itemDataView.Multiplier
        End Sub

        Public Function EarnSummaryFilter(ByVal obj As Object) As Boolean
            If (obj.EarningIdNo Is Nothing Or obj.EarningIdNo = 0 Or obj.Multiplier = 0) Then 'AndAlso (obj.PayGroupIdNo Is Nothing Or obj.PayGroupIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_payrollEarnAccountModel, DtUpdateTable, DtInsertTable, passedValue, "PayGroupIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_earningSummaryModel, DtEarnUpdateTable, DtEarnInsertTable, passedValue, "EarningSummaryIdNo")
            End If
        End Sub

        'Public Overrides Sub UpdateViewDisplay(idNo As Int32)
        '    If idNo <> 0 Then
        '        Dim modelData As EarningModel
        '        RecordCount = GetRecordCount()
        '        'RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
        '        modelData = ModelPresenter.GetRecordById(Of EarningModel)(idNo)
        '        'RaiseEvent AfterRecordRetrieval(modelData)
        '        'If Ea IsNot Nothing Then
        '        '    Ea.PublishEvent(New BeforeAssignment(modelData))
        '        'End If
        '        Dim x As List(Of EmployeeEarningView)
        '        GlobalVariables.Mapper.Map(modelData.PayrollEarnAccounts, View.PayrollEarnAccounts)
        '        GlobalVariables.Mapper.Map(modelData, View)
        '        GlobalVariables.Mapper.Map(modelData, View)
        '        For Each child In ChildPresenters
        '            child.UpdateViewDisplay(idNo)
        '        Next
        '    End If
        'End Sub

        'Public Sub UpdateFirstLine()
        '    If EditMode Or AddMode Then
        '        If View.PayrollEarnAccounts.Count() = 0 Then
        '            View.PayrollEarnAccounts = New List(Of PayrollEarnAccountView) From {
        '                NewPayrollEarnAccount()
        '                }
        '        End If
        '        'For Each item In View.PayrollEarnAccounts
        '        '    item.JournalIdNo = View.IdNo
        '        '    item.Sequence = 1
        '        '    item.AccountIdNo = View.AccountIdNo
        '        '    Dim tranType As String = CodeToEnum(Of TransactionTypeSelection)(View.TransactionType)
        '        '    If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Credit Then
        '        '        If item.Credit = 0 Then
        '        '            item.Credit = View.Amount
        '        '            item.Debit = 0
        '        '        End If
        '        '    Else
        '        '        If item.Debit = 0 Then
        '        '            item.Credit = 0
        '        '            item.Debit = View.Amount
        '        '        End If
        '        '    End If
        '        '    item.RevCostCenterIdNo = 0
        '        '    Exit For
        '        'Next
        '    End If
        'End Sub

        'Private Function NewPayrollEarnAccount()
        '    Dim item As New PayrollEarnAccountView With {
        '            .EarningIdNo = View.IdNo,
        '            .AccountIdNo = 0,
        '            .PayGroupIdNo = 0,
        '            .Sequence = 0,
        '            }
        '    Return item
        'End Function

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If CodeToEnum(Of EarningTypeSelection)(View.EarningType) = EarningTypeSelection.Others Then

        '    End If
        'End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue As Boolean = True
        '    If MyBase.IsBizDataValid() Then
        '        If Not UsePayGroups() Then
        '            If View.AccountIdNo <= 0 Then
        '                Messaging.Show(True, "MsgPostingAccountMustNotBeBlank")
        '                retValue = False
        '            End If
        '        End If
        '        If retValue Then
        '            retValue = IsChildValid(Of EarningSummaryModel)(View.EarningsSummary)
        '        End If
        '    Else
        '        retValue = False
        '    End If
        '    Return retValue
        'End Function

        'Private Function GetChildErrors(retValue As Boolean) As Boolean
        '    Dim sModel As New List(Of EarningSummaryModel)
        '    Dim esModel As New ModelAccounts("EarningSummary")
        '    Dim dModel = GlobalVariables.Mapper.Map(View.EarningsSummary, sModel)
        '    For Each item In sModel
        '        If Not esModel.IsValid(item) Then
        '            retValue = False
        '        End If
        '    Next
        '    If Not retValue Then
        '        AddToParentError(esModel.GetBizObjectErrors)
        '    End If

        '    Return retValue
        'End Function
    End Class

End Namespace