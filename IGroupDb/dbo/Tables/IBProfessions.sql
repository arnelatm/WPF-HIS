CREATE TABLE [dbo].[IBProfessions] (
    [Trans_Key]        NUMERIC (10)  NOT NULL,
    [ProfessionID]     VARCHAR (15)  NOT NULL,
    [ProfessionName]   NVARCHAR (75) NOT NULL,
    [ProfessionArabic] NVARCHAR (75) NULL,
    [Active]           INT           DEFAULT ((1)) NULL,
    [UserID]           VARCHAR (15)  NULL,
    [Create_Date]      DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBProfessions]
    ON [dbo].[IBProfessions]([ProfessionID] ASC);

