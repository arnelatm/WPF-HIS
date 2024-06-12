Imports System.Drawing
Imports System.Windows.Forms

Public Class CDgvCustomCheckBoxCell
    Inherits DataGridViewCheckBoxCell

    Public Property row_index As Integer

    'Public ReadOnly Property CheckboxHeight As Integer
    '    Get
    '        Return 24
    '    End Get
    'End Property

    'Public ReadOnly Property CheckboxWidth As Integer
    '    Get
    '        Return 24
    '    End Get
    'End Property

    Public Sub New()
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        'Me.row_index = rowIndex
        'Dim rect As Rectangle = New Rectangle()

        'If value IsNot Nothing Then

        '    If CBool(value) Then
        '        graphics.FillRectangle(Brushes.Blue, rect)
        '    Else
        '        graphics.FillRectangle(Brushes.Green, rect)
        '    End If
        'End If
        If value Then
            cellStyle.BackColor = Color.Red
        Else
            cellStyle.BackColor = Color.White
        End If
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

    End Sub


    'Public Sub New()
    '    Dim PassedHere As Boolean
    '    PassedHere = True

    'End Sub



    'Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
    '        ByVal initialFormattedValue As Object,
    '        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

    '    ' Set the value of the editing control to the current cell value.
    '    MyBase.InitializeEditingControl(rowIndex, initialFormattedValue,
    '        dataGridViewCellStyle)

    '    Dim ctl As CDgvCustomCheckBoxEditingControl = CType(DataGridView.EditingControl, CDgvCustomCheckBoxEditingControl)

    '    ' Use the default row value when Value property is null.
    '    If (Me.Value Is Nothing) Then
    '        ctl.Checked = CType(Me.DefaultNewRowValue, Boolean)
    '    Else
    '        ctl.Checked = CType(Me.Value, Boolean)
    '    End If
    'End Sub

    'Public Overrides ReadOnly Property EditType() As Type
    '    Get
    '        ' Return the type of the editing control that CalendarCell uses.
    '        Return GetType(CDgvCustomCheckBoxEditingControl)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property DefaultNewRowValue() As Object
    '    Get
    '        ' Use the False as the default value.
    '        Return False
    '    End Get
    'End Property


    'Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
    '    MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '    Dim val = CType(formattedValue, Boolean?)
    '    Dim img = If(val.HasValue AndAlso val.Value, Properties.Resources.Checked, Properties.Resources.UnChecked)
    '    Dim w = img.Width
    '    Dim h = img.Height
    '    Dim x = cellBounds.Left + (cellBounds.Width - w) / 2
    '    Dim y = cellBounds.Top + (cellBounds.Height - h) / 2
    '    graphics.DrawImage(img, New Rectangle(x, y, w, h))
    'End Sub


    'Protected Overrides Sub Paint(graphics As Graphics, clipBounds As Rectangle, cellBounds As Rectangle, rowIndex As Integer, elementState As DataGridViewElementStates, value As Object, formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)

    '    MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)



    'End Sub

    'Private Sub dataGridView1_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
    '    e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

    '    If e.RowIndex = 2 Then
    '        Dim rect = Me.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
    '        CheckBoxRenderer.DrawCheckBox(e.Graphics, New Point(rect.X, rect.Y), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal)
    '        e.Handled = True
    '    End If

    'End Sub


    'Public Class CustomDataGridViewCheckBoxColumn
    '    Inherits DataGridViewCheckBoxColumn

    '    Public Sub New()
    '        Me.CellTemplate = New CustomDataGridViewCheckBoxCell()
    '    End Sub
    'End Class


    'Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
    '    MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '    Dim val = CType(formattedValue, Boolean?)
    '    Dim checkedBox As Image = AATM.Libraries.GlobalResources.My.Resources.CheckedBoxSmall
    '    Dim crossedBox As Image = AATM.Libraries.GlobalResources.My.Resources.CrossedBoxSmall
    '    Dim blankBox As Image = AATM.Libraries.GlobalResources.My.Resources.BlankBoxSmall

    '    Dim img = If(val.HasValue AndAlso val.Value, checkedBox, crossedBox)
    '    Dim w = img.Width
    '    Dim h = img.Height
    '    Dim x = cellBounds.Left + (cellBounds.Width - w) / 2
    '    Dim y = cellBounds.Top + (cellBounds.Height - h) / 2
    '    graphics.DrawImage(img, New Rectangle(x, y, w, h))
    'End Sub


End Class