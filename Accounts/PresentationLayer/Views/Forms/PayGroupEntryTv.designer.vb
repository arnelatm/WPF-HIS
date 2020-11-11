Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PayGroupEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayGroupEntryTv))
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLevelNumber = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
        Me.txtPayGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblNote = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.txtPayGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboParentIdNo = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
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
        'AppDataDAC
        '
        Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
        '
        'floDataDisplay
        '
        resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
        Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
        Me.floDataDisplay.Name = "floDataDisplay"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.txtLevelNumber, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayGroupNameAra, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNote, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblParentIdNo, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNameAra, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayGroupName, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPayGroupCode, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cboParentIdNo, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 11)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'txtLevelNumber
        '
        Me.txtLevelNumber.BackColor = System.Drawing.Color.White
        Me.txtLevelNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLevelNumber.ComputedValue = false
        Me.txtLevelNumber.CustomFormat = Nothing
        Me.txtLevelNumber.DataBoundControl = true
        Me.txtLevelNumber.DisplayOnly = true
        Me.txtLevelNumber.EditingMode = true
        resources.ApplyResources(Me.txtLevelNumber, "txtLevelNumber")
        Me.txtLevelNumber.ForeColor = System.Drawing.Color.Black
        Me.txtLevelNumber.LinkedLabel = Nothing
        Me.txtLevelNumber.MaximumValue = Nothing
        Me.txtLevelNumber.MinimumValue = Nothing
        Me.txtLevelNumber.Name = "txtLevelNumber"
        Me.txtLevelNumber.OldValue = Nothing
        Me.txtLevelNumber.ReadOnly = true
        Me.txtLevelNumber.ValueIsMandatory = true
        '
        'CLabel1
        '
        resources.ApplyResources(Me.CLabel1, "CLabel1")
        Me.CLabel1.DisplayOnly = true
        Me.CLabel1.EditingMode = false
        Me.CLabel1.Name = "CLabel1"
        '
        'txtPayGroupNameAra
        '
        Me.txtPayGroupNameAra.BackColor = System.Drawing.Color.White
        Me.txtPayGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayGroupNameAra, 2)
        Me.txtPayGroupNameAra.ComputedValue = false
        Me.txtPayGroupNameAra.CustomFormat = Nothing
        Me.txtPayGroupNameAra.DataBoundControl = true
        resources.ApplyResources(Me.txtPayGroupNameAra, "txtPayGroupNameAra")
        Me.txtPayGroupNameAra.EditingMode = false
        Me.txtPayGroupNameAra.EnglishControl = Me.txtPayGroupName
        Me.txtPayGroupNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtPayGroupNameAra.LinkedLabel = Nothing
        Me.txtPayGroupNameAra.MaximumValue = Nothing
        Me.txtPayGroupNameAra.MinimumValue = Nothing
        Me.txtPayGroupNameAra.Name = "txtPayGroupNameAra"
        Me.txtPayGroupNameAra.OldValue = Nothing
        Me.txtPayGroupNameAra.ReadOnly = true
        '
        'txtPayGroupName
        '
        Me.txtPayGroupName.BackColor = System.Drawing.Color.White
        Me.txtPayGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtPayGroupName, 2)
        Me.txtPayGroupName.ComputedValue = false
        Me.txtPayGroupName.CustomFormat = Nothing
        Me.txtPayGroupName.DataBoundControl = true
        resources.ApplyResources(Me.txtPayGroupName, "txtPayGroupName")
        Me.txtPayGroupName.EditingMode = false
        Me.txtPayGroupName.ForeColor = System.Drawing.Color.Black
        Me.txtPayGroupName.LinkedLabel = Nothing
        Me.txtPayGroupName.MaximumValue = Nothing
        Me.txtPayGroupName.MinimumValue = Nothing
        Me.txtPayGroupName.Name = "txtPayGroupName"
        Me.txtPayGroupName.OldValue = Nothing
        Me.txtPayGroupName.ReadOnly = true
        Me.txtPayGroupName.ValueIsMandatory = true
        '
        'lblNote
        '
        resources.ApplyResources(Me.lblNote, "lblNote")
        Me.lblNote.DisplayOnly = true
        Me.lblNote.EditingMode = false
        Me.lblNote.Name = "lblNote"
        '
        'lblParentIdNo
        '
        resources.ApplyResources(Me.lblParentIdNo, "lblParentIdNo")
        Me.lblParentIdNo.DisplayOnly = true
        Me.lblParentIdNo.EditingMode = false
        Me.lblParentIdNo.Name = "lblParentIdNo"
        '
        'lblNameAra
        '
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblNameAra, 2)
        Me.lblNameAra.DisplayOnly = true
        Me.lblNameAra.EditingMode = false
        Me.lblNameAra.Name = "lblNameAra"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        Me.lblName.Name = "lblName"
        '
        'txtPayGroupCode
        '
        Me.txtPayGroupCode.BackColor = System.Drawing.Color.White
        Me.txtPayGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPayGroupCode.ComputedValue = false
        Me.txtPayGroupCode.CustomFormat = Nothing
        Me.txtPayGroupCode.DataBoundControl = true
        Me.txtPayGroupCode.EditingMode = true
        resources.ApplyResources(Me.txtPayGroupCode, "txtPayGroupCode")
        Me.txtPayGroupCode.ForeColor = System.Drawing.Color.Black
        Me.txtPayGroupCode.LinkedLabel = Nothing
        Me.txtPayGroupCode.MaximumValue = Nothing
        Me.txtPayGroupCode.MinimumValue = Nothing
        Me.txtPayGroupCode.Name = "txtPayGroupCode"
        Me.txtPayGroupCode.OldValue = Nothing
        Me.txtPayGroupCode.ReadOnly = true
        Me.txtPayGroupCode.ValueIsMandatory = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Name = "lblIdNo"
        '
        'lblCode
        '
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.DisplayOnly = true
        Me.lblCode.EditingMode = false
        Me.lblCode.Name = "lblCode"
        '
        'cboParentIdNo
        '
        Me.cboParentIdNo.BackColor = System.Drawing.Color.White
        Me.cboParentIdNo.ChangingSearchValueOnly = false
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboParentIdNo, 2)
        Me.cboParentIdNo.CurrentSearchTerm = ""
        Me.cboParentIdNo.DefaultValue = Nothing
        Me.cboParentIdNo.DisplayMember = "Name"
        resources.ApplyResources(Me.cboParentIdNo, "cboParentIdNo")
        Me.cboParentIdNo.DropDownHeight = 200
        Me.cboParentIdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParentIdNo.EditingMode = true
        Me.cboParentIdNo.FilterRule = Nothing
        Me.cboParentIdNo.ForeColor = System.Drawing.Color.Black
        Me.cboParentIdNo.FormattingEnabled = true
        Me.cboParentIdNo.HideWhenNotEditingOrAdding = false
        Me.cboParentIdNo.LinkedLabel = Me.lblParentIdNo
        Me.cboParentIdNo.Name = "cboParentIdNo"
        Me.cboParentIdNo.OldValue = 0
        Me.cboParentIdNo.OriginalDataSource = Nothing
        Me.cboParentIdNo.OriginalList = Nothing
        Me.cboParentIdNo.OverrideDropDownStyleList = false
        Me.cboParentIdNo.PreviousSearchTerm = Nothing
        Me.cboParentIdNo.PreviousSelectedIndex = -1
        Me.cboParentIdNo.PropertySelector = Nothing
        Me.cboParentIdNo.ReadOnlyCombo = false
        Me.cboParentIdNo.SearchAnywhere = false
        Me.cboParentIdNo.SuggestBoxHeight = 200
        Me.cboParentIdNo.SuggestListOrderRule = Nothing
        Me.cboParentIdNo.TextToSearch = Nothing
        Me.cboParentIdNo.ValueIsMandatory = false
        Me.cboParentIdNo.ValueIsNullable = false
        Me.cboParentIdNo.ValueIsNumeric = false
        Me.cboParentIdNo.ValueMember = "IdNo"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 2)
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.EditingMode = true
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Me.lblNote
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        '
        'PayGroupEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "PayGroupEntry"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents txtPayGroupNameAra As CTextBoxArabic
        Friend WithEvents txtPayGroupName As CTextBox
        Friend WithEvents lblNote As CLabel
        Friend WithEvents lblParentIdNo As CLabel
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtPayGroupCode As CTextBox
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
        Friend WithEvents cboParentIdNo As CaComboBox
        Friend WithEvents txtLevelNumber As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtNotes As CTextBox
    End Class
End Namespace