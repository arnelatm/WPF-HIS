Imports System.ComponentModel
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView

Namespace CascadingComboboBox
    Friend Class BankCB
        Public Property BankID As Integer
        Public Property BankName As String
        Public Property Branches As BindingList(Of BranchCB)

        Public Overrides Function ToString() As String
            Dim sb As StringBuilder = New StringBuilder()
            sb.AppendLine("----------------------------------------------------------")
            sb.AppendLine("BankID: " & BankID.ToString() & " Name: " & BankName & " Branches:...")
            If Branches.Count > 1 Then
                For Each branch In Branches
                    If branch.BranchID <> 0 Then
                        sb.AppendLine(branch.ToString())
                    End If
                Next
            Else
                sb.AppendLine("No Branches")
            End If
            Return sb.ToString()
        End Function
    End Class
End Namespace
