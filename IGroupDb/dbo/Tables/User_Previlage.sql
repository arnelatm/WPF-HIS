CREATE TABLE [dbo].[User_Previlage] (
    [BranchID]        VARCHAR (15)  NOT NULL,
    [userID]          VARCHAR (15)  NOT NULL,
    [ApplicationName] VARCHAR (25)  NOT NULL,
    [Control_type]    VARCHAR (15)  NOT NULL,
    [control_name]    VARCHAR (100) NULL,
    [control_caption] VARCHAR (100) NULL,
    [value]           NUMERIC (1)   NULL,
    [sl_no]           NUMERIC (9)   DEFAULT (0) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_User_Previlage]
    ON [dbo].[User_Previlage]([BranchID] ASC, [userID] ASC, [ApplicationName] ASC, [Control_type] ASC, [control_name] ASC);

