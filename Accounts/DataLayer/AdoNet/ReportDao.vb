Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ReportSelector
    ' ** DAO Pattern

    Public Class ReportDao
        Inherits CommonDao
        Implements IDao(Of Report), IDaoList(Of Report)


        Private ReadOnly Db As New Db()
        Private Const FieldList = "IdNo," &
                                    "QueryForm," &
                                    "ReportCode," &
                                    "ReportFileName," &
                                    "ReportName," &
                                    "ReportNameAra," &
                                    "ReportTitle," &
                                    "ReportTitleAra"


        Private Shared ReadOnly Make As Func(Of IDataReader, Report) =
                                    Function(reader) _
            New Report() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .QueryForm = Extensions.AsString(reader("QueryForm")),
            .ReportCode = Extensions.AsString(reader("ReportCode")),
            .ReportFileName = Extensions.AsString(reader("ReportFileName")),
            .ReportName = Extensions.AsString(reader("ReportName")),
            .ReportNameAra = Extensions.AsString(reader("ReportNameAra")),
            .ReportTitle = Extensions.AsString(reader("ReportTitle"))
            }


        Public Function AddRecord(ByRef recordData As Report) As Integer Implements IDao(Of Report).AddRecord
            Throw New NotImplementedException()
        End Function

        Public Function UpdateRecord(ByRef recordData As Report) As Integer Implements IDao(Of Report).UpdateRecord
            Throw New NotImplementedException()
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As Report Implements IDao(Of Report).GetRecordByIdNo
            Dim sql As String = "SELECT " & FieldList & " from Report" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetList(Optional sortExpression As String = Nothing) As List(Of Report) Implements IDaoList(Of Report).GetList
            If sortExpression Is Nothing Then
                sortExpression = "ReportName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, ReportName" &
                    " FROM [Report] where Active = 1 order by " & sortExpression
            Return db.Read(sql, MakeList).ToList()
        End Function

        Private Shared ReadOnly MakeList As Func(Of IDataReader, Report) = Function(reader) New Report() With {
            .ReportName = Extensions.AsString(reader("ReportName")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo"))    
        }

    End Class

End Namespace