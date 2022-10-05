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
            Dim doctorId As String = parameter(0).ToString()
            Dim transactionDate As Date = parameter(1)
            Dim dateString As String = transactionDate.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture)
            Dim sql As String = "SELECT EmpNameEnglish from EmployeeDetails where EmpId = '" + doctorId.ToString() + "'"
            Dim data As New PmrInvestigation  
            data = _db.Read(sql, Make).FirstOrDefault()
            data.DoctorID = doctorId
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@DoctorId", doctorId, "@TransactionDate", dateString} 
            sql = "SELECT [CreateDate], [File No], [Inv Type], [Name], [Status], [Token], [Type] from PmrPatientDisplay_View where doctorid = @DoctorId and [TransDateEnglish] = @TransactionDate and Token <> 0 order by Cast(token as int) desc"
            data.PmrPatientDisplay = _db.Read(sql, MakePmrPatientDetails, params).ToList()
            Return data
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PmrInvestigation) = Function(reader) New PmrInvestigation() With
            {
            .DoctorName = Extensions.AsString(reader("EmpNameEnglish"))
            }

        Private Shared ReadOnly MakePmrPatientDetails As Func(Of IDataReader, PmrPatientDisplay) = Function(reader) New PmrPatientDisplay() With
            {
            .CreateDate = Extensions.AsDateTime(reader("CreateDate")),
            .File_No = Extensions.AsString(reader("File No")),
            .Inv_Type = Extensions.AsString(reader("Inv Type")),
            .Name = Extensions.AsString(reader("Name")),
            .Status = Extensions.AsChar(reader("Status")),
            .Token = Extensions.AsInt(Of Int16)(reader("Token")),
            .Type = Extensions.AsBool(reader("Type"))
            }

    End Class

End Namespace