CREATE TYPE [dbo].[EmployeePhoneInsert] AS TABLE (
    [AreaCode]       VARCHAR (5)  NULL,
    [CountryTelIdNo] SMALLINT     NOT NULL,
    [EmployeeIdNo]   INT          NOT NULL,
    [PhoneNumber]    VARCHAR (14) NOT NULL,
    [PhoneTypeIdNo]  SMALLINT     NULL,
    [Sequence]       TINYINT      NOT NULL);

