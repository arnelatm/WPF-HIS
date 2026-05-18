CREATE TABLE [dbo].[django_content_type] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [app_label] NVARCHAR (100) NOT NULL,
    [model]     NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [django_content_type_app_label_model_76bd3d3b_uniq]
    ON [dbo].[django_content_type]([app_label] ASC, [model] ASC) WHERE ([app_label] IS NOT NULL AND [model] IS NOT NULL);

