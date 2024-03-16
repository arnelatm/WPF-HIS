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
            MakeControlDataSources({New Object() {"Printer", "PrinterIdNo", Nothing, Nothing}})
        End Sub

        Private Sub UpdatePrinterDataSource()
            Dim printerName As String = GetFieldWithIdNo(View.printerIdNo,"Printer","PrinterName")
            If IsPrinterValid(printerName) Then               
                SetPrinterSupportedPaperSize(printerName, View.PaperSize)
                SetPrinterSupportedSources(printerName, View.PaperSource)
                SetPrinterSupportedPaperOrientation(printerName, View.PaperOrientation)
            End If
        End Sub

    End Class

End Namespace