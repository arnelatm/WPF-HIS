Imports AATM.Libraries
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer

    Module AccountHelpers

        Public Sub CreateSpecialAccountDataSource(ea As EventAggregator, specialAccountArray As String(), Control As Control)
            If ea IsNot Nothing Then
                Dim filter As String = CreateSpecialAccountFilterKey(specialAccountArray)
                ea.PublishEvent(New GetDataSource("Account", Control, filter))
            End If
        End Sub

        Public Function CreateSpecialAccountFilterKey(specialAccountArray As String()) As String
            Dim lookUpFilterKey = ""
            For Each specialAccountCode In specialAccountArray
                If lookUpFilterKey <> "" Then
                    lookUpFilterKey = lookUpFilterKey + " Or "
                End If
                lookUpFilterKey = lookUpFilterKey + "SpecialAccount = '" & specialAccountCode & "'"
            Next
            Return "DetailAccount=1 and (" + lookUpFilterKey + ")"
        End Function

    End Module
End Namespace