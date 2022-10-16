Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PrintJobEntryTv
        Implements IPrintJobView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboPrintJobName
            ' Add any initialization after the InitializeComponent() call.
        End Sub

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
                Return cboPrintJobName.GetValue()
            End Get
            Set
                cboPrintJobName.SetValue(Value)
            End Set
        End Property

        Public Property ComputerName As String Implements IPrintJobView.ComputerName
            Get
                Return cboComputerName.GetValue()
            End Get
            Set
                cboComputerName.SetValue(Value)
            End Set
        End Property

        Public Property PaperSize As Int32? Implements IPrintJobView.PaperSize
            Get
                Return cboPaperSize.GetValue()
            End Get
            Set
                cboPaperSize.SetValue(Value)
            End Set
        End Property

        Public Property PaperSource As Int16? Implements IPrintJobView.PaperSource
            Get
                Return cboPaperSource.GetValue()
            End Get
            Set
                cboPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property PrinterName As String Implements IPrintJobView.PrinterName
            Get
                Return cboPrinterName.GetValue()
            End Get
            Set
                cboPrinterName.SetValue(Value)
            End Set
        End Property

        Public Property PaperOrientation As Int16? Implements IPrintJobView.PaperOrientation
            Get
                Return cboPaperOrientation.GetValue()
            End Get
            Set
                cboPaperOrientation.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"ComputerName", cboComputerName},
                {"IdNo", TxtIdNo},
                {"PaperOrientation", cboPaperOrientation},
                {"PaperSize", cboPaperSize},
                {"PaperSource", cboPaperSource},
                {"PrinterName", cboPrinterName},
                {"PrintJobName", cboPrintJobName}
                }
        End Sub

    End Class

End Namespace