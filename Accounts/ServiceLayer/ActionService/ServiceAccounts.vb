Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Service As Object

        Protected Shared ReadOnly AccountsFactory As IAccountsDaoFactory = AccountsDaoFactories.GetAccountsFactory(Provider)
        Protected Shared ReadOnly AccountsDao As IAccountsDao = AccountsFactory.AccountsDao

        'Protected Shared ReadOnly ApJournalDao As IDaoAll(Of ApJournal) = AccountsFactory.ApJournalDao
        'Protected Shared ReadOnly ApJournalItemDao As IDaoJournalItems(Of ApJournalItem) = AccountsFactory.ApJournalItemDao

        'Protected Shared ReadOnly ApOpenInvoiceDao As IDaoChild(Of ApOpenInvoice) = AccountsFactory.ApOpenInvoiceDao

        Public ReadOnly Property AccountsDaoProp
            Get
                Return AccountsDao
            End Get
        End Property

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            Return GetAccountsDao().UpdateGlReferenceNumber(model)
        End Function

        Public Overrides Function GetBaseDao() As Object
            Return GetAccountsDao()
        End Function

        Public Overridable Function GetAccountsDao()
            Return CommonDaoProp
        End Function

    End Class

    Public Class ServiceCategory
        Inherits ServiceAccounts

        Protected Shared ReadOnly CategoryDao As IDaoAll(Of Category) = AccountsFactory.CategoryDao

        Public Overrides Function GetDao()
            Return CategoryDao
        End Function

    End Class

    Public Class ServiceEmployee
        Inherits ServiceAccounts

        Protected Shared ReadOnly EmployeeDao As IDaoAll(Of Employee) = AccountsFactory.EmployeeDao

        Public Overrides Function GetDao()
            Return EmployeeDao
        End Function

    End Class

    Public Class ServiceApJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApJournalDao As IDao(Of ApJournal) = AccountsFactory.ApJournalDao

        Public Overrides Function GetDao()
            Return ApJournalDao
        End Function

    End Class

    Public Class ServiceGeneralJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly GeneralJournalDao As IDao(Of GeneralJournal) = AccountsFactory.GeneralJournalDao

        Public Overrides Function GetAccountsDao()
            Return GeneralJournalDao
        End Function

    End Class

    Public Class ServiceJournalItem
        Inherits ServiceAccounts

        Protected Shared ReadOnly JournalItemDao As IDaoJournalItems(Of JournalItem) = AccountsFactory.ApJournalItemDao

        Public Overrides Function GetDao()
            Return JournalItemDao
        End Function

    End Class

    Public Class ServiceApJournalItems
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApJournalItemDao As IDaoJournalItems(Of JournalItem) = AccountsFactory.ApJournalItemDao

        Public Overrides Function GetDao()
            Return ApJournalItemDao
        End Function

    End Class

    Public Class ServiceGeneralJournalItem
        Inherits ServiceAccounts

        Protected Shared ReadOnly GeneralJournalItemDao As IDaoJournalItems(Of JournalItem) = AccountsFactory.GeneralJournalItemDao

        Public Overrides Function GetDao()
            Return GeneralJournalItemDao
        End Function

    End Class

    Public Class ServiceApOpenInvoice
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApOpenInvoiceDao As IDaoChild(Of ApOpenInvoice) = AccountsFactory.ApOpenInvoiceDao

        Public Overrides Function GetDao()
            Return ApOpenInvoiceDao
        End Function

    End Class

End Namespace