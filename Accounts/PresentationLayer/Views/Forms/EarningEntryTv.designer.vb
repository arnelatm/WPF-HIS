Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EarningEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EarningEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEarningCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEarningName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtEarningNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.tbcEarning = New AATM.Libraries.CBaseControlsLibrary.CTabControl()
            Me.Main = New System.Windows.Forms.TabPage()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblAccountIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboFrequency = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblFrequency = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboEarningType = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
            Me.lblEarningType = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.tbpAccountPosting = New System.Windows.Forms.TabPage()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.tbcEarning.SuspendLayout()
            Me.Main.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtEarningCode
            '
            Me.txtEarningCode.BackColor = System.Drawing.Color.White
            Me.txtEarningCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEarningCode.ComputedValue = False
            Me.txtEarningCode.CustomFormat = Nothing
            Me.txtEarningCode.DataBoundControl = True
            Me.txtEarningCode.EditingMode = True
            resources.ApplyResources(Me.txtEarningCode, "txtEarningCode")
            Me.txtEarningCode.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtEarningCode, CType(resources.GetObject("txtEarningCode.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.MyErrorProvider.SetIconPadding(Me.txtEarningCode, CType(resources.GetObject("txtEarningCode.IconPadding"), Integer))
            Me.txtEarningCode.LinkedLabel = Nothing
            Me.txtEarningCode.MaximumValue = Nothing
            Me.txtEarningCode.MinimumValue = Nothing
            Me.txtEarningCode.Name = "txtEarningCode"
            Me.txtEarningCode.OldValue = Nothing
            Me.txtEarningCode.ReadOnly = True
            Me.txtEarningCode.ValueIsMandatory = True
            '
            'txtEarningName
            '
            Me.txtEarningName.BackColor = System.Drawing.Color.White
            Me.txtEarningName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtEarningName, 2)
            Me.txtEarningName.ComputedValue = False
            Me.txtEarningName.CustomFormat = Nothing
            Me.txtEarningName.DataBoundControl = True
            resources.ApplyResources(Me.txtEarningName, "txtEarningName")
            Me.txtEarningName.EditingMode = False
            Me.txtEarningName.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtEarningName, CType(resources.GetObject("txtEarningName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
            Me.txtEarningName.LinkedLabel = Nothing
            Me.txtEarningName.MaximumValue = Nothing
            Me.txtEarningName.MinimumValue = Nothing
            Me.txtEarningName.Name = "txtEarningName"
            Me.txtEarningName.OldValue = Nothing
            Me.txtEarningName.ReadOnly = True
            Me.txtEarningName.ValueIsMandatory = True
            '
            'txtEarningNameAra
            '
            Me.txtEarningNameAra.BackColor = System.Drawing.Color.White
            Me.txtEarningNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtEarningNameAra, 2)
            Me.txtEarningNameAra.ComputedValue = False
            Me.txtEarningNameAra.CustomFormat = Nothing
            Me.txtEarningNameAra.DataBoundControl = True
            resources.ApplyResources(Me.txtEarningNameAra, "txtEarningNameAra")
            Me.txtEarningNameAra.EditingMode = False
            Me.txtEarningNameAra.EnglishControl = Me.txtEarningName
            Me.txtEarningNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtEarningNameAra.LinkedLabel = Nothing
            Me.txtEarningNameAra.MaximumValue = Nothing
            Me.txtEarningNameAra.MinimumValue = Nothing
            Me.txtEarningNameAra.Name = "txtEarningNameAra"
            Me.txtEarningNameAra.OldValue = Nothing
            Me.txtEarningNameAra.ReadOnly = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 2)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.tbcEarning)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'tbcEarning
            '
            Me.tbcEarning.Controls.Add(Me.Main)
            Me.tbcEarning.Controls.Add(Me.tbpAccountPosting)
            resources.ApplyResources(Me.tbcEarning, "tbcEarning")
            Me.tbcEarning.Name = "tbcEarning"
            Me.tbcEarning.SelectedIndex = 0
            '
            'Main
            '
            Me.Main.Controls.Add(Me.CFlowLayout1)
            resources.ApplyResources(Me.Main, "Main")
            Me.Main.Name = "Main"
            Me.Main.UseVisualStyleBackColor = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel1)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.cboAccountIdNo, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.lblAccountIdNo, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.cboFrequency, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblFrequency, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.cboEarningType, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.lblEarningType, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEarningNameAra, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNameAra, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEarningCode, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.txtEarningName, 0, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'cboAccountIdNo
            '
            Me.cboAccountIdNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboAccountIdNo.BackColor = System.Drawing.Color.White
            Me.cboAccountIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboAccountIdNo, 2)
            Me.cboAccountIdNo.CurrentSearchTerm = ""
            Me.cboAccountIdNo.DefaultValue = Nothing
            Me.cboAccountIdNo.DisplayMember = "Name"
            resources.ApplyResources(Me.cboAccountIdNo, "cboAccountIdNo")
            Me.cboAccountIdNo.DropDownHeight = 1
            Me.cboAccountIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboAccountIdNo.EditingMode = False
            Me.cboAccountIdNo.FilterRule = Nothing
            Me.cboAccountIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboAccountIdNo.FormattingEnabled = True
            Me.cboAccountIdNo.HideWhenNotEditingOrAdding = False
            Me.cboAccountIdNo.LinkedLabel = Me.lblAccountIdNo
            Me.cboAccountIdNo.Name = "cboAccountIdNo"
            Me.cboAccountIdNo.OldValue = 0
            Me.cboAccountIdNo.OriginalDataSource = Nothing
            Me.cboAccountIdNo.OriginalList = Nothing
            Me.cboAccountIdNo.OverrideDropDownStyleList = False
            Me.cboAccountIdNo.PreviousSearchTerm = Nothing
            Me.cboAccountIdNo.PreviousSelectedIndex = -1
            Me.cboAccountIdNo.PropertySelector = Nothing
            Me.cboAccountIdNo.ReadOnlyCombo = False
            Me.cboAccountIdNo.SearchAnywhere = False
            Me.cboAccountIdNo.SuggestBoxHeight = 200
            Me.cboAccountIdNo.SuggestListOrderRule = Nothing
            Me.cboAccountIdNo.TextToSearch = Nothing
            Me.cboAccountIdNo.ValueIsMandatory = False
            Me.cboAccountIdNo.ValueIsNullable = False
            Me.cboAccountIdNo.ValueIsNumeric = False
            Me.cboAccountIdNo.ValueMember = "Code"
            '
            'lblAccountIdNo
            '
            Me.lblAccountIdNo.DisplayOnly = True
            Me.lblAccountIdNo.EditingMode = False
            resources.ApplyResources(Me.lblAccountIdNo, "lblAccountIdNo")
            Me.lblAccountIdNo.Name = "lblAccountIdNo"
            '
            'cboFrequency
            '
            Me.cboFrequency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboFrequency.BackColor = System.Drawing.Color.White
            Me.cboFrequency.ChangingSearchValueOnly = False
            Me.cboFrequency.CurrentSearchTerm = ""
            Me.cboFrequency.DefaultValue = Nothing
            Me.cboFrequency.DisplayMember = "Name"
            resources.ApplyResources(Me.cboFrequency, "cboFrequency")
            Me.cboFrequency.DropDownHeight = 1
            Me.cboFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFrequency.EditingMode = False
            Me.cboFrequency.FilterRule = Nothing
            Me.cboFrequency.ForeColor = System.Drawing.Color.Black
            Me.cboFrequency.FormattingEnabled = True
            Me.cboFrequency.HideWhenNotEditingOrAdding = False
            Me.cboFrequency.LinkedLabel = Nothing
            Me.cboFrequency.Name = "cboFrequency"
            Me.cboFrequency.OldValue = 0
            Me.cboFrequency.OriginalDataSource = Nothing
            Me.cboFrequency.OriginalList = Nothing
            Me.cboFrequency.OverrideDropDownStyleList = False
            Me.cboFrequency.PreviousSearchTerm = Nothing
            Me.cboFrequency.PreviousSelectedIndex = -1
            Me.cboFrequency.PropertySelector = Nothing
            Me.cboFrequency.ReadOnlyCombo = False
            Me.cboFrequency.SearchAnywhere = False
            Me.cboFrequency.SuggestBoxHeight = 200
            Me.cboFrequency.SuggestListOrderRule = Nothing
            Me.cboFrequency.TextToSearch = Nothing
            Me.cboFrequency.ValueIsMandatory = False
            Me.cboFrequency.ValueIsNullable = False
            Me.cboFrequency.ValueIsNumeric = False
            Me.cboFrequency.ValueMember = "Code"
            '
            'lblFrequency
            '
            Me.lblFrequency.DisplayOnly = True
            Me.lblFrequency.EditingMode = False
            resources.ApplyResources(Me.lblFrequency, "lblFrequency")
            Me.lblFrequency.Name = "lblFrequency"
            '
            'cboEarningType
            '
            Me.cboEarningType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.cboEarningType.BackColor = System.Drawing.Color.White
            Me.cboEarningType.ChangingSearchValueOnly = False
            Me.cboEarningType.CurrentSearchTerm = ""
            Me.cboEarningType.DefaultValue = ""
            Me.cboEarningType.DisplayMember = "Name"
            resources.ApplyResources(Me.cboEarningType, "cboEarningType")
            Me.cboEarningType.DropDownHeight = 1
            Me.cboEarningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboEarningType.EditingMode = False
            Me.cboEarningType.FilterRule = Nothing
            Me.cboEarningType.ForeColor = System.Drawing.Color.Black
            Me.cboEarningType.HideWhenNotEditingOrAdding = False
            Me.cboEarningType.LinkedLabel = Me.lblEarningType
            Me.cboEarningType.Name = "cboEarningType"
            Me.cboEarningType.OldValue = 0
            Me.cboEarningType.OriginalDataSource = Nothing
            Me.cboEarningType.OriginalList = Nothing
            Me.cboEarningType.OverrideDropDownStyleList = False
            Me.cboEarningType.PreviousSearchTerm = Nothing
            Me.cboEarningType.PreviousSelectedIndex = 0
            Me.cboEarningType.PropertySelector = Nothing
            Me.cboEarningType.ReadOnlyCombo = False
            Me.cboEarningType.SearchAnywhere = False
            Me.cboEarningType.SuggestBoxHeight = 200
            Me.cboEarningType.SuggestListOrderRule = Nothing
            Me.cboEarningType.TextToSearch = Nothing
            Me.cboEarningType.ValueIsMandatory = False
            Me.cboEarningType.ValueIsNullable = False
            Me.cboEarningType.ValueIsNumeric = False
            Me.cboEarningType.ValueMember = "Code"
            '
            'lblEarningType
            '
            Me.lblEarningType.DisplayOnly = True
            Me.lblEarningType.EditingMode = False
            resources.ApplyResources(Me.lblEarningType, "lblEarningType")
            Me.lblEarningType.Name = "lblEarningType"
            '
            'lblNameAra
            '
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.Name = "lblNameAra"
            '
            'lblName
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.Name = "lblName"
            '
            'lblCode
            '
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.Name = "lblCode"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'tbpAccountPosting
            '
            resources.ApplyResources(Me.tbpAccountPosting, "tbpAccountPosting")
            Me.tbpAccountPosting.Name = "tbpAccountPosting"
            Me.tbpAccountPosting.UseVisualStyleBackColor = True
            '
            'EarningEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "EarningEntryTv"
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.tbcEarning.ResumeLayout(False)
            Me.Main.ResumeLayout(False)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtEarningCode As CTextBox
        Friend WithEvents txtEarningName As CTextBox
        Friend WithEvents txtEarningNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents lblFrequency As CLabel
        Friend WithEvents lblEarningType As CLabel
        Friend WithEvents cboEarningType As CaComboBox
        Friend WithEvents cboFrequency As CaComboBox
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents tbcEarning As CTabControl
        Friend WithEvents Main As TabPage
        Friend WithEvents tbpAccountPosting As TabPage
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents cboAccountIdNo As CaComboBox
        Friend WithEvents lblAccountIdNo As CLabel
    End Class
End Namespace