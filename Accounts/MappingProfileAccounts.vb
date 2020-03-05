Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Forms
Imports AutoMapper

Public Class MappingProfileAccounts
    Inherits Profile

    Public Sub New()
        CreateMap(Of Category, CategoryModel)().ReverseMap()
        CreateMap(Of CategoryModel, ICategoryView)().ReverseMap()
        CreateMap(Of ICategoryView, Category)()

    End Sub

End Class

