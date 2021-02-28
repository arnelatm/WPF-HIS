CREATE TABLE [dbo].[DeductionTable] (
    [IdNo]          SMALLINT   IDENTITY (1, 1) NOT NULL,
    [DeductionIdNo] SMALLINT   NULL,
    [LowRange]      SMALLMONEY NULL,
    [HighRange]     SMALLMONEY NULL,
    [MinAmount]     SMALLMONEY NULL,
    [MaxAmount]     SMALLMONEY NULL,
    [EmployeeShare] SMALLMONEY NULL,
    [EmployerShare] SMALLMONEY NULL,
    [Sequence]      SMALLINT   NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_DeductionTable] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

