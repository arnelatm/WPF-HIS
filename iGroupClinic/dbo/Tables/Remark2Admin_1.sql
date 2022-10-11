CREATE TABLE [dbo].[Remark2Admin] (
    [remarkID]    INT           IDENTITY (1, 1) NOT NULL,
    [BranchID]    VARCHAR (15)  NOT NULL,
    [TransDate]   DATETIME      NOT NULL,
    [Remark]      VARCHAR (300) NULL,
    [SendSuccess] CHAR (1)      DEFAULT ('N') NULL,
    [ReadSuccess] CHAR (1)      DEFAULT ('N') NULL,
    [CreateDate]  DATETIME      DEFAULT (getdate()) NULL,
    [UserID]      VARCHAR (10)  NULL,
    [machineId]   VARCHAR (20)  DEFAULT (host_name()) NULL,
    PRIMARY KEY CLUSTERED ([remarkID] ASC)
);

