Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for RecurringPayElement
    ' ** DAO Pattern

    Public Class RecurringPayElementDao
        Inherits CommonDao
        Implements IDao(Of RecurringPayElement), IDaoGetRecords(Of RecurringPayElement)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "Active," &
                                  "DateCreated, " &
                                  "EmployeeIdNo," &
                                  "EndDate," &
                                  "IdNo," &
                                  "LimitAmount," &
                                  "PeriodicAmount," &
                                  "PayElementIdNo," &
                                  "RecurType," &
                                  "StartDate," &
                                  "TotalAmount"

        Public Function GetRecordByIdNo(idNo) As RecurringPayElement Implements IDao(Of RecurringPayElement).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    "   FROM [RecurringPayElement_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef recurringPayElement As RecurringPayElement) As Integer Implements IDao(Of RecurringPayElement).UpdateRecord
            Dim sql As String =
                    "UPDATE [RecurringPayElement] Set " &
                    "Active = @Active," &
                    "EmployeeIdNo = @EmployeeIdNo," &
                    "EndDate = @EndDate," &
                    "LimitAmount = @LimitAmount," &
                    "PayElementIdNo = @PayElementIdNo," &
                    "PeriodicAmount = @PeriodicAmount," &
                    "RecurType = @RecurType," &
                    "StartDate = @StartDate " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(recurringPayElement))
        End Function

        Public Function AddRecord(ByRef recurringPayElement As RecurringPayElement) As Integer Implements IDao(Of RecurringPayElement).AddRecord
            Dim sql As String =
                    " INSERT INTO [RecurringPayElement] " &
                    " (Active,EmployeeIdNo,EndDate,LimitAmount,PayElementIdNo,PeriodicAmount,RecurType,StartDate) " &
                    " VALUES (@Active,@EmployeeIdNo,@EndDate,@LimitAmount,@PayElementIdNo,@PeriodicAmount,@RecurType,@StartDate) "
            Return Db.Insert(sql, Take(recurringPayElement))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of RecurringPayElement) Implements IDaoGetRecords(Of RecurringPayElement).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [RecurringPayElement_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, RecurringPayElement) =
                                    Function(reader) _
            New RecurringPayElement() With {
            .Active = Extensions.AsBool(reader("Active")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = Extensions.AsDate(reader("EndDate")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .LimitAmount = Extensions.AsDecimal(reader("LimitAmount")),
            .PayElementIdNo = Extensions.AsInt(Of Int16)(reader("PayElementIdNo")),
            .PeriodicAmount = Extensions.AsDecimal(reader("PeriodicAmount")),
            .RecurType = Extensions.AsString(reader("RecurType")),
            .StartDate = Extensions.AsDate(reader("StartDate")),
            .TotalAmount = Extensions.AsDecimal(reader("TotalAmount"))
            }

        Public Sub New()

        End Sub

        Private Function Take(recurringPayElement As RecurringPayElement) As Object()
            Return New Object() {
                                    "@Active", recurringPayElement.Active,
                                    "@EmployeeIdNo", recurringPayElement.EmployeeIdNo,
                                    "@EndDate", recurringPayElement.EndDate,
                                    "@IdNo", recurringPayElement.IdNo,
                                    "@LimitAmount", recurringPayElement.LimitAmount,
                                    "@PayElementIdNo", recurringPayElement.PayElementIdNo,
                                    "@PeriodicAmount", recurringPayElement.PeriodicAmount,
                                    "@RecurType", recurringPayElement.RecurType,
                                    "@StartDate", recurringPayElement.StartDate
                                }
        End Function

    End Class

End Namespace