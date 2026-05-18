CREATE TABLE [dbo].[att_reportparam] (
    [param_name]  NVARCHAR (20)  NOT NULL,
    [param_value] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([param_name] ASC)
);

