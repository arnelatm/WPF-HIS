CREATE TABLE [dbo].[iclock_terminalemployee] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [terminal_sn] NVARCHAR (50) NOT NULL,
    [emp_code]    NVARCHAR (20) NOT NULL,
    [privilege]   SMALLINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

