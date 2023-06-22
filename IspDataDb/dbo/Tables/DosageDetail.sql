CREATE TABLE [dbo].[DosageDetail] (
    [IdNo]            INT          IDENTITY (1, 1) NOT NULL,
    [DosageLabelIdNo] INT          NULL,
    [MedicineName]    VARCHAR (50) NULL,
    [GenericName]     VARCHAR (50) NULL,
    [Dosage]          VARCHAR (50) NULL,
    [Duration]        VARCHAR (50) NULL,
    [Route]           VARCHAR (50) NULL,
    [Direction]       VARCHAR (50) NULL,
    CONSTRAINT [PK_DosageDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



