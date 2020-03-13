Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Service As Object

        Protected Shared ReadOnly DaoFactoryAccountsFactory As IDaoFactoryAccounts = DaoFactoriesAccounts.GetAccountsFactory(Provider)
        Protected Shared ReadOnly DaoAccounts As IDaoAccounts = DaoFactoryAccountsFactory.DaoAccounts

        'Protected Shared ReadOnly ApJournalDao As IDaoAll(Of ApJournal) = DaoFactoryAccountsFactory.ApJournalDao
        'Protected Shared ReadOnly ApJournalItemDao As IDaoJournalItems(Of ApJournalItem) = DaoFactoryAccountsFactory.ApJournalItemDao

        'Protected Shared ReadOnly ApOpenInvoiceDao As IDaoChild(Of ApOpenInvoice) = DaoFactoryAccountsFactory.ApOpenInvoiceDao

        Public ReadOnly Property DaoAccountsProp
            Get
                Return DaoAccounts
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

        Protected Shared ReadOnly CategoryDao As IDaoAll(Of Category) = DaoFactoryAccountsFactory.CategoryDao

        Public Overrides Function GetDao()
            Return CategoryDao
        End Function

    End Class

    Public Class ServiceEmployee
        Inherits ServiceAccounts

        Protected Shared ReadOnly EmployeeDao As IDaoAll(Of Employee) = DaoFactoryAccountsFactory.EmployeeDao

        Public Overrides Function GetDao()
            Return EmployeeDao
        End Function

    End Class

    Public Class ServiceApJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApJournalDao As IDao(Of ApJournal) = DaoFactoryAccountsFactory.ApJournalDao

        Public Overrides Function GetDao()
            Return ApJournalDao
        End Function

    End Class

    Public Class ServiceGeneralJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly GeneralJournalDao As IDao(Of GeneralJournal) = DaoFactoryAccountsFactory.GeneralJournalDao

        Public Overrides Function GetAccountsDao()
            Return GeneralJournalDao
        End Function

    End Class

    Public Class ServiceJournalItem
        Inherits ServiceAccounts

        Protected Shared ReadOnly JournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.ApJournalItemDao

        Public Overrides Function GetDao()
            Return JournalItemDao
        End Function

    End Class

    Public Class ServiceApJournalItems
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApJournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.ApJournalItemDao

        Public Overrides Function GetDao()
            Return ApJournalItemDao
        End Function

    End Class

    Public Class ServiceGeneralJournalItem
        Inherits ServiceAccounts

        Protected Shared ReadOnly GeneralJournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.GeneralJournalItemDao

        Public Overrides Function GetDao()
            Return GeneralJournalItemDao
        End Function

    End Class

    Public MustInherit Class ServiceOpenInvoice
        Inherits ServiceAccounts
        Implements IOpenInvoiceService

        Protected Property OpenInvoiceDao

        Public Overrides Function GetDao()
            Return OpenInvoiceDao
        End Function

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IOpenInvoiceService.AddInvoicePayment
            Return OpenInvoiceDao.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IOpenInvoiceService.RemoveInvoicePayment
            Return OpenInvoiceDao.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

    End Class

    Public Class ServiceApOpenInvoice
        Inherits ServiceOpenInvoice
        Implements IOpenInvoiceService

        Public Sub New()
            OpenInvoiceDao = DaoFactoryAccountsFactory.ApOpenInvoiceDao
        End Sub

    End Class

    Public Class ServiceArOpenInvoice
        Inherits ServiceOpenInvoice
        Implements IOpenInvoiceService

        Public Sub New()
            OpenInvoiceDao = DaoFactoryAccountsFactory.ArOpenInvoiceDao
        End Sub

    End Class

End Namespace