CREATE TABLE [dbo].[DosageLabelDetail] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [DosageLabelIdNo] INT            NULL,
    [ItemName]        VARCHAR (500)  NULL,
    [Dosage]          VARCHAR (500)  NULL,
    [DosageAra]       NVARCHAR (500) NULL,
    CONSTRAINT [PK_DosageLabelDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

