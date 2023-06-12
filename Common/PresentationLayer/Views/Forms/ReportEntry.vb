Imports System.Printing
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports System.Management
Imports AATM.Common.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class ReportEntry
        Implements IReportView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboPrintJobIdNo
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IReportView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrintJobIdNo As Int16 Implements IReportView.PrintJobIdNo
            Get
                Return cboPrintJobIdNo.GetValue()
            End Get
            Set
                cboPrintJobIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ReportName As String Implements IReportView.ReportName
            Get
                Return txtReportName.Text
            End Get
            Set
                txtReportName.Text = Value
            End Set
        End Property

        Public Property ReportCode As String Implements IReportView.ReportCode
            Get
                Return txtReportCode.Text
            End Get
            Set
                txtReportCode.Text = Value
            End Set
        End Property

        Public Property QueryForm As String Implements IReportView.QueryForm
            Get
                Return txtQueryForm.Text
            End Get
            Set
                txtQueryForm.Text = Value
            End Set
        End Property

        Public Property QueryFormParameters As String Implements IReportView.QueryFormParameters
            Get
                Return txtQueryFormParameters.Text
            End Get
            Set
                txtQueryFormParameters.Text = Value
            End Set
        End Property

        Public Property QueryParameters As String Implements IReportView.QueryParameters
            Get
                Return txtQueryParameters.Text
            End Get
            Set
                txtQueryParameters.Text = Value
            End Set
        End Property

        Public Property ReportFileName As String Implements IReportView.ReportFileName
            Get
                Return txtReportFileName.Text
            End Get
            Set
                txtReportFileName.Text = Value
            End Set
        End Property

        Public Property ReportGroup As String Implements IReportView.ReportGroup
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ReportNameAra As String Implements IReportView.ReportNameAra
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ReportTitle As String Implements IReportView.ReportTitle
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property ReportTitleAra As String Implements IReportView.ReportTitleAra
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"ReportName", txtReportName},
                {"ReportCode", txtReportCode},
                {"QueryForm", txtQueryForm},
                {"QueryFormParameters", txtQueryFormParameters},
                {"ReportTitle", txtReportTitle},
                {"IdNo", txtIdNo}
                }
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