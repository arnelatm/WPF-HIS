Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Category
    ' ** DAO Pattern

    Public Class CategoryDao
        Inherits CommonDao
        Implements IDaoAll(Of Category)

        Private ReadOnly Db As New Db()

        Public Sub New()

        End Sub

        Public Function GetRecordById(idNo) As Category Implements IDaoAll(Of Category).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, CategoryCode, CategoryName, CategoryNameAra, Notes" &
                    "   FROM [Category]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Category) _
            Implements IDaoAll(Of Category).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "CategoryName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, CategoryCode, CategoryName, CategoryNameAra, Notes" &
                    "   FROM [Category] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef category As Category) As Integer Implements IDaoAll(Of Category).UpdateRecord
            Dim sql As String =
                    " UPDATE [Category]" &
                    "    SET CategoryCode = @CategoryCode," &
                    "        CategoryName = @CategoryName," &
                    "        CategoryNameAra = @CategoryNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(category))
        End Function

        Public Function AddRecord(ByRef category As Category) As Integer Implements IDaoAll(Of Category).AddRecord
            Dim sql As String =
                    " INSERT INTO [Category] " &
                    " (CategoryCode,CategoryName,CategoryNameAra,Notes) " &
                    " VALUES (@CategoryCode,@CategoryName,@CategoryNameAra,@Notes) "
            Return Db.Insert(sql, Take(category))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Category) =
                                    Function(reader) _
            New Category() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .CategoryCode = Extensions.AsString(reader("CategoryCode")),
            .CategoryName = Extensions.AsString(reader("CategoryName")),
            .CategoryNameAra = Extensions.AsString(reader("CategoryNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(category As Category) As Object()
            Return New Object() {
                                    "@IdNo", category.IdNo,
                                    "@CategoryCode", category.CategoryCode,
                                    "@CategoryName", category.CategoryName,
                                    "@CategoryNameAra", category.CategoryNameAra,
                                    "@Notes", category.Notes
                                }
        End Function

    End Class

End Namespace