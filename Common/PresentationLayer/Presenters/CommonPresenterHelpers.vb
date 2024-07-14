Imports System.Drawing.Printing
Imports System.Globalization
Imports AATM.Common.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms
Imports AATM.ServicesLayer.Services
Imports CrystalDecisions.Shared

Public Enum DataTypeSelection
    BooleanType = 0
    ByteType = 1
    CharType = 2
    DateType = 3
    DecimalType = 4
    DoubleType = 5
    IntegerType = 6
    LongType = 7
    ObjectType = 8
    SByteType = 9
    ShortType = 10
    SingleType = 11
    StringType = 12
    UIntegerType = 13
    ULongType = 14
    UserDefinedType = 15
    UShortType = 16
End Enum

Public Class DataTableLookupSpec
    Public Property TableName As String
    Public Property LuFields As String
    Public Property SortKey As String
    Public Property Filter As String
    Public Property ValueMember As String
    Public Property DisplayMember As String
    Public Property DataView As DataView
    Public Property NameField As String
    Public Property NameFieldOrig As String
    Public Property NameDisplayValue As String
    Public Property LookUpTask As Task(Of DataTable)
    Public Property DvLookUpTask As Task(Of DataView)
    Public Property Data As DataTable
    Public Property NameFieldToUse As String
    Public Property Ascending As Boolean
End Class

Public Class DataLookupSpecs
    Inherits DataTableLookupSpec

    Public Property PropertyControl As CtComboBox
    Public Property PropertyName As String

End Class

Public Class DataCreator

    Private Shared _sv As Service

    Public Sub New(svc As Service)
        _sv = svc
    End Sub

    Public Function CreateDataTable(dtl As DataLookupSpecs) As DataTable
        Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
    End Function

    Public Function CreateDataTable(dtl As DataTableLookupSpec) As DataTable
        Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
    End Function

End Class

Public Class DataViewCreator

    Private Shared _sv As Service

    Public Sub New(svc As Service)
        _sv = svc
    End Sub

    Public Function CreateDataView(dtl As DataLookupSpecs) As DataView
        Dim dt As DataTable = _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
        Dim dv As DataView
        dv = dt.DefaultView
        Return dv
    End Function

End Class

