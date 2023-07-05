Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class DosagePrinting
        Implements IDosagePrintingView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Public Event AddNewDosage() Implements IDosagePrintingView.AddNewDosage
        Public Event UpdateTree() Implements IDosagePrintingView.UpdateTree
        Public Event UpdatePatient() Implements IDosagePrintingView.UpdatePatient
        'Public Event PrintReport As IPrintReport.PrintReportEventHandler Implements IPrintReport.PrintReport

        'Public Event OnPrintReport As IPrintReportView.OnPrintReportEventHandler Implements IDosagePrintingView.PrintReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Text = Messaging.TranslateCaption("Check Disbursement Journal")
            _nfi.NumberDecimalDigits = 2

        End Sub


        Public Property IdNo As Int32 Implements IDosagePrintingView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Dose As Decimal Implements IDosagePrintingView.Dose
            Get
                Return txtDose.GetValue(Of Decimal)
            End Get
            Set
                txtDose.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property DosageUnit As Int32 Implements IDosagePrintingView.DosageUnit
            Get
                Return cboDosageUnit.GetValue(Of Int32)
            End Get
            Set
                cboDosageUnit.SetValue(Value)
            End Set
        End Property

        Public Property Duration As Decimal Implements IDosagePrintingView.Duration
            Get
                Return txtDuration.GetValue(Of Decimal)
            End Get
            Set
                txtDuration.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property DurationTiming As Decimal Implements IDosagePrintingView.DurationTiming
            Get
                Return cboDurationTiming.GetValue(Of Int32)
            End Get
            Set
                cboDurationTiming.SetValue(Value)
            End Set
        End Property

        Public Shadows Property DataFilter As String Implements IView.DataFilter

        Public Property DosageCode As String Implements IDosagePrintingView.DosageCode
            Get
                Return txtDosageCode.Text
            End Get
            Set(value As String)
                txtDosageCode.Text = value
            End Set
        End Property

        Public Property DosageName As String Implements IDosagePrintingView.DosageName
            Get
                Return txtDosageCode.Text
            End Get
            Set(value As String)
                txtDosageName.Text = value
            End Set
        End Property

        Public Property DosageNameAra As String Implements IDosagePrintingView.DosageNameAra
            Get
                Return txtDosageNameAra.Text
            End Get
            Set(value As String)
                txtDosageNameAra.Text = value
            End Set
        End Property

        Public Property FileNo As Integer Implements IDosagePrintingView.FileNo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PatientName As String Implements IDosagePrintingView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set(value As String)
                txtPatientName.Text = value
            End Set
        End Property

        Public Property Age As Short Implements IDosagePrintingView.Age
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Short)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property AgeDMY As String Implements IDosagePrintingView.AgeDMY
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Gender As String Implements IDosagePrintingView.Gender
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Route As Integer Implements IDosageView.Route
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Direction As Integer Implements IDosageView.Direction
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Frequency As Integer Implements IDosageView.Frequency
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property FrequencyTiming As Integer Implements IDosageView.FrequencyTiming
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

#Region "Field Items"

#End Region

        Public Overloads Sub Dispose()
            Close()
        End Sub



        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Dose", txtDose},
                {"DosageName", txtDosageName},
                {"DosageNameAra", txtDosageNameAra},
                {"DosageUnit", cboDosageUnit},
                {"Duration", txtDuration},
                {"DurationTiming", cboDurationTiming},
                {"IdNo", txtIdNo}
                }
        End Sub

        Private Sub DosagePrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnAdd.Visible = False
            btnDelete.Visible = False
            btnFilter.Visible = False
            btnSave.Visible = False
            btnUndo.Visible = False
            btnEdit.Visible = False
            txtDose.Text = 1
            txtDuration.Text = 1
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            RaiseEvent AddNewDosage()
            RaiseEvent UpdateTree()
        End Sub


    End Class

End Namespace