CREATE TABLE [dbo].[Note] (
    [ID]          INT            NOT NULL,
    [Title]       NVARCHAR (50)  NULL,
    [Descryption] NVARCHAR (MAX) NULL,
    [Date]        DATE           NULL,
    [time]        TIME (7)       NULL,
    [UserName]    NVARCHAR (50)  NULL,
    [Location]    NVARCHAR (50)  NULL
);

