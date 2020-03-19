Imports AATM.BusinessLayer.BusinessObjects

Public Interface ISecurityObjectDao

    ' gets a specific SecurityObject
    Function GetRecordById(idNo As Integer) As SecurityObject

    ' gets a sorted list of all SecurityObjects
    Function GetAll(Optional ByVal sortExpression As String = "SecurityObjectName") As List(Of SecurityObject)

    ' Add a SecurityObject
    Function AddRecord(ByRef securityObject As SecurityObject) As Integer

    ' updates a SecurityObject
    Function UpdateRecord(ByRef securityObject As SecurityObject) As Integer

    'Function GetSecurityObject(idNo As Integer) As SecurityObject

    'Function GetSecurityObjects(Optional ByVal sortExpression As String = "SecurityObjectName ASC") _
    '    As List(Of SecurityObject)

    'Function InsertSecurityObject(securityObject As SecurityObject) As Integer
    'Function UpdateSecurityObject(securityObject As SecurityObject)
    'Sub DeleteSecurityObject(securityObject As SecurityObject)

    'Function GetSecurityObjectList(Optional ByVal sortExpression As String = "SecurityObjectName ASC") _
    '    As List(Of SecurityObject)
End Interface