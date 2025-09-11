Imports AATM.Accounts.BusinessLayer
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPrescriptionView
        Inherits IView

        Property Age As String
        Property AgeYmd As String
        Property Dob As String
        Property DoctorCode As String
        Property DoctorName As String
        Property FileNo As Integer
        Property Gender As String
        Property PatientName As String
        Property Series As String
        Property TransDate As String
        Property TransKey As Integer
        Property PrescriptionDetails As List(Of PrescriptionItemView)
        Event PrintLabels()
        Event ItemCodeChanged(itemCode As String, bs As BindingSource)
        Event GTinScanned(GTin As String, bs As BindingSource, ByRef productCode As String)
    End Interface

End Namespace