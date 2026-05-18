CREATE TABLE [dbo].[base_sysparamdept] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [rule_name] NVARCHAR (40) NOT NULL,
    [dept_id]   INT           NOT NULL,
    [operator]  NVARCHAR (20) NULL,
    [op_time]   DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([rule_name] ASC)
);

