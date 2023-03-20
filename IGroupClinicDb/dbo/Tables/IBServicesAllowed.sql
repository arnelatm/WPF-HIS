CREATE TABLE [dbo].[IBServicesAllowed] (
    [IBType]      VARCHAR (4)  NOT NULL,
    [ServiceID]   VARCHAR (15) NOT NULL,
    [Activate]    INT          DEFAULT ((0)) NULL,
    [UserID]      VARCHAR (15) NULL,
    [Create_Date] DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]   VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBServicesAllowed]
    ON [dbo].[IBServicesAllowed]([IBType] ASC, [ServiceID] ASC);

