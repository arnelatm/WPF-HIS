Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.PresentationLayer.Forms
Imports AutoMapper

Public Class MappingProfileCommon
    Inherits Profile

    Public Sub New()
        ' copy BO to model ok
        CreateMap(Of Branch, BranchModel)().ReverseMap()
        ' copy model to view ok
        CreateMap(Of BranchModel, IBranchView)().ReverseMap()
        CreateMap(Of Department, DepartmentModel)().ReverseMap()
        CreateMap(Of DepartmentModel, IDepartmentView)()
        CreateMap(Of IDepartmentView, Department)()

    End Sub

End Class

