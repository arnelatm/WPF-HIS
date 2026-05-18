Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub

Public Class FinancialReportPresenter(Of TM As New)
    Inherits AccountsPresenter(Of IFinancialReportView, TM)

    Private _reportFileName As String
    Private _reportName As String
    Private _withFiscalYearDateRequirement As Boolean

    Public Sub New(view As IFinancialReportView)
        MyBase.New(view)
        TableName = "Account"
        WithTreeView = False
        Service = New AccountsService("Account")
        AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
        AddHandler view.ReportLoaded, AddressOf OnReportLoaded
        SetupReportRequirements()
    End Sub


    Public Sub New()
    End Sub


    Private Sub SetupReportRequirements()
        Select Case View.ReportCode
            Case "BalanceSheet"
                _reportName = "Balance Sheet"
                _reportFileName = "Balance Sheet.Rpt"
                _withFiscalYearDateRequirement = True
            Case "IncomeStatement"
                _reportName = "Profit & Loss Statement"
                _reportFileName = "Income Statement.Rpt"
                _withFiscalYearDateRequirement = True
            Case "TrialBalance"
                _reportName = "Trial Balance"
                _reportFileName = "Trial Balance.Rpt"
                _withFiscalYearDateRequirement = True
            Case "ApSummary"
                _reportName = "Summary of Accounts Payable"
                _reportFileName = "Summary of Accounts Payable.Rpt"
                View.WithZeroBalanceQuery = True
                _withFiscalYearDateRequirement = False
            Case "ArSummary"
                _reportName = "Summary of Accounts Receivable"
                _reportFileName = "Summary of Accounts Receivable.Rpt"
                View.WithZeroBalanceQuery = True
                _withFiscalYearDateRequirement = False
            Case "ErSummary"
                _reportName = "Summary of Employee Loans"
                _reportFileName = "Summary of Employee Loans.Rpt"
                View.WithZeroBalanceQuery = True
                _withFiscalYearDateRequirement = False
            Case "BalanceSheetClosing"
                _reportName = "Balance Sheet Closing Year"
                _reportFileName = "Balance Sheet Closing.Rpt"
                _withFiscalYearDateRequirement = True
            Case "TrialBalanceClosing"
                _reportName = "Trial Balance Closing Year"
                _reportFileName = "Trial Balance Closing.Rpt"
                _withFiscalYearDateRequirement = True
        End Select
    End Sub

    Public Sub OnPrintButtonClicked()
        Dim curCulture = CultureInfo.CurrentCulture
        Dim language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        Dim beginningDate As Date?
        Dim endingDate As Date?
        Dim lastFiscalYearDate As Date
        Dim AccountBalanceYear As Integer
        Dim begDataDate As Date
        Dim estName As String
        If language = "ar" Then
            estName = GlobalVariables.EstablishmentNameAra
        Else
            estName = GlobalVariables.EstablishmentName
        End If
        If _withFiscalYearDateRequirement Then
            lastFiscalYearDate = Service.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")
            beginningDate = IIf(View.BeginningDate Is Nothing, View.EndingDate, View.BeginningDate)
            endingDate = View.EndingDate
            AdjustBeginningEndDates(View.Period, beginningDate, endingDate)
            If beginningDate < lastFiscalYearDate Then
                AccountBalanceYear = Year(beginningDate)
                begDataDate = beginningDate
            Else
                If View.ReportCode = "TrialBalance" Or View.ReportCode = "TrialBalanceClosing" Then
                    AccountBalanceYear = GetFieldOnMaxField("Year", "AccountBalance", "Year")
                Else
                    AccountBalanceYear = Year(lastFiscalYearDate)
                    begDataDate = DateSerial(AccountBalanceYear, 1, 1)
                End If
            End If
        Else
            beginningDate = View.BeginningDate
            endingDate = View.EndingDate
        End If
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
            Dim reportArgs As New CrPrintableArgs
            Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(beginningDate, CultureInfo.CreateSpecificCulture("en-GB"))
            Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(endingDate, CultureInfo.CreateSpecificCulture("en-GB"))
            reportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(reportName, beginningDate, endingDate, curCulture, View.Period)
            Select Case View.ReportCode
                Case "BalanceSheet", "BalanceSheetClosing"
                    reportArgs.ReportParameters = {beginningDate, "BeginningDate",
                                  endingDate, "EndingDate",
                                  AccountBalanceYear, "AccountBalanceYear",
                                  begDataDate, "BegDataDate",
                                  lastFiscalYearDate, "LastFiscalYearDate",
                                  estName, "EstablishmentName",
                                  reportTitle, "ReportTitle",
                                  language, "Language"
                                  }
                Case "TrialBalance", "TrialBalanceClosing"
                    reportArgs.ReportParameters = {beginningDate, "BeginningDate",
                                      endingDate, "EndingDate",
                                      AccountBalanceYear, "AccountBalanceYear",
                                      lastFiscalYearDate, "LastFiscalYearDate",
                                      estName, "EstablishmentName",
                                      reportTitle, "ReportTitle",
                                      language, "Language"
                                      }
                Case "IncomeStatement"
                    reportArgs.ReportParameters = {beginningDate, "BeginningDate",
                                      endingDate, "EndingDate",
                                      estName, "EstablishmentName",
                                      reportTitle, "ReportTitle",
                                      language, "Language"
                                      }
                Case "ApSummary", "ArSummary", "ErSummary"
                    reportArgs.ReportParameters = {bDate, "BeginningDate",
                                     eDate, "EndingDate",
                                     reportTitle, "ReportTitle",
                                     View.ZeroBalanceChecked, "IncludeZeroBalance",
                                     estName, "EstablishmentName",
                                     language, "Language"}

                    'Case "ArSummary"
                    '    reportArgs.ReportParameters = {bDate, "BeginningDate",
                    '                     eDate, "EndingDate",
                    '                     reportTitle, "ReportTitle",
                    '                     View.ZeroBalanceChecked, "IncludeZeroBalance",
                    '                     estName, "EstablishmentName",
                    '                     View.Language, "Language"}
                    'Case "ErSummary"
                    '    reportArgs.ReportParameters = {bDate, "BeginningDate",
                    '                     eDate, "EndingDate",
                    '                     reportTitle, "ReportTitle",
                    '                     View.ZeroBalanceChecked, "IncludeZeroBalance",
                    '                     GlobalVariables.EstablishmentName, "EstablishmentName",
                    '                     View.Language, "Language"}

            End Select
            Dim p As New PrintReportPresenter(Of AccountModel)
            p.ViewReport(_reportFileName, reportArgs, False)
        End If
        CultureInfo.CurrentCulture = curCulture

    End Sub

    Private Sub OnReportLoaded()
        AdjustBeginningEndDates(View.Period, View.BeginningDate, View.EndingDate)
        Dim title As String
        title = Libraries.MessagingLibrary.Messaging.TranslateCaption(_reportName)
        Select Case View.Period
            Case "Y"
                title = Libraries.MessagingLibrary.Messaging.TranslateCaption("Yearly") + " " + title
            Case "M"
                title = Libraries.MessagingLibrary.Messaging.TranslateCaption("Monthly") + " " + title
            Case "Q"
                title = Libraries.MessagingLibrary.Messaging.TranslateCaption("Quarterly") + " " + title
            Case "S"
                title = Libraries.MessagingLibrary.Messaging.TranslateCaption("Semestral") + " " + title
            Case "C"
        End Select
        View.Title = title
    End Sub


End Class


