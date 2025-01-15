CREATE TABLE [dbo].[1] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [date1]               DATETIME       NULL,
    [paname]              NVARCHAR (255) NULL,
    [tf no]               NVARCHAR (255) NULL,
    [birthdate]           DATETIME       NULL,
    [gender]              NVARCHAR (255) NULL,
    [nationality]         NVARCHAR (255) NULL,
    [marital status]      NVARCHAR (255) NULL,
    [num of children]     NVARCHAR (255) NULL,
    [work]                NVARCHAR (255) NULL,
    [blood group]         NVARCHAR (255) NULL,
    [drug reactions]      NTEXT          NULL,
    [health status]       NVARCHAR (MAX) NULL,
    [notes]               NVARCHAR (255) NULL,
    [referral from]       NTEXT          NULL,
    [address]             NVARCHAR (255) NULL,
    [phone1]              NVARCHAR (255) NULL,
    [phone2]              NVARCHAR (255) NULL,
    [photo1]              NVARCHAR (255) NULL,
    [photo2]              NVARCHAR (255) NULL,
    [d1]                  NVARCHAR (255) NULL,
    [d2]                  NVARCHAR (255) NULL,
    [d3]                  NVARCHAR (255) NULL,
    [d4]                  NVARCHAR (255) NULL,
    [d5]                  NVARCHAR (255) NULL,
    [d6]                  NVARCHAR (255) NULL,
    [doctor name]         NVARCHAR (255) NULL,
    [insurance companies] NVARCHAR (255) NULL,
    [phone3]              NVARCHAR (255) NULL,
    [phone4]              NVARCHAR (255) NULL,
    [shak]                NTEXT          NULL,
    [3adat]               NTEXT          NULL,
    [teeth clen]          NTEXT          NULL,
    [teeth status]        NTEXT          NULL,
    [pastwork]            NTEXT          NULL,
    [gum]                 NTEXT          NULL,
    [glossa]              NTEXT          NULL,
    [tethcabt]            NTEXT          NULL,
    [lip]                 NTEXT          NULL,
    [aritcal]             NTEXT          NULL,
    [asnanam]             NTEXT          NULL,
    [hethtext]            NTEXT          NULL,
    [dd1]                 NVARCHAR (255) NULL,
    [dd2]                 NVARCHAR (255) NULL,
    [dd3]                 NVARCHAR (255) NULL,
    [dd4]                 NVARCHAR (255) NULL,
    [lastdate]            DATETIME       NULL,
    [lastvist]            DATETIME       NULL,
    [engname]             NVARCHAR (255) NULL,
    [notesa]              NTEXT          NULL,
    [laslvist2]           DATETIME       NULL,
    [dor]                 NVARCHAR (255) NULL,
    [nesb]                NVARCHAR (255) NULL,
    [smsberth]            NVARCHAR (255) NULL,
    [brday]               SMALLINT       NULL,
    [bronth]              SMALLINT       NULL,
    [inscenddate]         DATETIME       NULL,
    [spersnal]            NTEXT          NULL,
    [sfamil]              NTEXT          NULL,
    [sdrog]               NTEXT          NULL,
    [mordr]               NVARCHAR (255) NULL,
    [Fname]               NVARCHAR (255) NULL,
    [Mname]               NVARCHAR (255) NULL,
    [idnom]               NVARCHAR (255) NULL,
    [eyespast]            NTEXT          NULL,
    [ENTpast]             NTEXT          NULL,
    [SkinPast]            NTEXT          NULL,
    [enablesms]           NVARCHAR (255) NULL,
    [Signature1]          IMAGE          NULL,
    [Pasource]            NVARCHAR (MAX) NULL,
    [DDiscount]           NVARCHAR (50)  NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1';


GO
EXECUTE sp_addextendedproperty @name = N'DateCreated', @value = N'26/07/2015 12:55:17 م', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1';


GO
EXECUTE sp_addextendedproperty @name = N'LastUpdated', @value = N'26/07/2015 12:55:17 م', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1';


GO
EXECUTE sp_addextendedproperty @name = N'RecordCount', @value = N'2692', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1';


GO
EXECUTE sp_addextendedproperty @name = N'Updatable', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'17', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'date1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'date1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'date1';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'paname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'paname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'paname';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'tf no', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'tf no', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tf no';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'birthdate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'birthdate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'birthdate';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'gender', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'gender', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gender';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'nationality', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'7', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'nationality', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nationality';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'marital status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'marital status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'marital status';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'num of children', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'9', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'num of children', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'num of children';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'work', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'work', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'work';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'blood group', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'11', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'blood group', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'blood group';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'drug reactions', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'drug reactions', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'drug reactions';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'health status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'13', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'health status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'health status';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'notes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'14', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'notes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notes';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'referral from', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'15', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'referral from', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'referral from';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'address', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'16', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'address', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'phone1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'17', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'phone1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone1';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'phone2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'18', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'phone2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone2';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'photo1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'19', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'photo1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo1';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'photo2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'20', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'photo2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'photo2';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'd1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'21', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'd1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd1';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'd2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'22', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'd2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd2';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'd3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'23', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'd3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd3';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'd4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'24', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'd4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd4';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'd5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'25', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'd5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd5';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'd6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'26', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'd6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'd6';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'doctor name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'27', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'doctor name', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'doctor name';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'insurance companies', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'28', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'insurance companies', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'insurance companies';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'phone3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'29', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'phone3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone3';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'phone4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'30', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'phone4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'phone4';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'shak', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'31', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'shak', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'shak';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'3adat', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'32', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'3adat', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'3adat';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'teeth clen', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'33', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'teeth clen', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth clen';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'teeth status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'34', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'teeth status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'teeth status';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'pastwork', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'35', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'pastwork', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'pastwork';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'gum', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'36', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'gum', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'gum';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'glossa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'37', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'glossa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'glossa';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'tethcabt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'38', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'tethcabt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'tethcabt';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'lip', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'39', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'lip', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lip';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'aritcal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'40', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'aritcal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'aritcal';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'asnanam', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'41', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'asnanam', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'asnanam';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'hethtext', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'42', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'hethtext', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'hethtext';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'dd1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'43', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'dd1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd1';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'dd2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'44', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'dd2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd2';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'dd3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'45', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'dd3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd3';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'dd4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'46', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'dd4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dd4';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'lastdate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'47', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'lastdate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastdate';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'lastvist', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'48', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'lastvist', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'lastvist';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'engname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'49', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'engname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'engname';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'notesa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'50', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'notesa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'notesa';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'laslvist2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'51', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'laslvist2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'laslvist2';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'dor', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'52', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'dor', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'dor';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'nesb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'53', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'nesb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'nesb';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'smsberth', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'54', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'smsberth', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'smsberth';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'brday', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'55', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'brday', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'brday';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'bronth', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'56', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'bronth', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'bronth';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'inscenddate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'57', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'inscenddate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'inscenddate';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'spersnal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'58', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'spersnal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'spersnal';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'sfamil', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'59', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'sfamil', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sfamil';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'sdrog', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'60', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'sdrog', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'sdrog';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'mordr', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'61', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'mordr', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'mordr';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'Fname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'62', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'Fname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Fname';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'Mname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'63', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'Mname', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'Mname';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'idnom', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'64', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'idnom', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'idnom';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'eyespast', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'65', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'eyespast', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'eyespast';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'ENTpast', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'66', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'ENTpast', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'ENTpast';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'SkinPast', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'67', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'SkinPast', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'SkinPast';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'enablesms', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'68', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'enablesms', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'patient files', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'1', @level2type = N'COLUMN', @level2name = N'enablesms';

