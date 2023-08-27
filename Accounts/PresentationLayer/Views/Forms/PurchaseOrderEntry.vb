Imports System.ComponentModel
Imports System.Dynamic
Imports System.Globalization
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class PurchaseOrderEntry
        Implements IPurchaseOrderView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter
        Private _PurchaseOrderDetails As List(Of PurchaseOrderDetailView)

        Public Event ProductCodeChanged(productCode As String, bs As BindingSource) Implements IPurchaseOrderView.ProductCodeChanged
        Public Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String) Implements IPurchaseOrderView.GTinScanned
        Public Event ProductUnitSelection(productIdNo As Int32, bs As BindingSource) Implements IPurchaseOrderView.ProductUnitSelection
        Public Event ProductUnitEditing(productIdNo As Int32) Implements IPurchaseOrderView.ProductUnitEditing
        Public Event RowChanged(productIdNo As Int32) Implements IPurchaseOrderView.RowChanged
        Public Event PostData(idNo As Int32) Implements IPurchaseOrderView.PostData
        Public Event PurchaseOrderTypeChanged(invTransTypeIdNo As Int16) Implements IPurchaseOrderView.PurchaseOrderTypeChanged
        Private Event ProductCodeValidating(productCode As String, control As Windows.Forms.Control) Implements IPurchaseOrderView.ProductCodeValidating
        Private Event ProductNameValidating(productName As String, control As Windows.Forms.Control) Implements IPurchaseOrderView.ProductNameValidating
        Public Property NumberOfUnits As Int16 Implements IPurchaseOrderView.NumberOfUnits
        Public Property ProductCodeIsValid As Boolean Implements IPurchaseOrderView.ProductCodeIsValid
        Public Property ProductNameIsValid As Boolean Implements IPurchaseOrderView.ProductNameIsValid
        Public Property ProductsByCode As DataTable Implements IPurchaseOrderView.ProductsByCode
        Public Property UnitsByCode As Object Implements IPurchaseOrderView.UnitsByCode
        Public Property UnitsByProduct As Object Implements IPurchaseOrderView.UnitsByProduct
        Public Property ValidationErrorText As String Implements IPurchaseOrderView.ValidationErrorText

        'Public Property UnitsByProduct As DataTable Implements IPurchaseOrderView.UnitsByProduct
        'Public Property UnitsByCode As DataTable Implements IPurchaseOrderView.UnitsByCode
        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboSupplierIdNo
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub

