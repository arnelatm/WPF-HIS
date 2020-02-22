Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class CListBoxForm
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()> _
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuggestListBox = New ListBox()
        Me.SuspendLayout
        '
        'SuggestListBox
        '
        Me.SuggestListBox.Dock = DockStyle.Fill
        Me.SuggestListBox.FormattingEnabled = true
        Me.SuggestListBox.Location = New Point(0, 0)
        Me.SuggestListBox.Name = "SuggestListBox"
        Me.SuggestListBox.Size = New Size(200, 200)
        Me.SuggestListBox.TabIndex = 0
        '
        'CListBoxForm
        '
        Me.AutoScaleDimensions = New SizeF(6!, 13!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(200, 200)
        Me.Controls.Add(Me.SuggestListBox)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "CListBoxForm"
        Me.Text = "CListBoxForm"
        Me.ResumeLayout(false)

    End Sub

    Friend WithEvents SuggestListBox As ListBox
End Class
