Imports System.Data.Common
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports Telerik.WinControls.VirtualKeyboard

Namespace PresentationLayer.Views.Forms

    Public Class LabReportStatusForm
        Implements ILabReportStatusView

        Private _doctorId As String
        Private _dataAccessLevel As String = ""
        Private _connectionName As String = "Kizen"

        Public Event LabReportStatusRequested(transactionDate As Int32) Implements ILabReportStatusView.LabReportStatusRequested

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            SingleData = True
            QueryOnly = True
            DisplaySetup()
        End Sub

        Private Sub DisplaySetup()
            dtpInvoiceDate.Value = Today()
        End Sub

        Public Property InvoiceDate As Date Implements ILabReportStatusView.InvoiceDate
            Get
                Return dtpInvoiceDate.Value
            End Get
            Set(value As Date)
                dtpInvoiceDate.Value = value
            End Set
        End Property

        Public Property PatientName As String Implements ILabReportStatusView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set
                txtPatientName.Text = Value
            End Set
        End Property

        Public Property Gender As String Implements ILabReportStatusView.Gender
            Get
                Return txtGender.Text
            End Get
            Set
                txtGender.Text = Value
            End Set
        End Property

        Public Property Age As String Implements ILabReportStatusView.Age
            Get
                Return txtAge.Text
            End Get
            Set
                txtAge.Text = Value
            End Set
        End Property

        Public Property DoctorName As String Implements ILabReportStatusView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set
                txtDoctorName.Text = Value
            End Set
        End Property

        Public Property InvoiceNo As Integer Implements ILabReportStatusView.InvoiceNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtInvoiceNo.Text)
            End Get
            Set
                txtInvoiceNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Nationality As String Implements ILabReportStatusView.Nationality
            Get
                Return txtNationality.Text
            End Get
            Set
                txtNationality.Text = Value
            End Set
        End Property

        Public Property MRN As Integer Implements ILabReportStatusView.MRN
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtMRN.Text)
            End Get
            Set
                txtMRN.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property CollectedBy As String Implements ILabReportStatusView.CollectedBy
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property CollectedDateTime As Date Implements ILabReportStatusView.CollectedDateTime
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Date)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Completed As Boolean? Implements ILabReportStatusView.Completed
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Boolean?)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ProcessedBy As String Implements ILabReportStatusView.ProcessedBy
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ProcessedDateTime As Date Implements ILabReportStatusView.ProcessedDateTime
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Date)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ValidatedBy As String Implements ILabReportStatusView.ValidatedBy
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ValidatedDateTime As Date Implements ILabReportStatusView.ValidatedDateTime
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Date)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PatientNameMRN As String Implements ILabReportStatusView.PatientNameMRN
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent LabReportStatusRequested(InvoiceNo)
        End Sub

        Private Sub LabReportStatusCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent LabReportStatusRequested(InvoiceNo)
            'dgvClinical.ThreeState = True
            ''dgvAge.DisplayOnly = True
            'For Each col In DataGridViewLabReportStatusDetails.Columns
            '    Dim headerCell As DataGridViewColumnHeaderCell = col.HeaderCell
            '    headerCell.ToolTipText = col.HeaderText
            'Next
        End Sub

        Private Sub txtInvoiceNo_Validated(sender As Object, e As EventArgs) Handles txtInvoiceNo.Validated
            RaiseEvent LabReportStatusRequested(InvoiceNo)
        End Sub


        Protected Overrides Sub CreateMainFieldsDictionary()
            'MainFieldsDictionary = New Dictionary(Of String, Object) From
            '    {
            '    {"DoctorCode", txtDoctorCode},
            '    {"DoctorName", cboDoctorName}
            '    }
        End Sub

    End Class

End Namespace