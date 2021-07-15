Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LeaveEntryTv
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LeaveEntryTv))
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblNotes = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNotes = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.txtMaxLimit = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblMaxLimit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtMaxCarryOver = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblMaxCarryOver = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkCumulative = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblCumulative = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPaidPercent = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPaidPercent = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveAllowed = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblLeaveAllowed = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.txtLeaveName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtLeaveCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
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
            Me.TableLayoutPanel1.Controls.Add(Me.lblMaxLimit, 0, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.txtMaxCarryOver, 1, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.lblMaxCarryOver, 1, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.chkCumulative, 0, 11)
            Me.TableLayoutPanel1.Controls.Add(Me.lblCumulative, 0, 10)
            Me.TableLayoutPanel1.Controls.Add(Me.txtPaidPercent, 1, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.lblPaidPercent, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.txtLeaveAllowed, 0, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.lblLeaveAllowed, 0, 8)
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
            Me.lblNotes.Translatable = True
            '
            'txtNotes
            '
            Me.txtNotes.BackColor = System.Drawing.Color.White
            Me.txtNotes.BegFindValue = Nothing
            Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 2)
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
            'txtMaxLimit
            '
            Me.txtMaxLimit.BackColor = System.Drawing.Color.White
            Me.txtMaxLimit.BegFindValue = Nothing
            Me.txtMaxLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxLimit.ComputedValue = False
            Me.txtMaxLimit.CustomFormat = Nothing
            Me.txtMaxLimit.DataBoundControl = True
            Me.txtMaxLimit.EditingMode = True
            Me.txtMaxLimit.EndFindValue = Nothing
            Me.txtMaxLimit.FieldDescription = Nothing
            Me.txtMaxLimit.FieldName = Nothing
            Me.txtMaxLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMaxLimit.FindEnabled = True
            resources.ApplyResources(Me.txtMaxLimit, "txtMaxLimit")
            Me.txtMaxLimit.ForeColor = System.Drawing.Color.Black
            Me.txtMaxLimit.LinkedLabel = Nothing
            Me.txtMaxLimit.MaximumValue = Nothing
            Me.txtMaxLimit.MinimumValue = Nothing
            Me.txtMaxLimit.Name = "txtMaxLimit"
            Me.txtMaxLimit.OldValue = Nothing
            Me.txtMaxLimit.ReadOnly = True
            Me.txtMaxLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMaxLimit.Translatable = False
            Me.txtMaxLimit.ValueIsMandatory = True
            '
            'lblMaxLimit
            '
            resources.ApplyResources(Me.lblMaxLimit, "lblMaxLimit")
            Me.lblMaxLimit.DisplayOnly = True
            Me.lblMaxLimit.EditingMode = False
            Me.lblMaxLimit.Name = "lblMaxLimit"
            Me.lblMaxLimit.Translatable = True
            '
            'txtMaxCarryOver
            '
            Me.txtMaxCarryOver.BackColor = System.Drawing.Color.White
            Me.txtMaxCarryOver.BegFindValue = Nothing
            Me.txtMaxCarryOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxCarryOver.ComputedValue = False
            Me.txtMaxCarryOver.CustomFormat = Nothing
            Me.txtMaxCarryOver.DataBoundControl = True
            Me.txtMaxCarryOver.EditingMode = True
            Me.txtMaxCarryOver.EndFindValue = Nothing
            Me.txtMaxCarryOver.FieldDescription = Nothing
            Me.txtMaxCarryOver.FieldName = Nothing
            Me.txtMaxCarryOver.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtMaxCarryOver.FindEnabled = True
            resources.ApplyResources(Me.txtMaxCarryOver, "txtMaxCarryOver")
            Me.txtMaxCarryOver.ForeColor = System.Drawing.Color.Black
            Me.txtMaxCarryOver.LinkedLabel = Nothing
            Me.txtMaxCarryOver.MaximumValue = Nothing
            Me.txtMaxCarryOver.MinimumValue = Nothing
            Me.txtMaxCarryOver.Name = "txtMaxCarryOver"
            Me.txtMaxCarryOver.OldValue = Nothing
            Me.txtMaxCarryOver.ReadOnly = True
            Me.txtMaxCarryOver.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMaxCarryOver.Translatable = False
            Me.txtMaxCarryOver.ValueIsMandatory = True
            '
            'lblMaxCarryOver
            '
            resources.ApplyResources(Me.lblMaxCarryOver, "lblMaxCarryOver")
            Me.lblMaxCarryOver.DisplayOnly = True
            Me.lblMaxCarryOver.EditingMode = False
            Me.lblMaxCarryOver.Name = "lblMaxCarryOver"
            Me.lblMaxCarryOver.Translatable = True
            '
            'chkCumulative
            '
            resources.ApplyResources(Me.chkCumulative, "chkCumulative")
            Me.chkCumulative.BackColor = System.Drawing.Color.White
            Me.chkCumulative.BegFindValue = Nothing
            Me.chkCumulative.DisplayOnly = False
            Me.chkCumulative.EditingMode = True
            Me.chkCumulative.EndFindValue = Nothing
            Me.chkCumulative.FieldDescription = Nothing
            Me.chkCumulative.FieldName = Nothing
            Me.chkCumulative.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkCumulative.FindEnabled = False
            Me.chkCumulative.FlatAppearance.BorderSize = 0
            Me.chkCumulative.ForeColor = System.Drawing.Color.Black
            Me.chkCumulative.IFindableControl_FindEnabled = False
            Me.chkCumulative.IgnoreCase = False
            Me.chkCumulative.LinkedLabel = Nothing
            Me.chkCumulative.Name = "chkCumulative"
            Me.chkCumulative.NoLabel = True
            Me.chkCumulative.OldValue = Nothing
            Me.chkCumulative.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkCumulative.Translatable = False
            Me.chkCumulative.UseVisualStyleBackColor = False
            '
            'lblCumulative
            '
            resources.ApplyResources(Me.lblCumulative, "lblCumulative")
            Me.lblCumulative.DisplayOnly = True
            Me.lblCumulative.EditingMode = False
            Me.lblCumulative.Name = "lblCumulative"
            Me.lblCumulative.Translatable = True
            '
            'txtPaidPercent
            '
            Me.txtPaidPercent.BackColor = System.Drawing.Color.White
            Me.txtPaidPercent.BegFindValue = Nothing
            Me.txtPaidPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPaidPercent.ComputedValue = False
            Me.txtPaidPercent.CustomFormat = Nothing
            Me.txtPaidPercent.DataBoundControl = True
            Me.txtPaidPercent.EditingMode = True
            Me.txtPaidPercent.EndFindValue = Nothing
            Me.txtPaidPercent.FieldDescription = Nothing
            Me.txtPaidPercent.FieldName = Nothing
            Me.txtPaidPercent.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPaidPercent.FindEnabled = True
            resources.ApplyResources(Me.txtPaidPercent, "txtPaidPercent")
            Me.txtPaidPercent.ForeColor = System.Drawing.Color.Black
            Me.txtPaidPercent.LinkedLabel = Nothing
            Me.txtPaidPercent.MaximumValue = Nothing
            Me.txtPaidPercent.MinimumValue = Nothing
            Me.txtPaidPercent.Name = "txtPaidPercent"
            Me.txtPaidPercent.OldValue = Nothing
            Me.txtPaidPercent.ReadOnly = True
            Me.txtPaidPercent.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPaidPercent.Translatable = False
            Me.txtPaidPercent.ValueIsMandatory = True
            '
            'lblPaidPercent
            '
            resources.ApplyResources(Me.lblPaidPercent, "lblPaidPercent")
            Me.lblPaidPercent.DisplayOnly = True
            Me.lblPaidPercent.EditingMode = False
            Me.lblPaidPercent.Name = "lblPaidPercent"
            Me.lblPaidPercent.Translatable = True
            '
            'txtLeaveAllowed
            '
            Me.txtLeaveAllowed.BackColor = System.Drawing.Color.White
            Me.txtLeaveAllowed.BegFindValue = Nothing
            Me.txtLeaveAllowed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveAllowed.ComputedValue = False
            Me.txtLeaveAllowed.CustomFormat = Nothing
            Me.txtLeaveAllowed.DataBoundControl = True
            Me.txtLeaveAllowed.EditingMode = True
            Me.txtLeaveAllowed.EndFindValue = Nothing
            Me.txtLeaveAllowed.FieldDescription = Nothing
            Me.txtLeaveAllowed.FieldName = Nothing
            Me.txtLeaveAllowed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveAllowed.FindEnabled = True
            resources.ApplyResources(Me.txtLeaveAllowed, "txtLeaveAllowed")
            Me.txtLeaveAllowed.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveAllowed.LinkedLabel = Nothing
            Me.txtLeaveAllowed.MaximumValue = Nothing
            Me.txtLeaveAllowed.MinimumValue = Nothing
            Me.txtLeaveAllowed.Name = "txtLeaveAllowed"
            Me.txtLeaveAllowed.OldValue = Nothing
            Me.txtLeaveAllowed.ReadOnly = True
            Me.txtLeaveAllowed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveAllowed.Translatable = False
            Me.txtLeaveAllowed.ValueIsMandatory = True
            '
            'lblLeaveAllowed
            '
            resources.ApplyResources(Me.lblLeaveAllowed, "lblLeaveAllowed")
            Me.lblLeaveAllowed.DisplayOnly = True
            Me.lblLeaveAllowed.EditingMode = False
            Me.lblLeaveAllowed.Name = "lblLeaveAllowed"
            Me.lblLeaveAllowed.Translatable = True
            '
            'txtLeaveNameAra
            '
            Me.txtLeaveNameAra.BackColor = System.Drawing.Color.White
            Me.txtLeaveNameAra.BegFindValue = Nothing
            Me.txtLeaveNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveNameAra, 2)
            Me.txtLeaveNameAra.ComputedValue = False
            Me.txtLeaveNameAra.CustomFormat = Nothing
            Me.txtLeaveNameAra.DataBoundControl = True
            Me.txtLeaveNameAra.EditingMode = False
            Me.txtLeaveNameAra.EndFindValue = Nothing
            Me.txtLeaveNameAra.EnglishControl = Me.txtLeaveName
            Me.txtLeaveNameAra.FieldDescription = Nothing
            Me.txtLeaveNameAra.FieldName = Nothing
            Me.txtLeaveNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveNameAra.FindEnabled = True
            resources.ApplyResources(Me.txtLeaveNameAra, "txtLeaveNameAra")
            Me.txtLeaveNameAra.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveNameAra.LinkedLabel = Nothing
            Me.txtLeaveNameAra.MaximumValue = Nothing
            Me.txtLeaveNameAra.MinimumValue = Nothing
            Me.txtLeaveNameAra.Name = "txtLeaveNameAra"
            Me.txtLeaveNameAra.OldValue = Nothing
            Me.txtLeaveNameAra.ReadOnly = True
            Me.txtLeaveNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveNameAra.Translatable = False
            '
            'txtLeaveName
            '
            Me.txtLeaveName.BackColor = System.Drawing.Color.White
            Me.txtLeaveName.BegFindValue = Nothing
            Me.txtLeaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveName, 2)
            Me.txtLeaveName.ComputedValue = False
            Me.txtLeaveName.CustomFormat = Nothing
            Me.txtLeaveName.DataBoundControl = True
            Me.txtLeaveName.EditingMode = False
            Me.txtLeaveName.EndFindValue = Nothing
            Me.txtLeaveName.FieldDescription = Nothing
            Me.txtLeaveName.FieldName = Nothing
            Me.txtLeaveName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveName.FindEnabled = True
            resources.ApplyResources(Me.txtLeaveName, "txtLeaveName")
            Me.txtLeaveName.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveName.LinkedLabel = Nothing
            Me.txtLeaveName.MaximumValue = Nothing
            Me.txtLeaveName.MinimumValue = Nothing
            Me.txtLeaveName.Name = "txtLeaveName"
            Me.txtLeaveName.OldValue = Nothing
            Me.txtLeaveName.ReadOnly = True
            Me.txtLeaveName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveName.Translatable = False
            Me.txtLeaveName.ValueIsMandatory = True
            '
            'lblNameAra
            '
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblNameAra, 2)
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'lblName
            '
            resources.ApplyResources(Me.lblName, "lblName")
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
            Me.lblName.DisplayOnly = True
            Me.lblName.EditingMode = False
            Me.lblName.Name = "lblName"
            Me.lblName.Translatable = True
            '
            'txtLeaveCode
            '
            Me.txtLeaveCode.BackColor = System.Drawing.Color.White
            Me.txtLeaveCode.BegFindValue = Nothing
            Me.txtLeaveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLeaveCode.ComputedValue = False
            Me.txtLeaveCode.CustomFormat = Nothing
            Me.txtLeaveCode.DataBoundControl = True
            Me.txtLeaveCode.EditingMode = True
            Me.txtLeaveCode.EndFindValue = Nothing
            Me.txtLeaveCode.FieldDescription = Nothing
            Me.txtLeaveCode.FieldName = Nothing
            Me.txtLeaveCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtLeaveCode.FindEnabled = True
            resources.ApplyResources(Me.txtLeaveCode, "txtLeaveCode")
            Me.txtLeaveCode.ForeColor = System.Drawing.Color.Black
            Me.txtLeaveCode.LinkedLabel = Nothing
            Me.txtLeaveCode.MaximumValue = Nothing
            Me.txtLeaveCode.MinimumValue = Nothing
            Me.txtLeaveCode.Name = "txtLeaveCode"
            Me.txtLeaveCode.OldValue = Nothing
            Me.txtLeaveCode.ReadOnly = True
            Me.txtLeaveCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveCode.Translatable = False
            Me.txtLeaveCode.ValueIsMandatory = True
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
            'lblIdNo
            '
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblCode
            '
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
            '
            'LeaveEntryTv
            '
            resources.ApplyResources(Me, "$this")
            Me.Name = "LeaveEntryTv"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
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
        Friend WithEvents lblMaxLimit As CLabel
        Friend WithEvents txtMaxCarryOver As CTextBox
        Friend WithEvents lblMaxCarryOver As CLabel
        Friend WithEvents chkCumulative As CCheckBox
        Friend WithEvents lblCumulative As CLabel
        Friend WithEvents txtPaidPercent As CTextBox
        Friend WithEvents lblPaidPercent As CLabel
        Friend WithEvents txtLeaveAllowed As CTextBox
        Friend WithEvents lblLeaveAllowed As CLabel
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