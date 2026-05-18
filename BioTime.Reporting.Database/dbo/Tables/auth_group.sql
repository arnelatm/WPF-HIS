CREATE TABLE [dbo].[auth_group] (
    [id]   INT            IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_group_name_a6ea08ec_uniq] UNIQUE NONCLUSTERED ([name] ASC)
);

