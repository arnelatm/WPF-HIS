Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Linq.Expressions
Imports System.Runtime.Remoting.Contexts
Imports AATM.HIS.DataLayer

Namespace Services

    Public Class Repository(Of TEntity As Class)
        Implements IRepository(Of TEntity)

        Public Shared Property Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
        Public Shared Property Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Public Shared Property ColPropDao As ITblColPropDao = Factory.TblColPropDao

        Public Function GetRecordOne(id As Integer) As TEntity
            Return TEntity.GetOne(Of TEntity)().Find(id)
        End Function


        Public Function GetOne(idNo As Integer) As TEntity
            Return AdoNet.CommonDao.GetRecordWithIdNo(idNo)
        End Function



        Public Function IRepository_GetAll() As IEnumerable(Of TEntity) Implements IRepository(Of TEntity).GetAll
            Throw New NotImplementedException
        End Function

        Public Function IRepository_GetOne(id As Integer) As TEntity Implements IRepository(Of TEntity).GetOne
            Throw New NotImplementedException
        End Function

        Public Function GetAll() As IEnumerable(Of TEntity)
            Return Context.[Set](Of TEntity)().ToList()
        End Function

        Public Function Find(predicate As Expression(Of Func(Of TEntity, Boolean))) As IEnumerable(Of TEntity) Implements IRepository(Of TEntity).Find
            Return Find(predicate)
        End Function

        Public Function SingleOrDefault(predicate As Expression(Of Func(Of TEntity, Boolean))) As TEntity Implements IRepository(Of TEntity).SingleOrDefault
            Return SingleOrDefault(predicate)
        End Function

        Public Sub Add(entity As TEntity) Implements IRepository(Of TEntity).Add
            Add(entity)
        End Sub

        Public Sub AddRange(entities As IEnumerable(Of TEntity)) Implements IRepository(Of TEntity).AddRange
            AddRange(entities)
        End Sub

        Public Sub Remove(entity As TEntity) Implements IRepository(Of TEntity).Remove
            Remove(entity)
        End Sub

        Public Sub RemoveRange(entities As IEnumerable(Of TEntity)) Implements IRepository(Of TEntity).RemoveRange
            RemoveRange(entities)
        End Sub

        Public Function Find(predicate As Expression(Of Func(Of TEntity, Boolean))) As IEnumerable(Of TEntity)
            Return Context.[Set](Of TEntity)().Where(predicate)
        End Function

        Public Function SingleOrDefault(predicate As Expression(Of Func(Of TEntity, Boolean))) As TEntity
            Return Context.[Set](Of TEntity)().SingleOrDefault(predicate)
        End Function

        Public Sub Add(entity As TEntity)
            Context.[Set](Of TEntity)().Add(entity)
        End Sub

        Public Sub AddRange(entities As IEnumerable(Of TEntity))
            Context.[Set](Of TEntity)().AddRange(entities)
        End Sub

        Public Sub Remove(entity As TEntity)
            Context.[Set](Of TEntity)().Remove(entity)
        End Sub

        Public Sub RemoveRange(entities As IEnumerable(Of TEntity))
            Context.[Set](Of TEntity)().RemoveRange(entities)
        End Sub
    End Class
End Namespace