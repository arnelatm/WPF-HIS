Imports System.Drawing.Printing
Imports System.Runtime.InteropServices.ComTypes
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PrinterEntryTv
        Implements IPrinterView

        Public Event CheckPrinterClicked(sender As Object) Implements IPrinterView.CheckPrinterClicked

        Public Event PrinterChanged(sender As Object) Implements IPrinterView.PrinterChanged

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboPrinterName
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
                Return cboPrinterName.Text
            End Get
            Set
                cboPrinterName.Text = Value
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

        Public Property PaperSize As Int16 Implements IPrinterView.PaperSize
            Get
                Return cboPaperSize.GetValue(Of Int16)
            End Get
            Set
                cboPaperSize.SetValue(Value)
            End Set
        End Property

        Public Property PaperSource As Integer Implements IPrinterView.PaperSource
            Get
                Return cboPaperSource.GetValue(Of Integer)
            End Get
            Set
                cboPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property PaperOrientation As Int16 Implements IPrinterView.PaperOrientation
            Get
                Return cboPaperOrientation.GetValue(Of Int16)
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
                {"PaperOrientation", cboPaperOrientation},
                {"PaperSize", cboPaperSize},
                {"PaperSource", cboPaperSource},
                {"PrinterCode", txtPrinterCode},
                {"PrinterName", cboPrinterName}
                }
        End Sub

        Private Sub BtnCheckPrinter_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCheckPrinter.ClickButtonArea
            RaiseEvent CheckPrinterClicked(Me)
        End Sub

        Private Sub cboPrinterName_TextChanged(sender As Object, e As EventArgs) Handles cboPrinterName.SelectionChangeCommitted
            RaiseEvent PrinterChanged(Me)
        End Sub

    End Class

End Namespace