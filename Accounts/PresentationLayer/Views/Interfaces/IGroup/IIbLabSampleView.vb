Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IIbLabSampleView
        Inherits IView

        Property TransactionDate As Date?
        Property IbLabSampleDetails As List(Of IbLabSampleDetailView)
        Event IbLabSamplesRequested(transactionDate As Date?)
        Event IbLabSampleChanged(bindingSource As BindingSource)
    End Interface



    Public Interface IIbLabSampleDetailView
        Inherits IView

        Property Age As Decimal
        Property IdNo As Int32
        Property IqamaNo As String
        Property LabNo As String
        Property Nationality As String
        Property PatientName As String
        Property Rbs As Decimal
        Property Sequence As Int32
        Property Stool As Boolean
        Property TakenBy As String
        Property TakenDate As Date
        Property TakenTime As String
        Property Urine As Boolean
    End Interface

    Public Interface IIbLabResultView
        Inherits IView

        Property TransactionDate As Date?
        Property IbLabResultDetails As List(Of IbLabResultDetailView)
        Event IbLabResultRequested(transactionDate As Date?)
        Event IbLabResultChanged(bindingSource As BindingSource)

    End Interface

    Public Interface IIbLabResultDetailView
        Inherits IView

        Property BilharziasisStool As Boolean
        Property BilharziasisUrine As Boolean
        Property Cholera As Boolean
        Property Clinical As Boolean
        Property HBSAgEliza As Boolean
        Property HIVEliza As Boolean
        Property HOVEliza As Boolean
        Property IdNo As Int32
        Property IqamaNo As String
        Property LabNo As String
        Property Malaria As Boolean
        Property Nationality As String
        Property PassportNumber As String
        Property PatientName As String
        Property Pregnancy As Boolean
        Property Profession As Boolean
        Property Sequence As Int32
        Property Shigella As Boolean
        Property TBSputum As Boolean
        Property TransKey As Int32
        Property VDRL As Boolean
        Property Widal As Boolean
        Property XRay As Boolean

    End Interface

End Namespace