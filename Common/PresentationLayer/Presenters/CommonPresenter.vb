' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Presentation.Presenters
Imports AATM.Presentation.Views

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenter(Of TV As IView, TM As New)
        Inherits Presenter(Of TV, TM)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

    End Class


End Namespace