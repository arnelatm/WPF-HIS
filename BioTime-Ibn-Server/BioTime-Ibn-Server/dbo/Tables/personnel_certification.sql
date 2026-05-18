CREATE TABLE [dbo].[personnel_certification] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [cert_code] NVARCHAR (20)  NOT NULL,
    [cert_name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([cert_code] ASC),
    UNIQUE NONCLUSTERED ([cert_name] ASC)
);

