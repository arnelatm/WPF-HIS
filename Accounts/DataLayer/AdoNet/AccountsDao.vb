Imports AATM.Accounts.BusinessLayer
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
            Dim baseDao As New BaseDao
            Dim accountCode As String = baseDao.GetField(Of String, Int16)(accountIdNo, "Account", "IdNo", "AccountCode")
            sql = "Select Sum(Debit-Credit) from FuncGlAccountStatement(@BegDate,@EndDate,@BegAcctCode,@EndAcctCode)"
            Dim params() As Object
            params = {"@BegDate", endDate, "@EndDate", endDate, "@BegAcctCode", accountCode, "@EndAcctCode", accountCode}
            Return _db.Scalar(sql, params)
        End Function

    End Class

End Namespace