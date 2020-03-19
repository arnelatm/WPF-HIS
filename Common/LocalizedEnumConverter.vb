Imports AATM.Libraries.EnumLocalization

Class LocalizedEnumConverter
    Inherits ResourceEnumConverter

    Public Sub New(type As Type)
        MyBase.New(type, My.Resources.ResourceManager)
    End Sub

End Class