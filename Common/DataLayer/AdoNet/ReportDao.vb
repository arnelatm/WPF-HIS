Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for ReportSelector
    ' ** DAO Pattern

    Public Class ReportDao
        Inherits CommonDao
        Implements IDao(Of Report), IDaoListParametrized(Of Report), IDaoList(Of ReportGroup)

        Private ReadOnly _db As New Db()

        Private Const FieldList = "Active," &
                                  "BranchIdNo," &
                                  "DatabaseName," &
                                  "DateCreated," &
                                  "ReportGroupIdNo," &
                                  "IdNo," &
                                  "PrintJobIdNo," &
                                  "QueryForm," &
                                  "QueryFormParameters," &
                                  "QueryParameters," &
                                  "ReportCode," &
                                  "ReportFileName," &
                                  "ReportName," &
                                  "ReportNameAra," &
                                  "ReportOrder," &
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
            .ReportGroupIdNo = Extensions.AsInt(Of Int16)(reader("ReportGroupIdNo")),
            .ReportName = Extensions.AsString(reader("ReportName")),
            .ReportNameAra = Extensions.AsString(reader("ReportNameAra")),
            .ReportOrder = Extensions.AsInt(Of Int16)(reader("ReportOrder")),
            .ReportTitle = Extensions.AsString(reader("ReportTitle")),
            .ReportTitleAra = Extensions.AsString(reader("ReportTitleAra"))
            }

        Public Function AddRecord(ByRef report As Report) As Integer Implements IDao(Of Report).AddRecord
            'Dim sql As String =
            '        " INSERT INTO [PrintSetup] " &
            '        " (QueryForm,QueryFormParameters,QueryParameters,ReportCode,ReportFileName,ReportName,ReportNameAra,ReportTitle,ReportTitleAra) " &
            '        " VALUES (@QueryForm,@QueryFormParameters,@QueryParameters,@ReportCode,@ReportFileName,@ReportName,@ReportNameAra,@ReportTitle,@ReportTitleAra)"
            Dim sql As String =
                    " INSERT INTO Report " &
                    " (Active,BranchIdNo,DatabaseName,PrintJobIdNo,QueryForm,QueryFormParameters,QueryParameters,ReportCode,ReportFileName,ReportGroupIdNo,ReportName,ReportNameAra,ReportOrder,ReportTitle,ReportTitleAra) " &
                    " VALUES (@Active,@BranchIdNo,@DatabaseName,@PrintJobIdNo,@QueryForm,@QueryFormParameters,@QueryParameters,@ReportCode,@ReportFileName,@ReportGroupIdNo,@ReportName,@ReportNameAra,@ReportOrder,@ReportTitle,@ReportTitleAra)"
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
                                    "ReportGroupIdNo", report.ReportGroupIdNo,
                                    "ReportName", report.ReportName,
                                    "ReportNameAra", report.ReportNameAra,
                                    "ReportOrder", report.ReportOrder,
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
                    "ReportGroupIdNo = @ReportGroupIdNo, " &
                    "ReportName = @ReportName, " &
                    "ReportNameAra = @ReportNameAra, " &
                    "ReportOrder = @ReportOrder, " &
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

        Public Function GetListParametrized(reportGroupIdNo As Object, Optional sortExpression As String = Nothing) As List(Of Report) Implements IDaoListParametrized(Of Report).GetListParametrized
            Dim sql As String
            Dim params() As Object = {"@Parameter", CInt(reportGroupIdNo)}
            If sortExpression Is Nothing Or sortExpression = "" Then
                sql = " SELECT IdNo, ReportName" &
                      " FROM [Report] where Active = 1 and ReportGroupIdNo = @Parameter order by ReportOrder"
                Return _db.Read(sql, MakeList, params).ToList()
            Else
                sql = " SELECT IdNo, ReportName" &
                      " FROM [Report] where Active = 1 and ReportGroupIdNo = @Parameter order by " & sortExpression
            End If
            Return _db.Read(sql, MakeList, params).ToList()
        End Function

        Public Function GetList(Optional sortExpression As String = Nothing) As List(Of ReportGroup) Implements IDaoList(Of ReportGroup).GetList
            Dim sql As String
            If sortExpression Is Nothing Or sortExpression = "" Then
                If UserIsASuperAdmin() Then
                    sql = " SELECT IdNo, ReportGroupName, ReportGroupCode, ReportGroupNameAra" &
                      " FROM ReportGroup order by ReportGroupName"
                Else
                    sql = " SELECT Distinct IdNo, ReportGroupName, ReportGroupCode, ReportGroupNameAra" &
                          " FROM ReportGroup_View where SecuritygroupIdNo = " & GlobalVariables.SecurityGroupIdNo.ToString() & " or UserIdNo = " & GlobalVariables.UserIdNo.ToString() + " order by ReportGroupName "
                End If

                Return _db.Read(sql, MakeList2).ToList()
            Else
                If UserIsASuperAdmin() Then
                    sql = " SELECT IdNo, ReportGroupName, ReportGroupCode, ReportGroupNameAra" &
                      " FROM ReportGroup order by " & sortExpression
                Else
                    sql = " SELECT Distinct IdNo, ReportGroupName, ReportGroupCode, ReportGroupNameAra" &
                      " FROM ReportGroup_View  " & GlobalVariables.SecurityGroupIdNo.ToString() & " or UserIdNo = " & GlobalVariables.UserIdNo.ToString() & " order by " & sortExpression
                End If

                Return _db.Read(sql, MakeList2).ToList()
            End If
            Return _db.Read(sql, MakeList2).ToList()
        End Function

        Private Shared ReadOnly MakeList As Func(Of IDataReader, Report) = Function(reader) New Report() With {
            .ReportName = Extensions.AsString(reader("ReportName")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo"))
        }

        Private Shared ReadOnly MakeList2 As Func(Of IDataReader, ReportGroup) = Function(reader) New ReportGroup() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .ReportGroupCode = Extensions.AsString(reader("ReportGroupCode")),
            .ReportGroupName = Extensions.AsString(reader("ReportGroupName")),
            .ReportGroupNameAra = Extensions.AsString(reader("ReportGroupNameAra"))}

    End Class

End Namespace