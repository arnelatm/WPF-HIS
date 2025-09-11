Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Presentation.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JournalPrefixEntry
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JournalPrefixEntry))
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblJournalCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblJournalCodeAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalCodeAra = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblJournalName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblJournalNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtJournalNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblIdNo)
            Me.CFlowLayout1.Controls.Add(Me.txtIdNo)
            Me.CFlowLayout1.Controls.Add(Me.lblJournalCode)
            Me.CFlowLayout1.Controls.Add(Me.txtJournalCode)
            Me.CFlowLayout1.Controls.Add(Me.lblJournalCodeAra)
            Me.CFlowLayout1.Controls.Add(Me.txtJournalCodeAra)
            Me.CFlowLayout1.Controls.Add(Me.lblJournalName)
            Me.CFlowLayout1.Controls.Add(Me.txtJournalName)
            Me.CFlowLayout1.Controls.Add(Me.lblJournalNameAra)
            Me.CFlowLayout1.Controls.Add(Me.txtJournalNameAra)
            resources.ApplyResources(Me.CFlowLayout1, "CFlowLayout1")
            Me.CFlowLayout1.Name = "CFlowLayout1"
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'txtIdNo
            '
            Me.txtIdNo.BackColor = System.Drawing.Color.White
            Me.txtIdNo.BegFindValue = Nothing
            Me.txtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdNo.ComputedValue = False
            Me.txtIdNo.CustomFormat = Nothing
            Me.txtIdNo.DataBoundControl = True
            Me.txtIdNo.DisplayOnly = True
            Me.txtIdNo.EditingMode = True
            Me.txtIdNo.EndFindValue = Nothing
            Me.txtIdNo.FieldDescription = Nothing
            Me.txtIdNo.FieldName = Nothing
            Me.txtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtIdNo.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtIdNo, True)
            resources.ApplyResources(Me.txtIdNo, "txtIdNo")
            Me.txtIdNo.ForeColor = System.Drawing.Color.Black
            Me.txtIdNo.LinkedLabel = Nothing
            Me.txtIdNo.MaximumValue = Nothing
            Me.txtIdNo.MinimumValue = Nothing
            Me.txtIdNo.Name = "txtIdNo"
            Me.txtIdNo.OldValue = Nothing
            Me.txtIdNo.ReadOnly = True
            Me.txtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtIdNo.TabStop = False
            Me.txtIdNo.Translatable = False
            Me.txtIdNo.ValueIsNumeric = True
            '
            'lblJournalCode
            '
            Me.lblJournalCode.DisplayOnly = True
            Me.lblJournalCode.EditingMode = False
            resources.ApplyResources(Me.lblJournalCode, "lblJournalCode")
            Me.lblJournalCode.Name = "lblJournalCode"
            Me.lblJournalCode.Translatable = True
            '
            'txtJournalCode
            '
            Me.txtJournalCode.BackColor = System.Drawing.Color.White
            Me.txtJournalCode.BegFindValue = Nothing
            Me.txtJournalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalCode.ComputedValue = False
            Me.txtJournalCode.CustomFormat = Nothing
            Me.txtJournalCode.DataBoundControl = True
            Me.txtJournalCode.DisplayOnly = True
            Me.txtJournalCode.EditingMode = True
            Me.txtJournalCode.EndFindValue = Nothing
            Me.txtJournalCode.FieldDescription = Nothing
            Me.txtJournalCode.FieldName = Nothing
            Me.txtJournalCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalCode.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtJournalCode, True)
            resources.ApplyResources(Me.txtJournalCode, "txtJournalCode")
            Me.txtJournalCode.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCode.LinkedLabel = Nothing
            Me.txtJournalCode.MaximumValue = Nothing
            Me.txtJournalCode.MinimumValue = Nothing
            Me.txtJournalCode.Name = "txtJournalCode"
            Me.txtJournalCode.OldValue = Nothing
            Me.txtJournalCode.ReadOnly = True
            Me.txtJournalCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCode.Translatable = False
            Me.txtJournalCode.ValueIsMandatory = True
            '
            'lblJournalCodeAra
            '
            Me.lblJournalCodeAra.DisplayOnly = True
            Me.lblJournalCodeAra.EditingMode = False
            resources.ApplyResources(Me.lblJournalCodeAra, "lblJournalCodeAra")
            Me.lblJournalCodeAra.Name = "lblJournalCodeAra"
            Me.lblJournalCodeAra.Translatable = True
            '
            'txtJournalCodeAra
            '
            Me.txtJournalCodeAra.BackColor = System.Drawing.Color.White
            Me.txtJournalCodeAra.BegFindValue = Nothing
            Me.txtJournalCodeAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalCodeAra.ComputedValue = False
            Me.txtJournalCodeAra.CustomFormat = Nothing
            Me.txtJournalCodeAra.DataBoundControl = True
            Me.txtJournalCodeAra.EditingMode = True
            Me.txtJournalCodeAra.EndFindValue = Nothing
            Me.txtJournalCodeAra.FieldDescription = Nothing
            Me.txtJournalCodeAra.FieldName = Nothing
            Me.txtJournalCodeAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalCodeAra.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtJournalCodeAra, True)
            resources.ApplyResources(Me.txtJournalCodeAra, "txtJournalCodeAra")
            Me.txtJournalCodeAra.ForeColor = System.Drawing.Color.Black
            Me.txtJournalCodeAra.LinkedLabel = Nothing
            Me.txtJournalCodeAra.MaximumValue = Nothing
            Me.txtJournalCodeAra.MinimumValue = Nothing
            Me.txtJournalCodeAra.Name = "txtJournalCodeAra"
            Me.txtJournalCodeAra.OldValue = Nothing
            Me.txtJournalCodeAra.ReadOnly = True
            Me.txtJournalCodeAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalCodeAra.Translatable = False
            Me.txtJournalCodeAra.ValueIsMandatory = True
            '
            'lblJournalName
            '
            Me.lblJournalName.DisplayOnly = True
            Me.lblJournalName.EditingMode = False
            resources.ApplyResources(Me.lblJournalName, "lblJournalName")
            Me.lblJournalName.Name = "lblJournalName"
            Me.lblJournalName.Translatable = True
            '
            'txtJournalName
            '
            Me.txtJournalName.BackColor = System.Drawing.Color.White
            Me.txtJournalName.BegFindValue = Nothing
            Me.txtJournalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalName.ComputedValue = False
            Me.txtJournalName.CustomFormat = Nothing
            Me.txtJournalName.DataBoundControl = True
            Me.txtJournalName.DisplayOnly = True
            Me.txtJournalName.EditingMode = False
            Me.txtJournalName.EndFindValue = Nothing
            Me.txtJournalName.FieldDescription = Nothing
            Me.txtJournalName.FieldName = Nothing
            Me.txtJournalName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalName.FindEnabled = True
            Me.CFlowLayout1.SetFlowBreak(Me.txtJournalName, True)
            resources.ApplyResources(Me.txtJournalName, "txtJournalName")
            Me.txtJournalName.ForeColor = System.Drawing.Color.Black
            Me.txtJournalName.LinkedLabel = Nothing
            Me.txtJournalName.MaximumValue = Nothing
            Me.txtJournalName.MinimumValue = Nothing
            Me.txtJournalName.Name = "txtJournalName"
            Me.txtJournalName.OldValue = Nothing
            Me.txtJournalName.ReadOnly = True
            Me.txtJournalName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalName.Translatable = False
            Me.txtJournalName.ValueIsMandatory = True
            '
            'lblJournalNameAra
            '
            Me.lblJournalNameAra.DisplayOnly = True
            Me.lblJournalNameAra.EditingMode = False
            resources.ApplyResources(Me.lblJournalNameAra, "lblJournalNameAra")
            Me.lblJournalNameAra.Name = "lblJournalNameAra"
            Me.lblJournalNameAra.Translatable = True
            '
            'txtJournalNameAra
            '
            Me.txtJournalNameAra.BackColor = System.Drawing.Color.White
            Me.txtJournalNameAra.BegFindValue = Nothing
            Me.txtJournalNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtJournalNameAra.ComputedValue = False
            Me.txtJournalNameAra.CustomFormat = Nothing
            Me.txtJournalNameAra.DataBoundControl = True
            Me.txtJournalNameAra.EditingMode = False
            Me.txtJournalNameAra.EndFindValue = Nothing
            Me.txtJournalNameAra.EnglishControl = Me.txtJournalName
            Me.txtJournalNameAra.FieldDescription = Nothing
            Me.txtJournalNameAra.FieldName = Nothing
            Me.txtJournalNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtJournalNameAra.FindEnabled = True
            resources.ApplyResources(Me.txtJournalNameAra, "txtJournalNameAra")
            Me.txtJournalNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtJournalNameAra.LinkedLabel = Nothing
            Me.txtJournalNameAra.MaximumValue = Nothing
            Me.txtJournalNameAra.MinimumValue = Nothing
            Me.txtJournalNameAra.Name = "txtJournalNameAra"
            Me.txtJournalNameAra.OldValue = Nothing
            Me.txtJournalNameAra.ReadOnly = True
            Me.txtJournalNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtJournalNameAra.Translatable = False
            '
            'JournalPrefixEntry
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "JournalPrefixEntry"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents txtIdNo As CTextBox
        Friend WithEvents lblJournalCode As CLabel
        Friend WithEvents txtJournalCode As CTextBox
        Friend WithEvents lblJournalCodeAra As CLabel
        Friend WithEvents txtJournalCodeAra As CTextBox
        Friend WithEvents lblJournalName As CLabel
        Friend WithEvents txtJournalName As CTextBox
        Friend WithEvents lblJournalNameAra As CLabel
        Friend WithEvents txtJournalNameAra As CTextBoxArabic
    End Class
End Namespace