Namespace PresentationLayer.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LeaveView
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveAllowed = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPaidPercent = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPercent = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCumulative = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMaxCarryOver = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMaxLimit = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblEarnable = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkEarnable = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblCode)
            Me.CFlowLayout1.Controls.Add(Me.txtLeaveCode)
            Me.CFlowLayout1.Controls.Add(Me.lblName)
            Me.CFlowLayout1.Controls.Add(Me.txtLeaveName)
            Me.CFlowLayout1.Controls.Add(Me.lblNameAra)
            Me.CFlowLayout1.Controls.Add(Me.txtLeaveNameAra)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.txtLeaveAllowed)
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.txtPaidPercent)
            Me.CFlowLayout1.Controls.Add(Me.lblPercent)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.chkCumulative)
            Me.CFlowLayout1.Controls.Add(Me.CLabel4)
            Me.CFlowLayout1.Controls.Add(Me.txtMaxCarryOver)
            Me.CFlowLayout1.Controls.Add(Me.CLabel5)
            Me.CFlowLayout1.Controls.Add(Me.txtMaxLimit)
            Me.CFlowLayout1.Controls.Add(Me.lblEarnable)
            Me.CFlowLayout1.Controls.Add(Me.chkEarnable)
            Me.CFlowLayout1.Controls.Add(Me.lblNotes)
            Me.CFlowLayout1.Controls.Add(Me.txtNotes)
            Me.CFlowLayout1.Location = New System.Drawing.Point(15, 18)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(604, 313)
            Me.CFlowLayout1.TabIndex = 0
            '
            'lblIdNo
            '
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(155, 23)
            Me.lblIdNo.TabIndex = 163
            Me.lblIdNo.Text = "ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(168, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 159
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblCode
            '
            Me.lblCode.BackColor = System.Drawing.Color.Transparent
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCode.Location = New System.Drawing.Point(11, 36)
            Me.lblCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(155, 23)
            Me.lblCode.TabIndex = 164
            Me.lblCode.Text = "Code"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCode.Translatable = True
            '
            'txtLeaveCode
            '
            Me.txtLeaveCode.BackColor = System.Drawing.Color.White
            Me.txtLeaveCode.BegFindValue = Nothing
            Me.txtLeaveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveCode.ComputedValue = False
            Me.txtLeaveCode.CustomFormat = Nothing
            Me.txtLeaveCode.DataBoundControl = True
            Me.txtLeaveCode.EditingMode = True
            Me.txtLeaveCode.EndFindValue = Nothing
            Me.txtLeaveCode.FieldDescription = Nothing
            Me.txtLeaveCode.FieldName = Nothing
            Me.txtLeaveCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveCode.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtLeaveCode, True)
            Me.txtLeaveCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLeaveCode.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveCode.LinkedLabel = Nothing
            Me.txtLeaveCode.Location = New System.Drawing.Point(168, 36)
            Me.txtLeaveCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLeaveCode.MaximumValue = Nothing
            Me.txtLeaveCode.MinimumValue = Nothing
            Me.txtLeaveCode.Name = "txtLeaveCode"
            Me.txtLeaveCode.OldValue = Nothing
            Me.txtLeaveCode.OverrideMaxLength = 0
            Me.txtLeaveCode.ReadOnly = True
            Me.txtLeaveCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveCode.Size = New System.Drawing.Size(62, 23)
            Me.txtLeaveCode.TabIndex = 160
            Me.txtLeaveCode.Translatable = False
            Me.txtLeaveCode.ValueIsMandatory = True
            '
            'lblName
            '
            Me.lblName.BackColor = System.Drawing.Color.Transparent
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblName.Location = New System.Drawing.Point(11, 61)
            Me.lblName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(155, 23)
            Me.lblName.TabIndex = 165
            Me.lblName.Text = "Name"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblName.Translatable = True
            '
            'txtLeaveName
            '
            Me.txtLeaveName.BackColor = System.Drawing.Color.White
            Me.txtLeaveName.BegFindValue = Nothing
            Me.txtLeaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveName.ComputedValue = False
            Me.txtLeaveName.CustomFormat = Nothing
            Me.txtLeaveName.DataBoundControl = True
            Me.txtLeaveName.EditingMode = False
            Me.txtLeaveName.EndFindValue = Nothing
            Me.txtLeaveName.FieldDescription = Nothing
            Me.txtLeaveName.FieldName = Nothing
            Me.txtLeaveName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveName.FindEnabled = False
            Me.txtLeaveName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLeaveName.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveName.LinkedLabel = Nothing
            Me.txtLeaveName.Location = New System.Drawing.Point(168, 61)
            Me.txtLeaveName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLeaveName.MaximumValue = Nothing
            Me.txtLeaveName.MinimumValue = Nothing
            Me.txtLeaveName.Name = "txtLeaveName"
            Me.txtLeaveName.OldValue = Nothing
            Me.txtLeaveName.OverrideMaxLength = 0
            Me.txtLeaveName.ReadOnly = True
            Me.txtLeaveName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveName.Size = New System.Drawing.Size(418, 23)
            Me.txtLeaveName.TabIndex = 161
            Me.txtLeaveName.Translatable = False
            Me.txtLeaveName.ValueIsMandatory = True
            '
            'lblNameAra
            '
            Me.lblNameAra.BackColor = System.Drawing.Color.Transparent
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Size = New System.Drawing.Size(155, 23)
            Me.lblNameAra.TabIndex = 166
            Me.lblNameAra.Text = "Name (Arabic)"
            Me.lblNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNameAra.Translatable = True
            '
            'txtLeaveNameAra
            '
            Me.txtLeaveNameAra.BackColor = System.Drawing.Color.White
            Me.txtLeaveNameAra.BegFindValue = Nothing
            Me.txtLeaveNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveNameAra.ComputedValue = False
            Me.txtLeaveNameAra.CustomFormat = Nothing
            Me.txtLeaveNameAra.DataBoundControl = True
            Me.txtLeaveNameAra.EditingMode = False
            Me.txtLeaveNameAra.EndFindValue = Nothing
            Me.txtLeaveNameAra.EnglishControl = Me.txtLeaveName
            Me.txtLeaveNameAra.FieldDescription = Nothing
            Me.txtLeaveNameAra.FieldName = Nothing
            Me.txtLeaveNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveNameAra.FindEnabled = False
            Me.txtLeaveNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLeaveNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveNameAra.LinkedLabel = Nothing
            Me.txtLeaveNameAra.Location = New System.Drawing.Point(168, 86)
            Me.txtLeaveNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLeaveNameAra.MaximumValue = Nothing
            Me.txtLeaveNameAra.MinimumValue = Nothing
            Me.txtLeaveNameAra.Name = "txtLeaveNameAra"
            Me.txtLeaveNameAra.OldValue = Nothing
            Me.txtLeaveNameAra.OverrideMaxLength = 0
            Me.txtLeaveNameAra.ReadOnly = True
            Me.txtLeaveNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtLeaveNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtLeaveNameAra.TabIndex = 162
            Me.txtLeaveNameAra.Translatable = False
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 111)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(155, 23)
            Me.CLabel1.TabIndex = 168
            Me.CLabel1.Text = "Number of Leaves Allowed"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'txtLeaveAllowed
            '
            Me.txtLeaveAllowed.BackColor = System.Drawing.Color.White
            Me.txtLeaveAllowed.BegFindValue = Nothing
            Me.txtLeaveAllowed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveAllowed.ComputedValue = False
            Me.txtLeaveAllowed.CustomFormat = Nothing
            Me.txtLeaveAllowed.DataBoundControl = True
            Me.txtLeaveAllowed.EditingMode = True
            Me.txtLeaveAllowed.EndFindValue = Nothing
            Me.txtLeaveAllowed.FieldDescription = Nothing
            Me.txtLeaveAllowed.FieldName = Nothing
            Me.txtLeaveAllowed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveAllowed.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtLeaveAllowed, True)
            Me.txtLeaveAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtLeaveAllowed.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveAllowed.LinkedLabel = Nothing
            Me.txtLeaveAllowed.Location = New System.Drawing.Point(168, 111)
            Me.txtLeaveAllowed.Margin = New System.Windows.Forms.Padding(1)
            Me.txtLeaveAllowed.MaximumValue = Nothing
            Me.txtLeaveAllowed.MinimumValue = Nothing
            Me.txtLeaveAllowed.Name = "txtLeaveAllowed"
            Me.txtLeaveAllowed.OldValue = Nothing
            Me.txtLeaveAllowed.OverrideMaxLength = 0
            Me.txtLeaveAllowed.ReadOnly = True
            Me.txtLeaveAllowed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveAllowed.Size = New System.Drawing.Size(62, 23)
            Me.txtLeaveAllowed.TabIndex = 167
            Me.txtLeaveAllowed.Translatable = False
            Me.txtLeaveAllowed.ValueIsMandatory = True
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.Transparent
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel2.Location = New System.Drawing.Point(11, 136)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(155, 23)
            Me.CLabel2.TabIndex = 170
            Me.CLabel2.Text = "Paid Percentage"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel2.Translatable = True
            '
            'txtPaidPercent
            '
            Me.txtPaidPercent.BackColor = System.Drawing.Color.White
            Me.txtPaidPercent.BegFindValue = Nothing
            Me.txtPaidPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPaidPercent.ComputedValue = False
            Me.txtPaidPercent.CustomFormat = Nothing
            Me.txtPaidPercent.DataBoundControl = True
            Me.txtPaidPercent.EditingMode = True
            Me.txtPaidPercent.EndFindValue = Nothing
            Me.txtPaidPercent.FieldDescription = Nothing
            Me.txtPaidPercent.FieldName = Nothing
            Me.txtPaidPercent.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPaidPercent.FindEnabled = False
            Me.txtPaidPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPaidPercent.ForeColor = System.Drawing.Color.Black
            Me.txtPaidPercent.LinkedLabel = Nothing
            Me.txtPaidPercent.Location = New System.Drawing.Point(168, 136)
            Me.txtPaidPercent.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPaidPercent.MaximumValue = Nothing
            Me.txtPaidPercent.MinimumValue = Nothing
            Me.txtPaidPercent.Name = "txtPaidPercent"
            Me.txtPaidPercent.OldValue = Nothing
            Me.txtPaidPercent.OverrideMaxLength = 0
            Me.txtPaidPercent.ReadOnly = True
            Me.txtPaidPercent.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPaidPercent.Size = New System.Drawing.Size(62, 23)
            Me.txtPaidPercent.TabIndex = 169
            Me.txtPaidPercent.Translatable = False
            Me.txtPaidPercent.ValueIsMandatory = True
            '
            'lblPercent
            '
            Me.lblPercent.BackColor = System.Drawing.Color.Transparent
            Me.lblPercent.DisplayOnly = True
            Me.lblPercent.EditingMode = False
            Me.CFlowLayout1.SetFlowBreak(Me.lblPercent, True)
            Me.lblPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblPercent.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPercent.Location = New System.Drawing.Point(231, 135)
            Me.lblPercent.Margin = New System.Windows.Forms.Padding(0)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(16, 23)
            Me.lblPercent.TabIndex = 270
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPercent.Translatable = True
            '
            'CLabel3
            '
            Me.CLabel3.BackColor = System.Drawing.Color.Transparent
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel3.Location = New System.Drawing.Point(11, 161)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(155, 23)
            Me.CLabel3.TabIndex = 172
            Me.CLabel3.Text = "Cumulative"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'chkCumulative
            '
            Me.chkCumulative.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkCumulative.BackColor = System.Drawing.Color.White
            Me.chkCumulative.BegFindValue = Nothing
            Me.chkCumulative.DisplayOnly = False
            Me.chkCumulative.EditingMode = True
            Me.chkCumulative.EndFindValue = Nothing
            Me.chkCumulative.FieldDescription = Nothing
            Me.chkCumulative.FieldName = Nothing
            Me.chkCumulative.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCumulative.FindEnabled = False
            Me.chkCumulative.FlatAppearance.BorderSize = 0
            Me.chkCumulative.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkCumulative, True)
            Me.chkCumulative.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkCumulative.ForeColor = System.Drawing.Color.Black
            Me.chkCumulative.IFindableControl_FindEnabled = False
            Me.chkCumulative.IgnoreCase = False
            Me.chkCumulative.LinkedLabel = Nothing
            Me.chkCumulative.Location = New System.Drawing.Point(168, 161)
            Me.chkCumulative.Margin = New System.Windows.Forms.Padding(1)
            Me.chkCumulative.Name = "chkCumulative"
            Me.chkCumulative.NoLabel = True
            Me.chkCumulative.OldValue = Nothing
            Me.chkCumulative.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCumulative.Size = New System.Drawing.Size(23, 23)
            Me.chkCumulative.TabIndex = 271
            Me.chkCumulative.Text = "  "
            Me.chkCumulative.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCumulative.Translatable = False
            Me.chkCumulative.UseVisualStyleBackColor = True
            '
            'CLabel4
            '
            Me.CLabel4.BackColor = System.Drawing.Color.Transparent
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel4.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel4.Location = New System.Drawing.Point(11, 186)
            Me.CLabel4.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel4.Name = "CLabel4"
            Me.CLabel4.Size = New System.Drawing.Size(155, 23)
            Me.CLabel4.TabIndex = 174
            Me.CLabel4.Text = "Maximum Carryover"
            Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel4.Translatable = True
            '
            'txtMaxCarryOver
            '
            Me.txtMaxCarryOver.BackColor = System.Drawing.Color.White
            Me.txtMaxCarryOver.BegFindValue = Nothing
            Me.txtMaxCarryOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxCarryOver.ComputedValue = False
            Me.txtMaxCarryOver.CustomFormat = Nothing
            Me.txtMaxCarryOver.DataBoundControl = True
            Me.txtMaxCarryOver.EditingMode = True
            Me.txtMaxCarryOver.EndFindValue = Nothing
            Me.txtMaxCarryOver.FieldDescription = Nothing
            Me.txtMaxCarryOver.FieldName = Nothing
            Me.txtMaxCarryOver.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMaxCarryOver.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtMaxCarryOver, True)
            Me.txtMaxCarryOver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtMaxCarryOver.ForeColor = System.Drawing.Color.Black
            Me.txtMaxCarryOver.LinkedLabel = Nothing
            Me.txtMaxCarryOver.Location = New System.Drawing.Point(168, 186)
            Me.txtMaxCarryOver.Margin = New System.Windows.Forms.Padding(1)
            Me.txtMaxCarryOver.MaximumValue = Nothing
            Me.txtMaxCarryOver.MinimumValue = Nothing
            Me.txtMaxCarryOver.Name = "txtMaxCarryOver"
            Me.txtMaxCarryOver.OldValue = Nothing
            Me.txtMaxCarryOver.OverrideMaxLength = 0
            Me.txtMaxCarryOver.ReadOnly = True
            Me.txtMaxCarryOver.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMaxCarryOver.Size = New System.Drawing.Size(62, 23)
            Me.txtMaxCarryOver.TabIndex = 173
            Me.txtMaxCarryOver.Translatable = False
            Me.txtMaxCarryOver.ValueIsMandatory = True
            '
            'CLabel5
            '
            Me.CLabel5.BackColor = System.Drawing.Color.Transparent
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel5.Location = New System.Drawing.Point(11, 211)
            Me.CLabel5.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel5.Name = "CLabel5"
            Me.CLabel5.Size = New System.Drawing.Size(155, 23)
            Me.CLabel5.TabIndex = 176
            Me.CLabel5.Text = "Maximum Limit"
            Me.CLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel5.Translatable = True
            '
            'txtMaxLimit
            '
            Me.txtMaxLimit.BackColor = System.Drawing.Color.White
            Me.txtMaxLimit.BegFindValue = Nothing
            Me.txtMaxLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxLimit.ComputedValue = False
            Me.txtMaxLimit.CustomFormat = Nothing
            Me.txtMaxLimit.DataBoundControl = True
            Me.txtMaxLimit.EditingMode = True
            Me.txtMaxLimit.EndFindValue = Nothing
            Me.txtMaxLimit.FieldDescription = Nothing
            Me.txtMaxLimit.FieldName = Nothing
            Me.txtMaxLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMaxLimit.FindEnabled = False
            Me.CFlowLayout1.SetFlowBreak(Me.txtMaxLimit, True)
            Me.txtMaxLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtMaxLimit.ForeColor = System.Drawing.Color.Black
            Me.txtMaxLimit.LinkedLabel = Nothing
            Me.txtMaxLimit.Location = New System.Drawing.Point(168, 211)
            Me.txtMaxLimit.Margin = New System.Windows.Forms.Padding(1)
            Me.txtMaxLimit.MaximumValue = Nothing
            Me.txtMaxLimit.MinimumValue = Nothing
            Me.txtMaxLimit.Name = "txtMaxLimit"
            Me.txtMaxLimit.OldValue = Nothing
            Me.txtMaxLimit.OverrideMaxLength = 0
            Me.txtMaxLimit.ReadOnly = True
            Me.txtMaxLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMaxLimit.Size = New System.Drawing.Size(62, 23)
            Me.txtMaxLimit.TabIndex = 175
            Me.txtMaxLimit.Translatable = False
            Me.txtMaxLimit.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(11, 261)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(155, 23)
            Me.lblNotes.TabIndex = 178
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(168, 261)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 177
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'lblEarnable
            '
            Me.lblEarnable.BackColor = System.Drawing.Color.Transparent
            Me.lblEarnable.DisplayOnly = True
            Me.lblEarnable.EditingMode = False
            Me.lblEarnable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblEarnable.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblEarnable.Location = New System.Drawing.Point(11, 236)
            Me.lblEarnable.Margin = New System.Windows.Forms.Padding(1)
            Me.lblEarnable.Name = "lblEarnable"
            Me.lblEarnable.Size = New System.Drawing.Size(155, 23)
            Me.lblEarnable.TabIndex = 272
            Me.lblEarnable.Text = "Cumulative"
            Me.lblEarnable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblEarnable.Translatable = True
            '
            'chkEarnable
            '
            Me.chkEarnable.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkEarnable.BackColor = System.Drawing.Color.White
            Me.chkEarnable.BegFindValue = Nothing
            Me.chkEarnable.DisplayOnly = False
            Me.chkEarnable.EditingMode = True
            Me.chkEarnable.EndFindValue = Nothing
            Me.chkEarnable.FieldDescription = Nothing
            Me.chkEarnable.FieldName = Nothing
            Me.chkEarnable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkEarnable.FindEnabled = False
            Me.chkEarnable.FlatAppearance.BorderSize = 0
            Me.chkEarnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkEarnable, True)
            Me.chkEarnable.Font = New System.Drawing.Font("Segoe UI", 9.0!)
            Me.chkEarnable.ForeColor = System.Drawing.Color.Black
            Me.chkEarnable.IFindableControl_FindEnabled = False
            Me.chkEarnable.IgnoreCase = False
            Me.chkEarnable.LinkedLabel = Nothing
            Me.chkEarnable.Location = New System.Drawing.Point(168, 236)
            Me.chkEarnable.Margin = New System.Windows.Forms.Padding(1)
            Me.chkEarnable.Name = "chkEarnable"
            Me.chkEarnable.NoLabel = True
            Me.chkEarnable.OldValue = Nothing
            Me.chkEarnable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkEarnable.Size = New System.Drawing.Size(23, 23)
            Me.chkEarnable.TabIndex = 273
            Me.chkEarnable.Text = "  "
            Me.chkEarnable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkEarnable.Translatable = False
            Me.chkEarnable.UseVisualStyleBackColor = True
            '
            'LeaveView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "LeaveView"
            Me.Size = New System.Drawing.Size(792, 432)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtLeaveCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtLeaveName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtLeaveNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtLeaveAllowed As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtPaidPercent As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel3 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel4 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtMaxCarryOver As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents CLabel5 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtMaxLimit As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNotes As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtNotes As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblPercent As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkCumulative As Libraries.CBaseControlsLibrary.CCheckBox
        Friend WithEvents lblEarnable As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents chkEarnable As Libraries.CBaseControlsLibrary.CCheckBox
    End Class
End NameSpace