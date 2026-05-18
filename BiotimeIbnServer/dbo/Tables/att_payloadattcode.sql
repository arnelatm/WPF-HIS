CREATE TABLE [dbo].[att_payloadattcode] (
    [id]              CHAR (32)      NOT NULL,
    [att_date]        DATE           NOT NULL,
    [week]            INT            NOT NULL,
    [weekday]         INT            NOT NULL,
    [att_code_alias]  NVARCHAR (50)  NOT NULL,
    [att_code_symbol] NVARCHAR (20)  NULL,
    [duration]        INT            NOT NULL,
    [workday]         NUMERIC (4, 1) NOT NULL,
    [hours]           NUMERIC (6, 1) NOT NULL,
    [minutes]         NUMERIC (8, 1) NOT NULL,
    [is_weekly]       BIT            NOT NULL,
    [att_code_id]     INT            NOT NULL,
    [emp_id]          INT            NOT NULL,
    [shift_id]        INT            NULL,
    [time_card_id]    CHAR (32)      NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_payloadattcode_att_code_id_0d635efd_fk_att_attcode_id] FOREIGN KEY ([att_code_id]) REFERENCES [dbo].[att_attcode] ([id]),
    CONSTRAINT [att_payloadattcode_emp_id_36569f54_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadattcode_shift_id_731faddf_fk_att_attshift_id] FOREIGN KEY ([shift_id]) REFERENCES [dbo].[att_attshift] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadattcode_att_code_id_0d635efd]
    ON [dbo].[att_payloadattcode]([att_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadattcode_att_date_19b2621e]
    ON [dbo].[att_payloadattcode]([att_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadattcode_emp_id_36569f54]
    ON [dbo].[att_payloadattcode]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadattcode_shift_id_731faddf]
    ON [dbo].[att_payloadattcode]([shift_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadattcode_time_card_id_e8a37c7a]
    ON [dbo].[att_payloadattcode]([time_card_id] ASC);

