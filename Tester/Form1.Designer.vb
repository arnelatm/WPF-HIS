<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.AtmComboBox2 = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
        Me.SuspendLayout()
        '
        'AtmComboBox2
        '
        Me.AtmComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AtmComboBox2.BackColor = System.Drawing.Color.White
        Me.AtmComboBox2.BegFindValue = Nothing
        Me.AtmComboBox2.ChangingSearchValueOnly = False
        Me.AtmComboBox2.CurrentSearchTerm = ""
        Me.AtmComboBox2.DataValue = Nothing
        Me.AtmComboBox2.DefaultValue = Nothing
        Me.AtmComboBox2.DisplayMember = "Name"
        Me.AtmComboBox2.Editable = True
        Me.AtmComboBox2.EditingMode = True
        Me.AtmComboBox2.EndFindValue = Nothing
        Me.AtmComboBox2.FieldDescription = Nothing
        Me.AtmComboBox2.FieldName = Nothing
        Me.AtmComboBox2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.AtmComboBox2.FindEnabled = False
        Me.AtmComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.AtmComboBox2.ForeColor = System.Drawing.Color.Black
        Me.AtmComboBox2.FormattingEnabled = True
        Me.AtmComboBox2.HideWhenNotEditingOrAdding = False
        Me.AtmComboBox2.IgnoreCase = False
        Me.AtmComboBox2.IntegralHeight = False
        Me.AtmComboBox2.LimitToList = False
        Me.AtmComboBox2.LinkedLabel = Nothing
        Me.AtmComboBox2.Location = New System.Drawing.Point(82, 49)
        Me.AtmComboBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.AtmComboBox2.Name = "AtmComboBox2"
        Me.AtmComboBox2.OldValue = 0
        Me.AtmComboBox2.OriginalDataSource = Nothing
        Me.AtmComboBox2.OriginalList = Nothing
        Me.AtmComboBox2.OverrideDropDownStyleList = False
        Me.AtmComboBox2.PreviousSearchTerm = Nothing
        Me.AtmComboBox2.Size = New System.Drawing.Size(204, 28)
        Me.AtmComboBox2.SuggestBoxHeight = 246
        Me.AtmComboBox2.SuggestCharCount = 0
        Me.AtmComboBox2.TabIndex = 2
        Me.AtmComboBox2.TextToSearch = Nothing
        Me.AtmComboBox2.Translatable = False
        Me.AtmComboBox2.ValueIsMandatory = False
        Me.AtmComboBox2.ValueIsNullable = False
        Me.AtmComboBox2.ValueIsNumeric = False
        Me.AtmComboBox2.ValueMember = "IdNo"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.AtmComboBox2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AtmComboBox2 As CBaseControlsLibrary.CdtComboBox
End Class
