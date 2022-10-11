CREATE TABLE [dbo].[MedicineDosageMaster] (
    [ItemID]          VARCHAR (15)   NULL,
    [ItemNameEnglish] NVARCHAR (100) NULL,
    [ItemNameArabic]  NVARCHAR (40)  NULL,
    [Value]           NVARCHAR (30)  NULL,
    [Activate]        CHAR (1)       NULL,
    [UserID]          VARCHAR (15)   DEFAULT ('Admin') NULL,
    [Create_Date]     DATETIME       DEFAULT (getdate()) NULL,
    [MachineID]       VARCHAR (20)   DEFAULT (host_name()) NULL,
    [primary_key]     INT            IDENTITY (1, 1) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IDX_MedicineDosageMaster]
    ON [dbo].[MedicineDosageMaster]([ItemID] ASC);

