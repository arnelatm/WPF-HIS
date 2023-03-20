CREATE TABLE [dbo].[ItemRegistration] (
    [IdNo]           INT             IDENTITY (1, 1) NOT NULL,
    [Item_Code]      VARCHAR (15)    NOT NULL,
    [GTIN]           VARCHAR (14)    NULL,
    [RegistrationNo] VARCHAR (30)    NOT NULL,
    [strength]       NUMERIC (10, 5) NULL,
    CONSTRAINT [PK_ItemRegistration] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

