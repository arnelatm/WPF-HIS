 DECLARE @BatchNo AS VARCHAR(20)
 DECLARE @Expiry AS Date
 DECLARE @GTin AS VARCHAR(10)
 DECLARE @SaleDate AS Date
 DECLARE @SerializationNo as Varchar(20)
Set @BatchNo = '1234'
Set @Expiry = '2022/11/01'
Set @GTin = '1234344'
Set @SaleDate = '2022/11/01'
Set @SerializationNo = '1234'
INSERT INTO [DrugSale]  (BatchNo,Expiry,GTin,SaleDate,SerializationNo)  VALUES (@BatchNo,@Expiry,@GTin,@SaleDate,@SerializationNo) 