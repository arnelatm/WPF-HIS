Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class BalanceSheet

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _period As String

        Public Sub New(period As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            _period = period

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim beginningDate As Date?
            Dim endingDate As Date?
            Dim lastFiscalYearDate As Date
            Dim AccountBalanceYear As Integer
            Dim begDataDate As Date
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            lastFiscalYearDate = Presenter.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")
            beginningDate = IIf(dtpBeginningDate.Value Is Nothing, dtpEndingDate.Value, dtpBeginningDate.Value)
            endingDate = dtpEndingDate.Value
            AdjustBeginningEndDates(_period, beginningDate, endingDate)
            dtpEndingDate.Value = endingDate
            dtpBeginningDate.Value = beginningDate
            If beginningDate < lastFiscalYearDate Then
                AccountBalanceYear = Year(beginningDate)
                begDataDate = beginningDate
            Else
                AccountBalanceYear = Year(lastFiscalYearDate)
                begDataDate = DateSerial(AccountBalanceYear, 1, 1)
            End If
            Dim reportName = Messaging.TranslateCaption("Balance Sheet")
            Dim reportTitle As String
            Dim cForm
            Dim valid As Boolean = True
            If beginningDate Is Nothing Or endingDate Is Nothing Then
                Messaging.Show(True, "MsgDatesCannotBeEmpty")
                valid = False
            ElseIf beginningDate > endingDate Then
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
                valid = False
            End If
            If valid Then
                reportTitle = Messaging.SelectReportName(reportName, beginningDate, endingDate, curCulture, _period)
                cForm = New ReportFormNew("Balance Sheet.Rpt", reportTitle, curCulture, beginningDate, "BeginningDate", endingDate, "EndingDate", AccountBalanceYear, "AccountBalanceYear", begDataDate, "BegDataDate", lastFiscalYearDate, "LastFiscalYearDate")
                cForm.Show()
            End If
            CultureInfo.CurrentCulture = curCulture

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(VSystemViewIdNo)
        End Sub

        Private Sub BalanceSheet_Shown() Handles MyBase.Shown
            lblBegDateCaption.Visible = False
            dtpBeginningDate.Visible = False
            AdjustBeginningEndDates(_period, dtpBeginningDate.Value, dtpEndingDate.Value)
            Dim title As String
            title = Messaging.TranslateCaption("Balance Sheet")
            Select Case _period
                Case "Y"
                    title = Messaging.TranslateCaption("Yearly") + " " + title
                Case "M"
                    title = Messaging.TranslateCaption("Monthly") + " " + title
                Case "Q"
                    title = Messaging.TranslateCaption("Quarterly") + " " + title
                Case "S"
                    title = Messaging.TranslateCaption("Semestral") + " " + title
                Case "C"
                    lblBegDateCaption.Visible = True
                    lblEndDateCaption.Visible = True
                    dtpEndingDate.Visible = True
                    dtpBeginningDate.Visible = True
            End Select
            lblTitle.Text = title
        End Sub

    End Class

End Namespace