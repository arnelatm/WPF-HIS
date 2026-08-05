Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CListBoxForm
    Inherits Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        If GlobalVariables.RightToLeftLayout Then
            RightToLeftLayout = True
            SuggestListBox.RightToLeft = RightToLeft.Yes
            'RightToLeft = True
        Else
            RightToLeftLayout = False
            SuggestListBox.RightToLeft = RightToLeft.No
            'SuggestListForm.RightToLeft = False
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
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
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuggestListBox = New ListBox()
        Me.SuspendLayout()
        '
        'SuggestListBox
        '
        Me.SuggestListBox.Dock = DockStyle.Fill
        Me.SuggestListBox.FormattingEnabled = True
        Me.SuggestListBox.Location = New Point(0, 0)
        Me.SuggestListBox.Name = "SuggestListBox"
        Me.SuggestListBox.Size = New Size(200, 200)
        Me.SuggestListBox.TabIndex = 0
        '
        'CListBoxForm
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(200, 200)
        Me.Controls.Add(Me.SuggestListBox)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "CListBoxForm"
        Me.Text = "CListBoxForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SuggestListBox As ListBox
End Class