#Region "Fields"

        Public Property Amount As Decimal Implements IPurchaseOrderView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime Implements IPurchaseOrderView.DateCreated
            Get
                Try
                    Return Convert.ToDateTime(txtDateCreated.Text)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set
                txtDateCreated.Text = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPurchaseOrderView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property


        Public Property PurchaseOrderDetails As List(Of PurchaseOrderDetailView) Implements IPurchaseOrderView.PurchaseOrderDetails
            Get
                Return _PurchaseOrderDetails
            End Get
            Set
                _PurchaseOrderDetails = Value
                BindPurchaseOrderDetail()
            End Set
        End Property

        Public Property Disapproved As Boolean Implements IPurchaseOrderView.Disapproved
            Get
                Return chkDisapproved.Checked
            End Get
            Set(value As Boolean)
                chkDisapproved.Checked = value
                'If value Then
                '    btnPost.Enabled = False
                'Else
                '    btnPost.Enabled = True
                'End If
            End Set
        End Property

        Public Property Approved As Boolean Implements IPurchaseOrderView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set(value As Boolean)
                chkApproved.Checked = value
                'If value Then
                '    btnPost.Enabled = False
                'Else
                '    btnPost.Enabled = True
                'End If
            End Set
        End Property

        Public Property WarehouseIdNo As Int16 Implements IPurchaseOrderView.WarehouseIdNo
            Get
                Return cboWarehouseIdNo.GetValue(Of Int16)
            End Get
            Set
                cboWarehouseIdNo.SetValue(Value)
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IPurchaseOrderView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                End If
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IPurchaseOrderView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IPurchaseOrderView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property UserIdNo As Int16 Implements IPurchaseOrderView.UserIdNo
            Get
                Return cboUserIdNo.GetValue(Of Int16)()
            End Get
            Set(value As Short)
                cboUserIdNo.SetValue(value)
            End Set
        End Property

        Private Property PurchaseOrderDetailsBs As BindingSource Implements IPurchaseOrderView.PurchaseOrderDetailsBs

        Public WriteOnly Property WarehouseToIdNoEnabled As Boolean Implements IPurchaseOrderView.WarehouseToIdNoEnabled
            Set(value As Boolean)
                cboSupplierIdNo.Visible = value
                lblWarehouseToIdNo.Visible = value
                floInventoryHeader.SetFlowBreak(cboWarehouseIdNo, Not value)
            End Set
        End Property

        Public Property SupplierIdNo As Integer Implements IPurchaseOrderView.SupplierIdNo
            Get
                Return cboSupplierIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboSupplierIdNo.SetValue(value)
            End Set
        End Property

        Public Property Notes As String Implements IPurchaseOrderView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Amount", txtAmount},
         {"Approved", chkApproved},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"IdNo", TxtIdNo},
         {"Disapproved", chkDisapproved},
         {"ReferenceNo", txtReferenceNo},
         {"SupplierIdNo", cboSupplierIdNo},
         {"TransactionDate", dtpTransactionDate},
         {"UserIdNo", cboUserIdNo},
         {"WarehouseIdNo", cboWarehouseIdNo}
         }
        End Sub

        Protected Sub PurchaseOrderUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub PurchaseOrderEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewPurchaseOrderDetails) With {
                .AutoCalc = True
            }
            _footer.ColumnToSum("dgvQuantity", 0) = True
            _footer.ColumnToSum("dgvNetAmount") = True
            _footer.SetAlignment("dgvQuantity", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvNetAmount", ContentAlignment.MiddleRight)
            _footer.SetText("dgvProductName", "Totals ->")
            SetupDgvColumns()
            UpdateTotals()
            If DirectCast(cboWarehouseIdNo.DataSource, System.Data.DataTable).Rows.Count() < 2 Then
                cboWarehouseIdNo.Enabled = False
            Else
                cboWarehouseIdNo.Enabled = True
            End If
            UpdateDgvColumns()
            dgvNetAmount.DisplayOnly = True
        End Sub

        Private Sub BindPurchaseOrderDetail()
            SuspendLayout()
            bsPurchaseOrderDetails.DataSource = Nothing
            DataGridViewPurchaseOrderDetails.Refresh()
            bsPurchaseOrderDetails.DataSource = PurchaseOrderDetails
            bsPurchaseOrderDetails.AllowNew = True
            PurchaseOrderDetailsBs = bsPurchaseOrderDetails
            ResumeLayout()
        End Sub


        Private Sub SetupDgvColumns()
            dgvSequence.DisplayOnly = True
            dgvUnitIdNo.ValueMember = "IdNo"
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.DataSource = UnitsByCode
            dgvUnitIdNo.DisplayStyleForCurrentCellOnly = True
            dgvQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvUnitCost.SetFormat(12, 4)
        End Sub

        Private Overloads Sub Dispose()
            Close()
            '_footer.Dispose()
        End Sub

        Private Sub dataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridViewPurchaseOrderDetails.CellValidating
            If DataGridViewPurchaseOrderDetails.IsCurrentCellDirty() Then
                With DataGridViewPurchaseOrderDetails
                    Dim cColumnName = .CurrentCell.OwningColumn.Name
                    If cColumnName = $"dgvProductCode" Then
                        Dim dgv As CtDataGridView = DataGridViewPurchaseOrderDetails
                        Dim pnt = dgv.PointToScreen(dgv.Location)
                        If Not ValidateProductCode(DataGridViewPurchaseOrderDetails, e) Then
                            e.Cancel = True
                            .Rows(e.RowIndex).ErrorText = ValidationErrorText
                            'DataGridViewPurchaseOrderDetails(e.RowIndex, e.ColumnIndex).ErrorText = ValidationErrorText
                        Else
                            .Rows(e.RowIndex).ErrorText = String.Empty
                        End If
                    ElseIf cColumnName = $"dgvProductName" Then
                        If Not ValidateProductName(DataGridViewPurchaseOrderDetails, e) Then
                            e.Cancel = True
                            ' Set error text to why the cell validating failed.
                            .Rows(e.RowIndex).ErrorText = ValidationErrorText
                            'DataGridViewPurchaseOrderDetails(e.RowIndex, e.ColumnIndex).ErrorText = ValidationErrorText
                            '.EndEdit()
                        Else
                            .Rows(e.RowIndex).ErrorText = String.Empty
                        End If
                    ElseIf cColumnName = $"dgvUnitIdNo" Then
                        '(DataGridViewPurchaseOrderDetails, e)
                    ElseIf cColumnName = $"dgvUnitCost" Then
                        If .CurrentRow.Cells("dgvInventoryIdNo").Value <> 0 Then
                            Messaging.ShowPmMessage(True, "MsgCannotEditInvItems", {"fieldName", Messaging.TranslateCaption("unit cost")})
                            e.Cancel = True
                            .CurrentRow.Cells("dgvUnitCost").Value = DataGridViewPurchaseOrderDetails.OldCellValue
                        End If
                    End If
                End With
            End If
        End Sub

        Private Function ValidateProductName(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs) As Boolean
            Dim valid As Boolean = True
            Dim findText = dgv.CurrentRow.Cells("dgvProductName").EditedFormattedValue
            RaiseEvent ProductNameValidating(findText, DataGridViewPurchaseOrderDetails.EditingControl)
            If ProductNameIsValid Then
                valid = True
            Else
                e.Cancel = True
                valid = False
            End If
            Return valid
        End Function

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseOrderDetails.CellEndEdit
            ProcessCellEndEdit(sender, bsPurchaseOrderDetails)
            UpdateTotals()
        End Sub


        Private Function ValidateProductCode(ByRef dgv As CtDataGridView, ByRef e As DataGridViewCellValidatingEventArgs)
            Dim valid As Boolean
            Dim code As String = dgv.CurrentRow.Cells("dgvProductCode").EditedFormattedValue
            RaiseEvent ProductCodeValidating(code, DataGridViewPurchaseOrderDetails.EditingControl)
            If ProductCodeIsValid Then
                If code Is Nothing Or code = "" Then
                    ' go to next cell (which is the productname)
                Else
                    SendKeys.Send("{Tab}")
                End If
                valid = True
            Else
                valid = False
                e.Cancel = True
            End If
            Return valid
        End Function


        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                Dim netAmount As Decimal = _footer.Value("dgvNetAmount")
                txtAmount.Text = netAmount.ToString("n2")
            End If
        End Sub


        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewPurchaseOrderDetails.UserDeletingRow
            'RaiseEvent UserDeletedRow()
            'UpdateTotals()
        End Sub

        Private Sub OnUserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewPurchaseOrderDetails.UserDeletedRow
            UpdateTotals()
            'UpdateInputVatAmount()
        End Sub

        Private Sub grid_EditingControlShowing(ByVal s As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchaseOrderDetails.EditingControlShowing
            With DataGridViewPurchaseOrderDetails
                Dim cColumnName = .CurrentCell.OwningColumn.Name
                If cColumnName = "dgvUnitIdNo" Then
                    Dim comboBox = TryCast(e.Control, DataGridViewComboBoxEditingControl)
                    If comboBox IsNot Nothing Then
                        RaiseEvent ProductUnitSelection(DataGridViewPurchaseOrderDetails.CurrentRow.Cells("dgvProductIdNo").Value, bsPurchaseOrderDetails)
                        comboBox.DropDownStyle = ComboBoxStyle.DropDown
                        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        comboBox.DataSource = UnitsByProduct
                    End If
                End If
            End With
        End Sub

        'Private _oldCellValue As Object

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewPurchaseOrderDetails.CellBeginEdit
            '_oldCellValue = DataGridViewPurchaseOrderDetails.CurrentCell.Value
            With DataGridViewPurchaseOrderDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name()
                If cColumnName = $"dgvUnitIdNo" Then
                    RaiseEvent ProductUnitEditing(DataGridViewPurchaseOrderDetails.CurrentRow.Cells("dgvProductIdNo").Value)
                End If
            End With
        End Sub

        <System.Security.Permissions.UIPermission(System.Security.Permissions.SecurityAction.LinkDemand, Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)>
        Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

            ' Extract the key code from the key value. 
            Dim key As Keys = keyData And Keys.KeyCode

            ' Handle the ENTER key as if it were a RIGHT ARROW key. 
            'If key = Keys.Enter Then
            '    Return Me.ProcessRightKey(keyData)
            'End If


            Return MyBase.ProcessDialogKey(keyData)

        End Function


        Private WithEvents txtQrText As New DataGridViewTextBoxEditingControl

        Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridViewPurchaseOrderDetails.EditingControlShowing
            If DataGridViewPurchaseOrderDetails.CurrentCell.OwningColumn.Name = "dgvProductName" Then
                txtQrText = CType(DataGridViewPurchaseOrderDetails.EditingControl, DataGridViewTextBoxEditingControl)
            End If
        End Sub

        Private Sub txtQrText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtQrText.KeyPress
            Dim i As Integer = txtQrText.SelectionStart 'save for later use

            Select Case Asc(e.KeyChar)

                'Case 4 'EOT

                '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<EOT>")

                '    Me.txtQrCode.SelectionStart = i + 5

                '    e.Handled = True

                Case 29 'GS

                    txtQrText.Text = txtQrText.Text.Insert(txtQrText.SelectionStart, "<GS>")
                    txtQrText.SelectionStart = i + 5
                    e.Handled = True

                    'Case 30 'RS

                    '    Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<RS>")

                    '    Me.txtQrCode.SelectionStart = i + 5

                    '    e.Handled = True

            End Select
        End Sub

        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurDetailsFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewPurchaseOrderDetails.CellFormatting
            If e.ColumnIndex > 0 Then
                If sender.Columns(e.ColumnIndex).Name.Equals("dgvUnitSalesPrice") Then
                    Dim x = DirectCast(sender, DataGridView).Rows(e.RowIndex)
                    If x IsNot Nothing Then
                        If x.Cells("dgvProductIdNo").Value <> 0 Then
                            If e.Value Is Nothing Or e.Value <= x.Cells("dgvUnitCost").Value Then
                                e.CellStyle.BackColor = Color.Red
                            End If
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub cboInvTransTypeIdNo_SelectedIndexChanged(sender As Object, e As EventArgs)
            UpdateDgvColumns()
        End Sub


        Private Sub UpdateDgvColumns()
            dgvUnitCost.DisplayOnly = False
            dgvUnitCost.UpdateDisplayOnlyControl()
        End Sub

    End Class

End Namespace