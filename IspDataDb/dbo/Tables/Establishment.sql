CREATE TABLE [dbo].[Establishment] (
    [IdNo]                 INT            IDENTITY (1, 1) NOT NULL,
    [EstablishmentName]    NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [EstablishmentNameAra] NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [PhoneNumber]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [EMailAddress]         VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [WebSite]              VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Address]              NVARCHAR (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Establishment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

