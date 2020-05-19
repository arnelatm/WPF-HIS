CREATE TYPE [dbo].[DistributionSchemeItemMerge] AS TABLE (
    [IDNo]                   INT            NOT NULL,
    [Sequence]               INT            NULL,
    [DistributionSchemeIdNo] INT            NOT NULL,
    [ProfitCenterIdNo]       INT            NOT NULL,
    [Percentage]             DECIMAL (6, 2) NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

