Public Enum ButtonClicked
    [Add]
    [Delete]
    [Edit]
    [Find]
    [First]
    [Last]
    [Next]
    [Previous]
    [Quit]
    [Save]
    [Undo]
    [Print]
    [Translate]
End Enum

Public Class AddModeChanged

    Public Sub New(ByVal addMode As Boolean)
        Me.AddMode = addMode
    End Sub

    Public Property AddMode As Boolean

End Class

Public Class EditModeChanged

    Public Sub New(ByVal editMode As Boolean)
        Me.EditMode = editMode
    End Sub

    Public Property EditMode As Boolean

End Class

Public Class InsertDgvLine

    Public Sub New(ByVal nRow As Int16, Optional dgvName As String = "")
        Me.BsRow = nRow
        Me.Name = dgvName
    End Sub

    Public Property BsRow
    Public Property Name

End Class

Public Class PassErrorList

    Public Sub New(ByRef errors As List(Of String))
        Me.Errors = errors
    End Sub

    Public Property Errors As List(Of String)

End Class

Public Class QuitView

    Public Sub New(ByRef quitView As Boolean)
        Me.QuitView = quitView
    End Sub

    Public Property QuitView As Boolean

End Class

Public Class BeforeAssignment

    Public Sub New(ByRef model)
        Me.Model = model
    End Sub

    Public Property Model
End Class

Public Class RecordPositionChanged

    Public Sub New(ByRef recPos As Integer)
        RecordPosition = recPos
    End Sub

    Public Property RecordPosition As Integer

End Class

Public Class RecordSaved

    Public Sub New(ByRef model)
        Me.Model = model
    End Sub

    Public Property Model

End Class

Public Class RecordDeleted

    Public Sub New(ByRef idNo As Int32)
        Me.IdNo = idNo
    End Sub

    Public Property IdNo As Int32

End Class

Public Class SelectedButton

    Public Sub New(ByVal clickedButton As ButtonClicked)
        Me.ClickedButton = clickedButton
    End Sub

    Public Property ClickedButton As ButtonClicked

End Class

Public Class ValidatingData

    Public Sub New(ByRef validated As Boolean)
        Me.Validated = validated
    End Sub

    Public Property Validated
End Class

Public Class DataGridCellChanged

    Public Sub New(ByVal index As Integer, ByVal columnName As String)
        Me.Index = index
        Me.ColumnName = columnName
    End Sub

    Public Property Index As Integer
    Public Property ColumnName As String

End Class