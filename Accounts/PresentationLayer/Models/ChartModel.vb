Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ChartModel

        Public Property Errors As List(Of String)
        Public Property AccountCode As String
        Public Property AccountGroup As String
        Public Property AccountName As String
        Public Property AccountNameAra As String
        Public Property Active As Boolean
        Public Property DetailAccount As Boolean
        Public Property IdNo As Int32
        Public Property LevelNumber As Int16
        Public Property NormalBalance As String
        Public Property Notes As String
        Public Property ParentIdNo As Int32?
        Public Property PayeeType As String
        Public Property SortKey As String
        Public Property SpecialAccount As String
        Public Property WithReconciliation As Boolean
    End Class

End Namespace