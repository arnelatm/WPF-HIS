CREATE TABLE [dbo].[att_attcode] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [code]           NVARCHAR (20)  NOT NULL,
    [alias]          NVARCHAR (50)  NOT NULL,
    [display_format] SMALLINT       NOT NULL,
    [symbol]         NVARCHAR (20)  NOT NULL,
    [round_off]      SMALLINT       NOT NULL,
    [min_val]        NUMERIC (4, 1) NOT NULL,
    [symbol_only]    BIT            NOT NULL,
    [order]          SMALLINT       NOT NULL,
    [color_setting]  NVARCHAR (30)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([alias] ASC),
    UNIQUE NONCLUSTERED ([code] ASC)
);

