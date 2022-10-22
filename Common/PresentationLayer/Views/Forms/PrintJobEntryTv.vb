Imports System.Printing
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.CBaseControlsLibrary
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

        Public Property PrintJobName As Int32? Implements IPrintJobView.PrintJobName
            Get
                Return cboPrintJobName.GetValue()
            End Get
            Set
                cboPrintJobName.SetValue(Value)
            End Set
        End Property

        Public Property ComputerName As String Implements IPrintJobView.ComputerName
            Get
                Return txtComputerName.Text
            End Get
            Set
                txtComputerName.Text = Value
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

        Public Property PaperSource As Int32? Implements IPrintJobView.PaperSource
            Get
                Return cboPaperSource.GetValue()
            End Get
            Set
                cboPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property PrinterName As String Implements IPrintJobView.PrinterName
            Get
                Return txtPrinterName.Text
            End Get
            Set
                txtPrinterName.Text = Value
            End Set
        End Property

        Public Property PaperOrientation As Int32? Implements IPrintJobView.PaperOrientation
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
                {"ComputerName", txtComputerName},
                {"IdNo", TxtIdNo},
                {"PaperOrientation", cboPaperOrientation},
                {"PaperSize", cboPaperSize},
                {"PaperSource", cboPaperSource},
                {"PrinterName", txtPrinterName},
                {"PrintJobName", cboPrintJobName}
                }
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrinters.ClickButtonArea
            'Dim myForm = New CListSelector(btnPrinters, GetInstalledPrinters())
            Dim queue As PrintQueueCollection = GlobalFunctions.GetNetworkPrinters()
            Dim printers As New ArrayList
            For Each item In queue
                If item.ShareName Is Nothing Or item.ShareName = "" Then
                    printers.Add(item.Name)
                Else
                    printers.Add(item.ShareName)
                End If
            Next
            Dim myForm = New CListSelector(btnPrinters, printers)
            myForm.Show()
        End Sub

    End Class

End Namespace