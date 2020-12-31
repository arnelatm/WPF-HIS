Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelCommon
        Inherits Model
        Implements IModelCommon

        Public Sub New(accountName As String, Optional bizParam As Object = Nothing, Optional daoParam As Object = Nothing)
            DataService = New ServiceCommon(accountName, bizParam, daoParam)
        End Sub

        Public Sub New()
        End Sub

    End Class

End Namespace