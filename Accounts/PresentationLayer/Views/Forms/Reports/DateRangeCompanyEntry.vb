Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DateRangeCompanyEntry
        Implements IContactDateRangeView

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private ReadOnly _reportParameters As New ArrayList
        Private ReadOnly _reportModel As ReportModel
        Private ReadOnly _period As String
        Private _insuranceList As Object
        Public Event FormLoaded() Implements IContactDateRangeView.FormLoaded
        Public Event PrintButtonClicked() Implements IContactDateRangeView.PrintButtonClicked


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
            SortOrderKey = "IdNo"

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Public Property InsuranceList As Object
            Get
                Return _insuranceList
            End Get
            Set(value As Object)
                _insuranceList = value
                BindInsuranceList()
            End Set
        End Property

        Public Property BeginningDate As Date? Implements IContactDateRangeView.BeginningDate
            Get
                Return dtpBeginningDate.Value
            End Get
            Set(value As Date?)
                dtpBeginningDate.Value = value
            End Set
        End Property

        Public Property EndingDate As Date? Implements IContactDateRangeView.EndingDate
            Get
                Return dtpEndingDate.Value
            End Get
            Set(value As Date?)
                dtpEndingDate.Value = value
            End Set
        End Property

        Public ReadOnly Property Language As String Implements IContactDateRangeView.Language

        Public Property IdNo As Integer Implements IContactDateRangeView.IdNo
            Get
                Return cboInsuranceIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboInsuranceIdNo.SetValue(value)
            End Set
        End Property

        Public ReadOnly Property ReportCode As String Implements IContactDateRangeView.ReportCode
        Public Property Title As String Implements IContactDateRangeView.Title
        Public Property UserHasAccess As Boolean Implements IContactDateRangeView.UserHasAccess
        Public Property PersonSelectorControl As Control Implements IContactDateRangeView.PersonSelectorControl
        Public Property PersonSelectorLabel As String Implements IContactDateRangeView.PersonSelectorLabel
        Public Property NoDates As Boolean Implements IContactDateRangeView.NoDates

        Public Property ContactDataSource As Object

        Private Property IContactDateRangeView_ContactDataSource As Object Implements IContactDateRangeView.ContactDataSource

        Private Sub DateRangeCompanyEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent FormLoaded()
            cboInsuranceIdNo.DisplayOnly = False
            cboInsuranceIdNo.EditingMode = True
        End Sub

        Private Sub BindInsuranceList()
            cboInsuranceIdNo.DataSource = Nothing
            cboInsuranceIdNo.DataSource = InsuranceList
            cboInsuranceIdNo.EditingMode = True
            cboInsuranceIdNo.Refresh()
        End Sub

    End Class

End Namespace