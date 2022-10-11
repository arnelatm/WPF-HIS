CREATE TABLE [dbo].[XryTemplates] (
    [TemplateID]               VARCHAR (6)    NOT NULL,
    [TemplateName]             VARCHAR (50)   NOT NULL,
    [InvestigationID]          VARCHAR (15)   NOT NULL,
    [InvestigationName]        VARCHAR (50)   NOT NULL,
    [InvestigationDescription] NVARCHAR (MAX) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_XryTemplates]
    ON [dbo].[XryTemplates]([TemplateID] ASC);

