Imports AATM.Common.DataLayer
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IAccountsDao
        Inherits ICommonDao

    End Interface

    Public Interface IJournalsDao(Of TM)

        Function UpdateGlReferenceNumber(ByRef model As TM) As Integer

    End Interface

End Namespace