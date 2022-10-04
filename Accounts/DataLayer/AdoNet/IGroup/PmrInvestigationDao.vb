Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.BusinessLayer.IGroup
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class PmrInvestigationDao
        Inherits CommonDao
        Implements IDaoParametrized(Of PmrInvestigation)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "Trans_Key"
        End Function

        'Private Function GetRecordByIdNo(idNo As Object) As PmrInvestigation Implements IDaoReadOnly(Of PmrInvestigation).GetRecordByIdNo
        '    Dim sql As String = "SELECT EmpNameEnglish from EmpDetails EmployeeDetails where EmpId = " + idNo.ToString()
        '    Dim data As New PmrInvestigation
        '    Return _db.Read(sql, Make)

        'End Function

        'Private Function GetPmrPatients(Optional filter As String = Nothing) As List(Of PmrPatientDisplay) Implements IDaoGetParametrized(Of PmrPatientDisplay).GetDaoRecords
        '    Dim sql As String = "SELECT [CreateDate], [File No], [Inv Type], [Name], [Status], [Token], [Type] from PmrPatientDisplay where " & filter
        '    Dim data As New List(Of PmrPatientDisplay)
        '    data = _db.Read(sql, MakePmrPatientDetails).ToList()
        '    Return data
        'End Function

        Public Function GetParametrized(parameter As Object, Optional sortExpression As String = Nothing) As PmrInvestigation Implements IDaoParametrized(Of PmrInvestigation).GetParametrized
            Dim doctorId As String = parameter(0)
            Dim transactionDate As String = parameter(1)
            Dim sql As String = "SELECT EmpNameEnglish from EmployeeDetails where EmpId = '" + doctorId.ToString() + "'"
            Dim data As New PmrInvestigation
            data = _db.Read(sql, Make)
            sql = "SELECT [CreateDate], [File No], [Inv Type], [Name], [Status], [Token], [Type] from PmrPatientDisplay where [DoctorId] = @doctorId and [TransactionDate] = @transactionDate and Token <> 0"
            data.PmrPatientDisplay = _db.Read(sql, MakePmrPatientDetails).ToList()
            Return data
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PmrInvestigation) = Function(reader) New PmrInvestigation() With
            {
            .DoctorName = Extensions.AsString(reader("EmpNameEnglish"))
            }

        Private Shared ReadOnly MakePmrPatientDetails As Func(Of IDataReader, PmrPatientDisplay) = Function(reader) New PmrPatientDisplay() With
            {
            .CreateDate = Extensions.AsDateTime(reader("CreateDate")),
            .File_No = Extensions.AsString(reader("File_No")),
            .Inv_Type = Extensions.AsString(reader("Inv_Type")),
            .Name = CType(Extensions.AsString(reader("Name")), Date),
            .Status = Extensions.AsBool(reader("Status")),
            .Token = Extensions.AsInt(Of Int16)(reader("Token")),
            .Type = Extensions.AsBool(reader("Type"))
            }

    End Class

End Namespace