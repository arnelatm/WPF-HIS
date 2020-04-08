Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class GeneralJournalPresenter
        Inherits AccountsPresenter(Of IGeneralJournalView, GeneralJournalModel)

        Public Sub New(view As IGeneralJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("GeneralJournal")
            TableName = "GeneralJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New GeneralJournalModel()
            DataModel = New GeneralJournalModel
        End Sub

        Public Property JournalItemsPresenter As GeneralJournalItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim generalJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    generalJournalChangesMade = True
                Else
                    generalJournalChangesMade = False
                End If
            Else
                generalJournalChangesMade = True
            End If
            Return generalJournalChangesMade
        End Function

        'Protected Overrides Function DataIsValid() As Boolean
        '    If MyBase.DataIsValid() Then
        '        DataModel = GlobalVariables.Mapper.Map(Of GeneralJournalModel)(View)
        '        With JournalItemsPresenter.View
        '            DataModel.JournalItems = .JournalItems
        '        End With
        '        Return JournalItemsPresenter.DataIsValid(DataModel)
        '    Else
        '        Return False
        '    End If
        'End Function

        'Public Shadows Sub Display(idNo As Integer)
        '    Dim modelData As GeneralJournalModel
        '    modelData = Model.GetRecordById(Of GeneralJournalModel)(idNo)
        '    If modelData IsNot Nothing Then
        '        OriginalModel = modelData
        '        If idNo <> 0 Then
        '            GlobalVariables.Mapper.Map(modelData, View)
        '        End If
        '    End If
        'End Sub

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

    End Class

End Namespace