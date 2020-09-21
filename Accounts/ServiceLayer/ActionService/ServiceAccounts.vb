Imports System.Reflection
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer.ActionService

    Public Class ServiceAccounts
        Inherits ServiceCommon
        Implements IServiceAccounts

        Protected Shared ReadOnly _
            DaoFactoryAccounts As IDaoFactoryAccounts = DaoFactoriesAccounts.GetAccountsFactory(Provider)

        Protected Service As Object

        Public Sub New(accountName As String)
            Dim bizObject
            If accountName.Length > 11 AndAlso accountName.Right(11) = "JournalItem" Then
                bizObject = $"AATM.Accounts.BusinessLayer.JournalItem"
            Else
                bizObject = $"AATM.Accounts.BusinessLayer." + accountName
            End If
            Dim dao = accountName + "Dao"
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            'DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
                Debugger.Break()
            End If
            'Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            'If fldInfo Is Nothing Then
            '    MessageBox.Show("Missing Data Access Object " + dao)
            '    Debugger.Break()
            'End If
            DataDao = Me.GetType().GetProperty(dao, BindingFlags.NonPublic Or BindingFlags.Instance).GetValue(Me)
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + dao)
                Debugger.Break()
            End If
            'DataDao = Me.GetType().GetProperty(dao).GetValue(me)
            'Dim bizObject = $"AATM.Accounts.BusinessLayer." + accountName
            'Dim dao = "_" + Strings.Left(accountName, 1).ToLower() + Strings.Mid(accountName, 2) + "Dao"
            'DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            'DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            'If DataBo Is Nothing Then
            '    MessageBox.Show("Missing Business Object " + bizObject)
            '    Debugger.Break()
            'End If
            'Dim fldInfo As FieldInfo = Me.GetType().GetField(dao, BindingFlags.NonPublic Or BindingFlags.Instance)
            'If fldInfo Is Nothing Then
            '    MessageBox.Show("Missing Data Access Object " + dao)
            '    Debugger.Break()
            'End If
            'DataDao = fldInfo.GetValue(Me)
        End Sub

        Private ReadOnly Property AccountReconciliationDao As IDao(Of AccountReconciliation)
            Get
                Return DaoFactoryAccounts.CreateDao("AccountReconciliation")
            End Get
        End Property

        Private ReadOnly Property ApJournalDao As IDao(Of ApJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("ApJournal")
            End Get
        End Property

        Private ReadOnly Property ApJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("ApJournalItem")
            End Get
        End Property

        Private ReadOnly Property ApOpenInvoiceDao As IDaoOpenInvoice(Of ApOpenInvoice)
            Get
                Return DaoFactoryAccounts.CreateDao("ApOpenInvoice")
            End Get
        End Property

        Private ReadOnly Property ArJournalDao As IDao(Of ArJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("ArJournal")
            End Get
        End Property

        Private ReadOnly Property ArJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("ArJournalItem")
            End Get
        End Property

        Private ReadOnly Property ArOpenInvoiceDao As IDaoOpenInvoice(Of ArOpenInvoice)
            Get
                Return DaoFactoryAccounts.CreateDao("ArOpenInvoice")
            End Get
        End Property

        Private ReadOnly Property BankDao As IDaoAll(Of Bank)
            Get
                Return DaoFactoryAccounts.CreateDao("Bank")
            End Get
        End Property

        Private ReadOnly Property CadOiItemDao As IDaoChild(Of CadOiItem)
            Get
                Return DaoFactoryAccounts.CreateDao("CadOiItem")
            End Get
        End Property

        Private ReadOnly Property CashCodeDao As IDaoAll(Of CashCode)
            Get
                Return DaoFactoryAccounts.CreateDao("CashCode")
            End Get
        End Property

        Private ReadOnly Property CashDisbursementJournalDao As IDao(Of CashDisbursementJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("CashDisbursementJournal")
            End Get
        End Property

        Private ReadOnly Property CashDisbursementJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("CashDisbursementJournalItem")
            End Get
        End Property

        Private ReadOnly Property CashReceiptJournalDao As IDao(Of CashReceiptJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("CashReceiptJournal")
            End Get
        End Property

        Private ReadOnly Property CashReceiptJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("CashReceiptJournalItem")
            End Get
        End Property

        Private ReadOnly Property ChartDao As IDaoAll(Of Chart)
            Get
                Return DaoFactoryAccounts.CreateDao("Chart")
            End Get
        End Property

        Private ReadOnly Property CheckDisbursementJournalDao As IDao(Of CheckDisbursementJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("CheckDisbursementJournal")
            End Get
        End Property

        Private ReadOnly Property CheckDisbursementJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("CheckDisbursementJournalItem")
            End Get
        End Property

        Private ReadOnly Property CkdOiItemDao As IDaoChild(Of CkdOiItem)
            Get
                Return DaoFactoryAccounts.CreateDao("CkdOiItem")
            End Get
        End Property

        Private ReadOnly Property CsrOiItemDao As IDaoChild(Of CsrOiItem)
            Get
                Return DaoFactoryAccounts.CreateDao("CsrOiItem")
            End Get
        End Property

        Private ReadOnly Property CustomerDao As IDaoAll(Of Customer)
            Get
                Return DaoFactoryAccounts.CreateDao("Customer")
            End Get
        End Property

        Private ReadOnly Property DeductionDao As IDaoAll(Of Deduction)
            Get
                Return DaoFactoryAccounts.CreateDao("Deduction")
            End Get
        End Property

        Private ReadOnly Property DesignationDao As IDaoAll(Of Designation)
            Get
                Return DaoFactoryAccounts.CreateDao("Designation")
            End Get
        End Property

        Private ReadOnly Property DistributionSchemeDao As IDaoAll(Of DistributionScheme)
            Get
                Return DaoFactoryAccounts.CreateDao("DistributionScheme")
            End Get
        End Property

        Private ReadOnly Property DistributionSchemeItemDao As IDaoChild(Of DistributionSchemeItem)
            Get
                Return DaoFactoryAccounts.CreateDao("DistributionSchemeItem")
            End Get
        End Property

        Private ReadOnly Property EmployeeDao As IDaoAll(Of Employee)
            Get
                Return DaoFactoryAccounts.CreateDao("Employee")
            End Get
        End Property

        Private ReadOnly Property EmployeeDeductionDao As IDaoChild(Of EmployeeDeduction)
            Get
                Return DaoFactoryAccounts.CreateDao("EmployeeDeduction")
            End Get
        End Property

        Private ReadOnly Property EmployeeEarningDao As IDaoChild(Of EmployeeEarning)
            Get
                Return DaoFactoryAccounts.CreateDao("EmployeeEarning")
            End Get
        End Property

        Private ReadOnly Property ErJournalDao As IDao(Of ErJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("ErJournal")
            End Get
        End Property

        'Private ReadOnly Property AccountReconciliationItemDao As IDaoChild(Of AccountReconciliationItem)
        '    Get
        '        Return DaoFactoryAccounts.CreateDao("AccountReconciliationItem")
        '    End Get
        'End Property
        Private ReadOnly Property ErJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("ErJournalItem")
            End Get
        End Property

        Private ReadOnly Property EarningDao As IDaoAll(Of Earning)
            Get
                Return DaoFactoryAccounts.CreateDao("Earning")
            End Get
        End Property

        Private ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("GeneralJournal")
            End Get
        End Property

        Private ReadOnly Property GeneralJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("GeneralJournalItem")
            End Get
        End Property

        Private ReadOnly Property JournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("ApJournalItem")
            End Get
        End Property

        Private ReadOnly Property PcsOiItemDao As IDaoChild(Of PcsOiItem)
            Get
                Return DaoFactoryAccounts.CreateDao("PcsOiItem")
            End Get
        End Property

        Private ReadOnly Property PettyCashJournalDao As IDao(Of PettyCashJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("PettyCashJournal")
            End Get
        End Property

        Private ReadOnly Property PettyCashJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("PettyCashJournalItem")
            End Get
        End Property

        Private ReadOnly Property ProductCategoryDao As IDaoAll(Of ProductCategory)
            Get
                Return DaoFactoryAccounts.CreateDao("ProductCategory")
            End Get
        End Property

        Private ReadOnly Property PurchaseItemDao As IDaoAll(Of PurchaseItem)
            Get
                Return DaoFactoryAccounts.CreateDao("PurchaseItem")
            End Get
        End Property

        Private ReadOnly Property ReconciledDao As IDaoChild(Of Reconciled)
            Get
                Return DaoFactoryAccounts.CreateDao("Reconciled")
            End Get
        End Property

        Private ReadOnly Property SalesCashItemDao As IDaoChild(Of SalesCashItem)
            Get
                Return DaoFactoryAccounts.CreateDao("SalesCashItem")
            End Get
        End Property

        Private ReadOnly Property SalesJournalDao As IDao(Of SalesJournal)
            Get
                Return DaoFactoryAccounts.CreateDao("SalesJournal")
            End Get
        End Property

        Private ReadOnly Property SalesJournalItemDao As IDaoChild(Of JournalItem)
            Get
                Return DaoFactoryAccounts.CreateDao("SalesJournalItem")
            End Get
        End Property

        Private ReadOnly Property SupplierDao As IDaoAll(Of Supplier)
            Get
                Return DaoFactoryAccounts.CreateDao("Supplier")
            End Get
        End Property

        Public Function GetAcctReconItems(Of TM)(AccountIdNo As Int16, reconciliationDate As Date,
                                                  Optional sortOrder As String = Nothing) As List(Of TM) _
            Implements IServiceAccounts.GetAcctReconItems
            Dim records = DataDao.GetAcctReconItems(accountIdNo, reconciliationDate, sortOrder)
            Dim model As New List(Of TM)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetOpenInvoices(Of TM)(idNo As Int32) As List(Of TM) _
            Implements IServiceAccounts.GetOpenInvoices
            Dim records = DataDao.GetOpenInvoices(idNo)
            Dim model As New List(Of TM)
            GlobalVariables.Mapper.Map(records, model)
            Return model
        End Function

        Public Function GetReconciledRecordsWithIdNo(Of TM)(reconciled As Boolean, idNo As Int32,
                                                             Optional sortOrder As String = Nothing) As List(Of TM) _
            Implements IServiceAccounts.GetReconciledRecordsWithIdNo
            Return DataDao.GetReconciledRecordsWithIdNo(Of TM)(reconciled, idNo, sortOrder)
        End Function

        Public Function UpdateGlReferenceNumber(Of TM)(ByRef model As TM) As Integer _
                                    Implements IServiceAccounts.UpdateGlReferenceNumber
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateGlReferenceNumber(DataBo)
        End Function

        Public Function UpdateOpeningBalance(Of TM)(ByRef model As TM) As Integer _
            Implements IServiceAccounts.UpdateOpeningBalance
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateOpeningBalance(DataBo)
        End Function

        'Public Function AddInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Object Implements IServiceAccounts.AddInvoicePayment
        '    Return DataDao.AddInvoicePayment(idNo, amount, discountTaken)
        'End Function

        'Public Function GetCustomerOpenInvoices(Of TM)(idNo As Int32) As List(Of TM) Implements IServiceAccounts.GetCustomerOpenInvoices
        '    Dim records = DataDao.GetCustomerOpenInvoices(idNo)
        '    Dim model As New List(Of TM)
        '    GlobalVariables.Mapper.Map(records, model)
        '    Return model
        'End Function
        'Public Function RemoveInvoicePayment(idNo As Int32, amount As Decimal, discountTaken As Decimal) As Object Implements IServiceAccounts.RemoveInvoicePayment
        '    Return DataDao.RemoveInvoicePayment(idNo, amount, discountTaken)
        'End Function
    End Class

    'Public MustInherit Class ServiceOpenInvoice
    '    Inherits ServiceAccounts
    '    Implements IOpenInvoiceService

    '    Public  AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
    '        Implements IOpenInvoiceService.AddInvoicePayment
    '        Return DataDao.AddInvoicePayment(idNo, amount, discountTaken)
    '    End Function

    '    Public Function RemoveInvoiceCollection(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) _
    '        Implements IOpenInvoiceService.RemoveInvoiceCollection
    '        Return DataDao.RemoveInvoiceCollection(idNo, amount, discountTaken)
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