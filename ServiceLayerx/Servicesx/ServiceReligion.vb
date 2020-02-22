Imports System.Linq.Expressions
Imports AATM.Businesslayer
Imports AATM.DataLayer.AdoNet

Public Class ServiceReligion
    Implements IServiceMain(Of Religion)
    
    Public Function GetRecord(Of TKey)(idNo As TKey) As Object Implements IServiceMain(Of Religion).GetRecord
        Return DaoReligion.GetRecord(Convert.ToInt64(idNo))        
    End Function

    Public Function GetRecordNew (Of TKey)(idNo As TKey) As Object Implements IServiceMain(Of Religion).GetRecordNew
        Throw New NotImplementedException
    End Function

    Public Function GetAll() As IEnumerable(Of Religion) Implements IServiceMain(Of Religion).GetAll
        Return DaoReligion.GetAll()
    End Function

    Public Sub Add(entity As Religion) Implements IServiceMain(Of Religion).Add
        Throw New NotImplementedException()
    End Sub

    Public Sub AddRange(entities As IEnumerable(Of Religion)) Implements IServiceMain(Of Religion).AddRange
        Throw New NotImplementedException()
    End Sub

    Public Sub Remove(entity As Religion) Implements IServiceMain(Of Religion).Remove
        Throw New NotImplementedException()
    End Sub

    Public Sub RemoveRange(entities As IEnumerable(Of Religion)) Implements IServiceMain(Of Religion).RemoveRange
        Throw New NotImplementedException()
    End Sub




    Public Function Find(predicate As Expression(Of Func(Of Religion, Boolean))) As IEnumerable(Of Religion) Implements IServiceMain(Of Religion).Find
        Throw New NotImplementedException()
    End Function

    Public Function SingleOrDefault(predicate As Expression(Of Func(Of Religion, Boolean))) As Object Implements IServiceMain(Of Religion).SingleOrDefault
        Throw New NotImplementedException()
    End Function
End Class
