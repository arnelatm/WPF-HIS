CREATE TABLE [dbo].[DrugAccept] (
    [IdNo]            INT          IDENTITY (1, 1) NOT NULL,
    [AcceptDate]      DATE         NOT NULL,
    [GTIN]            VARCHAR (14) NOT NULL,
    [Expiry]          DATE         NOT NULL,
    [BatchNo]         VARCHAR (20) NOT NULL,
    [SerializationNo] VARCHAR (20) NOT NULL,
    [DateTimeStamp]   ROWVERSION   NULL,
    CONSTRAINT [PK_DrugAccept] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

