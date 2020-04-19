Imports System.Windows.Forms
Imports AATM.Common
Imports AATM.Libraries.EnumLocalization
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms

Public Class OneTimeRun

    Public Shared Sub CreateAllMessages()
        Messaging.AddMessage("AskIfContinueAction", "Are you sure you want to {action} this {itemName} entry?", "Please confirm!")
        Messaging.AddMessage("AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!")
        Messaging.AddMessage("AskIfSaveEmptyJournal", "Journal Entry is Empty, do you still want to save this entry?", "Empty Journal")
        Messaging.AddMessage("AskLastRecordReachStartBeg", "This is the last matching record for the given text. Do you want to start search from the first record?", "Last Record Found.")
        Messaging.AddMessage("MsgAlreadyPosted", "Sorry this record has already been posted!", "Disallowed operation")
        Messaging.AddMessage("MsgAccountsNotAllowed", "Error on line {lineNumber}. Sorry {entryNames} accounts not allowed for this transaction!", "Invalid Entry")
        Messaging.AddMessage("MsgCannotPostUnreconciledEntry", "Sorry you can't post an un-reconciled entry!", "Disallowed operation")
        Messaging.AddMessage("MsgCashAccountsNotAllowed", "Error on line <{lineNumber}>. Cash accounts not allowed for this transaction.", "Invalid Entry")
        Messaging.AddMessage("MsgDeletePaidEntryNotAllowed", "You can't delete this row because this entry has an existing payment and/or discount!", "Delete Error")
        Messaging.AddMessage("MsgDeleteRecordFailed", "This record was not deleted because of an error. Please try again later or ask Database Administrator for help.", "Deletion Error")
        Messaging.AddMessage("MsgDuplicateKeyValueViolation", "Cannot insert duplicate key row in object {tableName} with unique index {indexName}. The duplicate key value is {duplicateValue}!", "Unique Key Violation")
        Messaging.AddMessage("MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
        Messaging.AddMessage("MsgInvalidDate", "Invalid {dateField} Date entered, value must be between {startDate} and {endDate}!", "Invalid Date")
        Messaging.AddMessage("MsgMemberCannotBeAParentToItself", "Sorry a member cannot be a parent to itself.", "Invalid Parent")
        Messaging.AddMessage("MsgNoChangesMadeNothingToSave", "No changes made, nothing to save", "Nothing to save.")
        Messaging.AddMessage("MsgOnEmptyReconChangeAccNotAllowed", "Sorry you can't change the account to reconcile when account reconciliation grid is not empty. Previous value restored.", "Account change not allowed")
        Messaging.AddMessage("MsgPaymentCollExistChangeNotAllowed", "Sorry, this account receivable has already been partially or fully collected/discounted, changing account/customer not allowed. Value will revert to previous value.", "Modification Error")
        Messaging.AddMessage("MsgPaymentDiscExistChangeNotAllowed", "Sorry, this account payable has already been partially or fully paid/discounted, changing account/supplier not allowed. Value will revert to previous value.", "Modification Error")
        Messaging.AddMessage("MsgRecordChangedSinceLastRetrieval", "Record Has Changed since you last retrieved the record, cannot save your modifications. Please refresh the record and try again.", "Someone changed the record!")
        Messaging.AddMessage("MsgRecordSuccessfullyDeleted", "Record was successfully deleted.", "Record Deleted")
        Messaging.AddMessage("MsgRowDelNotAllowedInViewMode", "Row deletion not allowed while in view mode. Press edit button to enable deletion.", "Error")
        Messaging.AddMessage("MsgRowInsNotAllowedInViewMode", "Row insertion not allowed while in view mode. Press edit button to enable deletion.", "Error")
        Messaging.AddMessage("MsgSaveReconFirstBeforePosting", "Please save first your reconciliation before posting!", "Unsaved entries exist")
        Messaging.AddMessage("MsgTooManyFormsOpen", "Too many forms open. You can only open up to {maxOpenForms} forms at the same time.", "Too many forms open")
        Messaging.AddMessage("MsgDeleteCollEntryNotAllowed", "You can't delete this row because this entry has an existing collection and/or discount!", "Delete Error")
    End Sub

    Public Shared Sub CreateEnums()
        ResourceEnumConverter.MakeResource("AccountGroupSelection", GetType(AccountGroupSelection))
        ResourceEnumConverter.MakeResource("AccountStatusSelection", GetType(AccountStatusSelection))
        ResourceEnumConverter.MakeResource("DebitCreditSelection", GetType(DebitCreditSelection))
        ResourceEnumConverter.MakeResource("DocumentTypeSelection", GetType(DocumentTypeSelection))
        ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
        ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
        ResourceEnumConverter.MakeResource("PayeeTypeSelection", GetType(PayeeTypeSelection))
        ResourceEnumConverter.MakeResource("PaymentMethodSelection", GetType(PaymentMethodSelection))
        ResourceEnumConverter.MakeResource("PaymentTypeSelection", GetType(PaymentTypeSelection))
        ResourceEnumConverter.MakeResource("ProfitCenterTypeSelection", GetType(ProfitCenterTypeSelection))
        ResourceEnumConverter.MakeResource("ReceiptTypeSelection", GetType(ReceiptTypeSelection))
        ResourceEnumConverter.MakeResource("SecurityLevelSelection", GetType(SecurityLevelSelection))
        ResourceEnumConverter.MakeResource("SpecialAccountSelection", GetType(SpecialAccountSelection))
        ResourceEnumConverter.MakeResource("TransactionTypeSelection", GetType(TransactionTypeSelection))
        ResourceEnumConverter.MakeResource("YearMonthDaySelection", GetType(YearMonthDaySelection))
        ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))

    End Sub

End Class