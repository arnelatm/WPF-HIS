Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PayGroupPresenter
        Inherits AccountsPresenter(Of IPayGroupView, PayGroupModel)

        Public ParentViewList As List(Of PayGroupModel)

        Public Sub New(view As IPayGroupView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PayGroup")
            TableName = "PayGroup_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "PayGroupName"
            TreeViewSecondaryField = "PayGroupCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New PayGroupModel()
            DataModel = New PayGroupModel
            TreeViewList = New List(Of PayGroupModel)
            ParentViewList = New List(Of PayGroupModel)
            'InitializerWithTv("PayGroup")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If GetEnumCodeValue(Of PayGroupTypeSelection)(View.PayGroupType) = PayGroupTypeSelection.Others Then

        '    End If
        'End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue = False
        '    If MyBase.IsBizDataValid() Then
        '        If View.PayGroupType = EnumCode(PayGroupTypeSelection.Others) Then
        '            View.PayGroupType =
        '        End If
        '    End If
        '    Return retValue
        'End Function

    End Class

End Namespace