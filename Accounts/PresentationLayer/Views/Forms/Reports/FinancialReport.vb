Imports System.Globalization
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class FinancialReport
        Implements IFinancialReportView

        Public Property MainTableName As String
        Public Event PrintButtonClicked() Implements IFinancialReportView.PrintButtonClicked
        Public Event ReportLoaded() Implements IFinancialReportView.ReportLoaded
        Protected SortOrderKey As String

        Public Sub New(pReportCode As String, Optional pPeriod As String = Nothing)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
            SortOrderKey = "IdNo"
            ReportCode = pReportCode
            Period = pPeriod
            Dim currentDate = Now()
            Dim endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, 0)
            dtpEndingDate.Value = endDate
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(endDate.Year, endDate.Month, 1)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
        End Sub

        Public ReadOnly Property BeginningDate As Date? Implements IFinancialReportView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
        End Property

        Public ReadOnly Property EndingDate As Date? Implements IFinancialReportView.EndingDate
            Get
                Return dtpEndingDate.Value
            End Get
        End Property

        Public ReadOnly Property Language As String Implements IFinancialReportView.Language
            Get
                Dim curCulture = CultureInfo.CurrentCulture
                Return Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            End Get
        End Property

        Public ReadOnly Property Period As String Implements IFinancialReportView.Period

        Public Property ReportCode As String Implements IFinancialReportView.ReportCode

        Public Property Title As String Implements IFinancialReportView.Title


        Public Property WithZeroBalanceQuery As Boolean Implements IFinancialReportView.WithZeroBalanceQuery

        Public Property ZeroBalanceChecked As Boolean Implements IFinancialReportView.ZeroBalanceChecked
            Get
                Return chkIncludeZeroBalances.Checked
            End Get
            Set(value As Boolean)
                chkIncludeZeroBalances.Checked = value
            End Set
        End Property

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(VSystemViewIdNo)
        End Sub

        Private Sub FinancialReport_Shown() Handles MyBase.Shown
            lblBegDateCaption.Visible = False
            dtpBeginningDate.Visible = False
            If Period Is Nothing OrElse Period = "C" Then
                lblBegDateCaption.Visible = True
                lblEndDateCaption.Visible = True
                dtpEndingDate.Visible = True
                dtpBeginningDate.Visible = True
            End If
            If WithZeroBalanceQuery Then
                lblIncludeZeroBalances.Visible = True
                chkIncludeZeroBalances.Visible = True
            Else
                lblIncludeZeroBalances.Visible = False
                chkIncludeZeroBalances.Visible = False
                Height = 205
            End If
            RaiseEvent ReportLoaded()
            lblTitle.Text = Title
            Text = Title
        End Sub

    End Class

End Namespace