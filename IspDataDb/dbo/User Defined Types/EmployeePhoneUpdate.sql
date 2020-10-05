CREATE TYPE [dbo].[EmployeePhoneUpdate] AS TABLE (
    [AreaCode]          VARCHAR (5)  NOT NULL,
    [EmployeeIdNo]      INT          NOT NULL,
    [IDNo]              INT          NOT NULL,
    [InternationalCode] VARCHAR (3)  NOT NULL,
    [PhoneIdNo]         SMALLINT     NOT NULL,
    [CountryTelCode]    VARCHAR (14) NOT NULL,
    [PhoneTypeIdNo]     SMALLINT     NOT NULL,
    [PhoneNumber]       VARCHAR (14) NOT NULL,
    [Sequence]          TINYINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));





