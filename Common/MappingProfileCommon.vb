Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AutoMapper

Public Class MappingProfileCommon
    Inherits Profile

    Public Sub New()
        CreateMap(Of Branch, BranchModel).ReverseMap()
        CreateMap(Of BranchModel, IBranchView).ReverseMap()
        CreateMap(Of Department, DepartmentModel).ReverseMap()
        CreateMap(Of DepartmentModel, IDepartmentView).ReverseMap()
        CreateMap(Of CostCenter, CostCenterModel).ReverseMap()
        CreateMap(Of CostCenterModel, ICostCenterView).ReverseMap()
        CreateMap(Of Country, CountryModel).ReverseMap()
        CreateMap(Of CountryModel, ICountryView).ReverseMap()
        CreateMap(Of ProfitCenter, ProfitCenterModel).ReverseMap()
        CreateMap(Of ProfitCenterModel, IProfitCenterView).ReverseMap()
        CreateMap(Of PhoneType, PhoneTypeModel).ReverseMap()
        CreateMap(Of PhoneTypeModel, IPhoneTypeView).ReverseMap()
        CreateMap(Of Religion, ReligionModel).ReverseMap()
        CreateMap(Of ReligionModel, IReligionView).ReverseMap()
        CreateMap(Of RevenueGroup, RevenueGroupModel).ReverseMap()
        CreateMap(Of RevenueGroupModel, IRevenueGroupView).ReverseMap()
        CreateMap(Of TranslatedMessages, TranslatedMessagesModel).ReverseMap()
        CreateMap(Of TranslatedMessagesModel, ITranslatedMessagesView).ReverseMap()
        CreateMap(Of OriginalMessages, OriginalMessagesModel).ReverseMap()
        CreateMap(Of OriginalMessagesModel, IOriginalMessagesView).ReverseMap()
    End Sub

End Class