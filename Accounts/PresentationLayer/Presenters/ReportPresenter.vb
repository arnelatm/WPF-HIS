Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Forms
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
        End Sub

        Public Function MakeCrViewer(reportFileName As String, reportTitle As String, cFormCulture As CultureInfo, ParamArray args() As Object) As CrViewer
            Dim cForm As New CrViewer(reportFileName, reportTitle, cFormCulture, args)
            Return cForm
        End Function

        Public Sub ShowReport(cForm As CrViewer, printJobName As String, dbConnectionName As String)
            Dim pjPresenter As New PrintJobPresenter()
            pjPresenter.ViewReport(cForm, printJobName, dbConnectionName)
            cForm.Show()
        End Sub

        Public Sub ShowReport(crViewerForm As Object)
            crViewerForm.Show()
        End Sub

    End Class

    Public Class DateRangeCompanyPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)

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