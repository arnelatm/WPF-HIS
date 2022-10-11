CREATE TABLE [dbo].[AccTrialBalance] (
    [br_code]     VARCHAR (2)     NOT NULL,
    [vou_date]    VARCHAR (10)    NOT NULL,
    [ac_code]     VARCHAR (20)    NOT NULL,
    [name_e]      VARCHAR (50)    NULL,
    [name_a]      VARCHAR (1)     NOT NULL,
    [ac_or_group] VARCHAR (1)     NOT NULL,
    [level_no]    INT             NOT NULL,
    [parent_code] VARCHAR (10)    NULL,
    [parent_name] VARCHAR (50)    NULL,
    [acc_type]    VARCHAR (1)     NOT NULL,
    [op_debit]    INT             NOT NULL,
    [op_credit]   INT             NOT NULL,
    [OP_BALANCE]  INT             NOT NULL,
    [debit]       NUMERIC (38, 2) NULL,
    [credit]      NUMERIC (38, 2) NULL,
    [BALANCE]     NUMERIC (38, 2) NULL
);

