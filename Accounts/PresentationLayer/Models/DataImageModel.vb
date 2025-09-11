Imports AATM.Presentation.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DataImageModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Image As Image
        
    End Class

End Namespace