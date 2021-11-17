Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayElementPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IPayElementView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Private ReadOnly _payElementAccountService As New AccountsService("PayElementAccount")
        Private ReadOnly _payElementItemService As New AccountsService("PayElementItem")

        Public Sub New(view As IPayElementView)
            MyBase.New(view)
            If view IsNot Nothing Then
                Service = New AccountsService("PayElement")
                TableName = "PayElement"
                TreeViewMainField = "PayElementName"
                TreeViewSecondaryField = "PayElementCode"
                SortOrderKey = "PayElementName"
                'OriginalModel = New PayElementModel()
                'DataModel = New PayElementModel
            End If
            CreateDataTables()
            ChildServices.Add(_payElementItemService)
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of PayElementKindSelection)("PayElementKind")
            CreateEnumDataSource(Of CalculationTypeSelection)("CalculationType")
            CreateEnumDataSource(Of FactorTypeSelection)("FactorType")
            CreateEnumDataSource(Of PayRateUnitSelection)("Unit")
            CreateEnumDataSource(Of QuantityTypeSelection)("QuantityType")
            CreateEnumDataSource(Of PayElementTypeSelection)("PayElementType")
            CreateDataSource("PayElement", "BasePaymentIdNo")
            CreateDataSource("Account", "AccountIdNo", "AccountName", "DetailAccount=1")
            CreateEnumData(Of FactorTypeSelection)("FactorTypeByCode")
            CreateEnumData(Of CalculationTypeSelection)("CalculationTypeByCode")
            CreateLookupData("PayElementGroup", "EarnReportGroupsByCode", "PayElementKind = '" & GlobalFunctions.EnumToCode(PayElementKindSelection.Earning) & "'")
            CreateLookupData("PayElementGroup", "DedReportGroupsByCode", "PayElementKind = '" & GlobalFunctions.EnumToCode(PayElementKindSelection.Deduction) & "'")
            CreateLookupData("PayElement", "PayElementsByCode")
            CreateLookupData("PayGroup", "PayGroupsByCode")
            CreateLookupData("Account", "AccountsByCode", "DetailAccount=1")
        End Sub

        Private Sub CreateDataTables()

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnInsertTable.Columns.Add("FactorType", GetType(String))
            DtEarnInsertTable.Columns.Add("FactorValue", GetType(Decimal))
            DtEarnInsertTable.Columns.Add("ParentIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnUpdateTable.Columns.Add("FactorType", GetType(String))
            DtEarnUpdateTable.Columns.Add("FactorValue", GetType(Decimal))
            DtEarnUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtEarnUpdateTable.Columns.Add("ParentIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("PayElementIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("Sequence", GetType(Int16))
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
            workRow("FactorType") = itemDataView.FactorType
            workRow("FactorValue") = itemDataView.FactorValue
            workRow("ParentIdNo") = View.IdNo
            workRow("PayElementIdNo") = itemDataView.PayElementIdNo
        End Sub

        Public Function EarnSummaryFilter(ByVal obj As Object) As Boolean
            If (obj.PayElementIdNo Is Nothing Or obj.PayElementIdNo = 0 Or obj.FactorValue = 0 Or obj.FactorType Is Nothing) Then 'AndAlso (obj.PayGroupIdNo Is Nothing Or obj.PayGroupIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_payElementAccountService, DtUpdateTable, DtInsertTable, passedValue, "PayGroupIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_payElementItemService, DtEarnUpdateTable, DtEarnInsertTable, passedValue, "ParentIdNo")
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