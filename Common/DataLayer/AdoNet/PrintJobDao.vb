Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PrintJob
    ' ** DAO Pattern

    Public Class PrintJobDao
        Inherits CommonDao
        Implements IDao(Of PrintJob)

        Private ReadOnly _db As New Db()

        'Public Function GetPrintJobByName(PrintJobName As String) As PrintJob Implements iDao(Of PrintJob).GetPrintJobByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetRecordByIdNo(idNo) As PrintJob Implements IDao(Of PrintJob).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, PrintJobCode, PrintJobName, PrintJobNameAra" &
                    "   FROM [PrintJob]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef PrintJob As PrintJob) As Integer Implements IDao(Of PrintJob).UpdateRecord
            Dim sql As String =
                    " UPDATE [PrintJob] SET" &
                    " PrintJobCode = @PrintJobCode," &
                    " PrintJobName = @PrintJobName," &
                    " PrintJobNameAra = @PrintJobNameAra," &
                    " WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(PrintJob))
        End Function

        Public Function AddRecord(ByRef PrintJob As PrintJob) As Integer Implements IDao(Of PrintJob).AddRecord
            Dim sql As String =
                    " INSERT INTO [PrintJob] " &
                    " (PrintJobCode, PrintJobName,PrintJobNameAra,) " &
                    " VALUES (@PrintJobCode,@PrintJobName,@PrintJobNameAra)"
            Return _db.Insert(sql, Take(PrintJob))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrintJob) =
                                    Function(reader) _
            New PrintJob() With {
            .PrintJobCode = Extensions.AsString(reader("PrintJobCode")),
            .PrintJobName = Extensions.AsString(reader("PrintJobName")),
            .PrintJobNameAra = Extensions.AsString(reader("PrintJobNameAra")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo"))
            }

        Private Function Take(PrintJob As PrintJob) As Object()
            Return New Object() {
                                    "@PrintJobCode", PrintJob.PrintJobCode,
                                    "@PrintJobName", PrintJob.PrintJobName,
                                    "@PrintJobNameAra", PrintJob.PrintJobNameAra,
                                    "@IdNo", PrintJob.IdNo
                                }
        End Function

    End Class

End Namespace