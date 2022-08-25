Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayGroupPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPayGroupView, TM)

        Public Sub New(itemView As IPayGroupView)
            MyBase.New(itemView)
            Service = New AccountsService("PayGroup")
            TableBaseName = "PayGroup"
            TableName = "PayGroup_View"
            TreeViewMainField = "PayGroupName"
            TreeViewSecondaryField = "PayGroupCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("PayGroup", "ParentIdNo")
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                If EditMode And View.ParentIdNo = View.IdNo Then
                    Messaging.Show(True, "MsgMemberCannotBeAParentToItself")
                Else
                    retValue = True
                End If
            End If
            Return retValue
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "PayGroupIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "PayElementAccont") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace