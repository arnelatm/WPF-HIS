Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.LIBRARIES.CBaseControlsLibrary
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class BfModalForm
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
        Me.components = New Container()
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(BfModalForm))
        Me.TxtSearchValue = New CTextBox()
        Me.CLabel1 = New CLabel()
        Me.CRadioButton1 = New CRadioButton()
        Me.CRadioButton2 = New CRadioButton()
        Me.BtnFind = New CButton()
        Me.BtnCancel = New CButton()
        Me.SuspendLayout()
        '
        'TxtSearchValue
        '
        Me.TxtSearchValue.AcceptsReturn = false
        Me.TxtSearchValue.AcceptsTab = false
        Me.TxtSearchValue.BackColor = Color.White
        Me.TxtSearchValue.BorderStyle = BorderStyle.FixedSingle
        Me.TxtSearchValue.ComputedValue = False
        Me.TxtSearchValue.DataBoundControl = True
        Me.TxtSearchValue.Enabled = False
        Me.TxtSearchValue.Font = New Font("Microsoft Sans Serif", 10.0!)
        Me.TxtSearchValue.ForeColor = Color.Black
        Me.TxtSearchValue.LinkedLabel = Nothing
        Me.TxtSearchValue.Location = New Point(90, 7)
        Me.TxtSearchValue.Margin = New Padding(1)
        Me.TxtSearchValue.Name = "TxtSearchValue"
        Me.TxtSearchValue.EditingMode = False
        Me.TxtSearchValue.Size = New Size(213, 23)
        Me.TxtSearchValue.TabIndex = 0
        '
        'CLabel1
        '
        Me.CLabel1.AutoSize = True
        Me.CLabel1.Font = New Font("Microsoft Sans Serif", 10.0!)
        Me.CLabel1.Location = New Point(12, 9)
        Me.CLabel1.Margin = New Padding(1)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.Size = New Size(60, 17)
        Me.CLabel1.TabIndex = 1
        Me.CLabel1.Text = "Look for"
        Me.CLabel1.TextAlign = ContentAlignment.MiddleLeft
        '
        'CRadioButton1
        '
        Me.CRadioButton1.AutoSize = True
        Me.CRadioButton1.Checked = True
        Me.CRadioButton1.Enabled = False
        Me.CRadioButton1.Location = New Point(15, 48)
        Me.CRadioButton1.Name = "CRadioButton1"
        Me.CRadioButton1.Size = New Size(124, 17)
        Me.CRadioButton1.TabIndex = 2
        Me.CRadioButton1.TabStop = True
        Me.CRadioButton1.Text = "Look at start of Field"
        Me.CRadioButton1.UseVisualStyleBackColor = True
        '
        'CRadioButton2
        '
        Me.CRadioButton2.AutoSize = True
        Me.CRadioButton2.Enabled = False
        Me.CRadioButton2.Location = New Point(15, 71)
        Me.CRadioButton2.Name = "CRadioButton2"
        Me.CRadioButton2.Size = New Size(132, 17)
        Me.CRadioButton2.TabIndex = 3
        Me.CRadioButton2.Text = "Look anywhere in field"
        Me.CRadioButton2.UseVisualStyleBackColor = True
        '
        'BtnFind
        '
        Me.BtnFind.BackColor = Color.Transparent
        Me.BtnFind.BackgroundImage = CType(resources.GetObject("BtnFind.BackgroundImage"), Image)
        Me.BtnFind.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnFind.DialogResult = DialogResult.OK
        Me.BtnFind.Location = New Point(52, 94)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New Size(75, 23)
        Me.BtnFind.TabIndex = 0
        Me.BtnFind.Text = "Find Next"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = Color.Transparent
        Me.BtnCancel.BackgroundImage = CType(resources.GetObject("BtnCancel.BackgroundImage"), Image)
        Me.BtnCancel.BackgroundImageLayout = ImageLayout.Stretch
        Me.BtnCancel.DialogResult = DialogResult.Cancel
        Me.BtnCancel.Location = New Point(161, 94)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Exit"
        '
        'BfModalForm
        '
        Me.AcceptButton = Me.BtnFind
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New Size(313, 122)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.CRadioButton2)
        Me.Controls.Add(Me.CRadioButton1)
        Me.Controls.Add(Me.CLabel1)
        Me.Controls.Add(Me.TxtSearchValue)
        Me.Name = "BfModalForm"
        Me.RightToLeft = RightToLeft.No
        Me.Text = "Search Field Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtSearchValue As CTextBox
    Friend WithEvents CLabel1 As CLabel
    Friend WithEvents CRadioButton1 As CRadioButton
    Friend WithEvents CRadioButton2 As CRadioButton
    Friend WithEvents BtnFind As CButton
    Friend WithEvents BtnCancel As CButton
End Class
