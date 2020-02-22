Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IChartView
        Inherits IView
        Property AccountCode As String
        Property AccountGroup As String
        Property AccountName As String
        Property AccountNameAra As String
        Property Active As Boolean
        Property DetailAccount As Boolean
        Property IdNo As Integer
        Property LevelNumber As Int16
        Property NormalBalance As String
        Property Notes As String
        Property ParentIdNo As Integer?
        Property PayeeType As String
        Property SortKey As String
        Property SpecialAccount As String
        Property WithReconciliation As Boolean
    End Interface
End NameSpace