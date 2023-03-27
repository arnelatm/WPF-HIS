Imports System.Printing
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Management

Namespace PresentationLayer.Views.Forms

    Public Class PrintJobEntryTv
        Implements IPrintJobView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtPrintJobName
            ' Add any initialization after the InitializeComponent() call.
        End Sub

        Public Event PrinterChanged(sender As Object) Implements IPrintJobView.PrinterChanged

#Region "Fields"

        Public Property IdNo As Int16 Implements IPrintJobView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrintJobName As String Implements IPrintJobView.PrintJobName
            Get
                Return txtPrintJobName.Text
            End Get
            Set
                txtPrintJobName.SetValue(Value)
            End Set
        End Property

        Public Property PaperSize As Int16 Implements IPrintJobView.PaperSize
            Get
                Return cboPaperSize.GetValue()
            End Get
            Set
                cboPaperSize.SetValue(Value)
            End Set
        End Property

        Public Property PaperSource As Int16 Implements IPrintJobView.PaperSource
            Get
                Return cboPaperSource.GetValue()
            End Get
            Set
                cboPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property PrinterIdNo As Int16 Implements IPrintJobView.PrinterIdNo
            Get
                Return cboPrinterIdNo.GetValue()
            End Get
            Set
                cboPrinterIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PaperOrientation As Int16 Implements IPrintJobView.PaperOrientation
            Get
                Return cboPaperOrientation.GetValue()
            End Get
            Set
                cboPaperOrientation.SetValue(Value)
            End Set
        End Property

        Public Property PrintJobNameAra As String Implements IPrintJobView.PrintJobNameAra
            Get
                Return txtPrintJobNameAra.Text
            End Get
            Set(value As String)
                txtPrintJobNameAra.SetValue(value)
            End Set
        End Property

        Public Property PrintJobCode As String Implements IPrintJobView.PrintJobCode
            Get
                Return txtPrintJobCode.Text
            End Get
            Set(value As String)
                txtPrintJobCode.SetValue(value)
            End Set
        End Property



#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IdNo", TxtIdNo},
                {"PaperOrientation", cboPaperOrientation},
                {"PaperSize", cboPaperSize},
                {"PaperSource", cboPaperSource},
                {"PrinterIdNo", cboPrinterIdNo},
                {"PrintJobName", txtPrintJobName},
                {"PrintJobNameAra", txtPrintJobNameAra}
                }
        End Sub


        Private Sub cboPrinterName_TextChanged(sender As Object, e As EventArgs) Handles cboPrinterIdNo.TextChanged
            RaiseEvent PrinterChanged(Me)
        End Sub

    End Class


End Namespace