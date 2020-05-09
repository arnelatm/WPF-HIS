' defines methods to access Salts.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.BusinessLayer.BusinessObjects

Public Interface ISaltDao
    ' gets a specific Salt

    Function GetSalt(idNo As Int32) As Salt

    ' gets a specific Salt by LoginIdNo

    Function GetSaltByLoginIdNo(loginIdNo As Int32) As Salt

    ' Insert a Salt
    Function InsertSalt(salt As Salt) As Integer

    ' deletes a Salt

    Sub DeleteSalt(salt As Salt)

End Interface