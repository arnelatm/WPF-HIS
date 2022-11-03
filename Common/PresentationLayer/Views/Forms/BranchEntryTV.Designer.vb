Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BranchEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BranchEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBranchCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBranchName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtBranchNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBranchCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBranchName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblBranchNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CButton1 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.txtBarcode = New System.Windows.Forms.TextBox()
            Me.CButton2 = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            resources.ApplyResources(Me.FormTreeView, "FormTreeView")
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = ""
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
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'txtBranchCode
            '
            Me.txtBranchCode.BackColor = System.Drawing.Color.White
            Me.txtBranchCode.BegFindValue = Nothing
            Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBranchCode.ComputedValue = False
            Me.txtBranchCode.CustomFormat = Nothing
            Me.txtBranchCode.DataBoundControl = True
            Me.txtBranchCode.EditingMode = True
            Me.txtBranchCode.EndFindValue = Nothing
            Me.txtBranchCode.FieldDescription = Nothing
            Me.txtBranchCode.FieldName = Nothing
            Me.txtBranchCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBranchCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBranchCode, True)
            resources.ApplyResources(Me.txtBranchCode, "txtBranchCode")
            Me.txtBranchCode.ForeColor = System.Drawing.Color.Black
            Me.txtBranchCode.LinkedLabel = Nothing
            Me.txtBranchCode.MaximumValue = Nothing
            Me.txtBranchCode.MinimumValue = Nothing
            Me.txtBranchCode.Name = "txtBranchCode"
            Me.txtBranchCode.OldValue = Nothing
            Me.txtBranchCode.ReadOnly = True
            Me.txtBranchCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBranchCode.Translatable = False
            Me.txtBranchCode.ValueIsMandatory = True
            Me.txtBranchCode.ValueIsUnique = True
            '
            'txtBranchName
            '
            Me.txtBranchName.BackColor = System.Drawing.Color.White
            Me.txtBranchName.BegFindValue = Nothing
            Me.txtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBranchName.ComputedValue = False
            Me.txtBranchName.CustomFormat = Nothing
            Me.txtBranchName.DataBoundControl = True
            Me.txtBranchName.EditingMode = False
            Me.txtBranchName.EndFindValue = Nothing
            Me.txtBranchName.FieldDescription = Nothing
            Me.txtBranchName.FieldName = Nothing
            Me.txtBranchName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBranchName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBranchName, True)
            resources.ApplyResources(Me.txtBranchName, "txtBranchName")
            Me.txtBranchName.ForeColor = System.Drawing.Color.Black
            Me.txtBranchName.LinkedLabel = Nothing
            Me.txtBranchName.MaximumValue = Nothing
            Me.txtBranchName.MinimumValue = Nothing
            Me.txtBranchName.Name = "txtBranchName"
            Me.txtBranchName.OldValue = Nothing
            Me.txtBranchName.ReadOnly = True
            Me.txtBranchName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBranchName.Translatable = False
            Me.txtBranchName.ValueIsMandatory = True
            Me.txtBranchName.ValueIsUnique = True
            '
            'txtBranchNameAra
            '
            Me.txtBranchNameAra.BackColor = System.Drawing.Color.White
            Me.txtBranchNameAra.BegFindValue = Nothing
            Me.txtBranchNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBranchNameAra.ComputedValue = False
            Me.txtBranchNameAra.CustomFormat = Nothing
            Me.txtBranchNameAra.DataBoundControl = True
            Me.txtBranchNameAra.EditingMode = False
            Me.txtBranchNameAra.EndFindValue = Nothing
            Me.txtBranchNameAra.EnglishControl = Me.txtBranchName
            Me.txtBranchNameAra.FieldDescription = Nothing
            Me.txtBranchNameAra.FieldName = Nothing
            Me.txtBranchNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBranchNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBranchNameAra, True)
            resources.ApplyResources(Me.txtBranchNameAra, "txtBranchNameAra")
            Me.txtBranchNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtBranchNameAra.LinkedLabel = Nothing
            Me.txtBranchNameAra.MaximumValue = Nothing
            Me.txtBranchNameAra.MinimumValue = Nothing
            Me.txtBranchNameAra.Name = "txtBranchNameAra"
            Me.txtBranchNameAra.OldValue = Nothing
            Me.txtBranchNameAra.ReadOnly = True
            Me.txtBranchNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBranchNameAra.Translatable = False
            Me.txtBranchNameAra.ValueIsUnique = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.ReadOnly = True
            Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtNotes.Translatable = False
            Me.txtNotes.ValueIsMandatory = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblBranchCode)
            Me.floDataDisplay.Controls.Add(Me.txtBranchCode)
            Me.floDataDisplay.Controls.Add(Me.lblBranchName)
            Me.floDataDisplay.Controls.Add(Me.txtBranchName)
            Me.floDataDisplay.Controls.Add(Me.lblBranchNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtBranchNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Controls.Add(Me.CButton1)
            Me.floDataDisplay.Controls.Add(Me.txtBarcode)
            Me.floDataDisplay.Controls.Add(Me.CButton2)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblBranchCode
            '
            Me.lblBranchCode.DisplayOnly = True
            Me.lblBranchCode.EditingMode = False
            resources.ApplyResources(Me.lblBranchCode, "lblBranchCode")
            Me.lblBranchCode.Name = "lblBranchCode"
            Me.lblBranchCode.Translatable = True
            '
            'lblBranchName
            '
            Me.lblBranchName.DisplayOnly = True
            Me.lblBranchName.EditingMode = False
            resources.ApplyResources(Me.lblBranchName, "lblBranchName")
            Me.lblBranchName.Name = "lblBranchName"
            Me.lblBranchName.Translatable = True
            '
            'lblBranchNameAra
            '
            Me.lblBranchNameAra.DisplayOnly = True
            Me.lblBranchNameAra.EditingMode = False
            resources.ApplyResources(Me.lblBranchNameAra, "lblBranchNameAra")
            Me.lblBranchNameAra.Name = "lblBranchNameAra"
            Me.lblBranchNameAra.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'CButton1
            '
            Me.CButton1.DesignerSelected = False
            Me.CButton1.ImageIndex = 0
            resources.ApplyResources(Me.CButton1, "CButton1")
            Me.CButton1.Name = "CButton1"
            Me.CButton1.OriginalImageName = Nothing
            Me.CButton1.SecurityKey = ""
            '
            'txtBarcode
            '
            resources.ApplyResources(Me.txtBarcode, "txtBarcode")
            Me.txtBarcode.Name = "txtBarcode"
            '
            'CButton2
            '
            Me.CButton2.DesignerSelected = False
            resources.ApplyResources(Me.CButton2, "CButton2")
            Me.CButton2.ImageIndex = 0
            Me.CButton2.Name = "CButton2"
            Me.CButton2.OriginalImageName = Nothing
            Me.CButton2.SecurityKey = ""
            '
            'BranchEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "BranchEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents txtBranchCode As CTextBox
        Friend WithEvents txtBranchName As CTextBox
        Friend WithEvents txtBranchNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblBranchCode As CLabel
        Friend WithEvents lblBranchName As CLabel
        Friend WithEvents lblBranchNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents CButton1 As CButton
        Friend WithEvents txtBarcode As TextBox
        Friend WithEvents CButton2 As CButton
    End Class
End NameSpace