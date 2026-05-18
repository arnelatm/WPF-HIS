CREATE TABLE [dbo].[att_calculatelastdate] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [last_date] DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [att_calculatelastdate_last_date_1441abdc]
    ON [dbo].[att_calculatelastdate]([last_date] ASC);

