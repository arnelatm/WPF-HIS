Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeDocument
    ' ** DAO Pattern

    Public Class EmployeeDocumentDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeDocument)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeDocument) Implements IDaoChild(Of EmployeeDocument).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "DataImageIdNo," &
                    "DocumentIdNo," &
                    "DocumentNumber," &
                    "EmployeeIdNo," &
                    "ExpiryDate," &
                    "IdNo," &
                    "IssueDate," &
                    "Sequence" &
                    " FROM EmployeeDocument" &
                    " WHERE EmployeeIdNo = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeDocument).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeeDocumentTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeDocument).InsertTvp
            Return Db.InsertTvp("InsertEmployeeDocumentTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeDocument) =
                                    Function(reader) _
            New EmployeeDocument() With {
            .DataImageIdNo = Extensions.AsInt(Of Int32)(reader("DataImageIdNo")),
            .DocumentIdNo = Extensions.AsInt(Of Int16)(reader("DocumentIdNo")),
            .DocumentNumber = Extensions.AsString(reader("DocumentNumber")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .ExpiryDate = Extensions.AsNullable(Of Date?)(reader("ExpiryDate")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .IssueDate = Extensions.AsNullable(Of Date?)(reader("IssueDate")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace