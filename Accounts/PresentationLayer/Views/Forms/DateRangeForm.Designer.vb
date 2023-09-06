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
            Me.CtComboBox1 = New AATM.Libraries.CBaseControlsLibrary.CtComboBox()
            Me.btnOk = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.btnCancel = New AATM.Libraries.CBaseControlsLibrary.CButton()
            Me.CLabel3 = New AATM.Libraries.CBaseControlsLibrary.CLabel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
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
            Me.CLabel2.Size = New System.Drawing.Size(687, 39)
            Me.CLabel2.TabIndex = 26
            Me.CLabel2.Text = "Date Range Selection"
            Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.CLabel2.Translatable = True
            '
            'dateRange
            '
            Me.dateRange.BackColor = System.Drawing.Color.Transparent
            Me.dateRange.BeginningDate = Nothing
            Me.TableLayoutPanel1.SetColumnSpan(Me.dateRange, 2)
            Me.dateRange.EndingDate = Nothing
            Me.dateRange.Location = New System.Drawing.Point(3, 3)
            Me.dateRange.Name = "dateRange"
            Me.dateRange.Size = New System.Drawing.Size(230, 53)
            Me.dateRange.TabIndex = 29
            '
            'CtComboBox1
            '
            Me.CtComboBox1.BackColor = System.Drawing.Color.White
            Me.CtComboBox1.BegFindValue = Nothing
            Me.CtComboBox1.ChangingSearchValueOnly = False
            Me.TableLayoutPanel1.SetColumnSpan(Me.CtComboBox1, 2)
            Me.CtComboBox1.CurrentSearchTerm = ""
            Me.CtComboBox1.DataValue = Nothing
            Me.CtComboBox1.DefaultValue = Nothing
            Me.CtComboBox1.DisplayMember = "Name"
            Me.CtComboBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CtComboBox1.Editable = True
            Me.CtComboBox1.EditingMode = True
            Me.CtComboBox1.EndFindValue = Nothing
            Me.CtComboBox1.FieldDescription = Nothing
            Me.CtComboBox1.FieldName = Nothing
            Me.CtComboBox1.FilterRule = Nothing
            Me.CtComboBox1.FindDataType = AATM.Libraries.AatmInterfaces.IFindableControl.DataTypeEnum.[String]
            Me.CtComboBox1.FindEnabled = False
            Me.CtComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CtComboBox1.ForeColor = System.Drawing.Color.Black
            Me.CtComboBox1.FormattingEnabled = True
            Me.CtComboBox1.HideWhenNotEditingOrAdding = False
            Me.CtComboBox1.IgnoreCase = False
            Me.CtComboBox1.IntegralHeight = False
            Me.CtComboBox1.LimitToList = False
            Me.CtComboBox1.LinkedLabel = Nothing
            Me.CtComboBox1.Location = New System.Drawing.Point(209, 75)
            Me.CtComboBox1.Margin = New System.Windows.Forms.Padding(1)
            Me.CtComboBox1.Name = "CtComboBox1"
            Me.CtComboBox1.OldValue = 0
            Me.CtComboBox1.OriginalDataSource = Nothing
            Me.CtComboBox1.OriginalList = Nothing
            Me.CtComboBox1.OverrideDropDownStyleList = False
            Me.CtComboBox1.PreviousSearchTerm = Nothing
            Me.CtComboBox1.PropertySelector = Nothing
            Me.CtComboBox1.Size = New System.Drawing.Size(496, 28)
            Me.CtComboBox1.SuggestBoxHeight = 200
            Me.CtComboBox1.SuggestCharCount = 0
            Me.CtComboBox1.SuggestListOrderRule = Nothing
            Me.CtComboBox1.TabIndex = 30
            Me.CtComboBox1.TextToSearch = Nothing
            Me.CtComboBox1.Translatable = False
            Me.CtComboBox1.ValueIsMandatory = False
            Me.CtComboBox1.ValueIsNullable = False
            Me.CtComboBox1.ValueIsNumeric = False
            Me.CtComboBox1.ValueMember = "IdNo"
            '
            'btnOk
            '
            Me.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.TableLayoutPanel1.SetColumnSpan(Me.btnOk, 2)
            Me.btnOk.DesignerSelected = False
            Me.btnOk.ImageIndex = 0
            Me.btnOk.Location = New System.Drawing.Point(166, 243)
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
            Me.btnCancel.Location = New System.Drawing.Point(570, 243)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.OriginalImageName = Nothing
            Me.btnCancel.SecurityKey = ""
            Me.btnCancel.Size = New System.Drawing.Size(83, 25)
            Me.btnCancel.TabIndex = 28
            Me.btnCancel.Text = "Cancel"
            '
            'CLabel3
            '
            Me.CLabel3.AutoSize = True
            Me.CLabel3.DisplayOnly = True
            Me.CLabel3.EditingMode = False
            Me.CLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.CLabel3.Location = New System.Drawing.Point(1, 60)
            Me.CLabel3.Margin = New System.Windows.Forms.Padding(1)
            Me.CLabel3.Name = "CLabel3"
            Me.CLabel3.Size = New System.Drawing.Size(71, 20)
            Me.CLabel3.TabIndex = 31
            Me.CLabel3.Text = "CLabel3"
            Me.CLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.CLabel3.Translatable = True
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.dateRange, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.btnOk, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CtComboBox1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CLabel3, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 2, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 44)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(664, 325)
            Me.TableLayoutPanel1.TabIndex = 29
            '
            'DateRangeForm
            '
            Me.ClientSize = New System.Drawing.Size(687, 449)
            Me.Controls.Add(Me.CLabel2)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.DoubleBuffered = True
            Me.Name = "DateRangeForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Text = "Date Range Selection"
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CLabel2 As Libraries.CBaseControlsLibrary.CLabel
        Friend WithEvents dateRange As DateRangeControl
        Private WithEvents btnOk As CButton
        Private WithEvents btnCancel As CButton
        Friend WithEvents CtComboBox1 As CtComboBox
        Friend WithEvents CLabel3 As CLabel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    End Class
End Namespace