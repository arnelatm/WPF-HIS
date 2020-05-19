CREATE TABLE [dbo].[InterfaceObjectsSecurity] (
    [IdNo]                INT        IDENTITY (1, 1) NOT NULL,
    [LoginIDNo]           INT        NOT NULL,
    [InterfaceObjectIDNo] INT        NOT NULL,
    [Editable]            BIT        NOT NULL,
    [Visible]             BIT        NOT NULL,
    [DateTimeStamp]       ROWVERSION NULL,
    CONSTRAINT [PK_InterfaceObjectSecurity] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_IntObjLoginIDNo]
    ON [dbo].[InterfaceObjectsSecurity]([LoginIDNo] ASC, [InterfaceObjectIDNo] ASC);

