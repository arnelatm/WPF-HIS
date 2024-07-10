<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DFormBasic
    Inherits AATM.Libraries.CBaseControlsLibrary.DForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DFormBasic))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnArabic = New System.Windows.Forms.ToolStripButton()
        Me.btnOriginal = New System.Windows.Forms.ToolStripButton()
        Me.btnTranslate = New System.Windows.Forms.ToolStripButton()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnDebug = New System.Windows.Forms.ToolStripButton()
        Me.btnQuit = New System.Windows.Forms.ToolStripButton()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDebug, Me.CopyToolStripButton, Me.CutToolStripButton, Me.btnArabic, Me.btnOriginal, Me.btnTranslate, Me.HelpToolStripButton, Me.btnQuit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'btnArabic
        '
        Me.btnArabic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnArabic.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArabic.Image = CType(resources.GetObject("btnArabic.Image"), System.Drawing.Image)
        Me.btnArabic.Name = "btnArabic"
        Me.btnArabic.Size = New System.Drawing.Size(24, 24)
        Me.btnArabic.Text = "Arabic"
        Me.btnArabic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArabic.ToolTipText = "Arabic"
        '
        'btnOriginal
        '
        Me.btnOriginal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOriginal.Image = CType(resources.GetObject("btnOriginal.Image"), System.Drawing.Image)
        Me.btnOriginal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOriginal.Name = "btnOriginal"
        Me.btnOriginal.Size = New System.Drawing.Size(24, 24)
        Me.btnOriginal.Text = "English"
        '
        'btnTranslate
        '
        Me.btnTranslate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTranslate.Font = New System.Drawing.Font("Arial Narrow", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnTranslate.Image = CType(resources.GetObject("btnTranslate.Image"), System.Drawing.Image)
        Me.btnTranslate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnTranslate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTranslate.Margin = New System.Windows.Forms.Padding(1)
        Me.btnTranslate.Name = "btnTranslate"
        Me.btnTranslate.Size = New System.Drawing.Size(23, 25)
        Me.btnTranslate.Text = "Translate"
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(24, 24)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'btnDebug
        '
        Me.btnDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDebug.Image = CType(resources.GetObject("btnDebug.Image"), System.Drawing.Image)
        Me.btnDebug.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.Size = New System.Drawing.Size(24, 24)
        Me.btnDebug.Text = "Set debugger on."
        '
        'btnQuit
        '
        Me.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnQuit.Image = CType(resources.GetObject("btnQuit.Image"), System.Drawing.Image)
        Me.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(24, 24)
        Me.btnQuit.Text = "Exit and close this form"
        '
        'DFormBasic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "DFormBasic"
        Me.Text = "DFormBase"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Public WithEvents btnArabic As Windows.Forms.ToolStripButton
    Friend WithEvents CutToolStripButton As Windows.Forms.ToolStripButton
    Public WithEvents btnOriginal As Windows.Forms.ToolStripButton
    Protected WithEvents btnTranslate As Windows.Forms.ToolStripButton
    Friend WithEvents HelpToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents btnQuit As Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As Windows.Forms.ToolStripButton
    Friend WithEvents btnDebug As Windows.Forms.ToolStripButton
End Class
