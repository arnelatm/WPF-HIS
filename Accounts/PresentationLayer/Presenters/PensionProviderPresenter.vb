Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PensionProviderPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPensionProviderView, TM)

        Public Sub New(view As IPensionProviderView)
            MyBase.New(view)
            Service = New AccountsService("PensionProvider")
            TableName = "PensionProvider"
            TreeViewMainField = "PensionProviderName"
            'TreeViewSecondaryField = "PensionProviderCode"
            SortOrderKey = "PensionProviderName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Country", "CountryCode")
            CreateDataSource("Bank", "BankIdNo")
            CreateEnumDataSource(Of PaymentMethodSelection)("PaymentMethod")
        End Sub

    End Class

End Namespace