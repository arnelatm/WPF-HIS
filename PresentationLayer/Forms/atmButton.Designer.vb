<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class atmButton
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(atmButton))
        Me.cButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cButton
        '
        Me.cButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cButton.BackgroundImage = CType(resources.GetObject("cButton.BackgroundImage"), System.Drawing.Image)
        Me.cButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cButton.Location = New System.Drawing.Point(0, 0)
        Me.cButton.Margin = New System.Windows.Forms.Padding(0)
        Me.cButton.Name = "cButton"
        Me.cButton.Size = New System.Drawing.Size(75, 23)
        Me.cButton.TabIndex = 0
        Me.cButton.Text = "Button1"
        Me.cButton.UseVisualStyleBackColor = True
        '
        'atmButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cButton)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "atmButton"
        Me.Size = New System.Drawing.Size(75, 23)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cButton As Windows.Forms.Button
End Class
