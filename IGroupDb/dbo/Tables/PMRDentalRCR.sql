CREATE TABLE [dbo].[PMRDentalRCR] (
    [Trans_key]         BIGINT        NOT NULL,
    [teeth_present1]    VARCHAR (20)  NULL,
    [teeth_present2]    VARCHAR (20)  NULL,
    [teeth_present3]    VARCHAR (20)  NULL,
    [teeth_present4]    VARCHAR (20)  NULL,
    [teeth_absent1]     VARCHAR (20)  NULL,
    [teeth_absent2]     VARCHAR (20)  NULL,
    [teeth_absent3]     VARCHAR (20)  NULL,
    [teeth_absent4]     VARCHAR (20)  NULL,
    [root_formation]    VARCHAR (30)  NULL,
    [root_resorption]   VARCHAR (30)  NULL,
    [permanent_tooth]   VARCHAR (30)  NULL,
    [supp_teeth]        VARCHAR (30)  NULL,
    [third_molars]      VARCHAR (30)  NULL,
    [pathological_cond] VARCHAR (30)  NULL,
    [others]            VARCHAR (100) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalRCR]
    ON [dbo].[PMRDentalRCR]([Trans_key] ASC);

