Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Category
    ' ** DAO Pattern

    Public Class CategoryDao
        Inherits AATM.DataLayer.AdoNet.CommonDaoOld
        Implements ICategoryDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As Category Implements ICategoryDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, CategoryCode, CategoryName, CategoryNameAra, Notes" &
                    "   FROM [Category]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "CategoryName ASC") As List(Of Category) _
            Implements ICategoryDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, CategoryCode, CategoryName, CategoryNameAra, Notes" &
                    "   FROM [Category] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef category As Category) As Integer Implements ICategoryDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [Category]" &
                    "    SET CategoryCode = @CategoryCode," &
                    "        CategoryName = @CategoryName," &
                    "        CategoryNameAra = @CategoryNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(category))
        End Function

        Public Function AddRecord(ByRef category As Category) As Integer Implements ICategoryDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Category] " &
                    " (CategoryCode,CategoryName,CategoryNameAra,Notes) " &
                    " VALUES (@CategoryCode,@CategoryName,@CategoryNameAra,@Notes) "
            Return Db.Insert(sql, Take(category))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Category) =
                                    Function(reader) _
            New Category() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .CategoryCode = Extensions.AsString(reader("CategoryCode")),
            .CategoryName = Extensions.AsString(reader("CategoryName")),
            .CategoryNameAra = Extensions.AsString(reader("CategoryNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(category As Category) As Object()
            Return New Object() {
                                    "@IDNo", category.IdNo,
                                    "@CategoryCode", category.CategoryCode,
                                    "@CategoryName", category.CategoryName,
                                    "@CategoryNameAra", category.CategoryNameAra,
                                    "@Notes", category.Notes
                                }
        End Function

    End Class

End Namespace