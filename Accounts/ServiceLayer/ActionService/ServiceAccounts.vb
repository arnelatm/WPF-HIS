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

        Protected Shared ReadOnly DaoFactoryAccounts As IDaoFactoryAccounts = DaoFactoriesAccounts.GetAccountsFactory(Provider)
        Private ReadOnly _categoryDao As IDaoAll(Of Category) = DaoFactoryAccounts.CategoryDao
        Private ReadOnly _employeeDao As IDaoAll(Of Employee) = DaoFactoryAccounts.EmployeeDao
        Private ReadOnly _chartDao As IDaoAll(Of Chart) = DaoFactoryAccounts.ChartDao
        Private ReadOnly _customerDao As IDaoAll(Of Customer) = DaoFactoryAccounts.CustomerDao
        Private ReadOnly _supplierDao As IDaoAll(Of Supplier) = DaoFactoryAccounts.SupplierDao
        Private ReadOnly _cashCodeDao As IDaoAll(Of CashCode) = DaoFactoryAccounts.CashCodeDao
        Private ReadOnly _purchaseItemDao As IDaoChild(Of PurchaseItem) = DaoFactoryAccounts.PurchaseItemDao()
        Private ReadOnly _apJournalDao As IDao(Of ApJournal) = DaoFactoryAccounts.ApJournalDao
        Private ReadOnly _arJournalDao As IDao(Of ArJournal) = DaoFactoryAccounts.ArJournalDao
        Private ReadOnly _generalJournalDao As IDao(Of GeneralJournal) = DaoFactoryAccounts.GeneralJournalDao
        Private ReadOnly _journalItemDao As IDaoJournalItems = DaoFactoryAccounts.ApJournalItemDao
        Private ReadOnly _apJournalItemDao As IDaoJournalItems = DaoFactoryAccounts.ApJournalItemDao
        Private ReadOnly _arJournalItemDao As IDaoJournalItems = DaoFactoryAccounts.ArJournalItemDao
        Private ReadOnly _accountReconciliationItemDao As IDaoJournalItems = DaoFactoryAccounts.ArJournalItemDao
        Private ReadOnly _generalJournalItemDao As IDaoJournalItems = DaoFactoryAccounts.GeneralJournalItemDao
        Private ReadOnly _distributionSchemeDao As IDaoAll(Of DistributionScheme) = DaoFactoryAccounts.DistributionSchemeDao
        Private ReadOnly _distributionSchemeItemDao As IDaoChild(Of DistributionSchemeItem) = DaoFactoryAccounts.DistributionSchemeItemDao

        Public Sub New(accountName As String)
            Dim bizObject = $"AATM.Accounts.BusinessLayer." + accountName
            Dim dao = "_" + Strings.Left(accountName, 1).ToLower() + Strings.Mid(accountName, 2) + "Dao"
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
            End If
            Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            If fldInfo Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + dao)
            End If
            DataDao = fldInfo.GetValue(Me)
        End Sub

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateGlReferenceNumber(DataBo)
        End Function

    End Class

    'Public MustInherit Class ServiceOpenInvoice
    '    Inherits ServiceAccounts
    '    Implements IOpenInvoiceService

    '    Public Function AddInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
    '        Implements IOpenInvoiceService.AddInvoicePayment
    '        Return DataDao.AddInvoicePayment(idNo, amount, discountTaken)
    '    End Function

    '    Public Function RemoveInvoicePayment(ByVal idNo As Integer, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
    '        Implements IOpenInvoiceService.RemoveInvoicePayment
    '        Return DataDao.RemoveInvoicePayment(idNo, amount, discountTaken)
    '    End Function

    'End Class

    'Public Class ServiceApOpenInvoice
    '    Inherits ServiceOpenInvoice
    '    Implements IOpenInvoiceService

    '    Public Sub New()
    '        DataDao = AdoNet.DaoFactoryAccounts.ApOpenInvoiceDao
    '        DataBo = New ApOpenInvoice
    '    End Sub

    'End Class

    'Public Class ServiceArOpenInvoice
    '    Inherits ServiceOpenInvoice
    '    Implements IOpenInvoiceService

    '    Public Sub New()
    '        DataDao = AdoNet.DaoFactoryAccounts.ArOpenInvoiceDao
    '        DataBo = New ArOpenInvoice
    '    End Sub

    'End Class

End Namespace