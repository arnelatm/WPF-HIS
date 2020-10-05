Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.PresentationLayer.Views

Public Class CountryTelCodeView
    Implements ICountryTelCodeView

    Public Property IdNo As Short Implements ICountryTelCodeView.IdNo

    Public Property CountryName As String Implements ICountryTelCodeView.CountryName

    Public Property CountryNameAra As String Implements ICountryTelCodeView.CountryNameAra

    Public Property CountryTelCode As String Implements ICountryTelCodeView.CountryTelCode

    Public Property Errors As List(Of String) Implements IView.Errors

End Class