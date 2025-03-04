CREATE TABLE [dbo].[DL_LabOrderWorks] (
    [ID]         INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]    INT             NULL,
    [Price]      DECIMAL (18, 2) NULL,
    [Count]      DECIMAL (18, 2) NULL,
    [Total]      DECIMAL (18, 2) NULL,
    [Disc]       DECIMAL (18, 2) NULL,
    [DiscNet]    DECIMAL (18, 2) NULL,
    [Net]        DECIMAL (18, 2) NULL,
    [Note]       NVARCHAR (MAX)  NULL,
    [UserName]   NVARCHAR (50)   NULL,
    [DateTime]   DATETIME        NULL,
    [WorkID]     NVARCHAR (MAX)  NULL,
    [Name]       NVARCHAR (MAX)  NULL,
    [TeethColor] NVARCHAR (MAX)  NULL,
    [TeethCodes] NVARCHAR (MAX)  NULL,
    [VATPer]     DECIMAL (18, 2) NULL,
    [VatValue]   DECIMAL (18, 2) NULL,
    [TotalNoVAT] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_DL_LabOrderWorks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

