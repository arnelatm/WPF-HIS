Imports AATM.BusinessLayer.BusinessObjects

Public Interface IUserDao
    ' defines methods to access Users.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    ' gets a sorted list of all Users
    Function GetAll(Optional ByVal sortExpression As String = "FullName ASC") As List(Of User)

    ' gets a specific User
    Function GetRecordById(idNo As Integer) As User

    Function GetUserByName(fullName As String) As User

    ' gets User given an order
    Function AddRecord(user As User) As Integer

    ' updates a User
    Function UpdateRecord(user As User) As Integer

    ' deletes a User
    Sub DeleteRecord(user As User)

End Interface