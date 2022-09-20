Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DrugAcceptEntry
        Implements IDrugAcceptView

        Public Event CheckDuplicateDrug(ByRef duplicate As Boolean) Implements IDrugAcceptView.CheckDuplicateDrug

        Public Event ClearEntry() Implements IDrugAcceptView.ClearEntry

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IDrugAcceptView.FinderValueChanged

        Public Event GenerateCsvFile(acceptDate As Date) Implements IDrugAcceptView.GenerateCsvFile

        Public Event ValidateEntries() Implements IDrugAcceptView.ValidateEntries

        Public Event ValidateQrCode(ByRef valid As Boolean) Implements IDrugAcceptView.ValidateQrCode

        Public Event SaveDrugAccept() Implements IDrugAcceptView.SaveDrugAccept

        Public Event AddDrugAccept() Implements IDrugAcceptView.AddDrugAccept

        Public Property DrugAcceptByName As List(Of Lookup.LookupData)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtQrCode
            AutoAddOnSave = True
            qrCodeErrorProvider.SetIconAlignment(txtQrCode, ErrorIconAlignment.MiddleRight)
            qrCodeErrorProvider.SetIconPadding(txtQrCode, 2)
            qrCodeErrorProvider.BlinkRate = 1000
            qrCodeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink

        End Sub

#Region "Field Items"

        Public Property IdNo As Int32 Implements IDrugAcceptView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property GTin As String Implements IDrugAcceptView.GTin
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
            End Set
        End Property

        Public Property BatchNo As String Implements IDrugAcceptView.BatchNo
            Get
                Return txtBatchNo.Text
            End Get
            Set(value As String)
                txtBatchNo.Text = value
            End Set
        End Property

        Public Property Expiry As Date? Implements IDrugAcceptView.Expiry
            Get
                Return dtpExpiry.Value
            End Get
            Set
                dtpExpiry.Value = Value
            End Set
        End Property

        Public Property Manufacture As Date? Implements IDrugAcceptView.Manufacture
            Get
                Return dtpManufacture.Value
            End Get
            Set
                dtpManufacture.Value = Value
            End Set
        End Property

        Public Property Item_Code As String Implements IDrugAcceptView.Item_Code
            Get
                Return TxtItem_Code.Text
            End Get
            Set(value As String)
                TxtItem_Code.Text = value
            End Set
        End Property

        Public Property ItemNameEnglish As String Implements IDrugAcceptView.ItemNameEnglish
            Get
                Return txtItemNameEnglish.Text
            End Get
            Set(value As String)
                txtItemNameEnglish.Text = value
            End Set
        End Property

        Public Property SerializationNo As String Implements IDrugAcceptView.SerializationNo
            Get
                Return txtSerializationNo.Text
            End Get
            Set(value As String)
                txtSerializationNo.Text = value
            End Set
        End Property

        Public Property AcceptDate As Date? Implements IDrugAcceptView.AcceptDate
            Get
                Return dtpAcceptDate.Value
            End Get
            Set(value As Date?)
                dtpAcceptDate.Value = value
            End Set
        End Property

        Public Property QrCode As String Implements IDrugAcceptView.QrCode
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
                {
                {"QrCode", txtQrCode},
                {"BatchNo", txtBatchNo},
                {"Expiry", dtpExpiry},
                {"GTin", txtGTIN},
                {"IdNo", TxtIdNo},
                {"Item_Code", TxtItem_Code},
                {"ItemNameEnglish", txtItemNameEnglish},
                {"AcceptDate", dtpAcceptDate},
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

        Private Sub btnClearEntry_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClearEntry.ClickButtonArea
            RaiseEvent ClearEntry()
        End Sub

        Private Sub DrugAcceptEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnAdd.PerformClick()
            txtQrCode.Focus()
        End Sub

        Private Sub btnValidate_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnValidate.ClickButtonArea
            RaiseEvent ValidateEntries()
        End Sub

        Private Sub txtQrCode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtQrCode.Validating
            Dim valid As Boolean = False
            RaiseEvent ValidateQrCode(valid)
            If valid Then
                e.Cancel = False
            Else
                e.Cancel = True
                MessageBox.Show("Invalid QR Code!")
            End If
        End Sub

        'Private Sub txtQrCode_Validated(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtQrCode.Validated
        '    If txtQrCode.Text IsNot Nothing Then
        '        RaiseEvent SaveDrugAccept()
        '    End If
        'End Sub

        Private Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            txtQrCode.Text = ""
            dtpManufacture.Value = Nothing
            txtQrCode.Focus()
        End Sub

        Private Sub txtQrCode_Validated(sender As Object, e As EventArgs) Handles txtQrCode.Validated
            If Not IsEmpty(txtQrCode.Text) Then
                RaiseEvent SaveDrugAccept()
                RaiseEvent AddDrugAccept()
                txtQrCode.Focus()
            End If
        End Sub

    End Class

End Namespace