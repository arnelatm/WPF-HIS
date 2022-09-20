CREATE TABLE [dbo].[ServiceRegistration] (
    [Primary_Key] INT          NULL,
    [INS_CO_CODE] VARCHAR (15) NULL,
    [Reg_Nbr]     NUMERIC (10) NOT NULL,
    [Trans_Date]  VARCHAR (10) NOT NULL,
    [Doct_Code]   VARCHAR (15) NOT NULL,
    [icd_code]    VARCHAR (30) NULL,
    [icd_code1]   VARCHAR (30) NULL,
    [icd_code2]   VARCHAR (30) NULL
);

