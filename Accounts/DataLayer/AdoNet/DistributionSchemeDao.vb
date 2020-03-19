Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for DistributionScheme
    ' ** DAO Pattern

    Public Class DistributionSchemeDao
        Inherits CommonDao
        Implements IDaoAll(Of DistributionScheme)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As DistributionScheme Implements IDaoAll(Of DistributionScheme).GetRecordById
            Dim sql As String =
                    " SELECT IDNo, DistributionSchemeName, DistributionSchemeNameAra, DistributionSchemeCode, ValidityStartDate,  ValidityEndDate, Notes" &
                    "   FROM [DistributionScheme]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of DistributionScheme) _
            Implements IDaoAll(Of DistributionScheme).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String =
                    " SELECT IDNo, DistributionSchemeCode, DistributionSchemeName, DistributionSchemeNameAra " &
                    "   FROM [DistributionScheme] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef distributionScheme As DistributionScheme) As Integer _
            Implements IDaoAll(Of DistributionScheme).UpdateRecord
            Dim sql As String =
                    " UPDATE [DistributionScheme]" &
                    "    SET DistributionSchemeName = @DistributionSchemeName," &
                    "        DistributionSchemeNameAra = @DistributionSchemeNameAra," &
                    "        DistributionSchemeCode = @DistributionSchemeCode," &
                    "        ValidityStartDate = @ValidityStartDate," &
                    "        ValidityEndDate = @ValidityEndDate," &
                    "        Notes = @Notes " &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(distributionScheme))
        End Function

        Public Function AddRecord(ByRef distributionScheme As DistributionScheme) As Integer _
            Implements IDaoAll(Of DistributionScheme).AddRecord
            Dim sql As String =
                    " INSERT INTO [DistributionScheme] " &
                    " (DistributionSchemeName,DistributionSchemeNameAra,DistributionSchemeCode,ValidityStartDate,ValidityEndDate,Notes) " &
                    " VALUES (@DistributionSchemeName,@DistributionSchemeNameAra,@DistributionSchemeCode,@ValidityStartDate,@ValidityEndDate,@Notes) "
            Return Db.Insert(sql, Take(distributionScheme))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DistributionScheme) =
                                    Function(reader) _
            New DistributionScheme() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .DistributionSchemeName = Extensions.AsString(reader("DistributionSchemeName")),
            .DistributionSchemeNameAra = Extensions.AsString(reader("DistributionSchemeNameAra")),
            .DistributionSchemeCode = Extensions.AsString(reader("DistributionSchemeCode")),
            .ValidityStartDate = Extensions.AsDate(reader("ValidityStartDate")),
            .ValidityEndDate = Extensions.AsDate(reader("ValidityEndDate")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(distributionScheme As DistributionScheme) As Object()
            Return New Object() {
                                    "@IDNo", distributionScheme.IdNo,
                                    "@DistributionSchemeName", distributionScheme.DistributionSchemeName,
                                    "@DistributionSchemeNameAra", distributionScheme.DistributionSchemeNameAra,
                                    "@DistributionSchemeCode", distributionScheme.DistributionSchemeCode,
                                    "@ValidityStartDate", distributionScheme.ValidityStartDate,
                                    "@ValidityEndDate", distributionScheme.ValidityEndDate,
                                    "@Notes", distributionScheme.Notes
                                }
        End Function

    End Class

End Namespace