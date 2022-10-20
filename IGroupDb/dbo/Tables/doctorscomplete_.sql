CREATE TABLE [dbo].[doctorscomplete$] (
    [doctcode] NVARCHAR (255) NULL,
    [doctname] NVARCHAR (255) NULL,
    [doctanam] NVARCHAR (255) NULL,
    [doctinit] NVARCHAR (255) NULL,
    [deptcode] NVARCHAR (255) NULL,
    [inactive] NVARCHAR (255) NULL,
    [exam_fee] FLOAT (53)     NULL,
    [fixedfee] BIT            NOT NULL,
    [doctordr] FLOAT (53)     NULL,
    [spclcode] NVARCHAR (255) NULL,
    [serial]   FLOAT (53)     NULL
);

