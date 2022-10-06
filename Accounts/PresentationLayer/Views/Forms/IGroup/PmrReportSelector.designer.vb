Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class PmrReportSelector
    Inherits CForm

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
        Me.TxtTextToSearch = New System.Windows.Forms.TextBox()
        Me.lblLookFor1 = New System.Windows.Forms.Label()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CGroupBox1 = New AATM.Libraries.CBaseControlsLibrary.CGroupBox()
        Me.rbRadiology = New System.Windows.Forms.RadioButton()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.rbLaboratory = New System.Windows.Forms.RadioButton()
        Me.rbEr = New System.Windows.Forms.RadioButton()
        Me.rbPrescription = New System.Windows.Forms.RadioButton()
        Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.CGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtTextToSearch
        '
        Me.TxtTextToSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtTextToSearch.Location = New System.Drawing.Point(80, 3)
        Me.TxtTextToSearch.Name = "TxtTextToSearch"
        Me.TxtTextToSearch.Size = New System.Drawing.Size(270, 20)
        Me.TxtTextToSearch.TabIndex = 0
        Me.TxtTextToSearch.Text = "txtPatientName"
        '
        'lblLookFor1
        '
        Me.lblLookFor1.AutoSize = True
        Me.lblLookFor1.BackColor = System.Drawing.Color.Transparent
        Me.lblLookFor1.Location = New System.Drawing.Point(3, 0)
        Me.lblLookFor1.Name = "lblLookFor1"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblLookFor1, 5)
        Me.lblLookFor1.Size = New System.Drawing.Size(71, 13)
        Me.lblLookFor1.TabIndex = 1
        Me.lblLookFor1.Text = "Patient Name"
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.BackColor = System.Drawing.Color.Transparent
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(6, 19)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(39, 17)
        Me.rbAll.TabIndex = 3
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All "
        Me.rbAll.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblLookFor1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtTextToSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CGroupBox1, 0, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 29)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(353, 179)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'CGroupBox1
        '
        Me.CGroupBox1.AutoSize = True
        Me.CGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.SetColumnSpan(Me.CGroupBox1, 2)
        Me.CGroupBox1.Controls.Add(Me.rbPrescription)
        Me.CGroupBox1.Controls.Add(Me.rbEr)
        Me.CGroupBox1.Controls.Add(Me.rbLaboratory)
        Me.CGroupBox1.Controls.Add(Me.rbAll)
        Me.CGroupBox1.Controls.Add(Me.rbRadiology)
        Me.CGroupBox1.DisplayOnly = True
        Me.CGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CGroupBox1.Location = New System.Drawing.Point(3, 29)
        Me.CGroupBox1.Name = "CGroupBox1"
        Me.CGroupBox1.Size = New System.Drawing.Size(347, 147)
        Me.CGroupBox1.TabIndex = 7
        Me.CGroupBox1.TabStop = False
        '
        'rbRadiology
        '
        Me.rbRadiology.AutoSize = True
        Me.rbRadiology.BackColor = System.Drawing.Color.Transparent
        Me.rbRadiology.Location = New System.Drawing.Point(5, 88)
        Me.rbRadiology.Name = "rbRadiology"
        Me.rbRadiology.Size = New System.Drawing.Size(115, 17)
        Me.rbRadiology.TabIndex = 11
        Me.rbRadiology.Text = "Radiology Request"
        Me.rbRadiology.UseVisualStyleBackColor = False
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CLabel1.DisplayOnly = True
        Me.CLabel1.EditingMode = False
        Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New System.Drawing.Point(142, 8)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New System.Drawing.Size(92, 17)
        Me.CLabel1.TabIndex = 7
        Me.CLabel1.Text = "PMR Reports"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CLabel1.Translatable = True
        '
        'rbLaboratory
        '
        Me.rbLaboratory.AutoSize = True
        Me.rbLaboratory.BackColor = System.Drawing.Color.Transparent
        Me.rbLaboratory.Location = New System.Drawing.Point(6, 65)
        Me.rbLaboratory.Name = "rbLaboratory"
        Me.rbLaboratory.Size = New System.Drawing.Size(118, 17)
        Me.rbLaboratory.TabIndex = 12
        Me.rbLaboratory.Text = "Laboratory Request"
        Me.rbLaboratory.UseVisualStyleBackColor = False
        '
        'rbEr
        '
        Me.rbEr.AutoSize = True
        Me.rbEr.BackColor = System.Drawing.Color.Transparent
        Me.rbEr.Location = New System.Drawing.Point(6, 111)
        Me.rbEr.Name = "rbEr"
        Me.rbEr.Size = New System.Drawing.Size(84, 17)
        Me.rbEr.TabIndex = 13
        Me.rbEr.Text = "ER Services"
        Me.rbEr.UseVisualStyleBackColor = False
        '
        'rbPrescription
        '
        Me.rbPrescription.AutoSize = True
        Me.rbPrescription.BackColor = System.Drawing.Color.Transparent
        Me.rbPrescription.Location = New System.Drawing.Point(5, 42)
        Me.rbPrescription.Name = "rbPrescription"
        Me.rbPrescription.Size = New System.Drawing.Size(120, 17)
        Me.rbPrescription.TabIndex = 14
        Me.rbPrescription.Text = "Medical Prescription"
        Me.rbPrescription.UseVisualStyleBackColor = False
        '
        'CButton1
        '
        Me.CButton1.DesignerSelected = False
        Me.CButton1.ImageIndex = 0
        Me.CButton1.Location = New System.Drawing.Point(90, 211)
        Me.CButton1.Name = "CButton1"
        Me.CButton1.OriginalImageName = Nothing
        Me.CButton1.SecurityKey = ""
        Me.CButton1.Size = New System.Drawing.Size(90, 25)
        Me.CButton1.TabIndex = 8
        Me.CButton1.Text = "Cancel"
        '
        'CButton2
        '
        Me.CButton2.DesignerSelected = False
        Me.CButton2.ImageIndex = 0
        Me.CButton2.Location = New System.Drawing.Point(186, 211)
        Me.CButton2.Name = "CButton2"
        Me.CButton2.OriginalImageName = Nothing
        Me.CButton2.SecurityKey = ""
        Me.CButton2.Size = New System.Drawing.Size(90, 25)
        Me.CButton2.TabIndex = 9
        Me.CButton2.Text = "Print"
        '
        'PmrReportSelector
        '
        Me.ClientSize = New System.Drawing.Size(380, 245)
        Me.Controls.Add(Me.CButton2)
        Me.Controls.Add(Me.CButton1)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PmrReportSelector"
        Me.Text = "Find Field Form"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.CGroupBox1.ResumeLayout(False)
        Me.CGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtTextToSearch As TextBox
    Friend WithEvents lblLookFor1 As Label
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents rbRadiology As RadioButton
    Friend WithEvents CGroupBox1 As CGroupBox
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents rbPrescription As RadioButton
    Friend WithEvents rbEr As RadioButton
    Friend WithEvents rbLaboratory As RadioButton
    Friend WithEvents CButton1 As CButton
    Friend WithEvents CButton2 As CButton
End Class
