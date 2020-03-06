Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.PresentationLayer.Forms
Imports AutoMapper

Public Class MappingProfileCommon
    Inherits Profile

    Public Sub New()
        CreateMap(Of Branch, BranchModel)().ReverseMap()
        CreateMap(Of BranchModel, IBranchView)().ReverseMap()
        CreateMap(Of IBranchView, Branch)()

    End Sub

End Class

