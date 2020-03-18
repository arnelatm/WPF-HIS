Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemeItemsPresenter
        Inherits AccountsPresenter(Of IDistributionSchemeItemView, DistributionSchemeItemModel)

        Public ParentViewList As List(Of DistributionSchemeItemModel)
        Private Shared _changesMadeInDataGrid As Boolean = False

        Public Sub New(view As IDistributionSchemeItemView)
            MyBase.New(view)
            TableName = "DistributionSchemeItem"
            SortOrderKey = "Sequence"
            ModelPresenter = New ModelAccounts("DistributionSchemeItem")
            DataModel = New DistributionSchemeItemModel

        End Sub

        ''' <summary>
        '''     Displays list of DistributionScheme Items.
        ''' </summary>
        ''' <param name="DistributionSchemeIdNo">DistributionSchemeIdNo id to display.</param>
        Public Overrides Sub Display(distributionSchemeIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            'If DistributionSchemeIdNo = 0 Then
            '    View.DistributionSchemeItems = Nothing
            'Else
            View.DistributionSchemeItems = Model.GetRecordsWithIdNo(Of DistributionSchemeItemModel)(distributionSchemeIdNo, "Sequence")
            'End If
        End Sub

        'Public Overrides Function ChangesMade() As Boolean
        '    Return
        'End Function

        Public Overrides Function DataIsValid() As Boolean
            If MyBase.DataIsValid() Then
                Dim retVal = True
                Dim totalPercentage As Decimal
                If View.DistributionSchemeItems Is Nothing Then
                    MessageBox.Show("No entries, cannot save a blank distribution scheme.")
                    retVal = False
                Else
                    For Each item In View.DistributionSchemeItems
                        totalPercentage = totalPercentage + item.Percentage
                        If item.ProfitCenterIdNo = 0 Then
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
            Else
                Return False
            End If
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       distributionSchemeIdNo As Integer)
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