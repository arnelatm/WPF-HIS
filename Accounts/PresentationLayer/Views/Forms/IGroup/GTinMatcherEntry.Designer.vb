Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GTinMatcherEntry
        Inherits AATM.PresentationLayer.Forms.CFormEntry

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GTinMatcherEntry))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnScanQrCode = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.EventLog1 = New System.Diagnostics.EventLog()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.BnItems = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.btnItemsBnAddNewItem = New System.Windows.Forms.ToolStripButton()
            Me.tsDrugsCount = New System.Windows.Forms.ToolStripLabel()
            Me.btnItemsBnDeleteItem = New System.Windows.Forms.ToolStripButton()
            Me.btnFirstItem = New System.Windows.Forms.ToolStripButton()
            Me.btnPrevItem = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsItemsCurrentRecord = New System.Windows.Forms.ToolStripTextBox()
            Me.tsItemsCount = New System.Windows.Forms.ToolStripLabel()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnNextItem = New System.Windows.Forms.ToolStripButton()
            Me.btnLastItem = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItemDetailsCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel6 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtQtyOnHand = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel9 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblPrice_Cash = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPrice_Cash = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPacking = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPack1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtpack2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtpack3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItemDetailsName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblGenericName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGenericName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblRegistrationCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblDosageForm = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDosageForm = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtStrengthValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblVolume = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.lblPackageType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboPackageType = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.cboPackageSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPackageSize = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboRouteOfAdministration = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.CFlowLayout2 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.BnDrugs = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
            Me.tsDrugsCurrentRecord = New System.Windows.Forms.ToolStripTextBox()
            Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
            Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnDrugBnAddNewItem = New System.Windows.Forms.ToolStripButton()
            Me.btnDrugBnDeleteItem = New System.Windows.Forms.ToolStripButton()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPublicPrice = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugPublicPrice = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugGTin = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel7 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugTradeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel8 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugGenericName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel10 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugRegistrationNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel11 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugDosageForm = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel12 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugStrengthValue = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel13 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugUnitOfStrength = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel14 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel15 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugUnitOfVolume = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel16 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugPackageType = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel17 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugPackageSize = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel18 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDrugRouteOfAdministration = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CFlowLayout3 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.DataGridViewItems = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            Me.DataGridViewDrugs = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.BnItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BnItems.SuspendLayout()
            Me.CFlowLayout2.SuspendLayout()
            CType(Me.BnDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BnDrugs.SuspendLayout()
            Me.CFlowLayout3.SuspendLayout()
            CType(Me.DataGridViewItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridViewDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(106, 26)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = ""
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(100, 21)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIdNo.Location = New System.Drawing.Point(1, 26)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(103, 23)
            Me.lblIdNo.TabIndex = 1
            Me.lblIdNo.Text = "I.D. Number"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'lblGTIN
            '
            Me.lblGTIN.DisplayOnly = True
            Me.lblGTIN.EditingMode = False
            Me.lblGTIN.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGTIN.Location = New System.Drawing.Point(1, 76)
            Me.lblGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGTIN.Name = "lblGTIN"
            Me.lblGTIN.Size = New System.Drawing.Size(103, 23)
            Me.lblGTIN.TabIndex = 36
            Me.lblGTIN.Text = "GTIN"
            Me.lblGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGTIN.Translatable = True
            '
            'btnScanQrCode
            '
            Me.btnScanQrCode.DesignerSelected = False
            Me.CFlowLayout1.SetFlowBreak(Me.btnScanQrCode, True)
            Me.btnScanQrCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnScanQrCode.ImageIndex = 0
            Me.btnScanQrCode.Location = New System.Drawing.Point(255, 75)
            Me.btnScanQrCode.Margin = New System.Windows.Forms.Padding(0)
            Me.btnScanQrCode.Name = "btnScanQrCode"
            Me.btnScanQrCode.OriginalImageName = Nothing
            Me.btnScanQrCode.SecurityKey = ""
            Me.btnScanQrCode.Size = New System.Drawing.Size(90, 20)
            Me.btnScanQrCode.TabIndex = 39
            Me.btnScanQrCode.Text = "Scan Qr Code"
            Me.btnScanQrCode.TextMargin = New System.Windows.Forms.Padding(0)
            '
            'EventLog1
            '
            Me.EventLog1.SynchronizingObject = Me
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.BnItems)
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblCode)
            Me.CFlowLayout1.Controls.Add(Me.TxtItemDetailsCode)
            Me.CFlowLayout1.Controls.Add(Me.CLabel6)
            Me.CFlowLayout1.Controls.Add(Me.txtQtyOnHand)
            Me.CFlowLayout1.Controls.Add(Me.CLabel9)
            Me.CFlowLayout1.Controls.Add(Me.lblPrice_Cash)
            Me.CFlowLayout1.Controls.Add(Me.txtPrice_Cash)
            Me.CFlowLayout1.Controls.Add(Me.lblPacking)
            Me.CFlowLayout1.Controls.Add(Me.txtPack1)
            Me.CFlowLayout1.Controls.Add(Me.txtpack2)
            Me.CFlowLayout1.Controls.Add(Me.txtpack3)
            Me.CFlowLayout1.Controls.Add(Me.lblGTIN)
            Me.CFlowLayout1.Controls.Add(Me.txtGTIN)
            Me.CFlowLayout1.Controls.Add(Me.btnScanQrCode)
            Me.CFlowLayout1.Controls.Add(Me.lblName)
            Me.CFlowLayout1.Controls.Add(Me.TxtItemDetailsName)
            Me.CFlowLayout1.Controls.Add(Me.lblGenericName)
            Me.CFlowLayout1.Controls.Add(Me.txtGenericName)
            Me.CFlowLayout1.Controls.Add(Me.lblRegistrationCode)
            Me.CFlowLayout1.Controls.Add(Me.txtRegistrationNo)
            Me.CFlowLayout1.Controls.Add(Me.lblDosageForm)
            Me.CFlowLayout1.Controls.Add(Me.cboDosageForm)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.txtStrengthValue)
            Me.CFlowLayout1.Controls.Add(Me.lblUnitOfStrength)
            Me.CFlowLayout1.Controls.Add(Me.cboUnitOfStrength)
            Me.CFlowLayout1.Controls.Add(Me.lblVolume)
            Me.CFlowLayout1.Controls.Add(Me.txtVolume)
            Me.CFlowLayout1.Controls.Add(Me.lblUnitOfVolume)
            Me.CFlowLayout1.Controls.Add(Me.cboUnitOfVolume)
            Me.CFlowLayout1.Controls.Add(Me.lblPackageType)
            Me.CFlowLayout1.Controls.Add(Me.cboPackageType)
            Me.CFlowLayout1.Controls.Add(Me.cboPackageSize)
            Me.CFlowLayout1.Controls.Add(Me.txtPackageSize)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.cboRouteOfAdministration)
            Me.CFlowLayout1.Location = New System.Drawing.Point(3, 3)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(617, 283)
            Me.CFlowLayout1.TabIndex = 6
            '
            'BnItems
            '
            Me.BnItems.AddNewItem = Me.btnItemsBnAddNewItem
            Me.BnItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.BnItems.CountItem = Me.tsDrugsCount
            Me.BnItems.DeleteItem = Me.btnItemsBnDeleteItem
            Me.BnItems.Dock = System.Windows.Forms.DockStyle.None
            Me.CFlowLayout1.SetFlowBreak(Me.BnItems, True)
            Me.BnItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFirstItem, Me.btnPrevItem, Me.ToolStripSeparator1, Me.tsItemsCurrentRecord, Me.tsItemsCount, Me.ToolStripSeparator2, Me.btnNextItem, Me.btnLastItem, Me.ToolStripSeparator3, Me.btnItemsBnAddNewItem, Me.btnItemsBnDeleteItem})
            Me.BnItems.Location = New System.Drawing.Point(0, 0)
            Me.BnItems.MoveFirstItem = Me.btnLastItem
            Me.BnItems.MoveLastItem = Me.btnLastItem
            Me.BnItems.MoveNextItem = Me.btnNextItem
            Me.BnItems.MovePreviousItem = Me.btnPrevItem
            Me.BnItems.Name = "BnItems"
            Me.BnItems.PositionItem = Me.tsItemsCurrentRecord
            Me.BnItems.Size = New System.Drawing.Size(255, 25)
            Me.BnItems.TabIndex = 81
            Me.BnItems.Text = "BindingNavigator2"
            '
            'btnItemsBnAddNewItem
            '
            Me.btnItemsBnAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnItemsBnAddNewItem.Image = CType(resources.GetObject("btnItemsBnAddNewItem.Image"), System.Drawing.Image)
            Me.btnItemsBnAddNewItem.Name = "btnItemsBnAddNewItem"
            Me.btnItemsBnAddNewItem.RightToLeftAutoMirrorImage = True
            Me.btnItemsBnAddNewItem.Size = New System.Drawing.Size(23, 22)
            Me.btnItemsBnAddNewItem.Text = "Add new"
            '
            'tsDrugsCount
            '
            Me.tsDrugsCount.Name = "tsDrugsCount"
            Me.tsDrugsCount.Size = New System.Drawing.Size(35, 22)
            Me.tsDrugsCount.Text = "of {0}"
            Me.tsDrugsCount.ToolTipText = "Total number of items"
            '
            'btnItemsBnDeleteItem
            '
            Me.btnItemsBnDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnItemsBnDeleteItem.Image = CType(resources.GetObject("btnItemsBnDeleteItem.Image"), System.Drawing.Image)
            Me.btnItemsBnDeleteItem.Name = "btnItemsBnDeleteItem"
            Me.btnItemsBnDeleteItem.RightToLeftAutoMirrorImage = True
            Me.btnItemsBnDeleteItem.Size = New System.Drawing.Size(23, 22)
            Me.btnItemsBnDeleteItem.Text = "Delete"
            '
            'btnFirstItem
            '
            Me.btnFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnFirstItem.Image = CType(resources.GetObject("btnFirstItem.Image"), System.Drawing.Image)
            Me.btnFirstItem.Name = "btnFirstItem"
            Me.btnFirstItem.RightToLeftAutoMirrorImage = True
            Me.btnFirstItem.Size = New System.Drawing.Size(23, 22)
            Me.btnFirstItem.Text = "Move first"
            '
            'btnPrevItem
            '
            Me.btnPrevItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnPrevItem.Image = CType(resources.GetObject("btnPrevItem.Image"), System.Drawing.Image)
            Me.btnPrevItem.Name = "btnPrevItem"
            Me.btnPrevItem.RightToLeftAutoMirrorImage = True
            Me.btnPrevItem.Size = New System.Drawing.Size(23, 22)
            Me.btnPrevItem.Text = "Move previous"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'tsItemsCurrentRecord
            '
            Me.tsItemsCurrentRecord.AccessibleName = "Position"
            Me.tsItemsCurrentRecord.AutoSize = False
            Me.tsItemsCurrentRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.tsItemsCurrentRecord.Name = "tsItemsCurrentRecord"
            Me.tsItemsCurrentRecord.Size = New System.Drawing.Size(50, 23)
            Me.tsItemsCurrentRecord.Text = "0"
            Me.tsItemsCurrentRecord.ToolTipText = "Current position"
            '
            'tsItemsCount
            '
            Me.tsItemsCount.Name = "tsItemsCount"
            Me.tsItemsCount.Size = New System.Drawing.Size(35, 22)
            Me.tsItemsCount.Text = "of {0}"
            Me.tsItemsCount.ToolTipText = "Total number of items"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'btnNextItem
            '
            Me.btnNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnNextItem.Image = CType(resources.GetObject("btnNextItem.Image"), System.Drawing.Image)
            Me.btnNextItem.Name = "btnNextItem"
            Me.btnNextItem.RightToLeftAutoMirrorImage = True
            Me.btnNextItem.Size = New System.Drawing.Size(23, 22)
            Me.btnNextItem.Text = "Move next"
            '
            'btnLastItem
            '
            Me.btnLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnLastItem.Image = CType(resources.GetObject("btnLastItem.Image"), System.Drawing.Image)
            Me.btnLastItem.Name = "btnLastItem"
            Me.btnLastItem.RightToLeftAutoMirrorImage = True
            Me.btnLastItem.Size = New System.Drawing.Size(23, 22)
            Me.btnLastItem.Text = "Move last"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCode.Location = New System.Drawing.Point(208, 26)
            Me.lblCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(59, 21)
            Me.lblCode.TabIndex = 39
            Me.lblCode.Text = "Code"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCode.Translatable = True
            '
            'TxtItemDetailsCode
            '
            Me.TxtItemDetailsCode.BackColor = System.Drawing.Color.White
            Me.TxtItemDetailsCode.BegFindValue = Nothing
            Me.TxtItemDetailsCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtItemDetailsCode.ComputedValue = False
            Me.TxtItemDetailsCode.CustomFormat = Nothing
            Me.TxtItemDetailsCode.DataBoundControl = True
            Me.TxtItemDetailsCode.DisplayOnly = True
            Me.TxtItemDetailsCode.EditingMode = True
            Me.TxtItemDetailsCode.EndFindValue = Nothing
            Me.TxtItemDetailsCode.FieldDescription = Nothing
            Me.TxtItemDetailsCode.FieldName = "Item_Code"
            Me.TxtItemDetailsCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItemDetailsCode.FindEnabled = True
            Me.TxtItemDetailsCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TxtItemDetailsCode.ForeColor = System.Drawing.Color.Black
            Me.TxtItemDetailsCode.LinkedLabel = Nothing
            Me.TxtItemDetailsCode.Location = New System.Drawing.Point(269, 26)
            Me.TxtItemDetailsCode.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItemDetailsCode.MaximumValue = Nothing
            Me.TxtItemDetailsCode.MinimumValue = Nothing
            Me.TxtItemDetailsCode.Name = "TxtItemDetailsCode"
            Me.TxtItemDetailsCode.OldValue = Nothing
            Me.TxtItemDetailsCode.OverrideMaxLength = 0
            Me.TxtItemDetailsCode.ReadOnly = True
            Me.TxtItemDetailsCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItemDetailsCode.Size = New System.Drawing.Size(74, 21)
            Me.TxtItemDetailsCode.TabIndex = 38
            Me.TxtItemDetailsCode.Translatable = False
            '
            'CLabel6
            '
            Me.CLabel6.DisplayOnly = True
            Me.CLabel6.EditingMode = False
            Me.CLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel6.Location = New System.Drawing.Point(345, 26)
            Me.CLabel6.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel6.Name = "CLabel6"
            Me.CLabel6.Size = New System.Drawing.Size(103, 23)
            Me.CLabel6.TabIndex = 79
            Me.CLabel6.Text = "Quantity On Hand"
            Me.CLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel6.Translatable = True
            '
            'txtQtyOnHand
            '
            Me.txtQtyOnHand.BackColor = System.Drawing.Color.White
            Me.txtQtyOnHand.BegFindValue = Nothing
            Me.txtQtyOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQtyOnHand.ComputedValue = False
            Me.txtQtyOnHand.CustomFormat = Nothing
            Me.txtQtyOnHand.DataBoundControl = True
            Me.txtQtyOnHand.EditingMode = True
            Me.txtQtyOnHand.EndFindValue = Nothing
            Me.txtQtyOnHand.FieldDescription = Nothing
            Me.txtQtyOnHand.FieldName = Nothing
            Me.txtQtyOnHand.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtQtyOnHand.FindEnabled = False
            Me.txtQtyOnHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQtyOnHand.ForeColor = System.Drawing.Color.Black
            Me.txtQtyOnHand.LinkedLabel = Nothing
            Me.txtQtyOnHand.Location = New System.Drawing.Point(450, 26)
            Me.txtQtyOnHand.Margin = New System.Windows.Forms.Padding(1)
            Me.txtQtyOnHand.MaximumValue = Nothing
            Me.txtQtyOnHand.MinimumValue = Nothing
            Me.txtQtyOnHand.Name = "txtQtyOnHand"
            Me.txtQtyOnHand.OldValue = Nothing
            Me.txtQtyOnHand.OverrideMaxLength = 0
            Me.txtQtyOnHand.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtQtyOnHand.Size = New System.Drawing.Size(86, 21)
            Me.txtQtyOnHand.TabIndex = 80
            Me.txtQtyOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtQtyOnHand.Translatable = False
            '
            'CLabel9
            '
            Me.CLabel9.AutoSize = True
            Me.CLabel9.DisplayOnly = True
            Me.CLabel9.EditingMode = False
            Me.CLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel9.Location = New System.Drawing.Point(538, 26)
            Me.CLabel9.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel9.Name = "CLabel9"
            Me.CLabel9.Size = New System.Drawing.Size(23, 16)
            Me.CLabel9.TabIndex = 81
            Me.CLabel9.Text = "box"
            Me.CLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel9.Translatable = True
            '
            'lblPrice_Cash
            '
            Me.lblPrice_Cash.DisplayOnly = True
            Me.lblPrice_Cash.EditingMode = False
            Me.lblPrice_Cash.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrice_Cash.Location = New System.Drawing.Point(1, 51)
            Me.lblPrice_Cash.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrice_Cash.Name = "lblPrice_Cash"
            Me.lblPrice_Cash.Size = New System.Drawing.Size(103, 21)
            Me.lblPrice_Cash.TabIndex = 77
            Me.lblPrice_Cash.Text = "Price"
            Me.lblPrice_Cash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrice_Cash.Translatable = True
            '
            'txtPrice_Cash
            '
            Me.txtPrice_Cash.BackColor = System.Drawing.Color.White
            Me.txtPrice_Cash.BegFindValue = Nothing
            Me.txtPrice_Cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrice_Cash.ComputedValue = False
            Me.txtPrice_Cash.CustomFormat = Nothing
            Me.txtPrice_Cash.DataBoundControl = True
            Me.txtPrice_Cash.DisplayOnly = True
            Me.txtPrice_Cash.EditingMode = True
            Me.txtPrice_Cash.EndFindValue = Nothing
            Me.txtPrice_Cash.FieldDescription = Nothing
            Me.txtPrice_Cash.FieldName = Nothing
            Me.txtPrice_Cash.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrice_Cash.FindEnabled = False
            Me.txtPrice_Cash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPrice_Cash.ForeColor = System.Drawing.Color.Black
            Me.txtPrice_Cash.LinkedLabel = Nothing
            Me.txtPrice_Cash.Location = New System.Drawing.Point(106, 51)
            Me.txtPrice_Cash.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrice_Cash.MaximumValue = Nothing
            Me.txtPrice_Cash.MinimumValue = Nothing
            Me.txtPrice_Cash.Name = "txtPrice_Cash"
            Me.txtPrice_Cash.OldValue = Nothing
            Me.txtPrice_Cash.OverrideMaxLength = 0
            Me.txtPrice_Cash.ReadOnly = True
            Me.txtPrice_Cash.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrice_Cash.Size = New System.Drawing.Size(100, 21)
            Me.txtPrice_Cash.TabIndex = 78
            Me.txtPrice_Cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPrice_Cash.Translatable = False
            '
            'lblPacking
            '
            Me.lblPacking.DisplayOnly = True
            Me.lblPacking.EditingMode = False
            Me.lblPacking.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPacking.Location = New System.Drawing.Point(208, 51)
            Me.lblPacking.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPacking.Name = "lblPacking"
            Me.lblPacking.Size = New System.Drawing.Size(240, 23)
            Me.lblPacking.TabIndex = 75
            Me.lblPacking.Text = "Packing"
            Me.lblPacking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPacking.Translatable = True
            '
            'txtPack1
            '
            Me.txtPack1.BackColor = System.Drawing.Color.White
            Me.txtPack1.BegFindValue = Nothing
            Me.txtPack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPack1.ComputedValue = False
            Me.txtPack1.CustomFormat = Nothing
            Me.txtPack1.DataBoundControl = True
            Me.txtPack1.DisplayOnly = True
            Me.txtPack1.EditingMode = True
            Me.txtPack1.EndFindValue = Nothing
            Me.txtPack1.FieldDescription = Nothing
            Me.txtPack1.FieldName = "Item_Code"
            Me.txtPack1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPack1.FindEnabled = True
            Me.txtPack1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPack1.ForeColor = System.Drawing.Color.Black
            Me.txtPack1.LinkedLabel = Nothing
            Me.txtPack1.Location = New System.Drawing.Point(450, 51)
            Me.txtPack1.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPack1.MaximumValue = Nothing
            Me.txtPack1.MinimumValue = Nothing
            Me.txtPack1.Name = "txtPack1"
            Me.txtPack1.OldValue = Nothing
            Me.txtPack1.OverrideMaxLength = 0
            Me.txtPack1.ReadOnly = True
            Me.txtPack1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPack1.Size = New System.Drawing.Size(30, 21)
            Me.txtPack1.TabIndex = 72
            Me.txtPack1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtPack1.Translatable = False
            '
            'txtpack2
            '
            Me.txtpack2.BackColor = System.Drawing.Color.White
            Me.txtpack2.BegFindValue = Nothing
            Me.txtpack2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtpack2.ComputedValue = False
            Me.txtpack2.CustomFormat = Nothing
            Me.txtpack2.DataBoundControl = True
            Me.txtpack2.DisplayOnly = True
            Me.txtpack2.EditingMode = True
            Me.txtpack2.EndFindValue = Nothing
            Me.txtpack2.FieldDescription = Nothing
            Me.txtpack2.FieldName = "Item_Code"
            Me.txtpack2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtpack2.FindEnabled = True
            Me.txtpack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtpack2.ForeColor = System.Drawing.Color.Black
            Me.txtpack2.LinkedLabel = Nothing
            Me.txtpack2.Location = New System.Drawing.Point(482, 51)
            Me.txtpack2.Margin = New System.Windows.Forms.Padding(1)
            Me.txtpack2.MaximumValue = Nothing
            Me.txtpack2.MinimumValue = Nothing
            Me.txtpack2.Name = "txtpack2"
            Me.txtpack2.OldValue = Nothing
            Me.txtpack2.OverrideMaxLength = 0
            Me.txtpack2.ReadOnly = True
            Me.txtpack2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtpack2.Size = New System.Drawing.Size(30, 21)
            Me.txtpack2.TabIndex = 73
            Me.txtpack2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtpack2.Translatable = False
            '
            'txtpack3
            '
            Me.txtpack3.BackColor = System.Drawing.Color.White
            Me.txtpack3.BegFindValue = Nothing
            Me.txtpack3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtpack3.ComputedValue = False
            Me.txtpack3.CustomFormat = Nothing
            Me.txtpack3.DataBoundControl = True
            Me.txtpack3.DisplayOnly = True
            Me.txtpack3.EditingMode = True
            Me.txtpack3.EndFindValue = Nothing
            Me.txtpack3.FieldDescription = Nothing
            Me.txtpack3.FieldName = "Item_Code"
            Me.txtpack3.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtpack3.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtpack3, True)
            Me.txtpack3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtpack3.ForeColor = System.Drawing.Color.Black
            Me.txtpack3.LinkedLabel = Nothing
            Me.txtpack3.Location = New System.Drawing.Point(514, 51)
            Me.txtpack3.Margin = New System.Windows.Forms.Padding(1)
            Me.txtpack3.MaximumValue = Nothing
            Me.txtpack3.MinimumValue = Nothing
            Me.txtpack3.Name = "txtpack3"
            Me.txtpack3.OldValue = Nothing
            Me.txtpack3.OverrideMaxLength = 0
            Me.txtpack3.ReadOnly = True
            Me.txtpack3.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtpack3.Size = New System.Drawing.Size(30, 21)
            Me.txtpack3.TabIndex = 74
            Me.txtpack3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtpack3.Translatable = False
            '
            'txtGTIN
            '
            Me.txtGTIN.BackColor = System.Drawing.Color.White
            Me.txtGTIN.BegFindValue = Nothing
            Me.txtGTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGTIN.ComputedValue = False
            Me.txtGTIN.CustomFormat = Nothing
            Me.txtGTIN.DataBoundControl = True
            Me.txtGTIN.EditingMode = True
            Me.txtGTIN.EndFindValue = Nothing
            Me.txtGTIN.FieldDescription = Nothing
            Me.txtGTIN.FieldName = Nothing
            Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTIN.FindEnabled = True
            Me.txtGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGTIN.ForeColor = System.Drawing.Color.Black
            Me.txtGTIN.LinkedLabel = Nothing
            Me.txtGTIN.Location = New System.Drawing.Point(106, 76)
            Me.txtGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGTIN.MaximumValue = Nothing
            Me.txtGTIN.MinimumValue = Nothing
            Me.txtGTIN.Name = "txtGTIN"
            Me.txtGTIN.OldValue = ""
            Me.txtGTIN.OverrideMaxLength = 0
            Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTIN.Size = New System.Drawing.Size(148, 21)
            Me.txtGTIN.TabIndex = 37
            Me.txtGTIN.Translatable = False
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblName.Location = New System.Drawing.Point(1, 101)
            Me.lblName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(103, 23)
            Me.lblName.TabIndex = 41
            Me.lblName.Text = "Name"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblName.Translatable = True
            '
            'TxtItemDetailsName
            '
            Me.TxtItemDetailsName.BackColor = System.Drawing.Color.White
            Me.TxtItemDetailsName.BegFindValue = Nothing
            Me.TxtItemDetailsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtItemDetailsName.ComputedValue = False
            Me.TxtItemDetailsName.CustomFormat = Nothing
            Me.TxtItemDetailsName.DataBoundControl = True
            Me.TxtItemDetailsName.EditingMode = True
            Me.TxtItemDetailsName.EndFindValue = Nothing
            Me.TxtItemDetailsName.FieldDescription = Nothing
            Me.TxtItemDetailsName.FieldName = Nothing
            Me.TxtItemDetailsName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItemDetailsName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtItemDetailsName, True)
            Me.TxtItemDetailsName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TxtItemDetailsName.ForeColor = System.Drawing.Color.Black
            Me.TxtItemDetailsName.LinkedLabel = Nothing
            Me.TxtItemDetailsName.Location = New System.Drawing.Point(106, 101)
            Me.TxtItemDetailsName.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItemDetailsName.MaximumValue = Nothing
            Me.TxtItemDetailsName.MinimumValue = Nothing
            Me.TxtItemDetailsName.Name = "TxtItemDetailsName"
            Me.TxtItemDetailsName.OldValue = Nothing
            Me.TxtItemDetailsName.OverrideMaxLength = 0
            Me.TxtItemDetailsName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItemDetailsName.Size = New System.Drawing.Size(497, 21)
            Me.TxtItemDetailsName.TabIndex = 40
            Me.TxtItemDetailsName.Translatable = False
            '
            'lblGenericName
            '
            Me.lblGenericName.DisplayOnly = True
            Me.lblGenericName.EditingMode = False
            Me.lblGenericName.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGenericName.Location = New System.Drawing.Point(1, 126)
            Me.lblGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGenericName.Name = "lblGenericName"
            Me.lblGenericName.Size = New System.Drawing.Size(103, 23)
            Me.lblGenericName.TabIndex = 44
            Me.lblGenericName.Text = "Generic Name"
            Me.lblGenericName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGenericName.Translatable = True
            '
            'txtGenericName
            '
            Me.txtGenericName.BackColor = System.Drawing.Color.White
            Me.txtGenericName.BegFindValue = Nothing
            Me.txtGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGenericName.ComputedValue = False
            Me.txtGenericName.CustomFormat = Nothing
            Me.txtGenericName.DataBoundControl = True
            Me.txtGenericName.EditingMode = True
            Me.txtGenericName.EndFindValue = Nothing
            Me.txtGenericName.FieldDescription = Nothing
            Me.txtGenericName.FieldName = Nothing
            Me.txtGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGenericName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtGenericName, True)
            Me.txtGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtGenericName.ForeColor = System.Drawing.Color.Black
            Me.txtGenericName.LinkedLabel = Nothing
            Me.txtGenericName.Location = New System.Drawing.Point(106, 126)
            Me.txtGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGenericName.MaximumValue = Nothing
            Me.txtGenericName.MinimumValue = Nothing
            Me.txtGenericName.Name = "txtGenericName"
            Me.txtGenericName.OldValue = ""
            Me.txtGenericName.OverrideMaxLength = 0
            Me.txtGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGenericName.Size = New System.Drawing.Size(497, 21)
            Me.txtGenericName.TabIndex = 43
            Me.txtGenericName.Translatable = False
            '
            'lblRegistrationCode
            '
            Me.lblRegistrationCode.DisplayOnly = True
            Me.lblRegistrationCode.EditingMode = False
            Me.lblRegistrationCode.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRegistrationCode.Location = New System.Drawing.Point(1, 151)
            Me.lblRegistrationCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblRegistrationCode.Name = "lblRegistrationCode"
            Me.lblRegistrationCode.Size = New System.Drawing.Size(103, 23)
            Me.lblRegistrationCode.TabIndex = 62
            Me.lblRegistrationCode.Text = "Registration Number"
            Me.lblRegistrationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblRegistrationCode.Translatable = True
            '
            'txtRegistrationNo
            '
            Me.txtRegistrationNo.BackColor = System.Drawing.Color.White
            Me.txtRegistrationNo.BegFindValue = Nothing
            Me.txtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtRegistrationNo.ComputedValue = False
            Me.txtRegistrationNo.CustomFormat = Nothing
            Me.txtRegistrationNo.DataBoundControl = True
            Me.txtRegistrationNo.EditingMode = True
            Me.txtRegistrationNo.EndFindValue = Nothing
            Me.txtRegistrationNo.FieldDescription = Nothing
            Me.txtRegistrationNo.FieldName = Nothing
            Me.txtRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtRegistrationNo.FindEnabled = True
            Me.txtRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRegistrationNo.ForeColor = System.Drawing.Color.Black
            Me.txtRegistrationNo.LinkedLabel = Nothing
            Me.txtRegistrationNo.Location = New System.Drawing.Point(106, 151)
            Me.txtRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtRegistrationNo.MaximumValue = Nothing
            Me.txtRegistrationNo.MinimumValue = Nothing
            Me.txtRegistrationNo.Name = "txtRegistrationNo"
            Me.txtRegistrationNo.OldValue = ""
            Me.txtRegistrationNo.OverrideMaxLength = 0
            Me.txtRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtRegistrationNo.Size = New System.Drawing.Size(148, 21)
            Me.txtRegistrationNo.TabIndex = 69
            Me.txtRegistrationNo.Translatable = False
            '
            'lblDosageForm
            '
            Me.lblDosageForm.DisplayOnly = True
            Me.lblDosageForm.EditingMode = False
            Me.lblDosageForm.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDosageForm.Location = New System.Drawing.Point(256, 151)
            Me.lblDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.lblDosageForm.Name = "lblDosageForm"
            Me.lblDosageForm.Size = New System.Drawing.Size(129, 16)
            Me.lblDosageForm.TabIndex = 60
            Me.lblDosageForm.Text = "Dosage Form"
            Me.lblDosageForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblDosageForm.Translatable = True
            '
            'cboDosageForm
            '
            Me.cboDosageForm.BackColor = System.Drawing.Color.White
            Me.cboDosageForm.BegFindValue = Nothing
            Me.cboDosageForm.ChangingSearchValueOnly = False
            Me.cboDosageForm.CurrentSearchTerm = ""
            Me.cboDosageForm.DataValue = Nothing
            Me.cboDosageForm.DefaultValue = Nothing
            Me.cboDosageForm.DisplayMember = "Name"
            Me.cboDosageForm.Editable = True
            Me.cboDosageForm.EditingMode = True
            Me.cboDosageForm.EndFindValue = Nothing
            Me.cboDosageForm.FieldDescription = Nothing
            Me.cboDosageForm.FieldName = Nothing
            Me.cboDosageForm.FilterRule = Nothing
            Me.cboDosageForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDosageForm.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboDosageForm, True)
            Me.cboDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDosageForm.ForeColor = System.Drawing.Color.Black
            Me.cboDosageForm.FormattingEnabled = True
            Me.cboDosageForm.HideWhenNotEditingOrAdding = False
            Me.cboDosageForm.IgnoreCase = False
            Me.cboDosageForm.IntegralHeight = False
            Me.cboDosageForm.LimitToList = False
            Me.cboDosageForm.LinkedLabel = Nothing
            Me.cboDosageForm.Location = New System.Drawing.Point(387, 151)
            Me.cboDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDosageForm.Name = "cboDosageForm"
            Me.cboDosageForm.OldValue = 0
            Me.cboDosageForm.OriginalDataSource = Nothing
            Me.cboDosageForm.OriginalList = Nothing
            Me.cboDosageForm.OverrideDropDownStyleList = False
            Me.cboDosageForm.PreviousSearchTerm = Nothing
            Me.cboDosageForm.PropertySelector = Nothing
            Me.cboDosageForm.Size = New System.Drawing.Size(216, 23)
            Me.cboDosageForm.SuggestBoxHeight = 200
            Me.cboDosageForm.SuggestCharCount = 0
            Me.cboDosageForm.SuggestListOrderRule = Nothing
            Me.cboDosageForm.TabIndex = 65
            Me.cboDosageForm.TextToSearch = Nothing
            Me.cboDosageForm.Translatable = False
            Me.cboDosageForm.ValueIsMandatory = False
            Me.cboDosageForm.ValueIsNullable = False
            Me.cboDosageForm.ValueIsNumeric = False
            Me.cboDosageForm.ValueMember = "Name"
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel1.Location = New System.Drawing.Point(1, 176)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(103, 23)
            Me.CLabel1.TabIndex = 51
            Me.CLabel1.Text = "Strength value"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtStrengthValue
            '
            Me.txtStrengthValue.BackColor = System.Drawing.Color.White
            Me.txtStrengthValue.BegFindValue = Nothing
            Me.txtStrengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtStrengthValue.ComputedValue = False
            Me.txtStrengthValue.CustomFormat = Nothing
            Me.txtStrengthValue.DataBoundControl = True
            Me.txtStrengthValue.EditingMode = True
            Me.txtStrengthValue.EndFindValue = Nothing
            Me.txtStrengthValue.FieldDescription = Nothing
            Me.txtStrengthValue.FieldName = Nothing
            Me.txtStrengthValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtStrengthValue.FindEnabled = True
            Me.txtStrengthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtStrengthValue.ForeColor = System.Drawing.Color.Black
            Me.txtStrengthValue.LinkedLabel = Nothing
            Me.txtStrengthValue.Location = New System.Drawing.Point(106, 176)
            Me.txtStrengthValue.Margin = New System.Windows.Forms.Padding(1)
            Me.txtStrengthValue.MaximumValue = Nothing
            Me.txtStrengthValue.MinimumValue = Nothing
            Me.txtStrengthValue.Name = "txtStrengthValue"
            Me.txtStrengthValue.OldValue = Nothing
            Me.txtStrengthValue.OverrideMaxLength = 0
            Me.txtStrengthValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtStrengthValue.Size = New System.Drawing.Size(148, 21)
            Me.txtStrengthValue.TabIndex = 71
            Me.txtStrengthValue.Translatable = False
            '
            'lblUnitOfStrength
            '
            Me.lblUnitOfStrength.DisplayOnly = True
            Me.lblUnitOfStrength.EditingMode = False
            Me.lblUnitOfStrength.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitOfStrength.Location = New System.Drawing.Point(256, 176)
            Me.lblUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUnitOfStrength.Name = "lblUnitOfStrength"
            Me.lblUnitOfStrength.Size = New System.Drawing.Size(129, 23)
            Me.lblUnitOfStrength.TabIndex = 55
            Me.lblUnitOfStrength.Text = "Unit of Strength"
            Me.lblUnitOfStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUnitOfStrength.Translatable = True
            '
            'cboUnitOfStrength
            '
            Me.cboUnitOfStrength.BackColor = System.Drawing.Color.White
            Me.cboUnitOfStrength.BegFindValue = Nothing
            Me.cboUnitOfStrength.ChangingSearchValueOnly = False
            Me.cboUnitOfStrength.CurrentSearchTerm = ""
            Me.cboUnitOfStrength.DataValue = Nothing
            Me.cboUnitOfStrength.DefaultValue = Nothing
            Me.cboUnitOfStrength.DisplayMember = "Name"
            Me.cboUnitOfStrength.Editable = True
            Me.cboUnitOfStrength.EditingMode = True
            Me.cboUnitOfStrength.EndFindValue = Nothing
            Me.cboUnitOfStrength.FieldDescription = Nothing
            Me.cboUnitOfStrength.FieldName = Nothing
            Me.cboUnitOfStrength.FilterRule = Nothing
            Me.cboUnitOfStrength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnitOfStrength.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboUnitOfStrength, True)
            Me.cboUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboUnitOfStrength.ForeColor = System.Drawing.Color.Black
            Me.cboUnitOfStrength.FormattingEnabled = True
            Me.cboUnitOfStrength.HideWhenNotEditingOrAdding = False
            Me.cboUnitOfStrength.IgnoreCase = False
            Me.cboUnitOfStrength.IntegralHeight = False
            Me.cboUnitOfStrength.LimitToList = False
            Me.cboUnitOfStrength.LinkedLabel = Nothing
            Me.cboUnitOfStrength.Location = New System.Drawing.Point(387, 176)
            Me.cboUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUnitOfStrength.Name = "cboUnitOfStrength"
            Me.cboUnitOfStrength.OldValue = 0
            Me.cboUnitOfStrength.OriginalDataSource = Nothing
            Me.cboUnitOfStrength.OriginalList = Nothing
            Me.cboUnitOfStrength.OverrideDropDownStyleList = False
            Me.cboUnitOfStrength.PreviousSearchTerm = Nothing
            Me.cboUnitOfStrength.PropertySelector = Nothing
            Me.cboUnitOfStrength.Size = New System.Drawing.Size(216, 23)
            Me.cboUnitOfStrength.SuggestBoxHeight = 200
            Me.cboUnitOfStrength.SuggestCharCount = 0
            Me.cboUnitOfStrength.SuggestListOrderRule = Nothing
            Me.cboUnitOfStrength.TabIndex = 70
            Me.cboUnitOfStrength.TextToSearch = Nothing
            Me.cboUnitOfStrength.Translatable = False
            Me.cboUnitOfStrength.ValueIsMandatory = False
            Me.cboUnitOfStrength.ValueIsNullable = False
            Me.cboUnitOfStrength.ValueIsNumeric = False
            Me.cboUnitOfStrength.ValueMember = "Name"
            '
            'lblVolume
            '
            Me.lblVolume.DisplayOnly = True
            Me.lblVolume.EditingMode = False
            Me.lblVolume.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblVolume.Location = New System.Drawing.Point(1, 201)
            Me.lblVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.lblVolume.Name = "lblVolume"
            Me.lblVolume.Size = New System.Drawing.Size(103, 23)
            Me.lblVolume.TabIndex = 56
            Me.lblVolume.Text = "Volume"
            Me.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblVolume.Translatable = True
            '
            'txtVolume
            '
            Me.txtVolume.BackColor = System.Drawing.Color.White
            Me.txtVolume.BegFindValue = Nothing
            Me.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtVolume.ComputedValue = False
            Me.txtVolume.CustomFormat = Nothing
            Me.txtVolume.DataBoundControl = True
            Me.txtVolume.EditingMode = True
            Me.txtVolume.EndFindValue = Nothing
            Me.txtVolume.FieldDescription = Nothing
            Me.txtVolume.FieldName = Nothing
            Me.txtVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtVolume.FindEnabled = True
            Me.txtVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtVolume.ForeColor = System.Drawing.Color.Black
            Me.txtVolume.LinkedLabel = Nothing
            Me.txtVolume.Location = New System.Drawing.Point(106, 201)
            Me.txtVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtVolume.MaximumValue = Nothing
            Me.txtVolume.MinimumValue = Nothing
            Me.txtVolume.Name = "txtVolume"
            Me.txtVolume.OldValue = Nothing
            Me.txtVolume.OverrideMaxLength = 0
            Me.txtVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtVolume.Size = New System.Drawing.Size(149, 21)
            Me.txtVolume.TabIndex = 64
            Me.txtVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtVolume.Translatable = False
            '
            'lblUnitOfVolume
            '
            Me.lblUnitOfVolume.DisplayOnly = True
            Me.lblUnitOfVolume.EditingMode = False
            Me.lblUnitOfVolume.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUnitOfVolume.Location = New System.Drawing.Point(257, 201)
            Me.lblUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.lblUnitOfVolume.Name = "lblUnitOfVolume"
            Me.lblUnitOfVolume.Size = New System.Drawing.Size(128, 23)
            Me.lblUnitOfVolume.TabIndex = 57
            Me.lblUnitOfVolume.Text = "Unit Of Volume"
            Me.lblUnitOfVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblUnitOfVolume.Translatable = True
            '
            'cboUnitOfVolume
            '
            Me.cboUnitOfVolume.BackColor = System.Drawing.Color.White
            Me.cboUnitOfVolume.BegFindValue = Nothing
            Me.cboUnitOfVolume.ChangingSearchValueOnly = False
            Me.cboUnitOfVolume.CurrentSearchTerm = ""
            Me.cboUnitOfVolume.DataValue = Nothing
            Me.cboUnitOfVolume.DefaultValue = Nothing
            Me.cboUnitOfVolume.DisplayMember = "Name"
            Me.cboUnitOfVolume.Editable = True
            Me.cboUnitOfVolume.EditingMode = True
            Me.cboUnitOfVolume.EndFindValue = Nothing
            Me.cboUnitOfVolume.FieldDescription = Nothing
            Me.cboUnitOfVolume.FieldName = Nothing
            Me.cboUnitOfVolume.FilterRule = Nothing
            Me.cboUnitOfVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboUnitOfVolume.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboUnitOfVolume, True)
            Me.cboUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboUnitOfVolume.ForeColor = System.Drawing.Color.Black
            Me.cboUnitOfVolume.FormattingEnabled = True
            Me.cboUnitOfVolume.HideWhenNotEditingOrAdding = False
            Me.cboUnitOfVolume.IgnoreCase = False
            Me.cboUnitOfVolume.IntegralHeight = False
            Me.cboUnitOfVolume.LimitToList = False
            Me.cboUnitOfVolume.LinkedLabel = Nothing
            Me.cboUnitOfVolume.Location = New System.Drawing.Point(387, 201)
            Me.cboUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.cboUnitOfVolume.Name = "cboUnitOfVolume"
            Me.cboUnitOfVolume.OldValue = 0
            Me.cboUnitOfVolume.OriginalDataSource = Nothing
            Me.cboUnitOfVolume.OriginalList = Nothing
            Me.cboUnitOfVolume.OverrideDropDownStyleList = False
            Me.cboUnitOfVolume.PreviousSearchTerm = Nothing
            Me.cboUnitOfVolume.PropertySelector = Nothing
            Me.cboUnitOfVolume.Size = New System.Drawing.Size(216, 23)
            Me.cboUnitOfVolume.SuggestBoxHeight = 200
            Me.cboUnitOfVolume.SuggestCharCount = 0
            Me.cboUnitOfVolume.SuggestListOrderRule = Nothing
            Me.cboUnitOfVolume.TabIndex = 68
            Me.cboUnitOfVolume.TextToSearch = Nothing
            Me.cboUnitOfVolume.Translatable = False
            Me.cboUnitOfVolume.ValueIsMandatory = False
            Me.cboUnitOfVolume.ValueIsNullable = False
            Me.cboUnitOfVolume.ValueIsNumeric = False
            Me.cboUnitOfVolume.ValueMember = "Name"
            '
            'lblPackageType
            '
            Me.lblPackageType.DisplayOnly = True
            Me.lblPackageType.EditingMode = False
            Me.lblPackageType.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPackageType.Location = New System.Drawing.Point(1, 226)
            Me.lblPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPackageType.Name = "lblPackageType"
            Me.lblPackageType.Size = New System.Drawing.Size(103, 23)
            Me.lblPackageType.TabIndex = 58
            Me.lblPackageType.Text = "Package Type"
            Me.lblPackageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPackageType.Translatable = True
            '
            'cboPackageType
            '
            Me.cboPackageType.BackColor = System.Drawing.Color.White
            Me.cboPackageType.BegFindValue = Nothing
            Me.cboPackageType.ChangingSearchValueOnly = False
            Me.cboPackageType.CurrentSearchTerm = ""
            Me.cboPackageType.DataValue = Nothing
            Me.cboPackageType.DefaultValue = Nothing
            Me.cboPackageType.DisplayMember = "Name"
            Me.cboPackageType.Editable = True
            Me.cboPackageType.EditingMode = True
            Me.cboPackageType.EndFindValue = Nothing
            Me.cboPackageType.FieldDescription = Nothing
            Me.cboPackageType.FieldName = Nothing
            Me.cboPackageType.FilterRule = Nothing
            Me.cboPackageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPackageType.FindEnabled = True
            Me.cboPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPackageType.ForeColor = System.Drawing.Color.Black
            Me.cboPackageType.FormattingEnabled = True
            Me.cboPackageType.HideWhenNotEditingOrAdding = False
            Me.cboPackageType.IgnoreCase = False
            Me.cboPackageType.IntegralHeight = False
            Me.cboPackageType.LimitToList = False
            Me.cboPackageType.LinkedLabel = Nothing
            Me.cboPackageType.Location = New System.Drawing.Point(106, 226)
            Me.cboPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPackageType.Name = "cboPackageType"
            Me.cboPackageType.OldValue = 0
            Me.cboPackageType.OriginalDataSource = Nothing
            Me.cboPackageType.OriginalList = Nothing
            Me.cboPackageType.OverrideDropDownStyleList = False
            Me.cboPackageType.PreviousSearchTerm = Nothing
            Me.cboPackageType.PropertySelector = Nothing
            Me.cboPackageType.Size = New System.Drawing.Size(148, 23)
            Me.cboPackageType.SuggestBoxHeight = 200
            Me.cboPackageType.SuggestCharCount = 0
            Me.cboPackageType.SuggestListOrderRule = Nothing
            Me.cboPackageType.TabIndex = 66
            Me.cboPackageType.TextToSearch = Nothing
            Me.cboPackageType.Translatable = False
            Me.cboPackageType.ValueIsMandatory = False
            Me.cboPackageType.ValueIsNullable = False
            Me.cboPackageType.ValueIsNumeric = False
            Me.cboPackageType.ValueMember = "Name"
            '
            'cboPackageSize
            '
            Me.cboPackageSize.DisplayOnly = True
            Me.cboPackageSize.EditingMode = False
            Me.cboPackageSize.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPackageSize.Location = New System.Drawing.Point(256, 226)
            Me.cboPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.cboPackageSize.Name = "cboPackageSize"
            Me.cboPackageSize.Size = New System.Drawing.Size(129, 23)
            Me.cboPackageSize.TabIndex = 59
            Me.cboPackageSize.Text = "Package Size"
            Me.cboPackageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.cboPackageSize.Translatable = True
            '
            'txtPackageSize
            '
            Me.txtPackageSize.BackColor = System.Drawing.Color.White
            Me.txtPackageSize.BegFindValue = Nothing
            Me.txtPackageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPackageSize.ComputedValue = False
            Me.txtPackageSize.CustomFormat = Nothing
            Me.txtPackageSize.DataBoundControl = True
            Me.txtPackageSize.EditingMode = True
            Me.txtPackageSize.EndFindValue = Nothing
            Me.txtPackageSize.FieldDescription = Nothing
            Me.txtPackageSize.FieldName = Nothing
            Me.txtPackageSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPackageSize.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtPackageSize, True)
            Me.txtPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPackageSize.ForeColor = System.Drawing.Color.Black
            Me.txtPackageSize.LinkedLabel = Nothing
            Me.txtPackageSize.Location = New System.Drawing.Point(387, 226)
            Me.txtPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPackageSize.MaximumValue = Nothing
            Me.txtPackageSize.MinimumValue = Nothing
            Me.txtPackageSize.Name = "txtPackageSize"
            Me.txtPackageSize.OldValue = Nothing
            Me.txtPackageSize.OverrideMaxLength = 0
            Me.txtPackageSize.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPackageSize.Size = New System.Drawing.Size(216, 21)
            Me.txtPackageSize.TabIndex = 67
            Me.txtPackageSize.Translatable = False
            '
            'CLabel3
            '
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel3.Location = New System.Drawing.Point(1, 251)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(103, 23)
            Me.CLabel3.TabIndex = 63
            Me.CLabel3.Text = "Route of Administration"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'cboRouteOfAdministration
            '
            Me.cboRouteOfAdministration.BackColor = System.Drawing.Color.White
            Me.cboRouteOfAdministration.BegFindValue = Nothing
            Me.cboRouteOfAdministration.ChangingSearchValueOnly = False
            Me.cboRouteOfAdministration.CurrentSearchTerm = ""
            Me.cboRouteOfAdministration.DataValue = Nothing
            Me.cboRouteOfAdministration.DefaultValue = Nothing
            Me.cboRouteOfAdministration.DisplayMember = "Name"
            Me.cboRouteOfAdministration.Editable = True
            Me.cboRouteOfAdministration.EditingMode = True
            Me.cboRouteOfAdministration.EndFindValue = Nothing
            Me.cboRouteOfAdministration.FieldDescription = Nothing
            Me.cboRouteOfAdministration.FieldName = Nothing
            Me.cboRouteOfAdministration.FilterRule = Nothing
            Me.cboRouteOfAdministration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboRouteOfAdministration.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.cboRouteOfAdministration, True)
            Me.cboRouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboRouteOfAdministration.ForeColor = System.Drawing.Color.Black
            Me.cboRouteOfAdministration.FormattingEnabled = True
            Me.cboRouteOfAdministration.HideWhenNotEditingOrAdding = False
            Me.cboRouteOfAdministration.IgnoreCase = False
            Me.cboRouteOfAdministration.IntegralHeight = False
            Me.cboRouteOfAdministration.LimitToList = False
            Me.cboRouteOfAdministration.LinkedLabel = Nothing
            Me.cboRouteOfAdministration.Location = New System.Drawing.Point(106, 251)
            Me.cboRouteOfAdministration.Margin = New System.Windows.Forms.Padding(1)
            Me.cboRouteOfAdministration.Name = "cboRouteOfAdministration"
            Me.cboRouteOfAdministration.OldValue = 0
            Me.cboRouteOfAdministration.OriginalDataSource = Nothing
            Me.cboRouteOfAdministration.OriginalList = Nothing
            Me.cboRouteOfAdministration.OverrideDropDownStyleList = False
            Me.cboRouteOfAdministration.PreviousSearchTerm = Nothing
            Me.cboRouteOfAdministration.PropertySelector = Nothing
            Me.cboRouteOfAdministration.Size = New System.Drawing.Size(497, 23)
            Me.cboRouteOfAdministration.SuggestBoxHeight = 200
            Me.cboRouteOfAdministration.SuggestCharCount = 0
            Me.cboRouteOfAdministration.SuggestListOrderRule = Nothing
            Me.cboRouteOfAdministration.TabIndex = 53
            Me.cboRouteOfAdministration.TextToSearch = Nothing
            Me.cboRouteOfAdministration.Translatable = False
            Me.cboRouteOfAdministration.ValueIsMandatory = False
            Me.cboRouteOfAdministration.ValueIsNullable = False
            Me.cboRouteOfAdministration.ValueIsNumeric = False
            Me.cboRouteOfAdministration.ValueMember = "Name"
            '
            'CFlowLayout2
            '
            Me.CFlowLayout2.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout2.Controls.Add(Me.BnDrugs)
            Me.CFlowLayout2.Controls.Add(Me.CLabel4)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugIdNo)
            Me.CFlowLayout2.Controls.Add(Me.lblPublicPrice)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugPublicPrice)
            Me.CFlowLayout2.Controls.Add(Me.CLabel5)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugGTin)
            Me.CFlowLayout2.Controls.Add(Me.CLabel7)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugTradeName)
            Me.CFlowLayout2.Controls.Add(Me.CLabel8)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugGenericName)
            Me.CFlowLayout2.Controls.Add(Me.CLabel10)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugRegistrationNo)
            Me.CFlowLayout2.Controls.Add(Me.CLabel11)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugDosageForm)
            Me.CFlowLayout2.Controls.Add(Me.CLabel12)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugStrengthValue)
            Me.CFlowLayout2.Controls.Add(Me.CLabel13)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugUnitOfStrength)
            Me.CFlowLayout2.Controls.Add(Me.CLabel14)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugVolume)
            Me.CFlowLayout2.Controls.Add(Me.CLabel15)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugUnitOfVolume)
            Me.CFlowLayout2.Controls.Add(Me.CLabel16)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugPackageType)
            Me.CFlowLayout2.Controls.Add(Me.CLabel17)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugPackageSize)
            Me.CFlowLayout2.Controls.Add(Me.CLabel18)
            Me.CFlowLayout2.Controls.Add(Me.txtDrugRouteOfAdministration)
            Me.CFlowLayout2.Location = New System.Drawing.Point(626, 3)
            Me.CFlowLayout2.Name = "CFlowLayout2"
            Me.CFlowLayout2.Size = New System.Drawing.Size(636, 283)
            Me.CFlowLayout2.TabIndex = 38
            '
            'BnDrugs
            '
            Me.BnDrugs.AddNewItem = Nothing
            Me.BnDrugs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.BnDrugs.CountItem = Me.tsDrugsCount
            Me.BnDrugs.DeleteItem = Nothing
            Me.BnDrugs.Dock = System.Windows.Forms.DockStyle.None
            Me.CFlowLayout2.SetFlowBreak(Me.BnDrugs, True)
            Me.BnDrugs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.tsDrugsCurrentRecord, Me.tsDrugsCount, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.btnDrugBnAddNewItem, Me.btnDrugBnDeleteItem})
            Me.BnDrugs.Location = New System.Drawing.Point(0, 0)
            Me.BnDrugs.MoveFirstItem = Me.BindingNavigatorMoveNextItem
            Me.BnDrugs.MoveLastItem = Me.BindingNavigatorMoveLastItem
            Me.BnDrugs.MoveNextItem = Me.BindingNavigatorMoveNextItem
            Me.BnDrugs.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
            Me.BnDrugs.Name = "BnDrugs"
            Me.BnDrugs.PositionItem = Me.tsDrugsCurrentRecord
            Me.BnDrugs.Size = New System.Drawing.Size(255, 25)
            Me.BnDrugs.TabIndex = 80
            Me.BnDrugs.Text = "BindingNavigator1"
            '
            'BindingNavigatorMoveFirstItem
            '
            Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
            Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveFirstItem.Text = "of {0}"
            '
            'BindingNavigatorMovePreviousItem
            '
            Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
            Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMovePreviousItem.Text = "of {0}"
            '
            'BindingNavigatorSeparator
            '
            Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
            Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
            '
            'tsDrugsCurrentRecord
            '
            Me.tsDrugsCurrentRecord.AccessibleName = "Position"
            Me.tsDrugsCurrentRecord.AutoSize = False
            Me.tsDrugsCurrentRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.tsDrugsCurrentRecord.Name = "tsDrugsCurrentRecord"
            Me.tsDrugsCurrentRecord.Size = New System.Drawing.Size(50, 23)
            Me.tsDrugsCurrentRecord.Text = "0"
            Me.tsDrugsCurrentRecord.ToolTipText = "Current position"
            '
            'BindingNavigatorSeparator1
            '
            Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
            Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'BindingNavigatorMoveNextItem
            '
            Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
            Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveNextItem.Text = "of {0}"
            '
            'BindingNavigatorMoveLastItem
            '
            Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
            Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
            Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
            Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
            Me.BindingNavigatorMoveLastItem.Text = "of {0}"
            '
            'BindingNavigatorSeparator2
            '
            Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
            Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'btnDrugBnAddNewItem
            '
            Me.btnDrugBnAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnDrugBnAddNewItem.Image = CType(resources.GetObject("btnDrugBnAddNewItem.Image"), System.Drawing.Image)
            Me.btnDrugBnAddNewItem.Name = "btnDrugBnAddNewItem"
            Me.btnDrugBnAddNewItem.RightToLeftAutoMirrorImage = True
            Me.btnDrugBnAddNewItem.Size = New System.Drawing.Size(23, 22)
            Me.btnDrugBnAddNewItem.Text = "Add new"
            '
            'btnDrugBnDeleteItem
            '
            Me.btnDrugBnDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnDrugBnDeleteItem.Image = CType(resources.GetObject("btnDrugBnDeleteItem.Image"), System.Drawing.Image)
            Me.btnDrugBnDeleteItem.Name = "btnDrugBnDeleteItem"
            Me.btnDrugBnDeleteItem.RightToLeftAutoMirrorImage = True
            Me.btnDrugBnDeleteItem.Size = New System.Drawing.Size(23, 22)
            Me.btnDrugBnDeleteItem.Text = "of {0}"
            '
            'CLabel4
            '
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel4.Location = New System.Drawing.Point(1, 26)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(102, 23)
            Me.CLabel4.TabIndex = 1
            Me.CLabel4.Text = "I.D. Number"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'txtDrugIdNo
            '
            Me.txtDrugIdNo.BackColor = System.Drawing.Color.White
            Me.txtDrugIdNo.BegFindValue = Nothing
            Me.txtDrugIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugIdNo.ComputedValue = False
            Me.txtDrugIdNo.CustomFormat = Nothing
            Me.txtDrugIdNo.DataBoundControl = True
            Me.txtDrugIdNo.DisplayOnly = True
            Me.txtDrugIdNo.EditingMode = True
            Me.txtDrugIdNo.EndFindValue = Nothing
            Me.txtDrugIdNo.FieldDescription = Nothing
            Me.txtDrugIdNo.FieldName = Nothing
            Me.txtDrugIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugIdNo.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugIdNo, True)
            Me.txtDrugIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtDrugIdNo.LinkedLabel = Nothing
            Me.txtDrugIdNo.Location = New System.Drawing.Point(105, 26)
            Me.txtDrugIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugIdNo.MaximumValue = Nothing
            Me.txtDrugIdNo.MinimumValue = Nothing
            Me.txtDrugIdNo.Name = "txtDrugIdNo"
            Me.txtDrugIdNo.OldValue = ""
            Me.txtDrugIdNo.OverrideMaxLength = 0
            Me.txtDrugIdNo.ReadOnly = True
            Me.txtDrugIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugIdNo.Size = New System.Drawing.Size(100, 21)
            Me.txtDrugIdNo.TabIndex = 0
            Me.txtDrugIdNo.Translatable = False
            '
            'lblPublicPrice
            '
            Me.lblPublicPrice.DisplayOnly = True
            Me.lblPublicPrice.EditingMode = False
            Me.lblPublicPrice.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPublicPrice.Location = New System.Drawing.Point(1, 51)
            Me.lblPublicPrice.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPublicPrice.Name = "lblPublicPrice"
            Me.lblPublicPrice.Size = New System.Drawing.Size(102, 23)
            Me.lblPublicPrice.TabIndex = 74
            Me.lblPublicPrice.Text = "Price"
            Me.lblPublicPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPublicPrice.Translatable = True
            '
            'txtDrugPublicPrice
            '
            Me.txtDrugPublicPrice.BackColor = System.Drawing.Color.White
            Me.txtDrugPublicPrice.BegFindValue = Nothing
            Me.txtDrugPublicPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugPublicPrice.ComputedValue = False
            Me.txtDrugPublicPrice.CustomFormat = Nothing
            Me.txtDrugPublicPrice.DataBoundControl = True
            Me.txtDrugPublicPrice.EditingMode = True
            Me.txtDrugPublicPrice.EndFindValue = Nothing
            Me.txtDrugPublicPrice.FieldDescription = Nothing
            Me.txtDrugPublicPrice.FieldName = Nothing
            Me.txtDrugPublicPrice.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugPublicPrice.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugPublicPrice, True)
            Me.txtDrugPublicPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugPublicPrice.ForeColor = System.Drawing.Color.Black
            Me.txtDrugPublicPrice.LinkedLabel = Nothing
            Me.txtDrugPublicPrice.Location = New System.Drawing.Point(105, 51)
            Me.txtDrugPublicPrice.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugPublicPrice.MaximumValue = Nothing
            Me.txtDrugPublicPrice.MinimumValue = Nothing
            Me.txtDrugPublicPrice.Name = "txtDrugPublicPrice"
            Me.txtDrugPublicPrice.OldValue = Nothing
            Me.txtDrugPublicPrice.OverrideMaxLength = 0
            Me.txtDrugPublicPrice.ReadOnly = True
            Me.txtDrugPublicPrice.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugPublicPrice.Size = New System.Drawing.Size(100, 21)
            Me.txtDrugPublicPrice.TabIndex = 73
            Me.txtDrugPublicPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtDrugPublicPrice.Translatable = False
            '
            'CLabel5
            '
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel5.Location = New System.Drawing.Point(1, 76)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(102, 23)
            Me.CLabel5.TabIndex = 36
            Me.CLabel5.Text = "GTIN"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'txtDrugGTin
            '
            Me.txtDrugGTin.BackColor = System.Drawing.Color.White
            Me.txtDrugGTin.BegFindValue = Nothing
            Me.txtDrugGTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugGTin.ComputedValue = False
            Me.txtDrugGTin.CustomFormat = Nothing
            Me.txtDrugGTin.DataBoundControl = True
            Me.txtDrugGTin.EditingMode = True
            Me.txtDrugGTin.EndFindValue = Nothing
            Me.txtDrugGTin.FieldDescription = Nothing
            Me.txtDrugGTin.FieldName = Nothing
            Me.txtDrugGTin.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugGTin.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugGTin, True)
            Me.txtDrugGTin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugGTin.ForeColor = System.Drawing.Color.Black
            Me.txtDrugGTin.LinkedLabel = Nothing
            Me.txtDrugGTin.Location = New System.Drawing.Point(105, 76)
            Me.txtDrugGTin.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugGTin.MaximumValue = Nothing
            Me.txtDrugGTin.MinimumValue = Nothing
            Me.txtDrugGTin.Name = "txtDrugGTin"
            Me.txtDrugGTin.OldValue = ""
            Me.txtDrugGTin.OverrideMaxLength = 0
            Me.txtDrugGTin.ReadOnly = True
            Me.txtDrugGTin.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugGTin.Size = New System.Drawing.Size(148, 21)
            Me.txtDrugGTin.TabIndex = 37
            Me.txtDrugGTin.Translatable = False
            '
            'CLabel7
            '
            Me.CLabel7.DisplayOnly = True
            Me.CLabel7.EditingMode = False
            Me.CLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel7.Location = New System.Drawing.Point(1, 101)
            Me.CLabel7.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel7.Name = "CLabel7"
            Me.CLabel7.Size = New System.Drawing.Size(102, 23)
            Me.CLabel7.TabIndex = 41
            Me.CLabel7.Text = "Name"
            Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel7.Translatable = True
            '
            'txtDrugTradeName
            '
            Me.txtDrugTradeName.BackColor = System.Drawing.Color.White
            Me.txtDrugTradeName.BegFindValue = Nothing
            Me.txtDrugTradeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugTradeName.ComputedValue = False
            Me.txtDrugTradeName.CustomFormat = Nothing
            Me.txtDrugTradeName.DataBoundControl = True
            Me.txtDrugTradeName.EditingMode = True
            Me.txtDrugTradeName.EndFindValue = Nothing
            Me.txtDrugTradeName.FieldDescription = Nothing
            Me.txtDrugTradeName.FieldName = Nothing
            Me.txtDrugTradeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugTradeName.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugTradeName, True)
            Me.txtDrugTradeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugTradeName.ForeColor = System.Drawing.Color.Black
            Me.txtDrugTradeName.LinkedLabel = Nothing
            Me.txtDrugTradeName.Location = New System.Drawing.Point(105, 101)
            Me.txtDrugTradeName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugTradeName.MaximumValue = Nothing
            Me.txtDrugTradeName.MinimumValue = Nothing
            Me.txtDrugTradeName.Name = "txtDrugTradeName"
            Me.txtDrugTradeName.OldValue = Nothing
            Me.txtDrugTradeName.OverrideMaxLength = 0
            Me.txtDrugTradeName.ReadOnly = True
            Me.txtDrugTradeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugTradeName.Size = New System.Drawing.Size(518, 21)
            Me.txtDrugTradeName.TabIndex = 40
            Me.txtDrugTradeName.Translatable = False
            '
            'CLabel8
            '
            Me.CLabel8.DisplayOnly = True
            Me.CLabel8.EditingMode = False
            Me.CLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel8.Location = New System.Drawing.Point(1, 126)
            Me.CLabel8.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel8.Name = "CLabel8"
            Me.CLabel8.Size = New System.Drawing.Size(102, 23)
            Me.CLabel8.TabIndex = 44
            Me.CLabel8.Text = "Generic Name"
            Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel8.Translatable = True
            '
            'txtDrugGenericName
            '
            Me.txtDrugGenericName.BackColor = System.Drawing.Color.White
            Me.txtDrugGenericName.BegFindValue = Nothing
            Me.txtDrugGenericName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugGenericName.ComputedValue = False
            Me.txtDrugGenericName.CustomFormat = Nothing
            Me.txtDrugGenericName.DataBoundControl = True
            Me.txtDrugGenericName.EditingMode = True
            Me.txtDrugGenericName.EndFindValue = Nothing
            Me.txtDrugGenericName.FieldDescription = Nothing
            Me.txtDrugGenericName.FieldName = Nothing
            Me.txtDrugGenericName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugGenericName.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugGenericName, True)
            Me.txtDrugGenericName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugGenericName.ForeColor = System.Drawing.Color.Black
            Me.txtDrugGenericName.LinkedLabel = Nothing
            Me.txtDrugGenericName.Location = New System.Drawing.Point(105, 126)
            Me.txtDrugGenericName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugGenericName.MaximumValue = Nothing
            Me.txtDrugGenericName.MinimumValue = Nothing
            Me.txtDrugGenericName.Name = "txtDrugGenericName"
            Me.txtDrugGenericName.OldValue = "0"
            Me.txtDrugGenericName.OverrideMaxLength = 0
            Me.txtDrugGenericName.ReadOnly = True
            Me.txtDrugGenericName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugGenericName.Size = New System.Drawing.Size(518, 21)
            Me.txtDrugGenericName.TabIndex = 53
            Me.txtDrugGenericName.Translatable = False
            '
            'CLabel10
            '
            Me.CLabel10.DisplayOnly = True
            Me.CLabel10.EditingMode = False
            Me.CLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel10.Location = New System.Drawing.Point(1, 151)
            Me.CLabel10.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel10.Name = "CLabel10"
            Me.CLabel10.Size = New System.Drawing.Size(102, 23)
            Me.CLabel10.TabIndex = 62
            Me.CLabel10.Text = "Registration Number"
            Me.CLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel10.Translatable = True
            '
            'txtDrugRegistrationNo
            '
            Me.txtDrugRegistrationNo.BackColor = System.Drawing.Color.White
            Me.txtDrugRegistrationNo.BegFindValue = Nothing
            Me.txtDrugRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugRegistrationNo.ComputedValue = False
            Me.txtDrugRegistrationNo.CustomFormat = Nothing
            Me.txtDrugRegistrationNo.DataBoundControl = True
            Me.txtDrugRegistrationNo.EditingMode = True
            Me.txtDrugRegistrationNo.EndFindValue = Nothing
            Me.txtDrugRegistrationNo.FieldDescription = Nothing
            Me.txtDrugRegistrationNo.FieldName = Nothing
            Me.txtDrugRegistrationNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugRegistrationNo.FindEnabled = False
            Me.txtDrugRegistrationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugRegistrationNo.ForeColor = System.Drawing.Color.Black
            Me.txtDrugRegistrationNo.LinkedLabel = Nothing
            Me.txtDrugRegistrationNo.Location = New System.Drawing.Point(105, 151)
            Me.txtDrugRegistrationNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugRegistrationNo.MaximumValue = Nothing
            Me.txtDrugRegistrationNo.MinimumValue = Nothing
            Me.txtDrugRegistrationNo.Name = "txtDrugRegistrationNo"
            Me.txtDrugRegistrationNo.OldValue = ""
            Me.txtDrugRegistrationNo.OverrideMaxLength = 0
            Me.txtDrugRegistrationNo.ReadOnly = True
            Me.txtDrugRegistrationNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugRegistrationNo.Size = New System.Drawing.Size(148, 21)
            Me.txtDrugRegistrationNo.TabIndex = 69
            Me.txtDrugRegistrationNo.Translatable = False
            '
            'CLabel11
            '
            Me.CLabel11.DisplayOnly = True
            Me.CLabel11.EditingMode = False
            Me.CLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel11.Location = New System.Drawing.Point(255, 151)
            Me.CLabel11.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel11.Name = "CLabel11"
            Me.CLabel11.Size = New System.Drawing.Size(115, 23)
            Me.CLabel11.TabIndex = 60
            Me.CLabel11.Text = "Dosage Form"
            Me.CLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel11.Translatable = True
            '
            'txtDrugDosageForm
            '
            Me.txtDrugDosageForm.BackColor = System.Drawing.Color.White
            Me.txtDrugDosageForm.BegFindValue = Nothing
            Me.txtDrugDosageForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugDosageForm.ComputedValue = False
            Me.txtDrugDosageForm.CustomFormat = Nothing
            Me.txtDrugDosageForm.DataBoundControl = True
            Me.txtDrugDosageForm.EditingMode = True
            Me.txtDrugDosageForm.EndFindValue = Nothing
            Me.txtDrugDosageForm.FieldDescription = Nothing
            Me.txtDrugDosageForm.FieldName = Nothing
            Me.txtDrugDosageForm.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugDosageForm.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugDosageForm, True)
            Me.txtDrugDosageForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugDosageForm.ForeColor = System.Drawing.Color.Black
            Me.txtDrugDosageForm.LinkedLabel = Nothing
            Me.txtDrugDosageForm.Location = New System.Drawing.Point(372, 151)
            Me.txtDrugDosageForm.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugDosageForm.MaximumValue = Nothing
            Me.txtDrugDosageForm.MinimumValue = Nothing
            Me.txtDrugDosageForm.Name = "txtDrugDosageForm"
            Me.txtDrugDosageForm.OldValue = "0"
            Me.txtDrugDosageForm.OverrideMaxLength = 0
            Me.txtDrugDosageForm.ReadOnly = True
            Me.txtDrugDosageForm.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugDosageForm.Size = New System.Drawing.Size(251, 21)
            Me.txtDrugDosageForm.TabIndex = 65
            Me.txtDrugDosageForm.Translatable = False
            '
            'CLabel12
            '
            Me.CLabel12.DisplayOnly = True
            Me.CLabel12.EditingMode = False
            Me.CLabel12.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel12.Location = New System.Drawing.Point(1, 176)
            Me.CLabel12.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel12.Name = "CLabel12"
            Me.CLabel12.Size = New System.Drawing.Size(102, 23)
            Me.CLabel12.TabIndex = 51
            Me.CLabel12.Text = "Strength value"
            Me.CLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel12.Translatable = True
            '
            'txtDrugStrengthValue
            '
            Me.txtDrugStrengthValue.BackColor = System.Drawing.Color.White
            Me.txtDrugStrengthValue.BegFindValue = Nothing
            Me.txtDrugStrengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugStrengthValue.ComputedValue = False
            Me.txtDrugStrengthValue.CustomFormat = Nothing
            Me.txtDrugStrengthValue.DataBoundControl = True
            Me.txtDrugStrengthValue.EditingMode = True
            Me.txtDrugStrengthValue.EndFindValue = Nothing
            Me.txtDrugStrengthValue.FieldDescription = Nothing
            Me.txtDrugStrengthValue.FieldName = Nothing
            Me.txtDrugStrengthValue.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugStrengthValue.FindEnabled = False
            Me.txtDrugStrengthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugStrengthValue.ForeColor = System.Drawing.Color.Black
            Me.txtDrugStrengthValue.LinkedLabel = Nothing
            Me.txtDrugStrengthValue.Location = New System.Drawing.Point(105, 176)
            Me.txtDrugStrengthValue.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugStrengthValue.MaximumValue = Nothing
            Me.txtDrugStrengthValue.MinimumValue = Nothing
            Me.txtDrugStrengthValue.Name = "txtDrugStrengthValue"
            Me.txtDrugStrengthValue.OldValue = Nothing
            Me.txtDrugStrengthValue.OverrideMaxLength = 0
            Me.txtDrugStrengthValue.ReadOnly = True
            Me.txtDrugStrengthValue.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugStrengthValue.Size = New System.Drawing.Size(148, 21)
            Me.txtDrugStrengthValue.TabIndex = 71
            Me.txtDrugStrengthValue.Translatable = False
            '
            'CLabel13
            '
            Me.CLabel13.DisplayOnly = True
            Me.CLabel13.EditingMode = False
            Me.CLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel13.Location = New System.Drawing.Point(255, 176)
            Me.CLabel13.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel13.Name = "CLabel13"
            Me.CLabel13.Size = New System.Drawing.Size(115, 23)
            Me.CLabel13.TabIndex = 55
            Me.CLabel13.Text = "Unit of Strength"
            Me.CLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel13.Translatable = True
            '
            'txtDrugUnitOfStrength
            '
            Me.txtDrugUnitOfStrength.BackColor = System.Drawing.Color.White
            Me.txtDrugUnitOfStrength.BegFindValue = Nothing
            Me.txtDrugUnitOfStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugUnitOfStrength.ComputedValue = False
            Me.txtDrugUnitOfStrength.CustomFormat = Nothing
            Me.txtDrugUnitOfStrength.DataBoundControl = True
            Me.txtDrugUnitOfStrength.EditingMode = True
            Me.txtDrugUnitOfStrength.EndFindValue = Nothing
            Me.txtDrugUnitOfStrength.FieldDescription = Nothing
            Me.txtDrugUnitOfStrength.FieldName = Nothing
            Me.txtDrugUnitOfStrength.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugUnitOfStrength.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugUnitOfStrength, True)
            Me.txtDrugUnitOfStrength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugUnitOfStrength.ForeColor = System.Drawing.Color.Black
            Me.txtDrugUnitOfStrength.LinkedLabel = Nothing
            Me.txtDrugUnitOfStrength.Location = New System.Drawing.Point(372, 176)
            Me.txtDrugUnitOfStrength.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugUnitOfStrength.MaximumValue = Nothing
            Me.txtDrugUnitOfStrength.MinimumValue = Nothing
            Me.txtDrugUnitOfStrength.Name = "txtDrugUnitOfStrength"
            Me.txtDrugUnitOfStrength.OldValue = "0"
            Me.txtDrugUnitOfStrength.OverrideMaxLength = 0
            Me.txtDrugUnitOfStrength.ReadOnly = True
            Me.txtDrugUnitOfStrength.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugUnitOfStrength.Size = New System.Drawing.Size(251, 21)
            Me.txtDrugUnitOfStrength.TabIndex = 70
            Me.txtDrugUnitOfStrength.Translatable = False
            '
            'CLabel14
            '
            Me.CLabel14.DisplayOnly = True
            Me.CLabel14.EditingMode = False
            Me.CLabel14.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel14.Location = New System.Drawing.Point(1, 201)
            Me.CLabel14.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel14.Name = "CLabel14"
            Me.CLabel14.Size = New System.Drawing.Size(102, 23)
            Me.CLabel14.TabIndex = 56
            Me.CLabel14.Text = "Volume"
            Me.CLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel14.Translatable = True
            '
            'txtDrugVolume
            '
            Me.txtDrugVolume.BackColor = System.Drawing.Color.White
            Me.txtDrugVolume.BegFindValue = Nothing
            Me.txtDrugVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugVolume.ComputedValue = False
            Me.txtDrugVolume.CustomFormat = Nothing
            Me.txtDrugVolume.DataBoundControl = True
            Me.txtDrugVolume.EditingMode = True
            Me.txtDrugVolume.EndFindValue = Nothing
            Me.txtDrugVolume.FieldDescription = Nothing
            Me.txtDrugVolume.FieldName = Nothing
            Me.txtDrugVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugVolume.FindEnabled = False
            Me.txtDrugVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugVolume.ForeColor = System.Drawing.Color.Black
            Me.txtDrugVolume.LinkedLabel = Nothing
            Me.txtDrugVolume.Location = New System.Drawing.Point(105, 201)
            Me.txtDrugVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugVolume.MaximumValue = Nothing
            Me.txtDrugVolume.MinimumValue = Nothing
            Me.txtDrugVolume.Name = "txtDrugVolume"
            Me.txtDrugVolume.OldValue = Nothing
            Me.txtDrugVolume.OverrideMaxLength = 0
            Me.txtDrugVolume.ReadOnly = True
            Me.txtDrugVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugVolume.Size = New System.Drawing.Size(148, 21)
            Me.txtDrugVolume.TabIndex = 64
            Me.txtDrugVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.txtDrugVolume.Translatable = False
            '
            'CLabel15
            '
            Me.CLabel15.DisplayOnly = True
            Me.CLabel15.EditingMode = False
            Me.CLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel15.Location = New System.Drawing.Point(255, 201)
            Me.CLabel15.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel15.Name = "CLabel15"
            Me.CLabel15.Size = New System.Drawing.Size(115, 23)
            Me.CLabel15.TabIndex = 57
            Me.CLabel15.Text = "Unit Of Volume"
            Me.CLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel15.Translatable = True
            '
            'txtDrugUnitOfVolume
            '
            Me.txtDrugUnitOfVolume.BackColor = System.Drawing.Color.White
            Me.txtDrugUnitOfVolume.BegFindValue = Nothing
            Me.txtDrugUnitOfVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugUnitOfVolume.ComputedValue = False
            Me.txtDrugUnitOfVolume.CustomFormat = Nothing
            Me.txtDrugUnitOfVolume.DataBoundControl = True
            Me.txtDrugUnitOfVolume.EditingMode = True
            Me.txtDrugUnitOfVolume.EndFindValue = Nothing
            Me.txtDrugUnitOfVolume.FieldDescription = Nothing
            Me.txtDrugUnitOfVolume.FieldName = Nothing
            Me.txtDrugUnitOfVolume.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugUnitOfVolume.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugUnitOfVolume, True)
            Me.txtDrugUnitOfVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugUnitOfVolume.ForeColor = System.Drawing.Color.Black
            Me.txtDrugUnitOfVolume.LinkedLabel = Nothing
            Me.txtDrugUnitOfVolume.Location = New System.Drawing.Point(372, 201)
            Me.txtDrugUnitOfVolume.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugUnitOfVolume.MaximumValue = Nothing
            Me.txtDrugUnitOfVolume.MinimumValue = Nothing
            Me.txtDrugUnitOfVolume.Name = "txtDrugUnitOfVolume"
            Me.txtDrugUnitOfVolume.OldValue = "0"
            Me.txtDrugUnitOfVolume.OverrideMaxLength = 0
            Me.txtDrugUnitOfVolume.ReadOnly = True
            Me.txtDrugUnitOfVolume.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugUnitOfVolume.Size = New System.Drawing.Size(251, 21)
            Me.txtDrugUnitOfVolume.TabIndex = 68
            Me.txtDrugUnitOfVolume.Translatable = False
            '
            'CLabel16
            '
            Me.CLabel16.DisplayOnly = True
            Me.CLabel16.EditingMode = False
            Me.CLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel16.Location = New System.Drawing.Point(1, 226)
            Me.CLabel16.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel16.Name = "CLabel16"
            Me.CLabel16.Size = New System.Drawing.Size(102, 23)
            Me.CLabel16.TabIndex = 58
            Me.CLabel16.Text = "Package Type"
            Me.CLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel16.Translatable = True
            '
            'txtDrugPackageType
            '
            Me.txtDrugPackageType.BackColor = System.Drawing.Color.White
            Me.txtDrugPackageType.BegFindValue = Nothing
            Me.txtDrugPackageType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugPackageType.ComputedValue = False
            Me.txtDrugPackageType.CustomFormat = Nothing
            Me.txtDrugPackageType.DataBoundControl = True
            Me.txtDrugPackageType.EditingMode = True
            Me.txtDrugPackageType.EndFindValue = Nothing
            Me.txtDrugPackageType.FieldDescription = Nothing
            Me.txtDrugPackageType.FieldName = Nothing
            Me.txtDrugPackageType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugPackageType.FindEnabled = False
            Me.txtDrugPackageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugPackageType.ForeColor = System.Drawing.Color.Black
            Me.txtDrugPackageType.LinkedLabel = Nothing
            Me.txtDrugPackageType.Location = New System.Drawing.Point(105, 226)
            Me.txtDrugPackageType.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugPackageType.MaximumValue = Nothing
            Me.txtDrugPackageType.MinimumValue = Nothing
            Me.txtDrugPackageType.Name = "txtDrugPackageType"
            Me.txtDrugPackageType.OldValue = "0"
            Me.txtDrugPackageType.OverrideMaxLength = 0
            Me.txtDrugPackageType.ReadOnly = True
            Me.txtDrugPackageType.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugPackageType.Size = New System.Drawing.Size(150, 21)
            Me.txtDrugPackageType.TabIndex = 66
            Me.txtDrugPackageType.Translatable = False
            '
            'CLabel17
            '
            Me.CLabel17.DisplayOnly = True
            Me.CLabel17.EditingMode = False
            Me.CLabel17.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel17.Location = New System.Drawing.Point(257, 226)
            Me.CLabel17.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel17.Name = "CLabel17"
            Me.CLabel17.Size = New System.Drawing.Size(113, 23)
            Me.CLabel17.TabIndex = 59
            Me.CLabel17.Text = "Package Size"
            Me.CLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel17.Translatable = True
            '
            'txtDrugPackageSize
            '
            Me.txtDrugPackageSize.BackColor = System.Drawing.Color.White
            Me.txtDrugPackageSize.BegFindValue = Nothing
            Me.txtDrugPackageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugPackageSize.ComputedValue = False
            Me.txtDrugPackageSize.CustomFormat = Nothing
            Me.txtDrugPackageSize.DataBoundControl = True
            Me.txtDrugPackageSize.EditingMode = True
            Me.txtDrugPackageSize.EndFindValue = Nothing
            Me.txtDrugPackageSize.FieldDescription = Nothing
            Me.txtDrugPackageSize.FieldName = Nothing
            Me.txtDrugPackageSize.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugPackageSize.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugPackageSize, True)
            Me.txtDrugPackageSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugPackageSize.ForeColor = System.Drawing.Color.Black
            Me.txtDrugPackageSize.LinkedLabel = Nothing
            Me.txtDrugPackageSize.Location = New System.Drawing.Point(372, 226)
            Me.txtDrugPackageSize.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugPackageSize.MaximumValue = Nothing
            Me.txtDrugPackageSize.MinimumValue = Nothing
            Me.txtDrugPackageSize.Name = "txtDrugPackageSize"
            Me.txtDrugPackageSize.OldValue = Nothing
            Me.txtDrugPackageSize.OverrideMaxLength = 0
            Me.txtDrugPackageSize.ReadOnly = True
            Me.txtDrugPackageSize.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugPackageSize.Size = New System.Drawing.Size(251, 21)
            Me.txtDrugPackageSize.TabIndex = 67
            Me.txtDrugPackageSize.Translatable = False
            '
            'CLabel18
            '
            Me.CLabel18.DisplayOnly = True
            Me.CLabel18.EditingMode = False
            Me.CLabel18.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CLabel18.Location = New System.Drawing.Point(1, 251)
            Me.CLabel18.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel18.Name = "CLabel18"
            Me.CLabel18.Size = New System.Drawing.Size(102, 23)
            Me.CLabel18.TabIndex = 63
            Me.CLabel18.Text = "Route of Administration"
            Me.CLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel18.Translatable = True
            '
            'txtDrugRouteOfAdministration
            '
            Me.txtDrugRouteOfAdministration.BackColor = System.Drawing.Color.White
            Me.txtDrugRouteOfAdministration.BegFindValue = Nothing
            Me.txtDrugRouteOfAdministration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDrugRouteOfAdministration.ComputedValue = False
            Me.txtDrugRouteOfAdministration.CustomFormat = Nothing
            Me.txtDrugRouteOfAdministration.DataBoundControl = True
            Me.txtDrugRouteOfAdministration.EditingMode = True
            Me.txtDrugRouteOfAdministration.EndFindValue = Nothing
            Me.txtDrugRouteOfAdministration.FieldDescription = Nothing
            Me.txtDrugRouteOfAdministration.FieldName = Nothing
            Me.txtDrugRouteOfAdministration.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtDrugRouteOfAdministration.FindEnabled = False
            Me.CFlowLayout2.SetFlowBreak(Me.txtDrugRouteOfAdministration, True)
            Me.txtDrugRouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDrugRouteOfAdministration.ForeColor = System.Drawing.Color.Black
            Me.txtDrugRouteOfAdministration.LinkedLabel = Nothing
            Me.txtDrugRouteOfAdministration.Location = New System.Drawing.Point(105, 251)
            Me.txtDrugRouteOfAdministration.Margin = New System.Windows.Forms.Padding(1)
            Me.txtDrugRouteOfAdministration.MaximumValue = Nothing
            Me.txtDrugRouteOfAdministration.MinimumValue = Nothing
            Me.txtDrugRouteOfAdministration.Name = "txtDrugRouteOfAdministration"
            Me.txtDrugRouteOfAdministration.OldValue = ""
            Me.txtDrugRouteOfAdministration.OverrideMaxLength = 0
            Me.txtDrugRouteOfAdministration.ReadOnly = True
            Me.txtDrugRouteOfAdministration.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtDrugRouteOfAdministration.Size = New System.Drawing.Size(518, 21)
            Me.txtDrugRouteOfAdministration.TabIndex = 43
            Me.txtDrugRouteOfAdministration.Translatable = False
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(374, 678)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(192, 25)
            Me.btnOk.TabIndex = 40
            Me.btnOk.Text = "Match Displayed Items"
            '
            'CFlowLayout3
            '
            Me.CFlowLayout3.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout3.Controls.Add(Me.CFlowLayout1)
            Me.CFlowLayout3.Controls.Add(Me.CFlowLayout2)
            Me.CFlowLayout3.Controls.Add(Me.DataGridViewItems)
            Me.CFlowLayout3.Controls.Add(Me.DataGridViewDrugs)
            Me.CFlowLayout3.Location = New System.Drawing.Point(4, 57)
            Me.CFlowLayout3.Margin = New System.Windows.Forms.Padding(0)
            Me.CFlowLayout3.Name = "CFlowLayout3"
            Me.CFlowLayout3.Size = New System.Drawing.Size(1271, 618)
            Me.CFlowLayout3.TabIndex = 79
            '
            'DataGridViewItems
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.DataGridViewItems.BegFindValue = Nothing
            Me.DataGridViewItems.Cached = False
            Me.DataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewItems.DataFilter = Nothing
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewItems.DefaultCellStyle = DataGridViewCellStyle2
            Me.DataGridViewItems.DgvFooter = Nothing
            Me.DataGridViewItems.DisplayOnly = True
            Me.DataGridViewItems.Ea = Nothing
            Me.DataGridViewItems.EditingMode = False
            Me.DataGridViewItems.EndFindValue = Nothing
            Me.DataGridViewItems.FieldDescription = Nothing
            Me.DataGridViewItems.FieldName = Nothing
            Me.DataGridViewItems.FieldsDictionary = Nothing
            Me.DataGridViewItems.FindColumnNo = CType(0, Short)
            Me.DataGridViewItems.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewItems.FindEnabled = True
            Me.DataGridViewItems.FirstRowDeletionEnabled = True
            Me.DataGridViewItems.FirstRowInsertionEnabled = True
            Me.DataGridViewItems.IgnoreCase = False
            Me.DataGridViewItems.IsDirty = False
            Me.DataGridViewItems.Location = New System.Drawing.Point(3, 292)
            Me.DataGridViewItems.Name = "DataGridViewItems"
            Me.DataGridViewItems.ReadOnly = True
            Me.DataGridViewItems.Searchable = True
            Me.DataGridViewItems.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewItems.SecurityKey = ""
            Me.DataGridViewItems.SequenceColumn = "dgvSequence"
            Me.DataGridViewItems.SequenceFieldName = "Sequence"
            Me.DataGridViewItems.ShowFooter = False
            Me.DataGridViewItems.Size = New System.Drawing.Size(1259, 159)
            Me.DataGridViewItems.TabIndex = 39
            Me.DataGridViewItems.Translatable = True
            '
            'DataGridViewDrugs
            '
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewDrugs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
            Me.DataGridViewDrugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
            Me.DataGridViewDrugs.BegFindValue = Nothing
            Me.DataGridViewDrugs.Cached = False
            Me.DataGridViewDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewDrugs.DataFilter = Nothing
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewDrugs.DefaultCellStyle = DataGridViewCellStyle4
            Me.DataGridViewDrugs.DgvFooter = Nothing
            Me.DataGridViewDrugs.DisplayOnly = True
            Me.DataGridViewDrugs.Ea = Nothing
            Me.DataGridViewDrugs.EditingMode = False
            Me.DataGridViewDrugs.EndFindValue = Nothing
            Me.DataGridViewDrugs.FieldDescription = Nothing
            Me.DataGridViewDrugs.FieldName = Nothing
            Me.DataGridViewDrugs.FieldsDictionary = Nothing
            Me.DataGridViewDrugs.FindColumnNo = CType(0, Short)
            Me.DataGridViewDrugs.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewDrugs.FindEnabled = True
            Me.DataGridViewDrugs.FirstRowDeletionEnabled = True
            Me.DataGridViewDrugs.FirstRowInsertionEnabled = True
            Me.DataGridViewDrugs.IgnoreCase = False
            Me.DataGridViewDrugs.IsDirty = False
            Me.DataGridViewDrugs.Location = New System.Drawing.Point(3, 457)
            Me.DataGridViewDrugs.Name = "DataGridViewDrugs"
            Me.DataGridViewDrugs.ReadOnly = True
            Me.DataGridViewDrugs.Searchable = True
            Me.DataGridViewDrugs.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewDrugs.SecurityKey = ""
            Me.DataGridViewDrugs.SequenceColumn = "dgvSequence"
            Me.DataGridViewDrugs.SequenceFieldName = "Sequence"
            Me.DataGridViewDrugs.ShowFooter = False
            Me.DataGridViewDrugs.Size = New System.Drawing.Size(1259, 159)
            Me.DataGridViewDrugs.TabIndex = 40
            Me.DataGridViewDrugs.Translatable = True
            '
            'GTinMatcherEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(1284, 709)
            Me.Controls.Add(Me.CFlowLayout3)
            Me.Controls.Add(Me.btnOk)
            Me.Name = "GTinMatcherEntry"
            Me.Text = "Item Details Entry"
            Me.Controls.SetChildIndex(Me.btnOk, 0)
            Me.Controls.SetChildIndex(Me.CFlowLayout3, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(false)
        Me.CFlowLayout1.PerformLayout
        CType(Me.BnItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.BnItems.ResumeLayout(false)
        Me.BnItems.PerformLayout
        Me.CFlowLayout2.ResumeLayout(false)
        Me.CFlowLayout2.PerformLayout
        CType(Me.BnDrugs,System.ComponentModel.ISupportInitialize).EndInit
        Me.BnDrugs.ResumeLayout(false)
        Me.BnDrugs.PerformLayout
        Me.CFlowLayout3.ResumeLayout(false)
        CType(Me.DataGridViewItems,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DataGridViewDrugs,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnScanQrCode As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents EventLog1 As EventLog
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItemDetailsCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItemDetailsName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGenericName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboRouteOfAdministration As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents lblRegistrationCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblDosageForm As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboDosageForm As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtStrengthValue As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblUnitOfStrength As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboUnitOfStrength As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents lblVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblUnitOfVolume As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboUnitOfVolume As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents lblPackageType As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboPackageType As Libraries.CBaseControlsLibrary.CtComboBox
        Friend WithEvents cboPackageSize As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPackageSize As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGenericName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CFlowLayout2 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugGTin As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel7 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugTradeName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel8 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugGenericName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel10 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugRegistrationNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel11 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugDosageForm As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel12 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugStrengthValue As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel13 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugUnitOfStrength As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel14 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel15 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugUnitOfVolume As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel16 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugPackageType As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel17 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugPackageSize As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel18 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugRouteOfAdministration As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPacking As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPack1 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtpack2 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents txtpack3 As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents lblPrice_Cash As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPrice_Cash As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPublicPrice As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtDrugPublicPrice As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel6 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtQtyOnHand As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel9 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout3 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents DataGridViewItems As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents DataGridViewDrugs As Libraries.CBaseControlsLibrary.CDataGridView
        Friend WithEvents BnDrugs As BindingNavigator
        Friend WithEvents btnDrugBnAddNewItem As ToolStripButton
        Friend WithEvents tsDrugsCount As ToolStripLabel
        Friend WithEvents btnDrugBnDeleteItem As ToolStripButton
        Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
        Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
        Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
        Friend WithEvents tsDrugsCurrentRecord As ToolStripTextBox
        Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
        Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
        Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
        Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
        Friend WithEvents BnItems As BindingNavigator
        Friend WithEvents btnItemsBnAddNewItem As ToolStripButton
        Friend WithEvents tsItemsCount As ToolStripLabel
        Friend WithEvents btnItemsBnDeleteItem As ToolStripButton
        Friend WithEvents btnFirstItem As ToolStripButton
        Friend WithEvents btnPrevItem As ToolStripButton
        Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
        Friend WithEvents tsItemsCurrentRecord As ToolStripTextBox
        Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
        Friend WithEvents btnNextItem As ToolStripButton
        Friend WithEvents btnLastItem As ToolStripButton
        Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    End Class
End Namespace