Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

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
            _employees = PresenterObj.GetLookup("Employee")
            _payGroups = PresenterObj.GetLookup("PayGroup")
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
                LoadEmployees(currentNode)
                currentNode.ExpandAll()
            End If

            If currentNode.Parent.Level > 1 Then

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

        Private Sub LoadEmployees(ByRef node As TreeNode)
            If node.Tag IsNot Nothing Then
                Dim Data = PresenterObj.GetRecords("Employee", "EmployeeName", {"IdNo", "EmployeeName", "PayGroupIdNo"})
                Dim lEmployeePayGroups As New List(Of EmployeePayGroups)
                For i = 1 To Int(Data.Count / 3)
                    Dim tData As New EmployeePayGroups
                    tData.IdNo = Data(i * 3 - 3)
                    tData.Name = Data(i * 3 - 2)
                    If Data(i * 3 - 1) Is DBNull.Value Then
                        tData.PayGroupIdNo = 0
                    Else
                        tData.PayGroupIdNo = Data(i * 3 - 1)
                    End If
                    lEmployeePayGroups.Add(tData)
                Next
                For Each employee In lEmployeePayGroups
                    If employee.PayGroupIdNo = node.Tag Then
                        node.Nodes.Add(New TreeNode With {.Text = employee.Name,
                                                   .Tag = employee.IdNo,
                                                   .Name = employee.Name
                                                 }
                              )
                    End If
                Next employee
            End If
        End Sub

        Private Class EmployeePayGroups
            Public IdNo As Int16
            Public Name As String
            Public PayGroupIdNo As Int16?
        End Class

    End Class

End Namespace