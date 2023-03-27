Imports System.Drawing.Printing
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PrintJobPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrintJobView, TM)

        Public Sub New(view As IPrintJobView)
            MyBase.New(view)

            Service = New CommonService("PrintJob")
            TableName = "PrintJob"
            TreeViewMainField = "PrintJobName"
            SortOrderKey = "PrintJobName"
            AddHandler view.PrinterChanged, AddressOf UpdatePrinterDataSource
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Printer", "PrinterIdNo")
            CreateDataSourceGroupCode("PaperOrientation", "PPOR")
        End Sub

        'Private Sub SetInstalledPrinter()
        '    Dim data As New List(Of Lookup.LookupData)
        '    ' Find all printers installed
        '    Dim index As Int16 = 0
        '    For Each item In PrinterSettings.InstalledPrinters
        '        Dim dbLookup = New Lookup.LookupData
        '        dbLookup.IdNo = index
        '        dbLookup.Name = item
        '        dbLookup.Code = item
        '        dbLookup.Index = index
        '        data.Add(dbLookup)
        '        index += 1
        '    Next
        '    Dim oldData = GetControlName("PrinterName").DataSource
        '    GetControlName("PrinterName").DataSource = data
        'End Sub

        Private Sub UpdatePrinterDataSource()
            Dim printerName As String = GetFieldWithIdNo(View.printerIdNo,"Printer","PrinterName")
            If IsPrinterValid(printerName) Then               
                SetPrinterSupportedPaper(printerName)
                SetPrinterSupportedSources(printerName)
            End If
        End Sub

        Private Sub SetPrinterSupportedPaper(pPrinterName As String)
            Dim data = GetPrinterPageInfo(pPrinterName)
            Dim paperSizeLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            If data.PrinterSettings.IsValid() Then
                For Each item As PaperSize In data.PrinterSettings.PaperSizes
                    Dim dbLookup = New Lookup.LookupData
                    dbLookup.IdNo = item.RawKind
                    dbLookup.Name = item.PaperName
                    dbLookup.Code = item.Kind
                    dbLookup.Index = index
                    paperSizeLookup.Add(dbLookup)
                    index += 1
                Next
                Dim savedDefaultPaperSize As Int32? = View.PaperSize
                GetControlName("PaperSize").DataSource = paperSizeLookup
                View.PaperSize = savedDefaultPaperSize
                If savedDefaultPaperSize Is Nothing Or savedDefaultPaperSize = 0 Then
                    View.PaperSize = data.PrinterSettings.DefaultPageSettings.PaperSize.RawKind
                End If
            End If
        End Sub

        Private Sub SetPrinterSupportedSources(pPrinterName As String)
            Dim data = GlobalFunctions.GetPrinterPageInfo(pPrinterName)
            Dim paperSourceLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            For Each item As PaperSource In data.PrinterSettings.PaperSources
                Dim dbLookup = New Lookup.LookupData
                dbLookup.IdNo = item.RawKind
                dbLookup.Name = item.SourceName
                dbLookup.Code = item.Kind
                dbLookup.Index = index
                paperSourceLookup.Add(dbLookup)
                index += 1
            Next
            Dim savedPaperSource As Int32? = View.PaperSource
            GetControlName("PaperSource").DataSource = paperSourceLookup
            View.PaperSource = savedPaperSource
            If savedPaperSource Is Nothing Or savedPaperSource = 0 Then
                View.PaperSource = data.PrinterSettings.DefaultPageSettings.PaperSource.RawKind
            End If
        End Sub

        'Private Sub SetInstalledPrinter()
        '    Dim data As New List(Of Lookup.LookupData)
        '    ' Find all printers installed
        '    Dim index As Int16 = 0
        '    For Each item In PrinterSettings.InstalledPrinters
        '        Dim dbLookup = New Lookup.LookupData
        '        dbLookup.IdNo = index
        '        dbLookup.Name = item
        '        dbLookup.Code = item
        '        dbLookup.Index = index
        '        data.Add(dbLookup)
        '        index += 1
        '    Next
        '    Dim oldData = GetControlName("PrinterIdNo").DataSource
        '    GetControlName("PrinterIdNo").DataSource = data
        'End Sub

        Private Function GetInstalledPrinters()
            Dim sPrinters As New ArrayList
            For Each printer In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                sPrinters.Add(printer)
            Next
            Return sPrinters
        End Function


    End Class

End Namespace