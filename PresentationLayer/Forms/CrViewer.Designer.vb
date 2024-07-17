Imports System.ComponentModel
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CrViewer
    Inherits DFormBasic

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
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
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CrViewerObj = New CrystalReportViewer()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrViewerObj
        '
        Me.CrViewerObj.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.CrViewerObj.ActiveViewIndex = -1
        Me.CrViewerObj.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CrViewerObj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrViewerObj.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrViewerObj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrViewerObj.EnableDrillDown = False
        Me.CrViewerObj.Location = New System.Drawing.Point(0, 27)
        Me.CrViewerObj.MinimumSize = New System.Drawing.Size(1000, 800)
        Me.CrViewerObj.Name = "CrystalReportViewer1"
        Me.CrViewerObj.Size = New System.Drawing.Size(1466, 800)
        Me.CrViewerObj.TabIndex = 2
        '
        'CrViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1466, 669)
        Me.Controls.Add(Me.CrViewerObj)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "CrViewer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RightToLeftDisplay = "False"
        Me.Text = "Report Viewer"
        Me.Controls.SetChildIndex(Me.CrViewerObj, 0)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents CrViewerObj As CrystalReportViewer
End Class
