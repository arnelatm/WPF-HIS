Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ProductEntry
        Implements IProductView

        Private _lockBranch As Boolean = False
        Private _productUnits As List(Of ProductUnitView)

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = cboCategoryIdNo
        End Sub

        Public Property DateCreated As DateTime? Implements IProductView.DateCreated
            Get
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If

            End Set
        End Property

        Public Property IdNo As Int32 Implements IProductView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ProductCode As String Implements IProductView.ProductCode
            Get
                Return txtProductCode.Text
            End Get
            Set
                txtProductCode.Text = Value
            End Set
        End Property

        Public Overloads Property ProductName As String Implements IProductView.ProductName
            Get
                Return txtProductName.Text
            End Get
            Set
                txtProductName.Text = Value
            End Set
        End Property

        Public Property ProductNameAra As String Implements IProductView.ProductNameAra
            Get
                Return txtProductNameAra.Text
            End Get
            Set
                txtProductNameAra.Text = Value
            End Set
        End Property

        Public Property BaseUnitIdNo As Int16 Implements IProductView.BaseUnitIdNo
            Get
                Return cboBaseUnitIdNo.GetValue(Of Int16)
            End Get
            Set
                cboBaseUnitIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Active As Boolean Implements IProductView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property CategoryIdNo As Int16 Implements IProductView.CategoryIdNo
            Get
                Return cboCategoryIdNo.GetValue(Of Int16)
            End Get
            Set(value As Int16)
                cboCategoryIdNo.SetValue(value)
            End Set
        End Property

        Public Property Barcode As String Implements IProductView.Barcode
            Get
                Return txtBarcode.Text
            End Get
            Set
                txtBarcode.Text = Value
            End Set
        End Property

        Public Property GTIN As String Implements IProductView.GTIN
            Get
                Return txtGTIN.Text
            End Get
            Set
                txtGTIN.Text = Value
                txtGTIN.Text = Value
            End Set
        End Property

        Public Property GTINQrCode As String
            Get
                Return txtGTIN.Text
            End Get
            Set
                txtGTIN.Text = Value
            End Set
        End Property

        Public Property ProductUnits As List(Of ProductUnitView) Implements IProductView.ProductUnits
            Get
                Return _productUnits
            End Get
            Set
                _productUnits = Value
                BindProductUnits()
            End Set
        End Property

        Public Property UnitsByCode As Object Implements IProductView.UnitsByCode

        Public Property UserName As String Implements IProductView.UserName
            Get
                Return txtUserName.Text
            End Get
            Set
                txtUserName.Text = Value
            End Set
        End Property

        Private Sub BindProductUnits()
            bsProductUnits.SuspendBinding()
            bsProductUnits.DataSource = Nothing
            DataGridViewProductUnits.Refresh()
            bsProductUnits.DataSource = ProductUnits
            bsProductUnits.AllowNew = True
            With DataGridViewProductUnits
                .AutoGenerateColumns = False
                .DataSource = bsProductUnits
            End With
            With DataGridViewProductUnits.Columns
                dgvUnitIdNo.DisplayMember = "Name"
                dgvUnitIdNo.ValueMember = "IdNo"
                dgvUnitIdNo.DataSource = UnitsByCode
                dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            bsProductUnits.ResumeBinding()
        End Sub

        Private Sub OnFormLoad() Handles MyBase.Load
            RaiseEvent FilterRecords()
        End Sub

        Protected Overrides Sub BeforeEdit()
            cboBaseUnitIdNo.DisplayOnly = True
            ' editing not allowed for units, can only be changed when newly added
            Refresh()
        End Sub

        Protected Overrides Sub BeforeAdd()
            cboBaseUnitIdNo.DisplayOnly = False
            ' editing not allowed for units, can only be changed when newly added
            Refresh()
        End Sub

        Public Event FilterRecords() Implements IProductView.FilterRecords
        Public Event ChangeBaseUnitButtonClicked() Implements IProductView.ChangeBaseUnitButtonClicked

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"Active", chkActive},
             {"Barcode", txtBarcode},
             {"BaseUnitIdNo", cboBaseUnitIdNo},
             {"CategoryIdNo", cboCategoryIdNo},
             {"DateCreated", txtDateCreated},
             {"GTIN", txtGTIN},
             {"IdNo", TxtIdNo},
             {"ProductCode", txtProductCode},
             {"ProductName", txtProductName},
             {"ProductNameAra", txtProductNameAra}
            }
        End Sub

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            bsProductUnits.ResetBindings(False)
            'If EditingMode Then

            'End If

        End Sub

        Private Sub Gtin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGTIN.KeyPress
            Dim i As Integer = txtGTIN.SelectionStart 'save for later use
            Select Case Asc(e.KeyChar)
                Case 29 'GS
                    txtGTIN.Text = txtGTIN.Text.Insert(txtGTIN.SelectionStart, "<GS>")
                    txtGTIN.SelectionStart = i + 5
                    e.Handled = True
            End Select
        End Sub

        Private Sub txtGTIN_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtGTIN.Validating
            If txtGTIN.Text.Contains("<GS>") Then
                txtGTIN.Text = Accounts.AccountHelpers.ExtractGTin(txtGTIN.Text)
            End If
        End Sub

        Protected Overrides Sub AfterAdd()
            MyBase.AfterAdd()
        End Sub

        Private Sub btnBaseUnitChanger_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnBaseUnitChanger.ClickButtonArea
            RaiseEvent ChangeBaseUnitButtonClicked()
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) _
                Handles DataGridViewProductUnits.UserDeletingRow
            If EditingMode Then
                e.Cancel = True
                AATM.Libraries.Messaging.MessagingService.Show(True, "MsgRowDelExistNotAllowed")
                'Do not allow deletions for units
            End If
        End Sub
    End Class

End Namespace