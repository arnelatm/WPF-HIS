Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Forms

    Public Class DosagePrintingForm
        Implements IDosagePrintingView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _shownInitialized As Boolean
        Public Event AddNewDosage() Implements IDosagePrintingView.AddNewDosage
        Public Event UpdateTree() Implements IDosagePrintingView.UpdateTree
        Public Event UpdatePatient() Implements IDosagePrintingView.UpdatePatient
        Public Event FindPatient() Implements IDosagePrintingView.FindPatient
        Public Event ItemCodeChanged() Implements IDosagePrintingView.ItemCodeChanged
        Public Event ItemNameChanged(idNo As Int32) Implements IDosagePrintingView.ItemNameChanged
        Public Event GTinChanged(cGTin As String) Implements IDosagePrintingView.GTinChanged
        Public Event BarCodeChanged(cBarCode As String) Implements IDosagePrintingView.BarCodeChanged
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
            Text = MessagingService.TranslateCaption("Dosage Printing")
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

        Public Property DoseUnit As Int32 Implements IDosagePrintingView.DoseUnit
            Get
                Return cboDoseUnit.GetValue(Of Int32)
            End Get
            Set
                cboDoseUnit.SetValue(Value)
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

        Public Property DurationUnit As Int16 Implements IDosagePrintingView.DurationUnit
            Get
                Return cboDurationUnit.GetValue(Of Int16)
            End Get
            Set
                cboDurationUnit.SetValue(Value)
            End Set
        End Property

        Public Property PatientType As Int16 Implements IDosagePrintingView.PatientType
            Get
                Return cboPatientType.GetValue(Of Int16)
            End Get
            Set
                cboPatientType.SetValue(Value)
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
                Return txtDosageName.Text
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
                Return txtFileNo.GetValue(Of Integer)
            End Get
            Set
                txtFileNo.SetValue(Value)
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

        Public Property Age As Int16 Implements IDosagePrintingView.Age
            Get
                Return txtAge.GetValue(Of Int16)
            End Get
            Set(value As Int16)
                txtAge.SetValue(value)
            End Set
        End Property

        Public Property AgeDMY As String Implements IDosagePrintingView.AgeDMY
            Get
                Return cboAgeYmd.GetValue()
            End Get
            Set(value As String)
                cboAgeYmd.SetValue(value)
            End Set
        End Property

        Public Property Gender As String Implements IDosagePrintingView.Gender
            Get
                Return cboGender.GetValue(Of String)
            End Get
            Set
                cboGender.SetValue(Value)
            End Set
        End Property

        Public Property Route As Int32 Implements IDosageView.Route

        Public Property Direction As Integer Implements IDosageView.Direction

        Public Property Frequency As Integer Implements IDosageView.Frequency

        Public Property FrequencyTiming As Integer Implements IDosageView.FrequencyTiming

        Public Property DefaultDoseUnit As Short Implements IDosagePrintingView.DefaultDoseUnit

        Public Property DefaultDurationUnit As Short Implements IDosagePrintingView.DefaultDurationUnit

        Public Property ItemCode As String Implements IDosagePrintingView.ItemCode
            Get
                Return txtItemCode.Text
            End Get
            Set
                txtItemCode.Text = Value
            End Set
        End Property

        Public Property ItemName As String Implements IDosagePrintingView.ItemName
            Get
                Return txtItemName.Text
            End Get
            Set
                txtItemName.Text = Value
            End Set
        End Property

        Public Property ItemIdNo As Int32 Implements IDosagePrintingView.ItemIdNo
            Get
                Return Nothing ' cboItemIdNo.GetValue(Of Int32)
            End Get
            Set
                cboItemIdNo.SetValue(Value)
                txtItemName.Text = DirectCast(cboItemIdNo.DataSource.Rows(cboItemIdNo.SelectedIndex()), System.Data.DataRow).Item(1)
                txtItemName.Text = Value
            End Set
        End Property

        Public Property GTin As String Implements IDosagePrintingView.GTin
            Get
                Return txtGTin.Text
            End Get
            Set
                txtGTin.Text = Value
            End Set
        End Property

        Public Property GenericName As String Implements IDosagePrintingView.GenericName
            Get
                Return txtGenericName.Text
            End Get
            Set
                txtGenericName.Text = Value
            End Set
        End Property

        Public Property BarCode As String Implements IDosagePrintingView.BarCode
            Get
                Return txtBarCode.Text
            End Get
            Set
                txtBarCode.Text = Value
            End Set
        End Property

        Public Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            SetAlwaysEditableFields()
        End Sub

        Private Sub SetAlwaysEditableFields()
            txtDose.Text = 1
            txtDuration.Text = 1
            cboDoseUnit.EditingMode = True
            cboGender.EditingMode = True
            cboDurationUnit.EditingMode = True
            cboAgeYmd.EditingMode = True
            cboGender.EditingMode = True
            cboPatientType.EditingMode = True
            txtItemCode.EditingMode = True
            txtGenericName.EditingMode = True
            txtBarCode.EditingMode = True
            txtGTin.EditingMode = True
            cboItemIdNo.EditingMode = True
            cboDoseUnit.SetValue(DefaultDoseUnit)
            cboDurationUnit.SetValue(DefaultDurationUnit)
        End Sub

