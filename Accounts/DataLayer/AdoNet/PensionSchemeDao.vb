Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PensionScheme
    ' ** DAO Pattern

    Public Class PensionSchemeDao
        Implements IDao(Of PensionScheme)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As PensionScheme Implements IDao(Of PensionScheme).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "PensionProviderIdNo," &
                    "PensionSchemeCode," &
                    "PensionSchemeName," &
                    "PensionSchemeNameAra," &
                    "IdNo," &
                    "Notes," &
                    " FROM [PensionScheme]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            'Dim peaDao = New PayrollEarnAccountDao()
            'data.PayrollEarnAccounts = peaDao.GetRecordsWithIdNo(idNo, "Sequence")
            Return data
        End Function

        Public Function UpdateRecord(ByRef pensionScheme As PensionScheme) As Integer Implements IDao(Of PensionScheme).UpdateRecord
            Dim sql As String = " UPDATE [PensionScheme] Set" &
                    " AccountIdNo = @AccountIdNo," &
                    " PensionProviderIdNo = @PensionProviderIdNo," &
                    " PensionSchemeCode = @PensionSchemeCode," &
                    " PensionSchemeName = @PensionSchemeName," &
                    " PensionSchemeNameAra = @PensionSchemeNameAra," &
                    " Notes = @Notes," &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(pensionScheme))
        End Function

        Public Function AddRecord(ByRef PensionScheme As PensionScheme) As Integer Implements IDao(Of PensionScheme).AddRecord
            Dim sql As String =
                    " INSERT INTO [PensionScheme] " &
                    " (AccountIdNo,PensionProviderIdNo,PensionSchemeCode,PensionSchemeName,PensionSchemeNameAra) " &
                    " VALUES (@AccountIdNo,@PensionProviderIdNo,@PensionSchemeCode,@PensionSchemeName,@PensionSchemeNameAra,@Notes) "
            Return _db.Insert(sql, Take(PensionScheme))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PensionScheme) =
                                    Function(reader) _
            New PensionScheme() With {
            .AccountIdNo = Extensions.AsId(Of Int16)(reader("AccountIdNo")),
            .PensionProviderIdNo = Extensions.AsId(Of Int16)(reader("PensionProviderIdNo")),
            .PensionSchemeCode = Extensions.AsString(reader("PensionSchemeCode")),
            .PensionSchemeName = Extensions.AsString(reader("PensionSchemeName")),
            .PensionSchemeNameAra = Extensions.AsString(reader("PensionSchemeNameAra")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(PensionScheme As PensionScheme) As Object()
            Return New Object() {
                                    "@AccountIdNo", PensionScheme.AccountIdNo,
                                    "@PensionProviderIdNo", PensionScheme.PensionProviderIdNo,
                                    "@PensionSchemeCode", PensionScheme.PensionSchemeCode,
                                    "@PensionSchemeName", PensionScheme.PensionSchemeName,
                                    "@PensionSchemeNameAra", PensionScheme.PensionSchemeNameAra,
                                    "@IdNo", PensionScheme.IdNo,
                                    "@Notes", PensionScheme.Notes
                                }
        End Function

    End Class

End Namespace