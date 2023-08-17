Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InventoryReportByWarehouse
        Inherits AATM.PresentationLayer.Forms.BfMain

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboBranchIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.cboWarehouseIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.chkAllWarehouses = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(1, 54)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(150, 24)
            Me.lblSupplierCode.TabIndex = 22
            Me.lblSupplierCode.Text = "Warehouse Name"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierCode.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.CLabel4)
            Me.CFlowLayout1.Controls.Add(Me.cboBranchIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblSupplierCode)
            Me.CFlowLayout1.Controls.Add(Me.cboWarehouseIdNo)
            Me.CFlowLayout1.Controls.Add(Me.chkAllWarehouses)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(693, 122)
            Me.CFlowLayout1.TabIndex = 26
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(682, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Inventory Report by Warehouse"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'CLabel4
            '
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(1, 28)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(150, 24)
            Me.CLabel4.TabIndex = 32
            Me.CLabel4.Text = "Branch Name"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'cboBranchIdNo
            '
            Me.cboBranchIdNo.BackColor = System.Drawing.Color.White
            Me.cboBranchIdNo.BegFindValue = Nothing
            Me.cboBranchIdNo.ChangingSearchValueOnly = False
            Me.cboBranchIdNo.CurrentSearchTerm = ""
            Me.cboBranchIdNo.DataValue = Nothing
            Me.cboBranchIdNo.DefaultValue = Nothing
            Me.cboBranchIdNo.DisplayMember = "Name"
            Me.cboBranchIdNo.DropDownHeight = 21
            Me.cboBranchIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboBranchIdNo.EditingMode = False
            Me.cboBranchIdNo.EndFindValue = Nothing
            Me.cboBranchIdNo.FieldDescription = Nothing
            Me.cboBranchIdNo.FieldName = Nothing
            Me.cboBranchIdNo.FilterRule = Nothing
            Me.cboBranchIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboBranchIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboBranchIdNo, True)
            Me.cboBranchIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboBranchIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboBranchIdNo.FormattingEnabled = True
            Me.cboBranchIdNo.HideWhenNotEditingOrAdding = False
            Me.cboBranchIdNo.IgnoreCase = False
            Me.cboBranchIdNo.IntegralHeight = False
            Me.cboBranchIdNo.LimitToList = False
            Me.cboBranchIdNo.LinkedLabel = Nothing
            Me.cboBranchIdNo.Location = New System.Drawing.Point(153, 28)
            Me.cboBranchIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboBranchIdNo.MaxDropDownItems = 1
            Me.cboBranchIdNo.Name = "cboBranchIdNo"
            Me.cboBranchIdNo.OldValue = 0
            Me.cboBranchIdNo.OriginalDataSource = Nothing
            Me.cboBranchIdNo.OriginalList = Nothing
            Me.cboBranchIdNo.OverrideDropDownStyleList = False
            Me.cboBranchIdNo.PreviousSearchTerm = Nothing
            Me.cboBranchIdNo.PropertySelector = Nothing
            Me.cboBranchIdNo.ReadOnlyCombo = False
            Me.cboBranchIdNo.Size = New System.Drawing.Size(530, 24)
            Me.cboBranchIdNo.SuggestBoxHeight = 200
            Me.cboBranchIdNo.SuggestListOrderRule = Nothing
            Me.cboBranchIdNo.TabIndex = 33
            Me.cboBranchIdNo.TextToSearch = Nothing
            Me.cboBranchIdNo.Translatable = False
            Me.cboBranchIdNo.ValueIsMandatory = False
            Me.cboBranchIdNo.ValueIsNullable = False
            Me.cboBranchIdNo.ValueIsNumeric = False
            Me.cboBranchIdNo.ValueMember = "IdNo"
            '
            'cboWarehouseIdNo
            '
            Me.cboWarehouseIdNo.BackColor = System.Drawing.Color.White
            Me.cboWarehouseIdNo.BegFindValue = Nothing
            Me.cboWarehouseIdNo.ChangingSearchValueOnly = False
            Me.cboWarehouseIdNo.CurrentSearchTerm = ""
            Me.cboWarehouseIdNo.DataValue = Nothing
            Me.cboWarehouseIdNo.DefaultValue = Nothing
            Me.cboWarehouseIdNo.DisplayMember = "Name"
            Me.cboWarehouseIdNo.DropDownHeight = 21
            Me.cboWarehouseIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboWarehouseIdNo.Editable = True
            Me.cboWarehouseIdNo.EditingMode = False
            Me.cboWarehouseIdNo.EndFindValue = Nothing
            Me.cboWarehouseIdNo.FieldDescription = Nothing
            Me.cboWarehouseIdNo.FieldName = Nothing
            Me.cboWarehouseIdNo.FilterRule = Nothing
            Me.cboWarehouseIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboWarehouseIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.cboWarehouseIdNo, True)
            Me.cboWarehouseIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboWarehouseIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboWarehouseIdNo.FormattingEnabled = True
            Me.cboWarehouseIdNo.HideWhenNotEditingOrAdding = False
            Me.cboWarehouseIdNo.IgnoreCase = False
            Me.cboWarehouseIdNo.IntegralHeight = False
            Me.cboWarehouseIdNo.LimitToList = False
            Me.cboWarehouseIdNo.LinkedLabel = Nothing
            Me.cboWarehouseIdNo.Location = New System.Drawing.Point(153, 54)
            Me.cboWarehouseIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboWarehouseIdNo.MaxDropDownItems = 1
            Me.cboWarehouseIdNo.Name = "cboWarehouseIdNo"
            Me.cboWarehouseIdNo.OldValue = 0
            Me.cboWarehouseIdNo.OriginalDataSource = Nothing
            Me.cboWarehouseIdNo.OriginalList = Nothing
            Me.cboWarehouseIdNo.OverrideDropDownStyleList = False
            Me.cboWarehouseIdNo.PreviousSearchTerm = Nothing
            Me.cboWarehouseIdNo.PropertySelector = Nothing
            Me.cboWarehouseIdNo.ReadOnlyCombo = False
            Me.cboWarehouseIdNo.Size = New System.Drawing.Size(530, 24)
            Me.cboWarehouseIdNo.SuggestBoxHeight = 200
            Me.cboWarehouseIdNo.SuggestListOrderRule = Nothing
            Me.cboWarehouseIdNo.TabIndex = 29
            Me.cboWarehouseIdNo.TextToSearch = Nothing
            Me.cboWarehouseIdNo.Translatable = False
            Me.cboWarehouseIdNo.ValueIsMandatory = False
            Me.cboWarehouseIdNo.ValueIsNullable = False
            Me.cboWarehouseIdNo.ValueIsNumeric = False
            Me.cboWarehouseIdNo.ValueMember = "IdNo"
            '
            'chkAllWarehouses
            '
            Me.chkAllWarehouses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkAllWarehouses.BackColor = System.Drawing.Color.Transparent
            Me.chkAllWarehouses.BegFindValue = Nothing
            Me.chkAllWarehouses.Checked = False
            Me.chkAllWarehouses.EditingMode = False
            Me.chkAllWarehouses.EndFindValue = Nothing
            Me.chkAllWarehouses.FieldDescription = Nothing
            Me.chkAllWarehouses.FieldName = Nothing
            Me.chkAllWarehouses.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkAllWarehouses.FindEnabled = False
            Me.chkAllWarehouses.IgnoreCase = False
            Me.chkAllWarehouses.LinkedLabel = Nothing
            Me.chkAllWarehouses.Location = New System.Drawing.Point(3, 82)
            Me.chkAllWarehouses.Name = "chkAllWarehouses"
            Me.chkAllWarehouses.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkAllWarehouses.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkAllWarehouses.Size = New System.Drawing.Size(186, 21)
            Me.chkAllWarehouses.TabIndex = 31
            Me.chkAllWarehouses.Text = "Print All Warehouses"
            Me.chkAllWarehouses.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(25, 37)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(150, 25)
            Me.CLabel1.TabIndex = 26
            Me.CLabel1.Text = "Beginning Date :"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(238, 140)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(360, 140)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'InventoryReportByWarehouse
            '
            Me.ClientSize = New System.Drawing.Size(716, 186)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.Name = "InventoryReportByWarehouse"
            Me.Text = "Inventory Report"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents lblSupplierCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents cboWarehouseIdNo As CaComboBox
        Friend WithEvents chkAllWarehouses As UcCheckBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents cboBranchIdNo As CaComboBox
    End Class
End Namespace