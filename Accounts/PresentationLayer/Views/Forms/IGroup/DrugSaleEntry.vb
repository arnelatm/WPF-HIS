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
            Set(value As Date)
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
            Dim dataLength = Len(txtQrCode.Text)
            'Dim data As Byte()
            'data = convertQPToByteArray(txtQrCode.Text)
            Dim message As String = "Text Length = " + Len(txtQrCode.Text).ToString() + vbLf
            'Dim myByte() As Byte = data
            Dim i As Int16 = 0
            Dim cGTIN = Mid(txtQrCode.Text, 3, 14)
            'MessageBox.Show("GTIN = " + GTIN)
            Dim ai As String = Mid(txtQrCode.Text, 17, 2)
            Dim lastPosition As Int16 = 18
            Dim cSerializationNo = ""
            Dim cBatchNo = ""
            Dim yy As String = ""
            Dim mm As String = ""
            Dim dd As String = ""

            While lastPosition < dataLength
                Select Case ai
                    Case "17"
                        yy = Mid(txtQrCode.Text, lastPosition + 1, 2)
                        mm = Mid(txtQrCode.Text, lastPosition + 3, 2)
                        dd = Mid(txtQrCode.Text, lastPosition + 5, 2)
                        'cExpiry = dd + "/" + mm + "/" + "20" + yy
                        'MessageBox.Show("Expiry = " + expiry)
                        lastPosition += 6
                    Case "11" 'manufacture date
                        ' don't need this data
                        lastPosition += 6
                    Case "10"
                        For i = lastPosition + 1 To dataLength
                            If Mid(txtQrCode.Text, i, 4) = "<GS>" Then ' separator
                                cBatchNo = Mid(txtQrCode.Text, lastPosition + 1, i - lastPosition - 1)
                                lastPosition = i + 3
                                Exit For
                            End If
                        Next
                    'MessageBox.Show("Batch No = " + batchNo)
                    Case "21"
                        For i = lastPosition + 1 To dataLength
                            If Mid(txtQrCode.Text, i, 4) = "<GS>" Or Mid(txtQrCode.Text, i, 1) = ChrW(13) Or i >= dataLength Then
                                cSerializationNo = Mid(txtQrCode.Text, lastPosition + 1, i - lastPosition)
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
            GTIN = cGTIN
            BatchNo = cBatchNo
            SerializationNo = cSerializationNo
            Expiry = GbDateSerial(2000 + Val(yy), Val(mm), Val(dd))
            RaiseEvent GetDrugName()
        End Sub

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

        'Private Sub cboItemFinder_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    RaiseEvent FinderValueChanged(cboItemFinder.SelectedItem.IdNo)
        'End Sub

#End Region

    End Class

End Namespace