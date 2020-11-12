Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class PayrollTvEntry
        Implements IPayPeriodView

        Private _bypassSelectedChange As Boolean = False
        Private _employees
        Private _payGroups

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            ' GlobalVariables.EventAggregator.SubscribeEvent(Me)
            ' Add any initialization after the InitializeComponent() call.
            trvTreeView = trvPayPeriods
            MainTableName = "PayPeriod"
            TvMainFieldName = "PayPeriodName"
            TvSecondaryFieldName = "PayPeriodCode"
            SortOrderKey = "SortKey"
            FirstControl = txtIdNo
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PayPeriodPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            _employees = PresenterObj.GetListByName("Employee")
            _payGroups = PresenterObj.GetListByName("PayGroup")
        End Sub

#Region "Fields"

        Public Property EndDate As Date Implements IPayPeriodView.EndDate
        Public Property IdNo As Int32 Implements IPayPeriodView.IdNo

        Public Property PayCycleIdNo As Int16 Implements IPayPeriodView.PayCycleIdNo

        Public Property PayPeriodCode As String Implements IPayPeriodView.PayPeriodCode
        Public Property PayPeriodName As String Implements IPayPeriodView.PayPeriodName
        Public Property PayPeriodNameAra As String Implements IPayPeriodView.PayPeriodNameAra
        Public Property StartDate As Date Implements IPayPeriodView.StartDate

#End Region

        Protected Sub PayrollTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvTreeView.AfterSelect
            Dim currentNode = trvTreeView.SelectedNode
            If currentNode.Parent.Level = 0 And currentNode.Nodes.Count = 0 Then
                LoadPayGroups(currentNode)
                currentNode.ExpandAll()
            End If
            If currentNode.Parent.Level = 1 And currentNode.Nodes.Count = 0 Then
                LoadEmployees(currentNode, 1)
                currentNode.ExpandAll()
            End If
        End Sub

        Private Sub LoadPayGroups(ByRef node As TreeNode)
            For Each payGroup In _payGroups
                node.Nodes.Add(New TreeNode With {.Text = payGroup.Name,
                                                   .Tag = payGroup.idNo,
                                                   .Name = payGroup.idNo
                                                 }
                              )
            Next payGroup
        End Sub

        Private Sub LoadEmployees(ByRef node As TreeNode, ByVal payGroupIdNo As Int16?)
            If payGroupIdNo IsNot Nothing Then
                For Each employee In _employees
                    node.Nodes.Add(New TreeNode With {.Text = employee.Name,
                                                       .Tag = employee.idNo,
                                                       .Name = employee.idNo
                                                     }
                                  )
                Next employee
            End If
        End Sub

    End Class

End Namespace