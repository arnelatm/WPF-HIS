CREATE TABLE [dbo].[FormControlsHandling] (
    [form_name]     VARCHAR (30) NOT NULL,
    [control_name]  VARCHAR (30) NOT NULL,
    [control_value] CHAR (1)     DEFAULT ('N') NULL,
    [UserID]        VARCHAR (15) DEFAULT ('All') NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_FormControlsHandling]
    ON [dbo].[FormControlsHandling]([form_name] ASC, [control_name] ASC);

