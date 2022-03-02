Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ItemDetails
    ' ** DAO Pattern

    Public Class ItemDetailsDao
        Inherits CommonDao
        Implements iDao(Of ItemDetails)

        Private _db As New Db("IGROUPCLINIC")

        Private FieldList As String = "BranchID," &
                                      "Category," &
                                      "Created_By_Branch," &
                                      "Item_Code," &
                                      "Item_Status," &
                                      "ItemGroup," &
                                      "ItemNameEnglish," &
                                      "Pack1," &
                                      "Pack2," &
                                      "Pack3," &
                                      "Primary_Key," &
                                      "SaleStrip," &
                                      "UserId"

        'Public Sub New(ParamArray arguments As Object())
        '    Db.SetConnectionString("IGROUPCLINIC")
        'End Sub

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "Primary_Key"
        End Function

        Public Function GetRecordByIdNo(idNo) As ItemDetails Implements iDao(Of ItemDetails).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM ItemDetails" &
                    " WHERE Primary_Key = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef ItemDetails As ItemDetails) As Integer Implements iDao(Of ItemDetails).UpdateRecord
            Dim sql As String =
                    " UPDATE [ItemDetails] SET " &
                    " BranchID = @BranchID," &
                    " Category = @Category," &
                    " Created_By_Branch = @Created_By_Branch," &
                    " Item_Code = @ItemDetailsCode," &
                    " Item_Status = @ItemStatus," &
                    " ItemGroup = @ItemGroup," &
                    " ItemNameEnglish = @ItemDetailsName," &
                    " Pack1 = @Pack1," &
                    " Pack2 = @Pack2," &
                    " Pack3 = @Pack3," &
                    " UserID = @UserId" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(ItemDetails))
        End Function

        Public Function AddRecord(ByRef ItemDetails As ItemDetails) As Integer Implements iDao(Of ItemDetails).AddRecord
            Dim sql As String = " INSERT INTO [ItemDetails] " &
                    " (BranchID,Category,Created_By_Branch,Item_Code,Item_Status,ItemGroup,ItemNameEnglish,Pack1,Pack2,Pack3,SaleStrip,UserId)" &
                    " VALUES (@BranchID,@Category,@Created_By_Branch,@ItemDetailsCode,@Item_Status,@ItemGroup,@ItemDetailsName,@Pack1,@Pack2,@Pack3,@SaleStrip,@UserId)"
            Return _db.Insert(sql, Take(ItemDetails))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ItemDetails) =
                            Function(reader) _
            New ItemDetails() With {
            .BranchID = Extensions.AsString(reader("BranchID")),
            .Category = Extensions.AsString(reader("Category")),
            .Created_By_Branch = Extensions.AsString(reader("Created_By_Branch")),
            .ItemDetailsCode = Extensions.AsString(reader("Item_Code")),
            .Item_Status = Extensions.AsString(reader("Item_Status")),
            .ItemGroup = Extensions.AsString(reader("ItemGroup")),
            .ItemDetailsName = Extensions.AsString(reader("ItemNameEnglish")),
            .IdNo = Extensions.AsId(Of Int32)(reader("Primary_Key")),
            .Pack1 = Extensions.AsInt(Of Int16)(reader("Pack1")),
            .Pack2 = Extensions.AsInt(Of Int16)(reader("Pack2")),
            .Pack3 = Extensions.AsInt(Of Int16)(reader("Pack3")),
            .SaleStrip = Extensions.AsString(reader("SaleStrip")),
            .UserId = Extensions.AsString(reader("UserId"))
            }

        Private Function Take(ItemDetails As ItemDetails) As Object()
            Return New Object() {
                            "BranchID", ItemDetails.BranchID,
                            "Category", ItemDetails.Category,
                            "Created_By_Branch", ItemDetails.Created_By_Branch,
                            "ItemDetailsCode", ItemDetails.ItemDetailsCode,
                            "ItemGroup", ItemDetails.ItemGroup,
                            "Item_Status", ItemDetails.Item_Status,
                            "ItemDetailsName", ItemDetails.ItemDetailsName,
                            "IdNo", ItemDetails.IdNo,
                            "Pack1", ItemDetails.Pack1,
                            "Pack2", ItemDetails.Pack2,
                            "Pack3", ItemDetails.Pack3,
                            "SaleStrip", ItemDetails.SaleStrip,
                            "UserId", ItemDetails.UserId
                            }
        End Function

        
    End Class

End Namespace