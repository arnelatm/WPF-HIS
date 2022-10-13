CREATE TABLE [dbo].[INJOtherServices] (
    [BranchID]    VARCHAR (15) DEFAULT ('02') NULL,
    [ServiceID]   VARCHAR (15) NOT NULL,
    [Status]      INT          DEFAULT ((1)) NULL,
    [Create_Date] DATETIME     DEFAULT (getdate()) NULL,
    [UserID]      VARCHAR (15) NULL,
    [MachineID]   VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE CLUSTERED INDEX [IDX_INJOtherServices]
    ON [dbo].[INJOtherServices]([ServiceID] ASC);

