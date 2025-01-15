CREATE TABLE [dbo].[VisitType] (
    [ID]                        INT            IDENTITY (1, 1) NOT NULL,
    [Name]                      NVARCHAR (MAX) NULL,
    [NameLatin]                 NVARCHAR (MAX) NULL,
    [SpecializationID]          INT            NULL,
    [ParentID]                  INT            NULL,
    [Note]                      NVARCHAR (MAX) NULL,
    [DefaultData]               NVARCHAR (MAX) NULL,
    [IsDisabled]                BIT            NULL,
    [IsDirection]               BIT            NULL,
    [IsForced]                  BIT            NULL,
    [IsMultiLine]               BIT            NULL,
    [IsPreventUserFromEdit]     BIT            NULL,
    [IsClearOldData]            BIT            NULL,
    [IsDisabledNoteTemplte]     BIT            NULL,
    [IsDisabledOldDataAsSource] BIT            NULL,
    [Icon]                      IMAGE          NULL,
    [Sort]                      INT            NULL,
    [RegPattern]                NVARCHAR (255) NULL,
    CONSTRAINT [PK_VisitType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

