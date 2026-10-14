Imports System.Data
Imports System.Globalization
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services
Imports Excel = Microsoft.Office.Interop.Excel

Namespace ServiceLayer
    Public Class TableViewerService
        Public Shared Function CanView() As Boolean
            If Not GlobalVariables.IsUserLoggedIn Then Return False
            If UserIsASuperAdmin() Then Return True
            Dim access = New Service().GetUserSecurityForKey("TableViewer", GlobalVariables.SecurityGroupIdNo)
            Return access IsNot Nothing AndAlso access.Count > 1 AndAlso Convert.ToBoolean(access(1))
        End Function

        Private Shared Sub EnsureAccess()
            If Not CanView() Then Throw New UnauthorizedAccessException("Access to the table viewer is denied.")
        End Sub

        Public Function GetTables() As DataTable
            EnsureAccess()
            Return New TableViewerDao().GetTables()
        End Function

        Public Function GetRecords(schemaName As String, tableName As String) As DataTable
            EnsureAccess()
            Return New TableViewerDao().GetRecords(schemaName, tableName, GlobalVariables.RightToLeftLayout)
        End Function

        Public Shared Function DisplayValue(value As Object) As String
            If value Is Nothing OrElse Convert.IsDBNull(value) Then Return String.Empty
            If TypeOf value Is Byte() Then Return "0x" & BitConverter.ToString(DirectCast(value, Byte())).Replace("-", "")
            If TypeOf value Is DateTime Then Return DirectCast(value, DateTime).ToString("yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture)
            Dim formattable = TryCast(value, IFormattable)
            Return If(formattable Is Nothing, value.ToString(), formattable.ToString(Nothing, CultureInfo.InvariantCulture))
        End Function

        Public Shared Function TryReadPicture(value As Object) As Image
            Dim bytes = TryCast(value, Byte())
            If bytes Is Nothing OrElse bytes.Length = 0 Then Return Nothing
            Try
                Using stream As New MemoryStream(bytes), original = Image.FromStream(stream, True, True)
                    Return New Bitmap(original)
                End Using
            Catch ex As ArgumentException
                Return Nothing
            Catch ex As OutOfMemoryException
                ' GDI+ also reports invalid image data as OutOfMemoryException.
                Return Nothing
            End Try
        End Function

        Public Sub ExportToExcel(data As DataTable, path As String)
            EnsureAccess()
            If data Is Nothing Then Throw New ArgumentNullException(NameOf(data))
            If data.Rows.Count > 1048575 OrElse data.Columns.Count > 16384 Then
                Throw New InvalidOperationException("The table exceeds Excel's worksheet limits.")
            End If
            If data.Columns.Count = 0 Then Throw New InvalidOperationException("Select at least one field to export.")
            Dim fullPath = System.IO.Path.GetFullPath(path)
            Dim filesName = System.IO.Path.GetFileNameWithoutExtension(fullPath) & "_files"
            Dim filesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fullPath), filesName)
            Dim app As Excel.Application = Nothing
            Dim books As Excel.Workbooks = Nothing
            Dim book As Excel.Workbook = Nothing
            Dim sheets As Excel.Sheets = Nothing
            Dim sheet As Excel.Worksheet = Nothing
            Dim cells As Excel.Range = Nothing
            Dim range As Excel.Range = Nothing
            Try
                app = New Excel.Application With {.Visible = False, .DisplayAlerts = False}
                books = app.Workbooks
                book = books.Add()
                sheets = book.Worksheets
                sheet = DirectCast(sheets.Item(1), Excel.Worksheet)
                sheet.Name = "Data"
                cells = sheet.Cells
                Dim headers(0, data.Columns.Count - 1) As Object
                For column = 0 To data.Columns.Count - 1
                    headers(0, column) = "'" & data.Columns(column).ColumnName
                Next
                range = cells.Resize(1, data.Columns.Count)
                range.NumberFormat = "@"
                range.Value2 = headers
                Release(range)
                For start = 0 To data.Rows.Count - 1 Step 1000
                    Dim count = Math.Min(1000, data.Rows.Count - start)
                    Dim values(count - 1, data.Columns.Count - 1) As Object
                    For row = 0 To count - 1
                        For column = 0 To data.Columns.Count - 1
                            Dim value = data.Rows(start + row)(column)
                            ' Text preserves long identifiers, leading zeros, and exact decimals,
                            ' and prevents database text from becoming an Excel formula.
                            Dim text As String = Nothing
                            If Not Convert.IsDBNull(value) Then
                                If TypeOf value Is Byte() Then
                                    Dim bytes = DirectCast(value, Byte())
                                    If bytes.Length = 0 Then
                                        text = "No picture / empty binary"
                                    Else
                                        Using picture = TryReadPicture(value)
                                            If picture Is Nothing AndAlso bytes.Length <= 16382 Then
                                                ' Small ordinary binary fields (including rowversion) remain hexadecimal.
                                                text = DisplayValue(value)
                                            Else
                                                Directory.CreateDirectory(filesPath)
                                                Dim name = "row_" & (start + row + 1).ToString() & "_field_" & (column + 1).ToString()
                                                name &= If(picture Is Nothing, ".bin", PictureExtension(bytes))
                                                ' Original bytes are retained without re-encoding.
                                                File.WriteAllBytes(System.IO.Path.Combine(filesPath, name), bytes)
                                                text = filesName & "/" & name
                                            End If
                                        End Using
                                    End If
                                Else
                                    text = DisplayValue(value)
                                    If text.Length > 32767 Then
                                        Directory.CreateDirectory(filesPath)
                                        Dim name = "row_" & (start + row + 1).ToString() & "_field_" & (column + 1).ToString() & ".txt"
                                        File.WriteAllText(System.IO.Path.Combine(filesPath, name), text, System.Text.Encoding.UTF8)
                                        text = filesName & "/" & name
                                    End If
                                End If
                            End If
                            values(row, column) = If(text Is Nothing, Nothing, "'" & text)
                        Next
                    Next
                    Dim first As Excel.Range = Nothing
                    Try
                        first = DirectCast(cells.Item(start + 2, 1), Excel.Range)
                        range = first.Resize(count, data.Columns.Count)
                        range.NumberFormat = "@"
                        range.Value2 = values
                    Finally
                        Release(range)
                        Release(first)
                    End Try
                Next
                EmbedPictures(data, sheet, cells, filesPath)
                book.SaveAs(fullPath, Excel.XlFileFormat.xlOpenXMLWorkbook)
            Finally
                Try
                    If book IsNot Nothing Then book.Close(False)
                Finally
                    Try
                        If app IsNot Nothing Then app.Quit()
                    Finally
                        Release(range)
                        Release(cells)
                        Release(sheet)
                        Release(sheets)
                        Release(book)
                        Release(books)
                        Release(app)
                    End Try
                End Try
            End Try
        End Sub

        Private Shared Function PictureExtension(bytes As Byte()) As String
            If bytes.Length >= 3 AndAlso bytes(0) = &HFF AndAlso bytes(1) = &HD8 Then Return ".jpg"
            If bytes.Length >= 4 AndAlso bytes(0) = &H89 AndAlso bytes(1) = &H50 Then Return ".png"
            If bytes.Length >= 3 AndAlso bytes(0) = &H47 AndAlso bytes(1) = &H49 Then Return ".gif"
            If bytes.Length >= 2 AndAlso bytes(0) = &H42 AndAlso bytes(1) = &H4D Then Return ".bmp"
            If bytes.Length >= 2 AndAlso ((bytes(0) = &H49 AndAlso bytes(1) = &H49) OrElse (bytes(0) = &H4D AndAlso bytes(1) = &H4D)) Then Return ".tif"
            Return ".img"
        End Function

        Private Shared Sub EmbedPictures(data As DataTable, sheet As Excel.Worksheet, cells As Excel.Range, filesPath As String)
            Dim shapes As Object = Nothing
            Try
                shapes = sheet.Shapes
                For row = 0 To data.Rows.Count - 1
                    For column = 0 To data.Columns.Count - 1
                        Dim value = data.Rows(row)(column)
                        If Not TypeOf value Is Byte() Then Continue For
                        Using picture = TryReadPicture(value)
                            If picture Is Nothing Then Continue For
                            Dim cell As Excel.Range = Nothing
                            Dim shape As Object = Nothing
                            Try
                                cell = DirectCast(cells.Item(row + 2, column + 1), Excel.Range)
                                cell.RowHeight = 78
                                cell.ColumnWidth = 26
                                Dim scale = Math.Min(100.0 / picture.Width, 52.0 / picture.Height)
                                Dim fileName = "row_" & (row + 1).ToString() & "_field_" & (column + 1).ToString() & PictureExtension(DirectCast(value, Byte()))
                                shape = shapes.AddPicture(System.IO.Path.Combine(filesPath, fileName), 0, -1,
                                                          CSng(cell.Left + 2), CSng(cell.Top + 2),
                                                          CSng(picture.Width * scale), CSng(picture.Height * scale))
                                shape.Placement = Excel.XlPlacement.xlMoveAndSize
                                cell.VerticalAlignment = Excel.XlVAlign.xlVAlignBottom
                            Finally
                                Release(shape)
                                Release(cell)
                            End Try
                        End Using
                    Next
                Next
            Finally
                Release(shapes)
            End Try
        End Sub

        Private Shared Sub Release(Of T As Class)(ByRef value As T)
            If value IsNot Nothing AndAlso Marshal.IsComObject(value) Then Marshal.FinalReleaseComObject(value)
            value = Nothing
        End Sub
    End Class
End Namespace
