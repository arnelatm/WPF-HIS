Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AutoMapper

Public Class MappingProfileAccounts
    Inherits Profile

    Public Sub New()
        CreateMap(Of Account, AccountModel)().ReverseMap()
        CreateMap(Of AccountModel, IAccountView)().ReverseMap()
        CreateMap(Of AccountReconciliation, AccountReconciliationModel)().ReverseMap()
        CreateMap(Of AccountReconciliationItem, AccountReconciliationItemModel)().ReverseMap()
        CreateMap(Of AccountReconciliationItemModel, AccountReconciliationItemView)().ReverseMap()
        CreateMap(Of AccountReconciliationModel, IAccountReconciliationView)().ReverseMap()
        CreateMap(Of ApJournal, ApJournalModel)().ReverseMap()
        CreateMap(Of ApJournalModel, IApJournalView)().ReverseMap()
        CreateMap(Of ApOpenInvoice, ApOpenInvoiceModel)().ReverseMap()
        CreateMap(Of ArJournal, ArJournalModel)().ReverseMap()
        CreateMap(Of ArJournalModel, IArJournalView)().ReverseMap()
        CreateMap(Of ArOpenInvoice, ArOpenInvoiceModel)().ReverseMap()
        CreateMap(Of AttendanceItem, AttendanceItemModel)().ReverseMap()
        CreateMap(Of AttendanceItemModel, AttendanceItemView)().ReverseMap()
        CreateMap(Of Bank, BankModel)().ReverseMap()
        CreateMap(Of BankModel, IBankView)().ReverseMap()
        CreateMap(Of Basic, BasicModel)().ReverseMap()
        CreateMap(Of BasicModel, IBasicView)().ReverseMap()
        CreateMap(Of CashReceiptJournal, CashReceiptJournalModel)().ReverseMap()
        CreateMap(Of CashReceiptJournalModel, ICashReceiptJournalView)().ReverseMap()
        CreateMap(Of IPettyCashClosingView, PettyCashClosingModel)().ReverseMap()
        CreateMap(Of PettyCashClosing, PettyCashClosingModel)().ReverseMap()
        CreateMap(Of CsrOiItem, CsrOiItemModel)().ReverseMap()
        CreateMap(Of CsrOiItemModel, CsrOiItemView)().ReverseMap()
        CreateMap(Of Customer, CustomerModel)().ReverseMap()
        CreateMap(Of CustomerModel, ICustomerView)().ReverseMap()
        CreateMap(Of Deduction, DeductionModel)().ReverseMap()
        CreateMap(Of DeductionModel, IDeductionView)().ReverseMap()
        CreateMap(Of DepositType, DepositTypeModel)().ReverseMap()
        CreateMap(Of DepositTypeModel, IDepositTypeView)().ReverseMap()
        CreateMap(Of Designation, DesignationModel)().ReverseMap()
        CreateMap(Of DesignationModel, IDesignationView)().ReverseMap()
        CreateMap(Of DisbursementJournal, DisbursementJournalModel)().ReverseMap()
        CreateMap(Of DisbursementJournalModel, IDisbursementJournalView)().ReverseMap()
        CreateMap(Of DistributionScheme, DistributionSchemeModel)().ReverseMap()
        CreateMap(Of DistributionSchemeItem, DistributionSchemeItemModel)().ReverseMap()
        CreateMap(Of DistributionSchemeItemModel, IDistributionSchemeItemView)().ReverseMap()
        CreateMap(Of DistributionSchemeModel, IDistributionSchemeView)().ReverseMap()
        CreateMap(Of DjOiItem, DjOiItemModel)().ReverseMap()
        CreateMap(Of DjOiItem, DjOiItemModel)().ReverseMap()
        CreateMap(Of DjOiItemModel, DjOiItemView)().ReverseMap()
        CreateMap(Of DjOiItemModel, DjOiItemView)().ReverseMap()
        CreateMap(Of Earning, EarningModel)().ReverseMap()
        CreateMap(Of EarningModel, IEarningView)().ReverseMap()
        CreateMap(Of Employee, EmployeeModel)().ReverseMap()
        CreateMap(Of EmployeeDeduction, EmployeeDeductionModel)().ReverseMap()
        CreateMap(Of EmployeeDeductionModel, EmployeeDeductionView)().ReverseMap()
        CreateMap(Of EmployeeDeductionModel, IEmployeeDeductionView)().ReverseMap()
        CreateMap(Of EmployeeEarning, EmployeeEarningModel)().ReverseMap()
        CreateMap(Of EmployeeEarningModel, EmployeeEarningView)().ReverseMap()
        CreateMap(Of EmployeeEarningModel, IEmployeeEarningView)().ReverseMap()
        CreateMap(Of EmployeeModel, IEmployeeView)().ReverseMap()
        CreateMap(Of IEmployeePhoneView, EmployeePhoneModel)()
        CreateMap(Of EmployeePhone, EmployeePhoneModel)().ReverseMap()
        CreateMap(Of EmployeePhoneModel, EmployeePhoneView)()
        CreateMap(Of ErJournal, ErJournalModel)().ReverseMap()
        CreateMap(Of ErJournalModel, IErJournalView)().ReverseMap()
        CreateMap(Of GeneralJournal, GeneralJournalModel)().ReverseMap()
        CreateMap(Of GeneralJournalModel, IGeneralJournalView)().ReverseMap()
        CreateMap(Of JournalItem, JournalItemModel)().ReverseMap()
        CreateMap(Of JournalItemModel, IJournalItemView)().ReverseMap()
        CreateMap(Of Leave, LeaveModel)().ReverseMap()
        CreateMap(Of LeaveModel, ILeaveView).ReverseMap()
        CreateMap(Of PayCycle, PayCycleModel)().ReverseMap()
        CreateMap(Of PayCycleModel, IPayCycleView).ReverseMap()
        CreateMap(Of PayGroup, PayGroupModel)().ReverseMap()
        CreateMap(Of PayGroupModel, IPayGroupView).ReverseMap()
        CreateMap(Of Payroll, PayrollModel)().ReverseMap()
        CreateMap(Of PayrollModel, IPayrollView).ReverseMap()
        CreateMap(Of IPayrollDeductAccountView, PayrollDeductAccountModel)()
        CreateMap(Of PayrollDeductAccount, PayrollDeductAccountModel)().ReverseMap()
        CreateMap(Of PayrollDeductAccountModel, PayrollDeductAccountView)()
        CreateMap(Of IPayrollEarnAccountView, PayrollEarnAccountModel)()
        CreateMap(Of PayrollEarnAccount, PayrollEarnAccountModel)().ReverseMap()
        CreateMap(Of PayrollEarnAccountModel, PayrollEarnAccountView)()
        CreateMap(Of PcJournal, PcJournalModel)().ReverseMap()
        CreateMap(Of PcJournalModel, IPcJournalView)().ReverseMap()
        CreateMap(Of PensionProvider, PensionProviderModel)().ReverseMap()
        CreateMap(Of PensionProviderModel, IPensionProviderView)().ReverseMap()
        CreateMap(Of IPensionRateView, PensionRateModel)()
        CreateMap(Of PensionRate, PensionRateModel)().ReverseMap()
        CreateMap(Of PensionRateModel, PensionRateView)()
        CreateMap(Of PensionScheme, PensionSchemeModel)().ReverseMap()
        CreateMap(Of PensionSchemeModel, IPensionSchemeView)().ReverseMap()
        CreateMap(Of ProductCategory, ProductCategoryModel)().ReverseMap()
        CreateMap(Of ProductCategoryModel, IProductCategoryView)().ReverseMap()
        CreateMap(Of PurchaseItem, PurchaseItemModel)().ReverseMap()
        CreateMap(Of PurchaseItemModel, IPurchaseItemView)().ReverseMap()
        CreateMap(Of PurchaseJournal, PurchaseJournalModel)().ReverseMap()
        CreateMap(Of PurchaseJournalModel, IPurchaseJournalView)().ReverseMap()
        CreateMap(Of SalesDeposit, SalesDepositModel)().ReverseMap()
        CreateMap(Of SalesDepositModel, SalesDepositView)(MemberList.Source).ReverseMap()
        CreateMap(Of SalesJournal, SalesJournalModel)().ReverseMap()
        CreateMap(Of SalesJournalModel, ISalesJournalView)().ReverseMap()
        CreateMap(Of Supplier, SupplierModel)().ReverseMap()
        CreateMap(Of SupplierModel, ISupplierView)().ReverseMap()
    End Sub

    'CreateMap(Of List(Of JournalItem), List(Of JournalItemModel))().ReverseMap()
    'CreateMap(Of List(Of JournalItemModel), IJournalItemsView)().ReverseMap()
    'CreateMap(Of JournalItemModel, IJournalItemView)().ReverseMap() '.ForMember(Function(dest) dest.CreateJournalItemView, Sub(opt) opt.Ignore())
    'Public Interface IValueResolver(Of In TSource, In TDestination, TDestMember)
    '    Function Resolve(ByVal source As TSource, ByVal destination As TDestination, ByVal destMember As TDestMember, ByVal context As ResolutionContext) As TDestMember
    'End Interface
    'Public Class CustomResolver
    '    Implements IValueResolver(Of ITranslatedMessagesView, OriginalMessagesModel, OriginalMessagesModel.IdNo)

    '    'Public Function Resolve(ByVal source As Source, ByVal destination As Destination, ByVal member As Integer, ByVal context As ResolutionContext) As Integer
    '    '    Return (source.Value1 + source.Value2)
    '    'End Function

    '    Private Function IValueResolver_Resolve(source As IOriginalMessagesView, destination As OriginalMessagesModel, destMember As Integer, context As ResolutionContext) As Integer Implements IValueResolver(Of IOriginalMessagesView, OriginalMessagesModel, Integer).Resolve
    '        Throw New NotImplementedException()
    '    End Function
    'End Class

End Class