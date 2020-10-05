CREATE TYPE [dbo].[PayrollDeductAccountUpdate] AS TABLE (
    [AccountIdNo]   SMALLINT NOT NULL,
    [DeductionIdNo] SMALLINT NOT NULL,
    [IdNo]          INT      NOT NULL,
    [PayGroupIdNo]  SMALLINT NOT NULL,
    [Sequence]      SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));



