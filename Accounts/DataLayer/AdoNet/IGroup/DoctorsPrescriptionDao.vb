Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class DoctorsPrescriptionDao
        'Inherits PmrInvestigationDao
        Implements IDoctorsPrescriptionDao
        'Implements IDaoParametrized(Of DoctorsPrescription), IDoctorsPrescriptionDao

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        'Public Overrides Function GetDB()
        '    Return _db
        'End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Overloads Function GetParametrized(parameter As Object, Optional sortExpression As String = Nothing) As DoctorsPrescription Implements IDaoParametrized(Of DoctorsPrescription).GetParametrized
            Dim doctorCode As String = parameter(0).ToString()
            Dim transactionDate As Date? = parameter(1)
            Dim dateString As String = CDate(transactionDate).ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture)
            Dim sql As String = "SELECT EmpNameEnglish from EmployeeDetails where EmpId = '" + doctorCode.ToString() + "'"
            Dim data As New DoctorsPrescription
            data = _db.Read(sql, Make).FirstOrDefault()
            data.DoctorCode = doctorCode
            data.DoctorName = doctorCode
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@DoctorId", doctorCode, "@TransactionDate", dateString}
            sql = $"SELECT Distinct [PmrDate], [FileNo], [FileType], [PatientName], [Status], [TokenNo], [PType], [LastConsDate], [Trans_Key], [InvTime] from PmrDoctorsGenForm_View where doctorid = @DoctorId and PmrDate = @TransactionDate and not (trans_key is Null and tokenno = 0) order by tokenno desc"
            data.DoctorsPatients = _db.Read(sql, MakeDoctorsPatient, params).ToList()
            'params = {"@Trans_Key", data.DoctorsPatients(0).TransKey}
            'sql = $"SELECT RowNbr, ItemNameEnglish, DosageEnglish, Duration from PmrMedicineDetails_View where Trans_Key = @Trans_Key order by rowNbr"
            'data.PrescriptionDetails = _db.Read(sql, MakePrescriptionDetail, params).ToList()
            Return data
        End Function

        'Private Shared ReadOnly Make As Func(Of IDataReader, DoctorsPrescription) = Function(reader) New DoctorsPrescription() With
        '    {
        '    .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmpNameEnglish"))
        '    }

        'Private Shared ReadOnly MakeDoctorsPatient As Func(Of IDataReader, DoctorsPatient) = Function(reader) New DoctorsPatient() With
        '    {
        '    .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PmrDate")),
        '    .FileNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("FileNo")),
        '    .InvType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("FileType")),
        '    .Name = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
        '    .Status = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Status")),
        '    .Token = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("TokenNo")),
        '    .PType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PType")),
        '    .LastConsDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LastConsDate")),
        '    .InvTime = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("InvTime")),
        '    .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Trans_Key"))
        '    }

        Private Shared ReadOnly MakePrescriptionDetail As Func(Of IDataReader, PrescriptionDetail) = Function(reader) New PrescriptionDetail() With
            {
            .ItemNameEnglish = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameEnglish")),
            .DosageEnglish = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageEnglish")),
            .Duration = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Duration")),
            .Item_Code = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Item_Code")),
            .RowNbr = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Item_Code")),
            .Trans_Key = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Trans_key"))
            }
        Public Function GetPrescriptionDetail(productIdNo As Int32) As List(Of PrescriptionDetail) Implements IDoctorsPrescriptionDao.GetPrescriptionDetail
            Dim prescriptionDetailDao = New PrescriptionDetailDao
            Return prescriptionDetailDao.GetRecordsWithGroupIdNo(productIdNo)
        End Function

    End Class

    Public Interface IDoctorsPrescriptionDao
        Function GetPrescriptionDetail(productIdNo As Integer) As List(Of PrescriptionDetail)

    End Interface

End Namespace