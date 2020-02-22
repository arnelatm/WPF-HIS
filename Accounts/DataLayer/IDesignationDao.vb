Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Designations.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IDesignationDao

        ' gets a specific Designation
        Function GetRecordById(idNo As Integer) As Designation

        ' gets a sorted list of all Designations
        Function GetAll(Optional ByVal sortExpression As String = "DesignationName ASC") As List(Of Designation)

        ' Add a Designation
        Function AddRecord(ByRef designation As Designation) As Integer

        ' updates a Designation
        Function UpdateRecord(ByRef designation As Designation) As Integer

    End Interface
End NameSpace