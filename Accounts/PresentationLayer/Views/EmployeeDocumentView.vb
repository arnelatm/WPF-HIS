Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeDocumentView
        Implements IEmployeeDocumentView

        Public Property IdNo As Int32 Implements IEmployeeDocumentView.IdNo

        Public Property EmployeeIdNo As Int32 Implements IEmployeeDocumentView.EmployeeIdNo

        Public Property DocumentIdNo As Int16 Implements IEmployeeDocumentView.DocumentIdNo
        Public Property DocumentNumber As String Implements IEmployeeDocumentView.DocumentNumber

        Public Property ExpiryDate As Date? Implements IEmployeeDocumentView.ExpiryDate

        Public Property IssueDate As Date? Implements IEmployeeDocumentView.IssueDate

        Public Property DocumentImage As Int32 Implements IEmployeeDocumentView.DocumentImage

        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property Sequence As Int16 Implements IEmployeeDocumentView.Sequence

    End Class

End Namespace