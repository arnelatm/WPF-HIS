Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DrugSaleEntry
        Implements IDrugSaleView

        Private _nfi As NumberFormatInfo

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtGTIN

            Dim numberDecimalDigits = 4
            Dim numberDecimalSeparator = ConfigurationManager.AppSettings("DefaultNumberDecimalSeparator")
            Dim numberGroupSeparator = ConfigurationManager.AppSettings("DefaultNumberGroupSeparator")
            _nfi = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
            _nfi.NumberDecimalDigits = 4
            If numberDecimalSeparator Is Nothing Then
                _nfi.NumberDecimalSeparator = "."
            Else
                _nfi.NumberDecimalSeparator = numberDecimalSeparator
            End If
            If numberGroupSeparator Is Nothing Then
                _nfi.NumberGroupSeparator = ","
            Else
                _nfi.NumberGroupSeparator = numberGroupSeparator
            End If

        End Sub

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IDrugSaleView.FinderValueChanged

        Public Event GenerateCsvFile(salesDate As Date) Implements IDrugSaleView.GenerateCsvFile

        Public Event GetDrugName() Implements IDrugSaleView.GetDrugName

        Public Property DrugSaleByName As List(Of Lookup.LookupData)

#Region "Field Items"

        Public Property IdNo As Int32 Implements IDrugSaleView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property GTIN As String Implements IDrugSaleView.GTin
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
            End Set
        End Property

        Public Property BatchNo As String Implements IDrugSaleView.BatchNo
            Get
                Return txtBatchNo.Text
            End Get
            Set(value As String)
                txtBatchNo.Text = value
            End Set
        End Property

        Public Property Expiry As Date Implements IDrugSaleView.Expiry
            Get
                Return dtpExpiry.Value
            End Get
            Set
                dtpExpiry.Value = Value
            End Set
        End Property

        Public Property Item_Code As String Implements IDrugSaleView.Item_Code
            Get
                Return TxtItem_Code.Text
            End Get
            Set(value As String)
                TxtItem_Code.Text = value
            End Set
        End Property

        Public Property ItemNameEnglish As String Implements IDrugSaleView.ItemNameEnglish
            Get
                Return txtItemNameEnglish.Text
            End Get
            Set(value As String)
                txtItemNameEnglish.Text = value
            End Set
        End Property

        Public Property SerializationNo As String Implements IDrugSaleView.SerializationNo
            Get
                Return txtSerializationNo.Text
            End Get
            Set(value As String)
                txtSerializationNo.Text = value
            End Set
        End Property

        Public Property SaleDate As Date Implements IDrugSaleView.SaleDate
            Get
                Return dtpSaleDate.Value
            End Get
            Set(value As DateTime)
                dtpSaleDate.Value = value
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"BatchNo", txtBatchNo},
                {"Expiry", dtpExpiry},
                {"GTin", txtGTIN},
                {"IdNo", TxtIdNo},
                {"Item_Code", TxtItem_Code},
                {"ItemNameEnglish", txtItemNameEnglish},
                {"SaleDate", dtpSaleDate},
                {"SerializationNo", txtSerializationNo}
                }
        End Sub

        Protected Overrides Sub BeforeEdit()
            SetDisplayOnly(True)
            Refresh()
        End Sub

        Private Sub SetDisplayOnly(value As Boolean)
            txtItemNameEnglish.DisplayOnly = value
            TxtItem_Code.DisplayOnly = value
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            Dim fileName As String = "C:\temp\DrugQrCode.txt"
            If File.Exists(fileName) Then
                File.Delete(fileName)
            End If
            txtGTIN.Text = ""
            txtBatchNo.Text = ""
            txtSerializationNo.Text = ""
            txtItemNameEnglish.Text = ""
            TxtItem_Code.Text = ""
            dtpExpiry.Value = Today()
            Process.Start("D:\AATM\QrDrugScanner\QrDrugScanner\bin\Debug\netcoreapp3.1\QrDrugScanner.exe")
            Dim fileReader As String
            Refresh()
            Dim dteFutureDate As DateTime = Date.Now().AddSeconds(1)
            Threading.Thread.Sleep(5000) ' 500 milliseconds = 2 seconds
            If File.Exists(fileName) Then
                fileReader = My.Computer.FileSystem.ReadAllText(fileName)
                Dim dataLength = Len(fileReader)
                'Dim data As Byte()
                'data = convertQPToByteArray(fileReader)
                Dim message As String = "Text Length = " + Len(fileReader).ToString() + vbLf
                'Dim myByte() As Byte = data
                Dim i As Int16 = 0
                Dim cGTIN = Mid(fileReader, 3, 14)
                'MessageBox.Show("GTIN = " + GTIN)
                Dim ai As String = Mid(fileReader, 17, 2)
                Dim lastPosition As Int16 = 16
                Dim cSerializationNo = ""
                Dim cBatchNo = ""
                Dim cExpiry
                Dim yy As String = ""
                Dim mm As String = ""
                Dim dd As String = ""

                While lastPosition < dataLength
                    Select Case ai
                        Case "17"
                            lastPosition += 2
                            yy = Mid(fileReader, lastPosition + 1, 2)
                            mm = Mid(fileReader, lastPosition + 3, 2)
                            dd = Mid(fileReader, lastPosition + 5, 2)
                            Expiry = dd + "/" + mm + "/" + "20" + yy
                            'MessageBox.Show("Expiry = " + expiry)
                            lastPosition += 6
                        Case "10"
                            lastPosition += 2
                            For i = lastPosition + 1 To dataLength
                                If Mid(fileReader, i, 1) = ChrW(29) Then
                                    cBatchNo = Mid(fileReader, lastPosition + 1, i - lastPosition - 1)
                                    lastPosition = i
                                    Exit For
                                End If
                            Next
                    'MessageBox.Show("Batch No = " + batchNo)
                        Case "21"
                            lastPosition += 2
                            For i = lastPosition + 1 To dataLength
                                If Mid(fileReader, i, 1) = ChrW(29) Or Mid(fileReader, i, 1) = ChrW(13) Or i >= dataLength Then
                                    cSerializationNo = Mid(fileReader, lastPosition + 1, i - lastPosition - 1)
                                    lastPosition = i
                                    Exit For
                                End If
                            Next
                            'MessageBox.Show("Serialization No = " + serializationNo)
                    End Select
                    If lastPosition >= dataLength Then
                        Exit While
                    Else
                        ai = Mid(fileReader, lastPosition + 1, 2)
                        If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                            Exit While
                        End If
                    End If
                End While
                GTIN = cGTIN
                BatchNo = cBatchNo
                SerializationNo = cSerializationNo
                Expiry = GbDateSerial(2000 + Val(yy), Val(mm), Val(dd))
                RaiseEvent GetDrugName()
                My.Computer.FileSystem.DeleteFile(fileName)
            Else
                MessageBox.Show("Please try again, barcode not detected")
            End If
        End Sub

        'Private Sub cboItemFinder_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    RaiseEvent FinderValueChanged(cboItemFinder.SelectedItem.IdNo)
        'End Sub

#End Region

    End Class

End Namespace