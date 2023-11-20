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
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.chkEarnable = New AATM.Libraries.CBaseControlsLibrary.CCheckBox()
            Me.lblLeaveCycle = New AATM.Libraries.CBaseControlsLibrary.CLabel()
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
            Me.cboLeaveCycle = New AATM.Libraries.CBaseControlsLibrary.CaComboBox()
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
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = ""
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
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel1, 1, 12)
            Me.TableLayoutPanel1.Controls.Add(Me.chkEarnable, 1, 13)
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
            'CLabel1
            '
            resources.ApplyResources(Me.CLabel1, "CLabel1")
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Translatable = True
            '
            'chkEarnable
            '
            resources.ApplyResources(Me.chkEarnable, "chkEarnable")
            Me.chkEarnable.BackColor = System.Drawing.Color.White
            Me.chkEarnable.BegFindValue = Nothing
            Me.chkEarnable.DisplayOnly = False
            Me.chkEarnable.EditingMode = True
            Me.chkEarnable.EndFindValue = Nothing
            Me.chkEarnable.FieldDescription = Nothing
            Me.chkEarnable.FieldName = Nothing
            Me.chkEarnable.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkEarnable.FindEnabled = False
            Me.chkEarnable.FlatAppearance.BorderSize = 0
            Me.chkEarnable.ForeColor = System.Drawing.Color.Black
            Me.chkEarnable.IFindableControl_FindEnabled = False
            Me.chkEarnable.IgnoreCase = False
            Me.chkEarnable.LinkedLabel = Nothing
            Me.chkEarnable.Name = "chkEarnable"
            Me.chkEarnable.NoLabel = True
            Me.chkEarnable.OldValue = Nothing
            Me.chkEarnable.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkEarnable.Translatable = False
            Me.chkEarnable.UseVisualStyleBackColor = False
            '
            'lblLeaveCycle
            '
            resources.ApplyResources(Me.lblLeaveCycle, "lblLeaveCycle")
            Me.lblLeaveCycle.BackColor = System.Drawing.Color.Transparent
            Me.lblLeaveCycle.DisplayOnly = True
            Me.lblLeaveCycle.EditingMode = False
            Me.lblLeaveCycle.Name = "lblLeaveCycle"
            Me.lblLeaveCycle.Translatable = True
            '
            'lblHoliday
            '
            resources.ApplyResources(Me.lblHoliday, "lblHoliday")
            Me.lblHoliday.BackColor = System.Drawing.Color.Transparent
            Me.lblHoliday.DisplayOnly = True
            Me.lblHoliday.EditingMode = False
            Me.lblHoliday.Name = "lblHoliday"
            Me.lblHoliday.Translatable = True
            '
            'chkHoliday
            '
            resources.ApplyResources(Me.chkHoliday, "chkHoliday")
            Me.chkHoliday.BackColor = System.Drawing.Color.White
            Me.chkHoliday.BegFindValue = Nothing
            Me.chkHoliday.DisplayOnly = False
            Me.chkHoliday.EditingMode = True
            Me.chkHoliday.EndFindValue = Nothing
            Me.chkHoliday.FieldDescription = Nothing
            Me.chkHoliday.FieldName = Nothing
            Me.chkHoliday.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkHoliday.FindEnabled = False
            Me.chkHoliday.FlatAppearance.BorderSize = 0
            Me.chkHoliday.ForeColor = System.Drawing.Color.Black
            Me.chkHoliday.IFindableControl_FindEnabled = False
            Me.chkHoliday.IgnoreCase = False
            Me.chkHoliday.LinkedLabel = Nothing
            Me.chkHoliday.Name = "chkHoliday"
            Me.chkHoliday.NoLabel = True
            Me.chkHoliday.OldValue = Nothing
            Me.chkHoliday.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkHoliday.Translatable = False
            Me.chkHoliday.UseVisualStyleBackColor = False
            '
            'lblNotes
            '
            resources.ApplyResources(Me.lblNotes, "lblNotes")
            Me.lblNotes.BackColor = System.Drawing.Color.Transparent
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtNotes, 3)
            Me.txtNotes.ComputedValue = False
            Me.txtNotes.CustomFormat = Nothing
            Me.txtNotes.DataBoundControl = True
            resources.ApplyResources(Me.txtNotes, "txtNotes")
            Me.txtNotes.EditingMode = False
            Me.txtNotes.EndFindValue = Nothing
            Me.txtNotes.FieldDescription = Nothing
            Me.txtNotes.FieldName = Nothing
            Me.txtNotes.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtNotes.FindEnabled = True
            Me.txtNotes.ForeColor = System.Drawing.Color.Black
            Me.txtNotes.LinkedLabel = Nothing
            Me.txtNotes.MaximumValue = Nothing
            Me.txtNotes.MinimumValue = Nothing
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.OldValue = Nothing
            Me.txtNotes.OverrideMaxLength = 0
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
            Me.txtMaxLimit.OverrideMaxLength = 0
            Me.txtMaxLimit.ReadOnly = True
            Me.txtMaxLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMaxLimit.Translatable = False
            Me.txtMaxLimit.ValueIsMandatory = True
            '
            'lblMaxLimit
            '
            resources.ApplyResources(Me.lblMaxLimit, "lblMaxLimit")
            Me.lblMaxLimit.BackColor = System.Drawing.Color.Transparent
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
            Me.txtMaxCarryOver.OverrideMaxLength = 0
            Me.txtMaxCarryOver.ReadOnly = True
            Me.txtMaxCarryOver.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtMaxCarryOver.Translatable = False
            Me.txtMaxCarryOver.ValueIsMandatory = True
            '
            'lblMaxCarryOver
            '
            resources.ApplyResources(Me.lblMaxCarryOver, "lblMaxCarryOver")
            Me.lblMaxCarryOver.BackColor = System.Drawing.Color.Transparent
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
            Me.lblCumulative.BackColor = System.Drawing.Color.Transparent
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
            Me.txtPaidPercent.OverrideMaxLength = 0
            Me.txtPaidPercent.ReadOnly = True
            Me.txtPaidPercent.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPaidPercent.Translatable = False
            Me.txtPaidPercent.ValueIsMandatory = True
            '
            'lblPaidPercent
            '
            resources.ApplyResources(Me.lblPaidPercent, "lblPaidPercent")
            Me.lblPaidPercent.BackColor = System.Drawing.Color.Transparent
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
            Me.txtLeaveAllowed.OverrideMaxLength = 0
            Me.txtLeaveAllowed.ReadOnly = True
            Me.txtLeaveAllowed.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveAllowed.Translatable = False
            Me.txtLeaveAllowed.ValueIsMandatory = True
            '
            'lblLeaveAllowed
            '
            resources.ApplyResources(Me.lblLeaveAllowed, "lblLeaveAllowed")
            Me.lblLeaveAllowed.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblLeaveAllowed, 2)
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
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveNameAra, 3)
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
            Me.txtLeaveNameAra.OverrideMaxLength = 0
            Me.txtLeaveNameAra.ReadOnly = True
            Me.txtLeaveNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveNameAra.Translatable = False
            '
            'txtLeaveName
            '
            Me.txtLeaveName.BackColor = System.Drawing.Color.White
            Me.txtLeaveName.BegFindValue = Nothing
            Me.txtLeaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TableLayoutPanel1.SetColumnSpan(Me.txtLeaveName, 3)
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
            Me.txtLeaveName.OverrideMaxLength = 0
            Me.txtLeaveName.ReadOnly = True
            Me.txtLeaveName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtLeaveName.Translatable = False
            Me.txtLeaveName.ValueIsMandatory = True
            '
            'lblNameAra
            '
            resources.ApplyResources(Me.lblNameAra, "lblNameAra")
            Me.lblNameAra.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.lblNameAra, 2)
            Me.lblNameAra.DisplayOnly = True
            Me.lblNameAra.EditingMode = False
            Me.lblNameAra.Name = "lblNameAra"
            Me.lblNameAra.Translatable = True
            '
            'lblName
            '
            resources.ApplyResources(Me.lblName, "lblName")
            Me.lblName.BackColor = System.Drawing.Color.Transparent
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
            Me.txtLeaveCode.OverrideMaxLength = 0
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
            Me.TxtIdNo.OverrideMaxLength = 0
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.TabStop = False
            Me.TxtIdNo.Translatable = False
            Me.TxtIdNo.ValueIsNumeric = True
            '
            'lblIdNo
            '
            resources.ApplyResources(Me.lblIdNo, "lblIdNo")
            Me.lblIdNo.BackColor = System.Drawing.Color.Transparent
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Translatable = True
            '
            'lblCode
            '
            resources.ApplyResources(Me.lblCode, "lblCode")
            Me.lblCode.BackColor = System.Drawing.Color.Transparent
            Me.lblCode.DisplayOnly = True
            Me.lblCode.EditingMode = False
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Translatable = True
            '
            'lblNoMaxLimit
            '
            resources.ApplyResources(Me.lblNoMaxLimit, "lblNoMaxLimit")
            Me.lblNoMaxLimit.BackColor = System.Drawing.Color.Transparent
            Me.lblNoMaxLimit.DisplayOnly = True
            Me.lblNoMaxLimit.EditingMode = False
            Me.lblNoMaxLimit.Name = "lblNoMaxLimit"
            Me.lblNoMaxLimit.Translatable = True
            '
            'chkNoMaxLimit
            '
            resources.ApplyResources(Me.chkNoMaxLimit, "chkNoMaxLimit")
            Me.chkNoMaxLimit.BackColor = System.Drawing.Color.White
            Me.chkNoMaxLimit.BegFindValue = Nothing
            Me.chkNoMaxLimit.DisplayOnly = False
            Me.chkNoMaxLimit.EditingMode = True
            Me.chkNoMaxLimit.EndFindValue = Nothing
            Me.chkNoMaxLimit.FieldDescription = Nothing
            Me.chkNoMaxLimit.FieldName = Nothing
            Me.chkNoMaxLimit.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkNoMaxLimit.FindEnabled = False
            Me.chkNoMaxLimit.FlatAppearance.BorderSize = 0
            Me.chkNoMaxLimit.ForeColor = System.Drawing.Color.Black
            Me.chkNoMaxLimit.IFindableControl_FindEnabled = False
            Me.chkNoMaxLimit.IgnoreCase = False
            Me.chkNoMaxLimit.LinkedLabel = Nothing
            Me.chkNoMaxLimit.Name = "chkNoMaxLimit"
            Me.chkNoMaxLimit.NoLabel = True
            Me.chkNoMaxLimit.OldValue = Nothing
            Me.chkNoMaxLimit.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkNoMaxLimit.Translatable = False
            Me.chkNoMaxLimit.UseVisualStyleBackColor = False
            '
            'cboLeaveCycle
            '
            Me.cboLeaveCycle.BackColor = System.Drawing.Color.White
            Me.cboLeaveCycle.BegFindValue = Nothing
            Me.cboLeaveCycle.ChangingSearchValueOnly = False
            Me.cboLeaveCycle.CurrentSearchTerm = ""
            Me.cboLeaveCycle.DataValue = Nothing
            Me.cboLeaveCycle.DefaultValue = Nothing
            Me.cboLeaveCycle.DisplayMember = "Name"
            resources.ApplyResources(Me.cboLeaveCycle, "cboLeaveCycle")
            Me.cboLeaveCycle.Editable = True
            Me.cboLeaveCycle.EditingMode = True
            Me.cboLeaveCycle.EndFindValue = Nothing
            Me.cboLeaveCycle.FieldDescription = Nothing
            Me.cboLeaveCycle.FieldName = Nothing
            Me.cboLeaveCycle.FilterRule = Nothing
            Me.cboLeaveCycle.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboLeaveCycle.FindEnabled = False
            Me.cboLeaveCycle.ForeColor = System.Drawing.Color.Black
            Me.cboLeaveCycle.FormattingEnabled = True
            Me.cboLeaveCycle.HideWhenNotEditingOrAdding = False
            Me.cboLeaveCycle.IgnoreCase = False
            Me.cboLeaveCycle.LimitToList = False
            Me.cboLeaveCycle.LinkedLabel = Nothing
            Me.cboLeaveCycle.Name = "cboLeaveCycle"
            Me.cboLeaveCycle.OldValue = 0
            Me.cboLeaveCycle.OriginalDataSource = Nothing
            Me.cboLeaveCycle.OriginalList = Nothing
            Me.cboLeaveCycle.OverrideDropDownStyleList = False
            Me.cboLeaveCycle.PreviousSearchTerm = Nothing
            Me.cboLeaveCycle.PropertySelector = Nothing
            Me.cboLeaveCycle.ReadOnlyCombo = False
            Me.cboLeaveCycle.SuggestBoxHeight = 200
            Me.cboLeaveCycle.SuggestListOrderRule = Nothing
            Me.cboLeaveCycle.TextToSearch = Nothing
            Me.cboLeaveCycle.Translatable = False
            Me.cboLeaveCycle.ValueIsMandatory = False
            Me.cboLeaveCycle.ValueIsNullable = False
            Me.cboLeaveCycle.ValueIsNumeric = False
            Me.cboLeaveCycle.ValueMember = "IdNo"
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
        Friend WithEvents chkEarnable As CCheckBox
        Friend WithEvents CLabel1 As CLabel
    End Class
End Namespace