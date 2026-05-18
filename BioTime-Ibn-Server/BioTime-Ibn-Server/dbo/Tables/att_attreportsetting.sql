CREATE TABLE [dbo].[att_attreportsetting] (
    [id]                  INT      IDENTITY (1, 1) NOT NULL,
    [filter_by_hire_date] BIT      NOT NULL,
    [resign_emp]          SMALLINT NOT NULL,
    [short_date]          SMALLINT NOT NULL,
    [short_time]          SMALLINT NOT NULL,
    [auto_calculate]      BIT      NOT NULL,
    [calculate_time]      TIME (7) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

