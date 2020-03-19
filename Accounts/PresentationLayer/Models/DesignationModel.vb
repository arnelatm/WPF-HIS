Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DesignationModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property DesignationCode As String
        Public Property DesignationName As String
        Public Property DesignationNameAra As String
        Public Property Notes As String
    End Class

End Namespace