Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class DosagePrinting
        Implements IDosageView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

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
            btnPrintCheck.Visible = True
            _nfi.NumberDecimalDigits = 2

        End Sub


        Public Property IdNo As Int32 Implements IDosageView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Dose As Decimal 
            Get
                Return NumParser(Of Decimal)(txtDose.Text)
            End Get
            Set
                txtDose.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property DosageUnit As Int32 
            Get
                Return cboDosageUnit.GetValue(Of Int32)
            End Get
            Set
                cboDosageUnit.SetValue(Value)
            End Set
        End Property

        Public Property Route As Int32 Implements IDosageView.Route

        Public Property Direction As Int32 Implements IDosageView.Direction

        Public Property Frequency As Int32 Implements IDosageView.Frequency

        Public Property FrequencyTiming As Int32 Implements IDosageView.FrequencyTiming

        Public Property Duration As Int32 
            Get
                Return txtDuration.Text
            End Get
            Set
                txtDuration.Text = Value
            End Set
        End Property

        Public Property DurationTiming As Int32
            Get
                Return cboDurationTiming.GetValue(Of Int32)
            End Get
            Set
                cboDurationTiming.SetValue(Value)
            End Set
        End Property

        Public Shadows Property DataFilter As String Implements IView.DataFilter

        Public Property DosageCode As String Implements IDosageView.DosageCode
            Get
                Return txtDosageCode.Text
            End Get
            Set(value As String)
                txtDosageCode.Text = value
            End Set
        End Property

        Public Property DosageName As String Implements IDosageView.DosageName
            Get
                Return txtDosageCode.Text 
            End Get
            Set(value As String)
                txtDosageName.Text = value
            End Set
        End Property

        Public Property DosageNameAra As String Implements IDosageView.DosageNameAra
            Get
                Return txtDosageNameAra.Text
            End Get
            Set(value As String)
                txtDosageNameAra.Text = value
            End Set
        End Property

#Region "Field Items"

#End Region

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub btnPrintCheck_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnPrintCheck.ClickButtonArea
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            Dim reportName As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            reportName = "Check Printing.Rpt"
            'Dim cForm As New ReportForm(reportName, checkAmountInWords, "CheckAmountInWords", payee, "PayeeName", dtpCheckDate.Value, "CheckDate", Convert.ToDecimal(txtAmount.Text), "CheckAmount", txtNotes.Text, "Notes", language, "Language")
            'cForm.Show()
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
        End Sub
    End Class

End Namespace