Imports AATM.BusinessLayer.BusinessObjects

Public Interface IUserDao
    ' defines methods to access Users.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    ' gets a specific User
    Function GetUser(idNo As Integer) As User
    Function GetUserByName(fullName As String) As User

    ' gets a sorted list of all Users

    Function GetUsers(Optional ByVal sortExpression As String = "FullName ASC") As List(Of User)

    ' gets User given an order

    Function InsertUser(user As User) As Integer

    ' updates a User

    Function UpdateUser(user As User) As Integer

    ' deletes a User

    Sub DeleteUser(user As User)
End Interface

