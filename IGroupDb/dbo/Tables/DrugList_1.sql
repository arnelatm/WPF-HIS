CREATE TABLE [dbo].[DrugList] (
    [IdNo]                    INT            IDENTITY (1, 1) NOT NULL,
    [RegistrationNo]          NVARCHAR (50)  NULL,
    [GTIN]                    VARCHAR (14)   NULL,
    [Generic name]            NVARCHAR (150) NULL,
    [Trade name]              NVARCHAR (150) NULL,
    [Strength value]          NVARCHAR (50)  NULL,
    [Unit of strength]        NVARCHAR (30)  NULL,
    [Dosage Form]             NVARCHAR (75)  NULL,
    [Route of Administration] NVARCHAR (150) NULL,
    [ATC Code 1]              NVARCHAR (50)  NULL,
    [ATC Code 2]              NVARCHAR (50)  NULL,
    [Volume]                  FLOAT (53)     NULL,
    [Unit of volume]          NVARCHAR (50)  NULL,
    [Package type]            NVARCHAR (50)  NULL,
    [Package size]            FLOAT (53)     NULL,
    [Legal status]            NVARCHAR (20)  NULL,
    [Product control]         NVARCHAR (30)  NULL,
    [Public price (SAR)]      FLOAT (53)     NULL,
    [Shelf-life (mon)]        FLOAT (53)     NULL,
    [Storage conditions]      NVARCHAR (50)  NULL,
    [Manufacturer name]       NVARCHAR (255) NULL,
    [Country of Manufacturer] NVARCHAR (50)  NULL,
    [Marketing Company]       NVARCHAR (150) NULL,
    [Nationality]             NVARCHAR (50)  NULL,
    [MAH (Agent name)]        NVARCHAR (150) NULL,
    [Authorization status]    NVARCHAR (15)  NULL,
    [Marketing status]        NVARCHAR (20)  NULL,
    [Remarks]                 NVARCHAR (255) NULL,
    [Color]                   NVARCHAR (50)  NULL,
    [Shape]                   NVARCHAR (50)  NULL,
    [DrugIdentification]      NVARCHAR (50)  NULL,
    CONSTRAINT [PK_DrugList] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [idx_DrugListGTIN_notnull]
    ON [dbo].[DrugList]([GTIN] ASC) WHERE ([GTIN] IS NOT NULL);

