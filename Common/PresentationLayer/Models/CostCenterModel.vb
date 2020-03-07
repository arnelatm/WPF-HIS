
Namespace PresentationLayer.Models
    Public Class CostCenterModel
        Inherits CommonModel

        Public Property ParentIdNo As Integer?
        Public Property CostCenterCode As String
        Public Property CostCenterName As String
        Public Property CostCenterNameAra As String
        Public Property ProfitCenterIdNo As Integer
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String
    End Class
End NameSpace