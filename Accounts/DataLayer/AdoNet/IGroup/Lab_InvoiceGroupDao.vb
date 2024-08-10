Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class Lab_InvoiceGroupDao
        Inherits CommonDao
        Implements IDaoUpdateDataTable

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Private ReadOnly FieldList As String = "InvoiceNo," &
                                      "PatientNameEnglish," &
                                      "InvoiceType," &
                                      "TransDate," &
                                      "AgeYMD," &
                                      "Age," &
                                      "Sex," &
                                      "SampleNo," &
                                      "Status," &
                                      "RegistrationNo," &
                                      "Remarks"

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
            .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
            .PatientNameEnglish = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientNameEnglish")),
            .InvoiceType = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceType")),
            .InvoiceDate = CType(AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransDate")), Date),
            .AgeYMD = AATM.DataLayer.AdoNet.Extensions.AsString(reader("AgeYMD")),
            .Age = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Age")),
            .Sex = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Sex")),
            .RegistrationNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("RegistrationNo")),
            .Remarks = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Remarks")),
            .SampleNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SampleNo")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Status"))
            }

        'Public Function UpdateTable2(Of T)(data As DataTable, groupKey As T) As Integer Implements IDaoUpdateDataTable.UpdateTable2
        '    Dim retVal As Integer
        '    Dim sql = ""
        '    Dim params() As Object
        '    Dim commands As New List(Of Object)
        '    For i = 0 To 19
        '        sql = "Update Lab_InvoiceDetails Set Result1 = @Result1, suffix1 = @Suffix1 where group_key = @group_Key and slno = @SlNo"
        '        params = {"@Result1", data.Rows(i).Item(3), "@Suffix1", data.Rows(i).Item(4), "@SlNo", data.Rows(i).Item(0), "@Group_Key", groupKey}
        '        commands.Add({sql, params})
        '    Next
        '    retVal = _db.ExecuteCommandsWithParameter("updateLabInvoices", commands)
        '    Return retVal
        'End Function

        'Public Function UpdateTable(Of TM, T)(data As List(Of TM), groupKey As T) As Integer Implements IDaoUpdateDataTable.UpdateTable
        '    Dim retVal As Integer
        '    Dim commands As New List(Of DaoCommand)
        '    For i = 0 To 19
        '        Dim command As New DaoCommand
        '        command.Add("Update Lab_InvoiceDetails Set Result1 = @Result1, suffix1 = @Suffix1 where group_key = @group_Key and slno = @SlNo",
        '                    {"@Result1", data.Rows(i).Item(3), "@Suffix1", data.Rows(i).Item(4), "@SlNo", data.Rows(i).Item(0), "@Group_Key", groupKey})
        '        commands.Add(command)
        '    Next
        '    retVal = _db.ExecuteNonQueryCommands("updateLabInvoices", commands)
        '    Return retVal
        'End Function

        Public Function UpdateTable(Of Int32)(data As Object(), groupKey As Int32) As Integer Implements IDaoUpdateDataTable.UpdateTable
            Dim retVal As Integer
            Dim commands As New List(Of DaoCommand)
            Dim labData As New List(Of Lab_InvoiceDetails)
            GlobalFUnctions.ManualMap(data, labData)
            For Each item As Lab_InvoiceDetails In labData
                Dim command As New DaoCommand
                command.Add("Update Lab_InvoiceDetails Set Result1 = @Result1, suffix1 = @Suffix1 where group_key = @group_Key and slno = @SlNo",
                            {"@Result1", item.Result1, "@Suffix1", item.Suffix1, "@SlNo", item.SlNo, "@Group_Key", groupKey})
                commands.Add(command)
            Next
            retVal = _db.ExecuteNonQueryCommands("updateLabInvoices", commands)
            Return retVal
        End Function

    End Class

    Public Class Lab_InvoiceDetailsDao
        Inherits AccountsDao
        Implements IDaoChildUpdateOnly(Of Lab_InvoiceDetails), IDaoUpdateTable(Of Lab_InvoiceDetails)

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

        Public Function UpdateTable(Of T)(data As List(Of Lab_InvoiceDetails), groupKey As T) As Integer Implements IDaoUpdateTable(Of Lab_InvoiceDetails).UpdateTable
            Dim retVal As Integer
            Dim commands As New List(Of DaoCommand)
            For Each item As Lab_InvoiceDetails In data
                Dim command As New DaoCommand
                command.Add("Update Lab_InvoiceDetails Set Result1 = @Result1, suffix1 = @Suffix1 where group_key = @group_Key and slno = @SlNo",
                            {"@Result1", item.Result1, "@Suffix1", item.Suffix1, "@SlNo", item.SlNo, "@Group_Key", groupKey})
                commands.Add(command)
            Next
            retVal = _db.ExecuteNonQueryCommands("updateLabInvoices", commands)
            Return retVal
        End Function

        'Public Function UpdateTable(Of Lab_InvoiceDetails)(data As Lab_InvoiceDetails, groupKey As Int32) As Integer Implements IDaoUpdateTable.UpdateTable
        '    Dim retVal As Integer
        '    Dim commands As New List(Of DaoCommand)
        '    Dim labData As New List(Of Lab_InvoiceDetails)
        '    GlobalFUnctions.ManualMap(data, labData)
        '    For Each item As Lab_InvoiceDetails In labData
        '        Dim command As New DaoCommand
        '        command.Add("Update Lab_InvoiceDetails Set Result1 = @Result1, suffix1 = @Suffix1 where group_key = @group_Key and slno = @SlNo",
        '                    {"@Result1", item.Result1, "@Suffix1", item.Suffix1, "@SlNo", item.SlNo, "@Group_Key", groupKey})
        '        commands.Add(command)
        '    Next
        '    retVal = _db.ExecuteNonQueryCommands("updateLabInvoices", commands)
        '    Return retVal
        'End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Lab_InvoiceDetails) =
                                    Function(reader) _
            New Lab_InvoiceDetails() With {
            .SlNo = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("SlNo")),
            .Diagnosis1 = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Diagnosis1")),
            .Result1 = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Result1")),
            .Suffix1 = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Suffix1"))
           }

    End Class

End Namespace