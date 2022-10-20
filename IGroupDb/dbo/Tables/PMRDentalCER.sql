CREATE TABLE [dbo].[PMRDentalCER] (
    [Trans_Key]           BIGINT        NOT NULL,
    [max_arch_shape]      VARCHAR (30)  NULL,
    [max_arch_symmetry]   VARCHAR (30)  NULL,
    [max_arch_alignment]  VARCHAR (30)  NULL,
    [man_arch_shape]      VARCHAR (30)  NULL,
    [man_arch_symmetry]   VARCHAR (30)  NULL,
    [man_arch_alignment]  VARCHAR (30)  NULL,
    [molar_relation]      VARCHAR (30)  NULL,
    [canine_relation]     VARCHAR (30)  NULL,
    [incisor_relation]    VARCHAR (30)  NULL,
    [incisor_overjet]     VARCHAR (30)  NULL,
    [incisor_overbite]    VARCHAR (30)  NULL,
    [incisor_overiteper]  VARCHAR (30)  NULL,
    [transverse_relation] VARCHAR (30)  NULL,
    [middle_upper]        VARCHAR (30)  NULL,
    [path_of_closure]     VARCHAR (30)  NULL,
    [others]              VARCHAR (100) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalCER]
    ON [dbo].[PMRDentalCER]([Trans_Key] ASC);

