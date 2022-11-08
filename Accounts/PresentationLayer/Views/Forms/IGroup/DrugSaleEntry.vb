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
            FirstControl = txtQrCode
            AutoAddOnSave = True

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
                Return NumParser(Of Int32)(TxtIdNo.Text)
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

        Public Property Expiry As Date? Implements IDrugSaleView.Expiry
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

        Public Property SaleDate As Date? Implements IDrugSaleView.SaleDate
            Get
                Return dtpSaleDate.Value
            End Get
            Set(value As Date?)
                dtpSaleDate.Value = value
            End Set
        End Property

        Public Property QrCode As String Implements IDrugSaleView.QrCode
            Get
                Return txtQrCode.Text
            End Get
            Set(value As String)
                txtQrCode.Text = value
            End Set
        End Property

#End Region

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

        Private _cGTIN As String = Nothing
        Private _cSerializationNo As String = Nothing
        Private _cBatchNo As String = Nothing
        Private _cExpiry As String
        Private _cManufacture As String

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            ProcessQrCode()
            If ValidValues() Then
                AssignQrCodeValues()
            End If
        End Sub

        Private Sub AssignQrCodeValues()
            GTIN = _cGTIN
            BatchNo = _cBatchNo
            SerializationNo = _cSerializationNo
            dtpManufactureDate.Text = MakeDate(_cManufacture)
            Expiry = MakeDate(_cExpiry)
            RaiseEvent GetDrugName()
        End Sub

        Private Sub EraseEntry()
            GTIN = ""
            BatchNo = ""
            SerializationNo = ""
            Expiry = Nothing
            dtpManufactureDate.Value = Nothing
            ItemNameEnglish = ""
        End Sub

        Private Function MakeDate(stringDate As String) As Date
            Return GbDateSerial(2000 + Val(Mid(stringDate, 1, 2)), Val(Mid(stringDate, 3, 2)), Val(Mid(stringDate, 5, 2)))
        End Function

        Private Sub ProcessQrCode()
            EraseEntry()
            Dim dataLength = Len(txtQrCode.Text)
            Dim i As Int16 = 0
            _cGTIN = Mid(txtQrCode.Text, 3, 14)
            Dim ai As String = Mid(txtQrCode.Text, 17, 2)
            Dim lastPosition As Int16 = 18
            While lastPosition < dataLength
                Select Case ai
                    Case "17"
                        _cExpiry = Mid(txtQrCode.Text, lastPosition + 1, 6)
                        If _cExpiry.Right(2) = "00" Then
                            _cExpiry = Mid(txtQrCode.Text, 1, 4) + "01"
                        End If
                        lastPosition += 6
                    Case "11" 'manufacture date
                        _cManufacture = Mid(txtQrCode.Text, lastPosition + 1, 6)
                        lastPosition += 6
                    Case "10"
                        For i = lastPosition + 1 To dataLength
                            If Mid(txtQrCode.Text, i, 4) = "<GS>" Then ' separator
                                _cBatchNo = Mid(txtQrCode.Text, lastPosition + 1, i - lastPosition - 1)
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                    'MessageBox.Show("Batch No = " + batchNo)
                    Case "21"
                        For i = lastPosition + 1 To dataLength
                            If Mid(txtQrCode.Text, i, 4) = "<GS>" Or Mid(txtQrCode.Text, i, 1) = ChrW(13) Or i >= dataLength Then
                                _cSerializationNo = Mid(txtQrCode.Text, lastPosition + 1, i - lastPosition)
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                        'MessageBox.Show("Serialization No = " + serializationNo)
                End Select
                If lastPosition >= dataLength Then
                    Exit While
                Else
                    ai = Mid(txtQrCode.Text, lastPosition + 1, 2)
                    If ai = vbLf Or ai = vbCrLf Or ai = vbLf & vbCr Then
                        Exit While
                    End If
                    lastPosition += 2
                End If
            End While
        End Sub

        'Private Function MakeQrDate(cDateText As String)
        '    Dim yy As String, mm As String, dd As String, startPosition As Short
        '    yy = Mid(txtQrCode.Text, startPosition + 1, 2)
        '    mm = Mid(txtQrCode.Text, startPosition + 3, 2)
        '    dd = Mid(txtQrCode.Text, startPosition + 5, 2)
        '    Return yy + "/" + mm + "/" + dd
        'End Function

        Private Function ValidValues()
            Dim formats() As String = {"dd/MM/yyyy"}
            Dim yy As String, mm As String, dd As String
            yy = Mid(_cExpiry, 1, 2)
            mm = Mid(_cExpiry, 3, 2)
            dd = Mid(_cExpiry, 5, 2)
            Dim textDate As String = dd + "/" + mm + "/" + (2000 + Val(yy)).ToString()
            Dim dDate As Date
            If Not DateTime.TryParseExact(textDate, formats, Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, dDate) Then
                MessageBox.Show("Invalid date value or format! <" + textDate + ">")
                Return False
            End If
            If dDate <= Today() Then
                MessageBox.Show("Item is Expired. Can't sell or accept an expired drug.")
                Return False
            End If
            If Len(_cGTIN) = 14 AndAlso Not IsNumeric(_cGTIN) Then
                MessageBox.Show("Invalid GTIN <" + _cGTIN + ">")
                Return False
            End If
            If Len(_cBatchNo) < 1 Then
                MessageBox.Show("Batch Number cannot be empty!")
                Return False
            End If
            If Len(_cSerializationNo) < 1 Then
                MessageBox.Show("Serialization Number cannot be empty!")
                Return False
            End If
            Return True
        End Function

        Private Sub txtQrCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQrCode.KeyPress

            Dim i As Integer = Me.txtQrCode.SelectionStart 'save for later use

            Select Case Asc(e.KeyChar)

                'Case 4 'EOT

                '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<EOT>")

                '    Me.txtQrCode.SelectionStart = i + 5

                '    e.Handled = True

                Case 29 'GS

                    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<GS>")

                    Me.txtQrCode.SelectionStart = i + 5

                    e.Handled = True

                    'Case 30 'RS

                    '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<RS>")

                    '    Me.txtQrCode.SelectionStart = i + 5

                    '    e.Handled = True

            End Select

        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton2.ClickButtonArea
            EraseEntry()
            txtQrCode.Text = ""
            txtQrCode.Focus()
        End Sub

        Private Sub DrugSaleEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnAdd.PerformClick()
            txtQrCode.Focus()
        End Sub

        Private Sub txtQrCode_Validated(sender As Object, e As EventArgs) Handles txtQrCode.LostFocus
            Dim saveData As Boolean = False
            If Not (txtQrCode.Text Is Nothing Or txtQrCode.Text = "") Then
                If txtQrCode.Text.Contains("<GS>") Then
                    ProcessQrCode()
                    If ValidValues() Then
                        AssignQrCodeValues()
                        saveData = True
                    End If
                End If
            End If
        End Sub

        Private Sub btnValidate_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnValidate.ClickButtonArea
            If Not ValidEntries() Then
                MessageBox.Show("Please correct this record.")
            Else
                MessageBox.Show("Values are valid.")
            End If
        End Sub

        Private Function ValidEntries()
            Dim formats() As String = {"dd/MM/yyyy"}
            If dtpExpiry.Value Is Nothing Then
                MessageBox.Show("Expiry Date can't be empty!")
                Return False
            End If
            If dtpExpiry.Value <= Today() Then
                MessageBox.Show("Item is Expired. Can't sell or accept an expired drug.")
                Return False
            End If
            If Len(GTIN) = 14 AndAlso Not IsNumeric(GTIN) Then
                MessageBox.Show("Invalid GTIN <" + GTIN + ">")
                Return False
            End If
            If Len(BatchNo) < 1 Then
                MessageBox.Show("Batch Number cannot be empty!")
                Return False
            End If
            If Len(SerializationNo) < 1 Then
                MessageBox.Show("Serialization Number cannot be empty!")
                Return False
            End If
            Return True
        End Function

    End Class

End Namespace