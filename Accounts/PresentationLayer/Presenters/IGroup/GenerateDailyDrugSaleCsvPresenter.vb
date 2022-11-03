' GeneralJournal business object as seen by the Service client.
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.Office.Interop

Namespace PresentationLayer.Presenters

    Public Class GenerateDailyDrugSaleCsvPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDrugSaleView, TM)

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New(view As IDrugSaleView)
            MyBase.New(view)
            Service = New AccountsService("DrugSale")
            TableName = "DrugSale"
            SortOrderKey = "IdNo"
            WithTreeView = False
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            AddHandler view.GenerateCsvFile, AddressOf OnGenerateCsvFile

        End Sub

        'Protected Overrides Sub CreateDataSources()
        '    CreateDataSource("DrugSale", "IdNo", "StartDate", Nothing)
        '    CreateDataSource("PayCycle", "PayCycleIdNo")
        'End Sub

        Public Sub OnGenerateCsvFile(saleDate As Date)
            Dim fileName = "DrugSale for " + Year(saleDate).ToString() + Strings.Right("0" + Month(saleDate).ToString().Trim(), 2) + ".csv"
            Dim csvFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & fileName 'Path to create or existing file
            Try

                Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFilePath, False)
                Dim sortKey As String = "IdNo"
                Dim fieldList As String = $"GTIN,SerializationNo,BatchNo,Expiry"
                Dim drugSales As Object = Service.GetSpRecords("fnGetDrugSaleCsv", fieldList, sortKey, "'" + saleDate.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture) + "'")
                outFile.WriteLine($"GTIN;SN;BN;XD")
                Dim fieldCount As Integer = 11
                Dim i As Int32 = 0
                Dim lineText As String = ""
                Dim lineNumber As Int32 = 2
                Dim errors As String = ""
                Dim errorNumber As Int32 = 0
                Dim netPay As Decimal = 0
                For Each item In drugSales
                    Debugger.Break()
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
                    'Select Case i + 1
                    '    Case 1
                    '        If item Is Nothing Or item.ToString() = "" Then
                    '            errorNumber += 1
                    '            errors += errorNumber.ToString() + ". Invalid Bank Code for line number " + lineNumber.ToString() + "." + Environment.NewLine
                    '        End If
                    '    Case 2
                    '        If item Is Nothing Or item.ToString() = "" Then
                    '            errorNumber += 1
                    '            errors += errorNumber.ToString() + ". Missing IBAN Number for line number " + lineNumber.ToString() + "." + Environment.NewLine
                    '        ElseIf Trim(item.ToString()).Length <> 24 Then
                    '            errorNumber += 1
                    '            errors += errorNumber.ToString() + ". Invalid IBAN Number <" + item.ToString() + "> for line number " + lineNumber.ToString() + "." + Environment.NewLine
                    '        End If
                    '    Case 6
                    '        If item Is Nothing Or item.ToString() = "" Then
                    '            errorNumber += 1
                    '            errors += errorNumber.ToString() + ". Missing National ID Number for line number " + lineNumber.ToString() + "." + Environment.NewLine
                    '        ElseIf Trim(item.ToString()).Length <> 10 Then
                    '            errorNumber += 1
                    '            errors += errorNumber.ToString() + ". Invalid National ID number <" + item.ToText() + "> for line number " + lineNumber.ToString() + "." + Environment.NewLine
                    '        End If
                    'End Select
                    'i += 1
                Next
                outFile.WriteLine(lineText)
                outFile.Close()
                Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFilePath))
                If IO.File.Exists(csvFilePath) Then
                    OpenInExcel(csvFilePath)
                End If
                'If errors <> "" Then
                '    Dim message = " -oOo- " & errorNumber.ToString() + " errors found in output file see list below. -oOo-" + Environment.NewLine + Environment.NewLine + errors
                '    MessageBox.Show(message, $"Errors Found", MessageBoxButtons.OK,
                '                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)

                'End If
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

        'Public Sub ReleaseComObject(ByVal obj As Object)
        '    Try
        '        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        '        obj = Nothing
        '    Catch ex As Exception
        '        obj = Nothing
        '    End Try
        'End Sub

    End Class

End Namespace