CREATE TYPE [dbo].[EmployeePhoneUpdate] AS TABLE (
    [AreaCode]       VARCHAR (5)  NULL,
    [EmployeeIdNo]   INT          NOT NULL,
    [IDNo]           INT          NOT NULL,
    [CountryTelIdNo] SMALLINT     NULL,
    [PhoneNumber]    VARCHAR (14) NOT NULL,
    [PhoneTypeIdNo]  SMALLINT     NOT NULL,
    [Sequence]       TINYINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));







