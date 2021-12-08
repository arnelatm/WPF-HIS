Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DesignationPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IDesignationView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IDesignationView)
            MyBase.New(view)
            Service = New AccountsService("Designation")
            TableName = "Designation"
            SortOrderKey = "DesignationName"
            TreeViewMainField = "DesignationName"
            TreeViewSecondaryField = "DesignationCode"
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "DesignationIdNo") Then
                Return True
            End If
            Return False
        End Function
    End Class

End Namespace