Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ReportSelector
    ' ** DAO Pattern

    Public Class ReportDao
        Inherits CommonDao
        Implements IDao(Of ReportSelector)


        Private ReadOnly Db As New Db()
        Private Const FieldList =   "IdNo," &
                                    "QueryForm," &
                                    "ReportCode," &
                                    "ReportFileName," &
                                    "ReportName," &
                                    "ReportNameAra," &
                                    "ReportTitle," &
                                    "ReportTitleAra" 
              

        Private Shared ReadOnly Make As Func(Of IDataReader, ReportSelector) =
                                    Function(reader) _
            New ReportSelector() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .QueryForm = Extensions.AsString(reader("QueryForm")),
            .ReportCode = Extensions.AsString(reader("ReportCode")),
            .ReportFileName = Extensions.AsString(reader("ReportFileName")),
            .ReportName = Extensions.AsString(reader("ReportName")),
            .ReportNameAra = Extensions.AsString(reader("ReportNameAra")),
            .ReportTitle = Extensions.AsString(reader("ReportTitle"))
            }


        Public Function AddRecord(ByRef recordData As ReportSelector) As Integer Implements IDao(Of ReportSelector).AddRecord
            Throw New NotImplementedException()
        End Function

        Public Function UpdateRecord(ByRef recordData As ReportSelector) As Integer Implements IDao(Of ReportSelector).UpdateRecord
            Throw New NotImplementedException()
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As ReportSelector Implements IDao(Of ReportSelector).GetRecordByIdNo
            Dim sql As String = "SELECT" & FieldList & " from Report" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function
    End Class

End Namespace