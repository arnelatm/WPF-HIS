ALTER ROLE [db_owner] ADD MEMBER [IBN-SINA\ISPADMIN];


GO
ALTER ROLE [db_owner] ADD MEMBER [BiotimeUser];


GO
ALTER ROLE [db_datareader] ADD MEMBER [BiotimeRemote];


GO
ALTER ROLE [db_datareader] ADD MEMBER [biotime_remote];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [BiotimeRemote];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [biotime_remote];

