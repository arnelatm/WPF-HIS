CREATE TABLE [dbo].[PensionScheme] (
    [IdNo]                 SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PensionSchemeCode]    VARCHAR (10)   NOT NULL,
    [PensionSchemeName]    VARCHAR (50)   NOT NULL,
    [PensionSchemeNameAra] NVARCHAR (50)  NOT NULL,
    [PensionProviderIdNo]  SMALLINT       NOT NULL,
    [AccountIdNo]          SMALLINT       NOT NULL,
    [Notes]                NVARCHAR (100) NULL,
    [DateTimeStamp]        ROWVERSION     NULL,
    CONSTRAINT [PK_Pension] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



