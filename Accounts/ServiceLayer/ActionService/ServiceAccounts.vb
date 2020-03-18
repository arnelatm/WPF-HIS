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
        Private ReadOnly _accountReconciliationItemDao As IDaoChild(Of JournalItem) = DaoFactoryAccounts.CreateDao("ArJournalItem")

        Private ReadOnly _apJournalDao                  As IDao(Of ApJournal) = DaoFactoryAccounts.CreateDao("ApJournal")
        Private ReadOnly _arJournalDao                  As IDao(Of ArJournal) = DaoFactoryAccounts.CreateDao("ArJournal")
        Private ReadOnly _cashDisbursementJournalDao    As IDao(Of CashDisbursementJournal) = DaoFactoryAccounts.CreateDao("CashDisbursementJournal")
        Private ReadOnly _cashReceiptJournalDao         As IDao(Of CashReceiptJournal) = DaoFactoryAccounts.CreateDao("CashReceiptJournal")
        Private ReadOnly _checkDisbursementJournalDao   As IDao(Of CheckDisbursementJournal) = DaoFactoryAccounts.CreateDao("CheckDisbursementJournal")
        Private ReadOnly _generalJournalDao             As IDao(Of GeneralJournal) = DaoFactoryAccounts.CreateDao("GeneralJournal")
        Private ReadOnly _pettyCashJournalDao           As IDao(Of PettyCashJournal) = DaoFactoryAccounts.CreateDao("PettyCashJournal")
        Private ReadOnly _salesJournalDao               As IDao(Of SalesJournal) = DaoFactoryAccounts.CreateDao("SalesJournal")

        Private ReadOnly _bankDao               As IDaoAll(Of Bank) = DaoFactoryAccounts.CreateDao("Bank")
        Private ReadOnly _cashCodeDao           As IDaoAll(Of CashCode) = DaoFactoryAccounts.CreateDao("CashCode")
        Private ReadOnly _categoryDao           As IDaoAll(Of Category) = DaoFactoryAccounts.CreateDao("Category")
        Private ReadOnly _chartDao              As IDaoAll(Of Chart) = DaoFactoryAccounts.CreateDao("Chart")
        Private ReadOnly _customerDao           As IDaoAll(Of Customer) = DaoFactoryAccounts.CreateDao("Customer")
        Private ReadOnly _supplierDao           As IDaoAll(Of Supplier) = DaoFactoryAccounts.CreateDao("Supplier")
        Private ReadOnly _distributionSchemeDao As IDaoAll(Of DistributionScheme) = DaoFactoryAccounts.CreateDao("DistributionScheme")
        Private ReadOnly _employeeDao           As IDaoAll(Of Employee) = DaoFactoryAccounts.CreateDao("Employee")
        Private ReadOnly _purchaseItemDao       As IDaoAll(Of PurchaseItem) = DaoFactoryAccounts.CreateDao("PurchaseItem")
        Private ReadOnly _designationDao        As IDaoAll(Of Designation) = DaoFactoryAccounts.CreateDao("Designation")

        Private ReadOnly _distributionSchemeItemDao As IDaoChild(Of DistributionSchemeItem) = DaoFactoryAccounts.CreateDao("DistributionSchemeItem")
        Private ReadOnly _apJournalItemDao          As IDaoChild(Of JournalItem) = DaoFactoryAccounts.CreateDao("ApJournalItem")
        Private ReadOnly _arJournalItemDao          As IDaoChild(Of JournalItem) = DaoFactoryAccounts.CreateDao("ArJournalItem")
        Private ReadOnly _generalJournalItemDao     As IDaoChild(Of JournalItem) = DaoFactoryAccounts.CreateDao("GeneralJournalItem")
        Private ReadOnly _journalItemDao            As IDaoChild(Of JournalItem) = DaoFactoryAccounts.CreateDao("ApJournalItem")
        Private ReadOnly _cadOiItemDao              As IDaoChild(Of cadOiItem) = DaoFactoryAccounts.CreateDao("CadOiItem")
        Private ReadOnly _csrOiItemDao              As IDaoChild(Of csrOiItem) = DaoFactoryAccounts.CreateDao("CsrOiItem")
        Private ReadOnly _ckdOiItemDao              As IDaoChild(Of ckdOiItem) = DaoFactoryAccounts.CreateDao("CkdOiItem")
        Private ReadOnly _pcsOiItemDao              As IDaoChild(Of PcsOiItem) = DaoFactoryAccounts.CreateDao("PcsOiItem")
        Private ReadOnly _salesCashItemDao          As IDaoChild(Of SalesCashItem) = DaoFactoryAccounts.CreateDao("SalesCashItem")


        Private ReadOnly _apOpenInvoiceDao As IDaoOpenInvoice(Of ApOpenInvoice) = DaoFactoryAccounts.CreateDao("ApOpenInvoice")
        Private ReadOnly _arOpenInvoiceDao As IDaoOpenInvoice(Of ArOpenInvoice) = DaoFactoryAccounts.CreateDao("ArOpenInvoice")

        Public Sub New(accountName As String)
            Dim bizObject = $"AATM.Accounts.BusinessLayer." + accountName
            Dim dao = "_" + Strings.Left(accountName, 1).ToLower() + Strings.Mid(accountName, 2) + "Dao"
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
                Debugger.Break
            End If
            Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            If fldInfo Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + dao)
                Debugger.Break
            End If
            DataDao = fldInfo.GetValue(Me)
        End Sub

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer Implements IServiceAccounts.UpdateGlReferenceNumber
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateGlReferenceNumber(DataBo)
        End Function

        Public Function AddInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Object Implements IServiceAccounts.AddInvoicePayment
            Return DataDao.AddInvoicePayment(idNo, amount, discountTaken)
        End Function


        Public Function GetCustomerOpenInvoices(Of TM)(idNo As Integer) As List(Of TM) Implements IServiceAccounts.GetCustomerOpenInvoices
            Dim records = DataDao.GetCustomerOpenInvoices(idNo)
            Dim bizObj as New List(Of TM)
            GlobalVariables.Mapper.Map(records, bizObj)
            Return bizObj
        End Function

        Public Function GetSupplierOpenInvoices(Of TM)(idNo As Integer) As List(Of TM) Implements IServiceAccounts.GetSupplierOpenInvoices
            Dim records = DataDao.GetSupplierOpenInvoices(idNo)
            Dim bizObj as New List(Of TM)
            GlobalVariables.Mapper.Map(records, bizObj)
            Return bizObj
        End Function

        Public Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem) Implements IServiceAccounts.GetAcctReconItems
            Throw New NotImplementedException()
        End Function

        Public Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Integer, Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItem) Implements IServiceAccounts.GetReconciledRecordsWithIdNo
            Throw New NotImplementedException()
        End Function

        Public Function RemoveInvoicePayment(idNo As Integer, amount As Decimal, discountTaken As Decimal) As Object Implements IServiceAccounts.RemoveInvoicePayment
            Throw New NotImplementedException()
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