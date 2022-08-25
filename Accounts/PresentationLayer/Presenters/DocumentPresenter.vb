Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DocumentPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDocumentView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IDocumentView)
            MyBase.New(view)
            Service = New AccountsService("Document")
            TableName = "Document"
            SortOrderKey = "DocumentName"
            TreeViewMainField = "DocumentName"
            'TreeViewSecondaryField = "DocumentCode"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of DocumentTypeSelection)("DocumentType")
            CreateEnumDataSource(Of ImageTypeSelection)("ImageType")           
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "DocumentIdNo") Then
                Return True
            End If
            Return False
        End Function

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And GlobalFunctions.IsEmpty(View.DocumentCode) Then
                retVal = Service.GenerateCode(View.IdNo)
                View.DocumentCode = Service.GetFieldWithIdNo(View.IdNo, "Document", "DocumentCode")
            End If
        End Sub

    End Class

End Namespace