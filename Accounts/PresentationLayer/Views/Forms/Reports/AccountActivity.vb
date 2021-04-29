Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class AccountActivity

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
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
            Dim AccountBalanceYear As Integer
            Dim begDataDate As Date
            Dim language As String
            Dim cTemp As String
            Dim dDate As Date
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            lastFiscalYearDate = PresenterObj.GetRecordFieldWithKeyG(Of Date)("LastFiscalYearEnd", "LastPosting", "TransactionName", "lastPostingDate")

            beginningDate = dtpBeginningDate.Value
            'dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Year(dtpEndingDate.Value), 12, 31)

            If beginningDate < lastFiscalYearDate Then
                AccountBalanceYear = Year(beginningDate)
                begDataDate = beginningDate
            Else
                AccountBalanceYear = Year(lastFiscalYearDate)
                begDataDate = DateSerial(AccountBalanceYear, 1, 1)
            End If

            If dtpBeginningDate.Value > dtpEndingDate.Value Then
                dDate = dtpBeginningDate.Value
                dtpBeginningDate.Value = dtpEndingDate.Value
                dtpEndingDate.Value = dDate
            End If
            If cboStartAccountCode.SelectedValue > cboEndAccountCode.SelectedValue Then
                cTemp = cboStartAccountCode.SelectedValue
                cboStartAccountCode.SelectedValue = cboEndAccountCode.SelectedValue
                cboEndAccountCode.SelectedValue = cTemp
            End If

            Refresh()
            Dim valid As Boolean = True
            If dtpBeginningDate.Value Is Nothing Or dtpBeginningDate.Value Is Nothing Then
                Messaging.Show(True, "MsgDatesCannotBeEmpty")
                valid = False
            ElseIf dtpBeginningDate.Value > dtpBeginningDate.Value Then
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
                valid = False
            End If
            If valid Then
                Dim reportTitle As String
                reportTitle = Messaging.TranslateCaption("Account Activity Report")
                Dim cForm As New ReportFormNew("Account Activity Report.Rpt", reportTitle, CultureInfo.CurrentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboStartAccountCode.SelectedValue, "BegAccountCode", cboEndAccountCode.SelectedValue, "EndAccountCode", language, "Language")
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

        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboStartAccountCode As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents cboEndAccountCode As Libraries.CBaseControlsLibrary.CaComboBox
    End Class

End Namespace