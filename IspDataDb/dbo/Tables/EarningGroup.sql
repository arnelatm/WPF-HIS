CREATE TABLE [dbo].[EarningGroup] (
    [IdNo]                SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EarningGroupCode]    VARCHAR (10)   NULL,
    [EarningGroupName]    VARCHAR (50)   NULL,
    [EarningGroupNameAra] NVARCHAR (50)  NULL,
    [Notes]               NVARCHAR (100) NULL,
    CONSTRAINT [PK_EarningGroupIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

