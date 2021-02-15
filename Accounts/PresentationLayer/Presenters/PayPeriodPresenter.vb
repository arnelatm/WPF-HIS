Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayPeriodPresenter
        Inherits AccountsPresenter(Of IPayPeriodView, PayPeriodModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private _attendanceItemModel

        Public Sub New(view As IPayPeriodView)
            MyBase.New(view)
            InitializerWithTv("PayPeriod")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _attendanceItemModel = New ModelAccounts("AttendanceItem", Nothing, Nothing)

            CreateDataTable(DtInsertTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"PayPeriodIdNo", GetType(Int32)},
                                            {"Sequence", GetType(Int16)}
                                           })

            CreateDataTable(DtUpdateTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayPeriodIdNo", GetType(Int32)},
                                            {"Sequence", GetType(Int16)}
                                           })

        End Sub

        Public Sub InitializeMonthlyPayroll(payCycleRecord As PayCycle)
            If View.StartDate = Nothing And View.EndDate = Nothing Then
                Dim nIdNoMax As Int32
                Dim maxRecord As PayPeriodModel
                Dim payMonthText As String = "Payroll for the Month of"
                Dim payPeriodText As String = "Payroll for the Period"
                nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "PayPeriod", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                maxRecord = ModelPresenter.GetRecordById(Of PayPeriodModel)(nIdNoMax)
                View.StartDate = maxRecord.EndDate.AddDays(1)
                Dim arabicCulture As New CultureInfo("ar-ae", False)
                If View.StartDate.Day = 1 Then
                    View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
                    View.PayPeriodName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                    View.PayPeriodNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
                Else
                    View.EndDate = maxRecord.EndDate.AddMonths(1)
                    View.PayPeriodName = payPeriodText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
                    View.PayPeriodNameAra = Messaging.TranslateCaption(payPeriodText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                End If
                View.PayPeriodCode = "M" + View.EndDate.ToString("yyMM")
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayPeriodAttendance, DtInsertTable, DtUpdateTable, AddressOf AttendanceItemFillData, AddressOf AttendanceItemFilter)
            End If
            'For Each item In View.PayPeriodAttendance
            '    If item.Equals(DBNull.Value) Then
            '        item.Notes = ""
            '    End If
            '    If item.Notes Is Nothing Then
            '        item.Notes = ""
            '    End If
            'Next
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_attendanceItemModel, DtUpdateTable, DtInsertTable, passedValue, "PayPeriodIdNo")
        End Sub

        Private Sub AttendanceItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("DaysAbsentWithoutPay") = itemDataView.DaysAbsentWithoutPay
            workRow("DaysAbsentWithPay") = itemDataView.DaysAbsentWithPay
            workRow("DaysOff") = itemDataView.DaysOff
            workRow("DaysPresent") = itemDataView.DaysPresent
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("PayPeriodIdNo") = View.IdNo
        End Sub

        Public Function AttendanceItemFilter(ByVal obj As Object) As Boolean
            'If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
            '    Return False
            'End If
            Return True
        End Function

    End Class

End Namespace