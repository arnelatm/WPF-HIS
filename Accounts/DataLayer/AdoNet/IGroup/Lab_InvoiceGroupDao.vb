Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class Lab_InvoiceGroupDao
        Inherits CommonDao
  
        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Private ReadOnly FieldList As String = "InvoiceNo," &
                                      "PatientNameEnglish," &
                                      "InvoiceType," &
                                      "TransDate," &
                                      "Age," &
                                      "AgeYMD," &
                                      "Sex," &
                                      "SampleNo," &
                                      "Status," &
                                      "RegistrationNo"

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "Trans_Key"
        End Function

        Public Function GetRecordByIdNo(idNo) As Lab_InvoiceGroup
            Dim sql As String = "SELECT " & FieldList & " from Lab_InvoiceGroup where InvestigationId = 'CBCNK' and Trans_Key = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data As Lab_InvoiceGroup = _db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim ldDao = New Lab_InvoiceDetailsDao()
                data.LabInvoiceDetails = ldDao.GetRecordsWithGroupIdNo(idNo, "SlNo")
            End If
            Return data
        End Function


        Private Shared ReadOnly Make As Func(Of IDataReader, Lab_InvoiceGroup) =
                            Function(reader) _
            New Lab_InvoiceGroup() With {
            .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
            .PatientNameEnglish = Extensions.AsString(reader("PatientNameEnglish")),
            .InvoiceType = Extensions.AsString(reader("InvoiceType")),
            .InvoiceDate = CType(Extensions.AsString(reader("TransDate")), Date),
            .Age = Extensions.AsDecimal(reader("Age")),
            .AgeYMD = Extensions.AsString(reader("AgeYMD")),
            .Sex = Extensions.AsString(reader("Sex")),
            .RegistrationNo = Extensions.AsString(reader("RegistrationNo")),
            .SampleNo = Extensions.AsString(reader("SampleNo")),
            .Status = Extensions.AsInt(Of Int32)(reader("Status"))
            }

    End Class


    Public Class Lab_InvoiceDetailsDao
        Inherits AccountsDao
        Implements IDaoChildUpdateOnly(Of Lab_InvoiceDetails)

        Private _db As New Db("IGROUPCLINIC")

        Private fieldList As String = "Diagnosis1," &
                                      "Result1," &
                                      "SlNo," &
                                      "Suffix1"


        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "Group_key"
        End Function

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of Lab_InvoiceDetails) Implements IDaoChildUpdateOnly(Of Lab_InvoiceDetails).GetRecordsWithGroupIdNo
            Dim primaryKey As String = GetPrimaryFieldName()
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String = " SELECT " & fieldList &
                    " FROM [Lab_InvoiceDetails]" &
                    " WHERE " & primaryKey & " = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChildUpdateOnly(Of Lab_InvoiceDetails).DelUpdateTvp
            Return _db.DelUpdateTvp("UpdateLabInvoiceDetailsTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Lab_InvoiceDetails) =
                                    Function(reader) _
            New Lab_InvoiceDetails() With {
            .SlNo = Extensions.AsDecimal(reader("SlNo")),
            .Diagnosis1 = Extensions.AsString(reader("Diagnosis1")),
            .Result1 = Extensions.AsString(reader("Result1")),
            .Suffix1 = Extensions.AsString(reader("Suffix1"))
           }

    End Class

End Namespace