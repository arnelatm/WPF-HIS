Namespace PresentationLayer.Models

    Public Class RevenueGroupModel
        Inherits CommonModel

        Public Property IdNo As Int16
        Public Property ParentIdNo As Int16?
        Public Property RevenueGroupCode As String
        Public Property RevenueGroupName As String
        Public Property RevenueGroupNameAra As String
        Public Property LevelNumber As Int16
        Public Property Notes As String
        Public Property SortKey As String
    End Class

End Namespace