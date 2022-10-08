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

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetParametrized(parameter As Object, Optional sortExpression As String = Nothing) As PmrInvestigation Implements IDaoParametrized(Of PmrInvestigation).GetParametrized
            Dim doctorCode As String = parameter(0).ToString()
            Dim transactionDate As Date? = parameter(1)
            Dim dateString As String = CDate(transactionDate).ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture)
            Dim sql As String = "SELECT EmpNameEnglish from EmployeeDetails where EmpId = '" + doctorCode.ToString() + "'"
            Dim data As New PmrInvestigation
            data = _db.Read(sql, Make).FirstOrDefault()
            data.DoctorCode = doctorCode
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@DoctorId", doctorCode, "@TransactionDate", dateString}
            sql = $"SELECT Distinct [PmrDate], [FileNo], [FileType], [PatientName], [Status], [TokenNo], [PType], [LastConsDate], [Trans_Key], [InvTime] from PmrDoctorsGenForm_View where doctorid = @DoctorId and PmrDate = @TransactionDate and not (trans_key is Null and tokenno = 0) order by tokenno desc"
            data.PmrPatientsDisplay = _db.Read(sql, MakePmrPatientDetails, params).ToList()
            Return data
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PmrInvestigation) = Function(reader) New PmrInvestigation() With
            {
            .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmpNameEnglish"))
            }

        Private Shared ReadOnly MakePmrPatientDetails As Func(Of IDataReader, PmrPatientDisplay) = Function(reader) New PmrPatientDisplay() With
            {
            .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PmrDate")),
            .FileNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("FileNo")),
            .InvType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("FileType")),
            .Name = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Status")),
            .Token = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("TokenNo")),
            .PType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PType")),
            .LastConsDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("LastConsDate")),
            .InvTime = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("InvTime")),
            .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Trans_Key"))
            }

    End Class

End Namespace