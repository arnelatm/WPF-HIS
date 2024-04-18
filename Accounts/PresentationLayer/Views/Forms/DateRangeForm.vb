Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace Accounts.PresentationLayer.Views.Forms

    Public Class DateRangeForm
        Implements IDateRangeView

        Public ReadOnly Property Language As String Implements IDateRangeView.Language
        Public ReadOnly Property ReportCode As String Implements IDateRangeView.ReportCode
        Public Property UserHasAccess As Boolean Implements IDateRangeView.UserHasAccess
        Public Property Title As String Implements IDateRangeView.Title
        Protected SortOrderKey As String
        Protected ReadOnly _reportParameters As New ArrayList
        Protected ReadOnly _reportModel As ReportModel
        Protected ReadOnly _period As String
        Protected Event FormLoaded() Implements IDateRangeView.FormLoaded
        Protected Event PrintButtonClicked() Implements IDateRangeView.PrintButtonClicked

        Public Property MainTableName As String

        Public Property BeginningDate As Date? Implements IDateRangeView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
            Set(value As Date?)
                dtpBeginningDate.Value = value
            End Set
        End Property

        Public Property EndingDate As Date? Implements IDateRangeView.EndingDate
            Get
                Return dtpEndingDate.Value
            End Get
            Set(value As Date?)
                dtpEndingDate.Value = value
            End Set
        End Property

        Private _noContact As Boolean

        Public Property NoContact As Boolean Implements IDateRangeView.NoContact
            Get
                Return _noContact
            End Get
            Set(value As Boolean)
                _noContact = value
            End Set
        End Property

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            NoContact = True
        End Sub

        Public Sub New(reportModel As ReportModel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _reportModel = reportModel
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            NoContact = True
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            'BeginningDate = dateRange.BeginningDate
            'EndingDate = dateRange.EndingDate
            RaiseEvent PrintButtonClicked()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub DateRangeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            If NoContact Then
                lblContactIdNo.Visible = False
                cboContactIdNo.Visible = False
                Height = 215
            Else
                lblContactIdNo.Visible = True
                cboContactIdNo.Visible = True
                Height = 240
            End If
            RaiseEvent FormLoaded()
        End Sub

        Private Sub CLabel2_Click(sender As Object, e As EventArgs) Handles CLabel2.Click
            Debugger.Break()
        End Sub
    End Class

End Namespace