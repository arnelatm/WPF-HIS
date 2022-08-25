Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeeDocumentView
        Implements IEmployeeDocumentView

        Public Property IdNo As Short Implements IEmployeeDocumentView.IdNo

        Public Property EmployeeIdNo As Short Implements IEmployeeDocumentView.EmployeeIdNo

        Public Property DocumentIdNo As Short Implements IEmployeeDocumentView.DocumentIdNo

        Public Property ExpiryDate As Date? Implements IEmployeeDocumentView.ExpiryDate

        Public Property IssueDate As Date? Implements IEmployeeDocumentView.IssueDate

        Public Property Number As String Implements IEmployeeDocumentView.Number

        Public Property Notes As String Implements IEmployeeDocumentView.Notes

        Public Property Image As Image Implements IEmployeeDocumentView.Image

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace