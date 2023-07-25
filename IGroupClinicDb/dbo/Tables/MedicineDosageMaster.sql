CREATE TABLE [dbo].[MedicineDosageMaster] (
    [ItemID]          VARCHAR (15)   NULL,
    [ItemNameEnglish] NVARCHAR (100) NULL,
    [ItemNameArabic]  NVARCHAR (40)  NULL,
    [Value]           NVARCHAR (30)  NULL,
    [Activate]        CHAR (1)       NULL,
    [UserID]          VARCHAR (15)   CONSTRAINT [DF__MedicineD__UserI__4924D839] DEFAULT ('Admin') NULL,
    [Create_Date]     DATETIME       CONSTRAINT [DF__MedicineD__Creat__4A18FC72] DEFAULT (getdate()) NULL,
    [MachineID]       VARCHAR (20)   CONSTRAINT [DF__MedicineD__Machi__4B0D20AB] DEFAULT (host_name()) NULL,
    [primary_key]     INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_MedicineDosageMaster] PRIMARY KEY CLUSTERED ([primary_key] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IDX_MedicineDosageMaster]
    ON [dbo].[MedicineDosageMaster]([ItemID] ASC);

