Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AutoMapper

Public Class MappingProfileAccounts
    Inherits Profile

    Public Sub New()
        CreateMap(Of AccountReconciliation, AccountReconciliationModel)().ReverseMap()
        CreateMap(Of AccountReconciliationItem, AccountReconciliationItemModel)().ReverseMap()
        CreateMap(Of AccountReconciliationItemModel, IAccountReconciliationItemView)().ReverseMap()
        CreateMap(Of AccountReconciliationModel, IAccountReconciliationView)().ReverseMap()
        CreateMap(Of ApJournal, ApJournalModel)().ReverseMap()
        CreateMap(Of ApOpenInvoice, ApOpenInvoiceModel)().ReverseMap()
        CreateMap(Of ArJournal, ArJournalModel)().ReverseMap()
        CreateMap(Of ArJournalModel, IArJournalView)().ReverseMap()
        CreateMap(Of ArOpenInvoice, ArOpenInvoiceModel)().ReverseMap()
        CreateMap(Of Bank, BankModel)().ReverseMap()
        CreateMap(Of BankModel, IBankView)().ReverseMap()
        CreateMap(Of CadOiItem, CadOiItemModel)().ReverseMap()
        CreateMap(Of CadOiItemModel, ICadOiItemView)().ReverseMap()
        CreateMap(Of CashCode, CashCodeModel)().ReverseMap()
        CreateMap(Of CashCodeModel, ICashCodeView)().ReverseMap()
        CreateMap(Of CashDisbursementJournal, CashDisbursementJournalModel)().ReverseMap()
        CreateMap(Of CashDisbursementJournalModel, ICashDisbursementJournalView)().ReverseMap()
        CreateMap(Of CashReceiptJournal, CashReceiptJournalModel)().ReverseMap()
        CreateMap(Of CashReceiptJournalModel, ICashReceiptJournalView)().ReverseMap()
        CreateMap(Of Category, CategoryModel)().ReverseMap()
        CreateMap(Of CategoryModel, ICategoryView)().ReverseMap()
        CreateMap(Of Chart, ChartModel)().ReverseMap()
        CreateMap(Of ChartModel, IChartView)().ReverseMap()
        CreateMap(Of CheckDisbursementJournal, CheckDisbursementJournalModel)().ReverseMap()
        CreateMap(Of CheckDisbursementJournalModel, ICheckDisbursementJournalView)().ReverseMap()
        CreateMap(Of CkdOiItem, CkdOiItemModel)().ReverseMap()
        CreateMap(Of CkdOiItemModel, ICkdOiItemView)().ReverseMap()
        CreateMap(Of CsrOiItem, CsrOiItemModel)().ReverseMap()
        CreateMap(Of CsrOiItemModel, ICsrOiItemView)().ReverseMap()
        CreateMap(Of Customer, CustomerModel)().ReverseMap()
        CreateMap(Of CustomerModel, ICustomerView)().ReverseMap()
        CreateMap(Of Designation, DesignationModel)().ReverseMap()
        CreateMap(Of DesignationModel, IDesignationView)().ReverseMap()
        CreateMap(Of DistributionScheme, DistributionSchemeModel)().ReverseMap()
        CreateMap(Of DistributionSchemeItem, DistributionSchemeItemModel)().ReverseMap()
        CreateMap(Of DistributionSchemeItemModel, IDistributionSchemeItemView)().ReverseMap()
        CreateMap(Of DistributionSchemeModel, IDistributionSchemeView)().ReverseMap()
        CreateMap(Of Employee, EmployeeModel)().ReverseMap()
        CreateMap(Of EmployeeModel, IEmployeeView)().ReverseMap()
        CreateMap(Of GeneralJournal, GeneralJournalModel)().ReverseMap()
        CreateMap(Of GeneralJournalModel, IGeneralJournalView)().ReverseMap()
        CreateMap(Of IApJournalView, ApJournalModel)()
        CreateMap(Of JournalItem, JournalItemModel)().ReverseMap()
        CreateMap(Of JournalItemModel, IJournalItemView)().ReverseMap()
        CreateMap(Of JournalItemModel, JournalItemView)().ReverseMap()
        CreateMap(Of PcsOiItem, PcsOiItemModel)().ReverseMap()
        CreateMap(Of PcsOiItemModel, IPcsOiItemView)().ReverseMap()
        CreateMap(Of PettyCashJournal, PettyCashJournalModel)().ReverseMap()
        CreateMap(Of PettyCashJournalModel, IPettyCashJournalView)().ReverseMap()
        CreateMap(Of PurchaseItem, PurchaseItemModel)().ReverseMap()
        CreateMap(Of PurchaseItemModel, IPurchaseItemView)().ReverseMap()
        CreateMap(Of PurchaseJournal, PurchaseJournalModel)().ReverseMap()
        CreateMap(Of PurchaseJournalModel, IPurchaseJournalView)().ReverseMap()
        CreateMap(Of SalesCashItem, SalesCashItemModel)().ReverseMap()
        CreateMap(Of SalesCashItemModel, ISalesCashItemView)().ReverseMap()
        CreateMap(Of SalesJournal, SalesJournalModel)().ReverseMap()
        CreateMap(Of SalesJournalModel, ISalesJournalView)().ReverseMap()
        CreateMap(Of Supplier, SupplierModel)().ReverseMap()
        CreateMap(Of SupplierModel, ISupplierView)().ReverseMap()
        'CreateMap(Of List(Of JournalItem), List(Of JournalItemModel))().ReverseMap()
        'CreateMap(Of List(Of JournalItemModel), IJournalItemsView)().ReverseMap()
        'CreateMap(Of JournalItemModel, IJournalItemView)().ReverseMap() '.ForMember(Function(dest) dest.CreateJournalItemView, Sub(opt) opt.Ignore())

    End Sub

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