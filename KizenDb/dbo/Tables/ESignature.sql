CREATE TABLE [dbo].[ESignature] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [SourceType]     NVARCHAR (50)  NULL,
    [LocationType]   NVARCHAR (50)  NULL,
    [LocationNumber] INT            NULL,
    [TargetID]       INT            NULL,
    [UserID]         INT            NULL,
    [UserName]       NVARCHAR (MAX) NULL,
    [Date]           DATETIME       NULL,
    [DeviceName]     NVARCHAR (MAX) NULL,
    [UserIDEdit]     INT            NULL,
    [UserNameEdit]   NVARCHAR (MAX) NULL,
    [DateEdit]       DATETIME       NULL,
    [DeviceNameEdit] NVARCHAR (MAX) NULL,
    [IsPathStored]   BIT            NULL,
    [d1]             NVARCHAR (MAX) NULL,
    [d2]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ESignature] PRIMARY KEY CLUSTERED ([ID] ASC)
);

