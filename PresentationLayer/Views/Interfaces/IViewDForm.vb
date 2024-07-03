Imports System.Windows.Forms



Public Interface IViewDFormBase
    Property MainFieldsDictionary

End Interface

Public Interface IViewDFormEntry
    Inherits IViewDFormBase

    Property AddingAllowed As Boolean
    Property AddingMode As Boolean
    Property AddOnOpen As Boolean
    Property AutoAddOnSave As Boolean
    Property DeletingAllowed As Boolean
    Property DisallowSaves As Boolean
    Property EditingAllowed As Boolean
    Property EditingMode As Boolean
    Property FirstControl As Control
    Property InputTurnedOn As Boolean
    Property ParentFieldName As String
    Property QuitOnSave As Boolean
    Property RecordDateTimeStampValue As Object
    Property RecordCount As Integer
    Property RecordPositionNumber As Integer
    Property SingleData As Boolean

    Event AfterUpdateView()
    Event AfterSave()
    Event InputsTurnedOn()
    Event InputsTurnedOff()
    Event AfterChangeRecord()
    Event BeforeChangeRecord()
    Event RecordPositionChanged()

End Interface