Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestForm
    Inherits CFormEntryTv

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestForm))
        Me.CTextBox1 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.BTextBox1 = New AATM.Libraries.BaseControlsLibrary.BTextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CTextBox2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.BTextBox2 = New AATM.Libraries.BaseControlsLibrary.BTextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BTextBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CTextBox2)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 397)
        '
        'FormTreeView
        '
        Me.FormTreeView.LineColor = System.Drawing.Color.Black
        Me.FormTreeView.Size = New System.Drawing.Size(266, 397)
        '
        'ImageListTreeView
        '
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
        Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
        '
        'CTextBox1
        '
        Me.CTextBox1.BackColor = System.Drawing.Color.White
        Me.CTextBox1.BegFindValue = Nothing
        Me.CTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox1.ComputedValue = False
        Me.CTextBox1.CustomFormat = Nothing
        Me.CTextBox1.DataBoundControl = True
        Me.CTextBox1.EditingMode = True
        Me.CTextBox1.EndFindValue = Nothing
        Me.CTextBox1.FieldDescription = Nothing
        Me.CTextBox1.FieldName = Nothing
        Me.CTextBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox1.FindEnabled = False
        Me.CTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CTextBox1.LinkedLabel = Nothing
        Me.CTextBox1.Location = New System.Drawing.Point(99, 66)
        Me.CTextBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox1.MaximumValue = Nothing
        Me.CTextBox1.MinimumValue = Nothing
        Me.CTextBox1.Name = "CTextBox1"
        Me.CTextBox1.OldValue = Nothing
        Me.CTextBox1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox1.TabIndex = 0
        Me.CTextBox1.Translatable = False
        '
        'BTextBox1
        '
        Me.BTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BTextBox1.Location = New System.Drawing.Point(99, 103)
        Me.BTextBox1.Name = "BTextBox1"
        Me.BTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.BTextBox1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(99, 139)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(269, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CTextBox"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(269, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "BTextBox"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "TextBox"
        '
        'CTextBox2
        '
        Me.CTextBox2.BackColor = System.Drawing.Color.White
        Me.CTextBox2.BegFindValue = Nothing
        Me.CTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CTextBox2.ComputedValue = False
        Me.CTextBox2.CustomFormat = Nothing
        Me.CTextBox2.DataBoundControl = True
        Me.CTextBox2.EditingMode = True
        Me.CTextBox2.EndFindValue = Nothing
        Me.CTextBox2.FieldDescription = Nothing
        Me.CTextBox2.FieldName = Nothing
        Me.CTextBox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.CTextBox2.FindEnabled = False
        Me.CTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CTextBox2.ForeColor = System.Drawing.Color.Black
        Me.CTextBox2.LinkedLabel = Nothing
        Me.CTextBox2.Location = New System.Drawing.Point(91, 86)
        Me.CTextBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.CTextBox2.MaximumValue = Nothing
        Me.CTextBox2.MinimumValue = Nothing
        Me.CTextBox2.Name = "CTextBox2"
        Me.CTextBox2.OldValue = Nothing
        Me.CTextBox2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.CTextBox2.Size = New System.Drawing.Size(100, 23)
        Me.CTextBox2.TabIndex = 0
        Me.CTextBox2.Translatable = False
        '
        'BTextBox2
        '
        Me.BTextBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BTextBox2.Location = New System.Drawing.Point(91, 147)
        Me.BTextBox2.Name = "BTextBox2"
        Me.BTextBox2.Size = New System.Drawing.Size(100, 20)
        Me.BTextBox2.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(91, 186)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(298, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BTextBox1)
        Me.Controls.Add(Me.CTextBox1)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.Controls.SetChildIndex(Me.CTextBox1, 0)
        Me.Controls.SetChildIndex(Me.BTextBox1, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CTextBox1 As Libraries.CBaseControlsLibrary.CTextBox
    Friend WithEvents BTextBox1 As Libraries.BaseControlsLibrary.BTextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents BTextBox2 As Libraries.BaseControlsLibrary.BTextBox
    Friend WithEvents CTextBox2 As CTextBox
    Friend WithEvents Button1 As Button
End Class
