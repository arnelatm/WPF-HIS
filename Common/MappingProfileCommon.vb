Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common.BusinessLayer
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces
Imports AutoMapper

Public Class MappingProfileCommon
    Inherits Profile

    Public Sub New()
        CreateMap(Of Branch, BranchModel).ReverseMap()
        CreateMap(Of BranchModel, IBranchView).ReverseMap()
        CreateMap(Of Country, CountryModel).ReverseMap()
        CreateMap(Of CountryModel, ICountryView).ReverseMap()
        CreateMap(Of Department, DepartmentModel).ReverseMap()
        CreateMap(Of DepartmentModel, IDepartmentView).ReverseMap()
        CreateMap(Of GroupAccess, GroupAccessModel).ReverseMap()
        CreateMap(Of GroupAccessModel, GroupAccessView)(MemberList.Source).ReverseMap()
        CreateMap(Of ITranslatedMessagesView, TranslatedMessagesModel)().ForMember(Function(dest) dest.IdNo, Sub(opt) opt.MapFrom(Function(src) src.IdNo))
        CreateMap(Of OriginalCaptions, OriginalCaptionsModel).ReverseMap()
        CreateMap(Of OriginalCaptionsModel, IOriginalCaptionsView).ReverseMap()
        CreateMap(Of OriginalMessages, OriginalMessagesModel).ReverseMap()
        CreateMap(Of OriginalMessagesModel, IOriginalMessagesView).ReverseMap()
        CreateMap(Of PhoneType, PhoneTypeModel).ReverseMap()
        CreateMap(Of PhoneTypeModel, IPhoneTypeView).ReverseMap()
        CreateMap(Of Religion, ReligionModel).ReverseMap()
        CreateMap(Of ReligionModel, IReligionView).ReverseMap()
        CreateMap(Of RevCostCenter, RevCostCenterModel).ReverseMap()
        CreateMap(Of RevCostCenterModel, IRevCostCenterView).ReverseMap()
        CreateMap(Of RevenueGroup, RevenueGroupModel).ReverseMap()
        CreateMap(Of RevenueGroupModel, IRevenueGroupView).ReverseMap()
        'CreateMap(Of SecurityGroup, SecurityGroupModel)().ForMember(Function(dest) dest.ParentIdNo, Sub(opt) opt.NullSubstitute(Nothing)).ReverseMap()
        'CreateMap(Of SecurityGroup, SecurityGroupModel).ForMember(Function(dest) dest.ParentIdNo, Sub(opt) opt.MapFrom( Function(src) IIf(src.ParentIdNo.HasValue, src.ParentIdNo, Nothing )))
        CreateMap(Of SecurityGroup, SecurityGroupModel).ReverseMap()
        'CreateMap(Of SecurityGroupModel, ISecurityGroupView).ReverseMap()
        'CreateMap(Of SecurityGroupModel, SecurityGroupView)().ForMember(Function(dest) dest.ParentIdNo, Sub(opt) opt.MapFrom( Function(src) IIf(src.ParentIdNo.HasValue, src.ParentIdNo, Nothing ))
        'CreateMap(Of SecurityGroupModel, SecurityGroupView)(MemberList.Source).ForMember(Function(dest) dest.ParentIdNo, Sub(opt) opt.NullSubstitute(Nothing)).ReverseMap()
        'CreateMap(Of SecurityGroupModel, SecurityGroupView)(MemberList.Source).ReverseMap()
        CreateMap(Of SecurityGroupModel, ISecurityGroupView)(MemberList.Source).ReverseMap()
        'CreateMap(Of SecurityGroupModel, SecurityGroupView).ForMember(Function(dest) dest.ParentIdNo, Sub(opt) opt.MapFrom( Function(src) IIf(src.ParentIdNo.HasValue, src.ParentIdNo, Nothing )))
        CreateMap(Of SecurityObject, SecurityObjectModel).ReverseMap()
        CreateMap(Of SecurityObjectModel, ISecurityObjectView).ReverseMap()
        CreateMap(Of TranslatedCaption, TranslatedCaptionModel).ReverseMap()
        CreateMap(Of TranslatedCaptionModel, ITranslatedCaptionView).ReverseMap()
        CreateMap(Of TranslatedMessages, TranslatedMessagesModel).ReverseMap()
        CreateMap(Of TranslatedMessagesModel, ITranslatedMessagesView)().ForMember(Function(dest) dest.IdNo, Sub(opt) opt.MapFrom(Function(src) src.IdNo))
        CreateMap(Of User, UserModel)().ReverseMap()
        CreateMap(Of UserModel, IUserView).ReverseMap()
        CreateMap(Of DefaultFieldValue, DefaultFieldValueModel).ReverseMap()
        CreateMap(Of DefaultFieldValueModel, IDefaultFieldValueView).ReverseMap()
        CreateMap(Of PrintJobModel, PrintJob).ReverseMap()

        'destination >= destination.Value, opt >= opt.NullSubstitute("Other Value")));;

        '    .ForMember(Function(dest) dest.TelephoneNumber, sub(opt) opt.MapFrom(function(src) src.TelephoneNo1)) _
        '    .ForMember(Function(dest) dest.MobileNumber, Sub(opt) opt.MapFrom(function(src) src.MobilePhoneNo)) _
        '    .ForMember(Function(dest) dest.NationalInsuranceNumber, sub(opt) opt.MapFrom(function(src) src.NINo)) _
        '    .ForMember(Function(dest) dest.DateOfBirth, Sub(opt) opt.MapFrom(function(src) src.BirthDate))

        'Mapper.CreateMap<IDataReader, Contact>().ForMember(c=>c.Addresses, opt=>opt.Ignore());
        'Mapper.CreateMap(Of IDataReader, Contact)().ForMember(Function(c) c.Addresses, Function(opt) opt.Ignore())
        'CreateMap(Of ITranslatedMessagesView, TranslatedMessagesModel)().ForMember(Function(c) c.TranslatedMessagesModel, Function(opt) opt.Ignore())

        'AutoMapper.Mapper.CreateMap<Transit, BusViewModel>().ForMember(dest => dest.NextArrivalInMinutes, opt => opt.MapFrom(src => src.NextBusArrival.Minute));

        'CreateMap(Of ITranslatedMessagesView , TranslatedMessagesModel )().ForMember(Function(c) c.MessagesIdNo, Function(opt) opt.MapFrom( Function(src) src.IdNo))

        'CreateMap(Of ITranslatedMessagesView , TranslatedMessagesModel )().ForMember(Function(c) c.MessagesIdNo, Function(opt) opt.Ignore())

    End Sub

End Class