Imports AATM.BusinessLayer.BusinessRules

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>

    Public Class AppSettingModel

        Public Property IdNo As Int32
        Public Property AppSettingGroupIdNo As Int16
        Public Property Selector1IdNo As Int32
        Public Property Selector2IdNo As Int32
        Public Property SettingValue As String

    End Class

End Namespace