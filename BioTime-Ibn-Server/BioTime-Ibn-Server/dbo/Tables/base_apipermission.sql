CREATE TABLE [dbo].[base_apipermission] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [is_active]   BIT           NOT NULL,
    [created_at]  DATETIME2 (7) NOT NULL,
    [updated_at]  DATETIME2 (7) NOT NULL,
    [endpoint_id] INT           NOT NULL,
    [user_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_apipermission_endpoint_id_b0111158_fk_base_apiendpoint_id] FOREIGN KEY ([endpoint_id]) REFERENCES [dbo].[base_apiendpoint] ([id]),
    CONSTRAINT [base_apipermission_user_id_1442696f_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [base_apipermission_endpoint_id_b0111158]
    ON [dbo].[base_apipermission]([endpoint_id] ASC);


GO
CREATE NONCLUSTERED INDEX [base_apipermission_user_id_1442696f]
    ON [dbo].[base_apipermission]([user_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [base_apipermission_user_id_endpoint_id_e7a02a0a_uniq]
    ON [dbo].[base_apipermission]([user_id] ASC, [endpoint_id] ASC) WHERE ([user_id] IS NOT NULL AND [endpoint_id] IS NOT NULL);

