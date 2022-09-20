CREATE TABLE [dbo].[temp] (
    [TagName]        VARCHAR (30)  NOT NULL,
    [ColumnWidth]    VARCHAR (200) NOT NULL,
    [QueryString]    VARCHAR (500) NOT NULL,
    [FieldNames]     VARCHAR (500) NOT NULL,
    [FieldTypes]     VARCHAR (300) NOT NULL,
    [HeadingString]  VARCHAR (700) NOT NULL,
    [SelectField]    VARCHAR (30)  NOT NULL,
    [OrderField]     VARCHAR (100) NULL,
    [NoOfRows]       NUMERIC (2)   NULL,
    [LookupHeight]   NUMERIC (3)   NULL,
    [LookupWidth]    NUMERIC (3)   NULL,
    [LookupPosition] VARCHAR (15)  NULL
);

