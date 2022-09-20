CREATE TABLE [dbo].[UserLogEvent] (
    [Primary_Key] INT          IDENTITY (1, 1) NOT NULL,
    [LogDate]     VARCHAR (10) NULL,
    [BranchID]    VARCHAR (15) NOT NULL,
    [UserID]      VARCHAR (5)  NOT NULL,
    [ModuleName]  VARCHAR (20) NULL,
    [MachineID]   VARCHAR (30) DEFAULT (host_name()) NULL,
    [LoginTime]   DATETIME     DEFAULT (getdate()) NULL,
    [LogoutTime]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_UserLogEvent]
    ON [dbo].[UserLogEvent]([Primary_Key] ASC, [BranchID] ASC, [UserID] ASC);