#Region "Field Items"

#End Region

        Public Overloads Sub Dispose()
            Close()
        End Sub



        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Age", txtAge},
                {"AgeYmd", cboAgeYmd},
                {"BarCode", txtBarCode},
                {"ItemIdNo", cboItemIdNo},
                {"DosageCode", txtDosageCode},
                {"DosageName", txtDosageName},
                {"DosageNameAra", txtDosageNameAra},
                {"Dose", txtDose},
                {"DoseUnit", cboDoseUnit},
                {"Duration", txtDuration},
                {"DurationUnit", cboDurationUnit},
                {"FileNo", txtFileNo},
                {"Gender", cboGender},
                {"GenericName", txtGenericName},
                {"GTin", txtGTin},
                {"IdNo", txtIdNo},
                {"ItemCode", txtItemCode},
                {"ItemName", txtItemName},
                {"PatientName", txtPatientName},
                {"PatientType", cboPatientType}
                }

        End Sub

        Private Sub DosagePrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnAdd.Visible = False
            btnDelete.Visible = False
            btnFilter.Visible = False
            btnSave.Visible = False
            btnUndo.Visible = False
            btnEdit.Visible = False
            SetAlwaysEditableFields()
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            RaiseEvent AddNewDosage()
            RaiseEvent UpdateTree()
        End Sub

        Private Sub btnFindPatient_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnFindPatient.ClickButtonArea
            If _shownInitialized Then
                RaiseEvent FindPatient()
            End If
        End Sub


        Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.LostFocus
            If _shownInitialized Then
                Dim cItemCode As String = sender.Text
                If cItemCode IsNot Nothing AndAlso cItemCode <> "" Then
                    RaiseEvent ItemCodeChanged()
                End If
            End If
        End Sub

        Private Sub cboItemIdNo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboItemIdNo.SelectedValueChanged, cboItemIdNo.Leave
            If _shownInitialized Then
                Dim selectedIdNo As Int32 = cboItemIdNo.SelectedValue
                If selectedIdNo <> 0 Then
                    RaiseEvent ItemNameChanged(selectedIdNo)
                End If
            End If
            'txtItemName.Text = DirectCast(cboItemIdNo.DataSource.Rows(cboItemIdNo.SelectedIndex()), System.Data.DataRow).ItemArray(1)
        End Sub

        Private Sub txtBarCode_Leave(sender As Object, e As EventArgs) Handles txtBarCode.Leave
            If _shownInitialized Then
                Dim cBarCode As String = sender.Text
                If cBarCode IsNot Nothing AndAlso cBarCode <> "" Then
                    RaiseEvent BarCodeChanged(txtBarCode.Text)
                End If
            End If
        End Sub

        Private Sub txtGTin_Leave(sender As Object, e As EventArgs) Handles txtGTin.Leave
            If _shownInitialized Then
                ProcessGTinEntry()
            End If
        End Sub

        Private Sub btnScanQrCode_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnScanQrCode.ClickButtonArea
            If _shownInitialized Then
                Dim gTinScanner As New GTinScanner
                gTinScanner.ShowDialog()
                txtGTin.Text = gTinScanner.GTin
                gTinScanner.Close()
                ProcessGTinEntry()
            End If
        End Sub

        Private Sub ProcessGTinEntry()
            If _shownInitialized Then
                Dim cGTin As String = txtGTin.Text
                If cGTin IsNot Nothing AndAlso cGTin <> "" Then
                    RaiseEvent GTinChanged(txtGTin.Text)
                End If
            End If
        End Sub

        Private Sub btnClear_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClear.ClickButtonArea
            txtGTin.Text = ""
            txtFileNo.Text = ""
            txtDose.Text = 1
            txtDuration.Text = 1
            txtBarCode.Text = ""
            txtFileNo.Text = ""
            txtItemCode.Text = ""
            txtGenericName.Text = ""
            cboItemIdNo.SelectedIndex = -1
            cboGender.SelectedIndex = -1
            cboAgeYmd.SelectedValue = EnumToCode(YearMonthDaySelection.Year)
            txtPatientName.Text = ""
            'cboPatientType.SelectedValue = 
        End Sub
    End Class

End Namespace