Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportPresenter
        Inherits AccountsPresenterNew(Of IView, AccountModel)

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
        Inherits AccountsPresenterNew(Of IView, AccountModel)

        'Public UserIsSupervisor As Boolean

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            Service = New AccountsService("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            WithTreeView = False
            CreateLookupData("InsuranceDetails", "InsuranceId", {"InsuranceId","NameEnglish"},"NameEnglish", Nothing)
        End Sub


    End Class

End Namespace