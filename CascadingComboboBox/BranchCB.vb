
Namespace CascadingComboboBox
    Friend Class BranchCB
        Public Property BranchID As Integer
        Public Property BranchName As String

        Public Shared ReadOnly Property BlankBranch As BranchCB
            Get
                Return New BranchCB With {
                    .BranchID = 0,
                    .BranchName = ""
                }
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return "BranchID: " & BranchID.ToString() & " Name: " & BranchName
        End Function
    End Class
End Namespace
