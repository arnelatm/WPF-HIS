CREATE TABLE [dbo].[CustomersNotes] (
    [NoteID]       INT            IDENTITY (1, 1) NOT NULL,
    [NodeTitle]    NVARCHAR (50)  NULL,
    [NodeDate]     DATE           NULL,
    [NodeSubject]  NVARCHAR (50)  NULL,
    [NodeTxt]      NVARCHAR (MAX) NULL,
    [NodeCustID]   NVARCHAR (MAX) NULL,
    [NodeCustName] NVARCHAR (50)  NULL,
    [NodeDrName]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_CustomersNotes] PRIMARY KEY CLUSTERED ([NoteID] ASC)
);

