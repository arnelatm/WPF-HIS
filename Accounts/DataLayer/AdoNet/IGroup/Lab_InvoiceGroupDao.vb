Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class Lab_InvoiceGroupDao
        Inherits CommonDao
        'Implements IDao(Of CbcRetrieval)

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

        'Public Sub New(ParamArray arguments As Object())
        '    Db.SetConnectionString("IGROUPCLINIC")
        'End Sub

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



        'Public Function UpdateRecord(ByRef CbcRetrieval As CbcRetrieval) As Integer Implements IDao(Of CbcRetrieval).UpdateRecord
        '    Dim sql As String =
        '            " UPDATE [CbcRetrieval] SET " &
        '            " BranchID = @BranchID," &
        '            " Category = @Category," &
        '            " Created_By_Branch = @Created_By_Branch," &
        '            " Item_Code = @CbcRetrievalCode," &
        '            " Item_Status = @Item_Status," &
        '            " ItemGroup = @ItemGroup," &
        '            " ItemNameEnglish = @CbcRetrievalName," &
        '            " Pack1 = @Pack1," &
        '            " Pack2 = @Pack2," &
        '            " Pack3 = @Pack3," &
        '            " UserID = @UserId" &
        '            " WHERE Primary_Key = @IdNo"
        '    Dim retval as Integer
        '    retval = _db.Update(sql, Take(CbcRetrieval))
        '    if retVAL > 0 AND Strings.Left(CbcRetrieval.RegistrationNo,1) = "X" THEN
        '        Dim sql1 As String = "UPDATE [DrugList] SET " &
        '            " [Dosage Form] = @DosageForm," &
        '            " [Generic Name] = @GenericName," &
        '            " [Package Size] = @PackageSize," &
        '            " [Package Type] = @PackageType," &
        '            " [Route Of Administration] = @RouteOfAdministration," &
        '            " [Strength Value] = @StrengthValue," &
        '            " [Trade Name] = @CbcRetrievalName," &
        '            " [Unit Of Strength] = @UnitOfStrength," &
        '            " [Unit Of Volume] = @UnitOfVolume," &
        '            " [Volume] = @Volume" &
        '            " WHERE RegistrationNo = @RegistrationNo"
        '        _db.Update(sql1, TakeDrug(CbcRetrieval))
        '       Dim sql3 = "UPDATE ItemRegistration SET " &
        '            " Strength = @Strength"
        '        _db.Update(sql3, TakeRegistration(CbcRetrieval))
        '    End If
        '    return retval
        'End Function

        'Public Function AddRecord(ByRef CbcRetrieval As CbcRetrieval) As Integer Implements IDao(Of CbcRetrieval).AddRecord
        '    'Dim sql As String = " INSERT INTO [CbcRetrieval] " &
        '    '        " (BranchID,Category,Created_By_Branch,Item_Code,Item_Status,ItemGroup,ItemNameEnglish,Pack1,Pack2,Pack3,SaleStrip,UserId)" &
        '    '        " VALUES (@BranchID,@Category,@Created_By_Branch,@CbcRetrievalCode,@Item_Status,@ItemGroup,@CbcRetrievalName,@Pack1,@Pack2,@Pack3,@SaleStrip,@UserId)"
        '    'Dim retval As Integer
        '    'retval = _db.Insert(sql, Take(CbcRetrieval))
        '    'If retval > 0 Then
        '    '    Dim sql2 = " INSERT INTO DrugList " &
        '    '        " ([RegistrationNo],[Generic Name],[Trade Name],[Route Of Administration],[Strength Value],[Unit Of Strength],[Dosage Form],[Volume],[Unit of Volume],[Package Size],[Package Type])" &
        '    '        " VALUES (@RegistrationNo,@GenericName,@TradeName,@RouteOfAdministration,@StrengthValue,@UnitOfStrength,@DosageForm,@Volume,@UnitOfVolume,@PackageSize,@PackageType)"
        '    '    _db.InsertNoId(sql2, TakeDrug(CbcRetrieval))
        '    '    Dim sql3 = " INSERT INTO ItemRegistration " &
        '    '        " ([Item_Code],[RegistrationNo],[Strength])" &
        '    '        " VALUES (@CbcRetrievalCode,@RegistrationNo,@Strength)"
        '    '    _db.InsertNoId(sql3, TakeRegistration(CbcRetrieval))
        '    'End If
        '    'Return retval
        '    Return Nothing
        'End Function

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

        'Private Function Take(CbcRetrieval As CbcRetrieval) As Object()
        '    Return New Object() {
        '                    "BranchID", CbcRetrieval.BranchID,
        '                    "Category", CbcRetrieval.Category,
        '                    "Created_By_Branch", CbcRetrieval.Created_By_Branch,
        '                    "CbcRetrievalCode", CbcRetrieval.CbcRetrievalCode,
        '                    "ItemGroup", CbcRetrieval.ItemGroup,
        '                    "Item_Status", CbcRetrieval.Item_status,
        '                    "CbcRetrievalName", CbcRetrieval.CbcRetrievalName,
        '                    "IdNo", CbcRetrieval.IdNo,
        '                    "Pack1", CbcRetrieval.Pack1,
        '                    "Pack2", CbcRetrieval.Pack2,
        '                    "Pack3", CbcRetrieval.Pack3,
        '                    "SaleStrip", CbcRetrieval.SaleStrip,
        '                    "UserId", CbcRetrieval.UserId
        '                    }
        'End Function


        'Public Overrides Function GetActualFieldName(fieldName As String)
        '    Dim actualFieldName As String
        '    If fieldName = "CbcRetrievalCode" Then
        '        actualFieldName = "Item_Code"
        '    ElseIf fieldName = "CbcRetrievalName" Then
        '        actualFieldName = "ItemNameEnglish"
        '    Else
        '        actualFieldName = fieldName
        '    End If
        '    Return actualFieldName
        'End Function

        'Public Function AddRecord(ByRef recordData As CbcRetrieval) As Integer Implements IDao(Of CbcRetrieval).AddRecord
        '    Throw New NotImplementedException()
        'End Function

        'Public Function UpdateRecord(ByRef recordData As CbcRetrieval) As Integer Implements IDao(Of CbcRetrieval).UpdateRecord
        '    Throw New NotImplementedException()
        'End Function

    End Class

    'Public Class Lab_InvoiceGroupDao
    '    Inherits AccountsDao
    '    Implements IDaoReadOnly(Of Lab_InvoiceGroup)

    '    Private ReadOnly dB As New Db("IGROUPCLINIC")
    '    Private PrimaryKey As String = "Trans_Key"

    '    Private ReadOnly fieldList As String = GetPrimaryFieldName() & "," &
    '                                  "InvoiceNo," &
    '                                  "InvoiceType," &
    '                                  "InvoiceDate," &
    '                                  "PatientNameEnglish," &
    '                                  "Age," &
    '                                  "AgeYMD," &
    '                                  "Sex"

    '    Public Overrides Function GetPrimaryFieldName()
    '        Return "Trans_Key"
    '    End Function

    '    Public Function GetRecordByIdNo(idNo) As Lab_InvoiceGroup Implements IDaoReadOnly(Of Lab_InvoiceGroup).GetRecordByIdNo
    '        Dim primaryKey = GetPrimaryFieldName()
    '        Dim sql As String = "SELECT " & fieldList &
    '                " FROM [Lab_InvoiceGroup]" &
    '                " WHERE " & primaryKey & " = @IdNo"
    '        Dim params() As Object = {"@IdNo", idNo}
    '        Dim data As Lab_InvoiceGroup = dB.Read(sql, Make, params).FirstOrDefault()
    '        If data IsNot Nothing Then
    '            Dim labInvoiceDetailsDao = New Lab_InvoiceDetailsDao
    '            Dim ld As List(Of Lab_InvoiceDetails) = labInvoiceDetailsDao.GetRecordsWithGroupIdNo(data.IdNo, "slNo")
    '            data.LabInvoiceDetails = ld
    '        End If
    '        Return data
    '    End Function

    '    Private ReadOnly Make As Func(Of IDataReader, Lab_InvoiceGroup) =
    '                                Function(reader) _
    '        New Lab_InvoiceGroup() With {
    '        .InvoiceNo = Extensions.AsString(reader("InvoiceNo")),
    '        .InvoiceType = Extensions.AsString(reader("InvoiceType")),
    '        .IdNO = Extensions.AsId(Of Decimal)(reader(primaryKey)),
    '        .PatientNameEnglish = Extensions.AsString(reader("PatientNameEnglish")),
    '        .Age = Extensions.AsString(reader("Age")),
    '        .AgeYmd = Extensions.AsString(reader("AgeYmd")),
    '        .Sex = Extensions.AsString(reader("Sex"))
    '       }

    '    'Public Overrides Function GetActualFieldName(fieldName As String)
    '    '    Dim actualFieldName As String
    '    '    If fieldName = "ItemDetailsCode" Then
    '    '        actualFieldName = "Item_Code"
    '    '    ElseIf fieldName = "ItemDetailsName" Then
    '    '        actualFieldName = "ItemNameEnglish"
    '    '    Else
    '    '        actualFieldName = fieldName
    '    '    End If
    '    '    Return actualFieldName
    '    'End Function

    'End Class


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