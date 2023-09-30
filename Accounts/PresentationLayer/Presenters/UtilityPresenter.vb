Imports System.Drawing.Design
Imports System.Dynamic
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.DataLayer
Imports Microsoft.Office.Interop.Excel

Namespace PresentationLayer.Presenters

    Public Class UtilityPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IUtilityView, TM)

        Private ReadOnly PresenterView

        Public Sub New(view As IUtilityView)
            MyBase.New(view)
            TableName = "Inventory"
            WithTreeView = False
            Service = New AccountsService("Inventory")
            AddHandler view.UtilityButtonClicked, AddressOf OnUtilityButtonClicked
            'AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
        End Sub

        Private Function OnUtilityButtonClicked(parameters As Object)
            Dim retVal As Int16
            Dim utilityName As String = View.UtilityName
            Dim utilityIdNo As Int16 = Service.GetField(Of Int16, String)(utilityName, "Utilities", "UtilityName", "IdNo")
            Dim utilityObject As Object = Service.GetFieldsWithIdNo(utilityIdNo, "Utilities", "StoredProcedure")
            If utilityObject.StoredProcedure Then
                retVal = Service.RunSpWithRollBack("sp" & utilityName, parameters)
                If retVal = 0 Then
                    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgRecordSuccessfullyUpdated")
                Else
                    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgRecordUpdateFail")
                End If
            End If
            Return retVal
        End Function



    End Class

End Namespace