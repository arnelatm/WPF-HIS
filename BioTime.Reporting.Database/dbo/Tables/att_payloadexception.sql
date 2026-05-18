CREATE TABLE [dbo].[att_payloadexception] (
    [uuid]        NVARCHAR (36) NOT NULL,
    [start_time]  DATETIME2 (7) NOT NULL,
    [end_time]    DATETIME2 (7) NOT NULL,
    [duration]    INT           NULL,
    [days]        FLOAT (53)    NULL,
    [data_type]   SMALLINT      NOT NULL,
    [description] NVARCHAR (50) NULL,
    [item_id]     INT           NULL,
    [skd_id]      NVARCHAR (36) NULL,
    PRIMARY KEY CLUSTERED ([uuid] ASC),
    CONSTRAINT [att_payloadexception_item_id_a08bfe48_fk_att_leave_workflowinstance_ptr_id] FOREIGN KEY ([item_id]) REFERENCES [dbo].[att_leave] ([workflowinstance_ptr_id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadexception_item_id_a08bfe48]
    ON [dbo].[att_payloadexception]([item_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadexception_skd_id_b2e9ecaa]
    ON [dbo].[att_payloadexception]([skd_id] ASC);

