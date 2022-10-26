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
                Return cboPrinterName.Text
            End Get
            Set
                cboPrinterName.Text = Value
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
                {"PrinterName", cboPrinterName},
                {"PrintJobName", cboPrintJobName}
                }
        End Sub

        'Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrinters.ClickButtonArea
        '    'Dim myForm = New CListSelector(btnPrinters, GetInstalledPrinters())
        '    Dim printersQueue As PrintQueueCollection = GlobalFunctions.GetNetworkPrinters()
        '    Dim printers As New ArrayList
        '    Dim computername As String = Environment.MachineName
        '    For Each item As PrintQueue In printersQueue
        '        'if item.sharename is nothing orelse (item.sharename = "") then
        '        '    printers.add(item.name)
        '        'else
        '        '    if item.hostingprintserver.name <> "\\" + computername then
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
        '    Dim computername As String = Environment.MachineName
        '    For Each item In queue
        '        printers.Add(item.Name + ":" + item.QueuePort.Name)
        '        'If item.ShareName Is Nothing OrElse (item.ShareName = "") Then
        '        '    printers.Add(item.Name)
        '        'Else
        '        '    If item.HostingPrintServer.Name <> "\\" + computername Then
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