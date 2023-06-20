Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models

Public Class PrescriptionModel
    Public Property Age As String
    Public Property AgeYmd As String
    Public Property Dob As String
    Public Property DoctorCode As String
    Public Property DoctorName As String
    Public Property FileNo As Integer
    Public Property Gender As String
    Public Property PatientName As String
    Public Property Series As String
    Public Property TransDate As String
    Public Property TransKey As Integer
    Public Property PrescriptionDetails As List(Of PrescriptionDetailModel)

End Class

