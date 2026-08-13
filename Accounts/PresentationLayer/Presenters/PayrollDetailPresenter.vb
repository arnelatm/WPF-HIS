Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PayrollDetailPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPayrollDetailView, TM)

        Protected DtPayElementInsertTable As New DataTable
        Protected DtPayElementUpdateTable As New DataTable
        'Private ReadOnly _payrollPayElementModel As New ModelAccounts("PayrollPayElement")

        Public Sub New(itemView As IPayrollDetailView)
            MyBase.New(itemView)
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            TableBaseName = "PayrollDetail"
            TableName = "PayrollDetail_View"
            SortOrderKey = "EmployeeName"

            Service = New AccountsService("PayrollDetail")

            CreateDataTable(DtPayElementInsertTable, {{"Amount", GetType(Decimal)},
                                            {"Generated", GetType(Boolean)},
                                            {"PayElementIdNo", GetType(Int16)},
                                            {"PayrollDetailIdNo", GetType(Int32)},
                                            {"RecurringPayElementIdNo", GetType(Int32)}
                                           })

            CreateDataTable(DtPayElementUpdateTable, {{"Amount", GetType(Decimal)},
                                            {"Generated", GetType(Boolean)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayElementIdNo", GetType(Int16)},
                                            {"PayrollDetailIdNo", GetType(Int32)},
                                            {"RecurringPayElementIdNo", GetType(Int32)}
                                           })

            If View.PayrollIdNo = 0 Then
                View.PayrollIdNo = Service.GetFieldOnMaxField("PayrollIdNo", "PayrollDetail", "PayrollIdNo")
            End If
            DataFilter = "PayrollIdNo = " & View.PayrollIdNo.ToString()

        End Sub

        
        Protected Overrides Sub CreateDataSources()
            'RaiseEvent UpdateDataFilterEvent(PayrollIdNo)
            MakeVarDataSources({New Object() {"PayElement", "PayEarningsByCode", Nothing, "PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) & "' and Summary = 0"},
                                New Object() {"PayElement", "PayDeductionsByCode", Nothing, "PayElementKind = '" & EnumToCode(PayElementKindSelection.Deduction) & "' and Summary = 0"}})
            MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing}})
        End Sub


        Public Sub DisplayPayrollDetails(ByRef startDate As Date?, ByRef endDate As Date?, ByRef payDescription As String)
            Dim payroll As Object = New ExpandoObject
            payroll = Service.GetFieldsWithIdNo(View.PayrollIdNo, "Payroll", "StartDate,EndDate,PayrollName,PayrollNameAra")
            startDate = CType(payroll.StartDate, Date)
            endDate = CType(payroll.EndDate, Date)
            If GlobalVariables.RightToLeftLayout Then
                payDescription = payroll.PayrollNameAra
            Else
                payDescription = payroll.PayrollName
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                Dim data As New List(Of PayrollPayElementView)
                data.AddRange(View.PayrollEarnings)
                data.AddRange(View.PayrollDeductions)
                CustomObjToDataTables(data, DtPayElementInsertTable, DtPayElementUpdateTable, AddressOf FillData, AddressOf PayrollPayElementFilter, "IdNo", "")
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("Amount") = itemDataView.Amount
            workRow("Generated") = itemDataView.Generated
            workRow("PayElementIdNo") = itemDataView.PayElementIdNo
            workRow("PayrollDetailIdNo") = View.IdNo
            workRow("RecurringPayElementIdNo") = itemDataView.RecurringPayElementIdNo
        End Sub

        Public Function PayrollPayElementFilter(ByVal obj As Object) As Boolean
            If (obj.Amount = 0 Or obj.PayElementIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            retVal = UpdateEmpPayElements(DtPayElementUpdateTable, DtPayElementInsertTable)
        End Sub

        Protected Function UpdateEmpPayElements(updateTable As DataTable, insertTable As DataTable) As Integer
            Dim retVal As Integer
            Dim payrollPayElementsDao = New PayrollPayElementDao
            retVal = payrollPayElementsDao.UpdInsEmpPayElementTvp(updateTable, insertTable, View.IdNo, View.EmployeeIdNo)
            Return retVal
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim reportName As String = "Payroll Report.Rpt"
            Dim reportTitle As String = Service.GetField(Of String, Int32)(View.PayrollIdNo, "Payroll", "IdNo", "PayrollName")
            Dim language As String
            Dim estName As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            estName = GlobalVariables.GetEstablishmentName(language)
            Dim cForm As New ReportForm(reportName, reportTitle, "ReportTitle", language, "Language", estName, "EstablishmentName", View.PayrollIdNo, "PayrollIdNo")
            cForm.Show()
        End Sub

    End Class

End Namespace
