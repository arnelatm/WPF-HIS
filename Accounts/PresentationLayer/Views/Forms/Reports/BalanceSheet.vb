Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class BalanceSheet
        Implements IBalanceSheetView

        Public Property MainTableName As String
        Public Event PrintButtonClicked() Implements IBalanceSheetView.PrintButtonClicked
        Protected SortOrderKey As String
        Private ReadOnly _period As String

        Public Sub New(period As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
            SortOrderKey = "IdNo"
            _period = period

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
        End Sub

        Public ReadOnly Property BeginningDate As Date? Implements IBalanceSheetView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
        End Property

        Public ReadOnly Property EndingDate As Date? Implements IBalanceSheetView.EndingDate
            Get
                Return dtpEndingDate.Value
            End Get
        End Property

        Public ReadOnly Property Language As String Implements IBalanceSheetView.Language
            Get
                Dim curCulture = CultureInfo.CurrentCulture
                Return Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            End Get
        End Property


        Public ReadOnly Property Period As String Implements IBalanceSheetView.Period
            Get
                Return _period
            End Get
        End Property

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