CREATE TABLE [dbo].[ListGroup] (
    [IdNo]        SMALLINT      IDENTITY (1, 1) NOT NULL,
    [ListName]    VARCHAR (50)  NULL,
    [ListNameAra] NVARCHAR (50) NULL,
    [Coded]       BIT           NULL,
    [UseIdNo]     BIT           NULL,
    [Closed]      BIT           NULL,
    CONSTRAINT [PK_ListGroup] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



