Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AutoMapper

Public Class MappingProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of SecurityObject, SecurityObjectModel).ReverseMap()
        CreateMap(Of SecurityObjectModel, ISecurityObjectView).ReverseMap()
        CreateMap(Of SecurityGroup, SecurityGroupModel)().ReverseMap()
        CreateMap(Of SecurityGroupModel, ISecurityGroupView).ReverseMap()
        CreateMap(Of GroupAccess, GroupAccessModel)().ReverseMap()
        CreateMap(Of GroupAccessModel, IGroupAccessView).ReverseMap()
        CreateMap(Of User, UserModel)().ReverseMap()
        CreateMap(Of UserModel, IUserView).ReverseMap()
    End Sub

End Class