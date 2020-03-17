' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoFactoryCommon
        Inherits IDaoFactory

        Function CreateDao(classBasename as String)

        'ReadOnly Property CommonDao As ICommonDao
        'ReadOnly Property CountryDao As ICountryDao
        'ReadOnly Property BranchDao As IBranchDao
        'ReadOnly Property ProfitCenterDao As IProfitCenterDao
        'ReadOnly Property CostCenterDao As ICostCenterDao
        'ReadOnly Property DepartmentDao As IDepartmentDao
        'ReadOnly Property ReligionDao As IReligionDao
        'ReadOnly Property RevenueGroupDao As IRevenueGroupDao
        'ReadOnly Property PhoneTypeDao As IPhoneTypeDao
        'ReadOnly Property OriginalMessagesDao As IOriginalMessagesDao
        'ReadOnly Property TranslatedMessagesDao As ITranslatedMessagesDao

    End Interface

End Namespace