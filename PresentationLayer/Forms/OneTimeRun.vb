Imports System.Windows.Forms

Public Class OneTimeRun

    Public Shared Sub CreateAllMessages()
        Messaging.Show(True, "MsgDeletePaidEntryNotAllowed", "You can't delete this row because this entry has an existing payment and/or discount!", "Delete Error")
        Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
        Messaging.Show(True, "MsgPaymentDiscountExistChangeDisallowed",
                       "Sorry, this account payable has already been partially or fully paid/discounted, changing account/supplier not allowed. Value will revert to previous value.",
                       "Modification Error")

    End Sub

End Class