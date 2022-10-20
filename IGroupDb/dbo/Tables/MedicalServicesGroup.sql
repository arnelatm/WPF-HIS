CREATE TABLE [dbo].[MedicalServicesGroup] (
    [BranchID]       VARCHAR (15) NOT NULL,
    [GroupServiceID] VARCHAR (15) NOT NULL,
    [ServiceID]      VARCHAR (15) NOT NULL,
    [Activate]       INT          DEFAULT ((1)) NULL
);


GO
CREATE NONCLUSTERED INDEX [IDX_MedicalServicesGroup]
    ON [dbo].[MedicalServicesGroup]([BranchID] ASC, [ServiceID] ASC);

