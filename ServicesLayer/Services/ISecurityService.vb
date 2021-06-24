Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer
Imports AATM.Libraries.AatmInterfaces

Namespace Services

    Public Interface ISecurityService
        Inherits IServiceNew

        Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String

        Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList

        Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList

        Function AddSecurityObject(securityObjectName As SecurityObject) As Integer

        Function InitializeSecurityObject() As Integer

    End Interface

End Namespace