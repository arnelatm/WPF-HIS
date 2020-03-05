Imports AATM.ServicesLayer.Services

Public Class ModelCommon
    Inherits Model
    Implements IModelCommon

    Public Overrides Function GetDataService()
        Return GetCommonService()
    End Function

    Public Overridable Function GetCommonService()
        Return New ServiceCommon()
    End Function

End Class