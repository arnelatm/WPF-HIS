Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.PresentationLayer.Views
Imports AutoMapper

Public Class MappingProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of SecurityObject, SecurityObjectModel)().ReverseMap()
        CreateMap(Of SecurityObjectModel, ISecurityObjectView)()
        CreateMap(Of ISecurityObjectView, SecurityObject)()
        CreateMap(Of SecurityGroup, SecurityGroupModel)().ReverseMap()
        CreateMap(Of SecurityGroupModel, ISecurityGroupView)()
        CreateMap(Of ISecurityGroupView, SecurityGroup)
        CreateMap(Of GroupAccess, GroupAccessModel)().ReverseMap()
        CreateMap(Of GroupAccessModel, IGroupAccessView)()
        CreateMap(Of IGroupAccessView, GroupAccess)()
        CreateMap(Of User, UserModel)().ReverseMap()
        CreateMap(Of UserModel, IUserView)()
        CreateMap(Of IUserView, User)()
    End Sub

End Class
