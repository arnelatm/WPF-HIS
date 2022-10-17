Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)

        'Public UserIsSupervisor As Boolean

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            Service = New AccountsService("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            WithTreeView = False
            'UserIsSupervisor = IsUserASupervisor()
        End Sub

    End Class

    Public Class DateRangeCompanyPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)

        'Public UserIsSupervisor As Boolean

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            Service = New AccountsService("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            WithTreeView = False
            Service.SaveConnectionString()
            Service.SetConnectionString("IGROUPCLINIC")
            CreateLookupData("InsuranceDetails", "InsuranceList", {"InsuranceId", "NameEnglish"}, "NameEnglish", Nothing)
            Service.RestoreConnectionString()
        End Sub

    End Class

End Namespace