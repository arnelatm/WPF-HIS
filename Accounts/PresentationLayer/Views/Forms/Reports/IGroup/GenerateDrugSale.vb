Imports System.Globalization
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services
Imports Microsoft.Office.Interop

Namespace PresentationLayer.Views.Forms.Reports

    Public Class GenerateDrugSale

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Private _service As New Service

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "DrugSale"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Dim today = Now()
            dtpSaleDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
        End Sub

        Private Sub BtnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            GenerateCsvFile(dtpSaleDate.Value)
        End Sub

        Private Sub BtnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Public Sub GenerateCsvFile(saleDate As Date)
            Dim fileName = "DrugSale for " + Year(saleDate).ToString() + Strings.Right("0" + Month(saleDate).ToString().Trim(), 2) + ".csv"
            Dim csvFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & fileName 'Path to create or existing file
            Try

                Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFilePath, False)
                Dim sortKey As String = "IdNo"
                Dim fieldList As String = $"GTIN,SerializationNo,BatchNo,Expiry"
                _service.DataDao = New DrugSaleDao
                Dim drugSales As Object = _service.GetSpRecords("fnGetDrugSaleCsv", fieldList, sortKey, "'" + saleDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture) + "'")
                outFile.WriteLine($"GTIN;SN;BN;XD")
                Dim fieldCount As Integer = 11
                Dim i As Int32 = 0
                Dim lineText As String = ""
                Dim lineNumber As Int32 = 2
                Dim errors As String = ""
                Dim errorNumber As Int32 = 0
                Dim netPay As Decimal = 0
                For Each item In drugSales
                    'Debugger.Break()
                    'lineText = item(i) ' + ";" + item.SerializationNo + ";" + item.BatchNo + ";" + item.SaleDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    'outFile.WriteLine(lineText)
                    If i = 4 Then
                        outFile.WriteLine(lineText)
                        lineText = item.ToString()
                        i = 0
                    Else
                        If TypeOf item Is Date Then
                            'Dim x = 1
                            lineText += ";" + Format(item, "dd/MM/yyyy")
                        Else
                            If i = 0 Then
                                lineText = item.ToString()
                            Else
                                lineText += ";" & item.ToString()
                            End If

                        End If

                    End If
                    i += 1
                Next
                outFile.WriteLine(lineText)
                outFile.Close()
                Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFilePath))
                If IO.File.Exists(csvFilePath) Then
                    OpenInExcel(csvFilePath)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Sub

        Private Sub OpenInExcel(pathFileName As String)
            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing
            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(pathFileName)
            xlApp.Visible = True
            xlWorkSheets = xlWorkBook.Sheets
            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)
                If xlWorkSheet.Name = pathFileName Then
                    Console.WriteLine(pathFileName)
                    Exit For
                End If
                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing
            Next
        End Sub

    End Class

End Namespace