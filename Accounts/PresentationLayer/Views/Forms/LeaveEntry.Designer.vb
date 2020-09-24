Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LeaveEntry
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LeaveEntry))
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtMaxLimit = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel5 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMaxCarryOver = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel4 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCumulative = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPaidPercent = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtDeductionCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtLeaveName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.YellowGradientBackgroundLarge
            Me.floDataDisplay.Controls.Add(Me.TableLayoutPanel1)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'TableLayoutPanel1
            '
            resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
            Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 14)
            Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 15)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMaxLimit, 0, 13)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel5, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMaxCarryOver, 1, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel4, 1, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.chkCumulative, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPaidPercent, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel2, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtDeductionCode, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 0, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtLeaveNameAra, 0, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.lblNameAra, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.txtLeaveName, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.lblName, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.txtLeaveCode, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblIdNo, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCode, 1, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            '
            'lblNotes
            '
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            Me.lblNotes.Name = "lblNotes"
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 2)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.ValueIsMandatory = True
            '
            'txtMaxLimit
            '
            Me.txtMaxLimit.BackColor = System.Drawing.Color.White
            Me.txtMaxLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxLimit.ComputedValue = False
            Me.txtMaxLimit.CustomFormat = Nothing
            Me.txtMaxLimit.DataBoundControl = True
            Me.txtMaxLimit.EditingMode = True
            resources.ApplyResources(Me.txtMaxLimit, "txtMaxLimit")
            Me.txtMaxLimit.ForeColor = System.Drawing.Color.Black
            Me.txtMaxLimit.LinkedLabel = Nothing
            Me.txtMaxLimit.MaximumValue = Nothing
            Me.txtMaxLimit.MinimumValue = Nothing
            Me.txtMaxLimit.Name = "txtMaxLimit"
            Me.txtMaxLimit.OldValue = Nothing
            Me.txtMaxLimit.ReadOnly = True
            Me.txtMaxLimit.ValueIsMandatory = True
            '
            'CLabel5
            '
            resources.ApplyResources(Me.CLabel5, "CLabel5")
            Me.CLabel5.DisplayOnly = True
            Me.CLabel5.EditingMode = False
            Me.CLabel5.Name = "CLabel5"
            '
            'txtMaxCarryOver
            '
            Me.txtMaxCarryOver.BackColor = System.Drawing.Color.White
            Me.txtMaxCarryOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxCarryOver.ComputedValue = False
            Me.txtMaxCarryOver.CustomFormat = Nothing
            Me.txtMaxCarryOver.DataBoundControl = True
            Me.txtMaxCarryOver.EditingMode = True
            resources.ApplyResources(Me.txtMaxCarryOver, "txtMaxCarryOver")
            Me.txtMaxCarryOver.ForeColor = System.Drawing.Color.Black
            Me.txtMaxCarryOver.LinkedLabel = Nothing
            Me.txtMaxCarryOver.MaximumValue = Nothing
            Me.txtMaxCarryOver.MinimumValue = Nothing
            Me.txtMaxCarryOver.Name = "txtMaxCarryOver"
            Me.txtMaxCarryOver.OldValue = Nothing
            Me.txtMaxCarryOver.ReadOnly = True
            Me.txtMaxCarryOver.ValueIsMandatory = True
            '
            'CLabel4
            '
            resources.ApplyResources(Me.CLabel4, "CLabel4")
            Me.CLabel4.DisplayOnly = True
            Me.CLabel4.EditingMode = False
            Me.CLabel4.Name = "CLabel4"
            '
            'chkCumulative
            '
            resources.ApplyResources(Me.chkCumulative, "chkCumulative")
            Me.chkCumulative.BackColor = System.Drawing.Color.White
            Me.chkCumulative.DisplayOnly = False
            Me.chkCumulative.EditingMode = True
            Me.chkCumulative.FlatAppearance.BorderSize = 0
            Me.chkCumulative.ForeColor = System.Drawing.Color.Black
            Me.chkCumulative.LinkedLabel = Nothing
            Me.chkCumulative.Name = "chkCumulative"
            Me.chkCumulative.NoLabel = False
            Me.chkCumulative.OldValue = Nothing
            Me.chkCumulative.UseVisualStyleBackColor = True
            '
            'CLabel3
            '
            resources.ApplyResources(Me.CLabel3, "CLabel3")
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Name = "CLabel3"
            '
            'txtPaidPercent
            '
            Me.txtPaidPercent.BackColor = System.Drawing.Color.White
            Me.txtPaidPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPaidPercent.ComputedValue = False
            Me.txtPaidPercent.CustomFormat = Nothing
            Me.txtPaidPercent.DataBoundControl = True
            Me.txtPaidPercent.EditingMode = True
            resources.ApplyResources(Me.txtPaidPercent, "txtPaidPercent")
            Me.txtPaidPercent.ForeColor = System.Drawing.Color.Black
            Me.txtPaidPercent.LinkedLabel = Nothing
            Me.txtPaidPercent.MaximumValue = Nothing
            Me.txtPaidPercent.MinimumValue = Nothing
            Me.txtPaidPercent.Name = "txtPaidPercent"
            Me.txtPaidPercent.OldValue = Nothing
            Me.txtPaidPercent.ReadOnly = True
            Me.txtPaidPercent.ValueIsMandatory = True
            '
            'CLabel2
            '
            resources.ApplyResources(Me.CLabel2, "CLabel2")
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Name = "CLabel2"
            '
            'txtDeductionCode
            '
            Me.txtDeductionCode.BackColor = System.Drawing.Color.White
            Me.txtDeductionCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeductionCode.ComputedValue = False
            Me.txtDeductionCode.CustomFormat = Nothing
            Me.txtDeductionCode.DataBoundControl = True
            Me.txtDeductionCode.EditingMode = True
            resources.ApplyResources(Me.txtDeductionCode, "txtDeductionCode")
            Me.txtDeductionCode.ForeColor = System.Drawing.Color.Black
            Me.txtDeductionCode.LinkedLabel = Nothing
            Me.txtDeductionCode.MaximumValue = Nothing
            Me.txtDeductionCode.MinimumValue = Nothing
            Me.txtDeductionCode.Name = "txtDeductionCode"
            Me.txtDeductionCode.OldValue = Nothing
            Me.txtDeductionCode.ReadOnly = True
            Me.txtDeductionCode.ValueIsMandatory = True
            '
            'CLabel1
            '
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Name = "CLabel1"
            '
            'txtLeaveNameAra
            '
            Me.txtLeaveNameAra.BackColor = System.Drawing.Color.White
            Me.txtLeaveNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveNameAra, 2)
            Me.txtLeaveNameAra.ComputedValue = False
            Me.txtLeaveNameAra.CustomFormat = Nothing
            Me.txtLeaveNameAra.DataBoundControl = True
            Me.txtLeaveNameAra.EditingMode = False
            Me.txtLeaveNameAra.EnglishControl = Me.txtLeaveName
            resources.ApplyResources(Me.txtLeaveNameAra, "txtLeaveNameAra")
            Me.txtLeaveNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveNameAra.LinkedLabel = Nothing
            Me.txtLeaveNameAra.MaximumValue = Nothing
            Me.txtLeaveNameAra.MinimumValue = Nothing
            Me.txtLeaveNameAra.Name = "txtLeaveNameAra"
            Me.txtLeaveNameAra.OldValue = Nothing
            Me.txtLeaveNameAra.ReadOnly = True
            '
            'txtLeaveName
            '
            Me.txtLeaveName.BackColor = System.Drawing.Color.White
            Me.txtLeaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveName, 2)
            Me.txtLeaveName.ComputedValue = False
            Me.txtLeaveName.CustomFormat = Nothing
            Me.txtLeaveName.DataBoundControl = True
            Me.txtLeaveName.EditingMode = False
            resources.ApplyResources(Me.txtLeaveName, "txtLeaveName")
            Me.txtLeaveName.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveName.LinkedLabel = Nothing
            Me.txtLeaveName.MaximumValue = Nothing
            Me.txtLeaveName.MinimumValue = Nothing
            Me.txtLeaveName.Name = "txtLeaveName"
            Me.txtLeaveName.OldValue = Nothing
            Me.txtLeaveName.ReadOnly = True
            Me.txtLeaveName.ValueIsMandatory = True
            '
            'lblNameAra
            '
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblNameAra, 2)
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            '
            'lblName
            '
            resources.ApplyResources(Me.lblName, "lblName")
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Name = "lblName"
            '
            'txtLeaveCode
            '
            Me.txtLeaveCode.BackColor = System.Drawing.Color.White
            Me.txtLeaveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveCode.ComputedValue = False
            Me.txtLeaveCode.CustomFormat = Nothing
            Me.txtLeaveCode.DataBoundControl = True
            Me.txtLeaveCode.EditingMode = True
            resources.ApplyResources(Me.txtLeaveCode, "txtLeaveCode")
            Me.txtLeaveCode.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveCode.LinkedLabel = Nothing
            Me.txtLeaveCode.MaximumValue = Nothing
            Me.txtLeaveCode.MinimumValue = Nothing
            Me.txtLeaveCode.Name = "txtLeaveCode"
            Me.txtLeaveCode.OldValue = Nothing
            Me.txtLeaveCode.ReadOnly = True
            Me.txtLeaveCode.ValueIsMandatory = True
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
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblIdNo
            '
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblCode
            '
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Name = "lblCode"
            '
            'LeaveEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "LeaveEntry"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents txtMaxLimit As CTextBox
        Friend WithEvents CLabel5 As CLabel
        Friend WithEvents txtMaxCarryOver As CTextBox
        Friend WithEvents CLabel4 As CLabel
        Friend WithEvents chkCumulative As CCheckBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents txtPaidPercent As CTextBox
        Friend WithEvents CLabel2 As CLabel
        Friend WithEvents txtDeductionCode As CTextBox
        Friend WithEvents CLabel1 As CLabel
        Friend WithEvents txtLeaveNameAra As CTextBoxArabic
        Friend WithEvents txtLeaveName As CTextBox
        Friend WithEvents lblNameAra As CLabel
        Friend WithEvents lblName As CLabel
        Friend WithEvents txtLeaveCode As CTextBox
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCode As CLabel
    End Class
End Namespace