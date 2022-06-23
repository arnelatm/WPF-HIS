Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    '' <summary>
    ''     The Model in MVP design pattern.
    ''     Implements IModel and communicates with WCF Service.
    '' </summary>

  
    Public Class Lab_InvoiceGroupModel
        Property InvoiceNo As Decimal
        Property InvoiceType As String
        Property InvoiceDate As Date
        Property PatientNameEnglish As String
        Property AgeYMD As String
        Property Age As Int16
        Property Sex As String
        Property RegistrationNo as Decimal
        Property Remarks as String
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