' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class HolidayTransfer
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property EnteredBy As Int32

        Public Property DateCreated As DateTime?
        Public Property DateEnd As DateTime?
        Public Property DateStart As DateTime?
        Public Property HolidayIdNo As Int16
        Public Property IdNo As Int32
        Public Property HolidayTransferItems As List(Of HolidayTransferItem)

    End Class

End Namespace