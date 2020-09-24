Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LeaveEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LeaveEntryTv))
            Me.LeaveView1 = New AATM.Accounts.PresentationLayer.Views.LeaveView()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            '
            'LeaveView1
            '
            Me.LeaveView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.LeaveView1.Errors = Nothing
            Me.LeaveView1.IdNo = CType(0, Short)
            Me.LeaveView1.LeaveCode = ""
            Me.LeaveView1.LeaveName = ""
            Me.LeaveView1.LeaveNameAra = ""
            resources.ApplyResources(Me.LeaveView1, "LeaveView1")
            Me.LeaveView1.Name = "LeaveView1"
            Me.LeaveView1.Notes = ""
            Me.LeaveView1.PaidPercent = New Decimal(New Integer() {0, 0, 0, 0})
            '
            'LeaveEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.LeaveView1)
            Me.Name = "LeaveEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.LeaveView1, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents LeaveView1 As LeaveView
    End Class
End Namespace