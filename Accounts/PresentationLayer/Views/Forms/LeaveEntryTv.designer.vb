Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class LeaveEntryTv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LeaveEntryTv))
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHoliday = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkHoliday = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
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
        Me.lblNoMaxLimit = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.chkNoMaxLimit = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
        Me.lblLeaveCycle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.cboLeaveCycle = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
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
        Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"),System.Windows.Forms.ImageListStreamer)
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblLeaveCycle, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHoliday, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chkHoliday, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNotes, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNotes, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMaxLimit, 2, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMaxLimit, 2, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMaxCarryOver, 2, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMaxCarryOver, 2, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.chkCumulative, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCumulative, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPaidPercent, 2, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPaidPercent, 2, 8)
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
        Me.TableLayoutPanel1.Controls.Add(Me.lblNoMaxLimit, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.chkNoMaxLimit, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.cboLeaveCycle, 0, 11)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'lblHoliday
        '
        resources.ApplyResources(Me.lblHoliday, "lblHoliday")
        Me.lblHoliday.DisplayOnly = true
        Me.lblHoliday.EditingMode = false
        Me.lblHoliday.Name = "lblHoliday"
        Me.lblHoliday.Translatable = true
        '
        'chkHoliday
        '
        resources.ApplyResources(Me.chkHoliday, "chkHoliday")
        Me.chkHoliday.BackColor = System.Drawing.Color.White
        Me.chkHoliday.BegFindValue = Nothing
        Me.chkHoliday.DisplayOnly = false
        Me.chkHoliday.EditingMode = true
        Me.chkHoliday.EndFindValue = Nothing
        Me.chkHoliday.FieldDescription = Nothing
        Me.chkHoliday.FieldName = Nothing
        Me.chkHoliday.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkHoliday.FindEnabled = false
        Me.chkHoliday.FlatAppearance.BorderSize = 0
        Me.chkHoliday.ForeColor = System.Drawing.Color.Black
        Me.chkHoliday.IFindableControl_FindEnabled = false
        Me.chkHoliday.IgnoreCase = false
        Me.chkHoliday.LinkedLabel = Nothing
        Me.chkHoliday.Name = "chkHoliday"
        Me.chkHoliday.NoLabel = true
        Me.chkHoliday.OldValue = Nothing
        Me.chkHoliday.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkHoliday.Translatable = false
        Me.chkHoliday.UseVisualStyleBackColor = false
        '
        'lblNotes
        '
        resources.ApplyResources(Me.lblNotes, "lblNotes")
        Me.lblNotes.DisplayOnly = true
        Me.lblNotes.EditingMode = false
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Translatable = true
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.White
        Me.txtNotes.BegFindValue = Nothing
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 3)
        Me.txtNotes.ComputedValue = false
        Me.txtNotes.CustomFormat = Nothing
        Me.txtNotes.DataBoundControl = true
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.EditingMode = false
        Me.txtNotes.EndFindValue = Nothing
        Me.txtNotes.FieldDescription = Nothing
        Me.txtNotes.FieldName = Nothing
        Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtNotes.FindEnabled = true
        Me.txtNotes.ForeColor = System.Drawing.Color.Black
        Me.txtNotes.LinkedLabel = Nothing
        Me.txtNotes.MaximumValue = Nothing
        Me.txtNotes.MinimumValue = Nothing
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.OldValue = Nothing
        Me.txtNotes.ReadOnly = true
        Me.txtNotes.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtNotes.Translatable = false
        Me.txtNotes.ValueIsMandatory = true
        '
        'txtMaxLimit
        '
        Me.txtMaxLimit.BackColor = System.Drawing.Color.White
        Me.txtMaxLimit.BegFindValue = Nothing
        Me.txtMaxLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxLimit.ComputedValue = false
        Me.txtMaxLimit.CustomFormat = Nothing
        Me.txtMaxLimit.DataBoundControl = true
        Me.txtMaxLimit.EditingMode = true
        Me.txtMaxLimit.EndFindValue = Nothing
        Me.txtMaxLimit.FieldDescription = Nothing
        Me.txtMaxLimit.FieldName = Nothing
        Me.txtMaxLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtMaxLimit.FindEnabled = true
        resources.ApplyResources(Me.txtMaxLimit, "txtMaxLimit")
        Me.txtMaxLimit.ForeColor = System.Drawing.Color.Black
        Me.txtMaxLimit.LinkedLabel = Nothing
        Me.txtMaxLimit.MaximumValue = Nothing
        Me.txtMaxLimit.MinimumValue = Nothing
        Me.txtMaxLimit.Name = "txtMaxLimit"
        Me.txtMaxLimit.OldValue = Nothing
        Me.txtMaxLimit.ReadOnly = true
        Me.txtMaxLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtMaxLimit.Translatable = false
        Me.txtMaxLimit.ValueIsMandatory = true
        '
        'lblMaxLimit
        '
        resources.ApplyResources(Me.lblMaxLimit, "lblMaxLimit")
        Me.lblMaxLimit.DisplayOnly = true
        Me.lblMaxLimit.EditingMode = false
        Me.lblMaxLimit.Name = "lblMaxLimit"
        Me.lblMaxLimit.Translatable = true
        '
        'txtMaxCarryOver
        '
        Me.txtMaxCarryOver.BackColor = System.Drawing.Color.White
        Me.txtMaxCarryOver.BegFindValue = Nothing
        Me.txtMaxCarryOver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxCarryOver.ComputedValue = false
        Me.txtMaxCarryOver.CustomFormat = Nothing
        Me.txtMaxCarryOver.DataBoundControl = true
        Me.txtMaxCarryOver.EditingMode = true
        Me.txtMaxCarryOver.EndFindValue = Nothing
        Me.txtMaxCarryOver.FieldDescription = Nothing
        Me.txtMaxCarryOver.FieldName = Nothing
        Me.txtMaxCarryOver.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtMaxCarryOver.FindEnabled = true
        resources.ApplyResources(Me.txtMaxCarryOver, "txtMaxCarryOver")
        Me.txtMaxCarryOver.ForeColor = System.Drawing.Color.Black
        Me.txtMaxCarryOver.LinkedLabel = Nothing
        Me.txtMaxCarryOver.MaximumValue = Nothing
        Me.txtMaxCarryOver.MinimumValue = Nothing
        Me.txtMaxCarryOver.Name = "txtMaxCarryOver"
        Me.txtMaxCarryOver.OldValue = Nothing
        Me.txtMaxCarryOver.ReadOnly = true
        Me.txtMaxCarryOver.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtMaxCarryOver.Translatable = false
        Me.txtMaxCarryOver.ValueIsMandatory = true
        '
        'lblMaxCarryOver
        '
        resources.ApplyResources(Me.lblMaxCarryOver, "lblMaxCarryOver")
        Me.lblMaxCarryOver.DisplayOnly = true
        Me.lblMaxCarryOver.EditingMode = false
        Me.lblMaxCarryOver.Name = "lblMaxCarryOver"
        Me.lblMaxCarryOver.Translatable = true
        '
        'chkCumulative
        '
        resources.ApplyResources(Me.chkCumulative, "chkCumulative")
        Me.chkCumulative.BackColor = System.Drawing.Color.White
        Me.chkCumulative.BegFindValue = Nothing
        Me.chkCumulative.DisplayOnly = false
        Me.chkCumulative.EditingMode = true
        Me.chkCumulative.EndFindValue = Nothing
        Me.chkCumulative.FieldDescription = Nothing
        Me.chkCumulative.FieldName = Nothing
        Me.chkCumulative.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkCumulative.FindEnabled = false
        Me.chkCumulative.FlatAppearance.BorderSize = 0
        Me.chkCumulative.ForeColor = System.Drawing.Color.Black
        Me.chkCumulative.IFindableControl_FindEnabled = false
        Me.chkCumulative.IgnoreCase = false
        Me.chkCumulative.LinkedLabel = Nothing
        Me.chkCumulative.Name = "chkCumulative"
        Me.chkCumulative.NoLabel = true
        Me.chkCumulative.OldValue = Nothing
        Me.chkCumulative.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkCumulative.Translatable = false
        Me.chkCumulative.UseVisualStyleBackColor = false
        '
        'lblCumulative
        '
        resources.ApplyResources(Me.lblCumulative, "lblCumulative")
        Me.lblCumulative.DisplayOnly = true
        Me.lblCumulative.EditingMode = false
        Me.lblCumulative.Name = "lblCumulative"
        Me.lblCumulative.Translatable = true
        '
        'txtPaidPercent
        '
        Me.txtPaidPercent.BackColor = System.Drawing.Color.White
        Me.txtPaidPercent.BegFindValue = Nothing
        Me.txtPaidPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaidPercent.ComputedValue = false
        Me.txtPaidPercent.CustomFormat = Nothing
        Me.txtPaidPercent.DataBoundControl = true
        Me.txtPaidPercent.EditingMode = true
        Me.txtPaidPercent.EndFindValue = Nothing
        Me.txtPaidPercent.FieldDescription = Nothing
        Me.txtPaidPercent.FieldName = Nothing
        Me.txtPaidPercent.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtPaidPercent.FindEnabled = true
        resources.ApplyResources(Me.txtPaidPercent, "txtPaidPercent")
        Me.txtPaidPercent.ForeColor = System.Drawing.Color.Black
        Me.txtPaidPercent.LinkedLabel = Nothing
        Me.txtPaidPercent.MaximumValue = Nothing
        Me.txtPaidPercent.MinimumValue = Nothing
        Me.txtPaidPercent.Name = "txtPaidPercent"
        Me.txtPaidPercent.OldValue = Nothing
        Me.txtPaidPercent.ReadOnly = true
        Me.txtPaidPercent.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtPaidPercent.Translatable = false
        Me.txtPaidPercent.ValueIsMandatory = true
        '
        'lblPaidPercent
        '
        resources.ApplyResources(Me.lblPaidPercent, "lblPaidPercent")
        Me.lblPaidPercent.DisplayOnly = true
        Me.lblPaidPercent.EditingMode = false
        Me.lblPaidPercent.Name = "lblPaidPercent"
        Me.lblPaidPercent.Translatable = true
        '
        'txtLeaveAllowed
        '
        Me.txtLeaveAllowed.BackColor = System.Drawing.Color.White
        Me.txtLeaveAllowed.BegFindValue = Nothing
        Me.txtLeaveAllowed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaveAllowed.ComputedValue = false
        Me.txtLeaveAllowed.CustomFormat = Nothing
        Me.txtLeaveAllowed.DataBoundControl = true
        Me.txtLeaveAllowed.EditingMode = true
        Me.txtLeaveAllowed.EndFindValue = Nothing
        Me.txtLeaveAllowed.FieldDescription = Nothing
        Me.txtLeaveAllowed.FieldName = Nothing
        Me.txtLeaveAllowed.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLeaveAllowed.FindEnabled = true
        resources.ApplyResources(Me.txtLeaveAllowed, "txtLeaveAllowed")
        Me.txtLeaveAllowed.ForeColor = System.Drawing.Color.Black
        Me.txtLeaveAllowed.LinkedLabel = Nothing
        Me.txtLeaveAllowed.MaximumValue = Nothing
        Me.txtLeaveAllowed.MinimumValue = Nothing
        Me.txtLeaveAllowed.Name = "txtLeaveAllowed"
        Me.txtLeaveAllowed.OldValue = Nothing
        Me.txtLeaveAllowed.ReadOnly = true
        Me.txtLeaveAllowed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLeaveAllowed.Translatable = false
        Me.txtLeaveAllowed.ValueIsMandatory = true
        '
        'lblLeaveAllowed
        '
        resources.ApplyResources(Me.lblLeaveAllowed, "lblLeaveAllowed")
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblLeaveAllowed, 2)
        Me.lblLeaveAllowed.DisplayOnly = true
        Me.lblLeaveAllowed.EditingMode = false
        Me.lblLeaveAllowed.Name = "lblLeaveAllowed"
        Me.lblLeaveAllowed.Translatable = true
        '
        'txtLeaveNameAra
        '
        Me.txtLeaveNameAra.BackColor = System.Drawing.Color.White
        Me.txtLeaveNameAra.BegFindValue = Nothing
        Me.txtLeaveNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveNameAra, 3)
        Me.txtLeaveNameAra.ComputedValue = false
        Me.txtLeaveNameAra.CustomFormat = Nothing
        Me.txtLeaveNameAra.DataBoundControl = true
        Me.txtLeaveNameAra.EditingMode = false
        Me.txtLeaveNameAra.EndFindValue = Nothing
        Me.txtLeaveNameAra.EnglishControl = Me.txtLeaveName
        Me.txtLeaveNameAra.FieldDescription = Nothing
        Me.txtLeaveNameAra.FieldName = Nothing
        Me.txtLeaveNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLeaveNameAra.FindEnabled = true
        resources.ApplyResources(Me.txtLeaveNameAra, "txtLeaveNameAra")
        Me.txtLeaveNameAra.ForeColor = System.Drawing.Color.Black
        Me.txtLeaveNameAra.LinkedLabel = Nothing
        Me.txtLeaveNameAra.MaximumValue = Nothing
        Me.txtLeaveNameAra.MinimumValue = Nothing
        Me.txtLeaveNameAra.Name = "txtLeaveNameAra"
        Me.txtLeaveNameAra.OldValue = Nothing
        Me.txtLeaveNameAra.ReadOnly = true
        Me.txtLeaveNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLeaveNameAra.Translatable = false
        '
        'txtLeaveName
        '
        Me.txtLeaveName.BackColor = System.Drawing.Color.White
        Me.txtLeaveName.BegFindValue = Nothing
        Me.txtLeaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveName, 3)
        Me.txtLeaveName.ComputedValue = false
        Me.txtLeaveName.CustomFormat = Nothing
        Me.txtLeaveName.DataBoundControl = true
        Me.txtLeaveName.EditingMode = false
        Me.txtLeaveName.EndFindValue = Nothing
        Me.txtLeaveName.FieldDescription = Nothing
        Me.txtLeaveName.FieldName = Nothing
        Me.txtLeaveName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLeaveName.FindEnabled = true
        resources.ApplyResources(Me.txtLeaveName, "txtLeaveName")
        Me.txtLeaveName.ForeColor = System.Drawing.Color.Black
        Me.txtLeaveName.LinkedLabel = Nothing
        Me.txtLeaveName.MaximumValue = Nothing
        Me.txtLeaveName.MinimumValue = Nothing
        Me.txtLeaveName.Name = "txtLeaveName"
        Me.txtLeaveName.OldValue = Nothing
        Me.txtLeaveName.ReadOnly = true
        Me.txtLeaveName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLeaveName.Translatable = false
        Me.txtLeaveName.ValueIsMandatory = true
        '
        'lblNameAra
        '
        resources.ApplyResources(Me.lblNameAra, "lblNameAra")
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblNameAra, 2)
        Me.lblNameAra.DisplayOnly = true
        Me.lblNameAra.EditingMode = false
        Me.lblNameAra.Name = "lblNameAra"
        Me.lblNameAra.Translatable = true
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblName, 2)
        Me.lblName.DisplayOnly = true
        Me.lblName.EditingMode = false
        Me.lblName.Name = "lblName"
        Me.lblName.Translatable = true
        '
        'txtLeaveCode
        '
        Me.txtLeaveCode.BackColor = System.Drawing.Color.White
        Me.txtLeaveCode.BegFindValue = Nothing
        Me.txtLeaveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLeaveCode.ComputedValue = false
        Me.txtLeaveCode.CustomFormat = Nothing
        Me.txtLeaveCode.DataBoundControl = true
        Me.txtLeaveCode.EditingMode = true
        Me.txtLeaveCode.EndFindValue = Nothing
        Me.txtLeaveCode.FieldDescription = Nothing
        Me.txtLeaveCode.FieldName = Nothing
        Me.txtLeaveCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.txtLeaveCode.FindEnabled = true
        resources.ApplyResources(Me.txtLeaveCode, "txtLeaveCode")
        Me.txtLeaveCode.ForeColor = System.Drawing.Color.Black
        Me.txtLeaveCode.LinkedLabel = Nothing
        Me.txtLeaveCode.MaximumValue = Nothing
        Me.txtLeaveCode.MinimumValue = Nothing
        Me.txtLeaveCode.Name = "txtLeaveCode"
        Me.txtLeaveCode.OldValue = Nothing
        Me.txtLeaveCode.ReadOnly = true
        Me.txtLeaveCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.txtLeaveCode.Translatable = false
        Me.txtLeaveCode.ValueIsMandatory = true
        '
        'TxtIdNo
        '
        Me.TxtIdNo.BackColor = System.Drawing.Color.White
        Me.TxtIdNo.BegFindValue = Nothing
        Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdNo.ComputedValue = false
        Me.TxtIdNo.CustomFormat = Nothing
        Me.TxtIdNo.DataBoundControl = true
        Me.TxtIdNo.DisplayOnly = true
        Me.TxtIdNo.EditingMode = true
        Me.TxtIdNo.EndFindValue = Nothing
        Me.TxtIdNo.FieldDescription = Nothing
        Me.TxtIdNo.FieldName = Nothing
        Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.TxtIdNo.FindEnabled = true
        resources.ApplyResources(Me.TxtIdNo, "TxtIdNo")
        Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIdNo.LinkedLabel = Nothing
        Me.TxtIdNo.MaximumValue = Nothing
        Me.TxtIdNo.MinimumValue = Nothing
        Me.TxtIdNo.Name = "TxtIdNo"
        Me.TxtIdNo.OldValue = Nothing
        Me.TxtIdNo.ReadOnly = true
        Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.TxtIdNo.TabStop = false
        Me.TxtIdNo.Translatable = false
        Me.TxtIdNo.ValueIsNumeric = true
        '
        'lblIdNo
        '
        resources.ApplyResources(Me.lblIdNo, "lblIdNo")
        Me.lblIdNo.DisplayOnly = true
        Me.lblIdNo.EditingMode = false
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Translatable = true
        '
        'lblCode
        '
        resources.ApplyResources(Me.lblCode, "lblCode")
        Me.lblCode.DisplayOnly = true
        Me.lblCode.EditingMode = false
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Translatable = true
        '
        'lblNoMaxLimit
        '
        resources.ApplyResources(Me.lblNoMaxLimit, "lblNoMaxLimit")
        Me.lblNoMaxLimit.DisplayOnly = true
        Me.lblNoMaxLimit.EditingMode = false
        Me.lblNoMaxLimit.Name = "lblNoMaxLimit"
        Me.lblNoMaxLimit.Translatable = true
        '
        'chkNoMaxLimit
        '
        resources.ApplyResources(Me.chkNoMaxLimit, "chkNoMaxLimit")
        Me.chkNoMaxLimit.BackColor = System.Drawing.Color.White
        Me.chkNoMaxLimit.BegFindValue = Nothing
        Me.chkNoMaxLimit.DisplayOnly = false
        Me.chkNoMaxLimit.EditingMode = true
        Me.chkNoMaxLimit.EndFindValue = Nothing
        Me.chkNoMaxLimit.FieldDescription = Nothing
        Me.chkNoMaxLimit.FieldName = Nothing
        Me.chkNoMaxLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.chkNoMaxLimit.FindEnabled = false
        Me.chkNoMaxLimit.FlatAppearance.BorderSize = 0
        Me.chkNoMaxLimit.ForeColor = System.Drawing.Color.Black
        Me.chkNoMaxLimit.IFindableControl_FindEnabled = false
        Me.chkNoMaxLimit.IgnoreCase = false
        Me.chkNoMaxLimit.LinkedLabel = Nothing
        Me.chkNoMaxLimit.Name = "chkNoMaxLimit"
        Me.chkNoMaxLimit.NoLabel = true
        Me.chkNoMaxLimit.OldValue = Nothing
        Me.chkNoMaxLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
        Me.chkNoMaxLimit.Translatable = false
        Me.chkNoMaxLimit.UseVisualStyleBackColor = false
        '
        'lblLeaveCycle
        '
        resources.ApplyResources(Me.lblLeaveCycle, "lblLeaveCycle")
        Me.lblLeaveCycle.DisplayOnly = true
        Me.lblLeaveCycle.EditingMode = false
        Me.lblLeaveCycle.Name = "lblLeaveCycle"
        Me.lblLeaveCycle.Translatable = true
        '
        'cboLeaveCycle
        '
        Me.cboLeaveCycle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cboLeaveCycle.BegFindValue = Nothing
        Me.cboLeaveCycle.ChangingSearchValueOnly = false
        Me.cboLeaveCycle.CurrentSearchTerm = ""
        Me.cboLeaveCycle.DefaultValue = Nothing
        Me.cboLeaveCycle.DisplayMember = "Name"
        Me.cboLeaveCycle.EditingMode = true
        Me.cboLeaveCycle.EndFindValue = Nothing
        Me.cboLeaveCycle.FieldDescription = Nothing
        Me.cboLeaveCycle.FieldName = Nothing
        Me.cboLeaveCycle.FilterRule = Nothing
        Me.cboLeaveCycle.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
        Me.cboLeaveCycle.FindEnabled = false
        resources.ApplyResources(Me.cboLeaveCycle, "cboLeaveCycle")
        Me.cboLeaveCycle.FormattingEnabled = true
        Me.cboLeaveCycle.HideWhenNotEditingOrAdding = false
        Me.cboLeaveCycle.IgnoreCase = false
        Me.cboLeaveCycle.LinkedLabel = Nothing
        Me.cboLeaveCycle.Name = "cboLeaveCycle"
        Me.cboLeaveCycle.OldValue = 0
        Me.cboLeaveCycle.OriginalDataSource = Nothing
        Me.cboLeaveCycle.OriginalList = Nothing
        Me.cboLeaveCycle.OverrideDropDownStyleList = false
        Me.cboLeaveCycle.PreviousSearchTerm = Nothing
        Me.cboLeaveCycle.PropertySelector = Nothing
        Me.cboLeaveCycle.ReadOnlyCombo = false
        Me.cboLeaveCycle.SuggestBoxHeight = 200
        Me.cboLeaveCycle.SuggestListOrderRule = Nothing
        Me.cboLeaveCycle.TextToSearch = Nothing
        Me.cboLeaveCycle.Translatable = false
        Me.cboLeaveCycle.ValueIsMandatory = false
        Me.cboLeaveCycle.ValueIsNullable = false
        Me.cboLeaveCycle.ValueIsNumeric = false
        Me.cboLeaveCycle.ValueMember = "IdNo"
        '
        'LeaveEntryTv
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "LeaveEntryTv"
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

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
        Friend WithEvents lblHoliday As CLabel
        Friend WithEvents chkHoliday As CCheckBox
        Friend WithEvents lblNoMaxLimit As CLabel
        Friend WithEvents chkNoMaxLimit As CCheckBox
        Friend WithEvents lblLeaveCycle As CLabel
        Friend WithEvents cboLeaveCycle As CaComboBox
    End Class
End Namespace