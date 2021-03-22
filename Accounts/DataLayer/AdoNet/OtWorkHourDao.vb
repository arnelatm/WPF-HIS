Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for OtWorkHour
    ' ** DAO Pattern

    Public Class OtWorkHourDao
        Inherits AccountsDao
        Implements IDaoChild(Of OtWorkHour), IDaoGetRecord(Of OtWorkHour)

        Private ReadOnly Db As New Db()

        Private ReadOnly FieldList As String = "EmployeeIdNo," &
                                               "EmployeeName," &
                                               "EmployeeNameAra," &
                                               "HoursWorked," &
                                               "IdNo," &
                                               "OvertimeRegular," &
                                               "OvertimeHoliday," &
                                               "OvertimeSpecial," &
                                               "PayrollIdNo"

        Public Function GetRecordsWithGroupIdNo(PayrollIdNo, Optional sortExpression = Nothing) As List(Of OtWorkHour) Implements IDaoChild(Of OtWorkHour).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName"
            End If
            If GlobalVariables.RightToLeftLayout Then
                If sortExpression = "EmployeeName" Then
                    sortExpression = "EmployeeNameAra"
                End If
            End If
            Dim sql As String =
                    "SELECT " & FieldList &
                    ",ROW_NUMBER() over(Order by " & sortExpression & ") As 'Sequence'" &
                    " FROM [OtWorkHour_View]" &
                    " WHERE PayrollIdNo = @PayrollIdNo "
            Dim params() As Object = {"@PayrollIdNo", PayrollIdNo}
            Dim dta = Db.Read(sql, Make, params).ToList()
            Return dta
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of OtWorkHour).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateOtWorkHourTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of OtWorkHour).InsertTvp
            Return Db.InsertTvp("InsertOtWorkHourTVP", tvpTable)
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As OtWorkHour Implements IDaoGetRecord(Of OtWorkHour).GetRecord
            Dim sql As String = "SELECT Top 1 " &
                                FieldList &
                                " FROM [OtWorkHour_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).FirstOrDefault()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, OtWorkHour) =
                                    Function(reader) _
            New OtWorkHour() With {
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .HoursWorked = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("HoursWorked")),
            .OvertimeRegular = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("OvertimeRegular")),
            .OvertimeHoliday = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("OvertimeHoliday")),
            .OvertimeSpecial = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("OvertimeSpecial")),
            .PayrollIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayrollIdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace