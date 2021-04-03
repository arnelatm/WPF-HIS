Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class CFindForm
    Inherits CForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.lblLookFor1 = New System.Windows.Forms.Label()
        Me.RBtnStart = New System.Windows.Forms.RadioButton()
        Me.RBtnAnywhere = New System.Windows.Forms.RadioButton()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLookFor2 = New System.Windows.Forms.Label()
        Me.cboTextToSearch = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTextToSearch
        '
        Me.TxtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTextToSearch.Location = New System.Drawing.Point(58, 3)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(245, 20)
        Me.TxtTextToSearch.TabIndex = 0
        '
        'lblLookFor1
        '
        Me.lblLookFor1.AutoSize = True
        Me.lblLookFor1.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor1.Location = New System.Drawing.Point(3, 0)
        Me.lblLookFor1.Name = "lblLookFor1"
        Me.lblLookFor1.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor1.TabIndex = 1
        Me.lblLookFor1.Text = "Look For"
        '
        'RBtnStart
        '
        Me.RBtnStart.AutoSize = True
        Me.RBtnStart.BackColor = System.Drawing.Color.Transparent
        Me.RBtnStart.Checked = True
        Me.RBtnStart.Location = New System.Drawing.Point(58, 55)
        Me.RBtnStart.Name = "RBtnStart"
        Me.RBtnStart.Size = New System.Drawing.Size(84, 17)
        Me.RBtnStart.TabIndex = 2
        Me.RBtnStart.TabStop = True
        Me.RBtnStart.Text = "Start of Field"
        Me.RBtnStart.UseVisualStyleBackColor = False
        '
        'RBtnAnywhere
        '
        Me.RBtnAnywhere.AutoSize = True
        Me.RBtnAnywhere.BackColor = System.Drawing.Color.Transparent
        Me.RBtnAnywhere.Location = New System.Drawing.Point(58, 78)
        Me.RBtnAnywhere.Name = "RBtnAnywhere"
        Me.RBtnAnywhere.Size = New System.Drawing.Size(112, 17)
        Me.RBtnAnywhere.TabIndex = 3
        Me.RBtnAnywhere.Text = "Anywhere on Field"
        Me.RBtnAnywhere.UseVisualStyleBackColor = False
        '
        'BtnFind
        '
        Me.BtnFind.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnFind.Location = New System.Drawing.Point(37, 3)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(75, 23)
        Me.BtnFind.TabIndex = 4
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(187, 3)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTextToSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RBtnAnywhere, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTextToSearch, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.RBtnStart, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(306, 136)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'lblLookFor2
        '
        Me.lblLookFor2.AutoSize = True
        Me.lblLookFor2.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor2.Location = New System.Drawing.Point(3, 26)
        Me.lblLookFor2.Name = "lblLookFor2"
        Me.lblLookFor2.Size = New System.Drawing.Size(49, 13)
        Me.lblLookFor2.TabIndex = 2
        Me.lblLookFor2.Text = "Look For"
        '
        'cboTextToSearch
        '
        Me.cboTextToSearch.BackColor = System.Drawing.Color.White
        Me.cboTextToSearch.ChangingSearchValueOnly = False
        Me.cboTextToSearch.CurrentSearchTerm = ""
        Me.cboTextToSearch.DefaultValue = Nothing
        Me.cboTextToSearch.DisplayMember = "Name"
        Me.cboTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTextToSearch.EditingMode = True
        Me.cboTextToSearch.FilterRule = Nothing
        Me.cboTextToSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cboTextToSearch.ForeColor = System.Drawing.Color.Black
        Me.cboTextToSearch.FormattingEnabled = True
        Me.cboTextToSearch.HideWhenNotEditingOrAdding = False
        Me.cboTextToSearch.IntegralHeight = False
        Me.cboTextToSearch.LinkedLabel = Nothing
        Me.cboTextToSearch.Location = New System.Drawing.Point(56, 27)
        Me.cboTextToSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.cboTextToSearch.Name = "cboTextToSearch"
        Me.cboTextToSearch.OldValue = 0
        Me.cboTextToSearch.OriginalDataSource = Nothing
        Me.cboTextToSearch.OriginalList = Nothing
        Me.cboTextToSearch.OverrideDropDownStyleList = False
        Me.cboTextToSearch.PreviousSearchTerm = Nothing
        Me.cboTextToSearch.PreviousSelectedIndex = -1
        Me.cboTextToSearch.PropertySelector = Nothing
        Me.cboTextToSearch.ReadOnlyCombo = False
        Me.cboTextToSearch.SearchAnywhere = False
        Me.cboTextToSearch.SearchField = Nothing
        Me.cboTextToSearch.Size = New System.Drawing.Size(249, 24)
        Me.cboTextToSearch.SuggestBoxHeight = 200
        Me.cboTextToSearch.SuggestListOrderRule = Nothing
        Me.cboTextToSearch.TabIndex = 3
        Me.cboTextToSearch.TextToSearch = Nothing
        Me.cboTextToSearch.ValueIsMandatory = False
        Me.cboTextToSearch.ValueIsNullable = False
        Me.cboTextToSearch.ValueIsNumeric = False
        Me.cboTextToSearch.ValueMember = "IdNo"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel1.SetColumnSpan(Me.TableLayoutPanel2, 2)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.BtnFind, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnCancel, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 101)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(300, 30)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'CFindForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(330, 162)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CFindForm"
        Me.Text = "Find Field Form"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents lblLookFor1 As Label
    Friend WithEvents RBtnStart As RadioButton
    Friend WithEvents RBtnAnywhere As RadioButton
    Friend WithEvents BtnFind As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblLookFor2 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Public WithEvents cboTextToSearch As CaComboBox
End Class
