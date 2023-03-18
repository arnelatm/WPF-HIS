Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class DosageEntryTv
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

        Public Property Dose As Decimal Implements IDosageView.Dose
            Get
                Return NumParser(Of Decimal)(txtDose.Text)
            End Get
            Set
                txtDose.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property DosageUnit As Int32 Implements IDosageView.DosageUnit
            Get
                Return cboDosageUnit.GetValue()
            End Get
            Set
                cboDosageUnit.SetValue(Value)
            End Set
        End Property

        Public Property Route As Int32 Implements IDosageView.Route
            Get
                Return cboRoute.GetValue()
            End Get
            Set
                cboRoute.SetValue(Value)
            End Set
        End Property

        Public Property Direction As Int32 Implements IDosageView.Direction
            Get
                Return cboDirection.GetValue()
            End Get
            Set
                cboDirection.SetValue(Value)
            End Set
        End Property

        Public Property Frequency As Int32 Implements IDosageView.Frequency
            Get
                Return cboFrequency.GetValue()
            End Get
            Set
                cboFrequency.SetValue(Value)
            End Set
        End Property

        Public Property FrequencyTiming As Int32 Implements IDosageView.FrequencyTiming
            Get
                Return cboFrequencyTiming.GetValue()
            End Get
            Set
                cboFrequencyTiming.SetValue(Value)
            End Set
        End Property

        Public Property Duration As Int32 Implements IDosageView.Duration
            Get
                Return txtDuration.Text
            End Get
            Set
                txtDuration.Text = Value
            End Set
        End Property

        Public Property DurationTiming As Int32 Implements IDosageView.DurationTiming
            Get
                Return cboDurationTiming.GetValue()
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
                Return txtDosageName.Text
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
                {"Direction", cboDirection},
                {"Dose", txtDose},
                {"DosageUnit", cboDosageUnit},
                {"Duration", txtDuration},
                {"DurationTiming", cboDurationTiming},
                {"Frequency", cboFrequency},
                {"FrequencyTiming", cboFrequencyTiming},
                {"IdNo", txtIdNo},
                {"Route", cboRoute}
                }
        End Sub


    End Class

End Namespace