CREATE TYPE [dbo].[DistributionSchemeItemUpdate] AS TABLE (
    [IDNo]                   INT            NOT NULL,
    [DistributionSchemeIdNo] INT            NOT NULL,
    [Sequence]               INT            NOT NULL,
    [RevCostCenterIdNo]      INT            NOT NULL,
    [Percentage]             DECIMAL (6, 2) NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));





