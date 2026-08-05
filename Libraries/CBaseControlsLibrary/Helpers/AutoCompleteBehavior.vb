Imports System.Windows.Forms

Public Class AutoCompleteBehavior
    Private ReadOnly _comboBox As ComboBox
    Private previousSearchterm As String
    Private originalList As Object()

    Public Sub New(ByVal comboBox As ComboBox)
        _comboBox = comboBox
        _comboBox.AutoCompleteMode = AutoCompleteMode.Suggest
        '_comboBox.TextChanged += AddressOf Me.OnTextChanged
        '_comboBox.KeyPress += AddressOf Me.OnKeyPress
        '_comboBox.SelectionChangeCommitted += AddressOf Me.OnSelectionChangeCommitted
    End Sub

    Private Sub OnSelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        If Me._comboBox.SelectedItem Is Nothing Then
            Return
        End If

        Dim sel = Me._comboBox.SelectedItem
        Me.ResetCompletionList()
        Me._comboBox.SelectedItem = sel
    End Sub

    Private Sub OnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not String.IsNullOrEmpty(Me._comboBox.Text) OrElse Not Me._comboBox.Visible OrElse Not Me._comboBox.Enabled Then
            Return
        End If

        Me.ResetCompletionList()
    End Sub

    Private Sub OnKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If e.KeyChar = vbCr OrElse e.KeyChar = vbLf Then
            e.Handled = True

            If Me._comboBox.SelectedIndex = -1 AndAlso Me._comboBox.Items.Count > 0 AndAlso Me._comboBox.Items(0).ToString().ToLowerInvariant().StartsWith(Me._comboBox.Text.ToLowerInvariant()) Then
                Me._comboBox.Text = Me._comboBox.Items(0).ToString()
            End If

            Me._comboBox.DroppedDown = False
            Return
        End If

        Me._comboBox.BeginInvoke(New Action(AddressOf Me.ReevaluateCompletionList))
    End Sub

    Private Sub ResetCompletionList()
        Me.previousSearchterm = Nothing

        Try
            Me._comboBox.SuspendLayout()

            If Me.originalList Is Nothing Then
                Me.originalList = Me._comboBox.Items.Cast(Of Object)().ToArray()
            End If

            If Me._comboBox.Items.Count = Me.originalList.Length Then
                Return
            End If

            While Me._comboBox.Items.Count > 0
                Me._comboBox.Items.RemoveAt(0)
            End While

            Me._comboBox.Items.AddRange(Me.originalList)
        Finally
            Me._comboBox.ResumeLayout(True)
        End Try
    End Sub

    Private Sub ReevaluateCompletionList()
        Dim currentSearchterm = Me._comboBox.Text.ToLowerInvariant()

        If currentSearchterm = Me.previousSearchterm Then
            Return
        End If

        Me.previousSearchterm = currentSearchterm

        Try
            Me._comboBox.SuspendLayout()

            If Me.originalList Is Nothing Then
                Me.originalList = Me._comboBox.Items.Cast(Of Object)().ToArray()
            End If

            Dim newList As Object()

            If String.IsNullOrEmpty(currentSearchterm) Then

                If Me._comboBox.Items.Count = Me.originalList.Length Then
                    Return
                End If

                newList = Me.originalList
            Else
                newList = Me.originalList.Where(Function(x) x.ToString().ToLowerInvariant().Contains(currentSearchterm)).ToArray()
            End If

            Try

                While Me._comboBox.Items.Count > 0
                    Me._comboBox.Items.RemoveAt(0)
                End While

            Catch

                Try
                    Me._comboBox.Items.Clear()
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            End Try

            Me._comboBox.Items.AddRange(newList.ToArray())
        Finally

            If currentSearchterm.Length >= 1 AndAlso Not Me._comboBox.DroppedDown Then
                Me._comboBox.DroppedDown = True
                Cursor.Current = Cursors.[Default]
                Me._comboBox.Text = currentSearchterm
                Me._comboBox.[Select](currentSearchterm.Length, 0)
            End If

            Me._comboBox.ResumeLayout(True)
        End Try
    End Sub
End Class

