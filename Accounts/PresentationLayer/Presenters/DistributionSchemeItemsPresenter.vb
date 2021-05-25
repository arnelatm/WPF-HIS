Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemeItemsPresenter
        Inherits AccountsPresenter(Of IDistributionSchemeItemsView, DistributionSchemeItemModel)

        Private Shared _changesMadeInDataGrid As Boolean = False

        Public Sub New(view As IDistributionSchemeItemsView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("DistributionSchemeItem")
            TableName = "DistributionSchemeItem"
            SortOrderKey = "Sequence"
            DataModel = New DistributionSchemeItemModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        ''' <summary>
        '''     Displays list of DistributionScheme Items.
        ''' </summary>
        ''' <param name="DistributionSchemeIdNo">DistributionSchemeIdNo id to display.</param>
        Public Shadows Sub Display(distributionSchemeIdNo As Int32)
            View.DistributionSchemeItems = Model.GetRecordsWithGroupIdNo(Of DistributionSchemeItemModel)(distributionSchemeIdNo, "Sequence")
        End Sub

        'Public Overrides Function ChangesMade() As Boolean
        '    Return
        'End Function

        Public Overloads Function DataIsValid(ByRef distributionSchemeItems As List(Of DistributionSchemeItemModel))
            Dim retVal = True
            Dim totalPercentage As Decimal
            If distributionSchemeItems Is Nothing Then
                MessageBox.Show("No entries, cannot save a blank distribution scheme.")
                retVal = False
            Else
                For Each item In distributionSchemeItems
                    totalPercentage += item.Percentage
                    If item.RevCostCenterIdNo = 0 Then
                        MessageBox.Show("Blank Profit Center is not allowed in line #" + item.Sequence.ToString())
                        retVal = False
                        Exit For
                    End If
                Next
                If retVal And Math.Abs(totalPercentage - 100.0) > 0.001 Then
                    MessageBox.Show("Total Percentage must be 100.00%")
                    retVal = False
                End If
            End If
            Return retVal
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       distributionSchemeIdNo As Int32)
            Dim insertReturnValue = 0
            Dim updateReturnValue = 0
            Dim retVal = 0
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, distributionSchemeIdNo)
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