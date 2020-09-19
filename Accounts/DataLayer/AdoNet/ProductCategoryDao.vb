Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ProductCategory
    ' ** DAO Pattern

    Public Class ProductCategoryDao
        Inherits CommonDao
        Implements IDaoAll(Of ProductCategory)

        Private ReadOnly Db As New Db()

        Public Sub New()

        End Sub

        Public Function GetRecordById(idNo) As ProductCategory Implements IDaoAll(Of ProductCategory).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, ProductCategoryCode, ProductCategoryName, ProductCategoryNameAra, Notes" &
                    "   FROM [ProductCategory]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of ProductCategory) _
            Implements IDaoAll(Of ProductCategory).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "ProductCategoryName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, ProductCategoryCode, ProductCategoryName, ProductCategoryNameAra, Notes" &
                    "   FROM [ProductCategory] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef productCategory As ProductCategory) As Integer Implements IDaoAll(Of ProductCategory).UpdateRecord
            Dim sql As String =
                    " UPDATE [ProductCategory]" &
                    "    SET ProductCategoryCode = @ProductCategoryCode," &
                    "        ProductCategoryName = @ProductCategoryName," &
                    "        ProductCategoryNameAra = @ProductCategoryNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(productCategory))
        End Function

        Public Function AddRecord(ByRef productCategory As ProductCategory) As Integer Implements IDaoAll(Of ProductCategory).AddRecord
            Dim sql As String =
                    " INSERT INTO [ProductCategory] " &
                    " (ProductCategoryCode,ProductCategoryName,ProductCategoryNameAra,Notes) " &
                    " VALUES (@ProductCategoryCode,@ProductCategoryName,@ProductCategoryNameAra,@Notes) "
            Return Db.Insert(sql, Take(productCategory))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ProductCategory) =
                                    Function(reader) _
            New ProductCategory() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .ProductCategoryCode = Extensions.AsString(reader("ProductCategoryCode")),
            .ProductCategoryName = Extensions.AsString(reader("ProductCategoryName")),
            .ProductCategoryNameAra = Extensions.AsString(reader("ProductCategoryNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(productCategory As ProductCategory) As Object()
            Return New Object() {
                                    "@IdNo", productCategory.IdNo,
                                    "@ProductCategoryCode", productCategory.ProductCategoryCode,
                                    "@ProductCategoryName", productCategory.ProductCategoryName,
                                    "@ProductCategoryNameAra", productCategory.ProductCategoryNameAra,
                                    "@Notes", productCategory.Notes
                                }
        End Function

    End Class

End Namespace