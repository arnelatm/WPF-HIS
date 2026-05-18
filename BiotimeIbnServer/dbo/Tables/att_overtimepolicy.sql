CREATE TABLE [dbo].[att_overtimepolicy] (
    [id]                    INT            IDENTITY (1, 1) NOT NULL,
    [create_time]           DATETIME2 (7)  NULL,
    [create_user]           NVARCHAR (150) NULL,
    [change_time]           DATETIME2 (7)  NULL,
    [change_user]           NVARCHAR (150) NULL,
    [status]                SMALLINT       NOT NULL,
    [mode]                  SMALLINT       NOT NULL,
    [hrs_from]              NUMERIC (4, 1) NOT NULL,
    [hrs_to]                NUMERIC (4, 1) NOT NULL,
    [master]                CHAR (32)      NOT NULL,
    [overnight_pay_code_id] INT            NULL,
    [pay_code_id]           INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_overtimepolicy_overnight_pay_code_id_274ce1b0_fk_att_paycode_id] FOREIGN KEY ([overnight_pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [att_overtimepolicy_pay_code_id_285b0a61_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_overtimepolicy_overnight_pay_code_id_274ce1b0]
    ON [dbo].[att_overtimepolicy]([overnight_pay_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_overtimepolicy_pay_code_id_285b0a61]
    ON [dbo].[att_overtimepolicy]([pay_code_id] ASC);

