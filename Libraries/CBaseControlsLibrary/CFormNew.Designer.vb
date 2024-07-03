Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.BaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CFormNew
    Inherits BForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CFormNew))
        Me.SuspendLayout()
        '
        'CFormNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Name = "CFormNew"
        Me.ResumeLayout(False)

    End Sub
End Class
