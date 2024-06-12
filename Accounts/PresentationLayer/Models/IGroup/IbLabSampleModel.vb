' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace PresentationLayer.Models


    Public Class IbLabSampleModel
        Property TransactionDate As Date
        Property IbLabSampleDetails As List(Of IbLabSampleDetailModel)
    End Class



    Public Class IbLabSampleDetailModel

        Public Property Age As Decimal
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property Nationality As String
        Public Property PatientName As String
        Public Property Rbs As Decimal
        Public Property Sequence As Int32
        Public Property Stool As Boolean
        Public Property TakenBy As String
        Public Property TakenDate As Date
        Public Property TakenTime As String
        Public Property Urine As Boolean
    End Class


    Public Class IbLabResultModel
        Property TransactionDate As Date
        Property IbLabResultDetails As List(Of IbLabResultDetailModel)
    End Class

    Public Class IbLabResultDetailModel
        Public Property BilharziasisStool As Boolean?
        Public Property BilharziasisUrine As Boolean?
        Public Property Cholera As Boolean?
        Public Property Clinical As Boolean?
        Public Property Gender As String
        Public Property HBSAgEliza As Boolean?
        Public Property HIVEliza As Boolean?
        Public Property HCVEliza As Boolean?
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property Malaria As Boolean?
        Public Property Nationality As String
        Public Property PassportNumber As String
        Public Property PatientName As String
        Public Property Pregnancy As Boolean?
        Public Property Profession As String
        Public Property Sequence As Int32
        Public Property Shigella As Boolean?
        Public Property TBSputum As Boolean?
        Public Property TransKey As Int32
        Public Property VDRL As Boolean?
        Public Property Widal As Boolean?
        Public Property XRay As Boolean?
    End Class

End Namespace
