 
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[SetA1_WorksInsertInto]


@ID  int ,
@Name nvarchar(max) ,
@Group nvarchar(max) ,
@LowerPrice int ,
@UpperPrice int ,
@OriginalCost int ,
@OriginalOriginalCost int ,
@CustCost  int ,
@InsureanceDisc  int ,
@Unit nvarchar(50) ,
@LocalBarCode nvarchar(max) ,
@SourceBarCode nvarchar(max) ,
@Source_Copmany nvarchar(100) ,
@IsExpiredDate bit ,
@DefaultCountBuy int ,
@DefaultCountVendor int ,
@DefaultDicount int ,
@IsService bit ,
@ExpiredDate date ,
@CountInStore int ,
@LowerCountStore int ,
@UpperCountStore int ,
@Price int 
 
AS
BEGIN	
	 SET IDENTITY_INSERT a1_works on

	 INSERT INTO A1_Works
                         (Name, [Group], LowerPrice, UpperPrice, OriginalCost, OriginalOriginalCost, CustCost, InsureanceDisc, Unit, LocalBarCode, SourceBarCode, Source_Copmany, IsExpiredDate, DefaultCountBuy, 
                         DefaultCountVendor, DefaultDicount, IsService, CountInStore, LowerCountStore, UpperCountStore, Price, ID)
VALUES        (@Name,@Group,@LowerPrice,@UpperPrice,@OriginalCost,@OriginalOriginalCost,@CustCost,@InsureanceDisc,@Unit,@LocalBarCode,@SourceBarCode,@Source_Copmany,@IsExpiredDate,@DefaultCountBuy,@DefaultCountVendor,@DefaultDicount,@IsService,@CountInStore,@LowerCountStore,@UpperCountStore,@Price,@ID); 

SET IDENTITY_INSERT a1_works off
 END