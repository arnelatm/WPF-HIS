CREATE TABLE [dbo].[Company_Profile] (
    [Br_Code]           VARCHAR (15)  NOT NULL,
    [Company_Name]      VARCHAR (200) NOT NULL,
    [Company_Address]   VARCHAR (500) NOT NULL,
    [Company_Logo]      VARBINARY (1) NULL,
    [Phone1]            VARCHAR (12)  NULL,
    [Phone2]            VARCHAR (12)  NULL,
    [Company_ShortName] VARCHAR (50)  NULL,
    [Company_Email]     VARCHAR (250) NULL,
    [Company_Fax]       VARCHAR (12)  NULL,
    [Company_Web]       VARCHAR (250) NULL,
    [Company_slogan]    VARCHAR (100) NULL
);

