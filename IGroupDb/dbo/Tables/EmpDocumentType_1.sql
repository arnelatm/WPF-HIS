CREATE TABLE [dbo].[EmpDocumentType] (
    [DocID]       VARCHAR (15)   NOT NULL,
    [Description] VARCHAR (50)   NOT NULL,
    [Width]       NUMERIC (7, 2) DEFAULT ((11.5)) NULL,
    [Height]      NUMERIC (7, 2) DEFAULT ((8.23)) NULL,
    [CountryIOTA] VARCHAR (15)   DEFAULT (NULL) NULL,
    [remark]      VARCHAR (150)  NULL,
    [activate]    INT            NULL
);

