Namespace PresentationLayer.Models

    Public Class RevCostCenterModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property ParentIdNo As Int16?
        Public Property RevCostCenterCode As String
        Public Property RevCostCenterName As String
        Public Property RevCostCenterNameAra As String
        Public Property RCType As String
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String
    End Class

End Namespace