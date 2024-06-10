' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports AATM.BusinessLayer

Namespace BusinessLayer


    Public Class IbLabSample
        Inherits AATM.BusinessLayer.BusinessObject
        Public Property TransactionDate As Date
        Public Property IbLabSampleDetails As List(Of IbLabSampleDetail)
    End Class



    Public Class IbLabSampleDetail
        Inherits BusinessObject

        Public Sub New()

        End Sub

        Public Property Age As Decimal
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property Nationality As String
        Public Property PatientName As String
        Public Property Sequence As Int32
        Public Property TransKey As Int32
        Public Property TakenDate As Date
        Public Property TakenTime As String
        Public Property TakenBy As String
        Public Property Urine As Boolean
        Public Property Stool As Boolean
        Public Property Rbs As Decimal
    End Class

    Public Class IbLabResult
        Inherits BusinessObject

        Public Sub New()

        End Sub

        Public Property TransactionDate As Date
        Public Property IbLabResultDetails As List(Of IbLabResultDetail)

    End Class

    Public Class IbLabResultDetail
        Inherits BusinessObject

        Public Property BilharziasisStool As Boolean?
        Public Property BilharziasisUrine As Boolean?
        Public Property Cholera As Boolean?
        Public Property Clinical As Boolean?
        Public Property Gender As Char
        Public Property HBSAgEliza As Boolean?
        Public Property HIVEliza As Boolean?
        Public Property HOVEliza As Boolean?
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