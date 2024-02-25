Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PensionSchemeEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
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
            Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim EventAggregator1 As AATM.Libraries.EventAggregator = New AATM.Libraries.EventAggregator()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PensionSchemeEntryTv))
            Me.bsPensionRates = New System.Windows.Forms.BindingSource(Me.components)
            Me.CFlowLayout4 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpPensionScheme = New System.Windows.Forms.TableLayoutPanel()
            Me.tbcPensionScheme = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.tbpMain = New System.Windows.Forms.TabPage()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tlpMainTab = New System.Windows.Forms.TableLayoutPanel()
            Me.cboPensionProviderIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.lblPensionProviderIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpPensionRates = New System.Windows.Forms.TabPage()
            Me.tlpPostingAccounts = New System.Windows.Forms.TableLayoutPanel()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CtCombobox()
            Me.DataGridViewPensionRates = New AATM.Libraries.CBaseControlsLibrary.CtDataGridView()
            Me.dgvSequence = New AATM.Libraries.CBaseControlsLibrary.CDgvTextColumn()
            Me.dgvLowRange = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvHighRange = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvEmployeeShare = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvEmployerShare = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.dgvMaxAmount = New AATM.Libraries.CBaseControlsLibrary.CdgvMoneyColumn()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IdNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.txtPensionSchemeNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtPensionSchemeName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPensionSchemeCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsPensionRates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout4.SuspendLayout()
            Me.tlpPensionScheme.SuspendLayout()
            Me.tbcPensionScheme.SuspendLayout()
            Me.tbpMain.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.tlpMainTab.SuspendLayout()
            Me.tbpPensionRates.SuspendLayout()
            Me.tlpPostingAccounts.SuspendLayout()
            CType(Me.DataGridViewPensionRates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.FormTreeView, "FormTreeView")
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'bsPensionRates
            '
            Me.bsPensionRates.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.PensionRateModel)
            '
            'CFlowLayout4
            '
            Me.CFlowLayout4.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout4.Controls.Add(Me.tlpPensionScheme)
            resources.ApplyResources(Me.CFlowLayout4, "CFlowLayout4")
            Me.CFlowLayout4.Name = "CFlowLayout4"
            '
            'tlpPensionScheme
            '
            Me.tlpPensionScheme.Controls.Add(Me.tbcPensionScheme, 0, 3)
            Me.tlpPensionScheme.Controls.Add(Me.txtPensionSchemeNameAra, 1, 2)
            Me.tlpPensionScheme.Controls.Add(Me.lblName, 0, 1)
            Me.tlpPensionScheme.Controls.Add(Me.txtPensionSchemeCode, 3, 0)
            Me.tlpPensionScheme.Controls.Add(Me.lblCode, 2, 0)
            Me.tlpPensionScheme.Controls.Add(Me.TxtIdNo, 1, 0)
            Me.tlpPensionScheme.Controls.Add(Me.CLabel1, 0, 0)
            Me.tlpPensionScheme.Controls.Add(Me.txtPensionSchemeName, 1, 1)
            Me.tlpPensionScheme.Controls.Add(Me.lblNameAra, 0, 2)
            Me.CFlowLayout4.SetFlowBreak(Me.tlpPensionScheme, True)
            resources.ApplyResources(Me.tlpPensionScheme, "tlpPensionScheme")
            Me.tlpPensionScheme.Name = "tlpPensionScheme"
            '
            'tbcPensionScheme
            '
            Me.tlpPensionScheme.SetColumnSpan(Me.tbcPensionScheme, 4)
            Me.tbcPensionScheme.Controls.Add(Me.tbpMain)
            Me.tbcPensionScheme.Controls.Add(Me.tbpPensionRates)
            resources.ApplyResources(Me.tbcPensionScheme, "tbcPensionScheme")
            Me.tbcPensionScheme.Name = "tbcPensionScheme"
            Me.tbcPensionScheme.SelectedIndex = 0
            '
            'tbpMain
            '
            Me.tbpMain.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            resources.ApplyResources(Me.tbpMain, "tbpMain")
            Me.tbpMain.Controls.Add(Me.CFlowLayout1)
            Me.tbpMain.Cursor = System.Windows.Forms.Cursors.Default
            Me.tbpMain.Name = "tbpMain"
            Me.tbpMain.UseVisualStyleBackColor = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.tlpMainTab)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'tlpMainTab
            '
            resources.ApplyResources(Me.tlpMainTab, "tlpMainTab")
            Me.tlpMainTab.Controls.Add(Me.cboPensionProviderIdNo, 0, 1)
            Me.tlpMainTab.Controls.Add(Me.lblPensionProviderIdNo, 0, 0)
            Me.tlpMainTab.Controls.Add(Me.txtNotes, 0, 3)
            Me.tlpMainTab.Controls.Add(Me.lblNotes, 0, 2)
            Me.tlpMainTab.Name = "tlpMainTab"
            '
            'cboPensionProviderIdNo
            '
            Me.cboPensionProviderIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboPensionProviderIdNo.BackColor = System.Drawing.Color.White
            Me.cboPensionProviderIdNo.BegFindValue = Nothing
            Me.cboPensionProviderIdNo.ChangingSearchValueOnly = False
            Me.tlpMainTab.SetColumnSpan(Me.cboPensionProviderIdNo, 2)
            Me.cboPensionProviderIdNo.CurrentSearchTerm = ""
            Me.cboPensionProviderIdNo.DefaultValue = Nothing
            Me.cboPensionProviderIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboPensionProviderIdNo, "cboPensionProviderIdNo")
            Me.cboPensionProviderIdNo.EditingMode = False
            Me.cboPensionProviderIdNo.EndFindValue = Nothing
            Me.cboPensionProviderIdNo.FieldDescription = Nothing
            Me.cboPensionProviderIdNo.FieldName = Nothing
            Me.cboPensionProviderIdNo.FilterRule = Nothing
            Me.cboPensionProviderIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboPensionProviderIdNo.FindEnabled = False
            Me.cboPensionProviderIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboPensionProviderIdNo.FormattingEnabled = True
            Me.cboPensionProviderIdNo.HideWhenNotEditingOrAdding = False
            Me.cboPensionProviderIdNo.IgnoreCase = False
            Me.cboPensionProviderIdNo.LinkedLabel = Nothing
            Me.cboPensionProviderIdNo.Name = "cboPensionProviderIdNo"
            Me.cboPensionProviderIdNo.OldValue = 0
            Me.cboPensionProviderIdNo.OriginalDataSource = Nothing
            Me.cboPensionProviderIdNo.OriginalList = Nothing
            Me.cboPensionProviderIdNo.OverrideDropDownStyleList = False
            Me.cboPensionProviderIdNo.PreviousSearchTerm = Nothing
            Me.cboPensionProviderIdNo.PropertySelector = Nothing
            Me.cboPensionProviderIdNo.SuggestBoxHeight = 200
            Me.cboPensionProviderIdNo.SuggestListOrderRule = Nothing
            Me.cboPensionProviderIdNo.TextToSearch = Nothing
            Me.cboPensionProviderIdNo.Translatable = False
            Me.cboPensionProviderIdNo.ValueIsMandatory = False
            Me.cboPensionProviderIdNo.ValueIsNullable = False
            Me.cboPensionProviderIdNo.ValueIsNumeric = False
            Me.cboPensionProviderIdNo.ValueMember = "IdNo"
            '
            'lblPensionProviderIdNo
            '
            Me.lblPensionProviderIdNo.DisplayOnly = True
            Me.lblPensionProviderIdNo.EditingMode = False
            resources.ApplyResources(Me.lblPensionProviderIdNo, "lblPensionProviderIdNo")
            Me.lblPensionProviderIdNo.Name = "lblPensionProviderIdNo"
            Me.lblPensionProviderIdNo.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpMainTab.SetColumnSpan(Me.txtNotes, 2)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'tbpPensionRates
            '
            Me.tbpPensionRates.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge2
            resources.ApplyResources(Me.tbpPensionRates, "tbpPensionRates")
            Me.tbpPensionRates.Controls.Add(Me.tlpPostingAccounts)
            Me.tbpPensionRates.Name = "tbpPensionRates"
            Me.tbpPensionRates.UseVisualStyleBackColor = True
            '
            'tlpPostingAccounts
            '
            resources.ApplyResources(Me.tlpPostingAccounts, "tlpPostingAccounts")
            Me.tlpPostingAccounts.Controls.Add(Me.lblAccountIdNo, 0, 1)
            Me.tlpPostingAccounts.Controls.Add(Me.cboAccountIdNo, 1, 1)
            Me.tlpPostingAccounts.Controls.Add(Me.DataGridViewPensionRates, 0, 2)
            Me.tlpPostingAccounts.Name = "tlpPostingAccounts"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.EditingMode = False
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            Me.lblAccountIdNo.Translatable = True
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.BegFindValue = Nothing
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.tlpPostingAccounts.SetColumnSpan(Me.cboAccountIdNo, 2)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.EndFindValue = Nothing
            Me.cboAccountIdNo.FieldDescription = Nothing
            Me.cboAccountIdNo.FieldName = Nothing
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboAccountIdNo.FindEnabled = False
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.IgnoreCase = False
            Me.cboAccountIdNo.LinkedLabel = Nothing
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.Translatable = False
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "IdNo"
            '
            'DataGridViewPensionRates
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
            Me.DataGridViewPensionRates.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.DataGridViewPensionRates.AutoGenerateColumns = False
            Me.DataGridViewPensionRates.BackgroundColor = System.Drawing.SystemColors.Window
            Me.DataGridViewPensionRates.BegFindValue = Nothing
            Me.DataGridViewPensionRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridViewPensionRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvSequence, Me.dgvLowRange, Me.dgvHighRange, Me.dgvEmployeeShare, Me.dgvEmployerShare, Me.dgvMaxAmount, Me.DataGridViewTextBoxColumn1, Me.IdNoDataGridViewTextBoxColumn})
            Me.tlpPostingAccounts.SetColumnSpan(Me.DataGridViewPensionRates, 3)
            Me.DataGridViewPensionRates.DataSource = Me.bsPensionRates
            DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.DataGridViewPensionRates.DefaultCellStyle = DataGridViewCellStyle8
            Me.DataGridViewPensionRates.DgvFooter = Nothing
            Me.DataGridViewPensionRates.DisplayOnly = False
            resources.ApplyResources(Me.DataGridViewPensionRates, "DataGridViewPensionRates")
            Me.DataGridViewPensionRates.Ea = EventAggregator1
            Me.DataGridViewPensionRates.EditingMode = False
            Me.DataGridViewPensionRates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.DataGridViewPensionRates.EndFindValue = Nothing
            Me.DataGridViewPensionRates.FieldDescription = Nothing
            Me.DataGridViewPensionRates.FieldName = Nothing
            Me.DataGridViewPensionRates.FieldsDictionary = Nothing
            Me.DataGridViewPensionRates.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.DataGridViewPensionRates.FindEnabled = False
            Me.DataGridViewPensionRates.FirstRowDeletionEnabled = True
            Me.DataGridViewPensionRates.FirstRowInsertionEnabled = True
            Me.DataGridViewPensionRates.IgnoreCase = False
            Me.DataGridViewPensionRates.Name = "DataGridViewPensionRates"
            Me.DataGridViewPensionRates.ReadOnly = True
            Me.DataGridViewPensionRates.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.DataGridViewPensionRates.SequenceColumn = "dgvSequence"
            Me.DataGridViewPensionRates.SequenceFieldName = "Sequence"
            Me.DataGridViewPensionRates.ShowFooter = False
            Me.DataGridViewPensionRates.Translatable = True
            '
            'dgvSequence
            '
            Me.dgvSequence.BegFindValue = Nothing
            Me.dgvSequence.DataPropertyName = "Sequence"
            DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            Me.dgvSequence.DefaultCellStyle = DataGridViewCellStyle2
            Me.dgvSequence.DisplayOnly = True
            Me.dgvSequence.EditingMode = False
            Me.dgvSequence.EndFindValue = Nothing
            Me.dgvSequence.FieldDescription = Nothing
            Me.dgvSequence.FieldName = Nothing
            Me.dgvSequence.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvSequence.FindEnabled = False
            resources.ApplyResources(Me.dgvSequence, "dgvSequence")
            Me.dgvSequence.IgnoreCase = False
            Me.dgvSequence.Name = "dgvSequence"
            Me.dgvSequence.ReadOnly = True
            Me.dgvSequence.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvSequence.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvSequence.Translatable = False
            '
            'dgvLowRange
            '
            Me.dgvLowRange.BegFindValue = Nothing
            Me.dgvLowRange.DataPropertyName = "LowRange"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.Format = "###,##0.00"
            Me.dgvLowRange.DefaultCellStyle = DataGridViewCellStyle3
            Me.dgvLowRange.EditingMode = False
            Me.dgvLowRange.EndFindValue = Nothing
            Me.dgvLowRange.FieldDescription = Nothing
            Me.dgvLowRange.FieldName = Nothing
            Me.dgvLowRange.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvLowRange.FindEnabled = False
            resources.ApplyResources(Me.dgvLowRange, "dgvLowRange")
            Me.dgvLowRange.Name = "dgvLowRange"
            Me.dgvLowRange.ReadOnly = True
            Me.dgvLowRange.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvLowRange.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvLowRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvLowRange.Translatable = False
            '
            'dgvHighRange
            '
            Me.dgvHighRange.BegFindValue = Nothing
            Me.dgvHighRange.DataPropertyName = "HighRange"
            DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle4.Format = "###,##0.00"
            Me.dgvHighRange.DefaultCellStyle = DataGridViewCellStyle4
            Me.dgvHighRange.EditingMode = False
            Me.dgvHighRange.EndFindValue = Nothing
            Me.dgvHighRange.FieldDescription = Nothing
            Me.dgvHighRange.FieldName = Nothing
            Me.dgvHighRange.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvHighRange.FindEnabled = False
            resources.ApplyResources(Me.dgvHighRange, "dgvHighRange")
            Me.dgvHighRange.Name = "dgvHighRange"
            Me.dgvHighRange.ReadOnly = True
            Me.dgvHighRange.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvHighRange.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvHighRange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvHighRange.Translatable = False
            '
            'dgvEmployeeShare
            '
            Me.dgvEmployeeShare.BegFindValue = Nothing
            Me.dgvEmployeeShare.DataPropertyName = "EmployeeShare"
            DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle5.Format = "###,##0.00"
            Me.dgvEmployeeShare.DefaultCellStyle = DataGridViewCellStyle5
            Me.dgvEmployeeShare.EditingMode = False
            Me.dgvEmployeeShare.EndFindValue = Nothing
            Me.dgvEmployeeShare.FieldDescription = Nothing
            Me.dgvEmployeeShare.FieldName = Nothing
            Me.dgvEmployeeShare.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEmployeeShare.FindEnabled = False
            resources.ApplyResources(Me.dgvEmployeeShare, "dgvEmployeeShare")
            Me.dgvEmployeeShare.Name = "dgvEmployeeShare"
            Me.dgvEmployeeShare.ReadOnly = True
            Me.dgvEmployeeShare.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEmployeeShare.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEmployeeShare.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEmployeeShare.Translatable = False
            '
            'dgvEmployerShare
            '
            Me.dgvEmployerShare.BegFindValue = Nothing
            Me.dgvEmployerShare.DataPropertyName = "EmployerShare"
            DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle6.Format = "###,##0.00"
            Me.dgvEmployerShare.DefaultCellStyle = DataGridViewCellStyle6
            Me.dgvEmployerShare.EditingMode = False
            Me.dgvEmployerShare.EndFindValue = Nothing
            Me.dgvEmployerShare.FieldDescription = Nothing
            Me.dgvEmployerShare.FieldName = Nothing
            Me.dgvEmployerShare.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvEmployerShare.FindEnabled = False
            resources.ApplyResources(Me.dgvEmployerShare, "dgvEmployerShare")
            Me.dgvEmployerShare.Name = "dgvEmployerShare"
            Me.dgvEmployerShare.ReadOnly = True
            Me.dgvEmployerShare.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvEmployerShare.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvEmployerShare.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvEmployerShare.Translatable = False
            '
            'dgvMaxAmount
            '
            Me.dgvMaxAmount.BegFindValue = Nothing
            Me.dgvMaxAmount.DataPropertyName = "MaxAmount"
            DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
            DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle7.Format = "###,##0.00"
            Me.dgvMaxAmount.DefaultCellStyle = DataGridViewCellStyle7
            Me.dgvMaxAmount.EditingMode = False
            Me.dgvMaxAmount.EndFindValue = Nothing
            Me.dgvMaxAmount.FieldDescription = Nothing
            Me.dgvMaxAmount.FieldName = Nothing
            Me.dgvMaxAmount.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.dgvMaxAmount.FindEnabled = False
            resources.ApplyResources(Me.dgvMaxAmount, "dgvMaxAmount")
            Me.dgvMaxAmount.Name = "dgvMaxAmount"
            Me.dgvMaxAmount.ReadOnly = True
            Me.dgvMaxAmount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgvMaxAmount.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.dgvMaxAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.dgvMaxAmount.Translatable = False
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "PensionSchemeIdNo"
            resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'IdNoDataGridViewTextBoxColumn
            '
            Me.IdNoDataGridViewTextBoxColumn.DataPropertyName = "IdNo"
            resources.ApplyResources(Me.IdNoDataGridViewTextBoxColumn, "IdNoDataGridViewTextBoxColumn")
            Me.IdNoDataGridViewTextBoxColumn.Name = "IdNoDataGridViewTextBoxColumn"
            Me.IdNoDataGridViewTextBoxColumn.ReadOnly = True
            '
            'txtPensionSchemeNameAra
            '
            Me.txtPensionSchemeNameAra.BackColor = System.Drawing.Color.White
            Me.txtPensionSchemeNameAra.BegFindValue = Nothing
            Me.txtPensionSchemeNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPensionScheme.SetColumnSpan(Me.txtPensionSchemeNameAra, 3)
            Me.txtPensionSchemeNameAra.ComputedValue = False
            Me.txtPensionSchemeNameAra.CustomFormat = Nothing
            Me.txtPensionSchemeNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtPensionSchemeNameAra, "txtPensionSchemeNameAra")
            Me.txtPensionSchemeNameAra.EditingMode = False
            Me.txtPensionSchemeNameAra.EndFindValue = Nothing
            Me.txtPensionSchemeNameAra.EnglishControl = Me.txtPensionSchemeName
            Me.txtPensionSchemeNameAra.FieldDescription = Nothing
            Me.txtPensionSchemeNameAra.FieldName = Nothing
            Me.txtPensionSchemeNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPensionSchemeNameAra.FindEnabled = True
            Me.txtPensionSchemeNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtPensionSchemeNameAra.LinkedLabel = Nothing
            Me.txtPensionSchemeNameAra.MaximumValue = Nothing
            Me.txtPensionSchemeNameAra.MinimumValue = Nothing
            Me.txtPensionSchemeNameAra.Name = "txtPensionSchemeNameAra"
            Me.txtPensionSchemeNameAra.OldValue = Nothing
            Me.txtPensionSchemeNameAra.ReadOnly = True
            Me.txtPensionSchemeNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPensionSchemeNameAra.Translatable = False
            '
            'txtPensionSchemeName
            '
            Me.txtPensionSchemeName.BackColor = System.Drawing.Color.White
            Me.txtPensionSchemeName.BegFindValue = Nothing
            Me.txtPensionSchemeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tlpPensionScheme.SetColumnSpan(Me.txtPensionSchemeName, 3)
            Me.txtPensionSchemeName.ComputedValue = False
            Me.txtPensionSchemeName.CustomFormat = Nothing
            Me.txtPensionSchemeName.DataBoundControl = True
            resources.ApplyResources(Me.txtPensionSchemeName, "txtPensionSchemeName")
            Me.txtPensionSchemeName.EditingMode = False
            Me.txtPensionSchemeName.EndFindValue = Nothing
            Me.txtPensionSchemeName.FieldDescription = Nothing
            Me.txtPensionSchemeName.FieldName = Nothing
            Me.txtPensionSchemeName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPensionSchemeName.FindEnabled = True
            Me.txtPensionSchemeName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPensionSchemeName, CType(resources.GetObject("txtPensionSchemeName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtPensionSchemeName.LinkedLabel = Nothing
            Me.txtPensionSchemeName.MaximumValue = Nothing
            Me.txtPensionSchemeName.MinimumValue = Nothing
            Me.txtPensionSchemeName.Name = "txtPensionSchemeName"
            Me.txtPensionSchemeName.OldValue = Nothing
            Me.txtPensionSchemeName.ReadOnly = True
            Me.txtPensionSchemeName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPensionSchemeName.Translatable = False
            Me.txtPensionSchemeName.ValueIsMandatory = True
            '
            'lblName
            '
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            Me.lblName.Translatable = True
            '
            'txtPensionSchemeCode
            '
            Me.txtPensionSchemeCode.BackColor = System.Drawing.Color.White
            Me.txtPensionSchemeCode.BegFindValue = Nothing
            Me.txtPensionSchemeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPensionSchemeCode.ComputedValue = False
            Me.txtPensionSchemeCode.CustomFormat = Nothing
            Me.txtPensionSchemeCode.DataBoundControl = True
            Me.txtPensionSchemeCode.EditingMode = True
            Me.txtPensionSchemeCode.EndFindValue = Nothing
            Me.txtPensionSchemeCode.FieldDescription = Nothing
            Me.txtPensionSchemeCode.FieldName = Nothing
            Me.txtPensionSchemeCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPensionSchemeCode.FindEnabled = True
            resources.ApplyResources(Me.txtPensionSchemeCode, "txtPensionSchemeCode")
            Me.txtPensionSchemeCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPensionSchemeCode, CType(resources.GetObject("txtPensionSchemeCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtPensionSchemeCode.LinkedLabel = Nothing
            Me.txtPensionSchemeCode.MaximumValue = Nothing
            Me.txtPensionSchemeCode.MinimumValue = Nothing
            Me.txtPensionSchemeCode.Name = "txtPensionSchemeCode"
            Me.txtPensionSchemeCode.OldValue = Nothing
            Me.txtPensionSchemeCode.ReadOnly = True
            Me.txtPensionSchemeCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPensionSchemeCode.Translatable = False
            Me.txtPensionSchemeCode.ValueIsMandatory = True
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.CFlowLayout4)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'PensionSchemeEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "PensionSchemeEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsPensionRates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout4.ResumeLayout(False)
            Me.tlpPensionScheme.ResumeLayout(False)
            Me.tlpPensionScheme.PerformLayout()
            Me.tbcPensionScheme.ResumeLayout(False)
            Me.tbpMain.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.tlpMainTab.ResumeLayout(False)
            Me.tlpMainTab.PerformLayout()
            Me.tbpPensionRates.ResumeLayout(False)
            Me.tbpPensionRates.PerformLayout()
            Me.tlpPostingAccounts.ResumeLayout(False)
            CType(Me.DataGridViewPensionRates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents bsPensionRates As BindingSource
        Friend WithEvents CFlowLayout4 As CFlowLayout
        Friend WithEvents tlpPensionScheme As TableLayoutPanel
        Friend WithEvents txtPensionSchemeNameAra As CTextBoxArabic
        Friend WithEvents txtPensionSchemeName As CTextBox
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtPensionSchemeCode As CTextBox
        Friend WithEvents lblCode As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents PensionSchemeIdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
        Friend WithEvents tbcPensionScheme As CTabControl
        Friend WithEvents tbpMain As TabPage
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents tlpMainTab As TableLayoutPanel
        Friend WithEvents cboPensionProviderIdNo As CtCombobox
        Friend WithEvents lblPensionProviderIdNo As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents tbpPensionRates As TabPage
        Friend WithEvents tlpPostingAccounts As TableLayoutPanel
        Friend WithEvents lblAccountIdNo As CLabel
        Friend WithEvents cboAccountIdNo As CtCombobox
        Friend WithEvents DataGridViewPensionRates As CtDataGridView
        Friend WithEvents dgvSequence As CDgvTextColumn
        Friend WithEvents dgvLowRange As CdgvMoneyColumn
        Friend WithEvents dgvHighRange As CdgvMoneyColumn
        Friend WithEvents dgvEmployeeShare As CdgvMoneyColumn
        Friend WithEvents dgvEmployerShare As CdgvMoneyColumn
        Friend WithEvents dgvMaxAmount As CdgvMoneyColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Friend WithEvents IdNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    End Class
End Namespace