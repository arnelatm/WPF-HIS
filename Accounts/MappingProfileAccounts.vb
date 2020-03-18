Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Forms
Imports AutoMapper

Public Class MappingProfileAccounts
    Inherits Profile

    Public Sub New()
        CreateMap(Of ApJournal, ApJournalModel)().ReverseMap()
        CreateMap(Of ApJournalModel, IApJournalView)().ReverseMap()
        CreateMap(Of ApOpenInvoice, ApOpenInvoiceModel)().ReverseMap()
        'CreateMap(Of ApOpenInvoiceModel, IApOpenInvoiceView)().ReverseMap()
        CreateMap(Of ArJournal, ArJournalModel)().ReverseMap()
        CreateMap(Of ArJournalModel, IArJournalView)().ReverseMap()
        CreateMap(Of ArOpenInvoice, ArOpenInvoiceModel)().ReverseMap()
        'CreateMap(Of ArOpenInvoiceModel, IArOpenInvoiceView)().ReverseMap()
        CreateMap(Of Bank, BankModel)().ReverseMap()
        CreateMap(Of BankModel, IBankView)().ReverseMap()
        CreateMap(Of CadOiItem, CadOiItemModel)().ReverseMap()
        CreateMap(Of CadOiItemModel, ICadOiItemView)().ReverseMap()
        CreateMap(Of CashDisbursementJournal, CashDisbursementJournalModel)().ReverseMap()
        CreateMap(Of CashDisbursementJournalModel, ICashDisbursementJournalView)().ReverseMap()
        CreateMap(Of Category, CategoryModel)().ReverseMap()
        CreateMap(Of CategoryModel, ICategoryView)().ReverseMap()
        CreateMap(Of Chart, ChartModel)().ReverseMap()
        CreateMap(Of ChartModel, IChartView)().ReverseMap()
        CreateMap(Of Customer, CustomerModel)().ReverseMap()
        CreateMap(Of CustomerModel, ICustomerView)().ReverseMap()
        CreateMap(Of Designation, DesignationModel)().ReverseMap()
        CreateMap(Of DesignationModel, IDesignationView)().ReverseMap()
        CreateMap(Of Employee, EmployeeModel)().ReverseMap()
        CreateMap(Of EmployeeModel, IEmployeeView)().ReverseMap()
        CreateMap(Of GeneralJournal, GeneralJournalModel)().ReverseMap()
        CreateMap(Of GeneralJournalModel, IGeneralJournalView)().ReverseMap()
        CreateMap(Of JournalItem, JournalItemModel)().ReverseMap()
        CreateMap(Of JournalItemModel, IJournalItemView)().ReverseMap()
        CreateMap(Of PurchaseItem, PurchaseItemModel)().ReverseMap()
        CreateMap(Of PurchaseItemModel, IPurchaseItemView)().ReverseMap()
        CreateMap(Of Supplier, SupplierModel)().ReverseMap()
        CreateMap(Of SupplierModel, ISupplierView)().ReverseMap()

    End Sub

End Class