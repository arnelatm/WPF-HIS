Public Interface ISecurityDao

    Function GetControlSecurityIdNo(searchValue As String) As String

    Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList

    Function GetUserSecurityForKey(securityObjectIdNo As String, securityGroupIdNo As Integer) As ArrayList

End Interface