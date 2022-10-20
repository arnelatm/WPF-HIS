CREATE TABLE [dbo].[ICD10_Master] (
    [Trans_key]       NUMERIC (10)   NOT NULL,
    [icd_code]        VARCHAR (15)   NOT NULL,
    [block]           VARCHAR (15)   NULL,
    [category]        VARCHAR (15)   NULL,
    [icd_description] NVARCHAR (500) NULL,
    [userid]          VARCHAR (15)   NULL,
    [create_date]     DATETIME       NULL,
    [machineid]       VARCHAR (20)   NULL
);

