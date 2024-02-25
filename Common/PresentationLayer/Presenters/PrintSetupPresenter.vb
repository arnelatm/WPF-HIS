Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PrintSetupPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrintSetupView, TM)

        Public Sub New(view As IPrintSetupView)
            MyBase.New(view)

            Service = New CommonService("PrintSetup")
            TableName = "PrintSetup_View"
            TableBaseName = "PrintSetup"
            TreeViewMainField = "PrintSetupName"
            TreeViewSecondaryField = ""
            SortOrderKey = "PrintSetupName"
            AddHandler view.PrinterChanged, AddressOf UpdatePrinterDataSource
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"Printer", "PrinterIdNo", Nothing, Nothing},
                                    New String() {"PrintJob", "PrintJobIdNo", Nothing, Nothing},
                                    New String() {"Computer", "ComputerIdNo", Nothing, Nothing}})
        End Sub


        Private Sub UpdatePrinterDataSource()
            Dim printerName As String = GetFieldWithIdNo(View.PrinterIdNo, "Printer", "PrinterName")
            If GlobalFunctions.IsPrinterValid(printerName) Then
                SetPrinterSupportedPaperSize(printerName, View.PaperSize)
                SetPrinterSupportedSources(printerName, View.PaperSource)
                SetPrinterSupportedPaperOrientation(printerName, View.PaperOrientation)
            End If
        End Sub

    End Class

End Namespace