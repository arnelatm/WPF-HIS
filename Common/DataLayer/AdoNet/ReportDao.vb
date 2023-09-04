Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports CrystalDecisions.Shared

Namespace DataLayer.AdoNet
    ' Data access object for ReportSelector
    ' ** DAO Pattern

    Public Class ReportDao
        Inherits CommonDao
        Implements IDao(Of Report), IDaoListParametrized(Of Report)

        Private ReadOnly _db As New Db()

        Private Const FieldList = "Active," &
                                  "BranchIdNo," &
                                  "DatabaseName," &
                                  "DateCreated," &
                                  "IdNo," &
                                  "PrintJobIdNo," &
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
            .Active = Extensions.AsBool(reader("Active")),
            .BranchIdNo = Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
            .DatabaseName = Extensions.AsString(reader("DatabaseName")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .PrintJobIdNo = Extensions.AsInt(Of Int16)(reader("PrintJobIdNo")),
            .QueryForm = Extensions.AsString(reader("QueryForm")),
            .QueryFormParameters = Extensions.AsString(reader("QueryFormParameters")),
            .QueryParameters = Extensions.AsString(reader("QueryParameters")),
            .ReportCode = Extensions.AsString(reader("ReportCode")),
            .ReportFileName = Extensions.AsString(reader("ReportFileName")),
            .ReportName = Extensions.AsString(reader("ReportName")),
            .ReportNameAra = Extensions.AsString(reader("ReportNameAra")),
            .ReportTitle = Extensions.AsString(reader("ReportTitle")),
            .ReportTitleAra = Extensions.AsString(reader("ReportTitleAra"))
            }

        Public Function AddRecord(ByRef report As Report) As Integer Implements IDao(Of Report).AddRecord
            'Dim sql As String =
            '        " INSERT INTO [PrintSetup] " &
            '        " (QueryForm,QueryFormParameters,QueryParameters,ReportCode,ReportFileName,ReportName,ReportNameAra,ReportTitle,ReportTitleAra) " &
            '        " VALUES (@QueryForm,@QueryFormParameters,@QueryParameters,@ReportCode,@ReportFileName,@ReportName,@ReportNameAra,@ReportTitle,@ReportTitleAra)"
            Dim sql As String =
                    " INSERT INTO [PrintSetup] " &
                    " (Active,BranchIdNo,DatabaseName,PrintJobIdNo,QueryForm,QueryFormParameters,QueryParameters,ReportCode,ReportFileName,ReportName,ReportNameAra,ReportTitle,ReportTitleAra) " &
                    " VALUES (@Active,@BranchIdNo,@DatabaseName,@PrintJobIdNo,@QueryForm,@QueryFormParameters,@QueryParameters,@ReportCode,@ReportFileName,@ReportName,@ReportNameAra,@ReportTitle,@ReportTitleAra)"
            Return _db.Insert(sql, Take(report))
        End Function

        Private Function Take(report As Report) As Object()
            Return New Object() {
                                    "@IdNo", report.IdNo,
                                    "Active", report.Active,
                                    "BranchIdNo", report.BranchIdNo,
                                    "DatabaseName", report.DatabaseName,
                                    "PrintJobIdNo", report.PrintJobIdNo,
                                    "QueryForm", report.QueryForm,
                                    "QueryFormParameters", report.QueryFormParameters,
                                    "QueryParameters", report.QueryParameters,
                                    "ReportCode", report.ReportCode,
                                    "ReportFileName", report.ReportFileName,
                                    "ReportName", report.ReportName,
                                    "ReportNameAra", report.ReportNameAra,
                                    "ReportTitle", report.ReportTitle,
                                    "ReportTitleAra", report.ReportTitleAra
                                }
        End Function

        Public Function UpdateRecord(ByRef report As Report) As Integer Implements IDao(Of Report).UpdateRecord
            Dim sql As String =
                    "UPDATE Report SET " &
                    "Active = @Active," &
                    "BranchIdNo = @BranchIdNo," &
                    "DatabaseName = @DatabaseName," &
                    "PrintJobIdNo = @PrintJobIdNo," &
                    "QueryForm = @QueryForm, " &
                    "QueryFormParameters = @QueryFormParameters, " &
                    "QueryParameters = @QueryParameters, " &
                    "ReportCode = @ReportCode, " &
                    "ReportFileName = @ReportFileName, " &
                    "ReportName = @ReportName, " &
                    "ReportNameAra = @ReportNameAra, " &
                    "ReportTitle = @ReportTitle, " &
                    "ReportTitleAra = @ReportTitleAra " &
                    "WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(report))
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As Report Implements IDao(Of Report).GetRecordByIdNo
            Dim sql As String = "SELECT " & FieldList & " from Report" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetListParametrized(parameter As Object, Optional sortExpression As String = Nothing) As List(Of Report) Implements IDaoListParametrized(Of Report).GetListParametrized
            Dim reportGroup As String = parameter
            Dim params() As Object = {"@Parameter", reportGroup}
            Dim sql As String
            If sortExpression Is Nothing Or sortExpression = "" Then
                sql = " SELECT IdNo, ReportName" &
                      " FROM [Report] where Active = 1 and ReportGroup = @Parameter order by ReportOrder"
                Return _db.Read(sql, MakeList, params).ToList()
            Else
                sql = " SELECT IdNo, ReportName" &
                      " FROM [Report] where Active = 1 and ReportGroup = @Parameter order by " & sortExpression
            End If
            Return _db.Read(sql, MakeList, params).ToList()
        End Function

        Private Shared ReadOnly MakeList As Func(Of IDataReader, Report) = Function(reader) New Report() With {
            .ReportName = Extensions.AsString(reader("ReportName")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo"))
        }

    End Class

End Namespace