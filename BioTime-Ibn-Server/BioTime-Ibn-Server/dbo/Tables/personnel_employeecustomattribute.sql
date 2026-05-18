CREATE TABLE [dbo].[personnel_employeecustomattribute] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [attr_name]  NVARCHAR (50)  NOT NULL,
    [attr_type]  SMALLINT       NOT NULL,
    [attr_value] NVARCHAR (999) NULL,
    [is_unique]  BIT            NOT NULL,
    [enable]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([attr_name] ASC)
);

