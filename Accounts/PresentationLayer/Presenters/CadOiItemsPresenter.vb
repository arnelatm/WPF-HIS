Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CadOiItemsPresenter
        Inherits AccountsPresenter(Of ICadOiItemsView, CadOiItemModel)

        Public ParentViewList As List(Of CadOiItemModel)

        Public Sub New(view As ICadOiItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("CadOiItem")
            TableName = "CadOiItem"
            SortOrderKey = "Sequence"
            DataModel = New CadOiItemModel
        End Sub

        Public Property ChangesMadeInCadOiItem As Boolean = False

        'Public Overloads Function DataIsValid(ByRef cadOiItems As List(Of CadOiItemModel), ByRef dataGridView As DataGridView, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
        Public Overloads Function DataIsValid(ByRef cadOiItems As BindingSource, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In cadOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim errorMsg = String.Format("Error in line {0:N0}. Applied amount and discount exceeds balance.", item.Sequence.ToString())
                        MessageBox.Show(errorMsg)
                        cadOiItems(index).errors.Add(errorMsg)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If cadOiItems(index).Errors IsNot Nothing Then
                            cadOiItems(index).errors.Clear()
                        End If
                    End If
                End If
                index += 1
            Next
            If retVal Then
                If unAppliedAmount <> 0 Then
                    If totalBalance > 0 Then
                        If unAppliedAmount > 0 Then
                            MessageBox.Show($"Payment not yet fully applied. Cannot save entry unless amount is fully applied.")
                            retVal = False
                        Else
                            MessageBox.Show($"Payment is over applied. Cannot save entry please reduce the applied payment.")
                            retVal = False
                        End If
                    Else
                        If MessageBox.Show($"Amount not yet fully applied or no more unpaid invoices for this supplier. Do you want to make the excess payment as an advance payment?", $"Save Advance Payment",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            retVal = True
                        Else
                            retVal = False
                        End If
                    End If
                Else
                    retVal = True
                End If
            End If
            Return retVal
        End Function

        '''' <summary>
        ''''     Displays list of Ap CadOi Items.
        '''' </summary>
        '''' <param name="cadOiIdNo">CadOiIDNo id to display.</param>
        Public Shadows Sub Display(cadOiIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.CadOiItems = Model.GetRecordsWithIdNo(Of CadOiItemModel)(cadOiIdNo, "Sequence")
        End Sub

        Public Function GetCadOiItems(cadOiIdNo As Integer) As List(Of CadOiItemModel)
            Return Model.GetRecordsWithIdNo(Of CadOiItemModel)(cadOiIdNo, "Sequence")
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Integer) As List(Of CadOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(Of CadOiItemModel)(supplierIdNo)
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       cadOiIdNo As Integer)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, cadOiIdNo)
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