Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class PcsOiItemsPresenter
        Inherits AccountsPresenter(Of IPcsOiItemsView, PcsOiItem, PcsOiItemModel)

        Public ParentViewList As List(Of PcsOiItemModel)

        Public Sub New(view As IPcsOiItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelPcsOiItem()
            TableName = "PcsOiItem"
            SortOrderKey = "Sequence"
            BizObject = New PcsOiItem
            DataModel = New PcsOiItemModel
        End Sub

        Public Property ChangesMadeInPcsOiItem As Boolean = False

        'Public Overloads Function DataIsValid(ByRef PcsOiItems As List(Of PcsOiItemModel), ByRef dataGridView As DataGridView, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
        Public Overloads Function DataIsValid(ByRef PcsOiItems As BindingSource, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In PcsOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim errorMsg = String.Format("Error in line {0:N0}. Applied amount and discount exceeds balance.", item.Sequence.ToString())
                        MessageBox.Show(errorMsg)
                        PcsOiItems(index).errors.Add(errorMsg)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If PcsOiItems(index).Errors IsNot Nothing Then
                            PcsOiItems(index).errors.Clear()
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
        ''''     Displays list of Ap PcsOi Items.
        '''' </summary>
        '''' <param name="pcsOiIdNo">pcsOiIdNo id to display.</param>
        Public Shadows Sub Display(pcsOiIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.PcsOiItems = Model.GetRecordsWithIdNo(Of PcsOiItemModel)(pcsOiIdNo, "Sequence")
        End Sub

        Public Function GetPcsOiItems(pcsOiIdNo As Integer) As List(Of PcsOiItemModel)
            Return Model.GetRecordsWithIdNo(Of PcsOiItemModel)(pcsOiIdNo, "Sequence")
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Integer) As List(Of PcsOiItemModel)
            Return ModelPresenter.GetSupplierOpenInvoices(supplierIdNo)
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       pcsOiIdNo As Integer)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, pcsOiIdNo)
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
End NameSpace