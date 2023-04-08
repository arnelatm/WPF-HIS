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
            SuggestGridBox.RightToLeft = RightToLeft.Yes
            'RightToLeft = True
        Else
            RightToLeftLayout = False
            SuggestGridBox.RightToLeft = RightToLeft.No
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
        Me.SuggestGridBox = New DataGridView()
        Me.SuspendLayout()
        '
        'SuggestGridBox
        '
        Me.SuggestGridBox.Dock = DockStyle.Fill
        Me.SuggestGridBox.Location = New Point(0, 0)
        Me.SuggestGridBox.Name = "SuggestGridBox"
        Me.SuggestGridBox.Size = New Size(200, 200)
        Me.SuggestGridBox.TabIndex = 0
        '
        'CListBoxForm
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(200, 200)
        Me.Controls.Add(Me.SuggestGridBox)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "CListBoxForm"
        Me.Text = "CListBoxForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SuggestGridBox As DataGridView
End Class
