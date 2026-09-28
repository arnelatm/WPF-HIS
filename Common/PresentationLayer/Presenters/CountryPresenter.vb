Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class CountryPresenter(Of TM As New)
        Inherits CommonPresenter(Of ICountryView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As ICountryView)
            MyBase.New(view)
            Service = New CommonService("Country")
            TableName = "Country"
            SortOrderKey = "CountryName"
            TreeViewMainField = "CountryName"
            'TreeViewSecondaryField = "CountryCode"
            ParentViewList = New List(Of TM)
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim countryCode = View.CountryCode
            Dim hasDependents =
                Service.CountRecordWithKey(Of String)("Customer", "CountryCode", countryCode) > 0 OrElse
                Service.CountRecordWithKey(Of String)("Employee", "CountryCode", countryCode) > 0 OrElse
                Service.CountRecordWithKey(Of String)("Employee", "NationalityCode", countryCode) > 0 OrElse
                Service.CountRecordWithKey(Of String)("EmployeeNew", "CountryCode", countryCode) > 0 OrElse
                Service.CountRecordWithKey(Of String)("EmployeeNew", "NationalityCode", countryCode) > 0 OrElse
                Service.CountRecordWithKey(Of String)("PensionProvider", "CountryCode", countryCode) > 0 OrElse
                Service.CountRecordWithKey(Of String)("Supplier", "CountryCode", countryCode) > 0

            If hasDependents AndAlso warn Then
                Messaging.Show(True, "MsgDependentRecordExists", {"additionalMessage", ""})
            End If

            Return hasDependents
        End Function

    End Class

End Namespace
