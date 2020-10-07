CREATE TYPE [dbo].[EmployeePhoneInsert] AS TABLE (
    [AreaCode]       VARCHAR (5)  NULL,
    [EmployeeIdNo]   INT          NOT NULL,
    [CountryTelIdNo] SMALLINT     NOT NULL,
    [PhoneNumber]    VARCHAR (14) NOT NULL,
    [PhoneTypeIdNo]  SMALLINT     NULL,
    [Sequence]       TINYINT      NOT NULL);





