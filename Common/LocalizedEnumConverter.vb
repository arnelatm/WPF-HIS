Imports AATM.Libraries.EnumLocalization
Imports AATM.Libraries.Languages

Class LocalizedEnumConverter
    Inherits ResourceEnumConverter

    Public Sub New(type As Type)
        MyBase.New(type, My.Resources.ResourceManager)
    End Sub

End Class