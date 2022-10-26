Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PrinterEntryTv
        Implements IPrinterView

        Public Event CheckPrinterClicked(sender As Object) Implements IPrinterView.CheckPrinterClicked


        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtPrinterName
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPrinterView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrinterName As String Implements IPrinterView.PrinterName
            Get
                Return txtPrinterName.Text
            End Get
            Set
                txtPrinterName.Text = Value
            End Set
        End Property

        Public Property PrinterCode As String Implements IPrinterView.PrinterCode
            Get
                Return txtPrinterCode.Text
            End Get
            Set
                txtPrinterCode.Text = Value
            End Set
        End Property

        Public Property DefaultPaperSize As Int32? Implements IPrinterView.DefaultPaperSize
            Get
                Return cboPaperSize.GetValue()
            End Get
            Set
                cboPaperSize.SetValue(Value)
            End Set
        End Property

        Public Property DefaultPaperSource As Int32? Implements IPrinterView.DefaultPaperSource
            Get
                Return cboPaperSource.GetValue()
            End Get
            Set
                cboPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property DefaultPaperOrientation As Int32? Implements IPrinterView.DefaultPaperOrientation
            Get
                Return cboPaperOrientation.GetValue()
            End Get
            Set
                cboPaperOrientation.SetValue(Value)
            End Set
        End Property

        Public Property HostOrIpName As String Implements IPrinterView.HostOrIpName
            Get
                Return txtHostOrIpName.Text
            End Get
            Set(value As String)
                txtHostOrIpName.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"HostOrIpName", txtHostOrIpName},
                {"IdNo", TxtIdNo},
                {"DefaultPaperOrientation", cboPaperOrientation},
                {"DefaultPaperSize", cboPaperSize},
                {"DefaultPaperSource", cboPaperSource},
                {"PrinterCode", txtPrinterCode},
                {"PrinterName", txtPrinterName}
                }
        End Sub

        Private Sub BtnCheckPrinter_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCheckPrinter.ClickButtonArea
            RaiseEvent CheckPrinterClicked(Me)
        End Sub
    End Class

End Namespace