Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class LabReportStatusDao
        Inherits CommonDao
        Implements IDao(Of LabReportStatus)

        Private ReadOnly _db As New Db("Kizen")


        Private ReadOnly _fieldList As String = "Age," &
                                                "CollectedBy," &
                                                "CollectedDateTime," &
                                                "RequestedBy," &
                                                "Gender," &
                                                "RequestedDateTime," &
                                                "InvoiceNo," &
                                                "MRN," &
                                                "Nationality," &
                                                "PatientName," &
                                                "PatientNameMRN," &
                                                "ProcessedBy," &
                                                "ProcessedDateTime," &
                                                "SampleNo," &
                                                "ValidatedBy," &
                                                "ValidatedDateTime"
        Public Overrides Function GetDB()
            Return _db
        End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetRecordByIdNo(sampleNo) As LabReportStatus Implements IDao(Of LabReportStatus).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM LabReportStatus_View" &
                    " WHERE SampleNo = @SampleNo"
            Dim params() As Object = {"@SampleNo", sampleNo}
            Dim value As LabReportStatus = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef recordData As LabReportStatus) As Integer Implements IDao(Of LabReportStatus).UpdateRecord
            Return 0
        End Function

        Public Function AddRecord(ByRef recordData As LabReportStatus) As Integer Implements IDao(Of LabReportStatus).AddRecord
            Throw New NotImplementedException()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, LabReportStatus) = Function(reader) New LabReportStatus() With
        {
        .Age = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Age")),
        .CollectedBy = AATM.DataLayer.AdoNet.Extensions.AsString(reader("CollectedBy")),
        .CollectedDateTime = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of DateTime?)(reader("CollectedDateTime")),
        .Gender = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Gender")),
        .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
        .MRN = AATM.DataLayer.AdoNet.Extensions.AsString(reader("MRN")),
        .Nationality = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Nationality")),
        .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
        .PatientNameMRN = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientNameMRN")),
        .ProcessedBy = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProcessedBy")),
        .ProcessedDateTime = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of DateTime?)(reader("ProcessedDateTime")),
        .RequestedBy = AATM.DataLayer.AdoNet.Extensions.AsString(reader("RequestedBy")),
        .RequestedDateTime = AATM.DataLayer.AdoNet.Extensions.AsString(reader("RequestedDateTime")),
        .ValidatedBy = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ValidatedBy")),
        .ValidatedDateTime = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of DateTime?)(reader("ValidatedDateTime"))
        }

    End Class


End Namespace