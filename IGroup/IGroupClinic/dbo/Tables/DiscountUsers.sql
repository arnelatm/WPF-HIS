CREATE TABLE [dbo].[DiscountUsers] (
    [Primary_Key]     INT           IDENTITY (1, 1) NOT NULL,
    [ItemID]          VARCHAR (15)  NULL,
    [ItemNameEnglish] VARCHAR (35)  NOT NULL,
    [ItemNameArabic]  NVARCHAR (35) NULL,
    [Value]           NVARCHAR (30) NULL,
    [Activate]        CHAR (1)      DEFAULT ('Y') NULL,
    [UserID]          VARCHAR (15)  DEFAULT ('Admin') NULL,
    [Create_Date]     DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]       VARCHAR (20)  DEFAULT (host_name()) NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_DiscountUsers]
    ON [dbo].[DiscountUsers]([ItemID] ASC);

