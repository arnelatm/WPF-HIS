Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.Office.Core

Namespace PresentationLayer.Presenters.Views.Forms
    Public Class ContactDateRangeForm
        Implements IContactDateRangeView

        Public Event ContactDateRangeFormLoaded() Implements IContactDateRangeView.ContactDateRangeFormLoaded


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

        Private _contactDataSource As Object
        Public Property ContactDataSource As Object Implements IContactDateRangeView.ContactDataSource
            Get
                Return _contactDataSource
            End Get
            Set(value As Object)
                _contactDataSource = value
                BindContactDataSource()
            End Set
        End Property
        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Report"
            SortOrderKey = "IdNo"
            Dim today = Now()
            lblContactIdNo.Visible = True
            cboContactIdNo.Visible = True
            'dateRange.BeginningDate = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            'dateRange.EndingDate = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)


        End Sub

        Public Sub New(reportModel As ReportModel)
            MyBase.New(reportModel)
            ' This call is required by the designer.
            InitializeComponent()
            cboContactIdNo.EditingMode = False
            ' Add any initialization after the InitializeComponent() call.
            NoContact = False
        End Sub

        Private Sub DateRangeCompanyEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent ContactDateRangeFormLoaded()
            cboContactIdNo.DisplayOnly = False
            cboContactIdNo.EditingMode = True
            cboContactIdNo.DropDownHeight = 28
            cboContactIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
            cboContactIdNo.Editable = True
            cboContactIdNo.EditingMode = True
            'cboContactIdNo.DataSource = ContactDataSource
        End Sub

        Private Sub BindContactDataSource()
            cboContactIdNo.DataSource = Nothing
            cboContactIdNo.DataSource = ContactDataSource
        End Sub

    End Class

End Namespace
