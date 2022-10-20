CREATE TABLE [dbo].[LOV_DEFINITION] (
    [Lov_Field]       VARCHAR (30)  NOT NULL,
    [Field_1]         VARCHAR (30)  NULL,
    [Field_2]         VARCHAR (30)  NULL,
    [Field_3]         VARCHAR (30)  NULL,
    [Field_4]         VARCHAR (30)  NULL,
    [Field_5]         VARCHAR (30)  NULL,
    [Table_Name]      VARCHAR (50)  NULL,
    [From_Where]      VARCHAR (150) NULL,
    [Width]           NUMERIC (5)   NULL,
    [Heading]         VARCHAR (150) NULL,
    [Col_Width_1]     NUMERIC (3)   NULL,
    [Col_Width_2]     NUMERIC (3)   NULL,
    [Col_Width_3]     NUMERIC (3)   NULL,
    [Col_Width_4]     NUMERIC (3)   NULL,
    [Col_Width_5]     NUMERIC (3)   NULL,
    [Total_Col_Width] NUMERIC (3)   NULL,
    [No_of_fields]    NUMERIC (3)   NULL,
    [No_of_Rows]      NUMERIC (3)   NULL
);

