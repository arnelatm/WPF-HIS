' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

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

    Public MustInherit Class CommonPresenterNew(Of TV As IViewNew, TM As New)
        Inherits PresenterB(Of TV, TM)

        Protected Sub New()
            MyBase.New()
        End Sub

        Protected Sub New(itemView As IViewNew)
            MyBase.New(itemView)
        End Sub

        'Public Overrides Sub GoAddRecord()
        '    MyBase.GoAddRecord()
        '    MakeDefaultValues()
        'End Sub

    End Class

End Namespace