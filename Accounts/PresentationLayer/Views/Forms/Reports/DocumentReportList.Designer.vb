Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DocumentReportList
        Inherits AATM.PresentationLayer.Forms.BfMain

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
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.lblSupplierCode = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.cboDocumentType = New AATM.Libraries.CBaseControlsLibrary.CdtComboBox()
            Me.chkAllDocuments = New AATM.Libraries.CBaseControlsLibrary.UcCheckBox()
            Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.CFlowLayout1.SuspendLayout()
            Me.SuspendLayout()
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.CLabel2)
            Me.CFlowLayout1.Controls.Add(Me.lblSupplierCode)
            Me.CFlowLayout1.Controls.Add(Me.cboDocumentType)
            Me.CFlowLayout1.Controls.Add(Me.chkAllDocuments)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 12)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(687, 93)
            Me.CFlowLayout1.TabIndex = 26
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(1, 1)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(682, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'lblSupplierCode
            '
            Me.lblSupplierCode.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplierCode.DisplayOnly = True
            Me.lblSupplierCode.EditingMode = False
            Me.lblSupplierCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSupplierCode.Location = New System.Drawing.Point(1, 28)
            Me.lblSupplierCode.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSupplierCode.Name = "lblSupplierCode"
            Me.lblSupplierCode.Size = New System.Drawing.Size(150, 24)
            Me.lblSupplierCode.TabIndex = 34
            Me.lblSupplierCode.Text = "Document Types"
            Me.lblSupplierCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSupplierCode.Translatable = True
            '
            'cboDocumentType
            '
            Me.cboDocumentType.BackColor = System.Drawing.Color.White
            Me.cboDocumentType.BegFindValue = Nothing
            Me.cboDocumentType.ChangingSearchValueOnly = False
            Me.cboDocumentType.CurrentSearchTerm = ""
            Me.cboDocumentType.DataValue = Nothing
            Me.cboDocumentType.DefaultValue = Nothing
            Me.cboDocumentType.DisplayMember = "Name"
            Me.cboDocumentType.DropDownHeight = 24
            Me.cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cboDocumentType.Editable = True
            Me.cboDocumentType.EditingMode = False
            Me.cboDocumentType.EndFindValue = Nothing
            Me.cboDocumentType.FieldDescription = Nothing
            Me.cboDocumentType.FieldName = Nothing
            Me.cboDocumentType.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboDocumentType.FindEnabled = False
            Me.cboDocumentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboDocumentType.ForeColor = System.Drawing.Color.Black
            Me.cboDocumentType.FormattingEnabled = True
            Me.cboDocumentType.HideWhenNotEditingOrAdding = False
            Me.cboDocumentType.IgnoreCase = False
            Me.cboDocumentType.IntegralHeight = False
            Me.cboDocumentType.LimitToList = False
            Me.cboDocumentType.LinkedLabel = Nothing
            Me.cboDocumentType.Location = New System.Drawing.Point(153, 28)
            Me.cboDocumentType.Margin = New System.Windows.Forms.Padding(1)
            Me.cboDocumentType.MaxDropDownItems = 1
            Me.cboDocumentType.Name = "cboDocumentType"
            Me.cboDocumentType.OldValue = 0
            Me.cboDocumentType.OriginalDataSource = Nothing
            Me.cboDocumentType.OriginalList = Nothing
            Me.cboDocumentType.OverrideDropDownStyleList = False
            Me.cboDocumentType.PreviousSearchTerm = Nothing
            Me.cboDocumentType.Size = New System.Drawing.Size(530, 24)
            Me.cboDocumentType.SuggestBoxHeight = 200
            Me.cboDocumentType.TabIndex = 35
            Me.cboDocumentType.TextToSearch = Nothing
            Me.cboDocumentType.Translatable = False
            Me.cboDocumentType.ValueIsMandatory = False
            Me.cboDocumentType.ValueIsNullable = False
            Me.cboDocumentType.ValueIsNumeric = False
            Me.cboDocumentType.ValueMember = "IdNo"
            '
            'chkAllDocuments
            '
            Me.chkAllDocuments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.chkAllDocuments.BackColor = System.Drawing.Color.Transparent
            Me.chkAllDocuments.BegFindValue = Nothing
            Me.chkAllDocuments.Checked = False
            Me.chkAllDocuments.EditingMode = False
            Me.chkAllDocuments.EndFindValue = Nothing
            Me.chkAllDocuments.FieldDescription = Nothing
            Me.chkAllDocuments.FieldName = Nothing
            Me.chkAllDocuments.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.chkAllDocuments.FindEnabled = False
            Me.chkAllDocuments.IgnoreCase = False
            Me.chkAllDocuments.LinkedLabel = Nothing
            Me.chkAllDocuments.Location = New System.Drawing.Point(4, 57)
            Me.chkAllDocuments.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.chkAllDocuments.Name = "chkAllDocuments"
            Me.chkAllDocuments.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.chkAllDocuments.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.chkAllDocuments.Size = New System.Drawing.Size(679, 21)
            Me.chkAllDocuments.TabIndex = 36
            Me.chkAllDocuments.Text = "Print All Document Types"
            Me.chkAllDocuments.Translatable = True
            '
            'CLabel1
            '
            Me.CLabel1.BackColor = System.Drawing.Color.Transparent
            Me.CLabel1.DisplayOnly = True
            Me.CLabel1.EditingMode = False
            Me.CLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel1.Location = New System.Drawing.Point(25, 37)
            Me.CLabel1.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel1.Name = "CLabel1"
            Me.CLabel1.Size = New System.Drawing.Size(150, 25)
            Me.CLabel1.TabIndex = 26
            Me.CLabel1.Text = "Beginning Date :"
            Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel1.Translatable = True
            '
            'btnOk
            '
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(214, 111)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(90, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(336, 111)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'DocumentReportList
            '
            Me.ClientSize = New System.Drawing.Size(705, 149)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.DoubleBuffered = True
            Me.Name = "DocumentReportList"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Document Report List"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents lblSupplierCode As CLabel
        Friend WithEvents cboDocumentType As CdtComboBox
        Friend WithEvents chkAllDocuments As UcCheckBox
    End Class
End Namespace