Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces.IGroup

    Public Interface IPmrPatientDisplayView
        Inherits IView

        Property [Token] As String
        Property [Status] As String
        Property [File_No] As String
        Property [Name] As String
        Property [Type]
        Property [Inv_Type]
        Property [CreateDate]

    End Interface

End Namespace