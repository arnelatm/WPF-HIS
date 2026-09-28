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
            Dim references As New List(Of String)
            AddCountryReference(references, countryCode, "Customer", "CountryCode")
            AddCountryReference(references, countryCode, "Employee", "CountryCode")
            AddCountryReference(references, countryCode, "Employee", "NationalityCode")
            AddCountryReference(references, countryCode, "EmployeeNew", "CountryCode")
            AddCountryReference(references, countryCode, "EmployeeNew", "NationalityCode")
            AddCountryReference(references, countryCode, "PensionProvider", "CountryCode")
            AddCountryReference(references, countryCode, "Supplier", "CountryCode")

            If references.Count > 0 AndAlso warn Then
                Messaging.Show(True, "MsgDependentRecordExists", {"additionalMessage", String.Join(Environment.NewLine, references)})
            End If

            Return references.Count > 0
        End Function

        Private Sub AddCountryReference(references As List(Of String), countryCode As String, tableName As String, fieldName As String)
            Dim recordId = Service.GetRecordFieldWithKeyG(Of Integer, String)(countryCode, tableName, fieldName, "IdNo")
            If recordId > 0 Then
                Dim tableCaption = Messaging.TranslateCaption(tableName)
                references.Add(Messaging.GetParametrizedMessage(True, "MsgSeeTableEntry", {"tableName", tableCaption, "idNumber", recordId.ToString()}))
            End If
        End Sub

    End Class

End Namespace
