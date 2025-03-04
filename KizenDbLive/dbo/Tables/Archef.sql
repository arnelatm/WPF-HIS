CREATE TABLE [dbo].[Archef] (
    [ArchefID]         INT            IDENTITY (1, 1) NOT NULL,
    [ArchefDateTime]   DATETIME       NULL,
    [ArchefDeviceName] NVARCHAR (255) NULL,
    [ArchefUserName]   NVARCHAR (255) NULL,
    [ArchefLocation]   NVARCHAR (MAX) NULL,
    [ArchefType]       NVARCHAR (MAX) NULL,
    [ArchefDetales]    NVARCHAR (MAX) NULL,
    [ArchefImagePath]  NVARCHAR (MAX) NULL,
    [ArchefCause]      NVARCHAR (MAX) NULL,
    [ArchefTitle]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Archef] PRIMARY KEY CLUSTERED ([ArchefID] ASC)
);

