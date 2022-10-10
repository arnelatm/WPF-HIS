CREATE TABLE [dbo].[Doctor] (
    [IdNo]          INT          IDENTITY (1, 1) NOT NULL,
    [DoctorCode]    NVARCHAR (3) NULL,
    [EmployeeIdNo]  INT          NULL,
    [SpecialtyIdNo] INT          NULL,
    [Active]        BIT          NULL,
    [DateCreated]   DATE         CONSTRAINT [DF_Doctor_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION   NULL,
    CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

