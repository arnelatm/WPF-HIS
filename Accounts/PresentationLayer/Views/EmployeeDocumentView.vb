Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeDocumentView
        Implements IEmployeeDocumentView

        Private _imageFileName As String

        Public Property Changed As Boolean Implements IEmployeeDocumentView.Changed
        Public Property DataImageIdNo As Int32 Implements IEmployeeDocumentView.DataImageIdNo
        Public Property DocumentIdNo As Int16 Implements IEmployeeDocumentView.DocumentIdNo
        Public Property DocumentNumber As String Implements IEmployeeDocumentView.DocumentNumber
        Public Property EmployeeIdNo As Int32 Implements IEmployeeDocumentView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property ExpiryDate As Date? Implements IEmployeeDocumentView.ExpiryDate
        Public Property IdNo As Int32 Implements IEmployeeDocumentView.IdNo

        Public Property ImageFileName As String Implements IEmployeeDocumentView.ImageFileName
            Get
                Return _imageFileName
            End Get
            Set(value As String)
                If DataImageIdNo <= 0 Then
                    If value IsNot Nothing Then
                        DataImageIdNo = -1
                    ElseIf value = "" Then
                        DataImageIdNo = 0
                    End If
                End If
                _imageFileName = value
            End Set
        End Property

        Public Property IssueDate As Date? Implements IEmployeeDocumentView.IssueDate
        Public Property Sequence As Int16 Implements IEmployeeDocumentView.Sequence
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace