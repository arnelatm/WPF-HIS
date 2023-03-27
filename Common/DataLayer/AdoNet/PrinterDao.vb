Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Printer
    ' ** DAO Pattern

    Public Class PrinterDao
        Inherits CommonDao
        Implements IDao(Of Printer)

        Private ReadOnly _db As New Db()

        Private Const FieldList = "DefaultPaperOrientation," &
                                  "DefaultPaperSize," &
                                  "DefaultPaperSource," &
                                  "HostOrIpName," &
                                  "IdNo," &
                                  "PrinterCode," &
                                  "PrinterName"

        'Public Function GetPrinterByName(PrinterName As String) As Printer Implements iDao(Of Printer).GetPrinterByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetRecordByIdNo(idNo) As Printer Implements IDao(Of Printer).GetRecordByIdNo
            Dim sql As String = "Select " & FieldList & " FROM [Printer] " &
                    "WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Printer As Printer) As Integer Implements IDao(Of Printer).UpdateRecord
            Dim sql As String =
                    "UPDATE [Printer] SET " &
                    "DefaultPaperOrientation = @DefaultPaperOrientation, " &
                    "DefaultPaperSize = @DefaultPaperSize, " &
                    "DefaultPaperSource = @DefaultPaperSource, " &
                    "HostOrIpName = @HostOrIpName, " &
                    "PrinterCode = @PrinterCode, " &
                    "PrinterName = @PrinterName " &
                    "WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(Printer))
        End Function

        Public Function AddRecord(ByRef Printer As Printer) As Integer Implements IDao(Of Printer).AddRecord
            Dim sql As String =
                    " INSERT INTO [Printer] " &
                    " (DefaultPaperOrientation,DefaultPaperSize,DefaultPaperSource,HostOrIpName,PrinterCode,PrinterName) " &
                    " VALUES (@DefaultPaperOrientation,@DefaultPaperSize,@DefaultPaperSource,@HostOrIpName,@PrinterCode,@PrinterName)"
            Return _db.Insert(sql, Take(Printer))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Printer) =
                                    Function(reader) _
            New Printer() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .DefaultPaperOrientation = Extensions.AsNullable(Of Int16)(reader("DefaultPaperOrientation")),
            .DefaultPaperSize = Extensions.AsNullable(Of Int16)(reader("DefaultPaperSize")),
            .DefaultPaperSource = Extensions.AsNullable(Of Int16)(reader("DefaultPaperSource")),
            .HostOrIpName = Extensions.AsString(reader("HostOrIpName")),
            .PrinterCode = Extensions.AsString(reader("PrinterCode")),
            .PrinterName = Extensions.AsString(reader("PrinterName"))
            }

        Private Function Take(Printer As Printer) As Object()
            Return New Object() {
                                    "@DefaultPaperOrientation", Printer.DefaultPaperOrientation,
                                    "@DefaultPaperSize", Printer.DefaultPaperSize,
                                    "@DefaultPaperSource", Printer.DefaultPaperSource,
                                    "@HostOrIpName", Printer.HostOrIpName,
                                    "@IdNo", Printer.IdNo,
                                    "@PrinterCode", Printer.PrinterCode,
                                    "@PrinterName", Printer.PrinterName
                                }
        End Function

    End Class

End Namespace