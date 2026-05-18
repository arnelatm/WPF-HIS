CREATE TABLE [dbo].[attparam] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [paraname]  NVARCHAR (30)  NOT NULL,
    [paratype]  NVARCHAR (10)  NULL,
    [paravalue] NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [attparam_paraname_paratype_6f176d25_uniq]
    ON [dbo].[attparam]([paraname] ASC, [paratype] ASC) WHERE ([paraname] IS NOT NULL AND [paratype] IS NOT NULL);

