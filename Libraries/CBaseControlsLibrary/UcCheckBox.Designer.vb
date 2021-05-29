<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcCheckBox
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
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.checkBox = New AATM.Libraries.CBaseControlsLibrary.CCheckBoxNew()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CFlowLayout1
        '
        Me.CFlowLayout1.AutoSize = True
        Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
        Me.CFlowLayout1.Controls.Add(Me.checkBox)
        Me.CFlowLayout1.Controls.Add(Me.CLabel1)
        Me.CFlowLayout1.Location = New System.Drawing.Point(0, 0)
        Me.CFlowLayout1.Name = "CFlowLayout1"
        Me.CFlowLayout1.Size = New System.Drawing.Size(80, 21)
        Me.CFlowLayout1.TabIndex = 0
        '
        'checkBox
        '
        Me.checkBox.AutoSize = True
        Me.checkBox.BegFindValue = Nothing
        Me.checkBox.DisplayOnly = False
        Me.checkBox.EditingMode = True
        Me.checkBox.EndFindValue = Nothing
        Me.checkBox.FieldDescription = Nothing
        Me.checkBox.FieldName = Nothing
        Me.checkBox.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.checkBox.FindEnabled = False
        Me.checkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.checkBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.checkBox.IFindableControl_FindEnabled = False
        Me.checkBox.IgnoreCase = False
        Me.checkBox.LinkedLabel = Nothing
        Me.checkBox.Location = New System.Drawing.Point(3, 3)
        Me.checkBox.Name = "checkBox"
        Me.checkBox.OldValue = Nothing
        Me.checkBox.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.ExactValue
        Me.checkBox.Size = New System.Drawing.Size(12, 11)
        Me.checkBox.TabIndex = 1
        Me.checkBox.Translatable = True
        Me.checkBox.UseVisualStyleBackColor = True
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(19, 1)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(60, 17)
        Me.CLabel1.TabIndex = 0
        Me.CLabel1.Text = "CLabel1"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'UcCheckBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.CFlowLayout1)
        Me.Name = "UcCheckBox"
        Me.Size = New System.Drawing.Size(85, 21)
        Me.CFlowLayout1.ResumeLayout(False)
        Me.CFlowLayout1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CFlowLayout1 As CFlowLayout
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents checkBox As CCheckBoxNew
End Class
