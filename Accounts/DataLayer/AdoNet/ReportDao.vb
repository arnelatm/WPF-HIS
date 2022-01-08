Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ReportSelector
    ' ** DAO Pattern

    Public Class ReportDao
        Inherits CommonDao
        Implements IDao(Of Report), IDaoListParametrized(Of Report)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "IdNo," &
                                    "QueryForm," &
                                    "QueryFormParameters," &
                                    "QueryParameters," &
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
            .QueryFormParameters = Extensions.AsString(reader("QueryFormParameters")),
            .QueryParameters = Extensions.AsString(reader("QueryParameters")),
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
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetListParametrized(parameter As Object, Optional sortExpression As String = Nothing) As List(Of Report) Implements IDaoListParametrized(Of Report).GetListParametrized
            Dim reportGroup As String = parameter
            Dim params() As Object = {"@Parameter", reportGroup}
            Dim sql As String
            If sortExpression Is Nothing Or sortExpression = "" Then
                sql = " SELECT IdNo, ReportName" &
                      " FROM [Report] where Active = 1 and ReportGroup = @Parameter order by ReportOrder"
                Return Db.Read(sql, MakeList, params).ToList()
            Else
                sql = " SELECT IdNo, ReportName" &
                      " FROM [Report] where Active = 1 and ReportGroup = @Parameter order by " & sortExpression
            End If
            Return Db.Read(sql, MakeList, params).ToList()
        End Function

        Private Shared ReadOnly MakeList As Func(Of IDataReader, Report) = Function(reader) New Report() With {
            .ReportName = Extensions.AsString(reader("ReportName")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo"))
        }

    End Class

End Namespace