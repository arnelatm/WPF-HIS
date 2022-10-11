CREATE TABLE [dbo].[AccountsVoucherGroup] (
    [BranchID]     VARCHAR (15) NOT NULL,
    [Trans_Key]    NUMERIC (10) NOT NULL,
    [TransNo]      NUMERIC (10) NOT NULL,
    [Vdate]        VARCHAR (10) NOT NULL,
    [FinYear]      VARCHAR (9)  NOT NULL,
    [VType]        VARCHAR (3)  NOT NULL,
    [VCategory]    VARCHAR (3)  NOT NULL,
    [RefType]      VARCHAR (10) NULL,
    [RefNo]        NUMERIC (10) NULL,
    [Status]       CHAR (1)     NULL,
    [CheckedBy]    VARCHAR (15) NULL,
    [ProvedBy]     VARCHAR (15) NULL,
    [VDescription] NTEXT        NULL,
    [UserID]       CHAR (15)    NOT NULL,
    [Create_Date]  DATETIME     DEFAULT (getdate()) NULL,
    [machineID]    VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX_AccountsVoucherGroup]
    ON [dbo].[AccountsVoucherGroup]([BranchID] ASC, [VType] ASC, [TransNo] ASC, [Trans_Key] ASC);

