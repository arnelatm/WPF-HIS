Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class IbLabSampleDetailView
        Implements IIbLabSampleDetailView
        Public Property Age As Decimal Implements IIbLabSampleDetailView.Age
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Integer Implements IIbLabSampleDetailView.IdNo
        Public Property InvoiceNo As Integer Implements IIbLabSampleDetailView.InvoiceNo
        Public Property IqamaNo As String Implements IIbLabSampleDetailView.IqamaNo
        Public Property LabNo As String Implements IIbLabSampleDetailView.LabNo
        Public Property Nationality As String Implements IIbLabSampleDetailView.Nationality
        Public Property PatientName As String Implements IIbLabSampleDetailView.PatientName
        Public Property Rbs As Decimal Implements IIbLabSampleDetailView.Rbs
        Public Property Sequence As Integer Implements IIbLabSampleDetailView.Sequence
        Public Property Stool As Boolean Implements IIbLabSampleDetailView.Stool
        Public Property TakenBy As String Implements IIbLabSampleDetailView.TakenBy
        Public Property TakenDate As Date Implements IIbLabSampleDetailView.TakenDate
        Public Property TakenTime As String Implements IIbLabSampleDetailView.TakenTime
        Public Property Trans_Key As Int32 Implements IIbLabSampleDetailView.Trans_key
        Public Property Urine As Boolean Implements IIbLabSampleDetailView.Urine
    End Class

    Public Class IbLabResultDetailView
        Implements IIbLabResultDetailView

        Public Property BilharziasisStool As Boolean? Implements IIbLabResultDetailView.BilharziasisStool
        Public Property BilharziasisUrine As Boolean? Implements IIbLabResultDetailView.BilharziasisUrine
        Public Property Cholera As Boolean? Implements IIbLabResultDetailView.Cholera
        Public Property Clinical As Boolean? Implements IIbLabResultDetailView.Clinical
        Public Property Gender As Char? Implements IIbLabResultDetailView.Gender
        Public Property HBSAgEliza As Boolean? Implements IIbLabResultDetailView.HBSAgEliza
        Public Property HIVEliza As Boolean? Implements IIbLabResultDetailView.HIVEliza
        Public Property HCVEliza As Boolean? Implements IIbLabResultDetailView.HCVEliza
        Public Property IdNo As Integer Implements IIbLabResultDetailView.IdNo
        Public Property IqamaNo As String Implements IIbLabResultDetailView.IqamaNo
        Public Property InvoiceNo As Int32 Implements IIbLabResultDetailView.InvoiceNo
        Public Property LabNo As String Implements IIbLabResultDetailView.LabNo
        Public Property Malaria As Boolean? Implements IIbLabResultDetailView.Malaria
        Public Property Nationality As String Implements IIbLabResultDetailView.Nationality
        Public Property PassportNumber As String Implements IIbLabResultDetailView.PassportNumber
        Public Property PatientName As String Implements IIbLabResultDetailView.PatientName
        Public Property Pregnancy As Boolean? Implements IIbLabResultDetailView.Pregnancy
        Public Property Profession As String Implements IIbLabResultDetailView.Profession
        Public Property Sequence As Integer Implements IIbLabResultDetailView.Sequence
        Public Property Shigella As Boolean? Implements IIbLabResultDetailView.Shigella
        Public Property TBSputum As Boolean? Implements IIbLabResultDetailView.TBSputum
        Public Property TransKey As Integer Implements IIbLabResultDetailView.TransKey
        Public Property VDRL As Boolean? Implements IIbLabResultDetailView.VDRL
        Public Property Widal As Boolean? Implements IIbLabResultDetailView.Widal
        Public Property XRay As Boolean? Implements IIbLabResultDetailView.XRay
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace