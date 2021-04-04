

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TxtComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cboComboBox = New CComboBox()
        Me.TxtTextBox = New CTextBox()
        Me.txtReadOnly = New CTextBox()
        Me.SuspendLayout
        '
        'cboComboBox
        '
        Me.cboComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboComboBox.BackColor = System.Drawing.Color.White
        Me.cboComboBox.DefaultValue = Nothing
        Me.cboComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.cboComboBox.ForeColor = System.Drawing.Color.Black
        Me.cboComboBox.FormattingEnabled = true
        Me.cboComboBox.HideWhenNotEditingOrAdding = true
        Me.cboComboBox.LinkedLabel = Nothing
        Me.cboComboBox.Location = New System.Drawing.Point(0, 0)
        Me.cboComboBox.Margin = New System.Windows.Forms.Padding(1)
        Me.cboComboBox.Name = "cboComboBox"
        Me.cboComboBox.OriginalDropDownStyle = 1
        Me.cboComboBox.PreviousSelectedIndex = 0
        Me.cboComboBox.ReadOnlyCombo = false
        Me.cboComboBox.EditingMode = false
        Me.cboComboBox.Size = New System.Drawing.Size(220, 24)
        Me.cboComboBox.TabIndex = 3
        Me.cboComboBox.ValueIsMandatory = false
        Me.cboComboBox.ValueIsNullable = false
        Me.cboComboBox.ValueIsNumeric = false
        Me.cboComboBox.DisplayOnly = false
        '
        'TxtTextBox
        '
        Me.TxtTextBox.AcceptsReturn = false
        Me.TxtTextBox.AcceptsTab = false
        Me.TxtTextBox.BackColor = System.Drawing.Color.White
        Me.TxtTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTextBox.ComputedValue = false
        Me.TxtTextBox.DataBoundControl = true
        Me.TxtTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtTextBox.ForeColor = System.Drawing.Color.Black
        Me.TxtTextBox.LinkedLabel = Nothing
        Me.TxtTextBox.Location = New System.Drawing.Point(0, 0)
        Me.TxtTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtTextBox.Name = "TxtTextBox"
        Me.TxtTextBox.EditingMode = false
        Me.TxtTextBox.Size = New System.Drawing.Size(200, 23)
        Me.TxtTextBox.TabIndex = 2
        '
        'txtReadOnly
        '
        Me.txtReadOnly.AcceptsReturn = false
        Me.txtReadOnly.AcceptsTab = false
        Me.txtReadOnly.BackColor = System.Drawing.Color.White
        Me.txtReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReadOnly.ComputedValue = false
        Me.txtReadOnly.DataBoundControl = true
        Me.txtReadOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtReadOnly.ForeColor = System.Drawing.Color.Black
        Me.txtReadOnly.LinkedLabel = Nothing
        Me.txtReadOnly.Location = New System.Drawing.Point(0, 0)
        Me.txtReadOnly.Margin = New System.Windows.Forms.Padding(0)
        Me.txtReadOnly.Name = "txtReadOnly"
        Me.txtReadOnly.EditingMode = false
        Me.txtReadOnly.Size = New System.Drawing.Size(200, 23)
        Me.txtReadOnly.TabIndex = 4
        '
        'TxtComboBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.cboComboBox)
        Me.Controls.Add(Me.TxtTextBox)
        Me.Controls.Add(Me.txtReadOnly)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "TxtComboBox"
        Me.Size = New System.Drawing.Size(218, 25)
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub

    Friend WithEvents cboComboBox As CComboBox
    Friend WithEvents TxtTextBox As CTextBox
    Friend WithEvents txtReadOnly As CTextBox
End Class
