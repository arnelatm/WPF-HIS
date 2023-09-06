Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace Accounts.PresentationLayer.Views.Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DateRangeForm
        Inherits BfMain

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
            Me.CLabel2 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.dateRange = New AATM.Libraries.CBaseControlsLibrary.DateRangeControl()
            Me.cboContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.lblContactIdNo = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CFlowLayout1 = New AATM.Libraries.CBaseControlsLibrary.CFlowLayout()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.CFlowLayout1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'CLabel2
            '
            Me.CLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CLabel2.DisplayOnly = True
            Me.CLabel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.CLabel2.EditingMode = False
            Me.CLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.CLabel2.Location = New System.Drawing.Point(0, 0)
            Me.CLabel2.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel2.Name = "CLabel2"
            Me.CLabel2.Size = New System.Drawing.Size(478, 39)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Date Range Selection"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'dateRange
            '
            Me.dateRange.BackColor = System.Drawing.Color.Transparent
            Me.dateRange.BeginningDate = Nothing
            Me.TableLayoutPanel1.SetColumnSpan(Me.dateRange, 3)
            Me.dateRange.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dateRange.EndingDate = Nothing
            Me.dateRange.Location = New System.Drawing.Point(3, 3)
            Me.dateRange.Name = "dateRange"
            Me.dateRange.Size = New System.Drawing.Size(458, 53)
            Me.dateRange.TabIndex = 29
            '
            'cboContactIdNo
            '
            Me.cboContactIdNo.BackColor = System.Drawing.Color.White
            Me.cboContactIdNo.BegFindValue = Nothing
            Me.cboContactIdNo.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.cboContactIdNo, 2)
            Me.cboContactIdNo.CurrentSearchTerm = ""
            Me.cboContactIdNo.DataValue = Nothing
            Me.cboContactIdNo.DefaultValue = Nothing
            Me.cboContactIdNo.DisplayMember = "Name"
            Me.cboContactIdNo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cboContactIdNo.Editable = True
            Me.cboContactIdNo.EditingMode = True
            Me.cboContactIdNo.EndFindValue = Nothing
            Me.cboContactIdNo.FieldDescription = Nothing
            Me.cboContactIdNo.FieldName = Nothing
            Me.cboContactIdNo.FilterRule = Nothing
            Me.cboContactIdNo.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.cboContactIdNo.FindEnabled = False
            Me.cboContactIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.cboContactIdNo.ForeColor = System.Drawing.Color.Black
            Me.cboContactIdNo.FormattingEnabled = True
            Me.cboContactIdNo.HideWhenNotEditingOrAdding = False
            Me.cboContactIdNo.IgnoreCase = False
            Me.cboContactIdNo.IntegralHeight = False
            Me.cboContactIdNo.LimitToList = False
            Me.cboContactIdNo.LinkedLabel = Nothing
            Me.cboContactIdNo.Location = New System.Drawing.Point(121, 60)
            Me.cboContactIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.cboContactIdNo.Name = "cboContactIdNo"
            Me.cboContactIdNo.OldValue = 0
            Me.cboContactIdNo.OriginalDataSource = Nothing
            Me.cboContactIdNo.OriginalList = Nothing
            Me.cboContactIdNo.OverrideDropDownStyleList = False
            Me.cboContactIdNo.PreviousSearchTerm = Nothing
            Me.cboContactIdNo.PropertySelector = Nothing
            Me.cboContactIdNo.Size = New System.Drawing.Size(342, 24)
            Me.cboContactIdNo.SuggestBoxHeight = 200
            Me.cboContactIdNo.SuggestCharCount = 0
            Me.cboContactIdNo.SuggestListOrderRule = Nothing
            Me.cboContactIdNo.TabIndex = 30
            Me.cboContactIdNo.TextToSearch = Nothing
            Me.cboContactIdNo.Translatable = False
            Me.cboContactIdNo.ValueIsMandatory = False
            Me.cboContactIdNo.ValueIsNullable = False
            Me.cboContactIdNo.ValueIsNumeric = False
            Me.cboContactIdNo.ValueMember = "IdNo"
            '
            'btnOk
            '
            Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(81, 7)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.OriginalImageName = Nothing
            Me.btnOk.SecurityKey = ""
            Me.btnOk.Size = New System.Drawing.Size(65, 25)
            Me.btnOk.TabIndex = 27
            Me.btnOk.Text = "Ok"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.btnCancel.DesignerSelected = False
            Me.btnCancel.ImageIndex = 0
            Me.btnCancel.Location = New System.Drawing.Point(299, 7)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(83, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'lblContactIdNo
            '
            Me.lblContactIdNo.AutoSize = True
            Me.lblContactIdNo.DisplayOnly = True
            Me.lblContactIdNo.EditingMode = False
            Me.lblContactIdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.lblContactIdNo.Location = New System.Drawing.Point(1, 60)
            Me.lblContactIdNo.Margin = New System.Windows.Forms.Padding(1)
            Me.lblContactIdNo.Name = "lblContactIdNo"
            Me.lblContactIdNo.Size = New System.Drawing.Size(97, 17)
            Me.lblContactIdNo.TabIndex = 31
            Me.lblContactIdNo.Text = "Contact Name"
            Me.lblContactIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblContactIdNo.Translatable = True
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.86207!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.13793!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.dateRange, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.cboContactIdNo, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.lblContactIdNo, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CFlowLayout1, 0, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 44)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(464, 139)
            Me.TableLayoutPanel1.TabIndex = 29
            '
            'CFlowLayout1
            '
            Me.CFlowLayout1.AutoSize = True
            Me.CFlowLayout1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CFlowLayout1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.SetColumnSpan(Me.CFlowLayout1, 3)
            Me.CFlowLayout1.Controls.Add(Me.TableLayoutPanel2)
            Me.CFlowLayout1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CFlowLayout1.Location = New System.Drawing.Point(3, 88)
            Me.CFlowLayout1.Name = "CFlowLayout1"
            Me.CFlowLayout1.Size = New System.Drawing.Size(458, 48)
            Me.CFlowLayout1.TabIndex = 32
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 2
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.btnCancel, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.btnOk, 0, 0)
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 1
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(455, 39)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'DateRangeForm
            '
            Me.ClientSize = New System.Drawing.Size(478, 191)
            Me.Controls.Add(Me.CLabel2)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.DoubleBuffered = True
            Me.Name = "DateRangeForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Date Range Selection"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.CFlowLayout1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dateRange As DateRangeControl
        Private WithEvents btnOk As CButton
        Private WithEvents btnCancel As CButton
        Friend WithEvents cboContactIdNo As CtComboBox
        Friend WithEvents lblContactIdNo As CLabel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents CFlowLayout1 As CFlowLayout
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    End Class
End Namespace