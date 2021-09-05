Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EmployeePayElement
    ' ** DAO Pattern

    Public Class EmployeePayElementDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeePayElement), IDaoGetRecordByIdNo(Of EmployeePayElement), IDaoGetRecords(Of EmployeePayElement), IDaoGetRecord(Of EmployeePayElement)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "Amount," &
                                    "PayElementCode," &
                                    "PayElementIdNo," &
                                    "PayElementName," &
                                    "PayElementNameAra," &
                                    "PayElementType," &
                                    "EmployeeIdNo," &
                                    "IdNo," &
                                    "Rate," &
                                    "Sequence," &
                                    "Unit"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeePayElement) Implements IDaoChild(Of EmployeePayElement).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim filter = "PayElementType='" + GlobalFunctions.EnumToCode(PayElementTypeSelection.Regular) + "'"
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [EmployeePayElement_View]" &
                    " WHERE EmployeeIdNo = @IdNo and " & filter &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeePayElement).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeePayElementTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeePayElement).InsertTvp
            Return Db.InsertTvp("InsertEmployeePayElementTVP", tvpTable)
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As List(Of EmployeePayElement) Implements IDaoGetRecordByIdNo(Of EmployeePayElement).GetRecordByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [EmployeePayElement_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeePayElement) =
                                    Function(reader) _
            New EmployeePayElement() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .PayElementCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayElementCode")),
            .PayElementIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("PayElementIdNo")),
            .PayElementName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayElementName")),
            .PayElementNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayElementNameAra")),
            .PayElementType = AATM.DataLayer.AdoNet.Extensions.AsChar(reader("PayElementType")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Rate = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Rate")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .Unit = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Unit"))
           }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeePayElement) Implements IDaoGetRecords(Of EmployeePayElement).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [EmployeePayElement_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As EmployeePayElement Implements IDaoGetRecord(Of EmployeePayElement).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [EmployeePayElement_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As EmployeePayElement = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace