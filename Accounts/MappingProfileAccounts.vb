Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.BusinessLayer
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AutoMapper

Public Class MappingProfileAccounts
    Inherits Profile

    Public Sub New()
        CreateMap(Of EmployeeAbsence, EmployeeAbsenceModel)().ReverseMap()
        CreateMap(Of EmployeeAbsenceModel, IEmployeeAbsenceView)().ReverseMap()
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
        CreateMap(Of Basic, BasicModel)().ReverseMap()
        CreateMap(Of BasicModel, IBasicView)().ReverseMap()
        CreateMap(Of CashReceiptJournal, CashReceiptJournalModel)().ReverseMap()
        CreateMap(Of CashReceiptJournalModel, ICashReceiptJournalView)().ReverseMap()
        CreateMap(Of CsrOiItem, CsrOiItemModel)().ReverseMap()
        CreateMap(Of CsrOiItemModel, CsrOiItemView)().ReverseMap()
        CreateMap(Of Customer, CustomerModel)().ReverseMap()
        CreateMap(Of CustomerModel, ICustomerView)().ReverseMap()
        'CreateMap(Of Deduction, DeductionModel)().ReverseMap()
        'CreateMap(Of DeductionModel, IDeductionView)().ReverseMap()
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
        'CreateMap(Of Earning, EarningModel)().ReverseMap()
        'CreateMap(Of EarningModel, IEarningView)().ReverseMap()
        'CreateMap(Of EarningSummary, EarningSummaryModel)().ReverseMap()
        'CreateMap(Of EarningSummaryModel, EarningSummaryView)().ReverseMap()
        'CreateMap(Of IPayrollEarnAccountView, PayrollEarnAccountModel)()

        CreateMap(Of Employee, EmployeeModel)().ReverseMap()
        CreateMap(Of EmployeeModel, IEmployeeView)().ReverseMap()

        CreateMap(Of EmployeeId, EmployeeIdModel)().ReverseMap()
        CreateMap(Of EmployeeIdModel, EmployeeIdView)().ReverseMap()

        CreateMap(Of EmployeeLeaveApproval, EmployeeLeaveApprovalModel)().ReverseMap()
        CreateMap(Of EmployeeLeaveApprovalModel, IEmployeeLeaveApprovalView)().ReverseMap()

        CreateMap(Of EmployeeLeaveApprovalItem, EmployeeLeaveApprovalItemModel)().ReverseMap()
        CreateMap(Of EmployeeLeaveApprovalItemModel, EmployeeLeaveApprovalItemView)().ReverseMap()
        CreateMap(Of EmployeeLeaveApprovalHistory, EmployeeLeaveApprovalHistoryModel)().ReverseMap()
        CreateMap(Of EmployeeLeaveApprovalHistoryModel, EmployeeLeaveApprovalHistoryView)().ReverseMap()
        CreateMap(Of EmployeeLeaveCredit, EmployeeLeaveCreditModel)().ReverseMap()
        CreateMap(Of EmployeeLeaveCreditModel, EmployeeLeaveCreditView)().ReverseMap()
        CreateMap(Of EmployeeLeaveCreditModel, IEmployeeLeaveCreditView)().ReverseMap()

        CreateMap(Of EmployeePayElement, EmployeePayElementModel)().ReverseMap()
        CreateMap(Of EmployeePayElementModel, EmployeePayElementView)().ReverseMap()
        CreateMap(Of EmployeePayElementModel, IEmployeePayElementView)().ReverseMap()

        CreateMap(Of IEmployeePhoneView, EmployeePhoneModel)()
        CreateMap(Of EmployeePhone, EmployeePhoneModel)().ReverseMap()
        CreateMap(Of EmployeePhoneModel, EmployeePhoneView)()
        CreateMap(Of EmployeeLeave, EmployeeLeaveModel)().ReverseMap()
        CreateMap(Of EmployeeLeaveModel, IEmployeeLeaveView)().ReverseMap()

        CreateMap(Of ErJournal, ErJournalModel)().ReverseMap()
        CreateMap(Of ErJournalModel, IErJournalView)().ReverseMap()
        CreateMap(Of GeneralJournal, GeneralJournalModel)().ReverseMap()
        CreateMap(Of GeneralJournalModel, IGeneralJournalView)().ReverseMap()
        CreateMap(Of Holiday, HolidayModel)().ReverseMap()
        CreateMap(Of HolidayModel, IHolidayView)().ReverseMap()
        CreateMap(Of HolidayTransfer, HolidayTransferModel)().ReverseMap()
        CreateMap(Of HolidayTransferModel, IHolidayTransferView)().ReverseMap()
        CreateMap(Of HolidayTransferItem, HolidayTransferItemModel)().ReverseMap()
        CreateMap(Of HolidayTransferItemModel, HolidayTransferItemView)().ReverseMap()
        CreateMap(Of JournalItem, JournalItemModel)().ReverseMap()
        CreateMap(Of JournalItemModel, JournalItemView)().ReverseMap()
        CreateMap(Of JournalPrefix, JournalPrefixModel)().ReverseMap()
        CreateMap(Of JournalPrefixModel, IJournalPrefixView)().ReverseMap()
        CreateMap(Of Leave, LeaveModel)().ReverseMap()
        CreateMap(Of LeaveModel, ILeaveView).ReverseMap()
        CreateMap(Of OtWorkHour, OtWorkHourModel)().ReverseMap()
        CreateMap(Of OtWorkHourModel, OtWorkHourView)().ReverseMap()
        CreateMap(Of PayCycle, PayCycleModel)().ReverseMap()
        CreateMap(Of PayCycleModel, IPayCycleView).ReverseMap()

        CreateMap(Of PayElement, PayElementModel)().ReverseMap()
        CreateMap(Of PayElementModel, IPayElementView)().ReverseMap()

        CreateMap(Of PayElementAccount, PayElementAccountModel)().ReverseMap()
        CreateMap(Of PayElementAccountModel, PayElementAccountView)().ReverseMap()

        CreateMap(Of PayElementItem, PayElementItemModel)().ReverseMap()
        CreateMap(Of PayElementItemModel, PayElementItemView)().ReverseMap()

        CreateMap(Of PayGroup, PayGroupModel)().ReverseMap()
        CreateMap(Of PayGroupModel, IPayGroupView).ReverseMap()
        CreateMap(Of Payroll, PayrollModel)().ReverseMap()
        CreateMap(Of PayrollModel, IPayrollView).ReverseMap()
        CreateMap(Of PayrollDetail, PayrollDetailModel)().ReverseMap()
        CreateMap(Of PayrollDetailModel, IPayrollDetailView)().ReverseMap()
        CreateMap(Of PayrollPayElement, PayrollPayElementModel)().ReverseMap()
        CreateMap(Of PayrollPayElementModel, IPayrollPayElementView)().ReverseMap()
        CreateMap(Of PayrollPayElementModel, PayrollPayElementView)().ReverseMap()
        CreateMap(Of PcClosingJournal, PcClosingJournalModel)().ReverseMap()
        CreateMap(Of PcClosingJournalModel, PcClosingJournalView)().ReverseMap()
        CreateMap(Of PettyCashClosing, PettyCashClosingModel)().ReverseMap()
        CreateMap(Of PettyCashClosingModel, IPettyCashClosingView)().ReverseMap()

        CreateMap(Of PensionProvider, PensionProviderModel)().ReverseMap()
        CreateMap(Of PensionProviderModel, IPensionProviderView)().ReverseMap()
        CreateMap(Of IPensionRateView, PensionRateModel)()
        CreateMap(Of PensionRate, PensionRateModel)().ReverseMap()
        CreateMap(Of PensionRateModel, PensionRateView)()
        CreateMap(Of PensionScheme, PensionSchemeModel)().ReverseMap()
        CreateMap(Of PensionSchemeModel, IPensionSchemeView)().ReverseMap()
        CreateMap(Of Category, CategoryModel)().ReverseMap()
        CreateMap(Of CategoryModel, ICategoryView)().ReverseMap()
        CreateMap(Of Product, ProductModel)().ReverseMap()
        CreateMap(Of ProductModel, IProductView)().ReverseMap()
        CreateMap(Of Purchase, PurchaseModel)().ReverseMap()
        CreateMap(Of PurchaseModel, IPurchaseView)().ReverseMap()
        CreateMap(Of RecurringPayElement, RecurringPayElementModel)().ReverseMap()
        CreateMap(Of RecurringPayElementModel, IRecurringPayElementView)().ReverseMap()
        CreateMap(Of Sale, SaleModel)().ReverseMap()
        CreateMap(Of SaleModel, ISaleView)().ReverseMap()
        CreateMap(Of SaleDetail, SaleDetailModel)().ReverseMap()
        CreateMap(Of SaleDetailModel, ISaleDetailView)().ReverseMap()
        CreateMap(Of SalesDeposit, SalesDepositModel)().ReverseMap()
        CreateMap(Of SalesDepositModel, SalesDepositView)(MemberList.Source).ReverseMap()
        CreateMap(Of SalesJournal, SalesJournalModel)().ReverseMap()
        CreateMap(Of SalesJournalModel, ISalesJournalView)().ReverseMap()
        CreateMap(Of Supplier, SupplierModel)().ReverseMap()
        CreateMap(Of SupplierModel, ISupplierView)().ReverseMap()
        CreateMap(Of ShiftSummary, ShiftSummaryModel)().ReverseMap()
        CreateMap(Of ShiftSummaryModel, IShiftSummaryView)().ReverseMap()
        CreateMap(Of ItemDetails, ItemDetailsModel)().ReverseMap()
        CreateMap(Of ItemDetailsModel, IItemDetailsView)().ReverseMap()
        CreateMap(Of Lab_InvoiceGroup, Lab_InvoiceGroupModel)().ReverseMap()
        CreateMap(Of Lab_InvoiceGroupModel, ILab_InvoiceGroupView)().ReverseMap()
        CreateMap(Of Lab_InvoiceDetails, Lab_InvoiceDetailsModel)().ReverseMap()
        CreateMap(Of Lab_InvoiceDetailsModel, Lab_InvoiceDetailsView)().ReverseMap()
        CreateMap(Of Document, DocumentModel)().ReverseMap()
        CreateMap(Of DocumentModel, IDocumentView)().ReverseMap()

        CreateMap(Of IEmployeeDocumentView, EmployeeDocumentModel)()
        CreateMap(Of EmployeeDocument, EmployeeDocumentModel)().ReverseMap()
        CreateMap(Of EmployeeDocumentModel, EmployeeDocumentView)()

        CreateMap(Of CodeGroup, CodeGroupModel)().ReverseMap()
        CreateMap(Of CodeGroupModel, ICodeGroupView)().ReverseMap()

        CreateMap(Of IDataImageView, DataImageModel)()
        CreateMap(Of DataImage, DataImageModel)().ReverseMap()
        CreateMap(Of DataImageModel, IDataImageView)().ReverseMap()

        CreateMap(Of PmrInvestigation, PmrInvestigationModel)().ReverseMap()
        CreateMap(Of PmrInvestigationModel, IPmrInvestigationView)().ReverseMap()

        CreateMap(Of ItemCode, ItemCodeModel)().ReverseMap()
        CreateMap(Of ItemCodeModel, IItemCodeView)().ReverseMap()

        CreateMap(Of DrugSale, DrugSaleModel)().ReverseMap()
        CreateMap(Of DrugSaleModel, IDrugSaleView)().ReverseMap()

        CreateMap(Of DrugAccept, DrugAcceptModel)().ReverseMap()
        CreateMap(Of DrugAcceptModel, IDrugAcceptView)().ReverseMap()

        CreateMap(Of CodeGroup, CodeGroupModel)().ReverseMap()
        CreateMap(Of CodeGroupModel, ICodeGroupView)().ReverseMap()

        CreateMap(Of Doctor, DoctorModel)().ReverseMap()
        CreateMap(Of DoctorModel, IDoctorView)().ReverseMap()

        CreateMap(Of DoctorsPatient, DoctorsPatientModel)().ReverseMap()
        CreateMap(Of DoctorsPatientModel, IDoctorsPatientView)().ReverseMap()
        CreateMap(Of DoctorsPatientModel, DoctorsPatientView)().ReverseMap()

        CreateMap(Of StockInventory, StockInventoryModel)().ReverseMap()
        CreateMap(Of StockInventoryModel, IStockInventoryView)().ReverseMap()

        CreateMap(Of GTinMatcher, GTinMatcherModel)().ReverseMap()
        CreateMap(Of GTinMatcherModel, IGTinMatcherView)().ReverseMap()

        CreateMap(Of Dosage, DosageModel)().ReverseMap()
        CreateMap(Of DosageModel, IDosageView)().ReverseMap()

        CreateMap(Of DosagePrinting, DosagePrintingModel)().ReverseMap()
        CreateMap(Of DosagePrintingModel, IDosagePrintingView)().ReverseMap()

        CreateMap(Of ItemDetails, ItemDetailsModel)().ReverseMap()
        CreateMap(Of ItemDetailsModel, IItemDetailsView)().ReverseMap()

        CreateMap(Of ProductUnit, ProductUnitModel)().ReverseMap()
        CreateMap(Of ProductUnitModel, ProductUnitView)().ReverseMap()
        CreateMap(Of IProductUnitView, ProductUnitModel)().ReverseMap()

        CreateMap(Of Purchase, PurchaseModel)().ReverseMap()
        CreateMap(Of PurchaseModel, IPurchaseView)().ReverseMap()

        CreateMap(Of PurchaseDetail, PurchaseDetailModel)().ReverseMap()
        CreateMap(Of PurchaseDetailModel, PurchaseDetailView)().ReverseMap()


        CreateMap(Of PurchaseHistory, PurchaseHistoryModel)().ReverseMap()
        CreateMap(Of PurchaseHistoryModel, PurchaseHistoryView)().ReverseMap()

        CreateMap(Of DoctorsPrescription, DoctorsPrescriptionModel)().ReverseMap()
        CreateMap(Of DoctorsPrescriptionModel, IDoctorsPrescriptionView)().ReverseMap()

        CreateMap(Of PrescriptionItem, PrescriptionItemModel)().ReverseMap()
        CreateMap(Of PrescriptionItemModel, PrescriptionItemView)().ReverseMap()

        CreateMap(Of Prescription, PrescriptionModel)().ReverseMap()
        CreateMap(Of PrescriptionModel, IPrescriptionView)().ReverseMap()

        CreateMap(Of Report, ReportModel)().ReverseMap()
        CreateMap(Of ReportModel, IReportView)().ReverseMap()

        CreateMap(Of DosageMaster, DosageMasterModel)().ReverseMap()
        CreateMap(Of DosageMasterModel, IDosageMasterView)().ReverseMap()

        CreateMap(Of Duration, DurationModel)().ReverseMap()
        CreateMap(Of DurationModel, IDurationView)().ReverseMap()

        CreateMap(Of InvTransType, InvTransTypeModel)().ReverseMap()
        CreateMap(Of InvTransTypeModel, IInvTransTypeView)().ReverseMap()

        'CreateMap(Of PmrPatientDisplayModel, PmrPatientDisplayView)()

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