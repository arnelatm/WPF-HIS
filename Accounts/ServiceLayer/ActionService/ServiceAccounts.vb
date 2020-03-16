Imports System.Reflection
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.BusinessLayer
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Service As Object

        Private Shared ReadOnly DaoFactoryAccounts As IDaoFactoryAccounts = DaoFactoriesAccounts.GetAccountsFactory(Provider)
        Private Shared ReadOnly CategoryDao As IDaoAll(Of Category) = DaoFactoryAccounts.CategoryDao

        Public Sub New(bObject As String, dao As String)
            Dim bizObject = $"AATM.Accounts.BusinessLayer." + bObject
            Dim daoOName = $"AATM.Accounts.DataLayer." + dao
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            DataDao = fldInfo.GetValue(Me)
        End Sub

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateGlReferenceNumber(DataBo)
        End Function

    End Class

    Public Class ServiceCategory
        Inherits ServiceAccounts

        Protected ReadOnly CategoryDao As IDaoAll(Of Category) = AdoNet.DaoFactoryAccounts.CategoryDao

        Public Sub New()
            DataBo = New Category()
            DataDao = CategoryDao
        End Sub

    End Class

    Public Class ServiceEmployee
        Inherits ServiceAccounts

        Protected ReadOnly EmployeeDao As IDaoAll(Of Employee) = AdoNet.DaoFactoryAccounts.EmployeeDao

        Public Sub New()
            DataBo = New Employee
            DataDao = EmployeeDao
        End Sub

    End Class

    Public Class ServiceChart
        Inherits ServiceAccounts

        Protected ReadOnly ChartDao As IDaoAll(Of Chart) = AdoNet.DaoFactoryAccounts.ChartDao

        Public Sub New()
            DataBo = New Chart
            DataDao = ChartDao
        End Sub

    End Class

    Public Class ServiceCustomer
        Inherits ServiceAccounts

        Protected ReadOnly CustomerDao As IDaoAll(Of Customer) = AdoNet.DaoFactoryAccounts.CustomerDao

        Public Sub New()
            DataBo = New Customer
            DataDao = CustomerDao
        End Sub

    End Class

    Public Class ServiceSupplier
        Inherits ServiceAccounts

        Protected ReadOnly SupplierDao As IDaoAll(Of Supplier) = AdoNet.DaoFactoryAccounts.SupplierDao

        Public Sub New()
            DataBo = New Supplier
            DataDao = SupplierDao
        End Sub

    End Class

    Public Class ServiceCashCode
        Inherits ServiceAccounts

        Protected ReadOnly CashCodeDao As IDaoAll(Of CashCode) = AdoNet.DaoFactoryAccounts.CashCodeDao

        Public Sub New()
            DataBo = New CashCode
            DataDao = CashCodeDao
        End Sub

    End Class

    Public Class ServicePurchaseItem
        Inherits ServiceAccounts

        Protected ReadOnly PurchaseItemDao As IDaoChild(Of PurchaseItem) = AdoNet.DaoFactoryAccounts.PurchaseItemDao()

        Public Sub New()
            DataDao = PurchaseItemDao
            DataBo = New PurchaseItem
        End Sub

    End Class

    Public Class ServiceApJournal
        Inherits ServiceAccounts

        Protected ReadOnly ApJournalDao As IDao(Of ApJournal) = AdoNet.DaoFactoryAccounts.ApJournalDao

        Public Sub New()
            DataBo = New ApJournal
            DataDao = ApJournalDao
        End Sub

    End Class

    Public Class ServiceArJournal
        Inherits ServiceAccounts

        Protected ReadOnly ArJournalDao As IDao(Of ArJournal) = AdoNet.DaoFactoryAccounts.ArJournalDao

        Public Sub New()
            DataBo = New ArJournal
            DataDao = ArJournalDao
        End Sub

    End Class

    Public Class ServiceGeneralJournal
        Inherits ServiceAccounts

        Protected ReadOnly GeneralJournalDao As IDao(Of GeneralJournal) = AdoNet.DaoFactoryAccounts.GeneralJournalDao

        Public Sub New()
            DataBo = New GeneralJournal
            DataDao = GeneralJournalDao
        End Sub

    End Class

    Public Class ServiceJournalItem
        Inherits ServiceAccounts

        Protected ReadOnly JournalItemDao As IDaoJournalItems = AdoNet.DaoFactoryAccounts.ApJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = JournalItemDao
        End Sub

    End Class

    Public Class ServiceApJournalItems
        Inherits ServiceAccounts

        Protected ReadOnly ApJournalItemDao As IDaoJournalItems = AdoNet.DaoFactoryAccounts.ApJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = ApJournalItemDao
        End Sub

    End Class

    Public Class ServiceArJournalItems
        Inherits ServiceAccounts

        Protected ReadOnly ArJournalItemDao As IDaoJournalItems = AdoNet.DaoFactoryAccounts.ArJournalItemDao

        Public Sub New()
            DataBo = New JournalItem
            DataDao = ArJournalItemDao
        End Sub

    End Class

    Public Class ServiceAccountReconciliationItem
        Inherits ServiceAccounts

        Protected ReadOnly AccountReconciliationItemDao As IDaoJournalItems = AdoNet.DaoFactoryAccounts.ArJournalItemDao

        Public Sub New()
            DataBo = New AccountReconciliationItem
            DataDao = AccountReconciliationItemDao
        End Sub

    End Class

    Public Class ServiceGeneralJournalItems
        Inherits ServiceAccounts

        Protected ReadOnly GeneralJournalItemDao As IDaoJournalItems = AdoNet.DaoFactoryAccounts.GeneralJournalItemDao

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
            DataDao = AdoNet.DaoFactoryAccounts.ApOpenInvoiceDao
            DataBo = New ApOpenInvoice
        End Sub

    End Class

    Public Class ServiceArOpenInvoice
        Inherits ServiceOpenInvoice
        Implements IOpenInvoiceService

        Public Sub New()
            DataDao = AdoNet.DaoFactoryAccounts.ArOpenInvoiceDao
            DataBo = New ArOpenInvoice
        End Sub

    End Class

    'Public Class ServiceDistributionScheme
    '    Inherits ServiceOpenInvoice
    '    Implements IOpenInvoiceService

    '    Protected Shared ReadOnly DistributionSchemeDao As IDaoAll(Of DistributionScheme) = DaoFactoryAccountsFactory.DistributionSchemeDao

    '    Public Sub New()
    '        DataDao = DaoFactoryAccountsFactory.DistributionSchemeDao
    '        DataBo = New DistributionScheme
    '    End Sub

    'End Class

    'Public Class ServiceDistributionSchemeItem
    '    Inherits ServiceOpenInvoice
    '    Implements IOpenInvoiceService

    '    Protected Shared ReadOnly DistributionSchemeDao As IDaoChild(Of DistributionSchemeItem) = DaoFactoryAccountsFactory.DistributionSchemeItemDao

    '    Public Sub New()
    '        DataDao = DaoFactoryAccountsFactory.DistributionSchemeItemDao
    '        DataBo = New DistributionSchemeItem
    '    End Sub

    'End Class

End Namespace