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

        Private Const FieldList = "ComputerName," &
                                  "IdNo," &
                                  "PaperOrientation," &
                                  "PaperSize," &
                                  "PaperSource," &
                                  "PrinterName," &
                                  "PrintJobName"

        'Public Function GetPrintJobByName(PrintJobName As String) As PrintJob Implements iDao(Of PrintJob).GetPrintJobByName
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
                    "ComputerName = @ComputerName, " &
                    "PaperOrientation = @PaperOrientation, " &
                    "PaperSize = @PaperSize, " &
                    "PaperSource = @PaperSource, " &
                    "PrinterName = @PrinterName, " &
                    "PrintJobName = @PrintJobName " &
                    "WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(printJob))
        End Function

        Public Function AddRecord(ByRef printJob As PrintJob) As Integer Implements IDao(Of PrintJob).AddRecord
            Dim sql As String =
                    " INSERT INTO [PrintJob] " &
                    " (ComputerName,PaperOrientation,PaperSize,PaperSource,PrinterName,PrintJobName) " &
                    " VALUES (@ComputerName,@PaperOrientation,@PaperSize,@PaperSource,@PrinterName,@PrintJobName)"
            Return _db.Insert(sql, Take(printJob))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrintJob) =
                                    Function(reader) _
            New PrintJob() With {
            .ComputerName = Extensions.AsString(reader("ComputerName")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PaperOrientation = Extensions.AsNullable(Of Int32?)(reader("PaperOrientation")),
            .PaperSize = Extensions.AsNullable(Of Int32?)(reader("PaperSize")),
            .PaperSource = Extensions.AsNullable(Of Int32?)(reader("PaperSource")),
            .PrinterName = Extensions.AsString(reader("PrinterName")),
            .PrintJobName = Extensions.AsString(reader("PrintJobName"))
            }

        Private Function Take(printJob As PrintJob) As Object()
            Return New Object() {
                                    "@ComputerName", printJob.ComputerName,
                                    "@PaperOrientation", printJob.PaperOrientation,
                                    "@PaperSize", printJob.PaperSize,
                                    "@PaperSource", printJob.PaperSource,
                                    "@PrinterName", printJob.PrinterName,
                                    "@PrintJobName", printJob.PrintJobName
                                }
        End Function

    End Class

End Namespace