Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DrugMapEntry
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.cboItemFinder = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblItemNameEnglish = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtItem_Code = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblItem_Code = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtGTIN = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblGTIN = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.ItemDataGridView = New AATM.Libraries.CBaseControlsLibrary.CDataGridView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            CType(Me.ItemDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 53)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
            Me.SplitContainer1.Panel1.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.SplitContainer1.Panel1.Controls.Add(Me.CFlowLayout1)
            Me.SplitContainer1.Panel1MinSize = 500
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
            Me.SplitContainer1.Panel2.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.SplitContainer1.Size = New System.Drawing.Size(984, 473)
            Me.SplitContainer1.SplitterDistance = 518
            Me.SplitContainer1.TabIndex = 46
            '
            'cboItemFinder
            '
            Me.cboItemFinder.BackColor = System.Drawing.Color.White
            Me.cboItemFinder.BegFindValue = Nothing
            Me.cboItemFinder.ChangingSearchValueOnly = False
            Me.cboItemFinder.CurrentSearchTerm = ""
            Me.cboItemFinder.DataValue = Nothing
            Me.cboItemFinder.DefaultValue = Nothing
            Me.cboItemFinder.DisplayMember = "Name"
            Me.cboItemFinder.EditingMode = True
            Me.cboItemFinder.EndFindValue = Nothing
            Me.cboItemFinder.FieldDescription = Nothing
            Me.cboItemFinder.FieldName = Nothing
            Me.cboItemFinder.FilterRule = Nothing
            Me.cboItemFinder.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboItemFinder.FindEnabled = True
            Me.cboItemFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboItemFinder.ForeColor = System.Drawing.Color.Black
            Me.cboItemFinder.FormattingEnabled = True
            Me.cboItemFinder.HideWhenNotEditingOrAdding = False
            Me.cboItemFinder.IgnoreCase = False
            Me.cboItemFinder.IntegralHeight = False
            Me.cboItemFinder.LinkedLabel = Nothing
            Me.cboItemFinder.Location = New System.Drawing.Point(98, 76)
            Me.cboItemFinder.Margin = New System.Windows.Forms.Padding(1)
            Me.cboItemFinder.Name = "cboItemFinder"
            Me.cboItemFinder.OldValue = 0
            Me.cboItemFinder.OriginalDataSource = Nothing
            Me.cboItemFinder.OriginalList = Nothing
            Me.cboItemFinder.OverrideDropDownStyleList = False
            Me.cboItemFinder.PreviousSearchTerm = Nothing
            Me.cboItemFinder.PropertySelector = Nothing
            Me.cboItemFinder.ReadOnlyCombo = False
            Me.cboItemFinder.Size = New System.Drawing.Size(350, 24)
            Me.cboItemFinder.SuggestBoxHeight = 200
            Me.cboItemFinder.SuggestListOrderRule = Nothing
            Me.cboItemFinder.TabIndex = 11
            Me.cboItemFinder.TextToSearch = Nothing
            Me.cboItemFinder.Translatable = False
            Me.cboItemFinder.ValueIsMandatory = False
            Me.cboItemFinder.ValueIsNullable = False
            Me.cboItemFinder.ValueIsNumeric = False
            Me.cboItemFinder.ValueMember = "Name"
            '
            'lblItemNameEnglish
            '
            Me.lblItemNameEnglish.DisplayOnly = True
            Me.lblItemNameEnglish.EditingMode = False
            Me.lblItemNameEnglish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblItemNameEnglish.Location = New System.Drawing.Point(1, 76)
            Me.lblItemNameEnglish.Margin = New System.Windows.Forms.Padding(1)
            Me.lblItemNameEnglish.Name = "lblItemNameEnglish"
            Me.lblItemNameEnglish.Size = New System.Drawing.Size(95, 23)
            Me.lblItemNameEnglish.TabIndex = 42
            Me.lblItemNameEnglish.Text = "Item Name"
            Me.lblItemNameEnglish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblItemNameEnglish.Translatable = True
            '
            'TxtItem_Code
            '
            Me.TxtItem_Code.BackColor = System.Drawing.Color.White
            Me.TxtItem_Code.BegFindValue = Nothing
            Me.TxtItem_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtItem_Code.ComputedValue = False
            Me.TxtItem_Code.CustomFormat = Nothing
            Me.TxtItem_Code.DataBoundControl = True
            Me.TxtItem_Code.DisplayOnly = True
            Me.TxtItem_Code.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtItem_Code.EditingMode = True
            Me.TxtItem_Code.EndFindValue = Nothing
            Me.TxtItem_Code.FieldDescription = Nothing
            Me.TxtItem_Code.FieldName = "Item_Code"
            Me.TxtItem_Code.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtItem_Code.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.TxtItem_Code, True)
            Me.TxtItem_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtItem_Code.ForeColor = System.Drawing.Color.Black
            Me.TxtItem_Code.LinkedLabel = Me.lblItem_Code
            Me.TxtItem_Code.Location = New System.Drawing.Point(98, 51)
            Me.TxtItem_Code.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtItem_Code.MaximumValue = Nothing
            Me.TxtItem_Code.MinimumValue = Nothing
            Me.TxtItem_Code.Name = "TxtItem_Code"
            Me.TxtItem_Code.OldValue = Nothing
            Me.TxtItem_Code.ReadOnly = True
            Me.TxtItem_Code.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtItem_Code.Size = New System.Drawing.Size(148, 23)
            Me.TxtItem_Code.TabIndex = 43
            Me.TxtItem_Code.Translatable = False
            '
            'lblItem_Code
            '
            Me.lblItem_Code.DisplayOnly = True
            Me.lblItem_Code.EditingMode = False
            Me.lblItem_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblItem_Code.Location = New System.Drawing.Point(1, 51)
            Me.lblItem_Code.Margin = New System.Windows.Forms.Padding(1)
            Me.lblItem_Code.Name = "lblItem_Code"
            Me.lblItem_Code.Size = New System.Drawing.Size(95, 23)
            Me.lblItem_Code.TabIndex = 2
            Me.lblItem_Code.Text = "Item Code"
            Me.lblItem_Code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblItem_Code.Translatable = True
            '
            'txtGTIN
            '
            Me.txtGTIN.BackColor = System.Drawing.Color.White
            Me.txtGTIN.BegFindValue = Nothing
            Me.txtGTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtGTIN.ComputedValue = False
            Me.txtGTIN.CustomFormat = Nothing
            Me.txtGTIN.DataBoundControl = True
            Me.txtGTIN.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtGTIN.EditingMode = True
            Me.txtGTIN.EndFindValue = Nothing
            Me.txtGTIN.FieldDescription = Nothing
            Me.txtGTIN.FieldName = Nothing
            Me.txtGTIN.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtGTIN.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtGTIN, True)
            Me.txtGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtGTIN.ForeColor = System.Drawing.Color.Black
            Me.txtGTIN.LinkedLabel = Me.lblGTIN
            Me.txtGTIN.Location = New System.Drawing.Point(98, 26)
            Me.txtGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.txtGTIN.MaximumValue = Nothing
            Me.txtGTIN.MinimumValue = Nothing
            Me.txtGTIN.Name = "txtGTIN"
            Me.txtGTIN.OldValue = ""
            Me.txtGTIN.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtGTIN.Size = New System.Drawing.Size(148, 23)
            Me.txtGTIN.TabIndex = 37
            Me.txtGTIN.Translatable = False
            '
            'lblGTIN
            '
            Me.lblGTIN.DisplayOnly = True
            Me.lblGTIN.EditingMode = False
            Me.lblGTIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblGTIN.Location = New System.Drawing.Point(1, 26)
            Me.lblGTIN.Margin = New System.Windows.Forms.Padding(1)
            Me.lblGTIN.Name = "lblGTIN"
            Me.lblGTIN.Size = New System.Drawing.Size(95, 23)
            Me.lblGTIN.TabIndex = 36
            Me.lblGTIN.Text = "GTIN"
            Me.lblGTIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblGTIN.Translatable = True
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
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
            Me.TxtIdNo.Location = New System.Drawing.Point(98, 1)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = ""
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(148, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(95, 23)
            Me.lblIdNo.TabIndex = 1
            Me.lblIdNo.Text = "I.D. Number"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblGTIN)
            Me.CFlowLayout1.Controls.Add(Me.txtGTIN)
            Me.CFlowLayout1.Controls.Add(Me.lblItem_Code)
            Me.CFlowLayout1.Controls.Add(Me.TxtItem_Code)
            Me.CFlowLayout1.Controls.Add(Me.lblItemNameEnglish)
            Me.CFlowLayout1.Controls.Add(Me.cboItemFinder)
            Me.CFlowLayout1.Controls.Add(Me.ItemDataGridView)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(514, 469)
            Me.CFlowLayout1.TabIndex = 45
            '
            'ItemDataGridView
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.ItemDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.ItemDataGridView.BegFindValue = Nothing
            Me.ItemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.ItemDataGridView.DefaultCellStyle = DataGridViewCellStyle2
            Me.ItemDataGridView.DgvFooter = Nothing
            Me.ItemDataGridView.DisplayOnly = False
            Me.ItemDataGridView.Ea = Nothing
            Me.ItemDataGridView.EditingMode = False
            Me.ItemDataGridView.EndFindValue = Nothing
            Me.ItemDataGridView.FieldDescription = Nothing
            Me.ItemDataGridView.FieldName = Nothing
            Me.ItemDataGridView.FieldsDictionary = Nothing
            Me.ItemDataGridView.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.ItemDataGridView.FindEnabled = False
            Me.ItemDataGridView.FirstRowDeletionEnabled = True
            Me.ItemDataGridView.FirstRowInsertionEnabled = True
            Me.ItemDataGridView.IgnoreCase = False
            Me.ItemDataGridView.IsDirty = False
            Me.ItemDataGridView.Location = New System.Drawing.Point(3, 104)
            Me.ItemDataGridView.Name = "ItemDataGridView"
            Me.ItemDataGridView.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.ItemDataGridView.SecurityKey = ""
            Me.ItemDataGridView.SequenceColumn = "dgvSequence"
            Me.ItemDataGridView.SequenceFieldName = "Sequence"
            Me.ItemDataGridView.ShowFooter = False
            Me.ItemDataGridView.ShowInsertColumnWhenEditing = True
            Me.ItemDataGridView.Size = New System.Drawing.Size(480, 260)
            Me.ItemDataGridView.TabIndex = 44
            Me.ItemDataGridView.Translatable = True
            '
            'DrugMapEntry
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.ClientSize = New System.Drawing.Size(984, 526)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Name = "DrugMapEntry"
            Me.Text = "Item Details Entry"
            Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            CType(Me.ItemDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblGTIN As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtGTIN As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblItem_Code As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtItem_Code As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblItemNameEnglish As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents cboItemFinder As Libraries.CBaseControlsLibrary.CaComboBox
        Friend WithEvents ItemDataGridView As Libraries.CBaseControlsLibrary.CDataGridView
    End Class
End Namespace