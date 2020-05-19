CREATE TYPE [dbo].[DistributionSchemeItemInsert] AS TABLE (
    [DistributionSchemeIdNo] INT            NOT NULL,
    [Sequence]               INT            NOT NULL,
    [ProfitCenteridNo]       INT            NOT NULL,
    [Percentage]             DECIMAL (6, 2) NULL);

