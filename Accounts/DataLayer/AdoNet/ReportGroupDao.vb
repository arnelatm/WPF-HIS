Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for ReportGroup
    ' ** DAO Pattern

    Public Class ReportGroupDao
        Inherits CommonDao
        Implements IDao(Of ReportGroup)

        Private Const FieldList = "IdNo," &
                          "ReportGroupCode," &
                          "ReportGroupName," &
                          "ReportGroupNameAra"

        Private ReadOnly Db As New Db()


        Public Function UpdateRecord(ByRef ReportGroup As ReportGroup) As Integer Implements IDao(Of ReportGroup).UpdateRecord
            Dim sql As String = " UPDATE [ReportGroup] Set" &
                    " ReportGroupCode = @ReportGroupCode," &
                    " ReportGroupName = @ReportGroupName," &
                    " ReportGroupNameAra = @ReportGroupNameAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(ReportGroup))
        End Function

        Public Function AddRecord(ByRef ReportGroup As ReportGroup) As Integer Implements IDao(Of ReportGroup).AddRecord
            Dim sql As String =
                    " INSERT INTO [ReportGroup] " &
                    " (ReportGroupCode,ReportGroupName,ReportGroupNameAra) " &
                    " VALUES (@ReportGroupCode,@ReportGroupName,@ReportGroupNameAra) "
            Return Db.Insert(sql, Take(ReportGroup))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ReportGroup) =
                                    Function(reader) _
            New ReportGroup() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ReportGroupCode = Extensions.AsString(reader("ReportGroupCode")),
            .ReportGroupName = Extensions.AsString(reader("ReportGroupName")),
            .ReportGroupNameAra = Extensions.AsString(reader("ReportGroupNameAra"))
            }

        Private Function Take(ReportGroup As ReportGroup) As Object()
            Return New Object() {"@IdNo", ReportGroup.IdNo,
                                  "@ReportGroupCode", ReportGroup.ReportGroupCode,
                                  "@ReportGroupName", ReportGroup.ReportGroupName,
                                  "@ReportGroupNameAra", ReportGroup.ReportGroupNameAra
                                }
        End Function

        Private Shared ReadOnly MakeReportGroup As Func(Of IDataReader, ReportGroup) =
                                    Function(reader) _
            New ReportGroup() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ReportGroupName = Extensions.AsString(reader("ReportGroupName")),
            .ReportGroupNameAra = Extensions.AsString(reader("ReportGroupNameAra")),
            .ReportGroupCode = Extensions.AsString(reader("ReportGroupCode"))
            }

        Public Function GetRecordByIdNo(idNo) As ReportGroup Implements IDao(Of ReportGroup).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM ReportGroup" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

    End Class


End Namespace
