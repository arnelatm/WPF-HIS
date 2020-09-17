CREATE TABLE [dbo].[DistributionSchemeItem] (
    [IdNo]                   INT             IDENTITY (1, 1) NOT NULL,
    [DistributionSchemeIdNo] INT             NULL,
    [Sequence]               SMALLINT        NULL,
    [RevCostCenterIdNo]      SMALLINT        NULL,
    [Percentage]             DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_DistributionSchemeItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



