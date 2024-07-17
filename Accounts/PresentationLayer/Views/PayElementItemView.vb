Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayElementItemView
        Implements IPayElementItemView

        Private _PayElementIdNo As Short

        Public Property ParentIdNo As Short Implements IPayElementItemView.ParentIdNo

        Public Property PayElementIdNo As Short Implements IPayElementItemView.PayElementIdNo
            Get
                Return _PayElementIdNo
            End Get
            Set(value As Short)
                _PayElementIdNo = value
                If FactorValue = 0 Then
                    FactorValue = 1
                End If
            End Set
        End Property

        Public Property IdNo As Int16 Implements IPayElementItemView.IdNo
        Public Property FactorType As String Implements IPayElementItemView.FactorType
        Public Property FactorValue As Decimal Implements IPayElementItemView.FactorValue
        Public Property Sequence As Int16 Implements IPayElementItemView.Sequence
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace