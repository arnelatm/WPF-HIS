Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class AccountsDao
        Inherits CommonDao
        Implements IAccountsDao

        Private ReadOnly _db As New Db()

        Public Sub New()
        End Sub

        Public Function UpdateVatNumber(vatNumber As String, idNo As Integer) As Integer Implements IAccountsDao.UpdateVatNumber
            Dim retVal As Boolean
            Dim sql1 As String
            sql1 = "Update Supplier set VatNumber = '" & vatNumber & "' where IdNo = " & idNo.ToString() & " and (VatNumber IS NULL or VatNumber = '')"
            retVal = _db.ExecuteSqlTransaction("UpdateVatNumber", sql1, "")
            Return retVal
        End Function

        Public Function GetAccountBalance(endDate As Date, accountIdNo As Int16) As Decimal Implements IAccountsDao.GetAccountBalance
            Dim sql As String
            sql = "select  dbo.FnGetAccountBalance(@AccountIdNo,@EndDate)"
            Dim params() As Object
            params = {"@AccountIdNo", accountIdNo, "@EndDate", Convert.ToDateTime(endDate)}
            Dim retVal = _db.Scalar(sql, params)
            If retVal Is Nothing Or retVal.Equals(DBNull.Value) Then
                Return 0
            Else
                Return retVal
            End If
        End Function

        Public Function GetLastPurchaseCost(productidNo As Int32) As Decimal Implements IAccountsDao.GetLastPurchaseCost
            Return _db.RunSqlStoredProcedure("spGetLastPurchaseCost", {"@ProductIdNo", productidNo})
        End Function

        Public Function GetLastPurchaseData(productidNo As Int32) As Object Implements IAccountsDao.GetLastPurchaseData
            Return GetRecordFieldsFiltered("PurchaseHistory_View", "UnitCost,BatchNo,ExpiryDate", "ProductIdNo = @ProductIdNo and PurchaseReturn = 0", {"@ProductIdNo", productidNo}, "TransactionDate Desc")
        End Function


    End Class

End Namespace