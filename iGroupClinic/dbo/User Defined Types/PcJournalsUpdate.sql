CREATE TYPE [dbo].[PcJournalsUpdate] AS TABLE (
    [CdJournalIdNo] INT NOT NULL,
    [IdNo]          INT NOT NULL,
    [PcClosed]      BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

