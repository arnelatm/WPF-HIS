Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeePhone
    ' ** DAO Pattern

    Public Class EmployeePhoneDao
        Inherits DaoAccounts
        Implements IDaoChild(Of EmployeePhone)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of EmployeePhone) Implements IDaoChild(Of EmployeePhone).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " &
                    "AreaCode," &
                    "EmployeeIdNo," &
                    "FullPhone," &
                    "FullPhoneAra," &
                    "IdNo," &
                    "CountryTelIdNo," &
                    "PhoneNumber," &
                    "PhoneTypeIdNo," &
                    "Sequence" &
                    " FROM [EmployeePhone_View]" &
                    " WHERE EmployeeIdNo = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeePhone).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeePhoneTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeePhone).InsertTvp
            Return Db.InsertTvp("InsertEmployeePhoneTVP", tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeePhone) =
                                    Function(reader) _
            New EmployeePhone() With {
            .AreaCode = Extensions.AsString(reader("AreaCode")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .CountryTelIdNo = Extensions.AsId(Of Int16)(reader("CountryTelIdNo")),
            .FullPhone = Extensions.AsString(reader("FullPhone")),
            .FullPhoneAra = Extensions.AsString(reader("FullPhoneAra")),
            .PhoneNumber = Extensions.AsString(reader("PhoneNumber")),
            .PhoneTypeIdNo = Extensions.AsId(Of Int16)(reader("PhoneTypeIdNo")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace