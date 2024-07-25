Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayGroupModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property LevelNumber As Int16
        Public Property ParentIdNo As Int16?
        Public Property PayGroupCode As String
        Public Property PayGroupName As String
        Public Property PayGroupNameAra As String
        Public Property RevCostCenterIdNo As Int16
        Public Property SortKey As String
        Public Property Notes As String
    End Class

End Namespace