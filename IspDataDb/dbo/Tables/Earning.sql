CREATE TABLE [dbo].[Earning] (
    [IdNo]           SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EarningCode]    VARCHAR (10)   NULL,
    [EarningName]    VARCHAR (50)   NULL,
    [EarningNameAra] NVARCHAR (50)  NULL,
    [Frequency]      CHAR (1)       NULL,
    [EarningType]    CHAR (1)       NULL,
    [AccountIdNo]    SMALLINT       NULL,
    [Notes]          NVARCHAR (100) NULL,
    [DateTimeStamp]  ROWVERSION     NULL,
    CONSTRAINT [PK_Earning] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);













