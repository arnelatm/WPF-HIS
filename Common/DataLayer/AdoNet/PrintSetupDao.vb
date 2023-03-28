Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PrintSetup
    ' ** DAO Pattern

    Public Class PrintSetupDao
        Inherits CommonDao
        Implements IDao(Of PrintSetup)

        Private ReadOnly _db As New Db()

        Private Const FieldList = "ComputerIdNo," &
                                  "IdNo," &
                                  "PaperOrientation," &
                                  "PaperSize," &
                                  "PaperSource," &
                                  "PrinterIdNo," &
                                  "PrintJobIdNo," &
                                  "PrintSetupName"

        'Public Function GetPrintSetupByName(PrintJobIdNo As String) As PrintSetup Implements iDao(Of PrintSetup).GetPrintSetupByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetRecordByIdNo(idNo) As PrintSetup Implements IDao(Of PrintSetup).GetRecordByIdNo
            Dim sql As String = "Select " & FieldList & " FROM [PrintSetup_View] " &
                    "WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef PrintSetup As PrintSetup) As Integer Implements IDao(Of PrintSetup).UpdateRecord
            Dim sql As String =
                    "UPDATE [PrintSetup] SET " &
                    "ComputerIdNo = @ComputerIdNo, " &
                    "PaperOrientation = @PaperOrientation, " &
                    "PaperSize = @PaperSize, " &
                    "PaperSource = @PaperSource, " &
                    "PrinterIdNo = @PrinterIdNo, " &
                    "PrintJobIdNo = @PrintJobIdNo " &
                    "WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(PrintSetup))
        End Function

        Public Function AddRecord(ByRef PrintSetup As PrintSetup) As Integer Implements IDao(Of PrintSetup).AddRecord
            Dim sql As String =
                    " INSERT INTO [PrintSetup] " &
                    " (ComputerIdNo,PaperOrientation,PaperSize,PaperSource,PrinterIdNo,PrintJobIdNo) " &
                    " VALUES (@ComputerIdNo,@PaperOrientation,@PaperSize,@PaperSource,@PrinterIdNo,@PrintJobIdNo)"
            Return _db.Insert(sql, Take(PrintSetup))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrintSetup) =
                                    Function(reader) _
            New PrintSetup() With {
            .ComputerIdNo = Extensions.AsInt(Of Int16)(reader("ComputerIdNo")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PaperOrientation = Extensions.AsNullable(Of Int16)(reader("PaperOrientation")),
            .PaperSize = Extensions.AsNullable(Of Int16)(reader("PaperSize")),
            .PaperSource = Extensions.AsNullable(Of Int16)(reader("PaperSource")),
            .PrinterIdNo = Extensions.AsNullable(Of Int16)(reader("PrinterIdNo")),
            .PrintJobIdNo = Extensions.AsNullable(Of Int16)(reader("PrintJobIdNo")),
            .PrintSetupName = Extensions.AsString(reader("PrintSetupName"))
            }

        Private Function Take(PrintSetup As PrintSetup) As Object()
            Return New Object() {
                                    "@ComputerIdNo", PrintSetup.ComputerIdNo,
                                    "@IdNo", PrintSetup.IdNo,
                                    "@PaperOrientation", PrintSetup.PaperOrientation,
                                    "@PaperSize", PrintSetup.PaperSize,
                                    "@PaperSource", PrintSetup.PaperSource,
                                    "@PrinterIdNo", PrintSetup.PrinterIdNo,
                                    "@PrintJobIdNo", PrintSetup.PrintJobIdNo
                                }
        End Function

    End Class

End Namespace