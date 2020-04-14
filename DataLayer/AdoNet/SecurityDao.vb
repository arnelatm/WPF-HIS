Imports AATM.Libraries.GlobalFuncNSub

Namespace AdoNet
    ' Data access object for Security
    ' ** DAO Pattern

    Public Class SecurityDao
        Inherits BaseDao
        Implements ISecurityDao

        Private ReadOnly Db As New Db("ISPDATA")

        Public Function GetControlSecurityIdNo(searchValue As String) As String _
            Implements ISecurityDao.GetControlSecurityIdNo
            Dim sql As String =
                    " Select Top 1 IdNo FROM SecurityObject " &
                    " Where SecurityObjectName = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = Db.Scalar(sql, params)
            If retVal Is Nothing Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
            Implements ISecurityDao.GetUserSecurity
            Dim params() As Object =
                    {"@SecurityObjectIDNo", securityObjectIdNo, "@SecurityGroupIDNo", securityGroupIdNo}
            Dim sql =
                    " SELECT top 1 Visible, Editable FROM GroupAccess where SecurityObjectIDNo = @SecurityObjectIDNo and SecurityGroupIDNo = @SecurityGroupIDNo"
            Return Db.SqlRead(sql, params)
        End Function

        Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Integer) As ArrayList _
            Implements ISecurityDao.GetUserSecurityForKey
            Dim params() As Object =
                    {"@SecurityObjectName", securityObjectName, "@SecurityGroupIDNo", securityGroupIdNo}
            Dim sql = "SELECT top 1 Visible, Editable FROM GroupAccess " &
                      "Left Join SecurityObject " &
                      "on GroupAccess.SecurityObjectIDNo = SecurityObject.IdNo " &
                      "where SecurityObject.SecurityObjectName = @securityObjectName and GroupAccess.SecurityGroupIdNo = @SecurityGroupIdNo"
            Return Db.SqlRead(sql, params)
        End Function

        Public Function IsUserDeveloper()
            Dim controlSecurityValues = GetUserSecurityForKey("_Developer", GlobalVariables.SecurityGroupIdNo)
            If _
                controlSecurityValues IsNot Nothing AndAlso controlSecurityValues.Count > 0 AndAlso
                controlSecurityValues(0) Then
                ' Visible property stored in first element of the array
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace