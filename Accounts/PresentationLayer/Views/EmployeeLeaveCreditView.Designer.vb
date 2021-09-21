Namespace PresentationLayer.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeLeaveCreditView
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
            Me.txtEmployeeLeaveCreditCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeLeaveCreditName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeLeaveCreditNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtEmployeeLeaveCreditAllowed = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.TxtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblCode)
            Me.CFlowLayout1.Controls.Add(Me.txtEmployeeLeaveCreditCode)
            Me.CFlowLayout1.Controls.Add(Me.lblName)
            Me.CFlowLayout1.Controls.Add(Me.txtEmployeeLeaveCreditName)
            Me.CFlowLayout1.Controls.Add(Me.lblNameAra)
            Me.CFlowLayout1.Controls.Add(Me.txtEmployeeLeaveCreditNameAra)
            Me.CFlowLayout1.Controls.Add(Me.CLabel1)
            Me.CFlowLayout1.Controls.Add(Me.txtEmployeeLeaveCreditAllowed)
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.txtPaidPercent)
            Me.CFlowLayout1.Controls.Add(Me.lblPercent)
            Me.CFlowLayout1.Controls.Add(Me.CLabel3)
            Me.CFlowLayout1.Controls.Add(Me.chkCumulative)
            Me.CFlowLayout1.Controls.Add(Me.CLabel4)
            Me.CFlowLayout1.Controls.Add(Me.txtMaxCarryOver)
            Me.CFlowLayout1.Controls.Add(Me.CLabel5)
            Me.CFlowLayout1.Controls.Add(Me.txtMaxLimit)
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
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.DisplayOnly = True
            Me.TxtIdNo.EditingMode = True
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
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 159
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblCode
            '
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
            '
            'txtEmployeeLeaveCreditCode
            '
            Me.txtEmployeeLeaveCreditCode.BackColor = System.Drawing.Color.White
            Me.txtEmployeeLeaveCreditCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeLeaveCreditCode.ComputedValue = False
            Me.txtEmployeeLeaveCreditCode.CustomFormat = Nothing
            Me.txtEmployeeLeaveCreditCode.DataBoundControl = True
            Me.txtEmployeeLeaveCreditCode.EditingMode = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtEmployeeLeaveCreditCode, True)
            Me.txtEmployeeLeaveCreditCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeLeaveCreditCode.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeLeaveCreditCode.LinkedLabel = Nothing
            Me.txtEmployeeLeaveCreditCode.Location = New System.Drawing.Point(168, 36)
            Me.txtEmployeeLeaveCreditCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeLeaveCreditCode.MaximumValue = Nothing
            Me.txtEmployeeLeaveCreditCode.MinimumValue = Nothing
            Me.txtEmployeeLeaveCreditCode.Name = "txtEmployeeLeaveCreditCode"
            Me.txtEmployeeLeaveCreditCode.OldValue = Nothing
            Me.txtEmployeeLeaveCreditCode.ReadOnly = True
            Me.txtEmployeeLeaveCreditCode.Size = New System.Drawing.Size(62, 23)
            Me.txtEmployeeLeaveCreditCode.TabIndex = 160
            Me.txtEmployeeLeaveCreditCode.ValueIsMandatory = True
            '
            'lblName
            '
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
            '
            'txtEmployeeLeaveCreditName
            '
            Me.txtEmployeeLeaveCreditName.BackColor = System.Drawing.Color.White
            Me.txtEmployeeLeaveCreditName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeLeaveCreditName.ComputedValue = False
            Me.txtEmployeeLeaveCreditName.CustomFormat = Nothing
            Me.txtEmployeeLeaveCreditName.DataBoundControl = True
            Me.txtEmployeeLeaveCreditName.EditingMode = False
            Me.txtEmployeeLeaveCreditName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeLeaveCreditName.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeLeaveCreditName.LinkedLabel = Nothing
            Me.txtEmployeeLeaveCreditName.Location = New System.Drawing.Point(168, 61)
            Me.txtEmployeeLeaveCreditName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeLeaveCreditName.MaximumValue = Nothing
            Me.txtEmployeeLeaveCreditName.MinimumValue = Nothing
            Me.txtEmployeeLeaveCreditName.Name = "txtEmployeeLeaveCreditName"
            Me.txtEmployeeLeaveCreditName.OldValue = Nothing
            Me.txtEmployeeLeaveCreditName.ReadOnly = True
            Me.txtEmployeeLeaveCreditName.Size = New System.Drawing.Size(418, 23)
            Me.txtEmployeeLeaveCreditName.TabIndex = 161
            Me.txtEmployeeLeaveCreditName.ValueIsMandatory = True
            '
            'lblNameAra
            '
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
            '
            'txtEmployeeLeaveCreditNameAra
            '
            Me.txtEmployeeLeaveCreditNameAra.BackColor = System.Drawing.Color.White
            Me.txtEmployeeLeaveCreditNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeLeaveCreditNameAra.ComputedValue = False
            Me.txtEmployeeLeaveCreditNameAra.CustomFormat = Nothing
            Me.txtEmployeeLeaveCreditNameAra.DataBoundControl = True
            Me.txtEmployeeLeaveCreditNameAra.EditingMode = False
            Me.txtEmployeeLeaveCreditNameAra.EnglishControl = Me.txtEmployeeLeaveCreditName
            Me.txtEmployeeLeaveCreditNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeLeaveCreditNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeLeaveCreditNameAra.LinkedLabel = Nothing
            Me.txtEmployeeLeaveCreditNameAra.Location = New System.Drawing.Point(168, 86)
            Me.txtEmployeeLeaveCreditNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeLeaveCreditNameAra.MaximumValue = Nothing
            Me.txtEmployeeLeaveCreditNameAra.MinimumValue = Nothing
            Me.txtEmployeeLeaveCreditNameAra.Name = "txtEmployeeLeaveCreditNameAra"
            Me.txtEmployeeLeaveCreditNameAra.OldValue = Nothing
            Me.txtEmployeeLeaveCreditNameAra.ReadOnly = True
            Me.txtEmployeeLeaveCreditNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtEmployeeLeaveCreditNameAra.Size = New System.Drawing.Size(418, 23)
            Me.txtEmployeeLeaveCreditNameAra.TabIndex = 162
            '
            'CLabel1
            '
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.CLabel1.Location = New System.Drawing.Point(11, 111)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(155, 23)
            Me.CLabel1.TabIndex = 168
            Me.CLabel1.Text = "Number of EmployeeLeaveCredits Allowed"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtEmployeeLeaveCreditAllowed
            '
            Me.txtEmployeeLeaveCreditAllowed.BackColor = System.Drawing.Color.White
            Me.txtEmployeeLeaveCreditAllowed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmployeeLeaveCreditAllowed.ComputedValue = False
            Me.txtEmployeeLeaveCreditAllowed.CustomFormat = Nothing
            Me.txtEmployeeLeaveCreditAllowed.DataBoundControl = True
            Me.txtEmployeeLeaveCreditAllowed.EditingMode = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtEmployeeLeaveCreditAllowed, True)
            Me.txtEmployeeLeaveCreditAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtEmployeeLeaveCreditAllowed.ForeColor = System.Drawing.Color.Black
            Me.txtEmployeeLeaveCreditAllowed.LinkedLabel = Nothing
            Me.txtEmployeeLeaveCreditAllowed.Location = New System.Drawing.Point(168, 111)
            Me.txtEmployeeLeaveCreditAllowed.Margin = New System.Windows.Forms.Padding(1)
            Me.txtEmployeeLeaveCreditAllowed.MaximumValue = Nothing
            Me.txtEmployeeLeaveCreditAllowed.MinimumValue = Nothing
            Me.txtEmployeeLeaveCreditAllowed.Name = "txtEmployeeLeaveCreditAllowed"
            Me.txtEmployeeLeaveCreditAllowed.OldValue = Nothing
            Me.txtEmployeeLeaveCreditAllowed.ReadOnly = True
            Me.txtEmployeeLeaveCreditAllowed.Size = New System.Drawing.Size(62, 23)
            Me.txtEmployeeLeaveCreditAllowed.TabIndex = 167
            Me.txtEmployeeLeaveCreditAllowed.ValueIsMandatory = True
            '
            'CLabel2
            '
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
            '
            'txtPaidPercent
            '
            Me.txtPaidPercent.BackColor = System.Drawing.Color.White
            Me.txtPaidPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPaidPercent.ComputedValue = False
            Me.txtPaidPercent.CustomFormat = Nothing
            Me.txtPaidPercent.DataBoundControl = True
            Me.txtPaidPercent.EditingMode = True
            Me.txtPaidPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPaidPercent.ForeColor = System.Drawing.Color.Black
            Me.txtPaidPercent.LinkedLabel = Nothing
            Me.txtPaidPercent.Location = New System.Drawing.Point(168, 136)
            Me.txtPaidPercent.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPaidPercent.MaximumValue = Nothing
            Me.txtPaidPercent.MinimumValue = Nothing
            Me.txtPaidPercent.Name = "txtPaidPercent"
            Me.txtPaidPercent.OldValue = Nothing
            Me.txtPaidPercent.ReadOnly = True
            Me.txtPaidPercent.Size = New System.Drawing.Size(62, 23)
            Me.txtPaidPercent.TabIndex = 169
            Me.txtPaidPercent.ValueIsMandatory = True
            '
            'lblPercent
            '
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
            '
            'CLabel3
            '
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
            '
            'chkCumulative
            '
            Me.chkCumulative.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkCumulative.BackColor = System.Drawing.Color.White
            Me.chkCumulative.DisplayOnly = False
            Me.chkCumulative.EditingMode = True
            Me.chkCumulative.FlatAppearance.BorderSize = 0
            Me.chkCumulative.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CFlowLayout1.SetFlowBreak(Me.chkCumulative, True)
            Me.chkCumulative.ForeColor = System.Drawing.Color.Black
            Me.chkCumulative.LinkedLabel = Nothing
            Me.chkCumulative.Location = New System.Drawing.Point(168, 161)
            Me.chkCumulative.Margin = New System.Windows.Forms.Padding(1)
            Me.chkCumulative.Name = "chkCumulative"
            Me.chkCumulative.NoLabel = True
            Me.chkCumulative.OldValue = Nothing
            Me.chkCumulative.Size = New System.Drawing.Size(23, 23)
            Me.chkCumulative.TabIndex = 271
            Me.chkCumulative.Text = "  "
            Me.chkCumulative.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkCumulative.UseVisualStyleBackColor = True
            '
            'CLabel4
            '
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
            '
            'txtMaxCarryOver
            '
            Me.txtMaxCarryOver.BackColor = System.Drawing.Color.White
            Me.txtMaxCarryOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxCarryOver.ComputedValue = False
            Me.txtMaxCarryOver.CustomFormat = Nothing
            Me.txtMaxCarryOver.DataBoundControl = True
            Me.txtMaxCarryOver.EditingMode = True
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
            Me.txtMaxCarryOver.ReadOnly = True
            Me.txtMaxCarryOver.Size = New System.Drawing.Size(62, 23)
            Me.txtMaxCarryOver.TabIndex = 173
            Me.txtMaxCarryOver.ValueIsMandatory = True
            '
            'CLabel5
            '
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
            '
            'txtMaxLimit
            '
            Me.txtMaxLimit.BackColor = System.Drawing.Color.White
            Me.txtMaxLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxLimit.ComputedValue = False
            Me.txtMaxLimit.CustomFormat = Nothing
            Me.txtMaxLimit.DataBoundControl = True
            Me.txtMaxLimit.EditingMode = True
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
            Me.txtMaxLimit.ReadOnly = True
            Me.txtMaxLimit.Size = New System.Drawing.Size(62, 23)
            Me.txtMaxLimit.TabIndex = 175
            Me.txtMaxLimit.ValueIsMandatory = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNotes.Location = New System.Drawing.Point(11, 236)
            Me.lblNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Size = New System.Drawing.Size(155, 23)
            Me.lblNotes.TabIndex = 178
            Me.lblNotes.Text = "Notes"
            Me.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Location = New System.Drawing.Point(168, 236)
            Me.txtNotes.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.Size = New System.Drawing.Size(418, 60)
            Me.txtNotes.TabIndex = 177
            Me.txtNotes.ValueIsMandatory = True
            '
            'EmployeeLeaveCreditView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Name = "EmployeeLeaveCreditView"
            Me.Size = New System.Drawing.Size(634, 346)
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents lblIdNo As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents TxtIdNo As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblCode As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeLeaveCreditCode As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblName As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeLeaveCreditName As Libraries.CBaseControlsLibrary.CTextBox
        Friend WithEvents lblNameAra As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeLeaveCreditNameAra As Libraries.CBaseControlsLibrary.CTextBoxArabic
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents txtEmployeeLeaveCreditAllowed As Libraries.CBaseControlsLibrary.CTextBox
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
    End Class
End NameSpace