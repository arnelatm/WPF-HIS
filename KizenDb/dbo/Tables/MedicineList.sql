CREATE TABLE [dbo].[MedicineList] (
    [ID]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX)  NULL,
    [Price] DECIMAL (18, 2) NULL,
    [Code]  NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_MedicineList] PRIMARY KEY CLUSTERED ([ID] ASC)
);

