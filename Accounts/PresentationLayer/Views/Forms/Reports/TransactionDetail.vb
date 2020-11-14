Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports
    Public Class TransactionDetail

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Chart"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            cboStartAccountCode.DataSource = PresenterObj.GetDetailAccountList()
            cboEndAccountCode.DataSource = PresenterObj.GetDetailAccountList()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, Today.Month, Today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim beginningDate As Date
            Dim lastFiscalYearDate As Date
            Dim chartBalanceYear As Integer
            Dim begDataDate As Date
            Dim language As String
            Dim cTemp as String
            Dim dDate as Date
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            lastFiscalYearDate = PresenterObj.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")

            beginningDate = dtpBeginningDate.Value
            'dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), 12, 31)

            If beginningDate < lastFiscalYearDate Then
                chartBalanceYear = Year(beginningDate)
                begDataDate = beginningDate
            Else
                chartBalanceYear = Year(lastFiscalYearDate)
                begDataDate = DateSerial(chartBalanceYear, 1, 1)
            End If

            if dtpBeginningDate.Value > dtpEndingDate.Value then
                dDate = dtpBeginningDate.Value
                dtpBeginningDate.Value = dtpEndingDate.Value
                dtpEndingDate.Value = dDate
            End If
            if cboStartAccountCode.SelectedValue > cboEndAccountCode.SelectedValue then
                cTemp = cboStartAccountCode.SelectedValue
                cboStartAccountCode.SelectedValue = cboEndAccountCode.SelectedValue
                cboEndAccountCode.SelectedValue = cTemp
            End If

            Refresh()
            Dim cForm As New ReportForm("Transaction Detail.Rpt", dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", chartBalanceYear, "ChartBalanceYear", begDataDate, "BegDataDate", lastFiscalYearDate, "LastFiscalYearDate", cboStartAccountCode.SelectedValue, "BegAccountCode", cboEndAccountCode.SelectedValue, "EndAccountCode", language, "Language")
            cForm.Show()

            CultureInfo.CurrentCulture = curCulture

        End Sub


        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(FormIdNo)
        End Sub

        'Private Sub TransactionDetail_BeforeLoad() Handles MyBase.BeforeLoad
        '    Dim currentDate = Now()
        '    Dim endDate As Date
        '    lblBegDateCaption.Visible = False
        '    dtpBeginningDate.Visible = False
        '    lblBegDateCaption.Visible = True
        '    lblEndDateCaption.Visible = True
        '    dtpEndingDate.Visible = True
        '    dtpBeginningDate.Visible = True
        '    endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, Month(currentDate), 0)
        '    Text = "Transaction Detail for Custom Period"
        '    lblEndDateCaption.Text = "Period Beginning Date:"
        '    lblEndDateCaption.Text = "Period End Date:"
        'lblTitle.Text = Text
        'dtpEndingDate.Value = endDate
        'End Sub

        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboStartAccountCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboEndAccountCode As Libraries.CBaseControlsLibrary.CaComboBox
    End Class
End Namespace