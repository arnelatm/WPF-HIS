Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms.Reports
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class IqamaCbcReport
        Inherits AATM.PresentationLayer.Forms.BFMain

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
        Me.lblSampleNumber = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
        Me.txtSampleNo = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.CLabel1 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
        Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
        Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CFlowLayout1.SuspendLayout
        Me.SuspendLayout
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'lblSampleNumber
            '
            Me.lblSampleNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblSampleNumber.DisplayOnly = True
            Me.lblSampleNumber.EditingMode = False
            Me.lblSampleNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblSampleNumber.Location = New System.Drawing.Point(11, 11)
            Me.lblSampleNumber.Margin = New System.Windows.Forms.Padding(1)
            Me.lblSampleNumber.Name = "lblSampleNumber"
            Me.lblSampleNumber.Size = New System.Drawing.Size(133, 25)
            Me.lblSampleNumber.TabIndex = 20
            Me.lblSampleNumber.Text = "Sample Number"
            Me.lblSampleNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSampleNumber.Translatable = True
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.CFlowLayout1.Controls.Add(Me.lblSampleNumber)
            Me.CFlowLayout1.Controls.Add(Me.txtSampleNo)
            Me.CFlowLayout1.Location = New System.Drawing.Point(12, 37)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Padding = New System.Windows.Forms.Padding(10)
            Me.CFlowLayout1.Size = New System.Drawing.Size(318, 50)
            Me.CFlowLayout1.TabIndex = 26
            '
            'txtSampleNo
            '
            Me.txtSampleNo.BackColor = System.Drawing.Color.White
            Me.txtSampleNo.BegFindValue = Nothing
            Me.txtSampleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSampleNo.ComputedValue = False
            Me.txtSampleNo.CustomFormat = Nothing
            Me.txtSampleNo.DataBoundControl = True
            Me.txtSampleNo.EditingMode = True
            Me.txtSampleNo.EndFindValue = Nothing
            Me.txtSampleNo.FieldDescription = Nothing
            Me.txtSampleNo.FieldName = Nothing
            Me.txtSampleNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.txtSampleNo.FindEnabled = False
            Me.txtSampleNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.txtSampleNo.ForeColor = System.Drawing.Color.Black
            Me.txtSampleNo.LinkedLabel = Nothing
            Me.txtSampleNo.Location = New System.Drawing.Point(146, 11)
            Me.txtSampleNo.Margin = New System.Windows.Forms.Padding(1)
            Me.txtSampleNo.MaximumValue = Nothing
            Me.txtSampleNo.MinimumValue = Nothing
            Me.txtSampleNo.Name = "txtSampleNo"
            Me.txtSampleNo.OldValue = Nothing
            Me.txtSampleNo.OverrideMaxLength = 0
            Me.txtSampleNo.SearchPlace = AATM.Libraries.AatmInterfaces.IFindableControl.SearchPlaceEnum.StartOfField
            Me.txtSampleNo.Size = New System.Drawing.Size(156, 26)
            Me.txtSampleNo.TabIndex = 25
            Me.txtSampleNo.Translatable = False
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(0, 0)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(321, 25)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Iqama CBC Result Printing"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
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
            Me.btnOk.Location = New System.Drawing.Point(69, 93)
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
            Me.btnCancel.Location = New System.Drawing.Point(175, 93)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(90, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'IqamaCbcReport
            '
            Me.ClientSize = New System.Drawing.Size(332, 128)
            Me.Controls.Add(Me.CLabel2)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.CFlowLayout1)
            Me.Controls.Add(Me.CLabel1)
            Me.DoubleBuffered = True
            Me.Name = "IqamaCbcReport"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Iqama CBC Result Printing"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.CFlowLayout1.PerformLayout
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents lblSampleNumber As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CFlowLayout1 As Libraries.CBaseControlsLibrary.CFlowLayout
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents CLabel1 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents btnOk As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents btnCancel As Libraries.CBaseControlsLibrary.CButton
        Friend WithEvents txtSampleNo As CTextBox
    End Class
End NameSpace