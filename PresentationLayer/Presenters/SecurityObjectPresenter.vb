Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Views.Interfaces
Imports AATM.ServicesLayer.Services

Public Class SecurityObjectPresenter(Of TM As New)
    Inherits Presenter(Of ISecurityObjectView, TM)

    Public Sub New(view As ISecurityObjectView)
        MyBase.New(view)
        Service = New Service("SecurityObject")
        TableName = "SecurityObject_View"
        TableBaseName = "SecurityObject"
        SortOrderKey = "SortKey"
        TreeViewMainField = "SecurityObjectName"
        TreeViewSecondaryField = "IdNo"
        ParentFieldName = "ParentIdNo"
    End Sub

    Protected Overrides Sub CreateDataSources()
        MakeControlDataSources({New Object() {"SystemView", "SystemViewIdNo", Nothing, Nothing},
                             New Object() {"SecurityObject", "ParentIdNo", Nothing, Nothing}})
    End Sub

    Protected Overrides Function IsBizDataValid() As Boolean
        Dim retValue = False
        If MyBase.IsBizDataValid() Then
            If EditMode And View.ParentIdNo = View.IdNo Then
                MessagingService.Show(True, "MsgMemberCannotBeAParentToItself")
            Else
                retValue = True
            End If
        End If
        Return retValue
    End Function

    Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        'Dim passedValue As Integer = retVal
        If retVal >= 0 And GlobalFunctions.IsEmpty(View.SecurityObjectCode) Then
            retVal = Service.GenerateCode(View.IdNo)
            View.SecurityObjectCode = Service.GetFieldWithIdNo(View.IdNo, "SecurityObject", "SecurityObjectCode")
        End If
    End Sub


End Class