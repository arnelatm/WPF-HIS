CREATE TABLE [dbo].[PensionSchemes] (
    [IdNo]           SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PensionCode]    VARCHAR (10)   NULL,
    [PensionName]    VARCHAR (50)   NULL,
    [PensionNameAra] NVARCHAR (50)  NULL,
    [AccountIdNo]    SMALLINT       NULL,
    [Notes]          NVARCHAR (100) NULL,
    [DateTimeStamp]  ROWVERSION     NULL,
    CONSTRAINT [PK_Pension] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

