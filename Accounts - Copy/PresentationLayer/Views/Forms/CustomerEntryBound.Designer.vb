Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.LocalizationUtilities
Imports AATM.PresentationLayer.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomerEntryBound
    Inherits CForm

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
        Dim CustomerCodeLabel As System.Windows.Forms.Label
        Dim CustomerNameLabel As System.Windows.Forms.Label
        Dim CustomerNameAraLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerEntryBound))
        Me.CustomerBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CustomerBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.CustomerCodeCTextBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CustomerNameCTextBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CustomerNameAraCTextBox = New AATM.Libraries.CBaseControlsLibrary.CTextBox()
        Me.CustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CustomerCodeLabel = New System.Windows.Forms.Label()
        CustomerNameLabel = New System.Windows.Forms.Label()
        CustomerNameAraLabel = New System.Windows.Forms.Label()
        CType(Me.CustomerBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomerBindingNavigator.SuspendLayout()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomerCodeLabel
        '
        CustomerCodeLabel.AutoSize = True
        CustomerCodeLabel.BackColor = System.Drawing.Color.Transparent
        CustomerCodeLabel.Location = New System.Drawing.Point(18, 304)
        CustomerCodeLabel.Name = "CustomerCodeLabel"
        CustomerCodeLabel.Size = New System.Drawing.Size(82, 13)
        CustomerCodeLabel.TabIndex = 21
        CustomerCodeLabel.Text = "Customer Code:"
        '
        'CustomerNameLabel
        '
        CustomerNameLabel.AutoSize = True
        CustomerNameLabel.BackColor = System.Drawing.Color.Transparent
        CustomerNameLabel.Location = New System.Drawing.Point(18, 329)
        CustomerNameLabel.Name = "CustomerNameLabel"
        CustomerNameLabel.Size = New System.Drawing.Size(85, 13)
        CustomerNameLabel.TabIndex = 23
        CustomerNameLabel.Text = "Customer Name:"
        '
        'CustomerNameAraLabel
        '
        CustomerNameAraLabel.AutoSize = True
        CustomerNameAraLabel.BackColor = System.Drawing.Color.Transparent
        CustomerNameAraLabel.Location = New System.Drawing.Point(18, 354)
        CustomerNameAraLabel.Name = "CustomerNameAraLabel"
        CustomerNameAraLabel.Size = New System.Drawing.Size(104, 13)
        CustomerNameAraLabel.TabIndex = 25
        CustomerNameAraLabel.Text = "Customer Name Ara:"
        '
        'CustomerBindingNavigator
        '
        Me.CustomerBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CustomerBindingNavigator.BindingSource = Me.CustomerBindingSource
        Me.CustomerBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.CustomerBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CustomerBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CustomerBindingNavigatorSaveItem})
        Me.CustomerBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.CustomerBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.CustomerBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.CustomerBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.CustomerBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.CustomerBindingNavigator.Name = "CustomerBindingNavigator"
        Me.CustomerBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.CustomerBindingNavigator.Size = New System.Drawing.Size(811, 25)
        Me.CustomerBindingNavigator.TabIndex = 0
        Me.CustomerBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CustomerBindingNavigatorSaveItem
        '
        Me.CustomerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CustomerBindingNavigatorSaveItem.Enabled = False
        Me.CustomerBindingNavigatorSaveItem.Image = CType(resources.GetObject("CustomerBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CustomerBindingNavigatorSaveItem.Name = "CustomerBindingNavigatorSaveItem"
        Me.CustomerBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.CustomerBindingNavigatorSaveItem.Text = "Save Data"
        '
        'CustomerCodeCTextBox
        '
        Me.CustomerCodeCTextBox.BackColor = System.Drawing.Color.White
        Me.CustomerCodeCTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomerCodeCTextBox.ComputedValue = False
        Me.CustomerCodeCTextBox.CustomFormat = Nothing
        Me.CustomerCodeCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerCode", True))
        Me.CustomerCodeCTextBox.DataBoundControl = True
        Me.CustomerCodeCTextBox.EditingMode = True
        Me.CustomerCodeCTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CustomerCodeCTextBox.ForeColor = System.Drawing.Color.Black
        Me.CustomerCodeCTextBox.LinkedLabel = Nothing
        Me.CustomerCodeCTextBox.Location = New System.Drawing.Point(147, 301)
        Me.CustomerCodeCTextBox.Margin = New System.Windows.Forms.Padding(1)
        Me.CustomerCodeCTextBox.MaximumValue = Nothing
        Me.CustomerCodeCTextBox.MinimumValue = Nothing
        Me.CustomerCodeCTextBox.Name = "CustomerCodeCTextBox"
        Me.CustomerCodeCTextBox.OldValue = Nothing
        Me.CustomerCodeCTextBox.Size = New System.Drawing.Size(200, 23)
        Me.CustomerCodeCTextBox.TabIndex = 22
        '
        'CustomerNameCTextBox
        '
        Me.CustomerNameCTextBox.BackColor = System.Drawing.Color.White
        Me.CustomerNameCTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomerNameCTextBox.ComputedValue = False
        Me.CustomerNameCTextBox.CustomFormat = Nothing
        Me.CustomerNameCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerName", True))
        Me.CustomerNameCTextBox.DataBoundControl = True
        Me.CustomerNameCTextBox.EditingMode = True
        Me.CustomerNameCTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CustomerNameCTextBox.ForeColor = System.Drawing.Color.Black
        Me.CustomerNameCTextBox.LinkedLabel = Nothing
        Me.CustomerNameCTextBox.Location = New System.Drawing.Point(147, 326)
        Me.CustomerNameCTextBox.Margin = New System.Windows.Forms.Padding(1)
        Me.CustomerNameCTextBox.MaximumValue = Nothing
        Me.CustomerNameCTextBox.MinimumValue = Nothing
        Me.CustomerNameCTextBox.Name = "CustomerNameCTextBox"
        Me.CustomerNameCTextBox.OldValue = Nothing
        Me.CustomerNameCTextBox.Size = New System.Drawing.Size(200, 23)
        Me.CustomerNameCTextBox.TabIndex = 24
        '
        'CustomerNameAraCTextBox
        '
        Me.CustomerNameAraCTextBox.BackColor = System.Drawing.Color.White
        Me.CustomerNameAraCTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomerNameAraCTextBox.ComputedValue = False
        Me.CustomerNameAraCTextBox.CustomFormat = Nothing
        Me.CustomerNameAraCTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomerBindingSource, "CustomerNameAra", True))
        Me.CustomerNameAraCTextBox.DataBoundControl = True
        Me.CustomerNameAraCTextBox.EditingMode = True
        Me.CustomerNameAraCTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CustomerNameAraCTextBox.ForeColor = System.Drawing.Color.Black
        Me.CustomerNameAraCTextBox.LinkedLabel = Nothing
        Me.CustomerNameAraCTextBox.Location = New System.Drawing.Point(147, 351)
        Me.CustomerNameAraCTextBox.Margin = New System.Windows.Forms.Padding(1)
        Me.CustomerNameAraCTextBox.MaximumValue = Nothing
        Me.CustomerNameAraCTextBox.MinimumValue = Nothing
        Me.CustomerNameAraCTextBox.Name = "CustomerNameAraCTextBox"
        Me.CustomerNameAraCTextBox.OldValue = Nothing
        Me.CustomerNameAraCTextBox.Size = New System.Drawing.Size(200, 23)
        Me.CustomerNameAraCTextBox.TabIndex = 26
        '
        'CustomerBindingSource
        '
        Me.CustomerBindingSource.DataSource = GetType(AATM.Accounts.BusinessLayer.Customer)
        '
        'CustomerEntryBound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(811, 604)
        Me.Controls.Add(CustomerCodeLabel)
        Me.Controls.Add(Me.CustomerCodeCTextBox)
        Me.Controls.Add(CustomerNameLabel)
        Me.Controls.Add(Me.CustomerNameCTextBox)
        Me.Controls.Add(CustomerNameAraLabel)
        Me.Controls.Add(Me.CustomerNameAraCTextBox)
        Me.Controls.Add(Me.CustomerBindingNavigator)
        Me.Name = "CustomerEntryBound"
        Me.Text = "CustomerEntryBound"
        CType(Me.CustomerBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomerBindingNavigator.ResumeLayout(False)
        Me.CustomerBindingNavigator.PerformLayout()
        CType(Me.CustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CustomerBindingSource As BindingSource
    Friend WithEvents CustomerBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents CustomerBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents CustomerCodeCTextBox As CTextBox
    Friend WithEvents CustomerNameCTextBox As CTextBox
    Friend WithEvents CustomerNameAraCTextBox As CTextBox
End Class
