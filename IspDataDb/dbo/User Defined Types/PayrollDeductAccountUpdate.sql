CREATE TYPE [dbo].[PayrollDeductAccountUpdate] AS TABLE (
    [AccountIdNo]   INT NOT NULL,
    [DeductionIdNo] INT NOT NULL,
    [IdNo]          INT NOT NULL,
    [PayGroupIdNo]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

