' defines methods to access Logins.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.Common.BusinessLayer

Namespace DataLayer

    Public Interface ILogoutDao

        ' gets a specific Login

        Function GetLogout(idNo As Integer) As Login

        ' gets a specific Login by UserName

    End Interface

End Namespace