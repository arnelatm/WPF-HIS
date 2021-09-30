CREATE TABLE [dbo].[DefaultFieldValue] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [SystemViewIdNo]   SMALLINT      NULL,
    [ViewName]         VARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [FieldName]        VARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DataType]         TINYINT       NOT NULL,
    [Length]           SMALLINT      NOT NULL,
    [DecimalPart]      TINYINT       NULL,
    [LinkedTable]      VARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [LinkedFieldValue] VARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [LinkedField]      VARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DefaultValue]     VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK_DefaultFieldValue] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);













