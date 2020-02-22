' defines methods to access Logins.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer

    Public Interface ILoginDao

        ' gets a specific Login

        Function GetLogin(idNo As Integer) As Login

        ' gets a specific Login by UserName

        Function GetLoginByUserName(userName As String) As Login

        ' gets a sorted list of all Logins

        Function GetLogins(Optional ByVal sortExpression As String = "IDNo ASC") As List(Of Login)

        ' gets Login given an order

        Sub InsertLogin(login As Login)

        ' updates a Login

        Sub UpdateLogin(login As Login)

        ' deletes a Login

        Sub DeleteLogin(login As Login)

    End Interface

End Namespace