Public Class ReportPrinter
    Implements IDisposable


    Dim transactionAmountInWords As String
    Dim totalLineAmountInWords As String
    Dim currencies As New List(Of CurrencyInfo)()
    Dim curCulture = CultureInfo.CurrentCulture
    Private _crReport As CrystalReportPrinter
    Private Shared _sv As Service
    Private _printJobService = New CommonService("PrintJob")
    Private _printSetupService = New CommonService("PrintSetup")
    Private _printerService = New CommonService("Printer")
    Private _reportArgs As New CrPrintableArgs
    Private _reportTitle As String = ""
    Private disposedValue As Boolean

    Public Sub New(reportFileName As String, dataBaseConnectionName As String, cCultureInfo As CultureInfo, crPrintableArgs As CrPrintableArgs)
        Language = Left(cCultureInfo.Name, cCultureInfo.Name.IndexOf("-", StringComparison.Ordinal))
        Me.ReportFileName = reportFileName
        Me.DataBaseConnectionName = dataBaseConnectionName
        Me.CReportPrintableArgs = crPrintableArgs
        Me.ReportParameters = crPrintableArgs.ReportParameters
        Me.curCulture = cCultureInfo
        crPrintableArgs.ReportFileName = reportFileName
        crPrintableArgs.CultureInfo = Language
        crPrintableArgs.DataBaseConnectionName = dataBaseConnectionName
        crPrintableArgs.Language = Language
        crPrintableArgs.ReportParameters = ReportParameters
    End Sub

    Public Property Language As String
    Public ReadOnly Property ReportName As String
    Public ReadOnly Property ReportParameters As Object
    Public ReadOnly Property ReportFileName As String
    Public ReadOnly Property DataBaseConnectionName As String
    Public ReadOnly Property CReportPrintableArgs As CrPrintableArgs

    Public Sub ShowReport()
        _crReport = GetReport()

        Dim CrViewer As New CrViewer(ReportFileName, CReportPrintableArgs, False, _crReport)
        CrViewer.Show()

    End Sub

    Public Function GetReport() As CrystalReportPrinter
        Dim printer As PrinterModel = Nothing
        Dim printJobIdNo As Int16 = GetPrintJobIdNo()
        Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(printJobIdNo)
        Dim psModel As New PrintSetupModel
        If printSetupIdNo <> 0 Then
            psModel = _printSetupService.GetRecordByIdNo(Of PrintSetupModel)(printSetupIdNo)
            If psModel IsNot Nothing Then
                printer = _printerService.GetRecordByIdNo(Of PrinterModel)(psModel.PrinterIdNo)
                printer.PaperSize = IIf(psModel.PaperSize <> 0, psModel.PaperSize, printer.PaperSize)
                printer.PaperOrientation = IIf(psModel.PaperOrientation <> 0, psModel.PaperOrientation, printer.PaperOrientation)
                printer.PaperSource = IIf(psModel.PaperSource <> 0, psModel.PaperSource, printer.PaperSource)
            Else
                Dim pjModel As New PrintJobModel
                pjModel = _printJobService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
                If pjModel IsNot Nothing Then
                    printer = _printerService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                    printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                    printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                    printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
                Else
                    printer.PrinterName = Nothing
                End If
            End If
        Else
            Dim pjModel As New PrintJobModel
            pjModel = _printJobService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
            If pjModel.IdNo <> 0 Then
                printer = _printerService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
            Else
                printer = GetDefaultPrinter()
            End If
        End If
        If printer IsNot Nothing Then
            '_reportArgs.ReportFileName = ReportFileName
            '_reportArgs.DataBaseConnectionName = DataBaseConnectionName
            '_reportArgs.CultureInfo = curCulture
            '_reportArgs.Language = Language
            '_report
            'Dim reportParameters As Object = CReportPrintableArgs
            Dim crReport As New CrystalReportPrinter(ReportFileName, DataBaseConnectionName, ReportParameters)
            crReport.Args = ReportParameters
            crReport.SetPrintOption(printer.PrinterName, printer.PaperSize, printer.PaperOrientation, printer.PaperSource)
            Return crReport
        End If
        Return Nothing
    End Function


    Private Function GetPrintSetupIdNo(printJobIdNo As Int16) As Int16
        Dim computerName As String = Environment.MachineName
        Dim computerIdNo As Int16 = _printSetupService.GetRecordFieldWithKeyG(Of Int16)(computerName, "Computer", "ComputerName", "IdNo")
        Return _printSetupService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo")
    End Function

    Private Function GetPrintJobIdNo() As Int16
        Return _printSetupService.GetRecordFieldWithKeyG(Of Int16, String)(ReportFileName, "Report", "ReportFileName", "PrintJobIdNo")
    End Function

    Private Function GetDefaultPrinter() As PrinterModel
        Dim defaultPrinter = New PrinterModel
        Dim settings As New PrinterSettings()
        defaultPrinter.PrinterName = settings.PrinterName
        defaultPrinter.PaperSize = settings.DefaultPageSettings.PaperSize.RawKind
        defaultPrinter.PaperOrientation = PaperOrientation.DefaultPaperOrientation
        defaultPrinter.HostOrIpName = Environment.MachineName
        Return defaultPrinter
    End Function


    ''Dim nav As XPathNavigator = MainDataSource.CreateNavigator()
    'Dim printlist As String = ""
    'Dim defaultPrinter As String = ""

    '    'Dim CurrentUser As String
    '    'Dim frmUser As String

    '    'If the form user field has not been filled in ie first time used get the printers and default printer.

    '    frmUser = nav.SelectSingleNode("//my:Username", NamespaceManager).Value
    '    If frmUser = "" Then

    ''Test each Printer, don't add the one's to the list that we know about. CutePDF etc...
    'For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
    'Dim p As New System.Drawing.Printing.PrinterSettings()
    '            p.PrinterName = printer
    '            If p.IsDefaultPrinter Then
    '                defaultPrinter = printer

    '                'msgbox for testing only...
    '                'MsgBox(defaultPrinter)
    '            Else
    'Select Case printer
    'Case "Microsoft XPS Document Writer"
    '                            'Do Nothing...
    'Case "CutePDF Writer"
    '                            'Do Nothing...
    'Case "Adobe PDF"
    '                            'Do Nothing...
    'Case "Fax"
    '                            'Do Nothing
    'Case "Microsoft Office Document Image Writer"
    '                            'Do Nothing
    'Case "HP Officejet Pro K850 Series"
    ''Do Nothing
    'Case Else
    '                        'Add the printer to the variable'
    '                        printlist = printlist & printer & vbCrLf
    '                End Select
    '            End If
    '        Next printer
    '        'Add the Final Result to the Text boxes in the form.
    '        nav.SelectSingleNode("//my:DefaultPrinter", NamespaceManager).SetValue(defaultPrinter)
    '        nav.SelectSingleNode("//my:PrinterList", NamespaceManager).SetValue(printlist)
    '    End If
    'End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
                '    printJobService.Dispose()
                '    printerService.Dispose()
                '    printSetupService.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub



End Class