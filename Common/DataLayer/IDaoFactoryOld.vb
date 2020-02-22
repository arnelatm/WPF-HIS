' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoFactoryOld

        ReadOnly Property SecurityDao As ISecurityDao
        ReadOnly Property CountryDao As ICountryDao
        ReadOnly Property BranchDao As IBranchDao
        ReadOnly Property ProfitCenterDao As IProfitCenterDao
        ReadOnly Property CostCenterDao As ICostCenterDao
        ReadOnly Property DepartmentDao As IDepartmentDao
        ReadOnly Property ReligionDao As IReligionDao
        ReadOnly Property RevenueGroupDao As IRevenueGroupDao

        ReadOnly Property UserDao As IUserDao
        ReadOnly Property LoginDao As ILoginDao
        ReadOnly Property LogoutDao As ILogoutDao
        ReadOnly Property SaltDao As ISaltDao

        ReadOnly Property PhoneTypeDao As IPhoneTypeDao
        ReadOnly Property SecurityGroupDao As ISecurityGroupDao
        ReadOnly Property SecurityObjectDao As ISecurityObjectDao
        ReadOnly Property GroupAccessDao As IGroupAccessDao
        ReadOnly Property OriginalMessagesDao As IOriginalMessagesDao
        ReadOnly Property TranslatedMessagesDao As ITranslatedMessagesDao

    End Interface

End Namespace