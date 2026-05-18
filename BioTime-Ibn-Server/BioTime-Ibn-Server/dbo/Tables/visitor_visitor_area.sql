CREATE TABLE [dbo].[visitor_visitor_area] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [visitor_id] INT NOT NULL,
    [area_id]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitor_area_area_id_b402c047_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id]),
    CONSTRAINT [visitor_visitor_area_visitor_id_98d7ed05_fk_visitor_visitor_id] FOREIGN KEY ([visitor_id]) REFERENCES [dbo].[visitor_visitor] ([id])
);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_area_area_id_b402c047]
    ON [dbo].[visitor_visitor_area]([area_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_area_visitor_id_98d7ed05]
    ON [dbo].[visitor_visitor_area]([visitor_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [visitor_visitor_area_visitor_id_area_id_27d158cc_uniq]
    ON [dbo].[visitor_visitor_area]([visitor_id] ASC, [area_id] ASC) WHERE ([visitor_id] IS NOT NULL AND [area_id] IS NOT NULL);

