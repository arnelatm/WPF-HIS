Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub

Public Class BalanceSheetPresenter(Of TM As New)
    Inherits AccountsPresenter(Of IBalanceSheetView, TM)

    Private _presenter As AccountsPresenter(Of IBalanceSheetView, ReportModel)
    Private _period As String

    Public Sub New(view As IBalanceSheetView, period As String)
        MyBase.New(view)
        TableName = "Account"
        WithTreeView = False
        Service = New AccountsService("Account")
        _period = period
        AddHandler view.PrintButtonClicked, AddressOf OnPrintButtonClicked
    End Sub

    Public Sub New()
    End Sub


    Public Sub OnPrintButtonClicked()
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        Dim beginningDate As Date?
        Dim endingDate As Date?
        Dim lastFiscalYearDate As Date
        Dim AccountBalanceYear As Integer
        Dim begDataDate As Date
        'Dim language As String
        Dim estName As String
        If View.Language = "ar" Then
            estName = GlobalVariables.EstablishmentNameAra
        Else
            estName = GlobalVariables.EstablishmentName
        End If
        lastFiscalYearDate = Service.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")
        beginningDate = IIf(View.BeginningDate Is Nothing, View.EndingDate, View.BeginningDate)
        endingDate = View.BeginningDate
        AdjustBeginningEndDates(_period, beginningDate, endingDate)
        If beginningDate < lastFiscalYearDate Then
            AccountBalanceYear = Year(beginningDate)
            begDataDate = beginningDate
        Else
            AccountBalanceYear = Year(lastFiscalYearDate)
            begDataDate = DateSerial(AccountBalanceYear, 1, 1)
        End If
        Dim reportName = Libraries.MessagingLibrary.Messaging.TranslateCaption("Balance Sheet")
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
            reportTitle = Libraries.MessagingLibrary.Messaging.SelectReportName(reportName, beginningDate, endingDate, curCulture, _period)
            reportArgs.ReportParameters = {beginningDate, "BeginningDate",
                                      endingDate, "EndingDate",
                                      AccountBalanceYear, "AccountBalanceYear",
                                      begDataDate, "BegDataDate",
                                      lastFiscalYearDate, "LastFiscalYearDate",
                                      estName, "EstablishmentName",
                                      reportTitle, "ReportTitle",
                                      View.Language, "Language"
                                      }
            Dim p As New PrintReportPresenter(Of AccountModel)
            p.ViewReport("Balance Sheet.Rpt", reportArgs, False)
        End If
        CultureInfo.CurrentCulture = curCulture

    End Sub


End Class


