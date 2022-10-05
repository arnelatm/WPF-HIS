Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPmrPatientDisplayView
        Inherits IView

        Property [Token] As String
        Property [Status] As String
        Property [File_No] As String
        Property [Name] As String
        Property [Type] As String
        Property [Inv_Type] As String
        Property [CreateDate] As DateTime

    End Interface

End Namespace