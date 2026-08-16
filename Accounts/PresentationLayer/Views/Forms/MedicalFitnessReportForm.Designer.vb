Namespace PresentationLayer.Views.Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class MedicalFitnessReportForm

        <Global.System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.mainPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.invoicePanel = New System.Windows.Forms.FlowLayoutPanel()
            Me.lblInvoiceNo = New System.Windows.Forms.Label()
            Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
            Me.btnRetrieve = New System.Windows.Forms.Button()
            Me.btnRefreshLabResults = New System.Windows.Forms.Button()
            Me.btnViewKizenResults = New System.Windows.Forms.Button()
            Me.dgvResults = New System.Windows.Forms.DataGridView()
            Me.finalPanel = New System.Windows.Forms.FlowLayoutPanel()
            Me.chkFinalFit = New System.Windows.Forms.CheckBox()
            Me.chkFinalUnfit = New System.Windows.Forms.CheckBox()
            Me.lblRemarks = New System.Windows.Forms.Label()
            Me.txtRemarks = New System.Windows.Forms.TextBox()
            Me.headerPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.txtPatientName = New System.Windows.Forms.TextBox()
            Me.lblGender = New System.Windows.Forms.Label()
            Me.txtGender = New System.Windows.Forms.TextBox()
            Me.lblAge = New System.Windows.Forms.Label()
            Me.txtAge = New System.Windows.Forms.TextBox()
            Me.lblNationality = New System.Windows.Forms.Label()
            Me.txtNationality = New System.Windows.Forms.TextBox()
            Me.lblIdentityNo = New System.Windows.Forms.Label()
            Me.txtIdentityNo = New System.Windows.Forms.TextBox()
            Me.lblFileNo = New System.Windows.Forms.Label()
            Me.txtFileNo = New System.Windows.Forms.TextBox()
            Me.lblInvoiceDate = New System.Windows.Forms.Label()
            Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
            Me.lblDoctorName = New System.Windows.Forms.Label()
            Me.txtDoctorName = New System.Windows.Forms.TextBox()
            Me.lblBloodType = New System.Windows.Forms.Label()
            Me.cboBloodType = New System.Windows.Forms.ComboBox()
            Me.lblPatientName = New System.Windows.Forms.Label()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mainPanel.SuspendLayout()
            Me.invoicePanel.SuspendLayout()
            CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.finalPanel.SuspendLayout()
            Me.headerPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'mainPanel
            '
            Me.mainPanel.BackColor = System.Drawing.Color.Transparent
            Me.mainPanel.ColumnCount = 1
            Me.mainPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.mainPanel.Controls.Add(Me.invoicePanel, 0, 0)
            Me.mainPanel.Controls.Add(Me.dgvResults, 0, 2)
            Me.mainPanel.Controls.Add(Me.finalPanel, 0, 3)
            Me.mainPanel.Controls.Add(Me.headerPanel, 0, 1)
            Me.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.mainPanel.Location = New System.Drawing.Point(0, 55)
            Me.mainPanel.Name = "mainPanel"
            Me.mainPanel.Padding = New System.Windows.Forms.Padding(8)
            Me.mainPanel.RowCount = 4
            Me.mainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.mainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.mainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.mainPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.mainPanel.Size = New System.Drawing.Size(1100, 765)
            Me.mainPanel.TabIndex = 0
            '
            'invoicePanel
            '
            Me.invoicePanel.AutoSize = True
            Me.invoicePanel.Controls.Add(Me.lblInvoiceNo)
            Me.invoicePanel.Controls.Add(Me.txtInvoiceNo)
            Me.invoicePanel.Controls.Add(Me.btnRetrieve)
            Me.invoicePanel.Controls.Add(Me.btnRefreshLabResults)
            Me.invoicePanel.Controls.Add(Me.btnViewKizenResults)
            Me.invoicePanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.invoicePanel.Location = New System.Drawing.Point(11, 11)
            Me.invoicePanel.Name = "invoicePanel"
            Me.invoicePanel.Size = New System.Drawing.Size(1078, 29)
            Me.invoicePanel.TabIndex = 0
            Me.invoicePanel.WrapContents = False
            '
            'lblInvoiceNo
            '
            Me.lblInvoiceNo.AutoSize = True
            Me.lblInvoiceNo.Location = New System.Drawing.Point(0, 6)
            Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(0, 6, 6, 0)
            Me.lblInvoiceNo.Name = "lblInvoiceNo"
            Me.lblInvoiceNo.Size = New System.Drawing.Size(62, 13)
            Me.lblInvoiceNo.TabIndex = 0
            Me.lblInvoiceNo.Text = "Invoice No."
            '
            'txtInvoiceNo
            '
            Me.txtInvoiceNo.Location = New System.Drawing.Point(71, 3)
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.Size = New System.Drawing.Size(120, 20)
            Me.txtInvoiceNo.TabIndex = 1
            '
            'btnRetrieve
            '
            Me.btnRetrieve.Location = New System.Drawing.Point(197, 3)
            Me.btnRetrieve.Name = "btnRetrieve"
            Me.btnRetrieve.Size = New System.Drawing.Size(90, 23)
            Me.btnRetrieve.TabIndex = 2
            Me.btnRetrieve.Text = "Retrieve"
            Me.btnRetrieve.UseVisualStyleBackColor = True
            '
            'btnRefreshLabResults
            '
            Me.btnRefreshLabResults.Location = New System.Drawing.Point(293, 3)
            Me.btnRefreshLabResults.Name = "btnRefreshLabResults"
            Me.btnRefreshLabResults.Size = New System.Drawing.Size(120, 23)
            Me.btnRefreshLabResults.TabIndex = 3
            Me.btnRefreshLabResults.Text = "Refresh Lab Results"
            Me.btnRefreshLabResults.UseVisualStyleBackColor = True
            '
            'btnViewKizenResults
            '
            Me.btnViewKizenResults.Enabled = False
            Me.btnViewKizenResults.Location = New System.Drawing.Point(419, 3)
            Me.btnViewKizenResults.Name = "btnViewKizenResults"
            Me.btnViewKizenResults.Size = New System.Drawing.Size(125, 23)
            Me.btnViewKizenResults.TabIndex = 4
            Me.btnViewKizenResults.Text = "View Kizen Results"
            Me.btnViewKizenResults.UseVisualStyleBackColor = True
            '
            'dgvResults
            '
            Me.dgvResults.AllowUserToAddRows = False
            Me.dgvResults.AllowUserToDeleteRows = False
            Me.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvResults.Location = New System.Drawing.Point(11, 131)
            Me.dgvResults.Name = "dgvResults"
            Me.dgvResults.RowHeadersVisible = False
            Me.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvResults.Size = New System.Drawing.Size(1078, 591)
            Me.dgvResults.TabIndex = 2
            '
            'finalPanel
            '
            Me.finalPanel.AutoSize = True
            Me.finalPanel.Controls.Add(Me.chkFinalFit)
            Me.finalPanel.Controls.Add(Me.chkFinalUnfit)
            Me.finalPanel.Controls.Add(Me.lblRemarks)
            Me.finalPanel.Controls.Add(Me.txtRemarks)
            Me.finalPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.finalPanel.Location = New System.Drawing.Point(11, 728)
            Me.finalPanel.Name = "finalPanel"
            Me.finalPanel.Size = New System.Drawing.Size(1078, 26)
            Me.finalPanel.TabIndex = 3
            '
            'chkFinalFit
            '
            Me.chkFinalFit.AutoSize = True
            Me.chkFinalFit.Location = New System.Drawing.Point(3, 3)
            Me.chkFinalFit.Name = "chkFinalFit"
            Me.chkFinalFit.Size = New System.Drawing.Size(62, 17)
            Me.chkFinalFit.TabIndex = 0
            Me.chkFinalFit.Text = "Final Fit"
            Me.chkFinalFit.UseVisualStyleBackColor = True
            '
            'chkFinalUnfit
            '
            Me.chkFinalUnfit.AutoSize = True
            Me.chkFinalUnfit.Location = New System.Drawing.Point(71, 3)
            Me.chkFinalUnfit.Name = "chkFinalUnfit"
            Me.chkFinalUnfit.Size = New System.Drawing.Size(73, 17)
            Me.chkFinalUnfit.TabIndex = 1
            Me.chkFinalUnfit.Text = "Final Unfit"
            Me.chkFinalUnfit.UseVisualStyleBackColor = True
            '
            'lblRemarks
            '
            Me.lblRemarks.AutoSize = True
            Me.lblRemarks.Location = New System.Drawing.Point(167, 4)
            Me.lblRemarks.Margin = New System.Windows.Forms.Padding(20, 4, 3, 0)
            Me.lblRemarks.Name = "lblRemarks"
            Me.lblRemarks.Size = New System.Drawing.Size(49, 13)
            Me.lblRemarks.TabIndex = 2
            Me.lblRemarks.Text = "Remarks"
            '
            'txtRemarks
            '
            Me.txtRemarks.Location = New System.Drawing.Point(222, 3)
            Me.txtRemarks.Name = "txtRemarks"
            Me.txtRemarks.Size = New System.Drawing.Size(500, 20)
            Me.txtRemarks.TabIndex = 3
            '
            'headerPanel
            '
            Me.headerPanel.AutoSize = True
            Me.headerPanel.ColumnCount = 6
            Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
            Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
            Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
            Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
            Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66!))
            Me.headerPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.7!))
            Me.headerPanel.Controls.Add(Me.txtPatientName, 1, 0)
            Me.headerPanel.Controls.Add(Me.lblGender, 2, 0)
            Me.headerPanel.Controls.Add(Me.txtGender, 3, 0)
            Me.headerPanel.Controls.Add(Me.lblAge, 4, 0)
            Me.headerPanel.Controls.Add(Me.txtAge, 5, 0)
            Me.headerPanel.Controls.Add(Me.lblNationality, 0, 1)
            Me.headerPanel.Controls.Add(Me.txtNationality, 1, 1)
            Me.headerPanel.Controls.Add(Me.lblIdentityNo, 2, 1)
            Me.headerPanel.Controls.Add(Me.txtIdentityNo, 3, 1)
            Me.headerPanel.Controls.Add(Me.lblFileNo, 4, 1)
            Me.headerPanel.Controls.Add(Me.txtFileNo, 5, 1)
            Me.headerPanel.Controls.Add(Me.lblInvoiceDate, 0, 2)
            Me.headerPanel.Controls.Add(Me.txtInvoiceDate, 1, 2)
            Me.headerPanel.Controls.Add(Me.lblDoctorName, 2, 2)
            Me.headerPanel.Controls.Add(Me.txtDoctorName, 3, 2)
            Me.headerPanel.Controls.Add(Me.lblBloodType, 4, 2)
            Me.headerPanel.Controls.Add(Me.cboBloodType, 5, 2)
            Me.headerPanel.Controls.Add(Me.lblPatientName, 0, 0)
            Me.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.headerPanel.Location = New System.Drawing.Point(11, 46)
            Me.headerPanel.Name = "headerPanel"
            Me.headerPanel.RowCount = 3
            Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.headerPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.headerPanel.Size = New System.Drawing.Size(1078, 79)
            Me.headerPanel.TabIndex = 1
            '
            'txtPatientName
            '
            Me.txtPatientName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtPatientName.Location = New System.Drawing.Point(182, 3)
            Me.txtPatientName.Name = "txtPatientName"
            Me.txtPatientName.ReadOnly = True
            Me.txtPatientName.Size = New System.Drawing.Size(173, 20)
            Me.txtPatientName.TabIndex = 1
            '
            'lblGender
            '
            Me.lblGender.AutoSize = True
            Me.lblGender.Location = New System.Drawing.Point(361, 6)
            Me.lblGender.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblGender.Name = "lblGender"
            Me.lblGender.Size = New System.Drawing.Size(42, 13)
            Me.lblGender.TabIndex = 2
            Me.lblGender.Text = "Gender"
            '
            'txtGender
            '
            Me.txtGender.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtGender.Location = New System.Drawing.Point(540, 3)
            Me.txtGender.Name = "txtGender"
            Me.txtGender.ReadOnly = True
            Me.txtGender.Size = New System.Drawing.Size(173, 20)
            Me.txtGender.TabIndex = 3
            '
            'lblAge
            '
            Me.lblAge.AutoSize = True
            Me.lblAge.Location = New System.Drawing.Point(719, 6)
            Me.lblAge.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblAge.Name = "lblAge"
            Me.lblAge.Size = New System.Drawing.Size(26, 13)
            Me.lblAge.TabIndex = 4
            Me.lblAge.Text = "Age"
            '
            'txtAge
            '
            Me.txtAge.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtAge.Location = New System.Drawing.Point(898, 3)
            Me.txtAge.Name = "txtAge"
            Me.txtAge.ReadOnly = True
            Me.txtAge.Size = New System.Drawing.Size(177, 20)
            Me.txtAge.TabIndex = 5
            '
            'lblNationality
            '
            Me.lblNationality.AutoSize = True
            Me.lblNationality.Location = New System.Drawing.Point(3, 32)
            Me.lblNationality.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblNationality.Name = "lblNationality"
            Me.lblNationality.Size = New System.Drawing.Size(56, 13)
            Me.lblNationality.TabIndex = 6
            Me.lblNationality.Text = "Nationality"
            '
            'txtNationality
            '
            Me.txtNationality.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNationality.Location = New System.Drawing.Point(182, 29)
            Me.txtNationality.Name = "txtNationality"
            Me.txtNationality.ReadOnly = True
            Me.txtNationality.Size = New System.Drawing.Size(173, 20)
            Me.txtNationality.TabIndex = 7
            '
            'lblIdentityNo
            '
            Me.lblIdentityNo.AutoSize = True
            Me.lblIdentityNo.Location = New System.Drawing.Point(361, 32)
            Me.lblIdentityNo.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblIdentityNo.Name = "lblIdentityNo"
            Me.lblIdentityNo.Size = New System.Drawing.Size(38, 13)
            Me.lblIdentityNo.TabIndex = 8
            Me.lblIdentityNo.Text = "ID No."
            '
            'txtIdentityNo
            '
            Me.txtIdentityNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtIdentityNo.Location = New System.Drawing.Point(540, 29)
            Me.txtIdentityNo.Name = "txtIdentityNo"
            Me.txtIdentityNo.ReadOnly = True
            Me.txtIdentityNo.Size = New System.Drawing.Size(173, 20)
            Me.txtIdentityNo.TabIndex = 9
            '
            'lblFileNo
            '
            Me.lblFileNo.AutoSize = True
            Me.lblFileNo.Location = New System.Drawing.Point(719, 32)
            Me.lblFileNo.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblFileNo.Name = "lblFileNo"
            Me.lblFileNo.Size = New System.Drawing.Size(43, 13)
            Me.lblFileNo.TabIndex = 10
            Me.lblFileNo.Text = "File No."
            '
            'txtFileNo
            '
            Me.txtFileNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtFileNo.Location = New System.Drawing.Point(898, 29)
            Me.txtFileNo.Name = "txtFileNo"
            Me.txtFileNo.ReadOnly = True
            Me.txtFileNo.Size = New System.Drawing.Size(177, 20)
            Me.txtFileNo.TabIndex = 11
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.AutoSize = True
            Me.lblInvoiceDate.Location = New System.Drawing.Point(3, 58)
            Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(30, 13)
            Me.lblInvoiceDate.TabIndex = 12
            Me.lblInvoiceDate.Text = "Date"
            '
            'txtInvoiceDate
            '
            Me.txtInvoiceDate.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtInvoiceDate.Location = New System.Drawing.Point(182, 55)
            Me.txtInvoiceDate.Name = "txtInvoiceDate"
            Me.txtInvoiceDate.ReadOnly = True
            Me.txtInvoiceDate.Size = New System.Drawing.Size(173, 20)
            Me.txtInvoiceDate.TabIndex = 13
            '
            'lblDoctorName
            '
            Me.lblDoctorName.AutoSize = True
            Me.lblDoctorName.Location = New System.Drawing.Point(361, 58)
            Me.lblDoctorName.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblDoctorName.Name = "lblDoctorName"
            Me.lblDoctorName.Size = New System.Drawing.Size(39, 13)
            Me.lblDoctorName.TabIndex = 14
            Me.lblDoctorName.Text = "Doctor"
            '
            'txtDoctorName
            '
            Me.txtDoctorName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDoctorName.Location = New System.Drawing.Point(540, 55)
            Me.txtDoctorName.Name = "txtDoctorName"
            Me.txtDoctorName.ReadOnly = True
            Me.txtDoctorName.Size = New System.Drawing.Size(173, 20)
            Me.txtDoctorName.TabIndex = 15
            '
            'lblBloodType
            '
            Me.lblBloodType.AutoSize = True
            Me.lblBloodType.Location = New System.Drawing.Point(719, 58)
            Me.lblBloodType.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblBloodType.Name = "lblBloodType"
            Me.lblBloodType.Size = New System.Drawing.Size(61, 13)
            Me.lblBloodType.TabIndex = 16
            Me.lblBloodType.Text = "Blood Type"
            '
            'cboBloodType
            '
            Me.cboBloodType.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboBloodType.Items.AddRange(New Object() {"", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"})
            Me.cboBloodType.Location = New System.Drawing.Point(898, 55)
            Me.cboBloodType.Name = "cboBloodType"
            Me.cboBloodType.Size = New System.Drawing.Size(177, 21)
            Me.cboBloodType.TabIndex = 17
            '
            'lblPatientName
            '
            Me.lblPatientName.AutoSize = True
            Me.lblPatientName.Location = New System.Drawing.Point(3, 6)
            Me.lblPatientName.Margin = New System.Windows.Forms.Padding(3, 6, 3, 3)
            Me.lblPatientName.Name = "lblPatientName"
            Me.lblPatientName.Size = New System.Drawing.Size(35, 13)
            Me.lblPatientName.TabIndex = 0
            Me.lblPatientName.Text = "Name"
            '
            'MedicalFitnessReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1100, 820)
            Me.Controls.Add(Me.mainPanel)
            Me.MinimumSize = New System.Drawing.Size(1000, 720)
            Me.Name = "MedicalFitnessReportForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Medical Fitness Report"
            Me.Controls.SetChildIndex(Me.mainPanel, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mainPanel.ResumeLayout(False)
            Me.mainPanel.PerformLayout()
            Me.invoicePanel.ResumeLayout(False)
            Me.invoicePanel.PerformLayout()
            CType(Me.dgvResults, System.ComponentModel.ISupportInitialize).EndInit()
            Me.finalPanel.ResumeLayout(False)
            Me.finalPanel.PerformLayout()
            Me.headerPanel.ResumeLayout(False)
            Me.headerPanel.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents mainPanel As Global.System.Windows.Forms.TableLayoutPanel
        Friend WithEvents invoicePanel As Global.System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents lblInvoiceNo As Global.System.Windows.Forms.Label
        Friend WithEvents txtInvoiceNo As Global.System.Windows.Forms.TextBox
        Friend WithEvents btnRetrieve As Global.System.Windows.Forms.Button
        Friend WithEvents btnRefreshLabResults As Global.System.Windows.Forms.Button
        Friend WithEvents btnViewKizenResults As Global.System.Windows.Forms.Button
        Friend WithEvents headerPanel As Global.System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblPatientName As Global.System.Windows.Forms.Label
        Friend WithEvents txtPatientName As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblGender As Global.System.Windows.Forms.Label
        Friend WithEvents txtGender As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblAge As Global.System.Windows.Forms.Label
        Friend WithEvents txtAge As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblNationality As Global.System.Windows.Forms.Label
        Friend WithEvents txtNationality As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblIdentityNo As Global.System.Windows.Forms.Label
        Friend WithEvents txtIdentityNo As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblFileNo As Global.System.Windows.Forms.Label
        Friend WithEvents txtFileNo As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblInvoiceDate As Global.System.Windows.Forms.Label
        Friend WithEvents txtInvoiceDate As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblDoctorName As Global.System.Windows.Forms.Label
        Friend WithEvents txtDoctorName As Global.System.Windows.Forms.TextBox
        Friend WithEvents lblBloodType As Global.System.Windows.Forms.Label
        Friend WithEvents cboBloodType As Global.System.Windows.Forms.ComboBox
        Friend WithEvents dgvResults As Global.System.Windows.Forms.DataGridView
        Friend WithEvents colSequence As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSection As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTest As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colLabResult As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colLabReferenceValue As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colLabUnit As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colLabAssessment As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colResultStatusSource As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colResultText As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFit As Global.System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents colUnfit As Global.System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents colRemarks As Global.System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents finalPanel As Global.System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents chkFinalFit As Global.System.Windows.Forms.CheckBox
        Friend WithEvents chkFinalUnfit As Global.System.Windows.Forms.CheckBox
        Friend WithEvents lblRemarks As Global.System.Windows.Forms.Label
        Friend WithEvents txtRemarks As Global.System.Windows.Forms.TextBox

    End Class

End Namespace
