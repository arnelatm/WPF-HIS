Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Public Class ApArEmReportPresenter(Of TM As New)
    Inherits CommonPresenterNew(Of IApArEmReportView, TM)

    Private _reportFileName As String
    Private _reportName As String
    Private _reportCode As String
    Private _selectorFilter As String
    Private _tableName As String
    Private _filter As String = ""
    Private _withFiscalYearDateRequirement As Boolean

    Public Sub New(view As IApArEmReportView, reportCode As String)
        MyBase.New(view)
        TableName = "Account"
        Service = New AccountsService("Account")
        _reportCode = reportCode
        AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
        AddHandler view.ReportLoaded, AddressOf OnReportLoaded
        SetupReportSpecs()
        view.IdNoData = MakeDataTable({_tableName})
    End Sub


    Public Sub New()
    End Sub


    Private Sub SetupReportSpecs()
        Select Case View.ReportCode
            Case "ApStatement"
                _reportName = "Statement Of Accounts Payable"
                If View.Language = "ar" Then
                    _reportFileName = "Statement of Accounts Payable Arabic.Rpt"
                Else
                    _reportFileName = "Statement of Accounts Payable.Rpt"
                End If
                _tableName = "Supplier"
                View.NoDates = False
            Case "ArStatement"
                _reportName = "Statement Of Accounts Receivable"
                If View.Language = "ar" Then
                    _reportFileName = "Statement of Accounts Receivable Arabic.Rpt"
                Else
                    _reportFileName = "Statement of Accounts Receivable.Rpt"
                End If
                _tableName = "Customer"
                View.NoDates = False
            Case "ErStatement"
                _reportName = "Statement Of Employee Loans"
                If View.Language = "ar" Then
                    _reportFileName = "Statement of Employee Loans Arabic.Rpt"
                Else
                    _reportFileName = "Statement of Employee Loans.Rpt"
                End If
                _tableName = "Employee"
                View.NoDates = False
            Case "EmployeeInfo"
                _reportName = "Employee Information"
                _reportFileName = "HR Employee Info.Rpt"
                _tableName = "Employee"
                View.NoDates = True
            Case "LeaveStatement"
                _reportName = "Statement of Employee Leaves"
                _reportFileName = "Statement Of Employee Leaves.Rpt"
                _tableName = "Employee"
                View.NoDates = False
        End Select
    End Sub

    Private Sub OnPrintButtonClicked()
        'Dim curCulture = CultureInfo.CurrentCulture
        'CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        Dim beginningDate As Date?
        Dim endingDate As Date?
        Dim estName As String

        If View.Language = "ar" Then
            estName = GlobalVariables.EstablishmentNameAra
        Else
            estName = GlobalVariables.EstablishmentName
        End If
        beginningDate = View.BeginningDate
        endingDate = View.EndingDate
        Dim reportName = Libraries.MessagingLibrary.Messaging.TranslateCaption(_reportName)
        Dim reportTitle As String
        Dim valid As Boolean = True
        If beginningDate Is Nothing Or endingDate Is Nothing Then
            Libraries.MessagingLibrary.Messaging.Show(True, "MsgDatesCannotBeEmpty")
            valid = False
        ElseIf beginningDate > endingDate Then
            Libraries.MessagingLibrary.Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            valid = False
        End If
        If valid Then
            Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
            Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(endingDate, CultureInfo.CreateSpecificCulture("en-GB"))
            Dim reportParameters As New Object
            reportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(reportName, beginningDate, endingDate, View.FormCulture)
            Select Case View.ReportCode
                Case "ApStatement"
                    reportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "SupplierIdNo",
                        View.PersonSelectorControl.Text, "DisplayName",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
                Case "ArStatement"
                    reportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "CustomerIdNo",
                        View.PersonSelectorControl.Text, "DisplayName",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
                Case "ErStatement"
                    reportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "EmployeeIdNo",
                        View.PersonSelectorControl.Text, "DisplayName",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
                Case "EmployeeInfo"
                    reportParameters = {View.IdNo, "EmployeeIdNo"}
                Case "LeaveStatement"
                    reportParameters = {beginningDate.Value, "BeginningDate",
                        endingDate.Value, "EndingDate",
                        View.IdNo, "EmployeeIdNo",
                        reportTitle, "ReportTitle",
                        GlobalVariables.EstablishmentName, "EstablishmentName",
                        View.Language, "Language"}
            End Select
            ShowReportToScreen(_reportFileName, reportParameters)
        End If

    End Sub

    Private Sub OnReportLoaded()
        View.BeginningDate = GlobalFunctions.GregorianDateSerial(Today.Year, 1, 1)
        View.EndingDate = GlobalFunctions.GregorianDateSerial(Today.Year, Today.Month, Today.Day)
        View.Title = Libraries.MessagingLibrary.Messaging.TranslateCaption(_reportName)
        'MakeControlDataSources({New Object() {_tableName, View.PersonSelectorControl, Nothing, _filter}})
        Select Case View.ReportCode
            Case "LeaveStatement", "ErStatement", "EmployeeInfo"
                View.PersonSelectorLabel = "Employee Name"
            Case "ApStatement"
                View.PersonSelectorLabel = "Supplier Name"
            Case "ArStatement"
                View.PersonSelectorLabel = "Customer Name"
        End Select
    End Sub


End Class


