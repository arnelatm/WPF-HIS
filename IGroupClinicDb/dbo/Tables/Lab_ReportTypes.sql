CREATE TABLE [dbo].[Lab_ReportTypes] (
    [TypeID]          VARCHAR (15) NULL,
    [TypeDescription] VARCHAR (50) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_ReportTypes]
    ON [dbo].[Lab_ReportTypes]([TypeID] ASC);

