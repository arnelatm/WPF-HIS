IF COL_LENGTH('dbo.Report', 'PromptParameterNames') IS NULL
BEGIN
    ALTER TABLE dbo.Report
        ADD PromptParameterNames varchar(500) NULL;
END;
GO

IF COL_LENGTH('dbo.Report', 'RepeatPromptAfterClose') IS NULL
BEGIN
    ALTER TABLE dbo.Report
        ADD RepeatPromptAfterClose bit NULL;
END;
GO
