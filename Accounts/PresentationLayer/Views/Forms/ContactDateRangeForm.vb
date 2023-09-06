Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters.Views.Forms
    Public Class ContactDateRangeForm
        Implements IContactDateRangeView

        Public ReadOnly Property Language As String Implements IDateRangeView.Language
        Public ReadOnly Property ReportCode As String Implements IDateRangeView.ReportCode
        Public Property UserHasAccess As Boolean Implements IDateRangeView.UserHasAccess
        Public Property Title As String Implements IDateRangeView.Title
        Protected SortOrderKey As String
        Private ReadOnly _reportParameters As New ArrayList
        Private ReadOnly _reportModel As ReportModel
        Private ReadOnly _period As String
        Public Event FormLoaded() Implements IDateRangeView.FormLoaded
        Public Event PrintButtonClicked() Implements IDateRangeView.PrintButtonClicked

        Public Property MainTableName As String

        Public Property BeginningDate As Date? Implements IDateRangeView.BeginningDate
            Get
                Return dateRange.BeginningDate.Value
            End Get
            Set(value As Date?)
                dateRange.BeginningDate = value
            End Set
        End Property

        Public Property EndingDate As Date? Implements IDateRangeView.EndingDate
            Get
                Return dateRange.EndingDate
            End Get
            Set(value As Date?)
                dateRange.EndingDate = value
            End Set
        End Property

        Public Property IdNo As Integer Implements IContactDateRangeView.IdNo
            Get
                Return cboContactIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboContactIdNo.SetValue(value)
            End Set
        End Property

        Public Property PersonSelectorControl As Control Implements IContactDateRangeView.PersonSelectorControl

        Public Property PersonSelectorLabel As String Implements IContactDateRangeView.PersonSelectorLabel

        Public Property ContactDataSource As Object Implements IContactDateRangeView.ContactDataSource

        Public ReadOnly Property NoContact As Boolean Implements IDateRangeView.NoContact
            Get
                Return False
            End Get
        End Property

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dateRange.BeginningDate = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dateRange.EndingDate = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            lblContactIdNo.Visible = True
            cboContactIdNo.Visible = True
        End Sub

        Public Sub New(reportModel As ReportModel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _reportModel = reportModel
            MainTableName = "Report"
            SortOrderKey = "IdNo"
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub
    End Class

End Namespace
