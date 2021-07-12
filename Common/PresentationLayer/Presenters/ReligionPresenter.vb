Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class ReligionPresenter(Of TV As IView, TM As New)
        Inherits PresenterNew(Of IReligionView, TM)

        Public Sub New(view As IReligionView)
            MyBase.New(view)
            Service = New Service("Religion")
            TableName = "Religion"
            TreeViewMainField = "ReligionName"
            TreeViewSecondaryField = "ReligionCode"
            SortOrderKey = "IdNo"
            'OriginalModel = New ReligionModel()
            'model = New ReligionModel()
        End Sub

    End Class

End Namespace