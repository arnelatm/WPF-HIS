Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class IncomeStatement

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _period As String

        Public Sub New(period As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            _period = period

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim beginningDate As Date
            Dim lastFiscalYearDate As Date
            Dim AccountBalanceYear As Integer
            Dim begDataDate As Date
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            lastFiscalYearDate = PresenterObj.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")

            Select Case _period
                Case "Y"
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), 1, 1)
                    dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), 12, 31)
                Case "M"
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), Month(dtpEndingDate.Value), 1)
                    dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), Month(dtpEndingDate.Value) + 1, 0)
                Case "Q"
                    Dim nMonth = Month(dtpEndingDate.Value)
                    Dim quarter = Int(nMonth / 3 + 0.8)
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), quarter * 3 - 2, 1)
                    Dim quarterEndDate = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), quarter * 3, 1)
                    quarterEndDate = DateSerial(Year(quarterEndDate), Month(quarterEndDate), DateTime.DaysInMonth(Year(quarterEndDate), Month(quarterEndDate)))
                    dtpEndingDate.Value = quarterEndDate
                Case "S"
                    Dim nMonth = Month(dtpEndingDate.Value)
                    Dim semester = Int(nMonth / 6 + 0.9)
                    beginningDate = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), semester * 6 - 5, 1)
                    Dim semesterEndDate = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), semester * 6, 1)
                    semesterEndDate = DateSerial(Year(semesterEndDate), Month(semesterEndDate), DateTime.DaysInMonth(Year(semesterEndDate), Month(semesterEndDate)))
                    dtpEndingDate.Value = semesterEndDate
                Case "C"
                    beginningDate = dtpBeginningDate.Value
            End Select
            If beginningDate < lastFiscalYearDate Then
                AccountBalanceYear = Year(beginningDate)
                begDataDate = beginningDate
            Else
                AccountBalanceYear = Year(lastFiscalYearDate)
                begDataDate = DateSerial(AccountBalanceYear, 1, 1)
            End If
            Dim cForm As New ReportForm("Income Statement.Rpt", beginningDate, "BeginningDate", dtpEndingDate.Value, "EndingDate", language, "Language", _period, "Period")
            cForm.Show()

            CultureInfo.CurrentCulture = curCulture

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(FormIdNo)
        End Sub

        Private Sub IncomeStatement_BeforeLoad() Handles MyBase.BeforeLoad
            Dim currentDate = Now()
            Dim endDate As Date
            lblBegDateCaption.Visible = False
            dtpBeginningDate.Visible = False
            Select Case _period
                Case "Y"
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year - 1, 12, 31)
                    Text = "Income Statement for the Year"
                    lblEndDateCaption.Text = "Year End Date:"
                Case "M"
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
                    Text = "Income Statement for the Month"
                    lblEndDateCaption.Text = "Month End Date:"
                Case "Q"
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
                    Text = "Income Statement for the Quarter"
                    lblEndDateCaption.Text = "Quarterly End Date:"
                Case "S"
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
                    Text = "Income Statement for the Semester"
                    lblEndDateCaption.Text = "Semester End Date:"
                Case "C"
                    lblBegDateCaption.Visible = True
                    lblEndDateCaption.Visible = True
                    dtpEndingDate.Visible = True
                    dtpBeginningDate.Visible = True
                    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
                    Text = "Income Statement for Custom Period"
                    lblEndDateCaption.Text = "Period Beginning Date:"
                    lblEndDateCaption.Text = "Period End Date:"

            End Select
            lblTitle.Text = Text
            dtpEndingDate.Value = endDate
        End Sub

    End Class

End Namespace