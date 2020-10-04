CREATE TYPE [dbo].[EmployeePhoneInsert] AS TABLE (
    [AreaCode]          VARCHAR (5)  NOT NULL,
    [EmployeeIdNo]      INT          NOT NULL,
    [InternationalCode] VARCHAR (3)  NOT NULL,
    [PhoneIdNo]         SMALLINT     NOT NULL,
    [PhoneNumber]       VARCHAR (14) NOT NULL,
    [PhoneTypeIdNo]     SMALLINT     NOT NULL,
    [Sequence]          TINYINT      NOT NULL);

