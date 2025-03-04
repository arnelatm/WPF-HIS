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
        Public Event LabReportStatusSaved(sampleNo As Int32) Implements ILabReportStatusView.LabReportStatusSaved
        Public Event UpdatePatientNameClick(sampleNo As Int32) Implements ILabReportStatusView.LabReportStatusUpdateName

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            SingleData = True
            QueryOnly = False
        End Sub



        Public Property RequestedDateTime As String Implements ILabReportStatusView.RequestedDateTime
            Get
                Return txtRequestedDateTime.Text
            End Get
            Set
                txtRequestedDateTime.Text = Value
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

        Public Property RequestedBy As String Implements ILabReportStatusView.RequestedBy
            Get
                Return txtRequestedBy.Text
            End Get
            Set
                txtRequestedBy.Text = Value
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
                Return txtCollectedBy.Text
            End Get
            Set
                txtCollectedBy.Text = Value
            End Set
        End Property

        Public Property CollectedDateTime As DateTime? Implements ILabReportStatusView.CollectedDateTime
            Get
                Return dtpCollectedDateTime.Value
            End Get
            Set
                dtpCollectedDateTime.Value = Value
            End Set
        End Property

        Public Property Completed As Boolean? Implements ILabReportStatusView.Completed
            Get
                Return chkCompleted.Checked
            End Get
            Set
                chkCompleted.Checked = If(Value Is Nothing, False, Value)
            End Set
        End Property

        Public Property ProcessedBy As String Implements ILabReportStatusView.ProcessedBy
            Get
                Return txtProcessedBy.Text
            End Get
            Set
                txtProcessedBy.Text = Value
            End Set
        End Property

        Public Property ProcessedDateTime As DateTime? Implements ILabReportStatusView.ProcessedDateTime
            Get
                Return dtpProcessedDateTime.Value
            End Get
            Set
                dtpProcessedDateTime.Value = Value
            End Set
        End Property

        Public Property ValidatedBy As String Implements ILabReportStatusView.ValidatedBy
            Get
                Return txtValidatedBy.Text
            End Get
            Set
                txtValidatedBy.Text = Value
            End Set
        End Property

        Public Property ValidatedDateTime As DateTime? Implements ILabReportStatusView.ValidatedDateTime
            Get
                Return dtpValidatedDateTime.Value
            End Get
            Set
                dtpValidatedDateTime.Value = Value
            End Set
        End Property

        Public Property PatientNameMRN As String Implements ILabReportStatusView.PatientNameMRN
            Get
                Return txtPatientNameMRN.Text
            End Get
            Set
                txtPatientNameMRN.Text = Value
            End Set
        End Property

        Public Property SampleNo As Integer Implements ILabReportStatusView.SampleNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtSampleNo.Text)
            End Get
            Set
                txtSampleNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent LabReportStatusRequested(SampleNo)
        End Sub

        Private Sub LabReportStatusCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent LabReportStatusRequested(SampleNo)
            'dgvClinical.ThreeState = True
            ''dgvAge.DisplayOnly = True
            'For Each col In DataGridViewLabReportStatusDetails.Columns
            '    Dim headerCell As DataGridViewColumnHeaderCell = col.HeaderCell
            '    headerCell.ToolTipText = col.HeaderText
            'Next
        End Sub

        Private Sub txtSampleNo_Validated(sender As Object, e As EventArgs) Handles txtSampleNo.Validated
            RaiseEvent LabReportStatusRequested(SampleNo)
        End Sub


        Protected Overrides Sub CreateMainFieldsDictionary()
            'MainFieldsDictionary = New Dictionary(Of String, Object) From
            '    {
            '    {"DoctorCode", txtDoctorCode},
            '    {"RequestedBy", cboRequestedBy}
            '    }
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSaveStatus.ClickButtonArea
            RaiseEvent LabReportStatusSaved(SampleNo)
        End Sub

        Private Sub btnUpdateNameFromFile_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnUpdateNameFromFile.ClickButtonArea
            RaiseEvent UpdatePatientNameClick(SampleNo)
        End Sub
    End Class

End Namespace