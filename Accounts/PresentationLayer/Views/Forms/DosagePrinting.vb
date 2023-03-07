Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class DosagePrinting
        Implements IDosagePrintView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            Presenter = New ReportPresenter(Me)
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            HideNavigatorButtons = True
            Text = Messaging.TranslateCaption("Check Disbursement Journal")
            btnPrintCheck.Visible = True
            _nfi.NumberDecimalDigits = 2

        End Sub

        Public Property Dosage As String Implements IDosagePrintView.Dosage
            Get
                Return txtDosage.Text
            End Get
            Set(value As String)
                txtDosage.Text = value
            End Set
        End Property

        Public Property DosageUnit As String Implements IDosagePrintView.DosageUnit
            Get
                Return cboDosageUnit.GetValue()
            End Get
            Set
                cboDosageUnit.SetValue(Value)
            End Set
        End Property

        Public Property Route As String Implements IDosagePrintView.Route
            Get
                Return cboRoute.GetValue()
            End Get
            Set
                cboRoute.SetValue(Value)
            End Set
        End Property

        Public Property Direction As String Implements IDosagePrintView.Direction
            Get
                Return cboDirection.GetValue()
            End Get
            Set
                cboDirection.SetValue(Value)
            End Set
        End Property

        Public Property Frequency As String Implements IDosagePrintView.Frequency
            Get
                Return cboFrequency.GetValue()
            End Get
            Set
                cboFrequency.SetValue(Value)
            End Set
        End Property

        Public Property FrequencyTiming As String Implements IDosagePrintView.FrequencyTiming
            Get
                Return cboFrequencyTiming.GetValue()
            End Get
            Set
                cboFrequencyTiming.SetValue(Value)
            End Set
        End Property

        Public Property Duration As String Implements IDosagePrintView.Duration
            Get
                Return txtDuration.Text
            End Get
            Set
                txtDuration.Text = Value
            End Set
        End Property

        Public Property DurationUnit As String Implements IDosagePrintView.DurationUnit
            Get
                Return cboDurationUnit.GetValue()
            End Get
            Set
                cboDurationUnit.SetValue(Value)
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
                {"Direction", cboDirection},
                {"DosageUnit", cboDosageUnit},
                {"DurationUnit", cboDurationUnit},
                {"Frequency", cboFrequency},
                {"FrequencyTiming", cboFrequencyTiming},
                {"Route", cboRoute},
                {"Dosage", txtDosage},
                {"Duration", txtDuration},
                {"DurationTiming", cboDurationUnit}
                }
        End Sub

    End Class

End Namespace