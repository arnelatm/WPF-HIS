CREATE TABLE [dbo].[GroupAccess] (
    [IdNo]               INT        IDENTITY (1, 1) NOT NULL,
    [SecurityGroupIDNo]  SMALLINT   NOT NULL,
    [SecurityObjectIDNo] INT        NOT NULL,
    [Visible]            BIT        NOT NULL,
    [Editable]           BIT        NOT NULL,
    [DateTimeStamp]      ROWVERSION NULL,
    CONSTRAINT [PK_SecurityGroupAccessIDNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





