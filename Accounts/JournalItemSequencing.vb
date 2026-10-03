Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Friend Module JournalItemSequencing

    Public Sub Normalize(items As List(Of JournalItem), Optional firstAccountIdNo As Integer? = Nothing)
        NormalizeItems(items, Function(item) item.AccountIdNo,
                       Function(item) item.Debit <> 0D OrElse item.Credit <> 0D,
                       Function(item) item.Sequence,
                       Sub(item, sequence) item.Sequence = sequence, firstAccountIdNo)
    End Sub

    Public Sub Normalize(items As List(Of JournalItemModel), Optional firstAccountIdNo As Integer? = Nothing)
        NormalizeItems(items, Function(item) item.AccountIdNo,
                       Function(item) item.Debit <> 0D OrElse item.Credit <> 0D,
                       Function(item) item.Sequence,
                       Sub(item, sequence) item.Sequence = sequence, firstAccountIdNo)
    End Sub

    Public Sub Normalize(items As List(Of JournalItemView), Optional firstAccountIdNo As Integer? = Nothing)
        NormalizeItems(items, Function(item) item.AccountIdNo,
                       Function(item) item.Debit <> 0D OrElse item.Credit <> 0D,
                       Function(item) item.Sequence,
                       Sub(item, sequence) item.Sequence = sequence, firstAccountIdNo)
    End Sub

    Private Sub NormalizeItems(Of T As Class)(items As List(Of T),
                                             accountId As Func(Of T, Short?),
                                             includeItem As Func(Of T, Boolean),
                                             getSequence As Func(Of T, Short),
                                             setSequence As Action(Of T, Short),
                                             firstAccountIdNo As Integer?)
        If items Is Nothing Then Return

        If firstAccountIdNo.HasValue AndAlso firstAccountIdNo.Value > 0 Then
            'Prefer the existing header line when several lines use the same account.
            Dim firstIndex = items.FindIndex(Function(item) item IsNot Nothing AndAlso
                accountId(item).HasValue AndAlso accountId(item).Value = firstAccountIdNo.Value AndAlso
                getSequence(item) = 1)
            If firstIndex < 0 Then
                firstIndex = items.FindIndex(Function(item) item IsNot Nothing AndAlso
                    accountId(item).HasValue AndAlso accountId(item).Value = firstAccountIdNo.Value)
            End If
            If firstIndex > 0 Then
                Dim firstItem = items(firstIndex)
                items.RemoveAt(firstIndex)
                items.Insert(0, firstItem)
            End If
        End If

        Dim sequence As Integer = 0
        For Each item In items
            If item Is Nothing Then Continue For
            If includeItem(item) Then
                sequence += 1
                setSequence(item, Convert.ToInt16(sequence))
            Else
                'Zero-value placeholders are not persisted and must not create gaps.
                setSequence(item, 0S)
            End If
        Next
    End Sub

End Module
