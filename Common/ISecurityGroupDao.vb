Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer

    Public Interface ISecurityGroupDao

        ' gets a specific SecurityGroup
        Function GetRecordById(idNo As Integer) As SecurityGroup

        ' gets a sorted list of all SecurityGroups
        Function GetAll(Optional ByVal sortExpression As String = "SecurityGroupName ASC") As List(Of SecurityGroup)

        ' Add a SecurityGroup
        Function AddRecord(ByRef securityGroup As SecurityGroup) As Integer

        ' updates a SecurityGroup
        Function UpdateRecord(ByRef securityGroup As SecurityGroup) As Integer

    End Interface

End Namespace