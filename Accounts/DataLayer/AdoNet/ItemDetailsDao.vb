Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ItemDetails
    ' ** DAO Pattern

    Public Class ItemDetailsDao
        Inherits CommonDao
        Implements IDao(Of ItemDetails), IDaoAutoCode

        Private _db As New Db("IGROUPCLINIC")

        Private FieldList As String = "BranchID," &
                                      "Category," &
                                      "Created_By_Branch," &
                                      "DosageForm," &
                                      "GenericName," &
                                      "Item_Code," &
                                      "Item_Status," &
                                      "ItemGroup," &
                                      "ItemNameEnglish," &
                                      "Pack1," &
                                      "Pack2," &
                                      "Pack3," &
                                      "PackageSize," &
                                      "PackageType," &
                                      "Primary_Key," &
                                      "RegistrationNo," &
                                      "RouteOfAdministration," &
                                      "SaleStrip," &
                                      "StrengthValue," &
                                      "UnitOfStrength," &
                                      "UnitOfVolume," &
                                      "UserId," &
                                      "Volume"

        'Public Sub New(ParamArray arguments As Object())
        '    Db.SetConnectionString("IGROUPCLINIC")
        'End Sub

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "Primary_Key"
        End Function

        Public Function GetRecordByIdNo(idNo) As ItemDetails Implements IDao(Of ItemDetails).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM ItemDetails_View" &
                    " WHERE Primary_Key = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef ItemDetails As ItemDetails) As Integer Implements IDao(Of ItemDetails).UpdateRecord
            Dim sql As String =
                    " UPDATE [ItemDetails] SET " &
                    " BranchID = @BranchID," &
                    " Category = @Category," &
                    " Created_By_Branch = @Created_By_Branch," &
                    " Item_Code = @ItemDetailsCode," &
                    " Item_Status = @Item_Status," &
                    " ItemGroup = @ItemGroup," &
                    " ItemNameEnglish = @ItemDetailsName," &
                    " Pack1 = @Pack1," &
                    " Pack2 = @Pack2," &
                    " Pack3 = @Pack3," &
                    " UserID = @UserId" &
                    " WHERE Primary_Key = @IdNo"
            Dim retval as Integer
            retval = _db.Update(sql, Take(ItemDetails))
            if retVAL > 0 AND Strings.Left(itemdetails.RegistrationNo,1) = "X" THEN
                Dim sql1 As String = "UPDATE [DrugList] SET " &
                    " [Dosage Form] = @DosageForm," &
                    " [Generic Name] = @GenericName," &
                    " [Package Size] = @PackageSize," &
                    " [Package Type] = @PackageType," &
                    " [Route Of Administration] = @RouteOfAdministration," &
                    " [Strength Value] = @StrengthValue," &
                    " [Trade Name] = @ItemDetailsName," &
                    " [Unit Of Strength] = @UnitOfStrength," &
                    " [Unit Of Volume] = @UnitOfVolume," &
                    " [Volume] = @Volume" &
                    " WHERE RegistrationNo = @RegistrationNo"
                _db.Update(sql1, TakeDrug(ItemDetails))
               Dim sql3 = "UPDATE ItemRegistration SET " &
                    " Strength = @Strength"
                _db.Update(sql3, TakeRegistration(ItemDetails))
            End If
            return retval
        End Function

        Public Function AddRecord(ByRef ItemDetails As ItemDetails) As Integer Implements IDao(Of ItemDetails).AddRecord
            Dim sql As String = " INSERT INTO [ItemDetails] " &
                    " (BranchID,Category,Created_By_Branch,Item_Code,Item_Status,ItemGroup,ItemNameEnglish,Pack1,Pack2,Pack3,SaleStrip,UserId)" &
                    " VALUES (@BranchID,@Category,@Created_By_Branch,@ItemDetailsCode,@Item_Status,@ItemGroup,@ItemDetailsName,@Pack1,@Pack2,@Pack3,@SaleStrip,@UserId)"
            Dim retval As Integer
            retval = _db.Insert(sql, Take(ItemDetails))
            If retval > 0 Then
                Dim sql2 = " INSERT INTO DrugList " &
                    " ([RegistrationNo],[Generic Name],[Trade Name],[Route Of Administration],[Strength Value],[Unit Of Strength],[Dosage Form],[Volume],[Unit of Volume],[Package Size],[Package Type])" &
                    " VALUES (@RegistrationNo,@GenericName,@ItemDetailsName,@RouteOfAdministration,@StrengthValue,@UnitOfStrength,@DosageForm,@Volume,@UnitOfVolume,@PackageSize,@PackageType)"
                _db.InsertNoId(sql2, TakeDrug(ItemDetails))
                Dim sql3 = " INSERT INTO ItemRegistration " &
                    " ([Item_Code],[RegistrationNo],[Strength])" &
                    " VALUES (@ItemDetailsCode,@RegistrationNo,@Strength)"
                _db.InsertNoId(sql3, TakeRegistration(ItemDetails))
            End If
            Return retval
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ItemDetails) =
                            Function(reader) _
            New ItemDetails() With {
            .BranchID = Extensions.AsString(reader("BranchID")),
            .Category = Extensions.AsString(reader("Category")),
            .Created_By_Branch = Extensions.AsString(reader("Created_By_Branch")),
            .DosageForm = Extensions.AsString(reader("DosageForm")),
            .GenericName = Extensions.AsString(reader("GenericName")),
            .IdNo = Extensions.AsId(Of Int32)(reader("Primary_Key")),
            .Item_status = Extensions.AsString(reader("Item_Status")),
            .ItemDetailsCode = Extensions.AsString(reader("Item_Code")),
            .ItemDetailsName = Extensions.AsString(reader("ItemNameEnglish")),
            .ItemGroup = Extensions.AsString(reader("ItemGroup")),
            .Pack1 = Extensions.AsInt(Of Int16)(reader("Pack1")),
            .Pack2 = Extensions.AsInt(Of Int16)(reader("Pack2")),
            .Pack3 = Extensions.AsInt(Of Int16)(reader("Pack3")),
            .PackageSize = Extensions.AsNullable(Of Decimal)(reader("PackageSize")),
            .PackageType = Extensions.AsString(reader("PackageType")),
            .RegistrationNo = Extensions.AsString(reader("RegistrationNo")),
            .RouteOfAdministration = Extensions.AsString(reader("RouteOfAdministration")),
            .StrengthValue = Extensions.AsString(reader("StrengthValue")),
            .UnitOfStrength = Extensions.AsString(reader("UnitOfStrength")),
            .UnitOfVolume = Extensions.AsString(reader("UnitOfVolume")),
            .UserId = Extensions.AsString(reader("UserId")),
            .Volume = Extensions.AsNullable(Of Decimal)(reader("Volume"))
            }

        Private Function Take(ItemDetails As ItemDetails) As Object()
            Return New Object() {
                            "BranchID", ItemDetails.BranchID,
                            "Category", ItemDetails.Category,
                            "Created_By_Branch", ItemDetails.Created_By_Branch,
                            "ItemDetailsCode", ItemDetails.ItemDetailsCode,
                            "ItemGroup", ItemDetails.ItemGroup,
                            "Item_Status", ItemDetails.Item_status,
                            "ItemDetailsName", ItemDetails.ItemDetailsName,
                            "IdNo", ItemDetails.IdNo,
                            "Pack1", ItemDetails.Pack1,
                            "Pack2", ItemDetails.Pack2,
                            "Pack3", ItemDetails.Pack3,
                            "SaleStrip", ItemDetails.SaleStrip,
                            "UserId", ItemDetails.UserId
                            }
        End Function

        Private Function TakeDrug(ItemDetails As ItemDetails) As Object()
            Return New Object() {
                                 "DosageForm", ItemDetails.DosageForm,
                                 "GenericName", ItemDetails.GenericName,
                                 "ItemDetailsName", ItemDetails.ItemDetailsName,
                                 "PackageSize", ItemDetails.PackageSize,
                                 "PackageType", ItemDetails.PackageType,
                                 "RegistrationNo", IIf(ItemDetails.RegistrationNo Is Nothing Or ItemDetails.RegistrationNo = "", "X-" + ItemDetails.ItemDetailsCode, ItemDetails.RegistrationNo),
                                 "RouteOfAdministration", ItemDetails.RouteOfAdministration,
                                 "StrengthValue", ItemDetails.StrengthValue,
                                 "UnitOfStrength", ItemDetails.UnitOfStrength,
                                 "UnitOfVolume", ItemDetails.UnitOfVolume,
                                 "Volume", ItemDetails.Volume
                                 }
        End Function

        Private Function TakeRegistration(ItemDetails As ItemDetails) As Object()
            Dim number As Decimal = 0
            Dim sStrength as String = Split(ItemDetails.StrengthValue, ",")(0)
            Decimal.TryParse(sStrength, number) 
            Return New Object() {"RegistrationNo", IIf(ItemDetails.RegistrationNo Is Nothing Or ItemDetails.RegistrationNo = "", "X-" + ItemDetails.ItemDetailsCode, ItemDetails.RegistrationNo),
                                 "ItemDetailsCode", ItemDetails.ItemDetailsCode,
                                 "Strength", number 
                                 }
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return GetNextCode("ItemDetails", idNo)
        End Function


        'Protected Function UpdateCode(db As Db, tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer) Implements ICommonDao.UpdateCode
        '    Dim sql1 As String
        '    Dim sql2 As String
        '    Dim retVal As Integer
        '    Dim series = tableName
        '    Dim maxlength As Int16
        '    Dim prefix As String

        '    If BaseDb.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
        '        'nothing to set no data.
        '    Else
        '        Dim x = BaseDb.Scalar("select prefix from series where seriesName = '" & series & "'")
        '        If IsDBNull(x) Then
        '            prefix = ""
        '        Else
        '            prefix = x
        '        End If
        '        maxlength = BaseDb.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
        '        Dim nValue = BaseDb.Scalar("Select Value from Series where SeriesName = '" & series & "'")
        '        If Not IsDBNull(nValue) Then
        '            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & tableName & "'"
        '            sql2 = "Update [" & tableName & "] set " & codeFieldName & " = (select value from series where seriesName = '" & tableName & "') where " & idFieldName & " = " & idNo
        '            retVal = BaseDb.ExecuteSqlTransaction("GenerateCode" + tableName, sql1, sql2)
        '        Else
        '            Dim code As String
        '            code = prefix & Right(StrDup(maxlength, "0") & idNo.ToString().Trim(), maxlength)
        '            sql1 = "Update " & tableName & " set " & codeFieldName & " = '" & code & "' where IdNo = " & idNo
        '            retVal = db.Scalar(sql1)
        '        End If
        '    End If
        '    Return retVal
        'End Function

        Public Overrides Function GetActualFieldName(fieldName As String)
            Dim actualFieldName As String
            If fieldName = "ItemDetailsCode" Then
                actualFieldName = "Item_Code"
            ElseIf fieldName = "ItemDetailsName" Then
                actualFieldName = "ItemNameEnglish"
            Else
                actualFieldName = fieldName
            End If
            Return actualFieldName
        End Function

    End Class

End Namespace