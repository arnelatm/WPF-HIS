Imports System.ComponentModel
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace PresentationLayer.Views.Forms


    <DesignerGenerated()>
    Partial Class ProductBaseUnitChanger
        Inherits BfMain

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
            Me.components = New System.ComponentModel.Container()
            Me.cmdCancel = New System.Windows.Forms.Button()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.bsNotes = New System.Windows.Forms.BindingSource(Me.components)
            Me.btnChangeUnit = New System.Windows.Forms.Button()
            Me.txtProductName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboNewUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.cboOldUnitIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bsNotes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New System.Drawing.Point(311, 99)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
            Me.cmdCancel.TabIndex = 4
            Me.cmdCancel.Text = "&Quit"
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'CLabel2
            '
            Me.CLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CLabel2.AutoSize = True
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.Location = New System.Drawing.Point(405, 382)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(0, 17)
            Me.CLabel2.TabIndex = 24
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'bsNotes
            '
            Me.bsNotes.DataSource = GetType(AATM.Accounts.PresentationLayer.Models.TransactionNotesModel)
            '
            'btnChangeUnit
            '
            Me.btnChangeUnit.Enabled = False
            Me.btnChangeUnit.Location = New System.Drawing.Point(159, 99)
            Me.btnChangeUnit.Name = "btnChangeUnit"
            Me.btnChangeUnit.Size = New System.Drawing.Size(146, 23)
            Me.btnChangeUnit.TabIndex = 3
            Me.btnChangeUnit.Text = "Change Unit"
            Me.btnChangeUnit.UseVisualStyleBackColor = True
            '
            'txtProductName
            '
            Me.txtProductName.BackColor = System.Drawing.Color.White
            Me.txtProductName.BegFindValue = Nothing
            Me.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProductName.ComputedValue = False
            Me.txtProductName.CustomFormat = Nothing
            Me.txtProductName.DataBoundControl = True
            Me.txtProductName.DisplayOnly = True
            Me.txtProductName.EditingMode = True
            Me.txtProductName.EndFindValue = Nothing
            Me.txtProductName.FieldDescription = Nothing
            Me.txtProductName.FieldName = Nothing
            Me.txtProductName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtProductName.FindEnabled = False
            Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtProductName.ForeColor = System.Drawing.Color.Black
            Me.txtProductName.LinkedLabel = Nothing
            Me.txtProductName.Location = New System.Drawing.Point(159, 10)
            Me.txtProductName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtProductName.MaximumValue = Nothing
            Me.txtProductName.MinimumValue = Nothing
            Me.txtProductName.Name = "txtProductName"
            Me.txtProductName.OldValue = Nothing
            Me.txtProductName.OverrideMaxLength = 0
            Me.txtProductName.ReadOnly = True
            Me.txtProductName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtProductName.Size = New System.Drawing.Size(406, 23)
            Me.txtProductName.TabIndex = 0
            Me.txtProductName.Translatable = False
            '
            'CLabel1
            '
            Me.CLabel1.AutoSize = True
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(10, 10)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(98, 17)
            Me.CLabel1.TabIndex = 36
            Me.CLabel1.Text = "Product Name"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(10, 38)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(63, 17)
            Me.CLabel3.TabIndex = 37
            Me.CLabel3.Text = "Old Unit "
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'CLabel4
            '
            Me.CLabel4.AutoSize = True
            Me.CLabel4.BackColor = System.Drawing.Color.Transparent
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.Location = New System.Drawing.Point(10, 64)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(64, 17)
            Me.CLabel4.TabIndex = 38
            Me.CLabel4.Text = "New Unit"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'cboNewUnitIdNo
            '
            Me.cboNewUnitIdNo.BackColor = System.Drawing.Color.White
            Me.cboNewUnitIdNo.BegFindValue = Nothing
            Me.cboNewUnitIdNo.ChangingSearchValueOnly = False
            Me.cboNewUnitIdNo.CurrentSearchTerm = ""
            Me.cboNewUnitIdNo.DataValue = Nothing
            Me.cboNewUnitIdNo.DefaultValue = Nothing
            Me.cboNewUnitIdNo.DisplayMember = "Name"
            Me.cboNewUnitIdNo.Editable = True
            Me.cboNewUnitIdNo.EditingMode = True
            Me.cboNewUnitIdNo.EndFindValue = Nothing
            Me.cboNewUnitIdNo.FieldDescription = Nothing
            Me.cboNewUnitIdNo.FieldName = Nothing
            Me.cboNewUnitIdNo.FilterRule = Nothing
            Me.cboNewUnitIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboNewUnitIdNo.FindEnabled = False
            Me.cboNewUnitIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboNewUnitIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboNewUnitIdNo.FormattingEnabled = True
            Me.cboNewUnitIdNo.HideWhenNotEditingOrAdding = False
            Me.cboNewUnitIdNo.IgnoreCase = False
            Me.cboNewUnitIdNo.IntegralHeight = False
            Me.cboNewUnitIdNo.LimitToList = False
            Me.cboNewUnitIdNo.LinkedLabel = Nothing
            Me.cboNewUnitIdNo.Location = New System.Drawing.Point(159, 61)
            Me.cboNewUnitIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboNewUnitIdNo.Name = "cboNewUnitIdNo"
            Me.cboNewUnitIdNo.OldValue = 0
            Me.cboNewUnitIdNo.OriginalDataSource = Nothing
            Me.cboNewUnitIdNo.OriginalList = Nothing
            Me.cboNewUnitIdNo.OverrideDropDownStyleList = False
            Me.cboNewUnitIdNo.PreviousSearchTerm = Nothing
            Me.cboNewUnitIdNo.PropertySelector = Nothing
            Me.cboNewUnitIdNo.Size = New System.Drawing.Size(121, 24)
            Me.cboNewUnitIdNo.SuggestBoxHeight = 200
            Me.cboNewUnitIdNo.SuggestCharCount = 0
            Me.cboNewUnitIdNo.SuggestListOrderRule = Nothing
            Me.cboNewUnitIdNo.TabIndex = 2
            Me.cboNewUnitIdNo.TextToSearch = Nothing
            Me.cboNewUnitIdNo.Translatable = False
            Me.cboNewUnitIdNo.ValueIsMandatory = False
            Me.cboNewUnitIdNo.ValueIsNullable = False
            Me.cboNewUnitIdNo.ValueIsNumeric = False
            Me.cboNewUnitIdNo.ValueMember = "IdNo"
            '
            'cboOldUnitIdNo
            '
            Me.cboOldUnitIdNo.BackColor = System.Drawing.Color.White
            Me.cboOldUnitIdNo.BegFindValue = Nothing
            Me.cboOldUnitIdNo.ChangingSearchValueOnly = False
            Me.cboOldUnitIdNo.CurrentSearchTerm = ""
            Me.cboOldUnitIdNo.DataValue = Nothing
            Me.cboOldUnitIdNo.DefaultValue = Nothing
            Me.cboOldUnitIdNo.DisplayMember = "Name"
            Me.cboOldUnitIdNo.DisplayOnly = True
            Me.cboOldUnitIdNo.Editable = True
            Me.cboOldUnitIdNo.EditingMode = True
            Me.cboOldUnitIdNo.EndFindValue = Nothing
            Me.cboOldUnitIdNo.FieldDescription = Nothing
            Me.cboOldUnitIdNo.FieldName = Nothing
            Me.cboOldUnitIdNo.FilterRule = Nothing
            Me.cboOldUnitIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboOldUnitIdNo.FindEnabled = False
            Me.cboOldUnitIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboOldUnitIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboOldUnitIdNo.FormattingEnabled = True
            Me.cboOldUnitIdNo.HideWhenNotEditingOrAdding = False
            Me.cboOldUnitIdNo.IgnoreCase = False
            Me.cboOldUnitIdNo.IntegralHeight = False
            Me.cboOldUnitIdNo.LimitToList = False
            Me.cboOldUnitIdNo.LinkedLabel = Nothing
            Me.cboOldUnitIdNo.Location = New System.Drawing.Point(159, 35)
            Me.cboOldUnitIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboOldUnitIdNo.Name = "cboOldUnitIdNo"
            Me.cboOldUnitIdNo.OldValue = 0
            Me.cboOldUnitIdNo.OriginalDataSource = Nothing
            Me.cboOldUnitIdNo.OriginalList = Nothing
            Me.cboOldUnitIdNo.OverrideDropDownStyleList = False
            Me.cboOldUnitIdNo.PreviousSearchTerm = Nothing
            Me.cboOldUnitIdNo.PropertySelector = Nothing
            Me.cboOldUnitIdNo.Size = New System.Drawing.Size(121, 24)
            Me.cboOldUnitIdNo.SuggestBoxHeight = 200
            Me.cboOldUnitIdNo.SuggestCharCount = 0
            Me.cboOldUnitIdNo.SuggestListOrderRule = Nothing
            Me.cboOldUnitIdNo.TabIndex = 1
            Me.cboOldUnitIdNo.TextToSearch = Nothing
            Me.cboOldUnitIdNo.Translatable = False
            Me.cboOldUnitIdNo.ValueIsMandatory = False
            Me.cboOldUnitIdNo.ValueIsNullable = False
            Me.cboOldUnitIdNo.ValueIsNumeric = False
            Me.cboOldUnitIdNo.ValueMember = "IdNo"
            '
            'ProductBaseUnitChanger
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(584, 133)
            Me.Controls.Add(Me.cboOldUnitIdNo)
            Me.Controls.Add(Me.cboNewUnitIdNo)
            Me.Controls.Add(Me.CLabel4)
            Me.Controls.Add(Me.CLabel3)
            Me.Controls.Add(Me.CLabel1)
            Me.Controls.Add(Me.txtProductName)
            Me.Controls.Add(Me.btnChangeUnit)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.CLabel2)
            Me.DoubleBuffered = True
            Me.Name = "ProductBaseUnitChanger"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Product Base Unit Changer"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bsNotes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents cmdCancel As Button
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents bsNotes As BindingSource
        Friend WithEvents btnChangeUnit As Button
        Friend WithEvents txtProductName As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents cboNewUnitIdNo As CtComboBox
        Friend WithEvents cboOldUnitIdNo As CtComboBox
    End Class
End NameSpace