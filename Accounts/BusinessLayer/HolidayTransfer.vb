' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries
Imports AATM.Libraries.Lookup

Namespace BusinessLayer

    Public Class HolidayTransfer
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AppliedBy As Int32

        Public Property DateCreated As DateTime?
        Public Property HolidayDate As DateTime?
        Public Property HolidayIdNo As Int32
        Public Property IdNo As Int32
        Public Property HolidayTransferItems As List(Of HolidayTransferItem)

    End Class

End Namespace