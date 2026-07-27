CREATE TABLE [dbo].[Employee_Import_Staging] (
    [Id]             INT            NULL,
    [NameAr]         NVARCHAR (75)  NULL,
    [NameEn]         VARCHAR (75)   NULL,
    [IdentityNumber] VARCHAR (20)   NULL,
    [IdenetyType]    NVARCHAR (20)  NULL,
    [Mobile1]        VARCHAR (20)   NULL,
    [Nationality]    NVARCHAR (100) NULL,
    [MateralStatu]   NVARCHAR (50)  NULL,
    [Mail1]          VARCHAR (100)  NULL,
    [BirthDay]       DATE           NULL,
    [Religion]       NVARCHAR (20)  NULL,
    [StartContract]  DATE           NULL,
    [Gender]         VARCHAR (10)   NULL
);

