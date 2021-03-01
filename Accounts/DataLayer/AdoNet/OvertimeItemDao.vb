Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for OvertimeItem
    ' ** DAO Pattern

    Public Class OvertimeItemDao
        Inherits AccountsDao
        Implements IDaoChild(Of OvertimeItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(PayrollIdNo, Optional sortExpression = Nothing) As List(Of OvertimeItem) Implements IDaoChild(Of OvertimeItem).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName"
            End If
            If GlobalVariables.RightToLeftLayout Then
                If sortExpression = "EmployeeName" Then
                    sortExpression = "EmployeeNameAra"
                End If
            End If
            Dim sql As String =
                    "SELECT " &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "IdNo," &
                    "OvertimeRegular," &
                    "OvertimeHoliday," &
                    "OvertimeSpecial," &
                    "PayrollIdNo," &
                    "ROW_NUMBER() over(Order by " & sortExpression & ") As 'Sequence'" &
                    " FROM [OvertimeItem_View]" &
                    " WHERE PayrollIdNo = @PayrollIdNo "
            Dim params() As Object = {"@PayrollIdNo", PayrollIdNo}
            Dim dta = Db.Read(sql, Make, params).ToList()
            Return dta
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of OvertimeItem).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateOvertimeItemTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of OvertimeItem).InsertTvp
            Return Db.InsertTvp("InsertOvertimeItemTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, OvertimeItem) =
                                    Function(reader) _
            New OvertimeItem() With {
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .OvertimeRegular = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("OvertimeRegular")),
            .OvertimeHoliday = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("OvertimeHoliday")),
            .OvertimeSpecial = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("OvertimeSpecial")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayrollIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace