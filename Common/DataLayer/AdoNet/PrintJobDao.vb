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

        Private Const FieldList = "IdNo," &
                                  "PaperOrientation," &
                                  "PaperSize," &
                                  "PaperSource," &
                                  "PrinterIdNo," &
                                  "PrintJobCode," &
                                  "PrintJobName," &
                                  "PrintJobNameAra" 

        'Public Function GetPrintJobByName(PrintSetupIdNo As String) As PrintJob Implements iDao(Of PrintJob).GetPrintJobByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetRecordByIdNo(idNo) As PrintJob Implements IDao(Of PrintJob).GetRecordByIdNo
            Dim sql As String = "Select " & FieldList & " FROM [PrintJob] " &
                    "WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef printJob As PrintJob) As Integer Implements IDao(Of PrintJob).UpdateRecord
            Dim sql As String =
                    "UPDATE [PrintJob] SET " &
                    "PaperOrientation = @PaperOrientation, " &
                    "PaperSize = @PaperSize, " &
                    "PaperSource = @PaperSource, " &
                    "PrinterIdNo = @PrinterIdNo, " &
                    "PrintJobCode = @PrintJobCode, " &
                    "PrintJobName = @PrintJobName, " &
                    "PrintJobNameAra = @PrintJobNameAra " &
                    "WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(printJob))
        End Function

        Public Function AddRecord(ByRef printJob As PrintJob) As Integer Implements IDao(Of PrintJob).AddRecord
            Dim sql As String =
                    " INSERT INTO [PrintJob] " &
                    " (PaperOrientation,PaperSize,PaperSource,PrinterIdNo,PrintJobCode,PrintJobName,PrintJobNameAra) " &
                    " VALUES (@PaperOrientation,@PaperSize,@PaperSource,@PrinterIdNo,@PrintJobCode,@PrintJobName,@PrintJobNameAra)"
            Return _db.Insert(sql, Take(printJob))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrintJob) =
                                    Function(reader) _
            New PrintJob() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PaperOrientation = Extensions.AsNullable(Of Int32?)(reader("PaperOrientation")),
            .PaperSize = Extensions.AsNullable(Of Int32?)(reader("PaperSize")),
            .PaperSource = Extensions.AsNullable(Of Int32?)(reader("PaperSource")),
            .PrinterIdNo = Extensions.AsNullable(Of Int16?)(reader("PrinterIdNo")),
            .PrintJobCode = Extensions.AsString(reader("PrintJobCode")),
            .PrintJobName = Extensions.AsString(reader("PrintJobName")),
            .PrintJobNameAra = Extensions.AsString(reader("PrintJobNameAra"))
            }

        Private Function Take(printJob As PrintJob) As Object()
            Return New Object() {
                                    "@IdNo", printJob.IdNo,
                                    "@PaperOrientation", printJob.PaperOrientation,
                                    "@PaperSize", printJob.PaperSize,
                                    "@PaperSource", printJob.PaperSource,
                                    "@PrinterIdNo", printJob.PrinterIdNo,
                                    "@PrintJobCode", printJob.PrintJobCode,
                                    "@PrintJobName", printJob.PrintJobName,
                                    "@PrintJobNameAra", printJob.PrintJobNameAra
                                }
        End Function

    End Class

End Namespace