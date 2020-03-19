Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    Public Class ModelCommon
        Inherits Model
        Implements IModelCommon

        Public Sub New(accountName As String)
            DataService = New ServiceCommon(accountName)
        End Sub

        Public Sub New()

        End Sub

        'Public Overrides Function GetDataService() Implements IModelCommon.GetDataService
        '    Return GetCommonService()
        'End Function

        'Public Overridable Function GetCommonService() Implements IModelCommon.GetCommonService
        '    Return New ServiceCommon()
        'End Function

    End Class

    'Public Class ModelBranch
    '    Inherits ModelCommon

    '    'Private ReadOnly _service As New ServiceBranch()
    '    Public Sub New()
    '        DataService = New ServiceBranch
    '    End Sub

    'End Class

    'Public Class ModelCostCenter
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceCostCenter
    '    End Sub

    'End Class

    'Public Class ModelCountry
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceCountry
    '    End Sub

    'End Class

    'Public Class ModelDepartment
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceDepartment
    '    End Sub

    'End Class

    'Public Class ModelOriginalMessages
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceOriginalMessages
    '    End Sub

    'End Class

    'Public Class ModelProfitCenter
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceProfitCenter
    '    End Sub

    'End Class

    'Public Class ModelReligion
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceReligion
    '    End Sub

    'End Class

    'Public Class ModelRevenueGroup
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceRevenueGroup
    '    End Sub

    'End Class

    'Public Class ModelTranslatedMessages
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServiceTranslatedMessages
    '    End Sub

    'End Class

    'Public Class ModelPhoneType
    '    Inherits ModelCommon

    '    Public Sub New()
    '        DataService = New ServicePhoneType
    '    End Sub

    'End Class

End Namespace