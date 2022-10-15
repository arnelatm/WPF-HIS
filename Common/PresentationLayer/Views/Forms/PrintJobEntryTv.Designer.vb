Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PrintJobEntryTv
        Inherits CFormEntryTv

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintJobEntryTv))
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPrintJobCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPrintJobCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPrintJobName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPrintJobName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblPrintJobNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtPrintJobNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.LblComputerName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBoxArabic1 = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.LblPaperSource = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBoxArabic2 = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.LblPaperSize = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBoxArabic3 = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.LblPaperOrientation = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.CTextBoxArabic4 = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
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
            Me.SplitContainer1.Size = New System.Drawing.Size(687, 312)
            Me.SplitContainer1.SplitterDistance = 228
            '
            'FormTreeView
            '
            Me.FormTreeView.LineColor = System.Drawing.Color.Black
            Me.FormTreeView.Size = New System.Drawing.Size(228, 312)
            '
            'ImageListTreeView
            '
            Me.ImageListTreeView.ImageStream = CType(resources.GetObject("ImageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.ImageListTreeView.Images.SetKeyName(0, "openbriefcase.png")
            Me.ImageListTreeView.Images.SetKeyName(1, "TreeNode.ico")
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSize = True
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblPrintJobCode)
            Me.floDataDisplay.Controls.Add(Me.txtPrintJobCode)
            Me.floDataDisplay.Controls.Add(Me.lblPrintJobName)
            Me.floDataDisplay.Controls.Add(Me.txtPrintJobName)
            Me.floDataDisplay.Controls.Add(Me.lblPrintJobNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtPrintJobNameAra)
            Me.floDataDisplay.Controls.Add(Me.LblComputerName)
            Me.floDataDisplay.Controls.Add(Me.CTextBoxArabic1)
            Me.floDataDisplay.Controls.Add(Me.LblPaperSource)
            Me.floDataDisplay.Controls.Add(Me.CTextBoxArabic2)
            Me.floDataDisplay.Controls.Add(Me.LblPaperSize)
            Me.floDataDisplay.Controls.Add(Me.CTextBoxArabic3)
            Me.floDataDisplay.Controls.Add(Me.LblPaperOrientation)
            Me.floDataDisplay.Controls.Add(Me.CTextBoxArabic4)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill
            Me.floDataDisplay.Location = New System.Drawing.Point(0, 0)
            Me.floDataDisplay.MinimumSize = New System.Drawing.Size(440, 300)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(449, 312)
            Me.floDataDisplay.TabIndex = 148
            '
            'lblIdNo
            '
            Me.lblIdNo.DisplayOnly = True
            Me.lblIdNo.EditingMode = False
            Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIdNo.Location = New System.Drawing.Point(11, 11)
            Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(184, 23)
            Me.lblIdNo.TabIndex = 150
            Me.lblIdNo.Text = "Print Job ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblIdNo.Translatable = True
            '
            'TxtIdNo
            '
            Me.TxtIdNo.BackColor = System.Drawing.Color.White
            Me.TxtIdNo.BegFindValue = Nothing
            Me.TxtIdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtIdNo.ComputedValue = False
            Me.TxtIdNo.CustomFormat = Nothing
            Me.TxtIdNo.DataBoundControl = True
            Me.TxtIdNo.EditingMode = True
            Me.TxtIdNo.EndFindValue = Nothing
            Me.TxtIdNo.FieldDescription = Nothing
            Me.TxtIdNo.FieldName = Nothing
            Me.TxtIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.TxtIdNo.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.TxtIdNo, True)
            Me.TxtIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtIdNo.ForeColor = System.Drawing.Color.Black
            Me.TxtIdNo.LinkedLabel = Nothing
            Me.TxtIdNo.Location = New System.Drawing.Point(197, 11)
            Me.TxtIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtIdNo.MaximumValue = Nothing
            Me.TxtIdNo.MinimumValue = Nothing
            Me.TxtIdNo.Name = "TxtIdNo"
            Me.TxtIdNo.OldValue = Nothing
            Me.TxtIdNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.Translatable = False
            '
            'lblPrintJobCode
            '
            Me.lblPrintJobCode.DisplayOnly = True
            Me.lblPrintJobCode.EditingMode = False
            Me.lblPrintJobCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintJobCode, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintJobCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintJobCode.Location = New System.Drawing.Point(11, 36)
            Me.lblPrintJobCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintJobCode.Name = "lblPrintJobCode"
            Me.lblPrintJobCode.Size = New System.Drawing.Size(184, 23)
            Me.lblPrintJobCode.TabIndex = 151
            Me.lblPrintJobCode.Text = "Print Job Code"
            Me.lblPrintJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintJobCode.Translatable = True
            '
            'txtPrintJobCode
            '
            Me.txtPrintJobCode.BackColor = System.Drawing.Color.White
            Me.txtPrintJobCode.BegFindValue = Nothing
            Me.txtPrintJobCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrintJobCode.ComputedValue = False
            Me.txtPrintJobCode.CustomFormat = Nothing
            Me.txtPrintJobCode.DataBoundControl = True
            Me.txtPrintJobCode.EditingMode = False
            Me.txtPrintJobCode.EndFindValue = Nothing
            Me.txtPrintJobCode.FieldDescription = Nothing
            Me.txtPrintJobCode.FieldName = Nothing
            Me.txtPrintJobCode.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrintJobCode.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPrintJobCode, True)
            Me.txtPrintJobCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPrintJobCode.ForeColor = System.Drawing.Color.Gray
            Me.MyErrorProvider.SetIconAlignment(Me.txtPrintJobCode, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtPrintJobCode.LinkedLabel = Nothing
            Me.txtPrintJobCode.Location = New System.Drawing.Point(197, 36)
            Me.txtPrintJobCode.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrintJobCode.MaximumValue = Nothing
            Me.txtPrintJobCode.MinimumValue = Nothing
            Me.txtPrintJobCode.Name = "txtPrintJobCode"
            Me.txtPrintJobCode.OldValue = Nothing
            Me.txtPrintJobCode.ReadOnly = True
            Me.txtPrintJobCode.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrintJobCode.Size = New System.Drawing.Size(62, 23)
            Me.txtPrintJobCode.TabIndex = 1
            Me.txtPrintJobCode.Translatable = False
            Me.txtPrintJobCode.ValueIsMandatory = True
            Me.txtPrintJobCode.ValueIsUnique = True
            '
            'lblPrintJobName
            '
            Me.lblPrintJobName.DisplayOnly = True
            Me.lblPrintJobName.EditingMode = False
            Me.lblPrintJobName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintJobName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintJobName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintJobName.Location = New System.Drawing.Point(11, 61)
            Me.lblPrintJobName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintJobName.Name = "lblPrintJobName"
            Me.lblPrintJobName.Size = New System.Drawing.Size(184, 23)
            Me.lblPrintJobName.TabIndex = 153
            Me.lblPrintJobName.Text = "Print Job Name"
            Me.lblPrintJobName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintJobName.Translatable = True
            '
            'txtPrintJobName
            '
            Me.txtPrintJobName.BackColor = System.Drawing.Color.White
            Me.txtPrintJobName.BegFindValue = Nothing
            Me.txtPrintJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrintJobName.ComputedValue = False
            Me.txtPrintJobName.CustomFormat = Nothing
            Me.txtPrintJobName.DataBoundControl = True
            Me.txtPrintJobName.EditingMode = False
            Me.txtPrintJobName.EndFindValue = Nothing
            Me.txtPrintJobName.FieldDescription = Nothing
            Me.txtPrintJobName.FieldName = Nothing
            Me.txtPrintJobName.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrintJobName.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPrintJobName, True)
            Me.txtPrintJobName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPrintJobName.ForeColor = System.Drawing.Color.Gray
            Me.MyErrorProvider.SetIconAlignment(Me.txtPrintJobName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtPrintJobName.LinkedLabel = Nothing
            Me.txtPrintJobName.Location = New System.Drawing.Point(197, 61)
            Me.txtPrintJobName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrintJobName.MaximumValue = Nothing
            Me.txtPrintJobName.MinimumValue = Nothing
            Me.txtPrintJobName.Name = "txtPrintJobName"
            Me.txtPrintJobName.OldValue = Nothing
            Me.txtPrintJobName.ReadOnly = True
            Me.txtPrintJobName.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrintJobName.Size = New System.Drawing.Size(221, 23)
            Me.txtPrintJobName.TabIndex = 2
            Me.txtPrintJobName.Translatable = False
            Me.txtPrintJobName.ValueIsMandatory = True
            Me.txtPrintJobName.ValueIsUnique = True
            '
            'lblPrintJobNameAra
            '
            Me.lblPrintJobNameAra.DisplayOnly = True
            Me.lblPrintJobNameAra.EditingMode = False
            Me.lblPrintJobNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblPrintJobNameAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblPrintJobNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblPrintJobNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblPrintJobNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblPrintJobNameAra.Name = "lblPrintJobNameAra"
            Me.lblPrintJobNameAra.Size = New System.Drawing.Size(184, 23)
            Me.lblPrintJobNameAra.TabIndex = 155
            Me.lblPrintJobNameAra.Text = "Print Job Name (Arabic)"
            Me.lblPrintJobNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPrintJobNameAra.Translatable = True
            '
            'txtPrintJobNameAra
            '
            Me.txtPrintJobNameAra.BackColor = System.Drawing.Color.White
            Me.txtPrintJobNameAra.BegFindValue = Nothing
            Me.txtPrintJobNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrintJobNameAra.ComputedValue = False
            Me.txtPrintJobNameAra.CustomFormat = Nothing
            Me.txtPrintJobNameAra.DataBoundControl = True
            Me.txtPrintJobNameAra.EditingMode = False
            Me.txtPrintJobNameAra.EndFindValue = Nothing
            Me.txtPrintJobNameAra.EnglishControl = Me.txtPrintJobName
            Me.txtPrintJobNameAra.FieldDescription = Nothing
            Me.txtPrintJobNameAra.FieldName = Nothing
            Me.txtPrintJobNameAra.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtPrintJobNameAra.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.txtPrintJobNameAra, True)
            Me.txtPrintJobNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtPrintJobNameAra.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtPrintJobNameAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtPrintJobNameAra.LinkedLabel = Nothing
            Me.txtPrintJobNameAra.Location = New System.Drawing.Point(197, 86)
            Me.txtPrintJobNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtPrintJobNameAra.MaximumValue = Nothing
            Me.txtPrintJobNameAra.MinimumValue = Nothing
            Me.txtPrintJobNameAra.Name = "txtPrintJobNameAra"
            Me.txtPrintJobNameAra.OldValue = Nothing
            Me.txtPrintJobNameAra.ReadOnly = True
            Me.txtPrintJobNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtPrintJobNameAra.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtPrintJobNameAra.Size = New System.Drawing.Size(221, 23)
            Me.txtPrintJobNameAra.TabIndex = 3
            Me.txtPrintJobNameAra.Translatable = False
            Me.txtPrintJobNameAra.ValueIsUnique = True
            '
            'LblComputerName
            '
            Me.LblComputerName.DisplayOnly = True
            Me.LblComputerName.EditingMode = False
            Me.LblComputerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblComputerName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblComputerName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblComputerName.Location = New System.Drawing.Point(11, 111)
            Me.LblComputerName.Margin = New System.Windows.Forms.Padding(1)
            Me.LblComputerName.Name = "LblComputerName"
            Me.LblComputerName.Size = New System.Drawing.Size(184, 23)
            Me.LblComputerName.TabIndex = 157
            Me.LblComputerName.Text = "Computer Name"
            Me.LblComputerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblComputerName.Translatable = True
            '
            'CTextBoxArabic1
            '
            Me.CTextBoxArabic1.BackColor = System.Drawing.Color.White
            Me.CTextBoxArabic1.BegFindValue = Nothing
            Me.CTextBoxArabic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBoxArabic1.ComputedValue = False
            Me.CTextBoxArabic1.CustomFormat = Nothing
            Me.CTextBoxArabic1.DataBoundControl = True
            Me.CTextBoxArabic1.EditingMode = False
            Me.CTextBoxArabic1.EndFindValue = Nothing
            Me.CTextBoxArabic1.EnglishControl = Me.txtPrintJobName
            Me.CTextBoxArabic1.FieldDescription = Nothing
            Me.CTextBoxArabic1.FieldName = Nothing
            Me.CTextBoxArabic1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBoxArabic1.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.CTextBoxArabic1, True)
            Me.CTextBoxArabic1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBoxArabic1.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.CTextBoxArabic1, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.CTextBoxArabic1.LinkedLabel = Nothing
            Me.CTextBoxArabic1.Location = New System.Drawing.Point(197, 111)
            Me.CTextBoxArabic1.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBoxArabic1.MaximumValue = Nothing
            Me.CTextBoxArabic1.MinimumValue = Nothing
            Me.CTextBoxArabic1.Name = "CTextBoxArabic1"
            Me.CTextBoxArabic1.OldValue = Nothing
            Me.CTextBoxArabic1.ReadOnly = True
            Me.CTextBoxArabic1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CTextBoxArabic1.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBoxArabic1.Size = New System.Drawing.Size(221, 23)
            Me.CTextBoxArabic1.TabIndex = 156
            Me.CTextBoxArabic1.Translatable = False
            Me.CTextBoxArabic1.ValueIsUnique = True
            '
            'LblPaperSource
            '
            Me.LblPaperSource.DisplayOnly = True
            Me.LblPaperSource.EditingMode = False
            Me.LblPaperSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSource, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperSource.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperSource.Location = New System.Drawing.Point(11, 136)
            Me.LblPaperSource.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperSource.Name = "LblPaperSource"
            Me.LblPaperSource.Size = New System.Drawing.Size(184, 23)
            Me.LblPaperSource.TabIndex = 159
            Me.LblPaperSource.Text = "Paper Source"
            Me.LblPaperSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperSource.Translatable = True
            '
            'CTextBoxArabic2
            '
            Me.CTextBoxArabic2.BackColor = System.Drawing.Color.White
            Me.CTextBoxArabic2.BegFindValue = Nothing
            Me.CTextBoxArabic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBoxArabic2.ComputedValue = False
            Me.CTextBoxArabic2.CustomFormat = Nothing
            Me.CTextBoxArabic2.DataBoundControl = True
            Me.CTextBoxArabic2.EditingMode = False
            Me.CTextBoxArabic2.EndFindValue = Nothing
            Me.CTextBoxArabic2.EnglishControl = Me.txtPrintJobName
            Me.CTextBoxArabic2.FieldDescription = Nothing
            Me.CTextBoxArabic2.FieldName = Nothing
            Me.CTextBoxArabic2.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBoxArabic2.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.CTextBoxArabic2, True)
            Me.CTextBoxArabic2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBoxArabic2.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.CTextBoxArabic2, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.CTextBoxArabic2.LinkedLabel = Nothing
            Me.CTextBoxArabic2.Location = New System.Drawing.Point(197, 136)
            Me.CTextBoxArabic2.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBoxArabic2.MaximumValue = Nothing
            Me.CTextBoxArabic2.MinimumValue = Nothing
            Me.CTextBoxArabic2.Name = "CTextBoxArabic2"
            Me.CTextBoxArabic2.OldValue = Nothing
            Me.CTextBoxArabic2.ReadOnly = True
            Me.CTextBoxArabic2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CTextBoxArabic2.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBoxArabic2.Size = New System.Drawing.Size(221, 23)
            Me.CTextBoxArabic2.TabIndex = 158
            Me.CTextBoxArabic2.Translatable = False
            Me.CTextBoxArabic2.ValueIsUnique = True
            '
            'LblPaperSize
            '
            Me.LblPaperSize.DisplayOnly = True
            Me.LblPaperSize.EditingMode = False
            Me.LblPaperSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperSize, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperSize.Location = New System.Drawing.Point(11, 161)
            Me.LblPaperSize.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperSize.Name = "LblPaperSize"
            Me.LblPaperSize.Size = New System.Drawing.Size(184, 23)
            Me.LblPaperSize.TabIndex = 161
            Me.LblPaperSize.Text = "Paper Size"
            Me.LblPaperSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperSize.Translatable = True
            '
            'CTextBoxArabic3
            '
            Me.CTextBoxArabic3.BackColor = System.Drawing.Color.White
            Me.CTextBoxArabic3.BegFindValue = Nothing
            Me.CTextBoxArabic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBoxArabic3.ComputedValue = False
            Me.CTextBoxArabic3.CustomFormat = Nothing
            Me.CTextBoxArabic3.DataBoundControl = True
            Me.CTextBoxArabic3.EditingMode = False
            Me.CTextBoxArabic3.EndFindValue = Nothing
            Me.CTextBoxArabic3.EnglishControl = Me.txtPrintJobName
            Me.CTextBoxArabic3.FieldDescription = Nothing
            Me.CTextBoxArabic3.FieldName = Nothing
            Me.CTextBoxArabic3.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBoxArabic3.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.CTextBoxArabic3, True)
            Me.CTextBoxArabic3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBoxArabic3.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.CTextBoxArabic3, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.CTextBoxArabic3.LinkedLabel = Nothing
            Me.CTextBoxArabic3.Location = New System.Drawing.Point(197, 161)
            Me.CTextBoxArabic3.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBoxArabic3.MaximumValue = Nothing
            Me.CTextBoxArabic3.MinimumValue = Nothing
            Me.CTextBoxArabic3.Name = "CTextBoxArabic3"
            Me.CTextBoxArabic3.OldValue = Nothing
            Me.CTextBoxArabic3.ReadOnly = True
            Me.CTextBoxArabic3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CTextBoxArabic3.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBoxArabic3.Size = New System.Drawing.Size(221, 23)
            Me.CTextBoxArabic3.TabIndex = 160
            Me.CTextBoxArabic3.Translatable = False
            Me.CTextBoxArabic3.ValueIsUnique = True
            '
            'LblPaperOrientation
            '
            Me.LblPaperOrientation.DisplayOnly = True
            Me.LblPaperOrientation.EditingMode = False
            Me.LblPaperOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblPaperOrientation, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblPaperOrientation.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblPaperOrientation.Location = New System.Drawing.Point(11, 186)
            Me.LblPaperOrientation.Margin = New System.Windows.Forms.Padding(1)
            Me.LblPaperOrientation.Name = "LblPaperOrientation"
            Me.LblPaperOrientation.Size = New System.Drawing.Size(184, 23)
            Me.LblPaperOrientation.TabIndex = 163
            Me.LblPaperOrientation.Text = "Paper Orientation"
            Me.LblPaperOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.LblPaperOrientation.Translatable = True
            '
            'CTextBoxArabic4
            '
            Me.CTextBoxArabic4.BackColor = System.Drawing.Color.White
            Me.CTextBoxArabic4.BegFindValue = Nothing
            Me.CTextBoxArabic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.CTextBoxArabic4.ComputedValue = False
            Me.CTextBoxArabic4.CustomFormat = Nothing
            Me.CTextBoxArabic4.DataBoundControl = True
            Me.CTextBoxArabic4.EditingMode = False
            Me.CTextBoxArabic4.EndFindValue = Nothing
            Me.CTextBoxArabic4.EnglishControl = Me.txtPrintJobName
            Me.CTextBoxArabic4.FieldDescription = Nothing
            Me.CTextBoxArabic4.FieldName = Nothing
            Me.CTextBoxArabic4.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CTextBoxArabic4.FindEnabled = True
            Me.floDataDisplay.SetFlowBreak(Me.CTextBoxArabic4, True)
            Me.CTextBoxArabic4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CTextBoxArabic4.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.CTextBoxArabic4, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.CTextBoxArabic4.LinkedLabel = Nothing
            Me.CTextBoxArabic4.Location = New System.Drawing.Point(197, 186)
            Me.CTextBoxArabic4.Margin = New System.Windows.Forms.Padding(1)
            Me.CTextBoxArabic4.MaximumValue = Nothing
            Me.CTextBoxArabic4.MinimumValue = Nothing
            Me.CTextBoxArabic4.Name = "CTextBoxArabic4"
            Me.CTextBoxArabic4.OldValue = Nothing
            Me.CTextBoxArabic4.ReadOnly = True
            Me.CTextBoxArabic4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.CTextBoxArabic4.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.CTextBoxArabic4.Size = New System.Drawing.Size(221, 23)
            Me.CTextBoxArabic4.TabIndex = 162
            Me.CTextBoxArabic4.Translatable = False
            Me.CTextBoxArabic4.ValueIsUnique = True
            '
            'PrintJobEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(687, 365)
            Me.MinimumSize = New System.Drawing.Size(703, 404)
            Me.Name = "PrintJobEntryTv"
            Me.Text = "Print Job Maintenance Form"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.Panel2.PerformLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents lblPrintJobCode As CLabel
        Friend WithEvents txtPrintJobCode As CTextBox
        Friend WithEvents lblPrintJobName As CLabel
        Friend WithEvents txtPrintJobName As CTextBox
        Friend WithEvents lblPrintJobNameAra As CLabel
        Friend WithEvents txtPrintJobNameAra As CTextBoxArabic
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents LblComputerName As CLabel
        Friend WithEvents CTextBoxArabic1 As CTextBoxArabic
        Friend WithEvents LblPaperSource As CLabel
        Friend WithEvents CTextBoxArabic2 As CTextBoxArabic
        Friend WithEvents LblPaperSize As CLabel
        Friend WithEvents CTextBoxArabic3 As CTextBoxArabic
        Friend WithEvents LblPaperOrientation As CLabel
        Friend WithEvents CTextBoxArabic4 As CTextBoxArabic
    End Class
End Namespace