Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters
    Public Class ContactPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IContactView, TM)

        Public Sub New(view As IContactView)
            MyBase.New(view)
            Service = New AccountsService("Contact")
            TableName = "Contact_View"
            TableBaseName = "Contact"
            SortOrderKey = "ContactName"
            TreeViewMainField = "ContactName"
            TreeViewSecondaryField = "ContactCode"
        End Sub

        Public Overrides Function GetTreeViewData() As Object
            ' Read the form's selected language on every tree load, including switches.
            TreeViewMainField = If(View.UseArabicNames, "ContactNameAra", "ContactName")
            SortOrderKey = TreeViewMainField
            Return MyBase.GetTreeViewData()
        End Function

        Public Overrides Function GetRecordDateTimeStamp(idNo As Int32) As Object
            ' Contact_View has no timestamp; this viewer never saves records.
            Return Nothing
        End Function

        ' Contacts are maintained by their source records, never by this viewer.
        Public Overrides Sub GoAddRecord()
        End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            Return False
        End Function

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Return False
        End Function

        Public Overrides Function GoDeleteRecord() As Integer
            Return -1
        End Function

        Protected Overrides Function DeleteRecordCore(idNo As Int32) As Integer
            Return -1
        End Function

        Public Overrides Function Save(ByRef viewControl As Control) As Boolean
            Return False
        End Function
    End Class
End Namespace
