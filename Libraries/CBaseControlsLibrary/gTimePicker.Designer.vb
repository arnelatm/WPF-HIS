
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTimePicker
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
        Me.txbTime = New AATM.Libraries.CBaseControlsLibrary.gTimeBox()
        Me.SuspendLayout
        '
        'txbTime
        '
        Me.txbTime.BackColor = System.Drawing.Color.White
        Me.txbTime.BegFindValue = Nothing
        Me.txbTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txbTime.ComputedValue = false
        Me.txbTime.CustomFormat = Nothing
        Me.txbTime.DataBoundControl = true
        Me.txbTime.EditingMode = true
        Me.txbTime.EndFindValue = Nothing
        Me.txbTime.FieldDescription = Nothing
        Me.txbTime.FieldName = Nothing
        Me.txbTime.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txbTime.FindEnabled = false
        Me.txbTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txbTime.ForeColor = System.Drawing.Color.Black
        Me.txbTime.LinkedLabel = Nothing
        Me.txbTime.Location = New System.Drawing.Point(0, 0)
        Me.txbTime.Margin = New System.Windows.Forms.Padding(1)
        Me.txbTime.MaximumValue = Nothing
        Me.txbTime.MinimumValue = Nothing
        Me.txbTime.Name = "txbTime"
        Me.txbTime.NullColorA = System.Drawing.Color.LightSteelBlue
        Me.txbTime.NullColorB = System.Drawing.Color.White
        Me.txbTime.NullHatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal
        Me.txbTime.NullTextColor = System.Drawing.Color.Black
        Me.txbTime.NullTextInFront = false
        Me.txbTime.OldValue = Nothing
        Me.txbTime.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txbTime.Size = New System.Drawing.Size(48, 22)
        Me.txbTime.TabIndex = 1
        Me.txbTime.Translatable = false
        '
        'gTimePicker
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.txbTime)
        Me.Name = "gTimePicker"
        Me.Size = New System.Drawing.Size(51, 18)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txbTime As gTimeBox

End Class
