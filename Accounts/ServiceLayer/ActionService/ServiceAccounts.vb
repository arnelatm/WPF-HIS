Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Service As Object

        Protected Shared ReadOnly DaoFactoryAccountsFactory As IDaoFactoryAccounts = DaoFactoriesAccounts.GetAccountsFactory(Provider)

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateGlReferenceNumber(DataBo)
        End Function

        'Public Overrides Function GetBaseDao() As Object
        '    Return GetAccountsDao()
        'End Function

        'Public Overridable Function GetAccountsDao()
        '    Return CommonDaoProp
        'End Function

    End Class

    Public Class ServiceCategory
        Inherits ServiceAccounts

        Protected Shared ReadOnly CategoryDao As IDaoAll(Of Category) = DaoFactoryAccountsFactory.CategoryDao

        Public Sub New()
            DataBo = New Category()
            DataDao = CategoryDao
        End Sub

    End Class

    Public Class ServiceEmployee
        Inherits ServiceAccounts

        Protected Shared ReadOnly EmployeeDao As IDaoAll(Of Employee) = DaoFactoryAccountsFactory.EmployeeDao

        Public Sub New()
            DataBo = New Employee
            DataDao = EmployeeDao
        End Sub

    End Class

    Public Class ServiceApJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApJournalDao As IDao(Of ApJournal) = DaoFactoryAccountsFactory.ApJournalDao

        Public Sub New()
            DataBo = New ApJournal
            DataDao = ApJournalDao
        End Sub

    End Class

    Public Class ServiceArJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly ArJournalDao As IDao(Of ArJournal) = DaoFactoryAccountsFactory.ArJournalDao

        Public Sub New()
            DataBo = New ArJournal
            DataDao = ArJournalDao
        End Sub

    End Class

    Public Class ServiceGeneralJournal
        Inherits ServiceAccounts

        Protected Shared ReadOnly GeneralJournalDao As IDao(Of GeneralJournal) = DaoFactoryAccountsFactory.GeneralJournalDao

        Public Sub New()
            DataBo = New GeneralJournal
            DataDao = GeneralJournalDao
        End Sub

    End Class

    Public Class ServiceJournalItem
        Inherits ServiceAccounts

        Protected Shared ReadOnly JournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.ApJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = JournalItemDao
        End Sub

    End Class

    Public Class ServiceApJournalItems
        Inherits ServiceAccounts

        Protected Shared ReadOnly ApJournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.ApJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = ApJournalItemDao
        End Sub

    End Class

    Public Class ServiceArJournalItems
        Inherits ServiceAccounts

        Protected Shared ReadOnly ArJournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.ArJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = ArJournalItemDao
        End Sub

    End Class

    Public Class ServiceGeneralJournalItems
        Inherits ServiceAccounts

        Protected Shared ReadOnly GeneralJournalItemDao As IDaoJournalItems = DaoFactoryAccountsFactory.GeneralJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = GeneralJournalItemDao
        End Sub

    End Class

    Public MustInherit Class ServiceOpenInvoice
        Inherits ServiceAccounts
        Implements IOpenInvoiceService

        Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IOpenInvoiceService.AddInvoicePayment
            Return DataDao.AddInvoicePayment(idNo, amount, discountTaken)
        End Function

        Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
            Implements IOpenInvoiceService.RemoveInvoicePayment
            Return DataDao.RemoveInvoicePayment(idNo, amount, discountTaken)
        End Function

    End Class

    Public Class ServiceApOpenInvoice
        Inherits ServiceOpenInvoice
        Implements IOpenInvoiceService

        Public Sub New()
            DataDao = DaoFactoryAccountsFactory.ApOpenInvoiceDao
            DataBo = New ApOpenInvoice
        End Sub

    End Class

    Public Class ServiceArOpenInvoice
        Inherits ServiceOpenInvoice
        Implements IOpenInvoiceService

        Public Sub New()
            DataDao = DaoFactoryAccountsFactory.ArOpenInvoiceDao
            DataBo = New ArOpenInvoice
        End Sub

    End Class

End Namespace