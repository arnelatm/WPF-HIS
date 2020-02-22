' IBModel interface, part of MVP design pattern.

Public Interface IModelSecurity
    Function GetControlSecurityIdNo(searchValue As String) As String

    Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList
End Interface