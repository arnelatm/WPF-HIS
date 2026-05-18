CREATE TABLE [dbo].[base_sendemail] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [purpose]       INT            NOT NULL,
    [email_to]      NVARCHAR (MAX) NOT NULL,
    [email_cc]      NVARCHAR (MAX) NULL,
    [email_bcc]     NVARCHAR (MAX) NULL,
    [email_subject] NVARCHAR (40)  NOT NULL,
    [email_content] NVARCHAR (MAX) NULL,
    [send_time]     DATETIME2 (7)  NULL,
    [send_status]   SMALLINT       NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

