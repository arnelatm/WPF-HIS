CREATE TABLE [dbo].[Earning] (
    [IdNo]                 SMALLINT      IDENTITY (1, 1) NOT NULL,
    [EarningCode]    VARCHAR (10)  NULL,
    [EarningName]    VARCHAR (50)  NULL,
    [EarningNameAra] NVARCHAR (50) NULL,
    [DefaultFrequency]     CHAR (1)      NULL,
    [AccountIdNo]          INT           NULL,
    [EarningType]    CHAR (1)      NULL,
    [DateTimeStamp]        ROWVERSION    NULL,
    CONSTRAINT [PK_Earnings] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



