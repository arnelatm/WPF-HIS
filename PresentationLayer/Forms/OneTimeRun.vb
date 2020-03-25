Imports System.Windows.Forms
Imports AATM.Libraries.MessagingLibrary

Public Class OneTimeRun

    Public Shared Sub CreateAllMessages()
        Messaging.AddMessage("AskIfSaveEmptyJournal", "Journal Entry is Empty, do you still want to save this entry?", "Empty Journal")
        Messaging.AddMessage("MsgDeletePaidEntryNotAllowed", "You can't delete this row because this entry has an existing payment and/or discount!", "Delete Error")
        Messaging.AddMessage("MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
        Messaging.AddMessage("MsgMemberCannotBeAParentToItself", "Sorry a member cannot be a parent to itself.", "Invalid Parent")
        Messaging.AddMessage("MsgPaymentDiscountExistChangeDisallowed", "Sorry, this account payable has already been partially or fully paid/discounted, changing account/supplier not allowed. Value will revert to previous value.", "Modification Error")
    End Sub

End Class