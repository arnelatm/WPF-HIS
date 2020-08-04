Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class ChartPresenter
        Inherits AccountsPresenter(Of IChartView, ChartModel)

        Public ParentViewList As List(Of ChartModel)

        Public Sub New(view As IChartView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("Chart")
            TableName = "Chart_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "AccountName"
            TreeViewSecondaryField = "AccountCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New ChartModel()
            DataModel = New ChartModel
            TreeViewList = New List(Of ChartModel)
            ParentViewList = New List(Of ChartModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function EditableAccountGroup(ByVal idNo As Int32?, ByVal parentIdNo As Int32?) As Boolean
            If AccountHasChildren(idNo) Then
                return False
            Else
                Dim parentAccount As ChartModel
                parentAccount = ModelPresenter.GetRecordById(Of ChartModel)(parentIdNo)
                If parentAccount.AccountGroup Is Nothing Then
                    return False
                Else
                    If parentAccount.AccountGroup = "S" Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
            'Dim accountGroup As String
            'If idNo Is Nothing Then
            '    Return True
            'End If
            'accountGroup = Model.GetRecordFieldWithKeyG(Of String)(idNo, "Chart", "IdNo", "AccountGroup")
            'If accountGroup = "S" Then
            '    Return True
            'End If
            'Return False
        End Function

        Public Function AccountHasChildren(ByVal idNo As Int32?) As Boolean
            If idNo Is Nothing Then
                Return True
            End If
            Return Model.CountRecordWithKey(idNo, "Chart", "ParentIdNo") > 0
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Chart", "ParentIdNo", "AccountName")
        End Function

    End Class

End Namespace