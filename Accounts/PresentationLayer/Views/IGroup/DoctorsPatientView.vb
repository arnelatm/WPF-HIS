Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Class DoctorsPatientView
        Implements IDoctorsPatientView

        Public Property Token As String Implements IDoctorsPatientView.Token
        Public Property Status As Boolean Implements IDoctorsPatientView.Status
        Public Property FileNo As String Implements IDoctorsPatientView.FileNo
        Public Property Name As String Implements IDoctorsPatientView.Name
        Public Property PType As String Implements IDoctorsPatientView.PType
        Public Property InvType As String Implements IDoctorsPatientView.InvType
        Public Property InvoiceDate As String Implements IDoctorsPatientView.InvoiceDate
        Public Property TransKey As Int32 Implements IDoctorsPatientView.TransKey
        Public Property LastConsDate As String Implements IDoctorsPatientView.LastConsDate
        Public Property InvTime As Date Implements IDoctorsPatientView.InvTime
        Public Property PatientIdNo As Int32 Implements IDoctorsPatientView.PatientIdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors



    End Class

    Public Class PmrPatientDisplayView
        Implements IPmrPatientDisplayView

        Public Property Token As String Implements IPmrPatientDisplayView.Token
        Public Property Status As Boolean Implements IPmrPatientDisplayView.Status
        Public Property FileNo As String Implements IPmrPatientDisplayView.FileNo
        Public Property Name As String Implements IPmrPatientDisplayView.Name
        Public Property PType As String Implements IPmrPatientDisplayView.PType
        Public Property InvType As String Implements IPmrPatientDisplayView.InvType
        Public Property InvoiceDate As String Implements IPmrPatientDisplayView.InvoiceDate
        Public Property TransKey As Int32 Implements IPmrPatientDisplayView.TransKey
        Public Property LastConsDate As String Implements IPmrPatientDisplayView.LastConsDate
        Public Property InvTime As Date Implements IPmrPatientDisplayView.InvTime
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace