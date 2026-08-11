Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views.Interfaces
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class MainPresenter(Of TM As New)
        Inherits Presenter(Of IUserView, TM)

        Public Sub New(ByVal view As IUserView)
            MyBase.New(view)
            Service = New Service("User")
            TableName = "User"
        End Sub

    End Class

End Namespace
