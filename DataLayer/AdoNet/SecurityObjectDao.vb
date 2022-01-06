Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for SecurityObject
    ' ** DAO Pattern

    Public Class SecurityObjectDao
        Inherits BaseDao
        Implements IDao(Of SecurityObject)

        Private ReadOnly _db As New Db()

        Private ReadOnly _make As Func(Of IDataReader, SecurityObject) =
                             Function(reader) _
            New SecurityObject() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ManuallyAdded = Extensions.AsBool(reader("ManuallyAdded")),
            .Notes = Extensions.AsString(reader("Notes")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .SecurityObjectCode = Extensions.AsString(reader("SecurityObjectCode")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .SecurityObjectNameAra = Extensions.AsString(reader("SecurityObjectNameAra")),
            .SystemViewIdNo = Extensions.AsId(Of Int32)(reader("SystemViewIdNo"))}

        Private Function Take(securityObject As SecurityObject) As Object()
            Return New Object() {"@IdNo", securityObject.IdNo,
                                  "@ManuallyAdded", securityObject.ManuallyAdded,
                                  "@Notes", securityObject.Notes,
                                  "@ParentIdNo", securityObject.ParentIdNo,
                                  "@SecurityObjectCode", securityObject.SecurityObjectCode,
                                  "@SecurityObjectName", securityObject.SecurityObjectName,
                                  "@SecurityObjectNameAra", securityObject.SecurityObjectNameAra,
                                  "@SystemViewIdNo", securityObject.SystemViewIdNo}
        End Function

        Public Function GetRecordByIdNo(idNo) As SecurityObject _
            Implements IDao(Of SecurityObject).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, ParentIdNo, SecurityObjectCode, SecurityObjectName, SecurityObjectNameAra,SystemViewIdNo,ManuallyAdded,Notes" &
                    "   FROM [SecurityObject]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, _make, params).FirstOrDefault()
        End Function

        Public Function AddRecord(ByRef recordData As SecurityObject) As Integer _
            Implements IDao(Of SecurityObject).AddRecord
            Dim sql As String =
                    " INSERT INTO [SecurityObject] " &
                    " (ManuallyAdded,Notes,ParentIdNo,SecurityObjectCode, SecurityObjectName,SecurityObjectNameAra,SystemViewIdNo) " &
                    " VALUES (@ManuallyAdded,@Notes,@ParentIdNo,@SecurityObjectCode,@SecurityObjectName,@SecurityObjectNameAra,@SystemViewIdNo)"
            Return _db.Insert(sql, Take(recordData))
        End Function

        Public Function UpdateRecord(ByRef recordData As SecurityObject) As Integer _
            Implements IDao(Of SecurityObject).UpdateRecord
            Dim sql As String =
                    " UPDATE [SecurityObject] Set " &
                    "ManuallyAdded = @ManuallyAdded," &
                    "Notes = @Notes," &
                    "ParentIdNo = @ParentIdNo," &
                    "SecurityObjectCode = @SecurityObjectCode," &
                    "SecurityObjectName = @SecurityObjectName," &
                    "SecurityObjectNameAra = @SecurityObjectNameAra," &
                    "SystemViewIdNo = @SystemViewIdNo" &
                    "  WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(recordData))
        End Function

    End Class

End Namespace