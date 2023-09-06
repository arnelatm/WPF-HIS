Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DateRangeSelector
        Implements IDateRangeView

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _reportParameters As New ArrayList
        Private ReadOnly _reportModel As ReportModel
        Private ReadOnly _period As String
        Public Event FormLoaded() Implements IDateRangeView.FormLoaded
        Public Event PrintButtonClicked() Implements IDateRangeView.PrintButtonClicked


        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)

        End Sub

        Public Sub New(reportModel As ReportModel)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _reportModel = reportModel
            MainTableName = "Report"

        End Sub

        Private Sub BtnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
        End Sub

        Private Sub BtnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

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

        Public ReadOnly Property Language As String Implements IDateRangeView.Language
        Public ReadOnly Property ReportCode As String Implements IDateRangeView.ReportCode
        Public Property Title As String Implements IDateRangeView.Title
        Public Property UserHasAccess As Boolean Implements IDateRangeView.UserHasAccess

        Public Property NoContact As Boolean Implements IDateRangeView.NoContact
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Boolean)
                Throw New NotImplementedException()
            End Set
        End Property
    End Class

End Namespace