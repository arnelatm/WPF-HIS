Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ApArEmReport
        Implements IApArEmReportView

        Public Event PrintButtonClicked() Implements IApArEmReportView.PrintButtonClicked
        Public Event ReportLoaded() Implements IApArEmReportView.ReportLoaded
        Public Event LanguageChanged() Implements IApArEmReportView.LanguageChanged
        Protected SortOrderKey As String
        Private _title As String

        Public Sub New(pReportCode As String)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ReportCode = pReportCode
            lblTitle.Translatable = False
            MainTableName = "Account"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)
            PersonSelectorControl = cboIdNo
        End Sub

        Public Property MainTableName As String

        Public Property PersonSelectorControl As Control Implements IApArEmReportView.PersonSelectorControl


        Public Property BeginningDate As Date? Implements IApArEmReportView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
            Set(value As Date?)
                dtpBeginningDate.Value = value
            End Set
        End Property

        Public Property EndingDate As Date? Implements IApArEmReportView.EndingDate
            Get
                Return dtpEndingDate.Value
            End Get
            Set(value As Date?)
                dtpEndingDate.Value = value
            End Set
        End Property

        Public ReadOnly Property Language As String Implements IApArEmReportView.Language
            Get
                Return Strings.Left(TextDisplayLanguage, TextDisplayLanguage.IndexOf("-"))
            End Get
        End Property

        Public Property IdNo As Integer Implements IApArEmReportView.IdNo
            Get
                Return cboIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboIdNo.SetValue(value)
            End Set
        End Property

        Public ReadOnly Property ReportCode As String Implements IApArEmReportView.ReportCode

        Public Property UserHasAccess As Boolean Implements IApArEmReportView.UserHasAccess

        Public Property Title As String Implements IApArEmReportView.Title
            Get
                Return _title
            End Get
            Set(value As String)
                _title = value
                Text = value
                If lblTitle IsNot Nothing Then
                    lblTitle.Text = value
                End If
            End Set
        End Property

        Public Property PersonSelectorLabel As String Implements IApArEmReportView.PersonSelectorLabel

        Public Property NoDates As Boolean Implements IApArEmReportView.NoDates

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboIdNo.EditingMode = False
            RaiseEvent ReportLoaded()

            cboIdNo.EditingMode = True
            Text = Title
            lblTitle.Text = Title
            lblIdNo.Text = PersonSelectorLabel
            dtpBeginningDate.Visible = Not NoDates
            dtpEndingDate.Visible = Not NoDates
            lblBeginningDate.Visible = Not NoDates
            lblEndingDate.Visible = Not NoDates
            If NoDates Then
                Height -= 25
            End If
        End Sub

        Private Sub OnTextDisplayLanguageChanged() Handles MyBase.TextDisplayLanguageChanged
            RaiseEvent LanguageChanged()
        End Sub

        Protected Overrides Sub OnAfterLanguageSwitch(context As LanguageSwitchContext)
            MyBase.OnAfterLanguageSwitch(context)
            Text = Title
            lblTitle.Text = Title
        End Sub

    End Class

End Namespace
