Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class PrescriptionDao
        Inherits CommonDao
        Implements IDao(Of Prescription)

        'Implements IPrescriptionDao
        'Implements IDaoParametrized(Of Prescription), IPrescriptionDao

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Private FieldList As String = "Age," &
                                      "AgeYmd," &
                                      "Dob," &
                                      "DoctorCode," &
                                      "DoctorName," &
                                      "FileNo," &
                                      "Gender," &
                                      "PatientName," &
                                      "Series," &
                                      "TransDate," &
                                      "TransKey"

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "TransKey"
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As Prescription Implements IDao(Of Prescription).GetRecordByIdNo
            Dim sql As String = "Select " & FieldList & " FROM Prescription_View " &
                "Where TransKey = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data As New Prescription
            data = _db.Read(sql, Make, params).FirstOrDefault()
            'sql = $"select * PrescriptionItem_View order by RowNbr where transKey = @IdNo"
            Dim piDao As New PrescriptionItemDao
            data.PrescriptionDetails = piDao.GetRecordsWithGroupIdNo(data.TransKey, "RowNbr")
            'params = {"@trans_key", data.doctorspatients(0).transkey}
            'sql = $"select rownbr, itemnameenglish, dosageenglish, duration from pmrmedicinedetails_view where trans_key = @trans_key order by rownbr"
            'data.prescriptiondetails = _db.read(sql, makeprescriptiondetail, params).tolist()
            Return data
        End Function

        'Public Overloads Function getparametrized(parameter As Object, Optional sortexpression As String = Nothing) As Prescription Implements IDaoParametrized(Of Prescription).GetParametrized
        '    Dim doctorcode As String = parameter(0).ToString()
        '    Dim transactiondate As Date? = parameter(1)
        '    Dim datestring As String = CDate(transactiondate).ToString("yyyy/mm/dd", System.Globalization.CultureInfo.InvariantCulture)
        '    'Dim sql As String = "select empnameenglish from employeedetails where empid = '" + doctorcode.ToString() + "'"
        '    Dim data As New Prescription
        '    'data = _db.Read(sql, make).firstordefault()
        '    data.DoctorName = doctorcode
        '    data.TransDate = TransDate
        '    Dim params() As Object = {"@DoctorCode", doctorcode, "@TransDate", datestring}
        '    Dim sql As String = $"select " & FieldList & " PrescriptionDetail_View order by RowNbr"
        '    data.PrescriptionDetails = _db.Read(Of PrescriptionDetail)(sql, MakePrescriptionDetail, params).ToList()
        '    'params = {"@trans_key", data.doctorspatients(0).transkey}
        '    'sql = $"select rownbr, itemnameenglish, dosageenglish, duration from pmrmedicinedetails_view where trans_key = @trans_key order by rownbr"
        '    'data.prescriptiondetails = _db.read(sql, makeprescriptiondetail, params).tolist()
        '    Return data
        'End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Prescription) = Function(reader) New Prescription() With
            {
            .Age = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Age")),
            .AgeYmd = AATM.DataLayer.AdoNet.Extensions.AsString(reader("AgeYmd")),
            .DoctorCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DoctorCode")),
            .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DoctorName")),
            .FileNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("FileNo")),
            .Gender = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Gender")),
            .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
            .Series = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Series")),
            .TransDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransDate")),
            .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("TransKey"))
            }

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

        Private Shared ReadOnly MakePrescriptionDetail As Func(Of IDataReader, PrescriptionItem) = Function(reader) New PrescriptionItem() With
            {
            .ItemName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemName")),
            .Dosage = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Dosage")),
            .Duration = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Duration")),
            .ItemCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemCode")),
            .RowNbr = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("RowNbr")),
            .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("TransKey"))
            }
        'Public Function GetPrescriptionDetail(productIdNo As Int32) As List(Of PrescriptionDetail) Implements IPrescriptionDao.GetPrescriptionDetail
        '    Dim prescriptionDetailDao = New PrescriptionDetailDao
        '    Return prescriptionDetailDao.GetRecordsWithGroupIdNo(productIdNo)
        'End Function



        Public Function AddRecord(ByRef recordData As Prescription) As Integer Implements IDao(Of Prescription).AddRecord
            Throw New NotImplementedException()
        End Function

        Public Function UpdateRecord(ByRef recordData As Prescription) As Integer Implements IDao(Of Prescription).UpdateRecord
            Throw New NotImplementedException()
        End Function
    End Class

    Public Interface IPrescriptionDao
        Function GetPrescriptionDetail(productIdNo As Integer) As List(Of PrescriptionItem)

    End Interface

End Namespace