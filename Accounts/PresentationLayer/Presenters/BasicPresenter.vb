Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class BasicPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IBasicView, TM)

        Private ReadOnly PresenterView
        Private _limitToBranch As Boolean

        Public Sub New(view As IBasicView, tableOrViewName As String)
            MyBase.New(view)
            If Accounts.AccountHelpers.LimitToBranch(tableOrViewName) Then
                DataFilter = "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString()
            Else
                DataFilter = ""
            End If
            'Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Models.ModelAccounts"
            TableName = tableOrViewName
            WithTreeView = False
            Service = New AccountsService("Basic", , tableOrViewName)
            If AutoGenerateCode(TableName) Then
                view.AutoCode = True
            Else
                view.AutoCode = False
            End If
        End Sub

        Public Sub UpdateCode(ByVal retVal As Integer) Handles MyBase.GenerateCode
            If AutoGenerateCode(TableName) Then
                If retVal >= 0 And IsEmpty(View.Code) Then
                    Service.GenerateCode(View.IdNo)
                    Dim code = Service.GetFieldWithIdNo(View.IdNo, TableName, TableName + "Code")
                    View.Code = IIf(IsDBNull(code), Nothing, code)
                End If
            End If
        End Sub

    End Class

End Namespace