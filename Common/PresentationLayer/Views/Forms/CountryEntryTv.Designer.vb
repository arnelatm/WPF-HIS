Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class CountryEntryTv
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
            Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtIdNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblIsoA2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtIsoA2 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCountryName = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCountryName = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.lblCountryNameAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtCountryNameAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.LblNationality = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNationality = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblNationalityAra = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.txtNationalityAra = New AATM.Libraries.CBaseControlsLibrary.CTextBoxArabic()
            Me.lblISOA3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtISOA3 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.LblISON = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtISON = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.LblCountryTelCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtCountryTelCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.LblFlag32 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtFlag32 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            Me.LblFlag128 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TxtFlag128 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.floDataDisplay.SuspendLayout()
            Me.SuspendLayout()
            '
            'TreeViewTableName
            '
            Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
            Me.TreeViewTableName.MinimumSize = New System.Drawing.Size(300, 286)
            Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.TreeViewTableName.Size = New System.Drawing.Size(300, 301)
            '
            'floDataDisplay
            '
            Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
            Me.floDataDisplay.Controls.Add(Me.lblIdNo)
            Me.floDataDisplay.Controls.Add(Me.TxtIdNo)
            Me.floDataDisplay.Controls.Add(Me.lblIsoA2)
            Me.floDataDisplay.Controls.Add(Me.txtIsoA2)
            Me.floDataDisplay.Controls.Add(Me.lblCountryName)
            Me.floDataDisplay.Controls.Add(Me.txtCountryName)
            Me.floDataDisplay.Controls.Add(Me.lblCountryNameAra)
            Me.floDataDisplay.Controls.Add(Me.txtCountryNameAra)
            Me.floDataDisplay.Controls.Add(Me.LblNationality)
            Me.floDataDisplay.Controls.Add(Me.txtNationality)
            Me.floDataDisplay.Controls.Add(Me.lblNationalityAra)
            Me.floDataDisplay.Controls.Add(Me.txtNationalityAra)
            Me.floDataDisplay.Controls.Add(Me.lblISOA3)
            Me.floDataDisplay.Controls.Add(Me.TxtISOA3)
            Me.floDataDisplay.Controls.Add(Me.LblISON)
            Me.floDataDisplay.Controls.Add(Me.TxtISON)
            Me.floDataDisplay.Controls.Add(Me.LblCountryTelCode)
            Me.floDataDisplay.Controls.Add(Me.TxtCountryTelCode)
            Me.floDataDisplay.Controls.Add(Me.LblFlag32)
            Me.floDataDisplay.Controls.Add(Me.TxtFlag32)
            Me.floDataDisplay.Controls.Add(Me.LblFlag128)
            Me.floDataDisplay.Controls.Add(Me.TxtFlag128)
            Me.floDataDisplay.Dock = System.Windows.Forms.DockStyle.Left
            Me.floDataDisplay.Location = New System.Drawing.Point(300, 53)
            Me.floDataDisplay.Name = "floDataDisplay"
            Me.floDataDisplay.Padding = New System.Windows.Forms.Padding(10, 10, 0, 0)
            Me.floDataDisplay.Size = New System.Drawing.Size(435, 301)
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
            Me.lblIdNo.Text = "Country ID No."
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.TxtIdNo.ReadOnly = True
            Me.TxtIdNo.Size = New System.Drawing.Size(62, 23)
            Me.TxtIdNo.TabIndex = 0
            Me.TxtIdNo.TabStop = False
            '
            'lblIsoA2
            '
            Me.lblIsoA2.DisplayOnly = True
            Me.lblIsoA2.EditingMode = False
            Me.lblIsoA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblIsoA2, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblIsoA2.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblIsoA2.Location = New System.Drawing.Point(11, 36)
            Me.lblIsoA2.Margin = New System.Windows.Forms.Padding(1)
            Me.lblIsoA2.Name = "lblIsoA2"
            Me.lblIsoA2.Size = New System.Drawing.Size(184, 23)
            Me.lblIsoA2.TabIndex = 151
            Me.lblIsoA2.Text = "ISO Code 2 Letter"
            Me.lblIsoA2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtIsoA2
            '
            Me.txtIsoA2.BackColor = System.Drawing.Color.White
            Me.txtIsoA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIsoA2.ComputedValue = False
            Me.txtIsoA2.CustomFormat = Nothing
            Me.txtIsoA2.DataBoundControl = True
            Me.txtIsoA2.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtIsoA2, True)
            Me.txtIsoA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtIsoA2.ForeColor = System.Drawing.Color.Gray
            Me.MyErrorProvider.SetIconAlignment(Me.txtIsoA2, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtIsoA2.LinkedLabel = Nothing
            Me.txtIsoA2.Location = New System.Drawing.Point(197, 36)
            Me.txtIsoA2.Margin = New System.Windows.Forms.Padding(1)
            Me.txtIsoA2.MaximumValue = Nothing
            Me.txtIsoA2.MinimumValue = Nothing
            Me.txtIsoA2.Name = "txtIsoA2"
            Me.txtIsoA2.OldValue = Nothing
            Me.txtIsoA2.ReadOnly = True
            Me.txtIsoA2.Size = New System.Drawing.Size(62, 23)
            Me.txtIsoA2.TabIndex = 1
            Me.txtIsoA2.ValueIsMandatory = True
            '
            'lblCountryName
            '
            Me.lblCountryName.DisplayOnly = True
            Me.lblCountryName.EditingMode = False
            Me.lblCountryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblCountryName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblCountryName.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCountryName.Location = New System.Drawing.Point(11, 61)
            Me.lblCountryName.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCountryName.Name = "lblCountryName"
            Me.lblCountryName.Size = New System.Drawing.Size(184, 23)
            Me.lblCountryName.TabIndex = 153
            Me.lblCountryName.Text = "Country Name"
            Me.lblCountryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtCountryName
            '
            Me.txtCountryName.BackColor = System.Drawing.Color.White
            Me.txtCountryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCountryName.ComputedValue = False
            Me.txtCountryName.CustomFormat = Nothing
            Me.txtCountryName.DataBoundControl = True
            Me.txtCountryName.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.txtCountryName, True)
            Me.txtCountryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCountryName.ForeColor = System.Drawing.Color.Gray
            Me.MyErrorProvider.SetIconAlignment(Me.txtCountryName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtCountryName.LinkedLabel = Nothing
            Me.txtCountryName.Location = New System.Drawing.Point(197, 61)
            Me.txtCountryName.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCountryName.MaximumValue = Nothing
            Me.txtCountryName.MinimumValue = Nothing
            Me.txtCountryName.Name = "txtCountryName"
            Me.txtCountryName.OldValue = Nothing
            Me.txtCountryName.ReadOnly = True
            Me.txtCountryName.Size = New System.Drawing.Size(221, 23)
            Me.txtCountryName.TabIndex = 2
            Me.txtCountryName.ValueIsMandatory = True
            '
            'lblCountryNameAra
            '
            Me.lblCountryNameAra.DisplayOnly = True
            Me.lblCountryNameAra.EditingMode = False
            Me.lblCountryNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblCountryNameAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblCountryNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblCountryNameAra.Location = New System.Drawing.Point(11, 86)
            Me.lblCountryNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblCountryNameAra.Name = "lblCountryNameAra"
            Me.lblCountryNameAra.Size = New System.Drawing.Size(184, 23)
            Me.lblCountryNameAra.TabIndex = 155
            Me.lblCountryNameAra.Text = "Country Name (Arabic)"
            Me.lblCountryNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtCountryNameAra
            '
            Me.txtCountryNameAra.BackColor = System.Drawing.Color.White
            Me.txtCountryNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCountryNameAra.ComputedValue = False
            Me.txtCountryNameAra.CustomFormat = Nothing
            Me.txtCountryNameAra.DataBoundControl = True
            Me.txtCountryNameAra.EditingMode = False
            Me.txtCountryNameAra.EnglishControl = Me.txtCountryName
            Me.floDataDisplay.SetFlowBreak(Me.txtCountryNameAra, True)
            Me.txtCountryNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtCountryNameAra.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtCountryNameAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtCountryNameAra.LinkedLabel = Nothing
            Me.txtCountryNameAra.Location = New System.Drawing.Point(197, 86)
            Me.txtCountryNameAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtCountryNameAra.MaximumValue = Nothing
            Me.txtCountryNameAra.MinimumValue = Nothing
            Me.txtCountryNameAra.Name = "txtCountryNameAra"
            Me.txtCountryNameAra.OldValue = Nothing
            Me.txtCountryNameAra.ReadOnly = True
            Me.txtCountryNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtCountryNameAra.Size = New System.Drawing.Size(221, 23)
            Me.txtCountryNameAra.TabIndex = 3
            '
            'LblNationality
            '
            Me.LblNationality.DisplayOnly = True
            Me.LblNationality.EditingMode = False
            Me.LblNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.LblNationality, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.LblNationality.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblNationality.Location = New System.Drawing.Point(11, 111)
            Me.LblNationality.Margin = New System.Windows.Forms.Padding(1)
            Me.LblNationality.Name = "LblNationality"
            Me.LblNationality.Size = New System.Drawing.Size(184, 23)
            Me.LblNationality.TabIndex = 158
            Me.LblNationality.Text = "Nationality"
            Me.LblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNationality
            '
            Me.txtNationality.BackColor = System.Drawing.Color.White
            Me.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationality.ComputedValue = False
            Me.txtNationality.CustomFormat = Nothing
            Me.txtNationality.DataBoundControl = True
            Me.txtNationality.EditingMode = False
            Me.txtNationality.EnglishControl = Me.txtCountryName
            Me.floDataDisplay.SetFlowBreak(Me.txtNationality, True)
            Me.txtNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationality.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtNationality, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtNationality.LinkedLabel = Nothing
            Me.txtNationality.Location = New System.Drawing.Point(197, 111)
            Me.txtNationality.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationality.MaximumValue = Nothing
            Me.txtNationality.MinimumValue = Nothing
            Me.txtNationality.Name = "txtNationality"
            Me.txtNationality.OldValue = Nothing
            Me.txtNationality.ReadOnly = True
            Me.txtNationality.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtNationality.Size = New System.Drawing.Size(221, 23)
            Me.txtNationality.TabIndex = 4
            '
            'lblNationalityAra
            '
            Me.lblNationalityAra.DisplayOnly = True
            Me.lblNationalityAra.EditingMode = False
            Me.lblNationalityAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblNationalityAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblNationalityAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblNationalityAra.Location = New System.Drawing.Point(11, 136)
            Me.lblNationalityAra.Margin = New System.Windows.Forms.Padding(1)
            Me.lblNationalityAra.Name = "lblNationalityAra"
            Me.lblNationalityAra.Size = New System.Drawing.Size(184, 23)
            Me.lblNationalityAra.TabIndex = 160
            Me.lblNationalityAra.Text = "Nationality (Arabic)"
            Me.lblNationalityAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNationalityAra
            '
            Me.txtNationalityAra.BackColor = System.Drawing.Color.White
            Me.txtNationalityAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNationalityAra.ComputedValue = False
            Me.txtNationalityAra.CustomFormat = Nothing
            Me.txtNationalityAra.DataBoundControl = True
            Me.txtNationalityAra.EditingMode = False
            Me.txtNationalityAra.EnglishControl = Me.txtCountryName
            Me.floDataDisplay.SetFlowBreak(Me.txtNationalityAra, True)
            Me.txtNationalityAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtNationalityAra.ForeColor = System.Drawing.Color.Black
            Me.MyErrorProvider.SetIconAlignment(Me.txtNationalityAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.txtNationalityAra.LinkedLabel = Nothing
            Me.txtNationalityAra.Location = New System.Drawing.Point(197, 136)
            Me.txtNationalityAra.Margin = New System.Windows.Forms.Padding(1)
            Me.txtNationalityAra.MaximumValue = Nothing
            Me.txtNationalityAra.MinimumValue = Nothing
            Me.txtNationalityAra.Name = "txtNationalityAra"
            Me.txtNationalityAra.OldValue = Nothing
            Me.txtNationalityAra.ReadOnly = True
            Me.txtNationalityAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.txtNationalityAra.Size = New System.Drawing.Size(221, 23)
            Me.txtNationalityAra.TabIndex = 5
            '
            'lblISOA3
            '
            Me.lblISOA3.DisplayOnly = True
            Me.lblISOA3.EditingMode = False
            Me.lblISOA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.MyErrorProvider.SetIconAlignment(Me.lblISOA3, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.lblISOA3.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblISOA3.Location = New System.Drawing.Point(11, 161)
            Me.lblISOA3.Margin = New System.Windows.Forms.Padding(1)
            Me.lblISOA3.Name = "lblISOA3"
            Me.lblISOA3.Size = New System.Drawing.Size(184, 23)
            Me.lblISOA3.TabIndex = 162
            Me.lblISOA3.Text = "ISO Code 3 Letters"
            Me.lblISOA3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TxtISOA3
            '
            Me.TxtISOA3.BackColor = System.Drawing.Color.White
            Me.TxtISOA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtISOA3.ComputedValue = False
            Me.TxtISOA3.CustomFormat = Nothing
            Me.TxtISOA3.DataBoundControl = True
            Me.TxtISOA3.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.TxtISOA3, True)
            Me.TxtISOA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtISOA3.ForeColor = System.Drawing.Color.Gray
            Me.MyErrorProvider.SetIconAlignment(Me.TxtISOA3, System.Windows.Forms.ErrorIconAlignment.TopLeft)
            Me.TxtISOA3.LinkedLabel = Nothing
            Me.TxtISOA3.Location = New System.Drawing.Point(197, 161)
            Me.TxtISOA3.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtISOA3.MaximumValue = Nothing
            Me.TxtISOA3.MinimumValue = Nothing
            Me.TxtISOA3.Name = "TxtISOA3"
            Me.TxtISOA3.OldValue = Nothing
            Me.TxtISOA3.ReadOnly = True
            Me.TxtISOA3.Size = New System.Drawing.Size(62, 23)
            Me.TxtISOA3.TabIndex = 6
            Me.TxtISOA3.ValueIsMandatory = True
            '
            'LblISON
            '
            Me.LblISON.DisplayOnly = True
            Me.LblISON.EditingMode = False
            Me.LblISON.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.LblISON.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblISON.Location = New System.Drawing.Point(11, 186)
            Me.LblISON.Margin = New System.Windows.Forms.Padding(1)
            Me.LblISON.Name = "LblISON"
            Me.LblISON.Size = New System.Drawing.Size(184, 23)
            Me.LblISON.TabIndex = 168
            Me.LblISON.Text = "ISO Code Numeric"
            Me.LblISON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TxtISON
            '
            Me.TxtISON.BackColor = System.Drawing.Color.White
            Me.TxtISON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtISON.ComputedValue = False
            Me.TxtISON.CustomFormat = Nothing
            Me.TxtISON.DataBoundControl = True
            Me.TxtISON.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.TxtISON, True)
            Me.TxtISON.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtISON.ForeColor = System.Drawing.Color.Gray
            Me.TxtISON.LinkedLabel = Me.LblISON
            Me.TxtISON.Location = New System.Drawing.Point(197, 186)
            Me.TxtISON.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtISON.MaximumValue = Nothing
            Me.TxtISON.MinimumValue = Nothing
            Me.TxtISON.Name = "TxtISON"
            Me.TxtISON.OldValue = Nothing
            Me.TxtISON.ReadOnly = True
            Me.TxtISON.Size = New System.Drawing.Size(62, 23)
            Me.TxtISON.TabIndex = 7
            Me.TxtISON.ValueIsNumeric = True
            '
            'LblCountryTelCode
            '
            Me.LblCountryTelCode.DisplayOnly = True
            Me.LblCountryTelCode.EditingMode = False
            Me.LblCountryTelCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.LblCountryTelCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblCountryTelCode.Location = New System.Drawing.Point(11, 211)
            Me.LblCountryTelCode.Margin = New System.Windows.Forms.Padding(1)
            Me.LblCountryTelCode.Name = "LblCountryTelIdNo"
            Me.LblCountryTelCode.Size = New System.Drawing.Size(184, 23)
            Me.LblCountryTelCode.TabIndex = 169
            Me.LblCountryTelCode.Text = "International Phone Code"
            Me.LblCountryTelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TxtCountryTelCode
            '
            Me.TxtCountryTelCode.BackColor = System.Drawing.Color.White
            Me.TxtCountryTelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtCountryTelCode.ComputedValue = False
            Me.TxtCountryTelCode.CustomFormat = Nothing
            Me.TxtCountryTelCode.DataBoundControl = True
            Me.TxtCountryTelCode.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.TxtCountryTelCode, True)
            Me.TxtCountryTelCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtCountryTelCode.ForeColor = System.Drawing.Color.Gray
            Me.TxtCountryTelCode.LinkedLabel = Me.LblCountryTelCode
            Me.TxtCountryTelCode.Location = New System.Drawing.Point(197, 211)
            Me.TxtCountryTelCode.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtCountryTelCode.MaximumValue = Nothing
            Me.TxtCountryTelCode.MinimumValue = Nothing
            Me.TxtCountryTelCode.Name = "TxtCountryTelIdNo"
            Me.TxtCountryTelCode.OldValue = Nothing
            Me.TxtCountryTelCode.ReadOnly = True
            Me.TxtCountryTelCode.Size = New System.Drawing.Size(62, 23)
            Me.TxtCountryTelCode.TabIndex = 8
            Me.TxtCountryTelCode.ValueIsNullable = True
            Me.TxtCountryTelCode.ValueIsNumeric = True
            '
            'LblFlag32
            '
            Me.LblFlag32.DisplayOnly = True
            Me.LblFlag32.EditingMode = False
            Me.LblFlag32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.LblFlag32.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblFlag32.Location = New System.Drawing.Point(11, 236)
            Me.LblFlag32.Margin = New System.Windows.Forms.Padding(1)
            Me.LblFlag32.Name = "LblFlag32"
            Me.LblFlag32.Size = New System.Drawing.Size(184, 23)
            Me.LblFlag32.TabIndex = 170
            Me.LblFlag32.Text = "Flag Small"
            Me.LblFlag32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TxtFlag32
            '
            Me.TxtFlag32.BackColor = System.Drawing.Color.White
            Me.TxtFlag32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtFlag32.ComputedValue = False
            Me.TxtFlag32.CustomFormat = Nothing
            Me.TxtFlag32.DataBoundControl = True
            Me.TxtFlag32.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.TxtFlag32, True)
            Me.TxtFlag32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtFlag32.ForeColor = System.Drawing.Color.Gray
            Me.TxtFlag32.LinkedLabel = Me.LblFlag32
            Me.TxtFlag32.Location = New System.Drawing.Point(197, 236)
            Me.TxtFlag32.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtFlag32.MaximumValue = Nothing
            Me.TxtFlag32.MinimumValue = Nothing
            Me.TxtFlag32.Name = "TxtFlag32"
            Me.TxtFlag32.OldValue = Nothing
            Me.TxtFlag32.ReadOnly = True
            Me.TxtFlag32.Size = New System.Drawing.Size(62, 23)
            Me.TxtFlag32.TabIndex = 9
            '
            'LblFlag128
            '
            Me.LblFlag128.DisplayOnly = True
            Me.LblFlag128.EditingMode = False
            Me.LblFlag128.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.LblFlag128.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.LblFlag128.Location = New System.Drawing.Point(11, 261)
            Me.LblFlag128.Margin = New System.Windows.Forms.Padding(1)
            Me.LblFlag128.Name = "LblFlag128"
            Me.LblFlag128.Size = New System.Drawing.Size(184, 23)
            Me.LblFlag128.TabIndex = 171
            Me.LblFlag128.Text = "Flag Big"
            Me.LblFlag128.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TxtFlag128
            '
            Me.TxtFlag128.BackColor = System.Drawing.Color.White
            Me.TxtFlag128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TxtFlag128.ComputedValue = False
            Me.TxtFlag128.CustomFormat = Nothing
            Me.TxtFlag128.DataBoundControl = True
            Me.TxtFlag128.EditingMode = False
            Me.floDataDisplay.SetFlowBreak(Me.TxtFlag128, True)
            Me.TxtFlag128.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.TxtFlag128.ForeColor = System.Drawing.Color.Gray
            Me.TxtFlag128.LinkedLabel = Me.LblFlag128
            Me.TxtFlag128.Location = New System.Drawing.Point(197, 261)
            Me.TxtFlag128.Margin = New System.Windows.Forms.Padding(1)
            Me.TxtFlag128.MaximumValue = Nothing
            Me.TxtFlag128.MinimumValue = Nothing
            Me.TxtFlag128.Name = "TxtFlag128"
            Me.TxtFlag128.OldValue = Nothing
            Me.TxtFlag128.ReadOnly = True
            Me.TxtFlag128.Size = New System.Drawing.Size(62, 23)
            Me.TxtFlag128.TabIndex = 10
            '
            'CountryEntryTv
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(738, 354)
            Me.Controls.Add(Me.floDataDisplay)
            Me.Name = "CountryEntryTv"
            Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
            Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.floDataDisplay.ResumeLayout(False)
            Me.floDataDisplay.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIdNo As CTextBox
        Friend WithEvents lblIsoA2 As CLabel
        Friend WithEvents txtIsoA2 As CTextBox
        Friend WithEvents lblCountryName As CLabel
        Friend WithEvents txtCountryName As CTextBox
        Friend WithEvents lblCountryNameAra As CLabel
        Friend WithEvents txtCountryNameAra As CTextBoxArabic
        Friend WithEvents LblNationality As CLabel
        Friend WithEvents txtNationality As CTextBoxArabic
        Friend WithEvents lblNationalityAra As CLabel
        Friend WithEvents txtNationalityAra As CTextBoxArabic
        Friend WithEvents lblISOA3 As CLabel
        Friend WithEvents TxtISOA3 As CTextBox
        Friend WithEvents LblISON As CLabel
        Friend WithEvents TxtISON As CTextBox
        Friend WithEvents LblCountryTelCode As CLabel
        Friend WithEvents TxtFlag128 As CTextBox
        Friend WithEvents LblFlag128 As CLabel
        Friend WithEvents LblFlag32 As CLabel
        Friend WithEvents TxtFlag32 As CTextBox
        Friend WithEvents TxtCountryTelCode As CTextBox
    End Class
End Namespace