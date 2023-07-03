CREATE TABLE [dbo].[DosageLabelDetail] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [DosageLabelIdNo] INT            NULL,
    [ItemName]        VARCHAR (100)  NULL,
    [Dosage]          VARCHAR (100)  NULL,
    [DosageAra]       NVARCHAR (100) NULL,
    CONSTRAINT [PK_DosageLabelDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

