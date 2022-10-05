Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

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

        Public Function GetParametrized(parameter As Object, Optional sortExpression As String = Nothing) As PmrInvestigation Implements IDaoParametrized(Of PmrInvestigation).GetParametrized
            Dim doctorId As String = parameter(0).ToString()
            Dim transactionDate As Date? = parameter(1)
            Dim dateString As String = CDate(transactionDate).ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture)
            Dim sql As String = "SELECT EmpNameEnglish from EmployeeDetails where EmpId = '" + doctorId.ToString() + "'"
            Dim data As New PmrInvestigation
            data = _db.Read(sql, Make).FirstOrDefault()
            data.DoctorID = doctorId
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@DoctorId", doctorId, "@TransactionDate", dateString}
            sql = $"SELECT [CreateDate], [File No], [Inv Type], [Name], [Status], [Token], [Type] from PmrPatientDisplay_View where doctorid = @DoctorId and [TransDateEnglish] = @TransactionDate and Token <> 0 order by Cast(token as int) desc"
            data.PmrPatientsDisplay = _db.Read(sql, MakePmrPatientDetails, params).ToList()
            Return data
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PmrInvestigation) = Function(reader) New PmrInvestigation() With
            {
            .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmpNameEnglish"))
            }

        Private Shared ReadOnly MakePmrPatientDetails As Func(Of IDataReader, PmrPatientDisplay) = Function(reader) New PmrPatientDisplay() With
            {
            .CreateDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("CreateDate")),
            .FileNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("File No")),
            .InvType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Inv Type")),
            .Name = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Name")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Status")),
            .Token = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Token")),
            .PType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Type"))
            }

    End Class

End Namespace