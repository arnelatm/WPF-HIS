Imports System.Data.SqlClient
Imports System.IO

Namespace Classes

    Public Class DataOperations
        Inherits BaseSqlServerConnection

        Private ReadOnly _pinvalidImage As Image
        Public ReadOnly Property InvalidImage() As Image
            Get
                Return _pinvalidImage
            End Get
        End Property

        Public Sub New()

            _pinvalidImage = ConvertTextToImage(
                Environment.NewLine & "    Error",
                "Arial", 20,
                Color.Red, Color.White,
                300, 200)

        End Sub
        ''' <summary>
        ''' Read all records excluding Picture field
        ''' </summary>
        ''' <returns></returns>
        Public Function GetEmployees() As List(Of Employee)
            Dim EmployeeList As New List(Of Employee)
            Using cn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand("SELECT IdNo ,[EmployeeName] FROM dbo.Employee1", cn)
                    Try
                        cn.Open()
                        Dim reader As SqlDataReader = cmd.ExecuteReader()

                        While reader.Read()
                            EmployeeList.Add(New Employee() With
                                             {
                                                 .IdNo = reader.GetInt32(0),
                                                 .EmployeeName = reader.GetString(1)
                                             })
                        End While

                        ' add invalid item
                        EmployeeList.Add(New Employee() With {.IdNo = 100, .EmployeeName = "Does not exist"})

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try
                End Using
            End Using

            Return EmployeeList

        End Function

        '''' <summary>
        '''' Read all records with all fields
        '''' </summary>
        '''' <returns></returns>
        'Public Function GetEmployeesWithImagesFromList1() As List(Of Employee)
        '    Dim EmployeeImage As Image = Nothing
        '    Dim EmployeeList As New List(Of Employee)

        '    Using cn As New SqlConnection(ConnectionString)
        '        Using cmd As New SqlCommand("SELECT IdNo, [EmployeeName], Picture FROM dbo.Employee1", cn)
        '            Try

        '                cn.Open()

        '                Dim reader As SqlDataReader = cmd.ExecuteReader()

        '                While reader.Read()

        '                    Dim imageData = CType(reader(2), Byte())

        '                    If imageData IsNot Nothing Then
        '                        Using ms As New MemoryStream(imageData, 0, imageData.Length)
        '                            ms.Write(imageData, 0, imageData.Length)
        '                            EmployeeImage = Image.FromStream(ms, True)
        '                        End Using
        '                    Else
        '                        ' tmpImage is used for adding a new item
        '                    End If

        '                    EmployeeList.Add(New Employee() With
        '                                     {
        '                                         .IdNo = reader.GetInt32(0),
        '                                         .EmployeeName = reader.GetString(1),
        '                                         .Picture = EmployeeImage
        '                                     })
        '                End While

        '            Catch ex As Exception
        '                mHasException = True
        '                mLastException = ex
        '            End Try
        '        End Using
        '    End Using

        '    Return EmployeeList

        '    End
        'End Function





        ''' <summary>
        ''' Read all records with all fields
        ''' </summary>
        ''' <returns></returns>
        Public Function GetEmployeesWithImagesFromList() As List(Of Employee)
            Dim EmployeeImage As Image = Nothing
            Dim EmployeeList As New List(Of Employee)

            Using cn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand("SELECT IdNo, [EmployeeName], Picture FROM dbo.Employee1", cn)
                    Try

                        cn.Open()

                        Dim reader As SqlDataReader = cmd.ExecuteReader()

                        While reader.Read()

                            EmployeeList.Add(New Employee() With
                                             {
                                                 .IdNo = reader.GetInt32(0),
                                                 .EmployeeName = reader.GetString(1),
                                                 .Picture = GetPicture(reader(2))
                                             })
                        End While

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try
                End Using
            End Using

            Return EmployeeList

        End Function

        Public Function GetPicture(cPicture As Object) As Image
            Dim imageData = CType(cPicture, Byte())
            Dim img As Image = Nothing
            If imageData IsNot Nothing Then
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    img = Image.FromStream(ms, True)
                End Using
            End If
            Return img
        End Function


        Public Function DataTable() As DataTable
            Dim dt As New DataTable

            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SELECT IdNo,[EmployeeName], Picture FROM dbo.Employee1"}
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    dt.Columns("IdNo").ColumnMapping = MappingType.Hidden
                    dt.Columns("Picture").ColumnMapping = MappingType.Hidden
                    dt.Columns("Picture").ReadOnly = True
                End Using
            End Using

            Return dt

        End Function

        ''' <summary>
        ''' Read Picture from table by primary key
        ''' </summary>
        ''' <param name="pIdentifier"></param>
        ''' <returns></returns>
        Public Function GetImage(pIdentifier As Integer) As Image

            Dim EmployeeImage As Image = _pinvalidImage

            Using cn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand("SELECT Picture FROM dbo.Employee1 WHERE IdNo = @IdNo", cn)

                    cmd.Parameters.AddWithValue("@IdNo", pIdentifier)

                    Dim reader As SqlDataReader

                    Try
                        cn.Open()

                        reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                        If reader.Read Then

                            Dim imageData As Byte() = CType(reader(0), Byte())

                            reader.Close()

                            If imageData IsNot Nothing Then
                                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                                    ms.Write(imageData, 0, imageData.Length)
                                    EmployeeImage = Image.FromStream(ms, True)
                                End Using
                            End If

                        End If
                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                End Using

            End Using

            Return EmployeeImage

        End Function


        ''' <summary>
        ''' Responsive for creating a error image
        ''' </summary>
        ''' <param name="pMessageText"></param>
        ''' <param name="pFontName"></param>
        ''' <param name="pFontSize"></param>
        ''' <param name="pBackColor"></param>
        ''' <param name="pForeColor"></param>
        ''' <param name="pWidth"></param>
        ''' <param name="pHeight"></param>
        ''' <returns></returns>
        Private Function ConvertTextToImage(pMessageText As String,
                                            pFontName As String, pFontSize As Integer,
                                            pBackColor As Color,
                                            pForeColor As Color,
                                            pWidth As Integer,
                                            pHeight As Integer) As Bitmap

            Dim bmp As New Bitmap(pWidth, pHeight)

            Using graphics As Graphics = Graphics.FromImage(bmp)
                Dim font As New Font(pFontName, pFontSize)
                graphics.FillRectangle(New SolidBrush(pBackColor), 0, 0, bmp.Width, bmp.Height)
                graphics.DrawString(pMessageText, font, New SolidBrush(pForeColor), 0, 0)
                graphics.Flush()
                font.Dispose()
                graphics.Dispose()
            End Using

            Return bmp

        End Function


        Public Function SaveImage(idNo As Int32, picture As Image) As Boolean
            Dim retValue As Object = Nothing
            Dim tryAgain As Boolean
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    tryAgain = False
                    Try
                        Using command = CreateCommand(sql, connection, parms)
                            retValue = command.ExecuteNonQuery()
                        End Using
                    Catch ex As SqlException
                        '_waitForm.Close()
                        If ex.Number = 2601 OrElse ex.Number = 2627 Then
                            MessageBox.Show(
                                "Duplicate values found ....." & ex.Message & vbNewLine & "Record not saved!!",
                                "NOT Saved", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            retValue = -1
                        Else
                            Select Case TryToCatchError(ex)
                                Case DialogResult.Cancel
                                    retValue = -1
                                    '
                                Case DialogResult.Retry
                                    tryAgain = True
                                    '_waitForm.Show()
                                Case Else
                                    retValue = -1
                                    MessageBox.Show(ex.Message)
                                    Throw
                            End Select
                        End If
                    Catch ex As Exception
                        retValue = -1
                        MessageBox.Show(ex.Message)
                        Throw
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            Return retValue

        End Function

    End Class
End Namespace