

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMonthPicker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CMonthPicker))
        Me.floMonthPicker = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.btnPrevMonth = New System.Windows.Forms.Button()
        Me.cboMonths = New AATM.Libraries.CBaseControlsLibrary.CComboBox()
        Me.spnYear = New System.Windows.Forms.NumericUpDown()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.floMonthPicker.SuspendLayout
        CType(Me.spnYear,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'floMonthPicker
        '
        Me.floMonthPicker.Controls.Add(Me.btnPrevMonth)
        Me.floMonthPicker.Controls.Add(Me.cboMonths)
        Me.floMonthPicker.Controls.Add(Me.spnYear)
        Me.floMonthPicker.Controls.Add(Me.btnNextMonth)
        Me.floMonthPicker.Location = New System.Drawing.Point(0, 0)
        Me.floMonthPicker.Margin = New System.Windows.Forms.Padding(0)
        Me.floMonthPicker.Name = "floMonthPicker"
        Me.floMonthPicker.Size = New System.Drawing.Size(212, 21)
        Me.floMonthPicker.TabIndex = 96
        '
        'btnPrevMonth
        '
        Me.btnPrevMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevMonth.Image = CType(resources.GetObject("btnPrevMonth.Image"),System.Drawing.Image)
        Me.btnPrevMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrevMonth.Location = New System.Drawing.Point(1, 1)
        Me.btnPrevMonth.Margin = New System.Windows.Forms.Padding(1)
        Me.btnPrevMonth.Name = "btnPrevMonth"
        Me.btnPrevMonth.Size = New System.Drawing.Size(18, 18)
        Me.btnPrevMonth.TabIndex = 1
        '
        'cboMonths
        '
        Me.cboMonths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMonths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMonths.BackColor = System.Drawing.Color.White
        Me.cboMonths.DefaultValue = Nothing
        Me.cboMonths.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboMonths.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cboMonths.ForeColor = System.Drawing.Color.Black
        Me.cboMonths.FormattingEnabled = true
        Me.cboMonths.HideWhenNotEditingOrAdding = false
        Me.cboMonths.LinkedLabel = Nothing
        Me.cboMonths.Location = New System.Drawing.Point(21, 1)
        Me.cboMonths.Margin = New System.Windows.Forms.Padding(1)
        Me.cboMonths.Name = "cboMonths"
        Me.cboMonths.OriginalDataSource = Nothing
        Me.cboMonths.OriginalDropDownStyle = 1
        Me.cboMonths.OriginalList = Nothing
        Me.cboMonths.PreviousSelectedIndex = -1
        Me.cboMonths.ReadOnlyCombo = false
        Me.cboMonths.EditingMode = false
        Me.cboMonths.Size = New System.Drawing.Size(107, 22)
        Me.cboMonths.TabIndex = 1
        Me.cboMonths.ValueIsMandatory = false
        Me.cboMonths.ValueIsNullable = false
        Me.cboMonths.ValueIsNumeric = false
        Me.cboMonths.DisplayOnly = false
        '
        'spnYear
        '
        Me.spnYear.Dock = System.Windows.Forms.DockStyle.Left
        Me.spnYear.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spnYear.Location = New System.Drawing.Point(130, 1)
        Me.spnYear.Margin = New System.Windows.Forms.Padding(1)
        Me.spnYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.spnYear.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.spnYear.Name = "spnYear"
        Me.spnYear.Size = New System.Drawing.Size(58, 21)
        Me.spnYear.TabIndex = 3
        Me.spnYear.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'btnNextMonth
        '
        Me.btnNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextMonth.Font = New System.Drawing.Font("Tahoma", 8!, System.Drawing.FontStyle.Bold)
        Me.btnNextMonth.Image = CType(resources.GetObject("btnNextMonth.Image"),System.Drawing.Image)
        Me.btnNextMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNextMonth.Location = New System.Drawing.Point(190, 1)
        Me.btnNextMonth.Margin = New System.Windows.Forms.Padding(1)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(18, 18)
        Me.btnNextMonth.TabIndex = 2
        '
        'CMonthPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.floMonthPicker)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "CMonthPicker"
        Me.Size = New System.Drawing.Size(210, 22)
        Me.floMonthPicker.ResumeLayout(false)
        CType(Me.spnYear,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

    End Sub
    Private WithEvents btnNextMonth As Windows.Forms.Button
    Friend WithEvents cboMonths As CComboBox
    Private WithEvents btnPrevMonth As Windows.Forms.Button
    Friend WithEvents floMonthPicker As CFlowLayout
    Private WithEvents spnYear As Windows.Forms.NumericUpDown
End Class
