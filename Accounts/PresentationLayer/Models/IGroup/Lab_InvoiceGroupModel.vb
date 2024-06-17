Namespace PresentationLayer.Models

    '' <summary>
    ''     The Model in MVP design pattern.
    ''     Implements IModel and communicates with WCF Service.
    '' </summary>

    Public Class Lab_InvoiceGroupModel
        Public Property InvoiceNo As Decimal
        Public Property InvoiceType As String
        Public Property InvoiceDate As Date
        Public Property PatientNameEnglish As String
        Public Property AgeYMD As String
        Public Property Age As Int16
        Public Property Sex As String
        Public Property RegistrationNo As Decimal
        Public Property Remarks As String
        Public Property SampleNo As String
        Public Property Status As Int32
        Public Property LabInvoiceDetails As List(Of Lab_InvoiceDetailsModel)
    End Class

    Public Class Lab_InvoiceDetailsModel
        Public Property Group_Key As Decimal
        Public Property SlNo As Decimal
        Public Property Diagnosis1 As String
        Public Property Result1 As String
        Public Property Suffix1 As String
    End Class

End Namespace