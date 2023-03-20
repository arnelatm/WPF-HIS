CREATE TABLE [dbo].[PMRDentalDTPR] (
    [Trans_key]         BIGINT          NOT NULL,
    [diagnosis]         TEXT            NULL,
    [treatment]         TEXT            NULL,
    [treatment_plan]    TEXT            NULL,
    [prognosis]         TEXT            NULL,
    [type_of_appliance] TEXT            NULL,
    [duration]          VARCHAR (30)    NULL,
    [cost]              NUMERIC (10, 2) DEFAULT (0) NULL,
    [rtention_plan]     TEXT            NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalDTPR]
    ON [dbo].[PMRDentalDTPR]([Trans_key] ASC);

