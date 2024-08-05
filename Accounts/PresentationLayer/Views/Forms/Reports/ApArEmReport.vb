Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ApArEmReport
        Implements IApArEmReportView

        Private _idNoData As DataTable
        Public Event PrintButtonClicked() Implements IApArEmReportView.PrintButtonClicked
        Public Event ReportLoaded() Implements IApArEmReportView.ReportLoaded
        Protected SortOrderKey As String

        Public Sub New(pReportCode As String)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ReportCode = pReportCode
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

        'Public ReadOnly Property CultureInfoString As String Implements IApArEmReportView.CultureInfoString
        '    Get
        '        GlobalVariables.LastCultureInfo = New Globalization.CultureInfo(FormCulture.Name)
        '        Return FormCulture.Name
        '        'Return Strings.Left(FormCulture.Name, FormCulture.Name.IndexOf("-"))
        '    End Get
        'End Property

        Public Property IdNo As Integer Implements IApArEmReportView.IdNo
            Get
                Return cboIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboIdNo.SetValue(value)
            End Set
        End Property

        Public Property IdNoData As DataTable Implements IApArEmReportView.IdNoData
            Get
                Return _idNoData
            End Get
            Set(value As DataTable)
                _idNoData = value
                cboIdNo.DataSource = value
            End Set
        End Property

        Public ReadOnly Property ReportCode As String Implements IApArEmReportView.ReportCode

        Public Property UserHasAccess As Boolean Implements IApArEmReportView.UserHasAccess

        Public Property Title As String Implements IApArEmReportView.Title

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
            btnCancel.Left = floButtons.Size.Width - btnCancel.Width - btnOk.Width - floButtons.Margin.Left - floButtons.Margin.Right
        End Sub

    End Class

End Namespace