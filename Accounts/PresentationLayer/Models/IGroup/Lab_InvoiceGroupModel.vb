Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    '' <summary>
    ''     The Model in MVP design pattern.
    ''     Implements IModel and communicates with WCF Service.
    '' </summary>

    'Public Class CbcRetrievalModel
    '    'Implements IModelNew

    '    Property WbcR As String
    '    Property NeR As String
    '    Property LyR As String
    '    Property MoR As String
    '    Property EoR As String
    '    Property BaR As String
    '    Property RbcR As String
    '    Property HgbR As String
    '    Property HctR As String
    '    Property McvR As String
    '    Property MchR As String
    '    Property MchcR As String
    '    Property RdwcvR As String
    '    Property RdwcdR As String
    '    Property PltR As String
    '    Property PctR As String
    '    Property MpvR As String
    '    Property PdwR As String
    'End Class

    Public Class Lab_InvoiceGroupModel
        Property InvoiceNo As String
        Property InvoiceType As String
        Property InvoiceDate As Date
        Property PatientNameEnglish As String
        Property Age As Int16
        Property AgeYMD As String
        Property Sex As String
        Property RegistrationNo as Decimal
        Property SampleNo as String
        Property Status as Int32
        Property LabInvoiceDetails As List(Of Lab_InvoiceDetailsModel)
    End Class

    Public Class Lab_InvoiceDetailsModel
        Property Group_Key As Decimal
        Property SlNo As Decimal
        Property Diagnosis1 As String
        Property Result1 As String
        Property Suffix1 As String
    End Class

End Namespace