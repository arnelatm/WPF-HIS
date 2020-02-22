
Imports AATM.BusinessLayer.BusinessObject
Imports AATM.ServiceLayer.Services
''' <summary>
'''     The Model in MVP design pattern.
'''     Implements IModel and communicates with WCF Service.
''' </summary>
Public Class DefaultFieldValueDisplayModel
    Inherits ModelOld
    Implements IModelOld

    Public Sub New()
        BizObject = New DefaultFieldValue
        Service = New DefaultFieldValueService()
    End Sub
End Class