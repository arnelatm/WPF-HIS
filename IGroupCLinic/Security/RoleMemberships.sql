ALTER ROLE [db_owner] ADD MEMBER [iGroupAdmin];


GO
ALTER ROLE [db_accessadmin] ADD MEMBER [iGroupAdmin];


GO
ALTER ROLE [db_securityadmin] ADD MEMBER [iGroupAdmin];


GO
ALTER ROLE [db_ddladmin] ADD MEMBER [iGroupAdmin];


GO
ALTER ROLE [db_backupoperator] ADD MEMBER [iGroupAdmin];


GO
ALTER ROLE [db_datareader] ADD MEMBER [iGroupAdmin];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [iGroupAdmin];

