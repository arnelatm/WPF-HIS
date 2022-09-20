CREATE TABLE [dbo].[BranchItemMapped] (
    [Primary_Key]   INT          NULL,
    [Branch1ID]     VARCHAR (15) NOT NULL,
    [Item_Code]     VARCHAR (15) NOT NULL,
    [Branch2ID]     VARCHAR (15) NOT NULL,
    [Item_Code1]    VARCHAR (15) NOT NULL,
    [GroupPacking]  INT          DEFAULT ((1)) NULL,
    [GroupPacking1] INT          DEFAULT ((1)) NULL
);

