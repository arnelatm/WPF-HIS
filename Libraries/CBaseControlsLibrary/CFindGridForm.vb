Imports AATM.Libraries.AatmInterfaces

Public Class CFindGridForm
    Inherits CFindForm

    Private _dgView As CtDataGridView

    Public Sub New(findableControl As IFindableControl)
        MyBase.New(findableControl)
    End Sub

End Class