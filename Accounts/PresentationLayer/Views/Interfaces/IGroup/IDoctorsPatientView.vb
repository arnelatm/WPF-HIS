Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDoctorsPatientView
        Inherits IView

        Property InvoiceDate As String
        Property [Name] As String
        Property [Status] As Boolean
        Property [Token] As String
        Property PType As String
        Property FileNo As String
        Property InvType As String
        Property LastConsDate As String
        Property TransKey As Integer
        Property InvTime As Date
        Property PatientIdNo As Int32

    End Interface

    Public Interface IPmrPatientDisplayView
        Inherits IView

        Property InvoiceDate As String
        Property [Name] As String
        Property [Status] As Boolean
        Property [Token] As String
        Property PType As String
        Property FileNo As String
        Property InvType As String
        Property LastConsDate As String
        Property TransKey As Integer
        Property InvTime As Date

    End Interface

End Namespace