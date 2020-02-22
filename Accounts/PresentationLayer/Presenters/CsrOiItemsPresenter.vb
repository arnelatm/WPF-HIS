Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class CsrOiItemsPresenter
        Inherits AccountsPresenter(Of ICsrOiItemsView, CsrOiItem, CsrOiItemModel)

        Public ParentViewList As List(Of CsrOiItemModel)

        Public Sub New(view As ICsrOiItemsView)
            MyBase.New(view)
            CurrentModel = New ModelCsrOiItem()
            TableName = "CsrOiItem"
            SortOrderKey = "Sequence"
            BizObject = New CsrOiItem
            DataModel = New CsrOiItemModel
        End Sub

        Public Property ChangesMadeInCsrOiItem As Boolean = False

        Public Overloads Function DataIsValid(ByRef csrOiItems As BindingSource, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
            Dim retVal = True
            Dim index As Int16 = 0
            For Each item In csrOiItems
                If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                    If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
                       (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
                        Dim errorMsg = String.Format("Error in line {0:N0}. Applied amount and discount exceeds balance.", item.Sequence.ToString())
                        MessageBox.Show(errorMsg)
                        csrOiItems(index).errors.Add(errorMsg)
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
                        retVal = False
                        Exit For
                    Else
                        ' clear error message
                        'dataGridView.Rows(item.Sequence - 1).ErrorText = ""
                        If csrOiItems(index).Errors IsNot Nothing Then
                            csrOiItems(index).errors.Clear()
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
                        If MessageBox.Show($"Amount not yet fully applied or no more unpaid invoices for this customer. Do you want to make the excess payment as an advance payment?", $"Save Advance Payment",
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
        ''''     Displays list of Ap CsrOi Items.
        '''' </summary>
        '''' <param name="csrOiIdNo">CsrOiIDNo id to display.</param>
        Public Shadows Sub Display(csrOiIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.CsrOiItems = Model.GetRecordsWithIdNo(Of CsrOiItemModel)(csrOiIdNo, "Sequence")
        End Sub

        Public Function GetCsrOiItems(csrOiIdNo As Integer) As List(Of CsrOiItemModel)
            Return Model.GetRecordsWithIdNo(Of CsrOiItemModel)(csrOiIdNo, "Sequence")
        End Function

        Public Function GetCustomerOpenInvoices(ByVal customerIdNo As Integer) As List(Of CsrOiItemModel)
            Return CurrentModel.GetCustomerOpenInvoices(customerIdNo)
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       csrOiIdNo As Integer)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, csrOiIdNo)
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