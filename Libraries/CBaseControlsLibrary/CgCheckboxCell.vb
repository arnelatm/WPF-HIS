Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports AATM.Libraries.GlobalFuncNSub

Public Class CgCheckboxColumn
    Inherits DataGridViewCheckBoxColumn

    Public Sub New()
        MyBase.New()
        CellTemplate = New CgCheckBoxCell()
        'CellTemplate.Style.BackColor = Color.Beige
        'DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            If value IsNot Nothing AndAlso Not value.[GetType]().IsAssignableFrom(GetType(CgCheckBoxCell)) Then Throw New InvalidCastException("CustomDataGridViewCheckBoxCell.")
            MyBase.CellTemplate = value
        End Set
    End Property

    '<Category("Appearance")>
    '<Description("The check image.")>
    'Public Property TrueImage As Image
    '    Get
    '        Return AATM.Libraries.GlobalResources.My.Resources.CheckedBoxSmall
    '    End Get
    '    Set(value As Image)
    '        value = AATM.Libraries.GlobalResources.My.Resources.CheckedBoxSmall
    '    End Set
    'End Property

    '<Category("Appearance")>
    '<Description("The uncheck image.")>
    'Public Property FalseImage As Image
    '    Get
    '        Return AATM.Libraries.GlobalResources.My.Resources.CrossedBoxSmall
    '    End Get
    '    Set(value As Image)
    '        value = AATM.Libraries.GlobalResources.My.Resources.CrossedBoxSmall
    '    End Set
    'End Property

    Public Overrides Function Clone() As Object
        Dim c = TryCast(MyBase.Clone(), CgCheckboxColumn)
        Return c
    End Function
End Class



Public Class CgCheckBoxCell
    Inherits DataGridViewCheckBoxCell
    Public Sub New()
        MyBase.New()
    End Sub

    'Protected Overrides Sub Paint(ByVal g As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
    '    Dim col = TryCast(OwningColumn, CgCheckboxColumn)
    '    Dim parts = paintParts
    '    If col.TrueImage IsNot Nothing AndAlso col.FalseImage IsNot Nothing Then parts = parts And Not (DataGridViewPaintParts.ContentBackground Or DataGridViewPaintParts.ContentForeground)
    '    MyBase.Paint(g, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, parts)
    '    If parts = paintParts Then Return
    '    Dim img = If(CBool(formattedValue), col.TrueImage, col.FalseImage)
    '    Dim r = New Rectangle((cellBounds.Width - img.Width) / 2 + cellBounds.X, (cellBounds.Height - img.Height) / 2 + cellBounds.Y, img.Width, img.Height)
    '    g.DrawImage(img, r, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel)
    'End Sub

End Class

