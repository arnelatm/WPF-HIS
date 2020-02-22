' defines methods to access PhoneTypes.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer

    Public Interface IPhoneTypeDao

        ' gets a specific PhoneType
        Function GetRecordById(idNo As Integer) As PhoneType

        ' gets a sorted list of all PhoneTypes
        Function GetAll(Optional ByVal sortExpression As String = "PhoneTypeName") As List(Of PhoneType)

        ' Add a PhoneType
        Function AddRecord(ByRef PhoneType As PhoneType) As Integer

        ' updates a PhoneType
        Function UpdateRecord(ByRef PhoneType As PhoneType) As Integer

    End Interface

End Namespace