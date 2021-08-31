Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class PensionRatesPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IPensionRatesView, PensionRateModel)

        Public ParentViewList As List(Of PensionRateModel)

        Public Sub New(view As IPensionRatesView)
            MyBase.New(view)
            Service = New AccountsService("PensionRate")
            TableName = "PensionRate"
            SortOrderKey = "Sequence"
        End Sub

        'Public Property ChangesMadeInPensionRate As Boolean = False

        ''' <summary>
        '''     Displays list of Pension Scheme Rates.
        ''' </summary>
        ''' <param name="pensionSchemeIdNo">PensionSchemeIdNo id to display.</param>
        Public Shadows Sub Display(pensionSchemeIdNo As Int32)
            View.PensionRates = Service.GetRecordsWithGroupIdNo(Of PensionRateModel)(pensionSchemeIdNo, "Sequence")
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       pensionSchemeIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Service.DelUpdateTvp(dtUpdate, pensionSchemeIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Service.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

    End Class

End Namespace