Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CountryEntryTv
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
        Me.floDataDisplay = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.lblIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtIDNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
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
        Me.LblPhoneCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtPhoneCode = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.LblFlag32 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtFlag32 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.LblFlag128 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.TxtFlag128 = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.floDataDisplay.SuspendLayout
        Me.SuspendLayout
        '
        'TreeViewTableName
        '
        Me.TreeViewTableName.LineColor = System.Drawing.Color.Black
        Me.TreeViewTableName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TreeViewTableName.Size = New System.Drawing.Size(300, 313)
        '
        'floDataDisplay
        '
        Me.floDataDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.floDataDisplay.BackColor = System.Drawing.Color.Transparent
        Me.floDataDisplay.Controls.Add(Me.lblIdNo)
        Me.floDataDisplay.Controls.Add(Me.TxtIDNo)
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
        Me.floDataDisplay.Controls.Add(Me.LblPhoneCode)
        Me.floDataDisplay.Controls.Add(Me.TxtPhoneCode)
        Me.floDataDisplay.Controls.Add(Me.LblFlag32)
        Me.floDataDisplay.Controls.Add(Me.TxtFlag32)
        Me.floDataDisplay.Controls.Add(Me.LblFlag128)
        Me.floDataDisplay.Controls.Add(Me.TxtFlag128)
        Me.floDataDisplay.Location = New System.Drawing.Point(306, 12)
        Me.floDataDisplay.Name = "floDataDisplay"
        Me.floDataDisplay.Size = New System.Drawing.Size(403, 301)
        Me.floDataDisplay.TabIndex = 148
        '
        'lblIdNo
        '
        Me.lblIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.lblIdNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdNo.Location = New System.Drawing.Point(1, 1)
        Me.lblIdNo.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIdNo.Name = "lblIdNo"
        Me.lblIdNo.Size = New System.Drawing.Size(161, 23)
        Me.lblIdNo.TabIndex = 150
        Me.lblIdNo.Text = "Country ID No."
        Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtIDNo
        '
        Me.TxtIDNo.BackColor = System.Drawing.Color.White
        Me.TxtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDNo.ComputedValue = false
        Me.TxtIDNo.CustomFormat = Nothing
        Me.TxtIDNo.DataBoundControl = true
        Me.TxtIDNo.DisplayOnly = true
        Me.TxtIDNo.EditingMode = true
        Me.floDataDisplay.SetFlowBreak(Me.TxtIDNo, true)
        Me.TxtIDNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtIDNo.ForeColor = System.Drawing.Color.Black
        Me.TxtIDNo.LinkedLabel = Nothing
        Me.TxtIDNo.Location = New System.Drawing.Point(164, 1)
        Me.TxtIDNo.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtIDNo.Name = "TxtIDNo"
        Me.TxtIDNo.OldValue = Nothing
        Me.TxtIDNo.ReadOnly = true
        Me.TxtIDNo.Size = New System.Drawing.Size(62, 23)
        Me.TxtIDNo.TabIndex = 0
        Me.TxtIDNo.TabStop = false
        '
        'lblIsoA2
        '
        Me.lblIsoA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblIsoA2, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblIsoA2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIsoA2.Location = New System.Drawing.Point(1, 26)
        Me.lblIsoA2.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIsoA2.Name = "lblIsoA2"
        Me.lblIsoA2.Size = New System.Drawing.Size(161, 23)
        Me.lblIsoA2.TabIndex = 151
        Me.lblIsoA2.Text = "ISO Code 2 Letter"
        Me.lblIsoA2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIsoA2
        '
        Me.txtIsoA2.BackColor = System.Drawing.Color.White
        Me.txtIsoA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIsoA2.ComputedValue = false
        Me.txtIsoA2.CustomFormat = Nothing
        Me.txtIsoA2.DataBoundControl = true
        Me.txtIsoA2.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtIsoA2, true)
        Me.txtIsoA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtIsoA2.ForeColor = System.Drawing.Color.Gray
        Me.MyErrorProvider.SetIconAlignment(Me.txtIsoA2, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.txtIsoA2.LinkedLabel = Nothing
        Me.txtIsoA2.Location = New System.Drawing.Point(164, 26)
        Me.txtIsoA2.Margin = New System.Windows.Forms.Padding(1)
        Me.txtIsoA2.Name = "txtIsoA2"
        Me.txtIsoA2.OldValue = Nothing
        Me.txtIsoA2.ReadOnly = true
        Me.txtIsoA2.Size = New System.Drawing.Size(62, 23)
        Me.txtIsoA2.TabIndex = 152
        Me.txtIsoA2.ValueIsMandatory = true
        '
        'lblCountryName
        '
        Me.lblCountryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblCountryName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblCountryName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountryName.Location = New System.Drawing.Point(1, 51)
        Me.lblCountryName.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCountryName.Name = "lblCountryName"
        Me.lblCountryName.Size = New System.Drawing.Size(161, 23)
        Me.lblCountryName.TabIndex = 153
        Me.lblCountryName.Text = "Country Name"
        Me.lblCountryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCountryName
        '
        Me.txtCountryName.BackColor = System.Drawing.Color.White
        Me.txtCountryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountryName.ComputedValue = false
        Me.txtCountryName.CustomFormat = Nothing
        Me.txtCountryName.DataBoundControl = true
        Me.txtCountryName.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.txtCountryName, true)
        Me.txtCountryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCountryName.ForeColor = System.Drawing.Color.Gray
        Me.MyErrorProvider.SetIconAlignment(Me.txtCountryName, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.txtCountryName.LinkedLabel = Nothing
        Me.txtCountryName.Location = New System.Drawing.Point(164, 51)
        Me.txtCountryName.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCountryName.Name = "txtCountryName"
        Me.txtCountryName.OldValue = Nothing
        Me.txtCountryName.ReadOnly = true
        Me.txtCountryName.Size = New System.Drawing.Size(221, 23)
        Me.txtCountryName.TabIndex = 154
        Me.txtCountryName.ValueIsMandatory = true
        '
        'lblCountryNameAra
        '
        Me.lblCountryNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblCountryNameAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblCountryNameAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountryNameAra.Location = New System.Drawing.Point(1, 76)
        Me.lblCountryNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblCountryNameAra.Name = "lblCountryNameAra"
        Me.lblCountryNameAra.Size = New System.Drawing.Size(161, 23)
        Me.lblCountryNameAra.TabIndex = 155
        Me.lblCountryNameAra.Text = "Country Name (Arabic)"
        Me.lblCountryNameAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCountryNameAra
        '
        Me.txtCountryNameAra.BackColor = System.Drawing.Color.White
        Me.txtCountryNameAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountryNameAra.ComputedValue = false
        Me.txtCountryNameAra.CustomFormat = Nothing
        Me.txtCountryNameAra.DataBoundControl = true
        Me.txtCountryNameAra.EditingMode = false
        Me.txtCountryNameAra.EnglishControl = Me.txtCountryName
        Me.floDataDisplay.SetFlowBreak(Me.txtCountryNameAra, true)
        Me.txtCountryNameAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtCountryNameAra.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtCountryNameAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.txtCountryNameAra.LinkedLabel = Nothing
        Me.txtCountryNameAra.Location = New System.Drawing.Point(164, 76)
        Me.txtCountryNameAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCountryNameAra.Name = "txtCountryNameAra"
        Me.txtCountryNameAra.OldValue = Nothing
        Me.txtCountryNameAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCountryNameAra.Size = New System.Drawing.Size(221, 23)
        Me.txtCountryNameAra.TabIndex = 156
        '
        'LblNationality
        '
        Me.LblNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.LblNationality, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.LblNationality.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblNationality.Location = New System.Drawing.Point(1, 101)
        Me.LblNationality.Margin = New System.Windows.Forms.Padding(1)
        Me.LblNationality.Name = "LblNationality"
        Me.LblNationality.Size = New System.Drawing.Size(161, 23)
        Me.LblNationality.TabIndex = 158
        Me.LblNationality.Text = "Nationality"
        Me.LblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNationality
        '
        Me.txtNationality.BackColor = System.Drawing.Color.White
        Me.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNationality.ComputedValue = false
        Me.txtNationality.CustomFormat = Nothing
        Me.txtNationality.DataBoundControl = true
        Me.txtNationality.EditingMode = false
        Me.txtNationality.EnglishControl = Me.txtCountryName
        Me.floDataDisplay.SetFlowBreak(Me.txtNationality, true)
        Me.txtNationality.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNationality.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtNationality, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.txtNationality.LinkedLabel = Nothing
        Me.txtNationality.Location = New System.Drawing.Point(164, 101)
        Me.txtNationality.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNationality.Name = "txtNationality"
        Me.txtNationality.OldValue = Nothing
        Me.txtNationality.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNationality.Size = New System.Drawing.Size(221, 23)
        Me.txtNationality.TabIndex = 159
        '
        'lblNationalityAra
        '
        Me.lblNationalityAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblNationalityAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblNationalityAra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNationalityAra.Location = New System.Drawing.Point(1, 126)
        Me.lblNationalityAra.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNationalityAra.Name = "lblNationalityAra"
        Me.lblNationalityAra.Size = New System.Drawing.Size(161, 23)
        Me.lblNationalityAra.TabIndex = 160
        Me.lblNationalityAra.Text = "Nationality (Arabic)"
        Me.lblNationalityAra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNationalityAra
        '
        Me.txtNationalityAra.BackColor = System.Drawing.Color.White
        Me.txtNationalityAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNationalityAra.ComputedValue = false
        Me.txtNationalityAra.CustomFormat = Nothing
        Me.txtNationalityAra.DataBoundControl = true
        Me.txtNationalityAra.EditingMode = false
        Me.txtNationalityAra.EnglishControl = Me.txtCountryName
        Me.floDataDisplay.SetFlowBreak(Me.txtNationalityAra, true)
        Me.txtNationalityAra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.txtNationalityAra.ForeColor = System.Drawing.Color.Black
        Me.MyErrorProvider.SetIconAlignment(Me.txtNationalityAra, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.txtNationalityAra.LinkedLabel = Nothing
        Me.txtNationalityAra.Location = New System.Drawing.Point(164, 126)
        Me.txtNationalityAra.Margin = New System.Windows.Forms.Padding(1)
        Me.txtNationalityAra.Name = "txtNationalityAra"
        Me.txtNationalityAra.OldValue = Nothing
        Me.txtNationalityAra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNationalityAra.Size = New System.Drawing.Size(221, 23)
        Me.txtNationalityAra.TabIndex = 161
        '
        'lblISOA3
        '
        Me.lblISOA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.MyErrorProvider.SetIconAlignment(Me.lblISOA3, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.lblISOA3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblISOA3.Location = New System.Drawing.Point(1, 151)
        Me.lblISOA3.Margin = New System.Windows.Forms.Padding(1)
        Me.lblISOA3.Name = "lblISOA3"
        Me.lblISOA3.Size = New System.Drawing.Size(161, 23)
        Me.lblISOA3.TabIndex = 162
        Me.lblISOA3.Text = "ISO Code 3 Letters"
        Me.lblISOA3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtISOA3
        '
        Me.TxtISOA3.BackColor = System.Drawing.Color.White
        Me.TxtISOA3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtISOA3.ComputedValue = false
        Me.TxtISOA3.CustomFormat = Nothing
        Me.TxtISOA3.DataBoundControl = true
        Me.TxtISOA3.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.TxtISOA3, true)
        Me.TxtISOA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtISOA3.ForeColor = System.Drawing.Color.Gray
        Me.MyErrorProvider.SetIconAlignment(Me.TxtISOA3, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.TxtISOA3.LinkedLabel = Nothing
        Me.TxtISOA3.Location = New System.Drawing.Point(164, 151)
        Me.TxtISOA3.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtISOA3.Name = "TxtISOA3"
        Me.TxtISOA3.OldValue = Nothing
        Me.TxtISOA3.ReadOnly = true
        Me.TxtISOA3.Size = New System.Drawing.Size(62, 23)
        Me.TxtISOA3.TabIndex = 163
        Me.TxtISOA3.ValueIsMandatory = true
        '
        'LblISON
        '
        Me.LblISON.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.LblISON.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblISON.Location = New System.Drawing.Point(1, 176)
        Me.LblISON.Margin = New System.Windows.Forms.Padding(1)
        Me.LblISON.Name = "LblISON"
        Me.LblISON.Size = New System.Drawing.Size(161, 23)
        Me.LblISON.TabIndex = 168
        Me.LblISON.Text = "ISO Code Numeric"
        Me.LblISON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtISON
        '
        Me.TxtISON.BackColor = System.Drawing.Color.White
        Me.TxtISON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtISON.ComputedValue = false
        Me.TxtISON.CustomFormat = Nothing
        Me.TxtISON.DataBoundControl = true
        Me.TxtISON.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.TxtISON, true)
        Me.TxtISON.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtISON.ForeColor = System.Drawing.Color.Gray
        Me.TxtISON.LinkedLabel = Me.LblISON
        Me.TxtISON.Location = New System.Drawing.Point(164, 176)
        Me.TxtISON.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtISON.Name = "TxtISON"
        Me.TxtISON.OldValue = Nothing
        Me.TxtISON.ReadOnly = true
        Me.TxtISON.Size = New System.Drawing.Size(62, 23)
        Me.TxtISON.TabIndex = 164
        '
        'LblPhoneCode
        '
        Me.LblPhoneCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.LblPhoneCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblPhoneCode.Location = New System.Drawing.Point(1, 201)
        Me.LblPhoneCode.Margin = New System.Windows.Forms.Padding(1)
        Me.LblPhoneCode.Name = "LblPhoneCode"
        Me.LblPhoneCode.Size = New System.Drawing.Size(161, 23)
        Me.LblPhoneCode.TabIndex = 169
        Me.LblPhoneCode.Text = "International Phone Code"
        Me.LblPhoneCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPhoneCode
        '
        Me.TxtPhoneCode.BackColor = System.Drawing.Color.White
        Me.TxtPhoneCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPhoneCode.ComputedValue = false
        Me.TxtPhoneCode.CustomFormat = Nothing
        Me.TxtPhoneCode.DataBoundControl = true
        Me.TxtPhoneCode.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.TxtPhoneCode, true)
        Me.TxtPhoneCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtPhoneCode.ForeColor = System.Drawing.Color.Gray
        Me.TxtPhoneCode.LinkedLabel = Me.LblPhoneCode
        Me.TxtPhoneCode.Location = New System.Drawing.Point(164, 201)
        Me.TxtPhoneCode.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtPhoneCode.Name = "TxtPhoneCode"
        Me.TxtPhoneCode.OldValue = Nothing
        Me.TxtPhoneCode.ReadOnly = true
        Me.TxtPhoneCode.Size = New System.Drawing.Size(62, 23)
        Me.TxtPhoneCode.TabIndex = 165
        Me.TxtPhoneCode.ValueIsNumeric = true
        '
        'LblFlag32
        '
        Me.LblFlag32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.LblFlag32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblFlag32.Location = New System.Drawing.Point(1, 226)
        Me.LblFlag32.Margin = New System.Windows.Forms.Padding(1)
        Me.LblFlag32.Name = "LblFlag32"
        Me.LblFlag32.Size = New System.Drawing.Size(161, 23)
        Me.LblFlag32.TabIndex = 170
        Me.LblFlag32.Text = "Flag Small"
        Me.LblFlag32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFlag32
        '
        Me.TxtFlag32.BackColor = System.Drawing.Color.White
        Me.TxtFlag32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFlag32.ComputedValue = false
        Me.TxtFlag32.CustomFormat = Nothing
        Me.TxtFlag32.DataBoundControl = true
        Me.TxtFlag32.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.TxtFlag32, true)
        Me.TxtFlag32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtFlag32.ForeColor = System.Drawing.Color.Gray
        Me.TxtFlag32.LinkedLabel = Me.LblFlag32
        Me.TxtFlag32.Location = New System.Drawing.Point(164, 226)
        Me.TxtFlag32.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtFlag32.Name = "TxtFlag32"
        Me.TxtFlag32.OldValue = Nothing
        Me.TxtFlag32.ReadOnly = true
        Me.TxtFlag32.Size = New System.Drawing.Size(62, 23)
        Me.TxtFlag32.TabIndex = 166
        '
        'LblFlag128
        '
        Me.LblFlag128.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.LblFlag128.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblFlag128.Location = New System.Drawing.Point(1, 251)
        Me.LblFlag128.Margin = New System.Windows.Forms.Padding(1)
        Me.LblFlag128.Name = "LblFlag128"
        Me.LblFlag128.Size = New System.Drawing.Size(161, 23)
        Me.LblFlag128.TabIndex = 171
        Me.LblFlag128.Text = "Flag Big"
        Me.LblFlag128.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtFlag128
        '
        Me.TxtFlag128.BackColor = System.Drawing.Color.White
        Me.TxtFlag128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFlag128.ComputedValue = false
        Me.TxtFlag128.CustomFormat = Nothing
        Me.TxtFlag128.DataBoundControl = true
        Me.TxtFlag128.EditingMode = false
        Me.floDataDisplay.SetFlowBreak(Me.TxtFlag128, true)
        Me.TxtFlag128.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!)
        Me.TxtFlag128.ForeColor = System.Drawing.Color.Gray
        Me.TxtFlag128.LinkedLabel = Me.LblFlag128
        Me.TxtFlag128.Location = New System.Drawing.Point(164, 251)
        Me.TxtFlag128.Margin = New System.Windows.Forms.Padding(1)
        Me.TxtFlag128.Name = "TxtFlag128"
        Me.TxtFlag128.OldValue = Nothing
        Me.TxtFlag128.ReadOnly = true
        Me.TxtFlag128.Size = New System.Drawing.Size(62, 23)
        Me.TxtFlag128.TabIndex = 167
        '
        'CountryEntryTv
        '
        Me.ClientSize = New System.Drawing.Size(815, 398)
        Me.Controls.Add(Me.floDataDisplay)
        Me.Name = "CountryEntryTv"
        Me.Controls.SetChildIndex(Me.TreeViewTableName, 0)
        Me.Controls.SetChildIndex(Me.floDataDisplay, 0)
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.floDataDisplay.ResumeLayout(false)
        Me.floDataDisplay.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

        Friend WithEvents floDataDisplay As CFlowLayout
        Friend WithEvents lblIdNo As CLabel
        Friend WithEvents TxtIDNo As CTextBox
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
        Friend WithEvents LblPhoneCode As CLabel
        Friend WithEvents TxtFlag128 As CTextBox
        Friend WithEvents LblFlag128 As CLabel
        Friend WithEvents LblFlag32 As CLabel
        Friend WithEvents TxtFlag32 As CTextBox
        Friend WithEvents TxtPhoneCode As CTextBox
    End Class
End NameSpace