CREATE TABLE [dbo].[SoftwareBugs] (
    [UserID]       VARCHAR (15) NOT NULL,
    [MachineID]    VARCHAR (20) DEFAULT (host_name()) NULL,
    [SystemDate]   DATETIME     DEFAULT (getdate()) NULL,
    [em_module_no] VARCHAR (25) NULL,
    [ErrorNBR]     NUMERIC (5)  NULL,
    [ErrorMessage] NTEXT        NULL
);

