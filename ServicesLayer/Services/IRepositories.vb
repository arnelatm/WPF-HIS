Imports System.Linq.Expressions

Namespace Services

    Public Interface IRepository(Of TEntity As Class)

        Function GetOne(id As Integer) As TEntity

        Function GetAll() As IEnumerable(Of TEntity)

        Function Find(predicate As Expression(Of Func(Of TEntity, Boolean))) As IEnumerable(Of TEntity)

        Function SingleOrDefault(predicate As Expression(Of Func(Of TEntity, Boolean))) As TEntity

        Sub Add(entity As TEntity)

        Sub AddRange(entities As IEnumerable(Of TEntity))

        Sub Remove(entity As TEntity)

        Sub RemoveRange(entities As IEnumerable(Of TEntity))

    End Interface

End Namespace