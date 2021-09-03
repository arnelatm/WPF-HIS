' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services
Imports AutoMapper

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenterNew(Of TV As IView, TM As New)
        Inherits PresenterNew(Of TV, TM)

        'Shared Sub New()
        '    DefaultFieldValueService = New Service("DefaultFieldValue")
        'End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)

        End Sub

        Protected Sub New()
            MyBase.New()
        End Sub

        'Public Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

    End Class

End Namespace