Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CodeGroupEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodeGroupEntryTv))
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCodeGroupCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCodeGroupCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCodeGroupName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCodeGroupName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCodeGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblCodeGroupNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
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
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'txtCodeGroupCode
            '
            Me.txtCodeGroupCode.BackColor = System.Drawing.Color.White
            Me.txtCodeGroupCode.BegFindValue = Nothing
            Me.txtCodeGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCodeGroupCode.ComputedValue = False
            Me.txtCodeGroupCode.CustomFormat = Nothing
            Me.txtCodeGroupCode.DataBoundControl = True
            Me.txtCodeGroupCode.EditingMode = True
            Me.txtCodeGroupCode.EndFindValue = Nothing
            Me.txtCodeGroupCode.FieldDescription = Nothing
            Me.txtCodeGroupCode.FieldName = Nothing
            Me.txtCodeGroupCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCodeGroupCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCodeGroupCode, True)
            resources.ApplyResources(Me.txtCodeGroupCode, "txtCodeGroupCode")
            Me.txtCodeGroupCode.ForeColor = System.Drawing.Color.Black
            Me.txtCodeGroupCode.LinkedLabel = Me.lblCodeGroupCode
            Me.txtCodeGroupCode.MaximumValue = Nothing
            Me.txtCodeGroupCode.MinimumValue = Nothing
            Me.txtCodeGroupCode.Name = "txtCodeGroupCode"
            Me.txtCodeGroupCode.OldValue = Nothing
            Me.txtCodeGroupCode.ReadOnly = True
            Me.txtCodeGroupCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCodeGroupCode.Translatable = False
            Me.txtCodeGroupCode.ValueIsMandatory = True
            Me.txtCodeGroupCode.ValueIsUnique = True
            '
            'lblCodeGroupCode
            '
            Me.lblCodeGroupCode.DisplayOnly = True
            Me.lblCodeGroupCode.EditingMode = False
            resources.ApplyResources(Me.lblCodeGroupCode, "lblCodeGroupCode")
            Me.lblCodeGroupCode.Name = "lblCodeGroupCode"
            Me.lblCodeGroupCode.Translatable = True
            '
            'txtCodeGroupName
            '
            Me.txtCodeGroupName.BackColor = System.Drawing.Color.White
            Me.txtCodeGroupName.BegFindValue = Nothing
            Me.txtCodeGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCodeGroupName.ComputedValue = False
            Me.txtCodeGroupName.CustomFormat = Nothing
            Me.txtCodeGroupName.DataBoundControl = True
            Me.txtCodeGroupName.EditingMode = False
            Me.txtCodeGroupName.EndFindValue = Nothing
            Me.txtCodeGroupName.FieldDescription = Nothing
            Me.txtCodeGroupName.FieldName = Nothing
            Me.txtCodeGroupName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCodeGroupName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCodeGroupName, True)
            resources.ApplyResources(Me.txtCodeGroupName, "txtCodeGroupName")
            Me.txtCodeGroupName.ForeColor = System.Drawing.Color.Black
            Me.txtCodeGroupName.LinkedLabel = Me.lblCodeGroupName
            Me.txtCodeGroupName.MaximumValue = Nothing
            Me.txtCodeGroupName.MinimumValue = Nothing
            Me.txtCodeGroupName.Name = "txtCodeGroupName"
            Me.txtCodeGroupName.OldValue = Nothing
            Me.txtCodeGroupName.ReadOnly = True
            Me.txtCodeGroupName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCodeGroupName.Translatable = False
            Me.txtCodeGroupName.ValueIsMandatory = True
            Me.txtCodeGroupName.ValueIsUnique = True
            '
            'lblCodeGroupName
            '
            Me.lblCodeGroupName.DisplayOnly = True
            Me.lblCodeGroupName.EditingMode = False
            resources.ApplyResources(Me.lblCodeGroupName, "lblCodeGroupName")
            Me.lblCodeGroupName.Name = "lblCodeGroupName"
            Me.lblCodeGroupName.Translatable = True
            '
            'txtCodeGroupNameAra
            '
            Me.txtCodeGroupNameAra.BackColor = System.Drawing.Color.White
            Me.txtCodeGroupNameAra.BegFindValue = Nothing
            Me.txtCodeGroupNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCodeGroupNameAra.ComputedValue = False
            Me.txtCodeGroupNameAra.CustomFormat = Nothing
            Me.txtCodeGroupNameAra.DataBoundControl = True
            Me.txtCodeGroupNameAra.EditingMode = False
            Me.txtCodeGroupNameAra.EndFindValue = Nothing
            Me.txtCodeGroupNameAra.EnglishControl = Me.txtCodeGroupName
            Me.txtCodeGroupNameAra.FieldDescription = Nothing
            Me.txtCodeGroupNameAra.FieldName = Nothing
            Me.txtCodeGroupNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtCodeGroupNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtCodeGroupNameAra, True)
            resources.ApplyResources(Me.txtCodeGroupNameAra, "txtCodeGroupNameAra")
            Me.txtCodeGroupNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtCodeGroupNameAra.LinkedLabel = Me.lblCodeGroupNameAra
            Me.txtCodeGroupNameAra.MaximumValue = Nothing
            Me.txtCodeGroupNameAra.MinimumValue = Nothing
            Me.txtCodeGroupNameAra.Name = "txtCodeGroupNameAra"
            Me.txtCodeGroupNameAra.OldValue = Nothing
            Me.txtCodeGroupNameAra.ReadOnly = True
            Me.txtCodeGroupNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtCodeGroupNameAra.Translatable = False
            Me.txtCodeGroupNameAra.ValueIsUnique = True
            '
            'lblCodeGroupNameAra
            '
            Me.lblCodeGroupNameAra.DisplayOnly = True
            Me.lblCodeGroupNameAra.EditingMode = False
            resources.ApplyResources(Me.lblCodeGroupNameAra, "lblCodeGroupNameAra")
            Me.lblCodeGroupNameAra.Name = "lblCodeGroupNameAra"
            Me.lblCodeGroupNameAra.Translatable = True
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
            'lblNotes
            '
            Me.lblNotes.DisplayOnly = True
            Me.lblNotes.EditingMode = False
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.Name = "lblNotes"
            Me.lblNotes.Translatable = True
            '
            'floDataDisplay
            '
            resources.ApplyResources(Me.floDataDisplay, "floDataDisplay")
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.floDataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblCodeGroupCode)
            Me.floDataDisplay.Controls.Add(Me.txtCodeGroupCode)
            Me.floDataDisplay.Controls.Add(Me.lblCodeGroupName)
            Me.floDataDisplay.Controls.Add(Me.txtCodeGroupName)
            Me.floDataDisplay.Controls.Add(Me.lblCodeGroupNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtCodeGroupNameAra)
            Me.floDataDisplay.Controls.Add(Me.lblNotes)
            Me.floDataDisplay.Controls.Add(Me.txtNotes)
            Me.floDataDisplay.Name = "floDataDisplay"
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.floDataDisplay)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'CodeGroupEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "CodeGroupEntryTv"
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
        Friend WithEvents txtCodeGroupCode As CTextBox
        Friend WithEvents txtCodeGroupName As CTextBox
        Friend WithEvents txtCodeGroupNameAra As CTextBoxArabic
        Friend WithEvents txtNotes As CTextBox
        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblCodeGroupCode As CLabel
        Friend WithEvents lblCodeGroupName As CLabel
        Friend WithEvents lblCodeGroupNameAra As CLabel
        Friend WithEvents lblNotes As CLabel
        Friend WithEvents CFlowLayout1 As CFlowLayout
    End Class
End Namespace