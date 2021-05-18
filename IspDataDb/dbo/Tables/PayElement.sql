CREATE TABLE [dbo].[PayElement] (
    [IdNo]              SMALLINT        IDENTITY (1, 1) NOT NULL,
    [PayElementKind]    CHAR (1)        NULL,
    [PayElementCode]    VARCHAR (10)    NULL,
    [PayElementName]    VARCHAR (50)    NULL,
    [PayElementNameAra] NVARCHAR (50)   NULL,
    [Frequency]         CHAR (1)        NULL,
    [PayElementType]    CHAR (1)        NULL,
    [AccountIdNo]       SMALLINT        NULL,
    [BasePaymentIdNo]   SMALLINT        NULL,
    [CalculationType]   CHAR (1)        NULL,
    [DefaultQuantity]   DECIMAL (10, 4) NULL,
    [FactorValue]       DECIMAL (10, 4) NULL,
    [FactorType]        CHAR (1)        NULL,
    [IncludeInEos]      BIT             NULL,
    [Rate]              MONEY           NULL,
    [Taxable]           BIT             NULL,
    [Unit]              CHAR (1)        NULL,
    [QuantityType]      CHAR (1)        NULL,
    [UsePayGroups]      BIT             NULL,
    [ReportGroupIdNo]   TINYINT         NULL,
    [Notes]             NVARCHAR (100)  NULL,
    [DateTimeStamp]     ROWVERSION      NULL,
    [Summary]           BIT             NULL,
    [Active]            BIT             NULL,
    CONSTRAINT [PK_PayElement] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





