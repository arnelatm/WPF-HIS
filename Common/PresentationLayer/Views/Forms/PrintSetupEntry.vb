Imports System.Printing
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Management

Namespace PresentationLayer.Views.Forms

    Public Class PrintSetupEntryTv
        Implements IPrintSetupView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboPrintJobIdNo
            ' Add any initialization after the InitializeComponent() call.
        End Sub

        Public Event PrinterChanged(sender As Object) Implements IPrintSetupView.PrinterChanged

#Region "Fields"

        Public Property IdNo As Int16 Implements IPrintSetupView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrintJobIdNo As Int16 Implements IPrintSetupView.PrintJobIdNo
            Get
                Return cboPrintJobIdNo.GetValue()
            End Get
            Set
                cboPrintJobIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ComputerIdNo As Int16 Implements IPrintSetupView.ComputerIdNo
            Get
                Return cboComputerIdNo.GetValue()
            End Get
            Set
                cboComputerIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PaperSize As Int16 Implements IPrintSetupView.PaperSize
            Get
                Return cboPaperSize.GetValue()
            End Get
            Set
                cboPaperSize.SetValue(Value)
            End Set
        End Property

        Public Property PaperSource As Int16 Implements IPrintSetupView.PaperSource
            Get
                Return cboPaperSource.GetValue()
            End Get
            Set
                cboPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property PrinterIdNo As Int16 Implements IPrintSetupView.PrinterIdNo
            Get
                Return cboPrinterIdNo.GetValue()
            End Get
            Set
                cboPrinterIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PaperOrientation As Int16 Implements IPrintSetupView.PaperOrientation
            Get
                Return cboPaperOrientation.GetValue()
            End Get
            Set
                cboPaperOrientation.SetValue(Value)
            End Set
        End Property

        Public Property PrintSetupName As String Implements IPrintSetupView.PrintSetupName
            Get
                Return txtPrintSetupName.Text
            End Get
            Set
                txtPrintSetupName.Text = Value
            End Set
        End Property

        Public Property PrintSetupCode As String Implements IPrintSetupView.PrintSetupCode
            Get
                Return txtPrintSetupCode.Text
            End Get
            Set
                txtPrintSetupCode.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"ComputerIdNo", cboComputerIdNo},
                {"IdNo", TxtIdNo},
                {"PaperOrientation", cboPaperOrientation},
                {"PaperSize", cboPaperSize},
                {"PaperSource", cboPaperSource},
                {"PrinterIdNo", cboPrinterIdNo},
                {"PrintJobIdNo", cboPrintJobIdNo}
                }
        End Sub

        Private Sub cboPrinterName_TextChanged(sender As Object, e As EventArgs) Handles cboPrinterIdNo.TextChanged
            RaiseEvent PrinterChanged(Me)
        End Sub


        'Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrinters.ClickButtonArea
        '    'Dim myForm = New CListSelector(btnPrinters, GetInstalledPrinters())
        '    Dim printersQueue As PrintQueueCollection = GlobalFunctions.GetNetworkPrinters()
        '    Dim printers As New ArrayList
        '    Dim ComputerIdNo As String = Environment.MachineName
        '    For Each item As PrintQueue In printersQueue
        '        'if item.sharename is nothing orelse (item.sharename = "") then
        '        '    printers.add(item.name)
        '        'else
        '        '    if item.hostingprintserver.name <> "\\" + ComputerIdNo then
        '        '        printers.add(item.hostingprintserver.name + "\" + item.sharename)
        '        'else
        '        printers.Add(item.Name + " | " + item.QueuePort.Name)
        '        'end if
        '        'end if
        '    Next
        '    Dim myForm = New CListSelector(btnPrinters, printers)
        '    myForm.Show()
        'End Sub

        'Private Function GetNetPrinters() As ArrayList
        '    ' Use the ObjectQuery to get the list of configured printers
        '    Dim printers As New ArrayList
        '    Dim oQuery As System.Management.ObjectQuery = New System.Management.ObjectQuery("SELECT * FROM Win32_Printer")

        '    Dim moSearcher As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(oQuery)

        '    Dim moc As System.Management.ManagementObjectCollection = moSearcher.Get()

        '    For Each mo As ManagementObject In moc
        '        Dim pdc As System.Management.PropertyDataCollection = mo.Properties
        '        For Each pd As System.Management.PropertyData In pdc
        '            If CBool(mo("Network")) Then
        '                printers.Add(mo(pd.Name))
        '            End If
        '        Next pd
        '    Next mo
        '    Return printers
        'End Function

        'Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrinters.ClickButtonArea
        '    'Dim myForm = New CListSelector(btnPrinters, GetInstalledPrinters())
        '    Dim queue As PrintQueueCollection = GlobalFunctions.GetNetworkPrinters()
        '    Dim printers As New ArrayList
        '    Dim ComputerIdNo As String = Environment.MachineName
        '    For Each item In queue
        '        printers.Add(item.Name + ":" + item.QueuePort.Name)
        '        'If item.ShareName Is Nothing OrElse (item.ShareName = "") Then
        '        '    printers.Add(item.Name)
        '        'Else
        '        '    If item.HostingPrintServer.Name <> "\\" + ComputerIdNo Then
        '        '        printers.Add(item.HostingPrintServer.Name + "\" + item.ShareName)
        '        '    Else
        '        '        printers.Add(item.Name)
        '        '    End If
        '        'End If
        '    Next
        '    Dim myForm = New CListSelector(btnPrinters, printers)
        '    myForm.Show()
        'End Sub

    End Class

End Namespace