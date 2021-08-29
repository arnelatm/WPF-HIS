Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class PensionRatesPresenter
        Inherits AccountsPresenter(Of IPensionRatesView, PensionRateModel)

        Public ParentViewList As List(Of PensionRateModel)

        Public Sub New(view As IPensionRatesView)
            MyBase.New(view)
            Service = New ModelAccounts("PensionRate")
            TableName = "PensionRate"
            SortOrderKey = "Sequence"
            DataModel = New PensionRateModel
        End Sub

        'Public Property ChangesMadeInPensionRate As Boolean = False

        ''' <summary>
        '''     Displays list of Pension Scheme Rates.
        ''' </summary>
        ''' <param name="pensionSchemeIdNo">PensionSchemeIdNo id to display.</param>
        Public Shadows Sub Display(pensionSchemeIdNo As Int32)
            View.PensionRates = Model.GetRecordsWithGroupIdNo(Of PensionRateModel)(pensionSchemeIdNo, "Sequence")
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       pensionSchemeIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, pensionSchemeIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Model.InsertTvp(dtInsert)
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