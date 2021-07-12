Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BankEntryTv
        Inherits CFormEntryTvNew

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
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.CFlowLayout1)
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
            Me.ImageListTreeView.Images.SetKeyName(0, "TreeNode.ico")
            Me.ImageListTreeView.Images.SetKeyName(1, "openbriefcase.png")
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
            Me.TxtIdNo.LinkedLabel = Me.lblIdNo
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
            'txtBankCode
            '
            Me.txtBankCode.BackColor = System.Drawing.Color.White
            Me.txtBankCode.BegFindValue = Nothing
            Me.txtBankCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankCode.ComputedValue = False
            Me.txtBankCode.CustomFormat = Nothing
            Me.txtBankCode.DataBoundControl = True
            Me.txtBankCode.EditingMode = True
            Me.txtBankCode.EndFindValue = Nothing
            Me.txtBankCode.FieldDescription = Nothing
            Me.txtBankCode.FieldName = Nothing
            Me.txtBankCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBankCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBankCode, True)
            resources.ApplyResources(Me.txtBankCode, "txtBankCode")
            Me.txtBankCode.ForeColor = System.Drawing.Color.Black
            Me.txtBankCode.LinkedLabel = Me.lblBankCode
            Me.txtBankCode.MaximumValue = Nothing
            Me.txtBankCode.MinimumValue = Nothing
            Me.txtBankCode.Name = "txtBankCode"
            Me.txtBankCode.OldValue = Nothing
            Me.txtBankCode.ReadOnly = True
            Me.txtBankCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBankCode.Translatable = False
            Me.txtBankCode.ValueIsMandatory = True
            '
            'txtBankName
            '
            Me.txtBankName.BackColor = System.Drawing.Color.White
            Me.txtBankName.BegFindValue = Nothing
            Me.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankName.ComputedValue = False
            Me.txtBankName.CustomFormat = Nothing
            Me.txtBankName.DataBoundControl = True
            Me.txtBankName.EditingMode = False
            Me.txtBankName.EndFindValue = Nothing
            Me.txtBankName.FieldDescription = Nothing
            Me.txtBankName.FieldName = Nothing
            Me.txtBankName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBankName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBankName, True)
            resources.ApplyResources(Me.txtBankName, "txtBankName")
            Me.txtBankName.ForeColor = System.Drawing.Color.Black
            Me.txtBankName.LinkedLabel = Me.lblBankName
            Me.txtBankName.MaximumValue = Nothing
            Me.txtBankName.MinimumValue = Nothing
            Me.txtBankName.Name = "txtBankName"
            Me.txtBankName.OldValue = Nothing
            Me.txtBankName.ReadOnly = True
            Me.txtBankName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBankName.Translatable = False
            Me.txtBankName.ValueIsMandatory = True
            '
            'txtBankNameAra
            '
            Me.txtBankNameAra.BackColor = System.Drawing.Color.White
            Me.txtBankNameAra.BegFindValue = Nothing
            Me.txtBankNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtBankNameAra.ComputedValue = False
            Me.txtBankNameAra.CustomFormat = Nothing
            Me.txtBankNameAra.DataBoundControl = True
            Me.txtBankNameAra.EditingMode = False
            Me.txtBankNameAra.EndFindValue = Nothing
            Me.txtBankNameAra.EnglishControl = Me.txtBankName
            Me.txtBankNameAra.FieldDescription = Nothing
            Me.txtBankNameAra.FieldName = Nothing
            Me.txtBankNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtBankNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtBankNameAra, True)
            resources.ApplyResources(Me.txtBankNameAra, "txtBankNameAra")
            Me.txtBankNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtBankNameAra.LinkedLabel = Me.lblBankNameAra
            Me.txtBankNameAra.MaximumValue = Nothing
            Me.txtBankNameAra.MinimumValue = Nothing
            Me.txtBankNameAra.Name = "txtBankNameAra"
            Me.txtBankNameAra.OldValue = Nothing
            Me.txtBankNameAra.ReadOnly = True
            Me.txtBankNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtBankNameAra.Translatable = False
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
            Me.txtNotes.FindEnabled = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Me.lblNotes
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
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.floDataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
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
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblBankCode
            '
            Me.lblBankCode.DisplayOnly = True
            Me.lblBankCode.EditingMode = False
            resources.ApplyResources(Me.lblBankCode, "lblBankCode")
            Me.lblBankCode.Name = "lblBankCode"
            Me.lblBankCode.Translatable = True
            '
            'lblBankName
            '
            Me.lblBankName.DisplayOnly = True
            Me.lblBankName.EditingMode = False
            resources.ApplyResources(Me.lblBankName, "lblBankName")
            Me.lblBankName.Name = "lblBankName"
            Me.lblBankName.Translatable = True
            '
            'lblBankNameAra
            '
            Me.lblBankNameAra.DisplayOnly = True
            Me.lblBankNameAra.EditingMode = False
            resources.ApplyResources(Me.lblBankNameAra, "lblBankNameAra")
            Me.lblBankNameAra.Name = "lblBankNameAra"
            Me.lblBankNameAra.Translatable = True
            '
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'BankEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "BankEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TxtIdNo As CTextBox
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
        Friend WithEvents CFlowLayout1 As CFlowLayout
    End Class
End Namespace