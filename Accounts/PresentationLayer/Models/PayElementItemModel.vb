Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayElementItemModel

        Public Property ParentIdNo As Int16
        Public Property PayElementIdNo As Int16
        Public Property IdNo As Int16
        Public Property FactorType As String
        Public Property FactorValue As Decimal
        Public Property Sequence As Int16
    End Class

End Namespace