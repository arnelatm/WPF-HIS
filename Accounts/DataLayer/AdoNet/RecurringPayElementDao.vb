Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for RecurringPayElement
    ' ** DAO Pattern

    Public Class RecurringPayElementDao
        Inherits CommonDao
        Implements IDaoAll(Of RecurringPayElement)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As RecurringPayElement Implements IDaoAll(Of RecurringPayElement).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, EmployeeIdNo, Amount, StartDate, PeriodicPayment, PayElementIdNo, DateCreated" &
                    "   FROM [RecurringPayElement_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of RecurringPayElement) _
            Implements IDaoAll(Of RecurringPayElement).GetAll
            If sortExpression = Nothing Then
                sortExpression = " ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeIdNo" &
                    "   FROM [RecurringPayElement] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef recurringPayElement As RecurringPayElement) As Integer Implements IDaoAll(Of RecurringPayElement).UpdateRecord
            Dim sql As String =
                    " UPDATE [RecurringPayElement]" &
                    " SET EmployeeIdNo = @EmployeeIdNo," &
                    " Amount = @Amount," &
                    " StartDate = @StartDate," &
                    " PayElementIdNo = @PayElementIdNo," &
                    " PeriodicPayment = @PeriodicPayment" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(recurringPayElement))
        End Function

        Public Function AddRecord(ByRef recurringPayElement As RecurringPayElement) As Integer Implements IDaoAll(Of RecurringPayElement).AddRecord
            Dim sql As String =
                    " INSERT INTO [RecurringPayElement] " &
                    " (EmployeeIdNo,StartDate,PayElementIdNo,PeriodicPayment,Amount) " &
                    " VALUES (@EmployeeIdNo,@StartDate,@PayElementIdNo,@PeriodicPayment,@Amount) "
            Return Db.Insert(sql, Take(recurringPayElement))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, RecurringPayElement) =
                                    Function(reader) _
            New RecurringPayElement() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .StartDate = Extensions.AsDate(reader("StartDate")),
            .PayElementIdNo = Extensions.AsInt(Of Int16)(reader("PayElementIdNo")),
            .PeriodicPayment = Extensions.AsDecimal(reader("PeriodicPayment")),
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated"))
            }

        Public Sub New()

        End Sub

        Private Function Take(recurringPayElement As RecurringPayElement) As Object()
            Return New Object() {
                                    "@IdNo", recurringPayElement.IdNo,
                                    "@Amount", recurringPayElement.Amount,
                                    "@EmployeeIdNo", recurringPayElement.EmployeeIdNo,
                                    "@StartDate", recurringPayElement.StartDate,
                                    "@PayElementIdNo", recurringPayElement.PayElementIdNo,
                                    "@PeriodicPayment", recurringPayElement.PeriodicPayment
                                }
        End Function

    End Class

End Namespace