CREATE TABLE [dbo].[base_apiendpoint] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NOT NULL,
    [path]        NVARCHAR (255) NOT NULL,
    [method]      NVARCHAR (10)  NOT NULL,
    [module]      NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    [is_active]   BIT            NOT NULL,
    [created_at]  DATETIME2 (7)  NOT NULL,
    [updated_at]  DATETIME2 (7)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [base_apiendpoint_path_method_968394da_uniq]
    ON [dbo].[base_apiendpoint]([path] ASC, [method] ASC) WHERE ([path] IS NOT NULL AND [method] IS NOT NULL);

