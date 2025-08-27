Imports System.Windows.Forms
Imports System.Collections

' Publicly accessible caption storage helper extracted so service layer can call it.
' NOTE: This is a reconstructed implementation because the original StoreCaptions1
'       definition was not found in the current workspace. Adjust logic as needed
'       if you recover the original code.
Public NotInheritable Class StoreCaptions1

    Private Sub New()
    End Sub

    ' Holds original text for a control (extend if you need additional metadata).
    <Serializable()>
    Private Class OriginalCaptionHolder
        Public Property OriginalText As String
        Public Sub New(txt As String)
            OriginalText = txt
        End Sub
    End Class

    ' Recursively capture control.Text values into a VB Collection keyed by control.Name.
    ' Returns: Collection (controlName -> originalText).
    Public Shared Function StoreTranslation(root As Control) As Collection
        Dim col As New Collection()
        If root Is Nothing Then Return col
        AddControlRecursive(root, col)
        Return col
    End Function

    ' Persist (or mark) original control texts. Here we stash the original text
    ' inside the control.Tag (if Tag is Nothing or not already our holder).
    ' If Tag is used elsewhere with another object, we do not overwrite it.
    Public Shared Sub SaveControlsOriginalText(root As Control)
        If root Is Nothing Then Exit Sub
        ApplyOriginalTextTagRecursive(root)
    End Sub

#Region "Internal helpers"
    Private Shared Sub AddControlRecursive(parent As Control, target As Collection)
        ' Add this control (skip empty names to avoid key collisions on default blank names)
        If Not String.IsNullOrEmpty(parent.Name) Then
            Dim textValue As String = parent.Text
            ' Avoid duplicate key exceptions
            Try
                target.Add(textValue, parent.Name)
            Catch
                ' Duplicate key: ignore silently (existing behavior in many legacy VB apps)
            End Try
        End If

        ' Recurse children
        For Each child As Control In parent.Controls
            AddControlRecursive(child, target)
        Next

        ' Also traverse composite items: MenuStrip, ToolStrip, etc.
        If TypeOf parent Is MenuStrip Then
            For Each tsi As ToolStripItem In DirectCast(parent, MenuStrip).Items
                AddToolStripItem(tsi, target)
            Next
        ElseIf TypeOf parent Is ToolStrip Then
            For Each tsi As ToolStripItem In DirectCast(parent, ToolStrip).Items
                AddToolStripItem(tsi, target)
            Next
        End If
    End Sub

    Private Shared Sub AddToolStripItem(item As ToolStripItem, target As Collection)
        If Not String.IsNullOrEmpty(item.Name) Then
            Try
                target.Add(item.Text, item.Name)
            Catch
            End Try
        End If
        If TypeOf item Is ToolStripMenuItem Then
            For Each dd As ToolStripItem In DirectCast(item, ToolStripMenuItem).DropDownItems
                AddToolStripItem(dd, target)
            Next
        End If
    End Sub

    Private Shared Sub ApplyOriginalTextTagRecursive(ctrl As Control)
        ' Only set our holder if Tag is Nothing or already an OriginalCaptionHolder.
        If ctrl IsNot Nothing Then
            If ctrl.Tag Is Nothing Then
                ctrl.Tag = New OriginalCaptionHolder(ctrl.Text)
            ElseIf TypeOf ctrl.Tag Is OriginalCaptionHolder Then
                ' Update if needed (in case text changed before tagging)
                DirectCast(ctrl.Tag, OriginalCaptionHolder).OriginalText = ctrl.Text
            End If
        End If

        For Each child As Control In ctrl.Controls
            ApplyOriginalTextTagRecursive(child)
        Next

        If TypeOf ctrl Is MenuStrip Then
            For Each tsi As ToolStripItem In DirectCast(ctrl, MenuStrip).Items
                ApplyOriginalTextTagToolStrip(tsi)
            Next
        ElseIf TypeOf ctrl Is ToolStrip Then
            For Each tsi As ToolStripItem In DirectCast(ctrl, ToolStrip).Items
                ApplyOriginalTextTagToolStrip(tsi)
            Next
        End If
    End Sub

    Private Shared Sub ApplyOriginalTextTagToolStrip(item As ToolStripItem)
        ' ToolStripItem does not have a Tag property in winforms by default, so we cannot store
        ' directly without reflection; skip tagging; only collection capture is performed.
        If TypeOf item Is ToolStripMenuItem Then
            For Each dd As ToolStripItem In DirectCast(item, ToolStripMenuItem).DropDownItems
                ApplyOriginalTextTagToolStrip(dd)
            Next
        End If
    End Sub
#End Region

End Class