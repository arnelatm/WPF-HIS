-- Reference model only. Do not execute or publish this project.
-- The placeholder below is not a live password.

CREATE LOGIN [AATM_Accounts_Prod]
    WITH PASSWORD = '$(ReferenceOnlyLoginPassword)';
GO

CREATE LOGIN [iGroupAdmin]
    WITH PASSWORD = '$(ReferenceOnlyLoginPassword)';

GO
CREATE LOGIN [IBN-SINA\AATM-Accounts-Users]
    FROM WINDOWS;
