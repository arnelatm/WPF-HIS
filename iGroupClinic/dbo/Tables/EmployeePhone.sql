CREATE TABLE [dbo].[EmployeePhone] (
    [IdNo]           INT          IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]   INT          NOT NULL,
    [PhoneTypeIdNo]  SMALLINT     NULL,
    [CountryTelIdNo] SMALLINT     NULL,
    [AreaCode]       VARCHAR (5)  NULL,
    [PhoneNumber]    VARCHAR (14) NOT NULL,
    [Sequence]       TINYINT      NOT NULL,
    CONSTRAINT [PK_EmployeePhone] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

