Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BankEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankEntryTv))
            Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBankCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBankName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBankNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBankCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBankName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBankNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.TreeViewTableName, "TreeViewTableName")
            '
            'TxtIDNo
            '
            Me.TxtIDNo.AcceptsReturn = False
            Me.TxtIDNo.AcceptsTab = False
            Me.TxtIDNo.BackColor = System.Drawing.Color.White
            Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIDNo.ComputedValue = False
            Me.TxtIDNo.DataBoundControl = True
            Me.TxtIDNo.DisplayOnly = True
            Me.TxtIDNo.EditingMode = True
            resources.ApplyResources(Me.TxtIDNo, "TxtIDNo")
            Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, True)
            Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIDNo.LinkedLabel = Nothing
            Me.TxtIDNo.Name = "TxtIDNo"
            Me.TxtIDNo.ReadOnly = True
            Me.TxtIDNo.TabStop = False
            '
            'txtBankCode
            '
            Me.txtBankCode.AcceptsReturn = False
            Me.txtBankCode.AcceptsTab = False
            Me.txtBankCode.BackColor = System.Drawing.Color.White
            Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankCode.ComputedValue = False
            Me.txtBankCode.DataBoundControl = True
            Me.txtBankCode.EditingMode = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBankCode, True)
            resources.ApplyResources(Me.txtBankCode, "txtBankCode")
            Me.txtBankCode.ForeColor = System.Drawing.Color.Black
            Me.txtBankCode.LinkedLabel = Nothing
            Me.txtBankCode.Name = "txtBankCode"
            Me.txtBankCode.ReadOnly = True
            Me.txtBankCode.ValueIsMandatory = True
            '
            'txtBankName
            '
            Me.txtBankName.AcceptsReturn = False
            Me.txtBankName.AcceptsTab = False
            Me.txtBankName.BackColor = System.Drawing.Color.White
            Me.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankName.ComputedValue = False
            Me.txtBankName.DataBoundControl = True
            Me.txtBankName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtBankName, True)
            resources.ApplyResources(Me.txtBankName, "txtBankName")
            Me.txtBankName.ForeColor = System.Drawing.Color.Black
            Me.txtBankName.LinkedLabel = Nothing
            Me.txtBankName.Name = "txtBankName"
            Me.txtBankName.ValueIsMandatory = True
            '
            'txtBankNameAra
            '
            Me.txtBankNameAra.AcceptsReturn = False
            Me.txtBankNameAra.AcceptsTab = False
            Me.txtBankNameAra.BackColor = System.Drawing.Color.White
            Me.txtBankNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankNameAra.ComputedValue = False
            Me.txtBankNameAra.DataBoundControl = True
            Me.txtBankNameAra.EditingMode = False
            Me.txtBankNameAra.EnglishControl = Me.txtBankName
            Me.floDataDisplay.SetFlowBreak(Me.txtBankNameAra, True)
            resources.ApplyResources(Me.txtBankNameAra, "txtBankNameAra")
            Me.txtBankNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtBankNameAra.LinkedLabel = Nothing
            Me.txtBankNameAra.Name = "txtBankNameAra"
            '
            'txtNotes
            '
            Me.txtNotes.AcceptsReturn = False
            Me.txtNotes.AcceptsTab = False
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.DataBoundControl = True
            Me.txtNotes.EditingMode = False
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
            Me.floDataDisplay.Controls.Add(Me.lblBankCode)
            Me.floDataDisplay.Controls.Add(Me.txtBankCode)
            Me.floDataDisplay.Controls.Add(Me.lblBankName)
            Me.floDataDisplay.Controls.Add(Me.txtBankName)
            Me.floDataDisplay.Controls.Add(Me.lblBankNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtBankNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            '
            'lblBankCode
            '
            resources.ApplyResources(Me.lblBankCode, "lblBankCode")
            Me.lblBankCode.Name = "lblBankCode"
            '
            'lblBankName
            '
            resources.ApplyResources(Me.lblBankName, "lblBankName")
            Me.lblBankName.Name = "lblBankName"
            '
            'lblBankNameAra
            '
            resources.ApplyResources(Me.lblBankNameAra, "lblBankNameAra")
            Me.lblBankNameAra.Name = "lblBankNameAra"
            '
            'lblNotes
            '
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            '
            'BankEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "BankEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIDNo As CTextBox
        Friend WithEvents txtBankCode As CTextBox
        Friend WithEvents txtBankName As CTextBox
        Friend WithEvents txtBankNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblBankCode As CLabel
        Friend WithEvents lblBankName As CLabel
        Friend WithEvents lblBankNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
    End Class
End Namespace