Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayElementPresenter
        Inherits AccountsPresenter(Of IPayElementView, PayElementModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Private ReadOnly _PayElementAccountModel As New ModelAccounts("PayElementAccount")
        Private ReadOnly _payElementItemModel As New ModelAccounts("PayElementItem")

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(view As IPayElementView)
            MyBase.New(view)

            InitializerWithTv("PayElement")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnInsertTable.Columns.Add("PayElementItemIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("FactorType", GetType(String))
            DtEarnInsertTable.Columns.Add("FactorValue", GetType(Decimal))
            DtEarnInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnUpdateTable.Columns.Add("PayElementItemIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtEarnUpdateTable.Columns.Add("FactorType", GetType(String))
            DtEarnUpdateTable.Columns.Add("FactorValue", GetType(Decimal))
            DtEarnUpdateTable.Columns.Add("Sequence", GetType(Int16))

            ChildModels.Add(_payElementItemModel)

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayElementAccounts, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PayElementAccountFilter)
                ViewToDataTables(View.PayElementItems, DtEarnInsertTable, DtEarnUpdateTable, AddressOf FillEsData, AddressOf EarnSummaryFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("PayElementIdNo") = View.IdNo
            workRow("PayGroupIdNo") = itemDataView.PayGroupIdNo
        End Sub

        Public Function PayElementAccountFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) Then 'AndAlso (obj.PayGroupIdNo Is Nothing Or obj.PayGroupIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Private Sub FillEsData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("PayElementItemIdNo") = View.IdNo
            workRow("PayElementIdNo") = itemDataView.PayElementIdNo
            workRow("FactorType") = itemDataView.FactorType
            workRow("FactorValue") = itemDataView.FactorValue
        End Sub

        Public Function EarnSummaryFilter(ByVal obj As Object) As Boolean
            If (obj.PayElementIdNo Is Nothing Or obj.PayElementIdNo = 0 Or obj.FactorValue = 0 Or obj.FactorType Is Nothing) Then 'AndAlso (obj.PayGroupIdNo Is Nothing Or obj.PayGroupIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_PayElementAccountModel, DtUpdateTable, DtInsertTable, passedValue, "PayGroupIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_payElementItemModel, DtEarnUpdateTable, DtEarnInsertTable, passedValue, "PayElementItemIdNo")
            End If
        End Sub

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retValue = False
            If MyBase.IsOkToDeleteRecord() Then
                'If View.PayElementType = EnumToCode(PayElementTypeSelection.Computed) Or
                '   View.PayElementType = EnumToCode(PayElementTypeSelection.OvertimeHoliday) Or
                '   View.PayElementType = EnumToCode(PayElementTypeSelection.OvertimeSpecial) Then
                If View.IdNo <= 3 Then
                    Messaging.Show(True, "MsgSysPayElementDelNotAllowed")
                Else
                    retValue = True
                End If
            End If
            Return retValue
        End Function

        'Public Overrides Sub UpdateViewDisplay(idNo As Int32)
        '    MyBase.UpdateViewDisplay(idNo)
        '    UpdateCalculationTabDisplay()
        '    UpdatePostingTabDisplay()
        'End Sub

    End Class

End Namespace